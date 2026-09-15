using Claim_ServiceAPI.Authentication;
using Claim_ServiceAPI.Data;
using Claim_ServiceAPI.Repositories.Implementations;
using Claim_ServiceAPI.Repositories.Interfaces;
using Claim_ServiceAPI.Services.Implementations;
using Claim_ServiceAPI.Services.Interfaces;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT");
if (!string.IsNullOrWhiteSpace(port))
{
    builder.WebHost.UseUrls($"http://*:{port}");
}

// Add services to the container.

var claimServiceConnectionString = builder.Configuration.GetConnectionString("ClaimServiceDb")
    ?? throw new InvalidOperationException("Connection string 'ClaimServiceDb' was not found.");

builder.Services.AddDbContext<ClaimDbContext>(options =>
    options.UseSqlServer(claimServiceConnectionString));

builder.Services.AddScoped<IClaimRepository, ClaimRepository>();
builder.Services.AddScoped<IClaimDocumentRepository, ClaimDocumentRepository>();
builder.Services.AddScoped<IClaimAssessmentRepository, ClaimAssessmentRepository>();
builder.Services.AddScoped<IClaimSettlementRepository, ClaimSettlementRepository>();
builder.Services.AddScoped<IClaimPartyRepository, ClaimPartyRepository>();
builder.Services.AddScoped<IClaimHistoryRepository, ClaimHistoryRepository>();
builder.Services.AddScoped<IClaimLookupRepository, ClaimLookupRepository>();

builder.Services.AddScoped<IClaimService, ClaimService>();
builder.Services.AddScoped<IClaimDocumentService, ClaimDocumentService>();
builder.Services.AddScoped<IClaimAssessmentService, ClaimAssessmentService>();
builder.Services.AddScoped<IClaimSettlementService, ClaimSettlementService>();
builder.Services.AddScoped<IClaimPartyService, ClaimPartyService>();
builder.Services.AddScoped<IClaimHistoryService, ClaimHistoryService>();
builder.Services.AddScoped<IClaimLookupService, ClaimLookupService>();

var jwtKey = builder.Configuration["JWT_KEY"];
var jwtIssuer = builder.Configuration["JWT_ISSUER"];
var jwtAudience = builder.Configuration["JWT_AUDIENCE"];

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtKey
                    ?? throw new InvalidOperationException("JWT_KEY is missing."))),
            ValidateIssuer = true,
            ValidIssuer = jwtIssuer,
            ValidateAudience = true,
            ValidAudience = jwtAudience,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            RoleClaimType = ClaimTypes.Role,
            NameClaimType = ClaimTypes.Name
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(ClaimServicePolicies.ClaimRead, policy => policy
        .RequireAuthenticatedUser()
        .RequireAssertion(context =>
            context.User.IsInRole("ClaimsAdjuster") ||
            context.User.HasClaim("permission", "Claim.Read")));
});

builder.Services.AddClaimServiceAuthorization();

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

var publicBaseUrl = builder.Configuration["AppUrls:PublicBaseUrl"]?.TrimEnd('/');

using (var scope = app.Services.CreateScope())
{
    var claimDbContext = scope.ServiceProvider.GetRequiredService<ClaimDbContext>();
    await claimDbContext.Database.MigrateAsync();
}

app.UseForwardedHeaders();

// Configure the HTTP request pipeline.
app.UseSwagger(options =>
{
    options.PreSerializeFilters.Add((swagger, httpRequest) =>
    {
        var serverUrl = !string.IsNullOrWhiteSpace(publicBaseUrl)
            ? publicBaseUrl
            : $"{httpRequest.Scheme}://{httpRequest.Host.Value}";

        swagger.Servers = new List<OpenApiServer>
        {
            new()
            {
                Url = serverUrl
            }
        };
    });
});

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/health", () => Results.Ok(new { status = "healthy", service = "Claim Service API" }))
    .AllowAnonymous();

app.MapGet("/health/ready", () => Results.Ok(new { status = "ready", service = "Claim Service API" }))
    .AllowAnonymous();

app.MapGet("/", () => Results.Redirect("/swagger"))
    .AllowAnonymous();

app.MapControllers();

app.Run();
