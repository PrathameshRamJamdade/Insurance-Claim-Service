using System.Text.Json;
using Claim_ServiceAPI.DTOs.Claims;
using Claim_ServiceAPI.DTOs.Claims.Lookups;
using Claim_ServiceAPI.Models.Claims;
using Claim_ServiceAPI.Models.Claims.Lookups;

namespace Claim_ServiceAPI.Mappers;

public static class ClaimMappingExtensions
{
    public static ClaimSummaryDto ToSummaryDto(this Claim claim)
    {
        return new ClaimSummaryDto
        {
            ClaimId = claim.ClaimId,
            ClaimNumber = claim.ClaimNumber,
            PolicyId = claim.PolicyId,
            CustomerId = claim.CustomerId,
            ClaimTypeId = claim.ClaimTypeId,
            ClaimTypeName = claim.ClaimType?.Name ?? string.Empty,
            ClaimStatusId = claim.ClaimStatusId,
            ClaimStatusName = claim.ClaimStatus?.Name ?? string.Empty,
            PriorityId = claim.PriorityId,
            PriorityName = claim.Priority?.Name ?? string.Empty,
            IncidentDate = claim.IncidentDate,
            ReportedAt = claim.ReportedAt,
            ClaimAmount = claim.ClaimAmount,
            ApprovedAmount = claim.ApprovedAmount,
            SettledAmount = claim.SettledAmount,
            AssignedToUserId = claim.AssignedToUserId
        };
    }

    public static ClaimDetailDto ToDetailDto(this Claim claim)
    {
        return new ClaimDetailDto
        {
            ClaimId = claim.ClaimId,
            PolicyId = claim.PolicyId,
            CustomerId = claim.CustomerId,
            ClaimNumber = claim.ClaimNumber,
            ClaimTypeId = claim.ClaimTypeId,
            ClaimStatusId = claim.ClaimStatusId,
            IncidentDate = claim.IncidentDate,
            IncidentTime = claim.IncidentTime,
            ReportedAt = claim.ReportedAt,
            IntimationDate = claim.IntimationDate,
            ClaimAmount = claim.ClaimAmount,
            ApprovedAmount = claim.ApprovedAmount,
            SettledAmount = claim.SettledAmount,
            DeductionAmount = claim.DeductionAmount,
            CurrencyCode = claim.CurrencyCode,
            CauseOfLoss = claim.CauseOfLoss,
            LossDescription = claim.LossDescription,
            IncidentLocation = claim.IncidentLocation,
            PriorityId = claim.PriorityId,
            AssignedToUserId = claim.AssignedToUserId,
            FraudRiskScore = claim.FraudRiskScore,
            RejectionReason = claim.RejectionReason,
            ClosureReason = claim.ClosureReason,
            ClosedAt = claim.ClosedAt,
            CreatedAt = claim.CreatedAt,
            CreatedBy = claim.CreatedBy,
            UpdatedAt = claim.UpdatedAt,
            UpdatedBy = claim.UpdatedBy,
            IsDeleted = claim.IsDeleted,
            DeletedAt = claim.DeletedAt,
            VersionNo = claim.VersionNo,
            CorrelationId = claim.CorrelationId,
            ClaimType = claim.ClaimType?.ToDto(),
            ClaimStatus = claim.ClaimStatus?.ToDto(),
            Priority = claim.Priority?.ToDto(),
            Documents = claim.Documents.Select(document => document.ToDto()).ToList(),
            Assessments = claim.Assessments.Select(assessment => assessment.ToDto()).ToList(),
            StatusHistory = claim.StatusHistory.Select(statusHistory => statusHistory.ToDto()).ToList(),
            ActionHistory = claim.ActionHistory.Select(actionHistory => actionHistory.ToDto()).ToList(),
            Settlements = claim.Settlements.Select(settlement => settlement.ToDto()).ToList(),
            Parties = claim.Parties.Select(party => party.ToDto()).ToList()
        };
    }

    public static Claim ToEntity(this CreateClaimDto dto)
    {
        var claim = new Claim();
        claim.MapFrom(dto);
        return claim;
    }

