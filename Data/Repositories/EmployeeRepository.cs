using ERPNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPNet.Data.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee, ERPNetContext>
    {
        private readonly ERPNetContext _context;
        public EmployeeRepository(ERPNetContext context ) : base(context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllEmployee ( )
        {
            return await _context.Set<Employee> ()
                .Include ( e => e.Person )
                .ToListAsync ();
        }
        public async Task<Employee> GetByPerson ( int id )
        {
            return await _context.Set<Employee> ()
                .Include( e => e.Person)
                .SingleOrDefaultAsync ( e => e.PersonId == id );
        }

        public async Task<Employee> AddByPerson ( Person employee )
        {

            //_context.Set<Employee> ().Add ( employee );
            //await _context.SaveChangesAsync ();
            //return employee;

            //Person person = new Person
            //{
            //    Name = employee.Person.Name,
            //    LastName = employee.Person.LastName
            //};

            //_context.Person.Add ( person );
            //await _context.SaveChangesAsync ();

            //var newEmployee = new Employee
            //{
            //    PersonId = employee.PersonId,
            //    PositionJob = employee.PositionJob,
            //    Salary = employee.Salary,
            //    UserName = employee.UserName,
            //    Password = employee.Password
            //};

            //_context.Set<Employee> ().Add ( newEmployee );
            //await _context.SaveChangesAsync ();

            //return newEmployee;

            Person person = new Person ();

            person.Name = employee.Name;
            person.LastName = employee.LastName;
         

            _context.Set<Person> ().Add ( person );
            await _context.SaveChangesAsync ();


            var newEmployee = new Employee ();

            newEmployee.PersonId = employee.Employee.PersonId;
            newEmployee.PositionJob = employee.Employee.PositionJob;
            newEmployee.Salary = employee.Employee.Salary;
            newEmployee.UserName = employee.Employee.UserName;
            newEmployee.Password = employee.Employee.Password;

            

            _context.Set<Employee> ().Add ( newEmployee );
            await _context.SaveChangesAsync ();


            return newEmployee;
        }
    }
}
