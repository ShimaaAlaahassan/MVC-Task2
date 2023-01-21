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
        public virtual List<departmentLocation>? DepartmentLocations { get; set; }
        public virtual List<Project>? Projects { get; set; }




    }
}
