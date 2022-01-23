using CE.Model;
using CompaniesEmployees.Model;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace CompaniesEmployees.VM
{
    public class AppVM : BindableBase
    {
        private readonly CompanyModel _companyModel;
        private readonly EmployeeModel _employeeModel;
        private Employee _employee;
        private Company _company;

        public AppVM(IServiceProvider serviceProvider)
        {
            _companyModel = new(serviceProvider);
            _companyModel.PropertyChanged += (s, e) => RaisePropertyChanged(e.PropertyName);
            _employeeModel = new(serviceProvider);
            _employeeModel.PropertyChanged += (s, e) => RaisePropertyChanged(e.PropertyName);

            ClearSelectedItem = new DelegateCommand<ListBox>(
                elem =>
                {
                    elem.SelectedIndex = -1;
                });

            AddCompanyCommand = new DelegateCommand<Company>(
                company =>
                {
                    if (!string.IsNullOrEmpty(company.Name))
                        _companyModel.AddCompany(company);
                });

            RemoveCompanyCommand = new DelegateCommand<int?>(
                id =>
                {
                    if (id.HasValue)
                        _companyModel.RemoveCompany(id.Value);
                });

            EditCompanyCommand = new DelegateCommand<Company>(
                company =>
                {
                    if (!string.IsNullOrEmpty(company.Name))
                        _companyModel.EditCompany(company);
                });

            AddEmployeeCommand = new DelegateCommand<Employee>(
                employee =>
                {
                    if (!string.IsNullOrEmpty(employee.Name)
                        && !string.IsNullOrEmpty(employee.Surname))
                        _employeeModel.AddEmployee(employee);
                });

            RemoveEmployeeCommand = new DelegateCommand<int?>(
                id =>
                {
                    if (id.HasValue)
                        _employeeModel.RemoveEmployee(id.Value);
                });

            EditEmployeeCommand = new DelegateCommand<Employee>(
                employee =>
                {
                    if (!string.IsNullOrEmpty(employee.Name)
                        && !string.IsNullOrEmpty(employee.Surname))
                        _employeeModel.EditEmployee(employee);
                });
        }

        public ObservableCollection<Company> Companies
        {
            get
            {
                return _companyModel.GetCompanies();
            }
        }
        public Company SelectedCompany
        {
            get => _company;
            set
            {
                _company = value;
                RaisePropertyChanged("SelectedCompany");
            }
        }
        public ObservableCollection<Employee> Employees
        {
            get
            {
                return _employeeModel.GetEmployees();
            }
        }
        public Employee SelectedEmployee
        {
            get => _employee;
            set
            {
                _employee = value;
                RaisePropertyChanged("SelectedEmployee");
            }
        }

        public DelegateCommand<ListBox> ClearSelectedItem { get; }
        public DelegateCommand<Company> AddCompanyCommand { get; }
        public DelegateCommand<int?> RemoveCompanyCommand { get; }
        public DelegateCommand<Company> EditCompanyCommand { get; }
        public DelegateCommand<Employee> AddEmployeeCommand { get; }
        public DelegateCommand<int?> RemoveEmployeeCommand { get; }
        public DelegateCommand<Employee> EditEmployeeCommand { get; }
    }
}