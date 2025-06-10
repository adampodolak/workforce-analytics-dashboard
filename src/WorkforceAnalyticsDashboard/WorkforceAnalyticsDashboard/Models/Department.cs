namespace WorkforceAnalyticsDashboard.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }

        // Navigation property (optional)
        public ICollection<Employee>? Employees { get; set; }
    }
}
