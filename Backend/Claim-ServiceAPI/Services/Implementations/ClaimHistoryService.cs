using Claim_ServiceAPI.DTOs.Claims;
using Claim_ServiceAPI.Mappers;
using Claim_ServiceAPI.Repositories.Interfaces;
using Claim_ServiceAPI.Services.Interfaces;

namespace Claim_ServiceAPI.Services.Implementations;

public class ClaimHistoryService : IClaimHistoryService
{
    private readonly IClaimHistoryRepository _claimHistoryRepository;
    private readonly IClaimRepository _claimRepository;
    private readonly IClaimLookupRepository _claimLookupRepository;

    public ClaimHistoryService(
        IClaimHistoryRepository claimHistoryRepository,
        IClaimRepository claimRepository,
        IClaimLookupRepository claimLookupRepository)
    {
        _claimHistoryRepository = claimHistoryRepository;
        _claimRepository = claimRepository;
        _claimLookupRepository = claimLookupRepository;
    }

    public async Task<IReadOnlyList<ClaimStatusHistoryDto>> GetStatusHistoryByClaimIdAsync(long claimId, CancellationToken cancellationToken = default)
    {
        var statusHistory = await _claimHistoryRepository.GetStatusHistoryByClaimIdAsync(claimId, cancellationToken);
        return statusHistory.Select(history => history.ToDto()).ToList();
    }

    public async Task<IReadOnlyList<ClaimActionHistoryDto>> GetActionHistoryByClaimIdAsync(long claimId, CancellationToken cancellationToken = default)
    {
        var actionHistory = await _claimHistoryRepository.GetActionHistoryByClaimIdAsync(claimId, cancellationToken);
        return actionHistory.Select(history => history.ToDto()).ToList();
    }

    public async Task<ClaimStatusHistoryDto> CreateStatusHistoryAsync(CreateClaimStatusHistoryDto dto, CancellationToken cancellationToken = default)
    {
        await ClaimServiceSupport.EnsureClaimExistsAsync(_claimRepository, dto.ClaimId, cancellationToken);

        if (dto.PreviousStatusId.HasValue && await _claimLookupRepository.GetClaimStatusByIdAsync(dto.PreviousStatusId.Value, cancellationToken) == null)
        {
            throw new InvalidOperationException($"Previous claim status '{dto.PreviousStatusId.Value}' was not found.");
        }

        if (await _claimLookupRepository.GetClaimStatusByIdAsync(dto.CurrentStatusId, cancellationToken) == null)
        {
            throw new InvalidOperationException($"Current claim status '{dto.CurrentStatusId}' was not found.");
        }

        var entity = dto.ToEntity();

        await _claimHistoryRepository.AddStatusHistoryAsync(entity, cancellationToken);
        await _claimHistoryRepository.SaveChangesAsync(cancellationToken);

        var createdHistory = await _claimHistoryRepository.GetStatusHistoryByIdAsync(entity.ClaimStatusHistoryId, cancellationToken: cancellationToken)
            ?? throw new InvalidOperationException("Claim status history could not be loaded after creation.");

        return createdHistory.ToDto();
    }

    public async Task<ClaimActionHistoryDto> CreateActionHistoryAsync(CreateClaimActionHistoryDto dto, CancellationToken cancellationToken = default)
    {
        await ClaimServiceSupport.EnsureClaimExistsAsync(_claimRepository, dto.ClaimId, cancellationToken);

        if (await _claimLookupRepository.GetClaimActionTypeByIdAsync(dto.ActionTypeId, cancellationToken) == null)
        {
            throw new InvalidOperationException($"Claim action type '{dto.ActionTypeId}' was not found.");
        }

        var entity = dto.ToEntity();

        await _claimHistoryRepository.AddActionHistoryAsync(entity, cancellationToken);
        await _claimHistoryRepository.SaveChangesAsync(cancellationToken);

        var createdHistory = await _claimHistoryRepository.GetActionHistoryByIdAsync(entity.ClaimActionHistoryId, cancellationToken: cancellationToken)
            ?? throw new InvalidOperationException("Claim action history could not be loaded after creation.");

        return createdHistory.ToDto();
    }

    public async Task<bool> DeleteStatusHistoryAsync(long claimStatusHistoryId, CancellationToken cancellationToken = default)
    {
        var entity = await _claimHistoryRepository.GetStatusHistoryByIdAsync(claimStatusHistoryId, asNoTracking: false, cancellationToken: cancellationToken);

        if (entity == null)
        {
            return false;
        }

        _claimHistoryRepository.RemoveStatusHistory(entity);
        await _claimHistoryRepository.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> DeleteActionHistoryAsync(long claimActionHistoryId, CancellationToken cancellationToken = default)
    {
        var entity = await _claimHistoryRepository.GetActionHistoryByIdAsync(claimActionHistoryId, asNoTracking: false, cancellationToken: cancellationToken);

        if (entity == null)
        {
            return false;
        }

        _claimHistoryRepository.RemoveActionHistory(entity);
        await _claimHistoryRepository.SaveChangesAsync(cancellationToken);

        return true;
    }
}