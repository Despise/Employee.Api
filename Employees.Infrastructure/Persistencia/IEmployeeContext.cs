using Employees.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employees.Infrastructure.Persistencia
{
    public interface IEmployeeContext
    {
        DbSet<Employee> Employee { get; set; }
    }
}