using CE.Data;
using CE.EFC.Base;
using CE.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CE.EFC
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly ApplicationContext _context;

        public CompanyRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Company> GetWithRelated()
        {
            return _context.Companies
                           .Include(d => d.CompanyEmployees)
                               .ThenInclude(d => d.Employee);
        }
    }
}