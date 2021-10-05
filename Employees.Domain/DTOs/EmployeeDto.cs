using System;

namespace Employees.Domain.DTOs
{
    public class EmployeeDto
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
    }
}
