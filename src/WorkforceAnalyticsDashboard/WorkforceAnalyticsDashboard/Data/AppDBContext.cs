using Microsoft.EntityFrameworkCore;
using WorkforceAnalyticsDashboard.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Job> Jobs { get; set; }
}

