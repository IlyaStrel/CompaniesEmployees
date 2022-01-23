using CE.Data;
using CE.EFC.Base;
using CE.Model;

namespace CE.EFC
{
    public class CompanyEmployeeRepository : Repository<CompanyEmployee>, ICompanyEmployeeRepository
    {
        public CompanyEmployeeRepository(ApplicationContext context) : base(context) { }
    }
}