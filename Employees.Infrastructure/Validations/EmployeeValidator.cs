using Employees.Domain.DTOs;
using FluentValidation;
using System;

namespace Employees.Infrastructure.Validations
{
    public class EmployeeValidator : AbstractValidator<EmployeeDto>
    {
        public EmployeeValidator()
        {
            RuleFor(employeeDto => employeeDto.IdRut)
                .NotNull()
                .NotEmpty();
            RuleFor(emp => emp.Dv)
                .Length(1)
                .NotNull()
                .NotEmpty();
            RuleFor(emp => emp.FirstName)
                .NotNull()
                .NotEmpty()
                .Length(2, 40);
            RuleFor(emp => emp.LastName)
                .NotNull()
                .NotEmpty()
                .Length(2, 40);
            RuleFor(emp => emp.BirthDate)
                .NotNull()
                .NotEmpty()
                .GreaterThan(DateTime.MinValue);
            RuleFor(emp => emp.Contact)
                .NotNull();
            RuleFor(emp => emp.Email)
                .NotNull()
                .EmailAddress();
            RuleFor(emp => emp.Address)
                .NotNull()
                .Length(1, 60);
            RuleFor(emp => emp.Nationality)
                .NotNull()
                .Length(1, 15);
            RuleFor(emp => emp.ModifiedDate)
                .NotNull()
                .GreaterThan(DateTime.MinValue);
        }
    }
}
