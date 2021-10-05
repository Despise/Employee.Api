using AutoMapper;
using Employees.Application.Features.Employee.Commands;
using Employees.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Employees.Application.Handlers
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private IEmployee _employee;

        public DeleteEmployeeCommandHandler(
            IEmployee employee
            )
        {
            _employee = employee;
        }
        public async Task<bool> Handle(DeleteEmployeeCommand cmd, CancellationToken cancellationToken)
        {
            var emp = await _employee.DeleteEmployee(cmd.Id);
            return emp;
        }
    }
}
