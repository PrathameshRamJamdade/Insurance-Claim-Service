using Claim_ServiceAPI.Data;
using Claim_ServiceAPI.Models.Claims;
using Claim_ServiceAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Claim_ServiceAPI.Repositories.Implementations;

public class ClaimRepository : IClaimRepository
{
    private readonly ClaimDbContext _context;

    public ClaimRepository(ClaimDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Claim>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await BuildBaseQuery(asNoTracking: true)
            .OrderByDescending(claim => claim.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Claim>> GetByCustomerIdAsync(long customerId, CancellationToken cancellationToken = default)
    {
        return await BuildBaseQuery(asNoTracking: true)
            .Where(claim => claim.CustomerId == customerId)
            .OrderByDescending(claim => claim.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Claim>> GetByCustomerIdentityIdAsync(Guid customerIdentityId, CancellationToken cancellationToken = default)
    {
        return await BuildBaseQuery(asNoTracking: true)
            .Where(claim => claim.CustomerIdentityId == customerIdentityId)
            .OrderByDescending(claim => claim.CreatedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<Claim?> GetByIdAsync(long claimId, bool includeDetails = false, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        var query = includeDetails
            ? BuildDetailQuery(asNoTracking)
            : BuildBaseQuery(asNoTracking);

        return await query.FirstOrDefaultAsync(claim => claim.ClaimId == claimId, cancellationToken);
    }

    public async Task<Claim?> GetByClaimNumberAsync(string claimNumber, bool includeDetails = false, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        var query = includeDetails
            ? BuildDetailQuery(asNoTracking)
            : BuildBaseQuery(asNoTracking);

        return await query.FirstOrDefaultAsync(claim => claim.ClaimNumber == claimNumber, cancellationToken);
    }

    public Task<bool> ExistsAsync(long claimId, CancellationToken cancellationToken = default)
    {
        return _context.Claims.AnyAsync(claim => claim.ClaimId == claimId, cancellationToken);
    }

    public Task<bool> ClaimNumberExistsAsync(string claimNumber, long? excludedClaimId = null, CancellationToken cancellationToken = default)
    {
        return _context.Claims.AnyAsync(claim =>
            claim.ClaimNumber == claimNumber &&
            (!excludedClaimId.HasValue || claim.ClaimId != excludedClaimId.Value), cancellationToken);
    }

    public Task AddAsync(Claim claim, CancellationToken cancellationToken = default)
    {
        return _context.Claims.AddAsync(claim, cancellationToken).AsTask();
    }

    public void Update(Claim claim)
    {
        _context.Claims.Update(claim);
    }

    public void Remove(Claim claim)
    {
        _context.Claims.Remove(claim);
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }

    private IQueryable<Claim> BuildBaseQuery(bool asNoTracking)
    {
        var query = _context.Claims
            .Include(claim => claim.ClaimType)
            .Include(claim => claim.ClaimStatus)
            .Include(claim => claim.Priority)
            .AsQueryable();

        return asNoTracking ? query.AsNoTracking() : query;
    }

    private IQueryable<Claim> BuildDetailQuery(bool asNoTracking)
    {
        var query = _context.Claims
            .Include(claim => claim.ClaimType)
            .Include(claim => claim.ClaimStatus)
            .Include(claim => claim.Priority)
            .Include(claim => claim.Documents)
                .ThenInclude(document => document.DocumentType)
            .Include(claim => claim.Documents)
                .ThenInclude(document => document.VerificationStatus)
            .Include(claim => claim.Assessments)
                .ThenInclude(assessment => assessment.AssessmentStatus)
            .Include(claim => claim.StatusHistory)
                .ThenInclude(statusHistory => statusHistory.PreviousStatus)
            .Include(claim => claim.StatusHistory)
                .ThenInclude(statusHistory => statusHistory.CurrentStatus)
            .Include(claim => claim.ActionHistory)
                .ThenInclude(actionHistory => actionHistory.ActionType)
            .Include(claim => claim.Settlements)
                .ThenInclude(settlement => settlement.SettlementType)
            .Include(claim => claim.Settlements)
                .ThenInclude(settlement => settlement.PaymentStatus)
            .Include(claim => claim.Parties)
                .ThenInclude(party => party.PartyType)
            .AsSplitQuery()
            .AsQueryable();

        return asNoTracking ? query.AsNoTracking() : query;
    }
}