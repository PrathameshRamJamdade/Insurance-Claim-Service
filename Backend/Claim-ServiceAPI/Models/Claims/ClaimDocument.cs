using Claim_ServiceAPI.Enums;
using Claim_ServiceAPI.Models.Claims.Lookups;
using Claim_ServiceAPI.Models.Common;

namespace Claim_ServiceAPI.Models.Claims;

public class ClaimDocument : AuditableEntityBase
{
    public long ClaimDocumentId { get; set; }

    public long ClaimId { get; set; }

    public int DocumentTypeId { get; set; }

    public string FileName { get; set; } = string.Empty;

    public string OriginalFileName { get; set; } = string.Empty;

    public string FileExtension { get; set; } = string.Empty;

    public string MimeType { get; set; } = string.Empty;

    public long FileSizeBytes { get; set; }

    public string StoragePath { get; set; } = string.Empty;

    public ClaimDocumentStorageProvider StorageProvider { get; set; }

    public string? Checksum { get; set; }

    public long UploadedByUserId { get; set; }

    public DateTimeOffset UploadedAt { get; set; }

    public int VerificationStatusId { get; set; }

    public long? VerifiedByUserId { get; set; }

    public DateTimeOffset? VerifiedAt { get; set; }

    public string? Remarks { get; set; }

    public Claim? Claim { get; set; }

    public ClaimDocumentType? DocumentType { get; set; }

    public ClaimVerificationStatus? VerificationStatus { get; set; }
}