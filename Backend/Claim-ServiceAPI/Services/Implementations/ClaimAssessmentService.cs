using Claim_ServiceAPI.DTOs.Claims;
using Claim_ServiceAPI.Mappers;
using Claim_ServiceAPI.Repositories.Interfaces;
using Claim_ServiceAPI.Services.Interfaces;

namespace Claim_ServiceAPI.Services.Implementations;

public class ClaimAssessmentService : IClaimAssessmentService
{
    private readonly IClaimAssessmentRepository _claimAssessmentRepository;
    private readonly IClaimRepository _claimRepository;
    private readonly IClaimLookupRepository _claimLookupRepository;

    public ClaimAssessmentService(
        IClaimAssessmentRepository claimAssessmentRepository,
        IClaimRepository claimRepository,
        IClaimLookupRepository claimLookupRepository)
    {
        _claimAssessmentRepository = claimAssessmentRepository;
        _claimRepository = claimRepository;
        _claimLookupRepository = claimLookupRepository;
    }

    public async Task<IReadOnlyList<ClaimAssessmentDto>> GetByClaimIdAsync(long claimId, CancellationToken cancellationToken = default)
    {
        var assessments = await _claimAssessmentRepository.GetByClaimIdAsync(claimId, cancellationToken);

        return assessments
            .Where(assessment => !assessment.IsDeleted)
            .Select(assessment => assessment.ToDto())
            .ToList();
    }

    public async Task<ClaimAssessmentDto?> GetByIdAsync(long claimAssessmentId, CancellationToken cancellationToken = default)
    {
        var assessment = await _claimAssessmentRepository.GetByIdAsync(claimAssessmentId, cancellationToken: cancellationToken);
        return assessment == null || assessment.IsDeleted ? null : assessment.ToDto();
    }

    public async Task<ClaimAssessmentDto> CreateAsync(CreateClaimAssessmentDto dto, CancellationToken cancellationToken = default)
    {
        await ClaimServiceSupport.EnsureClaimExistsAsync(_claimRepository, dto.ClaimId, cancellationToken);

        if (await _claimLookupRepository.GetAssessmentStatusByIdAsync(dto.AssessmentStatusId, cancellationToken) == null)
        {
            throw new InvalidOperationException($"Assessment status '{dto.AssessmentStatusId}' was not found.");
        }

        var claimAssessment = dto.ToEntity();
        ClaimServiceSupport.ApplyCreationAudit(claimAssessment);

        await _claimAssessmentRepository.AddAsync(claimAssessment, cancellationToken);
        await _claimAssessmentRepository.SaveChangesAsync(cancellationToken);

        var createdAssessment = await _claimAssessmentRepository.GetByIdAsync(claimAssessment.ClaimAssessmentId, cancellationToken: cancellationToken)
            ?? throw new InvalidOperationException("Claim assessment could not be loaded after creation.");

        return createdAssessment.ToDto();
    }

    public async Task<ClaimAssessmentDto?> UpdateAsync(long claimAssessmentId, UpdateClaimAssessmentDto dto, CancellationToken cancellationToken = default)
    {
        var claimAssessment = await _claimAssessmentRepository.GetByIdAsync(claimAssessmentId, asNoTracking: false, cancellationToken: cancellationToken);

        if (claimAssessment == null || claimAssessment.IsDeleted)
        {
            return null;
        }

        await ClaimServiceSupport.EnsureClaimExistsAsync(_claimRepository, dto.ClaimId, cancellationToken);

        if (await _claimLookupRepository.GetAssessmentStatusByIdAsync(dto.AssessmentStatusId, cancellationToken) == null)
        {
            throw new InvalidOperationException($"Assessment status '{dto.AssessmentStatusId}' was not found.");
        }

        claimAssessment.MapFrom(dto);
        ClaimServiceSupport.ApplyUpdateAudit(claimAssessment);

        _claimAssessmentRepository.Update(claimAssessment);
        await _claimAssessmentRepository.SaveChangesAsync(cancellationToken);

        var updatedAssessment = await _claimAssessmentRepository.GetByIdAsync(claimAssessmentId, cancellationToken: cancellationToken)
            ?? throw new InvalidOperationException("Claim assessment could not be loaded after update.");

        return updatedAssessment.ToDto();
    }

    public async Task<bool> DeleteAsync(long claimAssessmentId, CancellationToken cancellationToken = default)
    {
        var claimAssessment = await _claimAssessmentRepository.GetByIdAsync(claimAssessmentId, asNoTracking: false, cancellationToken: cancellationToken);

        if (claimAssessment == null || claimAssessment.IsDeleted)
        {
            return false;
        }

        ClaimServiceSupport.ApplySoftDelete(claimAssessment);
        _claimAssessmentRepository.Update(claimAssessment);
        await _claimAssessmentRepository.SaveChangesAsync(cancellationToken);

        return true;
    }
}