namespace WorkforceAnalyticsDashboard.Models
{
    public class Job
    {
        public int JobID { get; set; }
        public string? JobTitle { get; set; }
        public string? JobLevel { get; set; }

        // Navigation property (optional)
        public ICollection<Employee>? Employees { get; set; }
    }
}
