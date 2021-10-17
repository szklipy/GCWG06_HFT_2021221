using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCWG06_HFT_2021221.Models
{
    [Table("Departments")]
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Department_id { get; set; }
        [ForeignKey(nameof(Hospital))]
        public int? Hospital_id { get; set; }
        public string Department_name { get; set; }
        [NotMapped]
        public string MainData => $"[{this.Department_id}] : {this.Department_name}," +
            $" no. employees: ({this.Employees.Count()})";
        [NotMapped]
        public virtual ICollection<Employee> Employees { get; set; }
        [NotMapped]
        public virtual Hospital Hospital { get; set; }
        //public virtual ICollection<Hospital> Hospitals { get; set; }
        public Department()
        {
            Employees = new HashSet<Employee>();
            //Hospitals = new HashSet<Hospital>();
        }
        public override string ToString()
        {
            return $"id: {this.Department_id}, Name: {this.Department_name}";
        }
        public override bool Equals(object obj)
        {
            if (obj is Department)
            {
                Department other = obj as Department;
                return this.Department_id == other.Department_id &&
                    this.Department_name == other.Department_name;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return (int)this.Department_id + this.Department_name.GetHashCode();
        }
    }
}
