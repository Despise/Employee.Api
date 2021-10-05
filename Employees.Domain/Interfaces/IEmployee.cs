using Employees.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.Domain.Interfaces
{
    public interface IEmployee
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int iRut);
        Task InsertEmployee(Employee employee);
        Task<bool> UpdateEmployee(Employee employee);
        Task<bool> DeleteEmployee(int iRut);
    }
}
