namespace JobTracker.DTOs;

public class CreateJobDto
{
    public string Company { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string? Notes { get; set; }
}

public class JobResponseDto
{
    public int Id { get; set; }
    public string Company { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime AppliedAt { get; set; }
    public string? Notes { get; set; }
}