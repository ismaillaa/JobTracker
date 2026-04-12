using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobTracker.Data;
using JobTracker.Models;
using JobTracker.DTOs;

namespace JobTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobsController : ControllerBase
{
    private readonly AppDbContext _context;

    public JobsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var jobs = await _context.Jobs
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

        return Ok(jobs);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var job = await _context.Jobs.FindAsync(id);
        if (job == null) return NotFound();

        var dto = new JobResponseDto
        {
            Id = job.Id,
            Company = job.Company,
            Position = job.Position,
            Status = job.Status,
            AppliedAt = job.AppliedAt,
            Notes = job.Notes
        };

        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateJobDto dto)
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

        var response = new JobResponseDto
        {
            Id = job.Id,
            Company = job.Company,
            Position = job.Position,
            Status = job.Status,
            AppliedAt = job.AppliedAt,
            Notes = job.Notes
        };

        return CreatedAtAction(nameof(GetById), new { id = job.Id }, response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var job = await _context.Jobs.FindAsync(id);
        if (job == null) return NotFound();
        _context.Jobs.Remove(job);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}