    public static void MapFrom(this Claim claim, CreateClaimDto dto)
    {
        claim.PolicyId = dto.PolicyId;
        claim.CustomerId = dto.CustomerId;
        claim.ClaimNumber = dto.ClaimNumber;
        claim.ClaimTypeId = dto.ClaimTypeId;
        claim.ClaimStatusId = dto.ClaimStatusId;
        claim.IncidentDate = dto.IncidentDate;
        claim.IncidentTime = dto.IncidentTime;
        claim.ReportedAt = dto.ReportedAt;
        claim.IntimationDate = dto.IntimationDate;
        claim.ClaimAmount = dto.ClaimAmount;
        claim.ApprovedAmount = dto.ApprovedAmount;
        claim.SettledAmount = dto.SettledAmount;
        claim.DeductionAmount = dto.DeductionAmount;
        claim.CurrencyCode = dto.CurrencyCode;
        claim.CauseOfLoss = dto.CauseOfLoss;
        claim.LossDescription = dto.LossDescription;
        claim.IncidentLocation = dto.IncidentLocation;
        claim.PriorityId = dto.PriorityId;
        claim.AssignedToUserId = dto.AssignedToUserId;
        claim.FraudRiskScore = dto.FraudRiskScore;
        claim.RejectionReason = dto.RejectionReason;
        claim.ClosureReason = dto.ClosureReason;
        claim.ClosedAt = dto.ClosedAt;
    }

    public static void MapFrom(this Claim claim, UpdateClaimDto dto)
    {
        claim.MapFrom((CreateClaimDto)dto);
    }

    public static ClaimDocumentDto ToDto(this ClaimDocument claimDocument)
    {
        return new ClaimDocumentDto
        {
            ClaimDocumentId = claimDocument.ClaimDocumentId,
            ClaimId = claimDocument.ClaimId,
            DocumentTypeId = claimDocument.DocumentTypeId,
            FileName = claimDocument.FileName,
            OriginalFileName = claimDocument.OriginalFileName,
            FileExtension = claimDocument.FileExtension,
            MimeType = claimDocument.MimeType,
            FileSizeBytes = claimDocument.FileSizeBytes,
            StoragePath = claimDocument.StoragePath,
            StorageProvider = claimDocument.StorageProvider,
            Checksum = claimDocument.Checksum,
            UploadedByUserId = claimDocument.UploadedByUserId,
            UploadedAt = claimDocument.UploadedAt,
            VerificationStatusId = claimDocument.VerificationStatusId,
            VerifiedByUserId = claimDocument.VerifiedByUserId,
            VerifiedAt = claimDocument.VerifiedAt,
            Remarks = claimDocument.Remarks,
            CreatedAt = claimDocument.CreatedAt,
            CreatedBy = claimDocument.CreatedBy,
            UpdatedAt = claimDocument.UpdatedAt,
            UpdatedBy = claimDocument.UpdatedBy,
            IsDeleted = claimDocument.IsDeleted,
            DeletedAt = claimDocument.DeletedAt,
            VersionNo = claimDocument.VersionNo,
            CorrelationId = claimDocument.CorrelationId,
            DocumentType = claimDocument.DocumentType?.ToDto(),
            VerificationStatus = claimDocument.VerificationStatus?.ToDto()
        };
    }

    public static ClaimDocument ToEntity(this CreateClaimDocumentDto dto)
    {
        var claimDocument = new ClaimDocument();
        claimDocument.MapFrom(dto);
        return claimDocument;
    }

