using Claim_ServiceAPI.DTOs.Claims;
using Claim_ServiceAPI.Mappers;
using Claim_ServiceAPI.Repositories.Interfaces;
using Claim_ServiceAPI.Services.Interfaces;

namespace Claim_ServiceAPI.Services.Implementations;

public class ClaimSettlementService : IClaimSettlementService
{
    private readonly IClaimSettlementRepository _claimSettlementRepository;
    private readonly IClaimRepository _claimRepository;
    private readonly IClaimLookupRepository _claimLookupRepository;

    public ClaimSettlementService(
        IClaimSettlementRepository claimSettlementRepository,
        IClaimRepository claimRepository,
        IClaimLookupRepository claimLookupRepository)
    {
        _claimSettlementRepository = claimSettlementRepository;
        _claimRepository = claimRepository;
        _claimLookupRepository = claimLookupRepository;
    }

    public async Task<IReadOnlyList<ClaimSettlementDto>> GetByClaimIdAsync(long claimId, CancellationToken cancellationToken = default)
    {
        var settlements = await _claimSettlementRepository.GetByClaimIdAsync(claimId, cancellationToken);

        return settlements
            .Where(settlement => !settlement.IsDeleted)
            .Select(settlement => settlement.ToDto())
            .ToList();
    }

    public async Task<ClaimSettlementDto?> GetByIdAsync(long claimSettlementId, CancellationToken cancellationToken = default)
    {
        var settlement = await _claimSettlementRepository.GetByIdAsync(claimSettlementId, cancellationToken: cancellationToken);
        return settlement == null || settlement.IsDeleted ? null : settlement.ToDto();
    }

    public async Task<ClaimSettlementDto> CreateAsync(CreateClaimSettlementDto dto, CancellationToken cancellationToken = default)
    {
        await ClaimServiceSupport.EnsureClaimExistsAsync(_claimRepository, dto.ClaimId, cancellationToken);
        await EnsureReferencesAsync(dto.SettlementTypeId, dto.PaymentStatusId, cancellationToken);

        var claimSettlement = dto.ToEntity();
        ClaimServiceSupport.ApplyCreationAudit(claimSettlement);

        await _claimSettlementRepository.AddAsync(claimSettlement, cancellationToken);
        await _claimSettlementRepository.SaveChangesAsync(cancellationToken);

        var createdSettlement = await _claimSettlementRepository.GetByIdAsync(claimSettlement.ClaimSettlementId, cancellationToken: cancellationToken)
            ?? throw new InvalidOperationException("Claim settlement could not be loaded after creation.");

        return createdSettlement.ToDto();
    }

    public async Task<ClaimSettlementDto?> UpdateAsync(long claimSettlementId, UpdateClaimSettlementDto dto, CancellationToken cancellationToken = default)
    {
        var claimSettlement = await _claimSettlementRepository.GetByIdAsync(claimSettlementId, asNoTracking: false, cancellationToken: cancellationToken);

        if (claimSettlement == null || claimSettlement.IsDeleted)
        {
            return null;
        }

        await ClaimServiceSupport.EnsureClaimExistsAsync(_claimRepository, dto.ClaimId, cancellationToken);
        await EnsureReferencesAsync(dto.SettlementTypeId, dto.PaymentStatusId, cancellationToken);

        claimSettlement.MapFrom(dto);
        ClaimServiceSupport.ApplyUpdateAudit(claimSettlement);

        _claimSettlementRepository.Update(claimSettlement);
        await _claimSettlementRepository.SaveChangesAsync(cancellationToken);

        var updatedSettlement = await _claimSettlementRepository.GetByIdAsync(claimSettlementId, cancellationToken: cancellationToken)
            ?? throw new InvalidOperationException("Claim settlement could not be loaded after update.");

        return updatedSettlement.ToDto();
    }

    public async Task<bool> DeleteAsync(long claimSettlementId, CancellationToken cancellationToken = default)
    {
        var claimSettlement = await _claimSettlementRepository.GetByIdAsync(claimSettlementId, asNoTracking: false, cancellationToken: cancellationToken);

        if (claimSettlement == null || claimSettlement.IsDeleted)
        {
            return false;
        }

        ClaimServiceSupport.ApplySoftDelete(claimSettlement);
        _claimSettlementRepository.Update(claimSettlement);
        await _claimSettlementRepository.SaveChangesAsync(cancellationToken);

        return true;
    }

    private async Task EnsureReferencesAsync(int settlementTypeId, int paymentStatusId, CancellationToken cancellationToken)
    {
        if (await _claimLookupRepository.GetSettlementTypeByIdAsync(settlementTypeId, cancellationToken) == null)
        {
            throw new InvalidOperationException($"Settlement type '{settlementTypeId}' was not found.");
        }

        if (await _claimLookupRepository.GetPaymentStatusByIdAsync(paymentStatusId, cancellationToken) == null)
        {
            throw new InvalidOperationException($"Payment status '{paymentStatusId}' was not found.");
        }
    }
}