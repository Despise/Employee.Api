using Employees.Core.Entities;
using Employees.Core.Interfaces;
using Employees.Infrastructure.Persistencia;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployee
    {

        private readonly EmployeeContext _employeeContext;

        public EmployeeRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public async Task<Employee> GetEmployee(int iRut)
        {
            var emp = await _employeeContext.Employee
                .FirstOrDefaultAsync(x => x.IdRut == iRut);

            return emp;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var emps = await _employeeContext.Employee.ToListAsync();

            return emps;
        }

        public async Task InsertEmployee(Employee employee)
        {
            _employeeContext.Employee.Add(employee);
            await _employeeContext.SaveChangesAsync();
        }
    }
}
