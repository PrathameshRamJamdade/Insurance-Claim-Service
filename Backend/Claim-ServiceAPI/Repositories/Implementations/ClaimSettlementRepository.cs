using Claim_ServiceAPI.Data;
using Claim_ServiceAPI.Models.Claims;
using Claim_ServiceAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Claim_ServiceAPI.Repositories.Implementations;

public class ClaimSettlementRepository : IClaimSettlementRepository
{
    private readonly ClaimDbContext _context;

    public ClaimSettlementRepository(ClaimDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<ClaimSettlement>> GetByClaimIdAsync(long claimId, CancellationToken cancellationToken = default)
    {
        return await _context.ClaimSettlements
            .AsNoTracking()
            .Include(claimSettlement => claimSettlement.SettlementType)
            .Include(claimSettlement => claimSettlement.PaymentStatus)
            .Where(claimSettlement => claimSettlement.ClaimId == claimId)
            .OrderByDescending(claimSettlement => claimSettlement.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<ClaimSettlement?> GetByIdAsync(long claimSettlementId, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        var query = _context.ClaimSettlements
            .Include(claimSettlement => claimSettlement.SettlementType)
            .Include(claimSettlement => claimSettlement.PaymentStatus)
            .AsQueryable();

        if (asNoTracking)
        {
            query = query.AsNoTracking();
        }

        return await query.FirstOrDefaultAsync(claimSettlement => claimSettlement.ClaimSettlementId == claimSettlementId, cancellationToken);
    }

    public Task AddAsync(ClaimSettlement claimSettlement, CancellationToken cancellationToken = default)
    {
        return _context.ClaimSettlements.AddAsync(claimSettlement, cancellationToken).AsTask();
    }

    public void Update(ClaimSettlement claimSettlement)
    {
        _context.ClaimSettlements.Update(claimSettlement);
    }

    public void Remove(ClaimSettlement claimSettlement)
    {
        _context.ClaimSettlements.Remove(claimSettlement);
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}