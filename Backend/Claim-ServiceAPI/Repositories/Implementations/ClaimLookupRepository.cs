using Claim_ServiceAPI.Data;
using Claim_ServiceAPI.Models.Claims.Lookups;
using Claim_ServiceAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Claim_ServiceAPI.Repositories.Implementations;

public class ClaimLookupRepository : IClaimLookupRepository
{
    private readonly ClaimDbContext _context;

    public ClaimLookupRepository(ClaimDbContext context)
    {
        _context = context;
    }

    public Task<IReadOnlyList<ClaimType>> GetClaimTypesAsync(bool activeOnly = true, CancellationToken cancellationToken = default)
        => GetLookupListAsync(_context.ClaimTypes, activeOnly, lookup => lookup.Name, cancellationToken);

    public Task<ClaimType?> GetClaimTypeByIdAsync(int claimTypeId, CancellationToken cancellationToken = default)
        => _context.ClaimTypes.AsNoTracking().FirstOrDefaultAsync(entity => entity.ClaimTypeId == claimTypeId, cancellationToken);

    public Task<IReadOnlyList<ClaimStatus>> GetClaimStatusesAsync(bool activeOnly = true, CancellationToken cancellationToken = default)
        => GetLookupListAsync(_context.ClaimStatuses, activeOnly, lookup => lookup.SequenceNo, cancellationToken);

    public Task<ClaimStatus?> GetClaimStatusByIdAsync(int claimStatusId, CancellationToken cancellationToken = default)
        => _context.ClaimStatuses.AsNoTracking().FirstOrDefaultAsync(entity => entity.ClaimStatusId == claimStatusId, cancellationToken);

    public Task<IReadOnlyList<ClaimPriority>> GetClaimPrioritiesAsync(bool activeOnly = true, CancellationToken cancellationToken = default)
        => GetLookupListAsync(_context.ClaimPriorities, activeOnly, lookup => lookup.Name, cancellationToken);

    public Task<ClaimPriority?> GetClaimPriorityByIdAsync(int priorityId, CancellationToken cancellationToken = default)
        => _context.ClaimPriorities.AsNoTracking().FirstOrDefaultAsync(entity => entity.PriorityId == priorityId, cancellationToken);

    public Task<IReadOnlyList<ClaimDocumentType>> GetClaimDocumentTypesAsync(bool activeOnly = true, CancellationToken cancellationToken = default)
        => GetLookupListAsync(_context.ClaimDocumentTypes, activeOnly, lookup => lookup.Name, cancellationToken);

    public Task<ClaimDocumentType?> GetClaimDocumentTypeByIdAsync(int documentTypeId, CancellationToken cancellationToken = default)
        => _context.ClaimDocumentTypes.AsNoTracking().FirstOrDefaultAsync(entity => entity.DocumentTypeId == documentTypeId, cancellationToken);

    public Task<IReadOnlyList<ClaimActionType>> GetClaimActionTypesAsync(bool activeOnly = true, CancellationToken cancellationToken = default)
        => GetLookupListAsync(_context.ClaimActionTypes, activeOnly, lookup => lookup.Name, cancellationToken);

    public Task<ClaimActionType?> GetClaimActionTypeByIdAsync(int actionTypeId, CancellationToken cancellationToken = default)
        => _context.ClaimActionTypes.AsNoTracking().FirstOrDefaultAsync(entity => entity.ActionTypeId == actionTypeId, cancellationToken);

    public Task<IReadOnlyList<AssessmentStatus>> GetAssessmentStatusesAsync(bool activeOnly = true, CancellationToken cancellationToken = default)
        => GetLookupListAsync(_context.AssessmentStatuses, activeOnly, lookup => lookup.Name, cancellationToken);

    public Task<AssessmentStatus?> GetAssessmentStatusByIdAsync(int assessmentStatusId, CancellationToken cancellationToken = default)
        => _context.AssessmentStatuses.AsNoTracking().FirstOrDefaultAsync(entity => entity.AssessmentStatusId == assessmentStatusId, cancellationToken);

    public Task<IReadOnlyList<SettlementType>> GetSettlementTypesAsync(bool activeOnly = true, CancellationToken cancellationToken = default)
        => GetLookupListAsync(_context.SettlementTypes, activeOnly, lookup => lookup.Name, cancellationToken);

    public Task<SettlementType?> GetSettlementTypeByIdAsync(int settlementTypeId, CancellationToken cancellationToken = default)
        => _context.SettlementTypes.AsNoTracking().FirstOrDefaultAsync(entity => entity.SettlementTypeId == settlementTypeId, cancellationToken);

    public Task<IReadOnlyList<PaymentStatus>> GetPaymentStatusesAsync(bool activeOnly = true, CancellationToken cancellationToken = default)
        => GetLookupListAsync(_context.PaymentStatuses, activeOnly, lookup => lookup.Name, cancellationToken);

    public Task<PaymentStatus?> GetPaymentStatusByIdAsync(int paymentStatusId, CancellationToken cancellationToken = default)
        => _context.PaymentStatuses.AsNoTracking().FirstOrDefaultAsync(entity => entity.PaymentStatusId == paymentStatusId, cancellationToken);

    public Task<IReadOnlyList<ClaimVerificationStatus>> GetClaimVerificationStatusesAsync(bool activeOnly = true, CancellationToken cancellationToken = default)
        => GetLookupListAsync(_context.ClaimVerificationStatuses, activeOnly, lookup => lookup.Name, cancellationToken);

    public Task<ClaimVerificationStatus?> GetClaimVerificationStatusByIdAsync(int verificationStatusId, CancellationToken cancellationToken = default)
        => _context.ClaimVerificationStatuses.AsNoTracking().FirstOrDefaultAsync(entity => entity.VerificationStatusId == verificationStatusId, cancellationToken);

    public Task<IReadOnlyList<ClaimPartyType>> GetClaimPartyTypesAsync(bool activeOnly = true, CancellationToken cancellationToken = default)
        => GetLookupListAsync(_context.ClaimPartyTypes, activeOnly, lookup => lookup.Name, cancellationToken);

    public Task<ClaimPartyType?> GetClaimPartyTypeByIdAsync(int partyTypeId, CancellationToken cancellationToken = default)
        => _context.ClaimPartyTypes.AsNoTracking().FirstOrDefaultAsync(entity => entity.PartyTypeId == partyTypeId, cancellationToken);

    private static async Task<IReadOnlyList<TEntity>> GetLookupListAsync<TEntity, TOrder>(
        IQueryable<TEntity> query,
        bool activeOnly,
        Expression<Func<TEntity, TOrder>> orderBy,
        CancellationToken cancellationToken)
        where TEntity : class
    {
        if (activeOnly)
        {
            query = query.Where(entity => EF.Property<bool>(entity, "IsActive"));
        }

        return await query
            .AsNoTracking()
            .OrderBy(orderBy)
            .ToListAsync(cancellationToken);
    }
}