
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ERPNet.Data;
using ERPNet.Models;
using Microsoft.AspNetCore.Cors;
using ERPNet.Data.Repositories;
using System.Net;

namespace ERPNet.Controllers
{
    [EnableCors ( "AllowSpecificOrigin" )]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : GenericController<Employee, EmployeeRepository>
    {

        private readonly EmployeeRepository _repository;
        //private readonly PeopleController _peopleController;
        //private readonly PeopleRepository _peopleRepository;


        public EmployeesController ( EmployeeRepository repository /*, PeopleController peopleController, PeopleRepository peopleRepository*/
             ) : base(repository)
        {
            _repository = repository;
            //_peopleRepository = peopleRepository;
            //_peopleController = peopleController;
        }

        // GET: api/Employees
       [HttpGet( "byperson" )]
        public async Task<IEnumerable<Employee>> GetAllEmployees ( )
        {
            return await _repository.GetAllEmployees ();
        }

        //GET: api/Employees/5
        [HttpGet ( "person/{id}" )]
        public async Task<ActionResult<Employee>> GetByPerson ( int id )
        {
            var employeebyPerson = await _repository.GetByPerson ( id );

            if(employeebyPerson == null)
            {
                return NotFound ();
            }
            return employeebyPerson;
        }

        //// PUT: api/Employees/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut ( "edit/{id}" )]
        public async Task<IActionResult> EditEmployee (  Employee employee )
        {
            var personId = (await _repository.GetByPerson ( employee.PersonId )).Id;
            //Person person = new Person
            //{
            //    Id = personId,
            //    Name = employee.Person.Name,
            //    LastName = employee.Person.LastName
            //};
            //var updatePerson = await _peopleController.EditPerson ( person );



            var employeeEdited = await _repository.GetEmployee ( employee.Id );

            employeeEdited.PositionJob = employee.PositionJob;
            employeeEdited.Salary = employee.Salary;
            employeeEdited.UserName = employee.UserName;
            employeeEdited.Password = employee.Password;

            return (IActionResult)await _repository.Update ( employeeEdited );
        }

        //// POST: api/Employees
        [HttpPost ( "person" )]
        public async Task<ActionResult<Employee>> PostEmployee ( Person employee )
        {
            //TODO CON AUTH
            var newEmployee = await _repository.AddByPerson ( employee );
     
            return CreatedAtAction ( "GetEmployee", new { id = employee.Id }, newEmployee );
        }

        //// DELETE: api/Employees/5
        [HttpDelete ( "{id}" )]
        public async Task<ActionResult<Employee>> DeleteEmployee ( int id )
        {
            var employee = await _repository.Delete ( id );
            if(employee == null)
            {
                return NotFound ();
            }

            return employee;
        }

    }
}
