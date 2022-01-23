using CE.Data;
using CE.EFC.Base;
using CE.Model;

namespace CE.EFC
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationContext context) : base(context) { }
    }
}