using Employees.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.Core.Interfaces
{
    public interface IEmployee
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int iRut);
        Task InsertEmployee(Employee employee);
        //Task<Employee> Put(Employee employee);
        //Task<Employee> Delete(int iRut);
    }
}
