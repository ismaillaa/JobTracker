namespace JobTracker.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Company { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime AppliedAt { get; set; } = DateTime.UtcNow;
        public string? Notes { get; set; }
    }
}
