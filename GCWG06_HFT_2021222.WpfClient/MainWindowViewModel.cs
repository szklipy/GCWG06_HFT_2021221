using GCWG06_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCWG06_HFT_2021222.WpfClient
{
    public class MainWindowViewModel
    {
        public RestCollection<Employee> Employees { get; set; }
        public MainWindowViewModel()
        {
            Employees = new RestCollection<Employee>("http://localhost:16099/", "employee");

        }
    }
}
