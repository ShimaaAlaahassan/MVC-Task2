using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Task2.Models;

namespace MVC_Task2.Controllers
{
    public class DepartmentController : Controller
    {
        private Companydbcontext db;
        public DepartmentController()
        {
            db = new Companydbcontext();
        }
        //to display all department
        public IActionResult Index()
        {
            List<Department>departments=db.Departments.ToList();
            return View(departments);
        }
        public IActionResult Add()
        {
            List<Department> departments = db.Departments.ToList();
            ViewBag.departments = new SelectList(departments, "Number", "name");
            return View();


        }
        public IActionResult AddDb(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
    }
}
