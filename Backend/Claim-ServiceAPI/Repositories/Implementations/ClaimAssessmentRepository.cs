using Claim_ServiceAPI.Data;
using Claim_ServiceAPI.Models.Claims;
using Claim_ServiceAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Claim_ServiceAPI.Repositories.Implementations;

public class ClaimAssessmentRepository : IClaimAssessmentRepository
{
    private readonly ClaimDbContext _context;

    public ClaimAssessmentRepository(ClaimDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<ClaimAssessment>> GetByClaimIdAsync(long claimId, CancellationToken cancellationToken = default)
    {
        return await _context.ClaimAssessments
            .AsNoTracking()
            .Include(claimAssessment => claimAssessment.AssessmentStatus)
            .Where(claimAssessment => claimAssessment.ClaimId == claimId)
            .OrderByDescending(claimAssessment => claimAssessment.AssessmentDate)
            .ToListAsync(cancellationToken);
    }

    public async Task<ClaimAssessment?> GetByIdAsync(long claimAssessmentId, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        var query = _context.ClaimAssessments
            .Include(claimAssessment => claimAssessment.AssessmentStatus)
            .AsQueryable();

        if (asNoTracking)
        {
            query = query.AsNoTracking();
        }

        return await query.FirstOrDefaultAsync(claimAssessment => claimAssessment.ClaimAssessmentId == claimAssessmentId, cancellationToken);
    }

    public Task AddAsync(ClaimAssessment claimAssessment, CancellationToken cancellationToken = default)
    {
        return _context.ClaimAssessments.AddAsync(claimAssessment, cancellationToken).AsTask();
    }

    public void Update(ClaimAssessment claimAssessment)
    {
        _context.ClaimAssessments.Update(claimAssessment);
    }

    public void Remove(ClaimAssessment claimAssessment)
    {
        _context.ClaimAssessments.Remove(claimAssessment);
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}