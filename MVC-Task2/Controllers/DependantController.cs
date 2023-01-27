using Microsoft.AspNetCore.Mvc;
using MVC_Task2.Models;
using Microsoft.EntityFrameworkCore;

namespace MVC_Task2.Controllers
{
    public class DependantController : Controller
    {
        EmployeeController1 employeeController1 = new EmployeeController1();
        private Companydbcontext db;
        public DependantController()
        {
            db = new Companydbcontext();
        }
        public IActionResult Index()
        {
            List<Dependant> dependants = db.Dependants.ToList();
            return View(dependants);
            
        }
        Int32 SSNfromSession;
        public IActionResult GetAllDependant()
        {
            SSNfromSession = (int)HttpContext.Session.GetInt32("SSN");
            List<Dependant> dependents = db.Dependants.Where(d => d.EmpSSN == SSNfromSession).ToList();

            return View(dependents);
        }
        

        public IActionResult Add()
        {

            return View();
        }
        public IActionResult AddDependant(Dependant dependent)
        {
            SSNfromSession = (int)HttpContext.Session.GetInt32("SSN");
            dependent.EmpSSN = SSNfromSession;
            db.Dependants.Add(dependent);
            db.SaveChanges();
            TempData["AddMsg"] = "You Add New Dependent";

            return RedirectToAction(nameof(GetAllDependant));

        }

        public IActionResult Edit(string id)
        {
            SSNfromSession = (int)HttpContext.Session.GetInt32("SSN");
            Dependant dependant = db.Dependants.SingleOrDefault(d => d.EmpSSN == SSNfromSession && d.Name == id);
            if (dependant == null)
                return View("Error");
            else
                return View(dependant);
        }
        public IActionResult EditDependant(Dependant dependantToEdit)
        {
            SSNfromSession = (int)HttpContext.Session.GetInt32("SSN");
            Dependant olDdependant = db.Dependants.SingleOrDefault(d => d.EmpSSN == SSNfromSession && d.Name == dependantToEdit.Name);
            olDdependant.Sex = dependantToEdit.Sex;
            olDdependant.Relationship = dependantToEdit.Relationship;
            olDdependant.BirthDate = dependantToEdit.BirthDate;
     

            db.SaveChanges();
            return RedirectToAction(nameof(GetAllDependant));
        }

        public IActionResult Delete(string id)
        {
            SSNfromSession =(int)HttpContext.Session.GetInt32("SSN");
            Dependant? dependantToDelete = db.Dependants.SingleOrDefault(d => d.EmpSSN == SSNfromSession && d.Name == id);

            db.Dependants.Remove(dependantToDelete);
            db.SaveChanges();
          
            return RedirectToAction(nameof(GetAllDependant));

        }

    }
}
