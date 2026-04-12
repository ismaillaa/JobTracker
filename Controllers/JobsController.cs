using Microsoft.AspNetCore.Mvc;
using JobTracker.DTOs;
using JobTracker.Services;

namespace JobTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobsController : ControllerBase
{
    private readonly IJobService _jobService;

    public JobsController(IJobService jobService)
    {
        _jobService = jobService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var jobs = await _jobService.GetAllAsync();
        return Ok(jobs);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var job = await _jobService.GetByIdAsync(id);
        if (job == null) return NotFound();
        return Ok(job);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateJobDto dto)
    {
        var job = await _jobService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = job.Id }, job);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _jobService.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}