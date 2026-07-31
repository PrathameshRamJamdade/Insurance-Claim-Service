namespace Claim_ServiceAPI.DTOs.Common;

public abstract class AuditableResponseDto
{
    public DateTimeOffset CreatedAt { get; set; }

    public long? CreatedBy { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    public long? UpdatedBy { get; set; }

    public bool IsDeleted { get; set; }

    public DateTimeOffset? DeletedAt { get; set; }

    public long VersionNo { get; set; }

    public string? CorrelationId { get; set; }
}