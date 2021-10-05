using Employees.Domain.DTOs;
using MediatR;

namespace Employees.Application.Features.Employee.Queries
{
    public class GetEmployeeById : IRequest<EmployeeDto>
    {
        public int Id { get; }
        public GetEmployeeById(int id)
        {
            Id = id;
        }
    }
}
