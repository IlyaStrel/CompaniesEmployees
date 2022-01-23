using CE.Data.Base;
using CE.Model;
using System.Collections.Generic;

namespace CE.Data
{
    public partial interface ICompanyRepository : IRepository<Company>
    {
        IEnumerable<Company> GetWithRelated();
    }
}