    public static void MapFrom(this ClaimDocument claimDocument, CreateClaimDocumentDto dto)
    {
        claimDocument.ClaimId = dto.ClaimId;
        claimDocument.DocumentTypeId = dto.DocumentTypeId;
        claimDocument.FileName = dto.FileName;
        claimDocument.OriginalFileName = dto.OriginalFileName;
        claimDocument.FileExtension = dto.FileExtension;
        claimDocument.MimeType = dto.MimeType;
        claimDocument.FileSizeBytes = dto.FileSizeBytes;
        claimDocument.StoragePath = dto.StoragePath;
        claimDocument.StorageProvider = dto.StorageProvider;
        claimDocument.Checksum = dto.Checksum;
        claimDocument.UploadedByUserId = dto.UploadedByUserId;
        claimDocument.UploadedAt = dto.UploadedAt;
        claimDocument.VerificationStatusId = dto.VerificationStatusId;
        claimDocument.VerifiedByUserId = dto.VerifiedByUserId;
        claimDocument.VerifiedAt = dto.VerifiedAt;
        claimDocument.Remarks = dto.Remarks;
    }

    public static void MapFrom(this ClaimDocument claimDocument, UpdateClaimDocumentDto dto)
    {
        claimDocument.MapFrom((CreateClaimDocumentDto)dto);
    }

    public static ClaimAssessmentDto ToDto(this ClaimAssessment claimAssessment)
    {
        return new ClaimAssessmentDto
        {
            ClaimAssessmentId = claimAssessment.ClaimAssessmentId,
            ClaimId = claimAssessment.ClaimId,
            AssessorUserId = claimAssessment.AssessorUserId,
            AssessmentDate = claimAssessment.AssessmentDate,
            EstimatedLossAmount = claimAssessment.EstimatedLossAmount,
            AssessedAmount = claimAssessment.AssessedAmount,
            RecommendedAmount = claimAssessment.RecommendedAmount,
            DepreciationAmount = claimAssessment.DepreciationAmount,
            SalvageAmount = claimAssessment.SalvageAmount,
            LiabilityPercentage = claimAssessment.LiabilityPercentage,
            AssessmentSummary = claimAssessment.AssessmentSummary,
            InternalRemarks = claimAssessment.InternalRemarks,
            AssessmentStatusId = claimAssessment.AssessmentStatusId,
            CreatedAt = claimAssessment.CreatedAt,
            CreatedBy = claimAssessment.CreatedBy,
            UpdatedAt = claimAssessment.UpdatedAt,
            UpdatedBy = claimAssessment.UpdatedBy,
            IsDeleted = claimAssessment.IsDeleted,
            DeletedAt = claimAssessment.DeletedAt,
            VersionNo = claimAssessment.VersionNo,
            CorrelationId = claimAssessment.CorrelationId,
            AssessmentStatus = claimAssessment.AssessmentStatus?.ToDto()
        };
    }

    public static ClaimAssessment ToEntity(this CreateClaimAssessmentDto dto)
    {
        var claimAssessment = new ClaimAssessment();
        claimAssessment.MapFrom(dto);
        return claimAssessment;
    }

    public static void MapFrom(this ClaimAssessment claimAssessment, CreateClaimAssessmentDto dto)
    {
        claimAssessment.ClaimId = dto.ClaimId;
        claimAssessment.AssessorUserId = dto.AssessorUserId;
        claimAssessment.AssessmentDate = dto.AssessmentDate;
        claimAssessment.EstimatedLossAmount = dto.EstimatedLossAmount;
        claimAssessment.AssessedAmount = dto.AssessedAmount;
        claimAssessment.RecommendedAmount = dto.RecommendedAmount;
        claimAssessment.DepreciationAmount = dto.DepreciationAmount;
        claimAssessment.SalvageAmount = dto.SalvageAmount;
        claimAssessment.LiabilityPercentage = dto.LiabilityPercentage;
        claimAssessment.AssessmentSummary = dto.AssessmentSummary;
        claimAssessment.InternalRemarks = dto.InternalRemarks;
        claimAssessment.AssessmentStatusId = dto.AssessmentStatusId;
    }

    public static void MapFrom(this ClaimAssessment claimAssessment, UpdateClaimAssessmentDto dto)
    {
        claimAssessment.MapFrom((CreateClaimAssessmentDto)dto);
    }

