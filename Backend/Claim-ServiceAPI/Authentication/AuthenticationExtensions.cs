using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Claim_ServiceAPI.Authentication;

public static class AuthenticationExtensions
{
    public static IServiceCollection AddClaimServiceAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        var jwtSettings = configuration.GetSection(JwtSettings.SectionName).Get<JwtSettings>()
            ?? throw new InvalidOperationException("JWT settings were not found.");

        if (string.IsNullOrWhiteSpace(jwtSettings.SecretKey) || jwtSettings.SecretKey.Length < 32)
        {
            throw new InvalidOperationException("JWT secret key must be at least 32 characters long.");
        }

        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = jwtSettings.ValidateIssuer,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidateAudience = jwtSettings.ValidateAudience,
                    ValidAudience = jwtSettings.Audience,
                    ValidateLifetime = jwtSettings.ValidateLifetime,
                    ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
                    IssuerSigningKey = signingKey,
                    ClockSkew = TimeSpan.FromMinutes(jwtSettings.ClockSkewMinutes)
                };
            });

        services.AddAuthorization(options =>
        {
            options.AddPolicy(ClaimServicePolicies.ClaimRead, policy =>
                policy.RequireAuthenticatedUser().RequireRole(
                    ClaimServiceRoles.Customer,
                    ClaimServiceRoles.Agent,
                    ClaimServiceRoles.Underwriter,
                    ClaimServiceRoles.ClaimsOfficer,
                    ClaimServiceRoles.FinanceTeam,
                    ClaimServiceRoles.CustomerSupport,
                    ClaimServiceRoles.Administrator,
                    ClaimServiceRoles.Management));

            options.AddPolicy(ClaimServicePolicies.ClaimCreate, policy =>
                policy.RequireAuthenticatedUser().RequireRole(
                    ClaimServiceRoles.Customer,
                    ClaimServiceRoles.Agent,
                    ClaimServiceRoles.ClaimsOfficer,
                    ClaimServiceRoles.Administrator));

            options.AddPolicy(ClaimServicePolicies.ClaimUpdate, policy =>
                policy.RequireAuthenticatedUser().RequireRole(
                    ClaimServiceRoles.ClaimsOfficer,
                    ClaimServiceRoles.Administrator,
                    ClaimServiceRoles.CustomerSupport));

            options.AddPolicy(ClaimServicePolicies.ClaimAssessmentManage, policy =>
                policy.RequireAuthenticatedUser().RequireRole(
                    ClaimServiceRoles.ClaimsOfficer,
                    ClaimServiceRoles.Underwriter,
                    ClaimServiceRoles.Administrator));

            options.AddPolicy(ClaimServicePolicies.ClaimSettlementManage, policy =>
                policy.RequireAuthenticatedUser().RequireRole(
                    ClaimServiceRoles.ClaimsOfficer,
                    ClaimServiceRoles.FinanceTeam,
                    ClaimServiceRoles.Administrator));

            options.AddPolicy(ClaimServicePolicies.ClaimPartyManage, policy =>
                policy.RequireAuthenticatedUser().RequireRole(
                    ClaimServiceRoles.Customer,
                    ClaimServiceRoles.Agent,
                    ClaimServiceRoles.ClaimsOfficer,
                    ClaimServiceRoles.Administrator));

            options.AddPolicy(ClaimServicePolicies.ClaimHistoryManage, policy =>
                policy.RequireAuthenticatedUser().RequireRole(
                    ClaimServiceRoles.ClaimsOfficer,
                    ClaimServiceRoles.CustomerSupport,
                    ClaimServiceRoles.Administrator,
                    ClaimServiceRoles.Management));

            options.AddPolicy(ClaimServicePolicies.ClaimLookupRead, policy =>
                policy.RequireAuthenticatedUser().RequireRole(
                    ClaimServiceRoles.Customer,
                    ClaimServiceRoles.Agent,
                    ClaimServiceRoles.Underwriter,
                    ClaimServiceRoles.ClaimsOfficer,
                    ClaimServiceRoles.FinanceTeam,
                    ClaimServiceRoles.CustomerSupport,
                    ClaimServiceRoles.Administrator,
                    ClaimServiceRoles.Management));
        });

        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter JWT Bearer token. Example: Bearer {token}"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        return services;
    }
}