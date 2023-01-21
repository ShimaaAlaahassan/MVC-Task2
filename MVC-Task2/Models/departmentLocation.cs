using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Task2.Models
{
    public class departmentLocation
    {
       
        public string location { get; set; }

        [ForeignKey("Department")]
        public int DeptNumber { get; set; }
        public virtual Department? Department { get; set; }
        public virtual List<departmentLocation>? departmentLocations { get; set; }
        public virtual List<Project>? Projects { get; set; }

    }
}
