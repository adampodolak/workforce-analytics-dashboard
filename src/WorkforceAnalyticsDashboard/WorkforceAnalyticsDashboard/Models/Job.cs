namespace WorkforceAnalyticsDashboard.Models
{
    public class Job
    {
        public int JobID { get; set; }
        public string? JobTitle { get; set; }
        public string? JobLevel { get; set; }

        public int? DepartmentID { get; set; }
        public Department? Department { get; set; }

        public ICollection<Employee>? Employees { get; set; }
    }
}
