using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCWG06_HFT_2021221.Logic
{
    public class AveragesResultEmp
    {
        public int DepartmentId { get; set; }
        public string Hospital { get; set; }
        public string DepartmentName { get; set; }
        public double AverageEmployeeNumber { get; set; }
        public override string ToString()
        {
            return $"DEPARTMENT ID: {DepartmentId}" +
                $"HOSPITAL: {Hospital}" +
                $"DEPARTMENT: {DepartmentName}" +
                $", AVERAGE EMPLOYEE NUMBER: {AverageEmployeeNumber}";
        }
        public override bool Equals(object obj)
        {
            if (obj is AveragesResultEmp)
            {
                AveragesResultEmp other = obj as AveragesResultEmp;
                return this.DepartmentName == other.DepartmentName &&
                    this.AverageEmployeeNumber == other.AverageEmployeeNumber &&
                    this.DepartmentId == other.DepartmentId &&
                    this.Hospital == other.Hospital;
            }
            else return false;
        }
    }
}
