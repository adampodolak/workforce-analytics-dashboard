namespace WorkforceAnalyticsDashboard.Models
{
    public class AnalyticsViewModel
    {
        public int TotalEmployees { get; set; }

        public double AverageTenure { get; set; }
        
        public double TurnoverRate { get; set; }

        public double AverageSalary { get; set; }

        public required Dictionary<string, int> EmployeesByDepartment { get; set; }
        
        public required Dictionary<string, int> HiresOverTime { get; set; }
    }
}
