using Employees.Domain.DTOs;
using MediatR;
using System.Collections.Generic;

namespace Employees.Application.Features.Employee.Queries
{
    public class GetEmployeesListQuery : IRequest<List<EmployeeDto>>
    {
    }
}
