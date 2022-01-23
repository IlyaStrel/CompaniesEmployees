using CE.Data;
using CE.EFC.Base;
using CE.Model;

namespace CE.EFC
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationContext context) : base(context) { }
    }
}