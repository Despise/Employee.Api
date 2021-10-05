using AutoMapper;
using Employees.Application.Features.Employee.Commands;
using Employees.Application.Models.Response;
using Employees.Domain.Entities;
using Employees.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Employees.Application.Handlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeResponse>
    {
        private readonly IEmployee _employee;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(
            IEmployee employee,
            IMapper mapper
            )
        {
            _employee = employee ?? throw new ArgumentNullException(nameof(employee));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }
        public async Task<EmployeeResponse> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
        {
            var emp = _mapper.Map<Employee>(command);
            await _employee.InsertEmployee(emp);
            return _mapper.Map<EmployeeResponse>(emp);
        }
    }
}
