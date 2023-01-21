using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Task2.Models
{
    public class Project
    {
        [Key]
        public int ProNumber { get; set; }
        public string? Name { get; set; }
        public string? location { get; set; }
        [ForeignKey("Department")]
        public int? deptNum { get; set; }
        public virtual Department? Department { get; set; }
        public virtual List<WorksOn>? WorksOns { get; set; }
    }
}
