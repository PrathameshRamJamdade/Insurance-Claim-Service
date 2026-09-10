using Microsoft.OpenApi.Models;

namespace Claim_ServiceAPI.Authentication;

public static class AuthenticationExtensions
{
    public static IServiceCollection AddClaimServiceAuthorization(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
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