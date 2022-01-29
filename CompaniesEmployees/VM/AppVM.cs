using CE.Model;
using CompaniesEmployees.Model;
using NLog;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace CompaniesEmployees.VM
{
    public class AppVM : BindableBase
    {
        private readonly CompanyModel _companyModel;
        private readonly EmployeeModel _employeeModel;
        private Employee _employee = new Employee();
        private Company _company = new Company();
        private ILogger _logger;

        public AppVM(
            IServiceProvider serviceProvider
            )
        {
            _logger = LogManager.GetCurrentClassLogger();
            _companyModel = new(serviceProvider);
            _companyModel.PropertyChanged += (s, e) => RaisePropertyChanged(e.PropertyName);
            _employeeModel = new(serviceProvider);
            _employeeModel.PropertyChanged += (s, e) => RaisePropertyChanged(e.PropertyName);

            ClearSelectedCompany = new DelegateCommand<ListBox>(
                elem =>
                {
                    elem.SelectedIndex = -1;

                    SelectedCompany = new Company();
                    SelectedEmployee = new Employee();

                    _logger.Info("Clear is true!");
                });

            AddCompanyCommand = new DelegateCommand<Company>(
                company =>
                {
                    if (!string.IsNullOrEmpty(company?.Name))
                    {
                        _companyModel.AddCompany(company);

                        _logger.Info("Adding is true!");
                    }
                });

            RemoveCompanyCommand = new DelegateCommand<int?>(
                id =>
                {
                    if (id.HasValue && id > 0)
                    {
                        _companyModel.RemoveCompany(id.Value);

                        SelectedCompany = new Company();
                        SelectedEmployee = new Employee();

                        _logger.Info("Removing is true!");
                    }
                });

            EditCompanyCommand = new DelegateCommand<Company>(
                company =>
                {
                    if (!string.IsNullOrEmpty(company.Name))
                    {
                        _companyModel.EditCompany(company);

                        _logger.Info("Editing is true!");
                    }
                });

            ClearSelectedEmployee = new DelegateCommand<ListBox>(
                elem =>
                {
                    elem.SelectedIndex = -1;

                    SelectedEmployee = new Employee();
                });

            AddEmployeeCommand = new DelegateCommand<Employee>(
                employee =>
                {
                    if (!string.IsNullOrEmpty(employee?.Name)
                        && !string.IsNullOrEmpty(employee?.Surname)
                        && SelectedCompany?.Id > 0)
                    {
                        _employeeModel.AddEmployee(employee, SelectedCompany.Id);
                    }

                });

            RemoveEmployeeCommand = new DelegateCommand<int?>(
                id =>
                {
                    if (id.HasValue)
                    {
                        _employeeModel.RemoveEmployee(id.Value);
                        SelectedEmployee = new Employee();
                    }
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
                RaisePropertyChanged("Employees");
            }
        }
        public ObservableCollection<Employee> Employees
        {
            get
            {
                SelectedEmployee = new Employee();

                if (SelectedCompany?.CompanyEmployees == null)
                    return new ObservableCollection<Employee>(new List<Employee> { new Employee() });

                return new ObservableCollection<Employee>(SelectedCompany?.CompanyEmployees?.Select(d => d.Employee));
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

        public DelegateCommand<ListBox> ClearSelectedCompany { get; }
        public DelegateCommand<Company> AddCompanyCommand { get; }
        public DelegateCommand<int?> RemoveCompanyCommand { get; }
        public DelegateCommand<Company> EditCompanyCommand { get; }
        public DelegateCommand<ListBox> ClearSelectedEmployee { get; }
        public DelegateCommand<Employee> AddEmployeeCommand { get; }
        public DelegateCommand<int?> RemoveEmployeeCommand { get; }
        public DelegateCommand<Employee> EditEmployeeCommand { get; }
    }
}