﻿using GCWG06_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCWG06_HFT_2021221.Logic
{
    public interface IEmployeeLogic
    {
        Employee GetEmployeeById(int id);
        IList<Employee> GetAllEmployees();
        void Create(Employee employee);
        void Delete(int id);
        void Update(Employee employee);
    }
}
