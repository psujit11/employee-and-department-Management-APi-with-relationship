using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MytemplateApi.Models;

namespace MytemplateApi.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}
