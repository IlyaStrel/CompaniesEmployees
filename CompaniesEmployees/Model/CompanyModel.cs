using CE.Data;
using CE.Model;
using Microsoft.Extensions.DependencyInjection;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;

namespace CompaniesEmployees.Model
{
    public class CompanyModel : BindableBase
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyModel(IServiceProvider serviceProvider)
        {
            _companyRepository = serviceProvider.GetService<ICompanyRepository>();
        }


        public ObservableCollection<Company> GetCompanies()
        {
            return new ObservableCollection<Company>(_companyRepository.Get());
        }

        public void AddCompany(Company company)
        {
            _companyRepository.Add(company);

            RaisePropertyChanged("Companies");
        }

        public void RemoveCompany(int id)
        {
            var company = _companyRepository.GetById(id);

            if (company != null)
                _companyRepository.Remove(company);

            RaisePropertyChanged("Companies");
        }

        public void EditCompany(Company company)
        {
            _companyRepository.Update(company);

            RaisePropertyChanged("Companies");
        }
    }
}