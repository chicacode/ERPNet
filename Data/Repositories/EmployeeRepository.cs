using ERPNet.Models;


namespace ERPNet.Data.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee, ERPNetContext>
    {
        public EmployeeRepository(ERPNetContext context ) : base(context)
        {

        }
    }
}
