using Claim_ServiceAPI.Data;
using Claim_ServiceAPI.Models.Claims;
using Claim_ServiceAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Claim_ServiceAPI.Repositories.Implementations;

public class ClaimHistoryRepository : IClaimHistoryRepository
{
    private readonly ClaimDbContext _context;

    public ClaimHistoryRepository(ClaimDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<ClaimStatusHistory>> GetStatusHistoryByClaimIdAsync(long claimId, CancellationToken cancellationToken = default)
    {
        return await _context.ClaimStatusHistories
            .AsNoTracking()
            .Include(history => history.PreviousStatus)
            .Include(history => history.CurrentStatus)
            .Where(history => history.ClaimId == claimId)
            .OrderByDescending(history => history.ChangedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<ClaimActionHistory>> GetActionHistoryByClaimIdAsync(long claimId, CancellationToken cancellationToken = default)
    {
        return await _context.ClaimActionHistories
            .AsNoTracking()
            .Include(history => history.ActionType)
            .Where(history => history.ClaimId == claimId)
            .OrderByDescending(history => history.ActionAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<ClaimStatusHistory?> GetStatusHistoryByIdAsync(long claimStatusHistoryId, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        var query = _context.ClaimStatusHistories
            .Include(history => history.PreviousStatus)
            .Include(history => history.CurrentStatus)
            .AsQueryable();

        if (asNoTracking)
        {
            query = query.AsNoTracking();
        }

        return await query.FirstOrDefaultAsync(history => history.ClaimStatusHistoryId == claimStatusHistoryId, cancellationToken);
    }

    public async Task<ClaimActionHistory?> GetActionHistoryByIdAsync(long claimActionHistoryId, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        var query = _context.ClaimActionHistories
            .Include(history => history.ActionType)
            .AsQueryable();

        if (asNoTracking)
        {
            query = query.AsNoTracking();
        }

        return await query.FirstOrDefaultAsync(history => history.ClaimActionHistoryId == claimActionHistoryId, cancellationToken);
    }

    public Task AddStatusHistoryAsync(ClaimStatusHistory claimStatusHistory, CancellationToken cancellationToken = default)
    {
        return _context.ClaimStatusHistories.AddAsync(claimStatusHistory, cancellationToken).AsTask();
    }

    public Task AddActionHistoryAsync(ClaimActionHistory claimActionHistory, CancellationToken cancellationToken = default)
    {
        return _context.ClaimActionHistories.AddAsync(claimActionHistory, cancellationToken).AsTask();
    }

    public void RemoveStatusHistory(ClaimStatusHistory claimStatusHistory)
    {
        _context.ClaimStatusHistories.Remove(claimStatusHistory);
    }

    public void RemoveActionHistory(ClaimActionHistory claimActionHistory)
    {
        _context.ClaimActionHistories.Remove(claimActionHistory);
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}