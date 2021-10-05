using Employees.Domain.DTOs;
using MediatR;

namespace Employees.Application.Features.Employee.Commands
{
    public class UpdateEmployeeCommand : IRequest<EmployeeDto>
    {
        public EmployeeDto EmployeeDto { get; set; }
        public UpdateEmployeeCommand()
        {
        }

        // No es necesario para este caso de uso
        //
        //public UpdateEmployeeCommand(EmployeeDto employeeDto)
        //{
        //    EmployeeDto = employeeDto;
        //}
    }
}
