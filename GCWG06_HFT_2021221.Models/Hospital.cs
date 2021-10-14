using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCWG06_HFT_2021221.Models
{
    [Table("Hospitals")]
    public class Hospital
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Hospital_id { get; set; }
        public string Hospital_name { get; set; }
        public string Hospital_location { get; set; }
        //public string country { get; set; }
        [NotMapped]
        public string MainData => $"[{this.Hospital_id}] : {this.Hospital_name}," +
            $" location: ({this.Hospital_location}), departments: ({Departments.Count()})," +
            $" employees: ({Employees.Count()})";
        [NotMapped]
        public virtual ICollection<Employee> Employees { get; set; }
        [NotMapped]
        public virtual ICollection<Department> Departments { get; set; }
        public Hospital()
        {
            Employees = new HashSet<Employee>();
            Departments = new HashSet<Department>();
        }
        public override string ToString()
        {
            return $"id: {this.Hospital_id}, Name: {this.Hospital_name}";
        }
        public override bool Equals(object obj)
        {
            if (obj is Hospital)
            {
                Hospital other = obj as Hospital;
                return this.Hospital_id == other.Hospital_id &&
                    this.Hospital_name == Hospital_name;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return (int)this.Hospital_id + this.Hospital_name.GetHashCode();
        }
    }
}
