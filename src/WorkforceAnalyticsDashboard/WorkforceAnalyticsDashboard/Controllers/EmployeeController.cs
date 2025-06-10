using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkforceAnalyticsDashboard.Models;
using WorkforceAnalyticsDashboard.Dtos;
using System.Xml.Serialization;
using System.IO;

namespace WorkforceAnalyticsDashboard.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Employee
        public async Task<IActionResult> Index(
            int? departmentId,
            string status,
            DateTime? startDate,
            DateTime? endDate,
            string sortBy = "LastName")
        {
            var employees = _context.Employees
            .Include(e => e.Department)
            .Include(e => e.Job)
            .AsQueryable();

            // Filtering
            if (departmentId.HasValue)
                employees = employees.Where(e => e.DepartmentID == departmentId.Value);

            if (!string.IsNullOrEmpty(status))
                employees = employees.Where(e => e.Status == status);

            if (startDate.HasValue)
                employees = employees.Where(e => e.HireDate >= startDate.Value);

            if (endDate.HasValue)
                employees = employees.Where(e => e.HireDate <= endDate.Value);

            // Sorting
            employees = sortBy switch
            {
                "FirstName" => employees.OrderBy(e => e.FirstName),
                "HireDate" => employees.OrderByDescending(e => e.HireDate),
                "Salary" => employees.OrderByDescending(e => e.Salary),
                _ => employees.OrderBy(e => e.LastName) // default
            };

            ViewBag.DepartmentId = departmentId;
            ViewBag.Status = status;
            ViewBag.StartDate = startDate?.ToString("yyyy-MM-dd");
            ViewBag.EndDate = endDate?.ToString("yyyy-MM-dd");
            ViewBag.SortBy = sortBy;

            var result = await employees.ToListAsync();
            return View(result);
        }


        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeID,FirstName,LastName,Email,PhoneNumber,HireDate,DepartmentID,JobID,Salary,Status")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeID,FirstName,LastName,Email,PhoneNumber,HireDate,DepartmentID,JobID,Salary,Status")] Employee employee)
        {
            if (id != employee.EmployeeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ExportToXml(string? status, int? departmentId, DateTime? startDate, DateTime? endDate)
        {
            var query = _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Job)
                .AsQueryable();

            if (!string.IsNullOrEmpty(status))
                query = query.Where(e => e.Status == status);

            if (departmentId.HasValue)
                query = query.Where(e => e.DepartmentID == departmentId.Value);

            if (startDate.HasValue)
                query = query.Where(e => e.HireDate >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(e => e.HireDate <= endDate.Value);

            var exportList = await query.Select(e => new EmployeeExportDto
            {
                EmployeeID = e.EmployeeID,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                HireDate = e.HireDate,
                Salary = e.Salary,
                Status = e.Status,
                DepartmentName = e.Department != null ? e.Department.Name : null,
                DepartmentLocation = e.Department != null ? e.Department.Location : null,
                JobTitle = e.Job != null ? e.Job.JobTitle : null,
                JobLevel = e.Job != null ? e.Job.JobLevel : null
            }).ToListAsync();

            var serializer = new XmlSerializer(typeof(List<EmployeeExportDto>));
            var memoryStream = new MemoryStream();
            serializer.Serialize(memoryStream, exportList);
            memoryStream.Position = 0;

            return File(memoryStream, "application/xml", "employee-data.xml");

            serializer.Serialize(memoryStream, exportList);
            memoryStream.Position = 0;

            return File(memoryStream, "application/xml", "employees.xml");
        }


        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeID == id);
        }
    }
}
