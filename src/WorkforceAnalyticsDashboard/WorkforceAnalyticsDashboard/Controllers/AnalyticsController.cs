using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkforceAnalyticsDashboard.Models;

namespace WorkforceAnalyticsDashboard.Controllers
{
    public class AnalyticsController : Controller
    {
        private readonly AppDbContext _context;

        public AnalyticsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var currentYear = DateTime.UtcNow.Year;

            var avgTenure = await _context.Employees
                .Select(e => currentYear - e.HireDate.Year)
                .AverageAsync();

            var totalEmployees = _context.Employees.Count();
            
            var inactiveEmployees = _context.Employees
                .Where(e => e.Status == "Inactive")
                .Count();

            var turnoverRate = totalEmployees > 0
                ? Math.Round((double)inactiveEmployees / totalEmployees * 100, 1)
                : 0;

            var employeesByDept = _context.Employees
                .Include(e => e.Department)
                .AsEnumerable()
                .GroupBy(e => e.Department?.Name ?? "Unknown")
                .ToDictionary(g => g.Key, g => g.Count());

            var hiresOverTime = _context.Employees
                .Where(e => e.HireDate <= DateTime.Now)
                .AsEnumerable()
                .GroupBy(e => e.HireDate.Year.ToString()) // Group by year
                .OrderBy(g => g.Key)
                .ToDictionary(g => g.Key, g => g.Count());

            var avgSalary = _context.Employees
                .Where(e => e.Status == "Active")
                .AsEnumerable()
                .Select(e => e.Salary)
                .DefaultIfEmpty(0)
                .Average();

            var viewModel = new AnalyticsViewModel
            {
                TotalEmployees = totalEmployees,
                AverageTenure = Math.Round(avgTenure, 1),
                TurnoverRate = turnoverRate,
                EmployeesByDepartment = employeesByDept,
                HiresOverTime = hiresOverTime,
                AverageSalary = Math.Round((double)avgSalary, 2)
            };

            return View(viewModel);
        }
    }
}
