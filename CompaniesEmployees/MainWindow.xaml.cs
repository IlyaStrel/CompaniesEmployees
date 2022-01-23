using CompaniesEmployees.VM;
using System;
using System.Windows;

namespace CompaniesEmployees
{
    public partial class MainWindow : Window
    {
        public MainWindow(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            DataContext = new AppVM(serviceProvider);
        }
    }
}