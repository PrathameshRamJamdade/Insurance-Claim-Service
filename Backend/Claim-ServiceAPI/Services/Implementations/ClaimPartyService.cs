using Claim_ServiceAPI.DTOs.Claims;
using Claim_ServiceAPI.Mappers;
using Claim_ServiceAPI.Repositories.Interfaces;
using Claim_ServiceAPI.Services.Interfaces;

namespace Claim_ServiceAPI.Services.Implementations;

public class ClaimPartyService : IClaimPartyService
{
    private readonly IClaimPartyRepository _claimPartyRepository;
    private readonly IClaimRepository _claimRepository;
    private readonly IClaimLookupRepository _claimLookupRepository;

    public ClaimPartyService(
        IClaimPartyRepository claimPartyRepository,
        IClaimRepository claimRepository,
        IClaimLookupRepository claimLookupRepository)
    {
        _claimPartyRepository = claimPartyRepository;
        _claimRepository = claimRepository;
        _claimLookupRepository = claimLookupRepository;
    }

    public async Task<IReadOnlyList<ClaimPartyDto>> GetByClaimIdAsync(long claimId, CancellationToken cancellationToken = default)
    {
        var parties = await _claimPartyRepository.GetByClaimIdAsync(claimId, cancellationToken);

        return parties
            .Where(party => !party.IsDeleted)
            .Select(party => party.ToDto())
            .ToList();
    }

    public async Task<ClaimPartyDto?> GetByIdAsync(long claimPartyId, CancellationToken cancellationToken = default)
    {
        var party = await _claimPartyRepository.GetByIdAsync(claimPartyId, cancellationToken: cancellationToken);
        return party == null || party.IsDeleted ? null : party.ToDto();
    }

    public async Task<ClaimPartyDto> CreateAsync(CreateClaimPartyDto dto, CancellationToken cancellationToken = default)
    {
        await ClaimServiceSupport.EnsureClaimExistsAsync(_claimRepository, dto.ClaimId, cancellationToken);

        if (await _claimLookupRepository.GetClaimPartyTypeByIdAsync(dto.PartyTypeId, cancellationToken) == null)
        {
            throw new InvalidOperationException($"Claim party type '{dto.PartyTypeId}' was not found.");
        }

        var claimParty = dto.ToEntity();
        ClaimServiceSupport.ApplyCreationAudit(claimParty);

        await _claimPartyRepository.AddAsync(claimParty, cancellationToken);
        await _claimPartyRepository.SaveChangesAsync(cancellationToken);

        var createdParty = await _claimPartyRepository.GetByIdAsync(claimParty.ClaimPartyId, cancellationToken: cancellationToken)
            ?? throw new InvalidOperationException("Claim party could not be loaded after creation.");

        return createdParty.ToDto();
    }

    public async Task<ClaimPartyDto?> UpdateAsync(long claimPartyId, UpdateClaimPartyDto dto, CancellationToken cancellationToken = default)
    {
        var claimParty = await _claimPartyRepository.GetByIdAsync(claimPartyId, asNoTracking: false, cancellationToken: cancellationToken);

        if (claimParty == null || claimParty.IsDeleted)
        {
            return null;
        }

        await ClaimServiceSupport.EnsureClaimExistsAsync(_claimRepository, dto.ClaimId, cancellationToken);

        if (await _claimLookupRepository.GetClaimPartyTypeByIdAsync(dto.PartyTypeId, cancellationToken) == null)
        {
            throw new InvalidOperationException($"Claim party type '{dto.PartyTypeId}' was not found.");
        }

        claimParty.MapFrom(dto);
        ClaimServiceSupport.ApplyUpdateAudit(claimParty);

        _claimPartyRepository.Update(claimParty);
        await _claimPartyRepository.SaveChangesAsync(cancellationToken);

        var updatedParty = await _claimPartyRepository.GetByIdAsync(claimPartyId, cancellationToken: cancellationToken)
            ?? throw new InvalidOperationException("Claim party could not be loaded after update.");

        return updatedParty.ToDto();
    }

    public async Task<bool> DeleteAsync(long claimPartyId, CancellationToken cancellationToken = default)
    {
        var claimParty = await _claimPartyRepository.GetByIdAsync(claimPartyId, asNoTracking: false, cancellationToken: cancellationToken);

        if (claimParty == null || claimParty.IsDeleted)
        {
            return false;
        }

        ClaimServiceSupport.ApplySoftDelete(claimParty);
        _claimPartyRepository.Update(claimParty);
        await _claimPartyRepository.SaveChangesAsync(cancellationToken);

        return true;
    }
}