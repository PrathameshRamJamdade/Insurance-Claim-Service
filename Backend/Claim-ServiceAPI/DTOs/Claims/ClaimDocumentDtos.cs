using System.ComponentModel.DataAnnotations;
using Claim_ServiceAPI.DTOs.Claims.Lookups;
using Claim_ServiceAPI.DTOs.Common;
using Claim_ServiceAPI.Enums;

namespace Claim_ServiceAPI.DTOs.Claims;

public class ClaimDocumentDto : AuditableResponseDto
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

    public ClaimDocumentTypeDto? DocumentType { get; set; }

    public ClaimVerificationStatusDto? VerificationStatus { get; set; }
}

public class CreateClaimDocumentDto
{
    [Required]
    public long ClaimId { get; set; }

    [Required]
    public int DocumentTypeId { get; set; }

    [Required]
    [StringLength(255)]
    public string FileName { get; set; } = string.Empty;

    [Required]
    [StringLength(255)]
    public string OriginalFileName { get; set; } = string.Empty;

    [Required]
    [StringLength(20)]
    public string FileExtension { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string MimeType { get; set; } = string.Empty;

    [Range(0, long.MaxValue)]
    public long FileSizeBytes { get; set; }

    [Required]
    [StringLength(500)]
    public string StoragePath { get; set; } = string.Empty;

    [Required]
    public ClaimDocumentStorageProvider StorageProvider { get; set; }

    [StringLength(128)]
    public string? Checksum { get; set; }

    [Required]
    public long UploadedByUserId { get; set; }

    [Required]
    public DateTimeOffset UploadedAt { get; set; }

    [Required]
    public int VerificationStatusId { get; set; }

    public long? VerifiedByUserId { get; set; }

    public DateTimeOffset? VerifiedAt { get; set; }

    [StringLength(500)]
    public string? Remarks { get; set; }
}

public class UpdateClaimDocumentDto : CreateClaimDocumentDto
{
}