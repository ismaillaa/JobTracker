using JobTracker.DTOs;

namespace JobTracker.Services;

public interface IJobService
{
    Task<List<JobResponseDto>> GetAllAsync();
    Task<JobResponseDto?> GetByIdAsync(int id);
    Task<JobResponseDto> CreateAsync(CreateJobDto dto);
    Task<bool> DeleteAsync(int id);
}