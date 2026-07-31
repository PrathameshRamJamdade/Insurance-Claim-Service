using Claim_ServiceAPI.Authentication;
using Claim_ServiceAPI.Data;
using Claim_ServiceAPI.Repositories.Implementations;
using Claim_ServiceAPI.Repositories.Interfaces;
using Claim_ServiceAPI.Services.Implementations;
using Claim_ServiceAPI.Services.Interfaces;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;

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

builder.Services.AddClaimServiceAuthentication(builder.Configuration);

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

app.UseForwardedHeaders();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/health", () => Results.Ok(new { status = "healthy", service = "Claim Service API" }))
    .AllowAnonymous();

app.MapControllers();

app.Run();
