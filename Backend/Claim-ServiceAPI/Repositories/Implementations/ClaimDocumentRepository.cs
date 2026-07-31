using Claim_ServiceAPI.Data;
using Claim_ServiceAPI.Models.Claims;
using Claim_ServiceAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Claim_ServiceAPI.Repositories.Implementations;

public class ClaimDocumentRepository : IClaimDocumentRepository
{
    private readonly ClaimDbContext _context;

    public ClaimDocumentRepository(ClaimDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<ClaimDocument>> GetByClaimIdAsync(long claimId, CancellationToken cancellationToken = default)
    {
        return await _context.ClaimDocuments
            .AsNoTracking()
            .Include(claimDocument => claimDocument.DocumentType)
            .Include(claimDocument => claimDocument.VerificationStatus)
            .Where(claimDocument => claimDocument.ClaimId == claimId)
            .OrderByDescending(claimDocument => claimDocument.UploadedAt)
            .ToListAsync(cancellationToken);
    }

    public async Task<ClaimDocument?> GetByIdAsync(long claimDocumentId, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        var query = _context.ClaimDocuments
            .Include(claimDocument => claimDocument.DocumentType)
            .Include(claimDocument => claimDocument.VerificationStatus)
            .AsQueryable();

        if (asNoTracking)
        {
            query = query.AsNoTracking();
        }

        return await query.FirstOrDefaultAsync(claimDocument => claimDocument.ClaimDocumentId == claimDocumentId, cancellationToken);
    }

    public Task AddAsync(ClaimDocument claimDocument, CancellationToken cancellationToken = default)
    {
        return _context.ClaimDocuments.AddAsync(claimDocument, cancellationToken).AsTask();
    }

    public void Update(ClaimDocument claimDocument)
    {
        _context.ClaimDocuments.Update(claimDocument);
    }

    public void Remove(ClaimDocument claimDocument)
    {
        _context.ClaimDocuments.Remove(claimDocument);
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}