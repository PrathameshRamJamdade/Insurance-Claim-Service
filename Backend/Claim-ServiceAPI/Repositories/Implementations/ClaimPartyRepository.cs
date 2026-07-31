using Claim_ServiceAPI.Data;
using Claim_ServiceAPI.Models.Claims;
using Claim_ServiceAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Claim_ServiceAPI.Repositories.Implementations;

public class ClaimPartyRepository : IClaimPartyRepository
{
    private readonly ClaimDbContext _context;

    public ClaimPartyRepository(ClaimDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<ClaimParty>> GetByClaimIdAsync(long claimId, CancellationToken cancellationToken = default)
    {
        return await _context.ClaimParties
            .AsNoTracking()
            .Include(claimParty => claimParty.PartyType)
            .Where(claimParty => claimParty.ClaimId == claimId)
            .OrderBy(claimParty => claimParty.Name)
            .ToListAsync(cancellationToken);
    }

    public async Task<ClaimParty?> GetByIdAsync(long claimPartyId, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        var query = _context.ClaimParties
            .Include(claimParty => claimParty.PartyType)
            .AsQueryable();

        if (asNoTracking)
        {
            query = query.AsNoTracking();
        }

        return await query.FirstOrDefaultAsync(claimParty => claimParty.ClaimPartyId == claimPartyId, cancellationToken);
    }

    public Task AddAsync(ClaimParty claimParty, CancellationToken cancellationToken = default)
    {
        return _context.ClaimParties.AddAsync(claimParty, cancellationToken).AsTask();
    }

    public void Update(ClaimParty claimParty)
    {
        _context.ClaimParties.Update(claimParty);
    }

    public void Remove(ClaimParty claimParty)
    {
        _context.ClaimParties.Remove(claimParty);
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}