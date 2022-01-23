using CE.Data;
using Microsoft.Extensions.DependencyInjection;

namespace CE.EFC.Base
{
    public static class DependencyIngectionHelper
    {
        public static void RegisterInformationData(this IServiceCollection service)
        {
            service.AddTransient<ICompanyRepository, CompanyRepository>();
            service.AddTransient<ICompanyEmployeeRepository, CompanyEmployeeRepository>();
            service.AddTransient<IEmployeeRepository, EmployeeRepository>();
        }
    }
}