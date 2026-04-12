using Microsoft.EntityFrameworkCore;
using JobTracker.Data;
using JobTracker.Models;
using JobTracker.DTOs;

namespace JobTracker.Services;

public class JobService : IJobService
{
    private readonly AppDbContext _context;

    public JobService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<JobResponseDto>> GetAllAsync()
    {
        return await _context.Jobs
            .Select(j => new JobResponseDto
            {
                Id = j.Id,
                Company = j.Company,
                Position = j.Position,
                Status = j.Status,
                AppliedAt = j.AppliedAt,
                Notes = j.Notes
            })
            .ToListAsync();
    }

    public async Task<JobResponseDto?> GetByIdAsync(int id)
    {
        var job = await _context.Jobs.FindAsync(id);
        if (job == null) return null;

        return new JobResponseDto
        {
            Id = job.Id,
            Company = job.Company,
            Position = job.Position,
            Status = job.Status,
            AppliedAt = job.AppliedAt,
            Notes = job.Notes
        };
    }

    public async Task<JobResponseDto> CreateAsync(CreateJobDto dto)
    {
        var job = new Job
        {
            Company = dto.Company,
            Position = dto.Position,
            Status = dto.Status,
            Notes = dto.Notes
        };

        _context.Jobs.Add(job);
        await _context.SaveChangesAsync();

        return new JobResponseDto
        {
            Id = job.Id,
            Company = job.Company,
            Position = job.Position,
            Status = job.Status,
            AppliedAt = job.AppliedAt,
            Notes = job.Notes
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var job = await _context.Jobs.FindAsync(id);
        if (job == null) return false;
        _context.Jobs.Remove(job);
        await _context.SaveChangesAsync();
        return true;
    }
}