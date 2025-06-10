namespace WorkforceAnalyticsDashboard.Dtos
{
    public class EmployeeExportDto
    {
        public int EmployeeID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public string? Status { get; set; }
        public string? DepartmentName { get; set; }
        public string? DepartmentLocation { get; set; }
        public string? JobTitle { get; set; }
        public string? JobLevel { get; set; }
    }
}
