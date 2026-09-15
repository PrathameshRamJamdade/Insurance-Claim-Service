using Claim_ServiceAPI.DTOs.Claims;
using Claim_ServiceAPI.Mappers;
using Claim_ServiceAPI.Repositories.Interfaces;
using Claim_ServiceAPI.Services.Interfaces;

namespace Claim_ServiceAPI.Services.Implementations;

public class ClaimService : IClaimService
{
    private readonly IClaimRepository _claimRepository;
    private readonly IClaimLookupRepository _claimLookupRepository;

    public ClaimService(IClaimRepository claimRepository, IClaimLookupRepository claimLookupRepository)
    {
        _claimRepository = claimRepository;
        _claimLookupRepository = claimLookupRepository;
    }

    public async Task<IReadOnlyList<ClaimSummaryDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var claims = await _claimRepository.GetAllAsync(cancellationToken);

        return claims
            .Where(claim => !claim.IsDeleted)
            .Select(claim => claim.ToSummaryDto())
            .ToList();
    }

    public async Task<IReadOnlyList<ClaimSummaryDto>> GetByCustomerIdAsync(long customerId, CancellationToken cancellationToken = default)
    {
        var claims = await _claimRepository.GetByCustomerIdAsync(customerId, cancellationToken);

        return claims
            .Where(claim => !claim.IsDeleted)
            .Select(claim => claim.ToSummaryDto())
            .ToList();
    }

    public async Task<IReadOnlyList<ClaimSummaryDto>> GetByCustomerIdentityIdAsync(Guid customerIdentityId, CancellationToken cancellationToken = default)
    {
        var claims = await _claimRepository.GetByCustomerIdentityIdAsync(customerIdentityId, cancellationToken);

        return claims
            .Where(claim => !claim.IsDeleted)
            .Select(claim => claim.ToSummaryDto())
            .ToList();
    }

    public async Task<ClaimDetailDto?> GetByIdAsync(long claimId, CancellationToken cancellationToken = default)
    {
        var claim = await _claimRepository.GetByIdAsync(claimId, includeDetails: true, cancellationToken: cancellationToken);

        return claim == null || claim.IsDeleted ? null : claim.ToDetailDto();
    }

    public async Task<ClaimDetailDto?> GetByClaimNumberAsync(string claimNumber, CancellationToken cancellationToken = default)
    {
        var claim = await _claimRepository.GetByClaimNumberAsync(claimNumber, includeDetails: true, cancellationToken: cancellationToken);

        return claim == null || claim.IsDeleted ? null : claim.ToDetailDto();
    }

    public async Task<ClaimDetailDto> CreateAsync(CreateClaimDto dto, CancellationToken cancellationToken = default)
    {
        return await CreateAsync(dto, Guid.Empty, cancellationToken);
    }

    public async Task<ClaimDetailDto> CreateAsync(CreateClaimDto dto, Guid customerIdentityId, CancellationToken cancellationToken = default)
    {
        await EnsureClaimReferencesAsync(dto.ClaimTypeId, dto.ClaimStatusId, dto.PriorityId, cancellationToken);

        if (await _claimRepository.ClaimNumberExistsAsync(dto.ClaimNumber, cancellationToken: cancellationToken))
        {
            throw new InvalidOperationException($"Claim number '{dto.ClaimNumber}' already exists.");
        }

        var claim = dto.ToEntity();
    claim.CustomerIdentityId = customerIdentityId;
        ClaimServiceSupport.ApplyCreationAudit(claim);

        await _claimRepository.AddAsync(claim, cancellationToken);
        await _claimRepository.SaveChangesAsync(cancellationToken);

        var createdClaim = await _claimRepository.GetByIdAsync(claim.ClaimId, includeDetails: true, cancellationToken: cancellationToken)
            ?? throw new InvalidOperationException("Claim could not be loaded after creation.");

        return createdClaim.ToDetailDto();
    }

    public async Task<ClaimDetailDto?> UpdateAsync(long claimId, UpdateClaimDto dto, CancellationToken cancellationToken = default)
    {
        var claim = await _claimRepository.GetByIdAsync(claimId, includeDetails: false, asNoTracking: false, cancellationToken: cancellationToken);

        if (claim == null || claim.IsDeleted)
        {
            return null;
        }

        await EnsureClaimReferencesAsync(dto.ClaimTypeId, dto.ClaimStatusId, dto.PriorityId, cancellationToken);

        if (await _claimRepository.ClaimNumberExistsAsync(dto.ClaimNumber, claimId, cancellationToken))
        {
            throw new InvalidOperationException($"Claim number '{dto.ClaimNumber}' already exists.");
        }

        claim.MapFrom(dto);
        ClaimServiceSupport.ApplyUpdateAudit(claim);

        _claimRepository.Update(claim);
        await _claimRepository.SaveChangesAsync(cancellationToken);

        var updatedClaim = await _claimRepository.GetByIdAsync(claimId, includeDetails: true, cancellationToken: cancellationToken)
            ?? throw new InvalidOperationException("Claim could not be loaded after update.");

        return updatedClaim.ToDetailDto();
    }

    public async Task<bool> DeleteAsync(long claimId, CancellationToken cancellationToken = default)
    {
        var claim = await _claimRepository.GetByIdAsync(claimId, includeDetails: false, asNoTracking: false, cancellationToken: cancellationToken);

        if (claim == null || claim.IsDeleted)
        {
            return false;
        }

        ClaimServiceSupport.ApplySoftDelete(claim);
        _claimRepository.Update(claim);
        await _claimRepository.SaveChangesAsync(cancellationToken);

        return true;
    }

    private async Task EnsureClaimReferencesAsync(int claimTypeId, int claimStatusId, int priorityId, CancellationToken cancellationToken)
    {
        if (await _claimLookupRepository.GetClaimTypeByIdAsync(claimTypeId, cancellationToken) == null)
        {
            throw new InvalidOperationException($"Claim type '{claimTypeId}' was not found.");
        }

        if (await _claimLookupRepository.GetClaimStatusByIdAsync(claimStatusId, cancellationToken) == null)
        {
            throw new InvalidOperationException($"Claim status '{claimStatusId}' was not found.");
        }

        if (await _claimLookupRepository.GetClaimPriorityByIdAsync(priorityId, cancellationToken) == null)
        {
            throw new InvalidOperationException($"Claim priority '{priorityId}' was not found.");
        }
    }
}