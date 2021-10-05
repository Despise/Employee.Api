using AutoMapper;
using Employees.Application.Features.Employee.Commands;
using Employees.Domain.DTOs;
using Employees.Domain.Entities;
using Employees.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Employees.Application.Handlers
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeDto>
    {
        private readonly IEmployee _employee;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(
            IMapper mapper, 
            IEmployee employee
            )
        {
            _mapper = mapper;
            _employee = employee;
        }

        public async Task<EmployeeDto> Handle(UpdateEmployeeCommand cmd, CancellationToken cancellationToken)
        {
            var emp = _mapper.Map<Employee>(cmd.EmployeeDto);
            await _employee.UpdateEmployee(emp);
            return _mapper.Map<EmployeeDto>(emp);
        }
    }
}
