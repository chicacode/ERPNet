
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ERPNet.Data;
using ERPNet.Models;
using Microsoft.AspNetCore.Cors;
using ERPNet.Data.Repositories;

namespace ERPNet.Controllers
{
    [EnableCors ( "AllowSpecificOrigin" )]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : GenericController<Employee, EmployeeRepository>
    {

        private readonly EmployeeRepository _repository;

        public EmployeesController ( EmployeeRepository repository ) : base(repository)
        {
            _repository = repository;
        }

        // GET: api/Employees
       [HttpGet( "byperson" )]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees ( )
        {
            return await _repository.GetAllEmployees ();
        }

        //GET: api/Employees/5
        [HttpGet ( "person/{id}" )]
        public async Task<ActionResult<Employee>> GetByPerson ( int id )
        {
            var employeebyPerson = await _repository.GetByPerson ( id );

            return employeebyPerson;
        }

        //// PUT: api/Employees/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutEmployee(int id, Employee employee)
        //{
        //    if (id != employee.Id)
        //    {
        //        return BadRequest();
        //    }

        //    var editEmployee = await _context.Employee.FindAsync ( id );

        //    if(editEmployee == null)
        //    {
        //        return NotFound ();
        //    }

        //    var person = await _context.Person.FindAsync ( employee.PersonId );

        //    if(person == null)
        //    {
        //        return NotFound ();
        //    }
        //    editEmployee.PositionJob = employee.PositionJob;
        //    editEmployee.Salary = employee.Salary;
        //    editEmployee.UserName = employee.UserName;
        //    editEmployee.Password = employee.Password;

        //    person.Name = employee.Person.Name;
        //    person.Name = employee.Person.LastName;

        //    _context.Entry ( person ).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EmployeeExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Employees
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost ( "person" )]
        public async Task<ActionResult<Employee>> PostEmployee ( Person employee )
        {
            var newEmployee = await _repository.AddByPerson ( employee );
     
            return CreatedAtAction ( "GetEmployee", new { id = employee.Id }, newEmployee );
        }

        //// DELETE: api/Employees/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        //{
        //    var employee = await _context.Employee.FindAsync(id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Employee.Remove(employee);
        //    await _context.SaveChangesAsync();

        //    return employee;
        //}

        //private bool EmployeeExists(int id)
        //{
        //    return _context.Employee.Any(e => e.Id == id);
        //}
    }
}
