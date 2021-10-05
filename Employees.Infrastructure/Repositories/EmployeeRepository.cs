using Employees.Domain.Entities;
using Employees.Domain.Interfaces;
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

        public async Task<List<Employee>> GetEmployees()
        {
            var emps = await _employeeContext.Employee.ToListAsync();
            return emps;
        }

        public async Task InsertEmployee(Employee employee)
        {
            _employeeContext.Employee.Add(employee);
            await _employeeContext.SaveChangesAsync();
        }

        public async Task<bool> UpdateEmployee(Employee employee) {
            _employeeContext.Update(employee);
            return await _employeeContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteEmployee(int iRut) {
            //var rep = _employeeContext.Employee.Where(x => x.IdRut == rut).FirstOrDefault();
            var emp = await GetEmployee(iRut);
            _employeeContext.Employee.Remove(emp);
            return await _employeeContext.SaveChangesAsync() > 0;
        }
    }
}
