using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Task2.Models
{
    public class WorksOn
    {
        //composite pk
        public string Hours { get; set; }

        [ForeignKey("Employee")]
        public int EmpSSN { get; set; }
        public virtual Employee? Employees { get; set; }

        [ForeignKey("Project")]
        public int projNum { get; set; }
        public virtual Project? Project { get; set; }
    }
}
