using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Claim_ServiceAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialClaimSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssessmentStatus",
                columns: table => new
                {
                    AssessmentStatusId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentStatus", x => x.AssessmentStatusId);
                });

            migrationBuilder.CreateTable(
                name: "ClaimActionType",
                columns: table => new
                {
                    ActionTypeId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimActionType", x => x.ActionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ClaimDocumentType",
                columns: table => new
                {
                    DocumentTypeId = table.Column<int>(type: "int", nullable: false),
                    IsMandatory = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimDocumentType", x => x.DocumentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ClaimPartyType",
                columns: table => new
                {
                    PartyTypeId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimPartyType", x => x.PartyTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ClaimPriority",
                columns: table => new
                {
                    PriorityId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimPriority", x => x.PriorityId);
                });

            migrationBuilder.CreateTable(
                name: "ClaimStatus",
                columns: table => new
                {
                    ClaimStatusId = table.Column<int>(type: "int", nullable: false),
                    SequenceNo = table.Column<int>(type: "int", nullable: false),
                    IsTerminal = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimStatus", x => x.ClaimStatusId);
                });

            migrationBuilder.CreateTable(
                name: "ClaimType",
                columns: table => new
                {
                    ClaimTypeId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimType", x => x.ClaimTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ClaimVerificationStatus",
                columns: table => new
                {
                    VerificationStatusId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimVerificationStatus", x => x.VerificationStatusId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentStatus",
                columns: table => new
                {
                    PaymentStatusId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentStatus", x => x.PaymentStatusId);
                });

            migrationBuilder.CreateTable(
                name: "SettlementType",
                columns: table => new
                {
                    SettlementTypeId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettlementType", x => x.SettlementTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Claim",
                columns: table => new
                {
                    ClaimId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyId = table.Column<long>(type: "bigint", nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClaimTypeId = table.Column<int>(type: "int", nullable: false),
                    ClaimStatusId = table.Column<int>(type: "int", nullable: false),
                    IncidentDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IncidentTime = table.Column<TimeOnly>(type: "time", nullable: true),
                    ReportedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IntimationDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ClaimAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ApprovedAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SettledAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DeductionAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CurrencyCode = table.Column<string>(type: "char(3)", nullable: false),
                    CauseOfLoss = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LossDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IncidentLocation = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    PriorityId = table.Column<int>(type: "int", nullable: false),
                    AssignedToUserId = table.Column<long>(type: "bigint", nullable: true),
                    FraudRiskScore = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    RejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClosureReason = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ClosedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    VersionNo = table.Column<long>(type: "bigint", nullable: false, defaultValue: 1L),
                    CorrelationId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claim", x => x.ClaimId);
                    table.ForeignKey(
                        name: "FK_Claim_ClaimPriority_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "ClaimPriority",
                        principalColumn: "PriorityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Claim_ClaimStatus_ClaimStatusId",
                        column: x => x.ClaimStatusId,
                        principalTable: "ClaimStatus",
                        principalColumn: "ClaimStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Claim_ClaimType_ClaimTypeId",
                        column: x => x.ClaimTypeId,
                        principalTable: "ClaimType",
                        principalColumn: "ClaimTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClaimActionHistory",
                columns: table => new
                {
                    ClaimActionHistoryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimId = table.Column<long>(type: "bigint", nullable: false),
                    ActionTypeId = table.Column<int>(type: "int", nullable: false),
                    ActionByUserId = table.Column<long>(type: "bigint", nullable: false),
                    ActionAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldValuesJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValuesJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrelationId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimActionHistory", x => x.ClaimActionHistoryId);
                    table.ForeignKey(
                        name: "FK_ClaimActionHistory_ClaimActionType_ActionTypeId",
                        column: x => x.ActionTypeId,
                        principalTable: "ClaimActionType",
                        principalColumn: "ActionTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClaimActionHistory_Claim_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "Claim",
                        principalColumn: "ClaimId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClaimAssessment",
                columns: table => new
                {
                    ClaimAssessmentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimId = table.Column<long>(type: "bigint", nullable: false),
                    AssessorUserId = table.Column<long>(type: "bigint", nullable: false),
                    AssessmentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EstimatedLossAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AssessedAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    RecommendedAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DepreciationAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SalvageAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    LiabilityPercentage = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    AssessmentSummary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InternalRemarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssessmentStatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    VersionNo = table.Column<long>(type: "bigint", nullable: false, defaultValue: 1L),
                    CorrelationId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimAssessment", x => x.ClaimAssessmentId);
                    table.ForeignKey(
                        name: "FK_ClaimAssessment_AssessmentStatus_AssessmentStatusId",
                        column: x => x.AssessmentStatusId,
                        principalTable: "AssessmentStatus",
                        principalColumn: "AssessmentStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClaimAssessment_Claim_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "Claim",
                        principalColumn: "ClaimId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClaimDocument",
                columns: table => new
                {
                    ClaimDocumentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimId = table.Column<long>(type: "bigint", nullable: false),
                    DocumentTypeId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    OriginalFileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MimeType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileSizeBytes = table.Column<long>(type: "bigint", nullable: false),
                    StoragePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    StorageProvider = table.Column<int>(type: "int", nullable: false),
                    Checksum = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    UploadedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    UploadedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    VerificationStatusId = table.Column<int>(type: "int", nullable: false),
                    VerifiedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    VerifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    VersionNo = table.Column<long>(type: "bigint", nullable: false, defaultValue: 1L),
                    CorrelationId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimDocument", x => x.ClaimDocumentId);
                    table.ForeignKey(
                        name: "FK_ClaimDocument_ClaimDocumentType_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "ClaimDocumentType",
                        principalColumn: "DocumentTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClaimDocument_ClaimVerificationStatus_VerificationStatusId",
                        column: x => x.VerificationStatusId,
                        principalTable: "ClaimVerificationStatus",
                        principalColumn: "VerificationStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClaimDocument_Claim_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "Claim",
                        principalColumn: "ClaimId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClaimParty",
                columns: table => new
                {
                    ClaimPartyId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimId = table.Column<long>(type: "bigint", nullable: false),
                    PartyTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    VersionNo = table.Column<long>(type: "bigint", nullable: false, defaultValue: 1L),
                    CorrelationId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimParty", x => x.ClaimPartyId);
                    table.ForeignKey(
                        name: "FK_ClaimParty_ClaimPartyType_PartyTypeId",
                        column: x => x.PartyTypeId,
                        principalTable: "ClaimPartyType",
                        principalColumn: "PartyTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClaimParty_Claim_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "Claim",
                        principalColumn: "ClaimId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClaimSettlement",
                columns: table => new
                {
                    ClaimSettlementId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimId = table.Column<long>(type: "bigint", nullable: false),
                    SettlementTypeId = table.Column<int>(type: "int", nullable: false),
                    ApprovedAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DeductionsAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    NetPayableAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SettlementDate = table.Column<DateOnly>(type: "date", nullable: true),
                    PaymentStatusId = table.Column<int>(type: "int", nullable: false),
                    PaymentReferenceNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PaidToName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    PaidToAccountMasked = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    VersionNo = table.Column<long>(type: "bigint", nullable: false, defaultValue: 1L),
                    CorrelationId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimSettlement", x => x.ClaimSettlementId);
                    table.ForeignKey(
                        name: "FK_ClaimSettlement_Claim_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "Claim",
                        principalColumn: "ClaimId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClaimSettlement_PaymentStatus_PaymentStatusId",
                        column: x => x.PaymentStatusId,
                        principalTable: "PaymentStatus",
                        principalColumn: "PaymentStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClaimSettlement_SettlementType_SettlementTypeId",
                        column: x => x.SettlementTypeId,
                        principalTable: "SettlementType",
                        principalColumn: "SettlementTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClaimStatusHistory",
                columns: table => new
                {
                    ClaimStatusHistoryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimId = table.Column<long>(type: "bigint", nullable: false),
                    PreviousStatusId = table.Column<int>(type: "int", nullable: true),
                    CurrentStatusId = table.Column<int>(type: "int", nullable: false),
                    ChangedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    ChangedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ReasonCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Source = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimStatusHistory", x => x.ClaimStatusHistoryId);
                    table.ForeignKey(
                        name: "FK_ClaimStatusHistory_ClaimStatus_CurrentStatusId",
                        column: x => x.CurrentStatusId,
                        principalTable: "ClaimStatus",
                        principalColumn: "ClaimStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClaimStatusHistory_ClaimStatus_PreviousStatusId",
                        column: x => x.PreviousStatusId,
                        principalTable: "ClaimStatus",
                        principalColumn: "ClaimStatusId");
                    table.ForeignKey(
                        name: "FK_ClaimStatusHistory_Claim_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "Claim",
                        principalColumn: "ClaimId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentStatus_Code",
                table: "AssessmentStatus",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Claim_AssignedToUserId",
                table: "Claim",
                column: "AssignedToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Claim_ClaimNumber",
                table: "Claim",
                column: "ClaimNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Claim_ClaimStatusId",
                table: "Claim",
                column: "ClaimStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Claim_ClaimTypeId",
                table: "Claim",
                column: "ClaimTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Claim_CustomerId",
                table: "Claim",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Claim_PolicyId",
                table: "Claim",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Claim_PriorityId",
                table: "Claim",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimActionHistory_ActionByUserId",
                table: "ClaimActionHistory",
                column: "ActionByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimActionHistory_ActionTypeId",
                table: "ClaimActionHistory",
                column: "ActionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimActionHistory_ClaimId",
                table: "ClaimActionHistory",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimActionType_Code",
                table: "ClaimActionType",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClaimAssessment_AssessmentStatusId",
                table: "ClaimAssessment",
                column: "AssessmentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimAssessment_AssessorUserId",
                table: "ClaimAssessment",
                column: "AssessorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimAssessment_ClaimId",
                table: "ClaimAssessment",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimDocument_ClaimId",
                table: "ClaimDocument",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimDocument_DocumentTypeId",
                table: "ClaimDocument",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimDocument_VerificationStatusId",
                table: "ClaimDocument",
                column: "VerificationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimDocumentType_Code",
                table: "ClaimDocumentType",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClaimParty_ClaimId",
                table: "ClaimParty",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimParty_PartyTypeId",
                table: "ClaimParty",
                column: "PartyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimPartyType_Code",
                table: "ClaimPartyType",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClaimPriority_Code",
                table: "ClaimPriority",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClaimSettlement_ClaimId",
                table: "ClaimSettlement",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimSettlement_PaymentStatusId",
                table: "ClaimSettlement",
                column: "PaymentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimSettlement_SettlementTypeId",
                table: "ClaimSettlement",
                column: "SettlementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimStatus_Code",
                table: "ClaimStatus",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClaimStatusHistory_ChangedByUserId",
                table: "ClaimStatusHistory",
                column: "ChangedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimStatusHistory_ClaimId",
                table: "ClaimStatusHistory",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimStatusHistory_CurrentStatusId",
                table: "ClaimStatusHistory",
                column: "CurrentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimStatusHistory_PreviousStatusId",
                table: "ClaimStatusHistory",
                column: "PreviousStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimType_Code",
                table: "ClaimType",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClaimVerificationStatus_Code",
                table: "ClaimVerificationStatus",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentStatus_Code",
                table: "PaymentStatus",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SettlementType_Code",
                table: "SettlementType",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClaimActionHistory");

            migrationBuilder.DropTable(
                name: "ClaimAssessment");

            migrationBuilder.DropTable(
                name: "ClaimDocument");

            migrationBuilder.DropTable(
                name: "ClaimParty");

            migrationBuilder.DropTable(
                name: "ClaimSettlement");

            migrationBuilder.DropTable(
                name: "ClaimStatusHistory");

            migrationBuilder.DropTable(
                name: "ClaimActionType");

            migrationBuilder.DropTable(
                name: "AssessmentStatus");

            migrationBuilder.DropTable(
                name: "ClaimDocumentType");

            migrationBuilder.DropTable(
                name: "ClaimVerificationStatus");

            migrationBuilder.DropTable(
                name: "ClaimPartyType");

            migrationBuilder.DropTable(
                name: "PaymentStatus");

            migrationBuilder.DropTable(
                name: "SettlementType");

            migrationBuilder.DropTable(
                name: "Claim");

            migrationBuilder.DropTable(
                name: "ClaimPriority");

            migrationBuilder.DropTable(
                name: "ClaimStatus");

            migrationBuilder.DropTable(
                name: "ClaimType");
        }
    }
}
