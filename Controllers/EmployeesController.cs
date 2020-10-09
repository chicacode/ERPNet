
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ERPNet.Data;
using ERPNet.Models;
using Microsoft.AspNetCore.Cors;

namespace ERPNet.Controllers
{
    [EnableCors ( "AllowSpecificOrigin" )]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ERPNetContext _context;

        public EmployeesController(ERPNetContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            return await _context.Employee.ToListAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            //var employee = await _context.Employee.FindAsync(id);

            var employee = await _context.Employee
            .Include ( c => c.Person )
            .SingleOrDefaultAsync ( c => c.PersonId == id );

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            var editEmployee = await _context.Employee.FindAsync ( id );

            if(editEmployee == null)
            {
                return NotFound ();
            }

            var person = await _context.Person.FindAsync ( employee.PersonId );

            if(person == null)
            {
                return NotFound ();
            }
            editEmployee.PositionJob = employee.PositionJob;
            editEmployee.Salary = employee.Salary;
            editEmployee.UserName = employee.UserName;
            editEmployee.Password = employee.Password;

            person.Name = employee.Person.Name;
            person.Name = employee.Person.LastName;

            _context.Entry ( person ).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {

            var person = new Person
            {
                Name = employee.Person.Name,
                LastName = employee.Person.LastName
            };

            _context.Person.Add ( person );
            await _context.SaveChangesAsync ();

            var newEmployee = new Employee
            {
                PersonId = employee.PersonId,
                PositionJob = employee.PositionJob,
                Salary = employee.Salary,
                UserName = employee.UserName,
                Password = employee.Password
            };

            _context.Employee.Add( newEmployee );
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, newEmployee );
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }
    }
}