    public static ClaimStatusHistoryDto ToDto(this ClaimStatusHistory claimStatusHistory)
    {
        return new ClaimStatusHistoryDto
        {
            ClaimStatusHistoryId = claimStatusHistory.ClaimStatusHistoryId,
            ClaimId = claimStatusHistory.ClaimId,
            PreviousStatusId = claimStatusHistory.PreviousStatusId,
            CurrentStatusId = claimStatusHistory.CurrentStatusId,
            ChangedByUserId = claimStatusHistory.ChangedByUserId,
            ChangedAt = claimStatusHistory.ChangedAt,
            ReasonCode = claimStatusHistory.ReasonCode,
            Comments = claimStatusHistory.Comments,
            Source = claimStatusHistory.Source,
            PreviousStatus = claimStatusHistory.PreviousStatus?.ToDto(),
            CurrentStatus = claimStatusHistory.CurrentStatus?.ToDto()
        };
    }

    public static ClaimStatusHistory ToEntity(this CreateClaimStatusHistoryDto dto)
    {
        return new ClaimStatusHistory
        {
            ClaimId = dto.ClaimId,
            PreviousStatusId = dto.PreviousStatusId,
            CurrentStatusId = dto.CurrentStatusId,
            ChangedByUserId = dto.ChangedByUserId,
            ChangedAt = dto.ChangedAt,
            ReasonCode = dto.ReasonCode,
            Comments = dto.Comments,
            Source = dto.Source
        };
    }

    public static ClaimActionHistoryDto ToDto(this ClaimActionHistory claimActionHistory)
    {
        return new ClaimActionHistoryDto
        {
            ClaimActionHistoryId = claimActionHistory.ClaimActionHistoryId,
            ClaimId = claimActionHistory.ClaimId,
            ActionTypeId = claimActionHistory.ActionTypeId,
            ActionByUserId = claimActionHistory.ActionByUserId,
            ActionAt = claimActionHistory.ActionAt,
            Remarks = claimActionHistory.Remarks,
            OldValuesJson = claimActionHistory.OldValuesJson?.RootElement.GetRawText(),
            NewValuesJson = claimActionHistory.NewValuesJson?.RootElement.GetRawText(),
            CorrelationId = claimActionHistory.CorrelationId,
            ActionType = claimActionHistory.ActionType?.ToDto()
        };
    }

    public static ClaimActionHistory ToEntity(this CreateClaimActionHistoryDto dto)
    {
        return new ClaimActionHistory
        {
            ClaimId = dto.ClaimId,
            ActionTypeId = dto.ActionTypeId,
            ActionByUserId = dto.ActionByUserId,
            ActionAt = dto.ActionAt,
            Remarks = dto.Remarks,
            OldValuesJson = ParseJson(dto.OldValuesJson),
            NewValuesJson = ParseJson(dto.NewValuesJson),
            CorrelationId = dto.CorrelationId
        };
    }

    public static ClaimSettlementDto ToDto(this ClaimSettlement claimSettlement)
    {
        return new ClaimSettlementDto
        {
            ClaimSettlementId = claimSettlement.ClaimSettlementId,
            ClaimId = claimSettlement.ClaimId,
            SettlementTypeId = claimSettlement.SettlementTypeId,
            ApprovedAmount = claimSettlement.ApprovedAmount,
            DeductionsAmount = claimSettlement.DeductionsAmount,
            NetPayableAmount = claimSettlement.NetPayableAmount,
            SettlementDate = claimSettlement.SettlementDate,
            PaymentStatusId = claimSettlement.PaymentStatusId,
            PaymentReferenceNumber = claimSettlement.PaymentReferenceNumber,
            PaidToName = claimSettlement.PaidToName,
            PaidToAccountMasked = claimSettlement.PaidToAccountMasked,
            Remarks = claimSettlement.Remarks,
            CreatedAt = claimSettlement.CreatedAt,
            CreatedBy = claimSettlement.CreatedBy,
            UpdatedAt = claimSettlement.UpdatedAt,
            UpdatedBy = claimSettlement.UpdatedBy,
            IsDeleted = claimSettlement.IsDeleted,
            DeletedAt = claimSettlement.DeletedAt,
            VersionNo = claimSettlement.VersionNo,
            CorrelationId = claimSettlement.CorrelationId,
            SettlementType = claimSettlement.SettlementType?.ToDto(),
            PaymentStatus = claimSettlement.PaymentStatus?.ToDto()
        };
    }

