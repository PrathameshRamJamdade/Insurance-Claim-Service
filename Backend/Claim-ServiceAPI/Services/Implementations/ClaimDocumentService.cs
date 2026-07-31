using Claim_ServiceAPI.DTOs.Claims;
using Claim_ServiceAPI.Mappers;
using Claim_ServiceAPI.Repositories.Interfaces;
using Claim_ServiceAPI.Services.Interfaces;

namespace Claim_ServiceAPI.Services.Implementations;

public class ClaimDocumentService : IClaimDocumentService
{
    private readonly IClaimDocumentRepository _claimDocumentRepository;
    private readonly IClaimRepository _claimRepository;
    private readonly IClaimLookupRepository _claimLookupRepository;

    public ClaimDocumentService(
        IClaimDocumentRepository claimDocumentRepository,
        IClaimRepository claimRepository,
        IClaimLookupRepository claimLookupRepository)
    {
        _claimDocumentRepository = claimDocumentRepository;
        _claimRepository = claimRepository;
        _claimLookupRepository = claimLookupRepository;
    }

    public async Task<IReadOnlyList<ClaimDocumentDto>> GetByClaimIdAsync(long claimId, CancellationToken cancellationToken = default)
    {
        var documents = await _claimDocumentRepository.GetByClaimIdAsync(claimId, cancellationToken);

        return documents
            .Where(document => !document.IsDeleted)
            .Select(document => document.ToDto())
            .ToList();
    }

    public async Task<ClaimDocumentDto?> GetByIdAsync(long claimDocumentId, CancellationToken cancellationToken = default)
    {
        var document = await _claimDocumentRepository.GetByIdAsync(claimDocumentId, cancellationToken: cancellationToken);
        return document == null || document.IsDeleted ? null : document.ToDto();
    }

    public async Task<ClaimDocumentDto> CreateAsync(CreateClaimDocumentDto dto, CancellationToken cancellationToken = default)
    {
        await ClaimServiceSupport.EnsureClaimExistsAsync(_claimRepository, dto.ClaimId, cancellationToken);
        await EnsureReferencesAsync(dto.DocumentTypeId, dto.VerificationStatusId, cancellationToken);

        var claimDocument = dto.ToEntity();
        ClaimServiceSupport.ApplyCreationAudit(claimDocument);

        await _claimDocumentRepository.AddAsync(claimDocument, cancellationToken);
        await _claimDocumentRepository.SaveChangesAsync(cancellationToken);

        var createdDocument = await _claimDocumentRepository.GetByIdAsync(claimDocument.ClaimDocumentId, cancellationToken: cancellationToken)
            ?? throw new InvalidOperationException("Claim document could not be loaded after creation.");

        return createdDocument.ToDto();
    }

    public async Task<ClaimDocumentDto?> UpdateAsync(long claimDocumentId, UpdateClaimDocumentDto dto, CancellationToken cancellationToken = default)
    {
        var claimDocument = await _claimDocumentRepository.GetByIdAsync(claimDocumentId, asNoTracking: false, cancellationToken: cancellationToken);

        if (claimDocument == null || claimDocument.IsDeleted)
        {
            return null;
        }

        await ClaimServiceSupport.EnsureClaimExistsAsync(_claimRepository, dto.ClaimId, cancellationToken);
        await EnsureReferencesAsync(dto.DocumentTypeId, dto.VerificationStatusId, cancellationToken);

        claimDocument.MapFrom(dto);
        ClaimServiceSupport.ApplyUpdateAudit(claimDocument);

        _claimDocumentRepository.Update(claimDocument);
        await _claimDocumentRepository.SaveChangesAsync(cancellationToken);

        var updatedDocument = await _claimDocumentRepository.GetByIdAsync(claimDocumentId, cancellationToken: cancellationToken)
            ?? throw new InvalidOperationException("Claim document could not be loaded after update.");

        return updatedDocument.ToDto();
    }

    public async Task<bool> DeleteAsync(long claimDocumentId, CancellationToken cancellationToken = default)
    {
        var claimDocument = await _claimDocumentRepository.GetByIdAsync(claimDocumentId, asNoTracking: false, cancellationToken: cancellationToken);

        if (claimDocument == null || claimDocument.IsDeleted)
        {
            return false;
        }

        ClaimServiceSupport.ApplySoftDelete(claimDocument);
        _claimDocumentRepository.Update(claimDocument);
        await _claimDocumentRepository.SaveChangesAsync(cancellationToken);

        return true;
    }

    private async Task EnsureReferencesAsync(int documentTypeId, int verificationStatusId, CancellationToken cancellationToken)
    {
        if (await _claimLookupRepository.GetClaimDocumentTypeByIdAsync(documentTypeId, cancellationToken) == null)
        {
            throw new InvalidOperationException($"Claim document type '{documentTypeId}' was not found.");
        }

        if (await _claimLookupRepository.GetClaimVerificationStatusByIdAsync(verificationStatusId, cancellationToken) == null)
        {
            throw new InvalidOperationException($"Claim verification status '{verificationStatusId}' was not found.");
        }
    }
}