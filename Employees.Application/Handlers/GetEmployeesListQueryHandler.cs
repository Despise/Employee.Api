using AutoMapper;
using Employees.Application.Features.Employee.Queries;
using Employees.Domain.DTOs;
using Employees.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Employees.Application.Handlers
{
    public class GetEmployeesListQueryHandler : IRequestHandler<GetEmployeesListQuery, List<EmployeeDto>>
    {
        private readonly IEmployee _employee;
        private readonly IMapper _mapper;

        public GetEmployeesListQueryHandler(
            IEmployee employee,
            IMapper mapper
            )
        {
            _employee = employee;
            _mapper = mapper;
        }

        public async Task<List<EmployeeDto>> Handle(GetEmployeesListQuery request, CancellationToken cancellationToken)
        {
            var emps = await _employee.GetEmployees();
            return _mapper.Map<List<EmployeeDto>>(emps);
        }
    }
}