    public static ClaimSettlement ToEntity(this CreateClaimSettlementDto dto)
    {
        var claimSettlement = new ClaimSettlement();
        claimSettlement.MapFrom(dto);
        return claimSettlement;
    }

    public static void MapFrom(this ClaimSettlement claimSettlement, CreateClaimSettlementDto dto)
    {
        claimSettlement.ClaimId = dto.ClaimId;
        claimSettlement.SettlementTypeId = dto.SettlementTypeId;
        claimSettlement.ApprovedAmount = dto.ApprovedAmount;
        claimSettlement.DeductionsAmount = dto.DeductionsAmount;
        claimSettlement.NetPayableAmount = dto.NetPayableAmount;
        claimSettlement.SettlementDate = dto.SettlementDate;
        claimSettlement.PaymentStatusId = dto.PaymentStatusId;
        claimSettlement.PaymentReferenceNumber = dto.PaymentReferenceNumber;
        claimSettlement.PaidToName = dto.PaidToName;
        claimSettlement.PaidToAccountMasked = dto.PaidToAccountMasked;
        claimSettlement.Remarks = dto.Remarks;
    }

    public static void MapFrom(this ClaimSettlement claimSettlement, UpdateClaimSettlementDto dto)
    {
        claimSettlement.MapFrom((CreateClaimSettlementDto)dto);
    }

    public static ClaimPartyDto ToDto(this ClaimParty claimParty)
    {
        return new ClaimPartyDto
        {
            ClaimPartyId = claimParty.ClaimPartyId,
            ClaimId = claimParty.ClaimId,
            PartyTypeId = claimParty.PartyTypeId,
            Name = claimParty.Name,
            ContactNumber = claimParty.ContactNumber,
            Email = claimParty.Email,
            AddressLine1 = claimParty.AddressLine1,
            AddressLine2 = claimParty.AddressLine2,
            City = claimParty.City,
            State = claimParty.State,
            Country = claimParty.Country,
            PostalCode = claimParty.PostalCode,
            ReferenceNumber = claimParty.ReferenceNumber,
            Remarks = claimParty.Remarks,
            CreatedAt = claimParty.CreatedAt,
            CreatedBy = claimParty.CreatedBy,
            UpdatedAt = claimParty.UpdatedAt,
            UpdatedBy = claimParty.UpdatedBy,
            IsDeleted = claimParty.IsDeleted,
            DeletedAt = claimParty.DeletedAt,
            VersionNo = claimParty.VersionNo,
            CorrelationId = claimParty.CorrelationId,
            PartyType = claimParty.PartyType?.ToDto()
        };
    }

    public static ClaimParty ToEntity(this CreateClaimPartyDto dto)
    {
        var claimParty = new ClaimParty();
        claimParty.MapFrom(dto);
        return claimParty;
    }

    public static void MapFrom(this ClaimParty claimParty, CreateClaimPartyDto dto)
    {
        claimParty.ClaimId = dto.ClaimId;
        claimParty.PartyTypeId = dto.PartyTypeId;
        claimParty.Name = dto.Name;
        claimParty.ContactNumber = dto.ContactNumber;
        claimParty.Email = dto.Email;
        claimParty.AddressLine1 = dto.AddressLine1;
        claimParty.AddressLine2 = dto.AddressLine2;
        claimParty.City = dto.City;
        claimParty.State = dto.State;
        claimParty.Country = dto.Country;
        claimParty.PostalCode = dto.PostalCode;
        claimParty.ReferenceNumber = dto.ReferenceNumber;
        claimParty.Remarks = dto.Remarks;
    }

    public static void MapFrom(this ClaimParty claimParty, UpdateClaimPartyDto dto)
    {
        claimParty.MapFrom((CreateClaimPartyDto)dto);
    }

