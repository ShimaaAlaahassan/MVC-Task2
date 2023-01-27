using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Task2.Models
{
    public class Employee
    {
        [Key]
        public int SSN { get; set; }
        public string? fname { get; set; }
        public string? lname { get; set; }
        public string? Minit { get; set; }
        public string? sex { get; set; }
        public string? address { get; set;}

        [Column(TypeName = "money")]
        public int? salary { get; set; }
        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }
        //
        [ForeignKey("deptWork")]
        public int? deptId_w { get; set; }
        [ForeignKey("deptManage")]
        public int? deptId_m { get; set; }
        
        public virtual Department? deptWork { get; set; }
        public virtual Department? deptManage { get; set; }
        //fk api
        public int? SupervisorSSN { get; set; }
        public virtual Employee? Supervisor { get; set; }
       
        public List<Employee>? Employees { get; set;}
        public virtual List<WorksOn>? WorksOn { get; set; }

        public virtual List<Dependant>? Dependants { get; set; }
       


    }
}
