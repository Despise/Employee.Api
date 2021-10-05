using AutoMapper;
using Employees.Application.Features.Employee.Queries;
using Employees.Domain.DTOs;
using Employees.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Employees.Application.Handlers
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeById, EmployeeDto>
    {
        private readonly IEmployee _employee;
        private readonly IMapper _mapper;

        public GetEmployeeByIdHandler(
            IEmployee employee,
            IMapper mapper
            )
        {
            _employee = employee;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> Handle(GetEmployeeById request, CancellationToken cancellationToken)
        {
            var emp = await _employee.GetEmployee(request.Id);
            //var empDto = _mapper.Map<EmployeeDto>(emp);
            return _mapper.Map<EmployeeDto>(emp);
        }
    }
}