    public static ClaimTypeDto ToDto(this ClaimType claimType)
    {
        return new ClaimTypeDto
        {
            Id = claimType.ClaimTypeId,
            Code = claimType.Code,
            Name = claimType.Name,
            Description = claimType.Description,
            IsActive = claimType.IsActive
        };
    }

    public static ClaimStatusDto ToDto(this ClaimStatus claimStatus)
    {
        return new ClaimStatusDto
        {
            Id = claimStatus.ClaimStatusId,
            Code = claimStatus.Code,
            Name = claimStatus.Name,
            Description = claimStatus.Description,
            IsActive = claimStatus.IsActive,
            SequenceNo = claimStatus.SequenceNo,
            IsTerminal = claimStatus.IsTerminal
        };
    }

    public static ClaimPriorityDto ToDto(this ClaimPriority claimPriority)
    {
        return new ClaimPriorityDto
        {
            Id = claimPriority.PriorityId,
            Code = claimPriority.Code,
            Name = claimPriority.Name,
            Description = claimPriority.Description,
            IsActive = claimPriority.IsActive
        };
    }

    public static ClaimDocumentTypeDto ToDto(this ClaimDocumentType claimDocumentType)
    {
        return new ClaimDocumentTypeDto
        {
            Id = claimDocumentType.DocumentTypeId,
            Code = claimDocumentType.Code,
            Name = claimDocumentType.Name,
            Description = claimDocumentType.Description,
            IsActive = claimDocumentType.IsActive,
            IsMandatory = claimDocumentType.IsMandatory
        };
    }

    public static ClaimActionTypeDto ToDto(this ClaimActionType claimActionType)
    {
        return new ClaimActionTypeDto
        {
            Id = claimActionType.ActionTypeId,
            Code = claimActionType.Code,
            Name = claimActionType.Name,
            Description = claimActionType.Description,
            IsActive = claimActionType.IsActive
        };
    }

    public static AssessmentStatusDto ToDto(this AssessmentStatus assessmentStatus)
    {
        return new AssessmentStatusDto
        {
            Id = assessmentStatus.AssessmentStatusId,
            Code = assessmentStatus.Code,
            Name = assessmentStatus.Name,
            Description = assessmentStatus.Description,
            IsActive = assessmentStatus.IsActive
        };
    }

    public static SettlementTypeDto ToDto(this SettlementType settlementType)
    {
        return new SettlementTypeDto
        {
            Id = settlementType.SettlementTypeId,
            Code = settlementType.Code,
            Name = settlementType.Name,
            Description = settlementType.Description,
            IsActive = settlementType.IsActive
        };
    }

    public static PaymentStatusDto ToDto(this PaymentStatus paymentStatus)
    {
        return new PaymentStatusDto
        {
            Id = paymentStatus.PaymentStatusId,
            Code = paymentStatus.Code,
            Name = paymentStatus.Name,
            Description = paymentStatus.Description,
            IsActive = paymentStatus.IsActive
        };
    }

    public static ClaimVerificationStatusDto ToDto(this ClaimVerificationStatus claimVerificationStatus)
    {
        return new ClaimVerificationStatusDto
        {
            Id = claimVerificationStatus.VerificationStatusId,
            Code = claimVerificationStatus.Code,
            Name = claimVerificationStatus.Name,
            Description = claimVerificationStatus.Description,
            IsActive = claimVerificationStatus.IsActive
        };
    }

    public static ClaimPartyTypeDto ToDto(this ClaimPartyType claimPartyType)
    {
        return new ClaimPartyTypeDto
        {
            Id = claimPartyType.PartyTypeId,
            Code = claimPartyType.Code,
            Name = claimPartyType.Name,
            Description = claimPartyType.Description,
            IsActive = claimPartyType.IsActive
        };
    }

    private static JsonDocument? ParseJson(string? json)
    {
        return string.IsNullOrWhiteSpace(json)
            ? null
            : JsonDocument.Parse(json);
    }
}