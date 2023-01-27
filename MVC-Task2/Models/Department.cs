using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC_Task2.Models
{
    public class Department
    {
        [Key]
        public int Number { get; set; }
        public string? name { get; set; }
       //
        [ForeignKey("EmpManage")]
        public int? emp_m { get; set; }
        public virtual List<Employee>? EmpWork { get; set; }
        public virtual Employee? EmpManage { get; set; }
        //
        public virtual List<departmentLocation>? DepartmentLocations { get; set; }
        public virtual List<Project>? Projects { get; set; }




    }
}
