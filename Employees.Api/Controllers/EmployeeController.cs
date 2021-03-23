using AutoMapper;
using Employees.Core.DTOs;
using Employees.Core.Entities;
using Employees.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employee;
        private readonly IMapper _mapper;

        public EmployeeController(
            IEmployee employee,
            IMapper mapper
            )
        {
            _employee = employee;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllEmployees")]
        public async Task<IActionResult> GetAllAsync()
        {
            var emps = await _employee.GetEmployees();
            var empsDtos = _mapper.Map<IEnumerable<EmployeeDto>>(emps);
            return Ok(empsDtos);
        }

        [HttpGet]
        [Route("GetEmployee")]
        public async Task<IActionResult> Get(int rut)
        {
            var emp = await _employee.GetEmployee(rut);
            var empDto = _mapper.Map<EmployeeDto>(emp);
            return Ok(empDto);
        }

        [HttpPost]
        [Route("CreateEmployee")]
        public async Task<IActionResult> Post([FromBody] EmployeeDto employeeDto)
        {
            var emp = _mapper.Map<Employee>(employeeDto);
            await _employee.InsertEmployee(emp);
            return Ok(emp);
        }

        //[HttpPut]
        //[Route("UpdateEmployee")]
        //public ActionResult Put([FromBody] Employee employee) {
        //    var rep = _employeeContext.Employee.Update(employee);
        //    _employeeContext.SaveChanges();
        //    return Ok();
        //}
        //[HttpDelete]
        //[Route("DeleteEmployee")]
        //public ActionResult Delete(int rut) {
        //    var rep = _employeeContext.Employee.Where(x => x.IdRut == rut).FirstOrDefault();
        //    _employeeContext.Employee.Remove(rep);
        //    _employeeContext.SaveChanges();
        //    return Ok();
        //}
    }
}