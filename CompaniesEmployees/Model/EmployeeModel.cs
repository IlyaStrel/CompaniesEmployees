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
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeModel(IServiceProvider serviceProvider)
        {
            _employeeRepository = serviceProvider.GetService<IEmployeeRepository>();
        }


        public ObservableCollection<Employee> GetEmployees()
        {
            return new ObservableCollection<Employee>(_employeeRepository.Get());
        }

        public void AddEmployee(Employee employee)
        {
            _employeeRepository.Add(employee);

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