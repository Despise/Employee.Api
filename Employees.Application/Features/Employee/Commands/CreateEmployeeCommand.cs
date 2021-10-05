using Employees.Application.Models.Response;
using MediatR;
using System;

namespace Employees.Application.Features.Employee.Commands
{
    public class CreateEmployeeCommand : IRequest<EmployeeResponse>
    {
        public int? IdRut { get; set; }
        public string Dv { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Nationality { get; set; }
        public DateTime ModifiedDate { get; set; }

        //[DataMember]
        //public Domain.Entities.Employee Employee { get; set; }
        //public CreateEmployeeCommand(Domain.Entities.Employee employee)
        //{

        //    //Employee = employee;
        //    //Employee = new Domain.Entities.Employee()
        //    //{
        //    //    Domain.Entities.Employee.IdRut = employee.IdRut,
        //    //    Domain.Entities.Employee.Dv = employee.Dv,
        //    //    Domain.Entities.Employee.FirstName = employee.FirstName,
        //    //    Domain.Entities.Employee.LastName = employee.LastName,
        //    //    Domain.Entities.Employee.BirthDate = employee.BirthDate,
        //    //    Domain.Entities.Employee.Contact = employee.Contact,
        //    //    Domain.Entities.Employee.Email = employee.Email,
        //    //    Domain.Entities.Employee.Address = employee.Address,
        //    //    Domain.Entities.Employee.Nationality = employee.Nationality,
        //    //    Domain.Entities.Employee.ModifiedDate = employee.ModifiedDate,
        //    //};

        //}
    }
}
