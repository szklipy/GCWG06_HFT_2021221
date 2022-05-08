using GCWG06_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GCWG06_HFT_2021222.WpfClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Employee> Employees { get; set; }

        private Employee selectedEmployee;

        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set 
            {

                if (value != null)
                {
                    selectedEmployee = new Employee()
                    {
                        Name = value.Name,
                        Employee_id = value.Employee_id,
                        Salary = value.Salary
                    };
                    OnPropertyChanged();
                    (DeleteEmployeeCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateEmployeeCommand { get; set; }
        public ICommand DeleteEmployeeCommand { get; set; }
        public ICommand UpdateEmployeeCommand { get; set; }

        public MainWindowViewModel()
        {
            Employees = new RestCollection<Employee>("http://localhost:16099/", "employee"/*,"hub"*/);

            CreateEmployeeCommand = new RelayCommand(
                () =>
                {
                    Employees.Add(new Employee()
                    {
                        Name = SelectedEmployee.Name,
                        Salary = SelectedEmployee.Salary,                        
                    });
                });
            DeleteEmployeeCommand = new RelayCommand(
                ()=>
                {
                    Employees.Delete(SelectedEmployee.Employee_id);
                },
                ()=>
                {
                   return SelectedEmployee != null;
                }
                );
            UpdateEmployeeCommand = new RelayCommand(() =>
            {
                Employees.Update(SelectedEmployee);
            });

            SelectedEmployee = new Employee();
        }
    }
}
