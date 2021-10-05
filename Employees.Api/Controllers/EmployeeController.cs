using Employees.Application.Features.Employee.Commands;
using Employees.Application.Features.Employee.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Employees.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(
            IMediator mediator
            )
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetAllEmployees")]
        public async Task<IActionResult> GetAllAsync()
        {
            var emp = await _mediator.Send(new GetEmployeesListQuery());
            return Ok(emp);
        }

        [HttpGet]
        [Route("GetEmployee")]
        public async Task<IActionResult> Get(int rut)
        {
            var emp = await _mediator.Send(new GetEmployeeById(rut));
            return Ok(emp);
        }

        [HttpPost]
        [Route("CreateEmployee")]
        public async Task<IActionResult> Post([FromBody] CreateEmployeeCommand cmd)
        {
            var resp = await _mediator.Send(cmd);
            //return Ok(resp);
            return CreatedAtAction(nameof(Get), new { rut = resp.IdRut }, resp);
            //var emp = _mapper.Map<Employee>(empDto);
            //await _employee.InsertEmployee(emp);
            //return Ok(emp);
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> Put([FromBody] UpdateEmployeeCommand cmd)
        {
            var emp = await _mediator.Send(cmd);
            return CreatedAtAction(nameof(Get), new { rut = emp.IdRut }, emp);
            //var emp = _mapper.Map<Employee>(empDto);
            //var resp = await _employee.UpdateEmployee(emp);
            //return Ok(resp);

            //var rep = _employeeContext.Employee.Update(employee);
            //_employeeContext.SaveChanges();
            //return Ok();
        }

        [HttpDelete]
        [Route("DeleteEmployee")]
        public async Task<IActionResult> Delete(DeleteEmployeeCommand cmd)
        {
            var resp = await _mediator.Send(cmd);
            return Ok(resp);

            //var resp = await _employee.DeleteEmployee(rut);
            //return Ok(resp);

            //var rep = _employeeContext.Employee.Where(x => x.IdRut == rut).FirstOrDefault();
            //_employeeContext.Employee.Remove(rep);
            //_employeeContext.SaveChanges();
            //return Ok();
        }
    }
}