using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCWG06_HFT_2021221.Logic
{
    public class AveragesResultSal
    {
        public int DepartmentId { get; set; }
        public string Hospital { get; set; }
        public string DepartmentName { get; set; }
        public double AverageSalary { get; set; }
        public override string ToString()
        {
            return $"DEPARTMENT ID: {DepartmentId}" +
                $"HOSPITAL: {Hospital}" +
                $",DEPARTMENT: {DepartmentName}" +
                $", AVERAGE SALARY: {AverageSalary}";
        }
        public override bool Equals(object obj)
        {
            if (obj is AveragesResultSal)
            {
                AveragesResultSal other = obj as AveragesResultSal;
                return this.DepartmentName == other.DepartmentName &&
                    this.AverageSalary == other.AverageSalary &&
                    this.DepartmentId == other.DepartmentId &&
                    this.Hospital == other.Hospital;
            }
            else return false;
        }
    }
}
