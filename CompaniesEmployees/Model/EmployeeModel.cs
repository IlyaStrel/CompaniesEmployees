using CE.Data;
using CE.Model;
using Microsoft.Extensions.DependencyInjection;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;

namespace CompaniesEmployees.Model
{
    public class EmployeeModel : BindableBase
    {
        private readonly ICompanyEmployeeRepository _companyEmployeeRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeModel(IServiceProvider serviceProvider)
        {
            _employeeRepository = serviceProvider.GetService<IEmployeeRepository>();
            _companyEmployeeRepository = serviceProvider.GetService<ICompanyEmployeeRepository>();
        }


        public ObservableCollection<Employee> GetEmployees()
        {
            return new ObservableCollection<Employee>(_employeeRepository.Get());
        }

        public void AddEmployee(Employee employee, int companyId)
        {
            employee = _employeeRepository.AddAndReturn(employee);

            _companyEmployeeRepository.Add(
                new CompanyEmployee
                {
                    CompanyId = companyId,
                    EmployeeId = employee.Id
                });

            RaisePropertyChanged("Employees");
        }

        public void RemoveEmployee(int id)
        {
            var employ = _employeeRepository.GetById(id);

            if (employ != null)
                _employeeRepository.Remove(employ);

            RaisePropertyChanged("Employees");
        }

        public void EditEmployee(Employee employee)
        {
            _employeeRepository.Update(employee);

            RaisePropertyChanged("Employees");
        }
    }
}