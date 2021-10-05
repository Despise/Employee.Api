using Employees.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employees.Infrastructure.Persistencia
{
    public class EmployeeContext : DbContext, IEmployeeContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }
        public DbSet<Employee> Employee { get; set; }
    }
}
