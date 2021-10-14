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
            $" location: {this.Hospital_location}";
        [NotMapped]
        public virtual ICollection<Employee>Employees { get; }
        [NotMapped]
        //nullable enable
        public virtual ICollection<Department> Departments { get; }

    }
}
