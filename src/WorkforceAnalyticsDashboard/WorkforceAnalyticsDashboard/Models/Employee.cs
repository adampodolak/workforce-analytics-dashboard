using System.ComponentModel.DataAnnotations.Schema;

namespace WorkforceAnalyticsDashboard.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        [Column(TypeName = "timestamp without time zone")]
        public DateTime HireDate { get; set; }
        public int DepartmentID { get; set; }
        public int JobID { get; set; }
        public decimal Salary { get; set; }
        public string? Status { get; set; }

        public Department? Department { get; set; }
        public Job? Job { get; set; }
    }
}

