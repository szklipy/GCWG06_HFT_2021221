using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCWG06_HFT_2021221.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int Employee_id { get; set; }
        [ForeignKey(nameof(Department))]
        public int Department_id { get; set; }
        [ForeignKey(nameof(Hospital))]
        public int Hospital_id { get; set; }
        public string Name { get; set; }
        public string Hire_date { get; set; }
        public string Job_title { get; set; }
        [NotMapped]
        public string MainData => $"[{this.Employee_id}] : {this.Name}," +
            $" hospital_id: {this.Hospital_id}, department_id: {this.Department_id}," +
            $" hire_date: {this.Hire_date}, job_title: {this.Job_title}";
        [NotMapped]
        public virtual Hospital Hospital { get; set; }
        [NotMapped]
        public virtual Department Department { get; set; }
        public override string ToString()
        {
            return $"id: {this.Employee_id}, Name: {this.Name}";
        }
        public override bool Equals(object obj)
        {
            if (obj is Employee)
            {
                Employee other = obj as Employee;
                return this.Employee_id == other.Employee_id &&
                    this.Name == other.Name &&
                    this.Hire_date == other.Hire_date;
            }//[KÉRDÉS] itt nem elég ha csak az id-kat nézzük meg, h egyeznek?
            return false;
        }
        public override int GetHashCode()
        {
            return (int)this.Employee_id + this.Department_id.GetHashCode() + this.Hospital_id.GetHashCode();
        }
    }
}
