using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Task2.Models;

namespace MVC_Task2.Controllers
{
    public class EmployeeController1 : Controller
    {
        private Companydbcontext db;
        public EmployeeController1()
        {
            db = new Companydbcontext();
        }
        //display
        public IActionResult Index()
        {
            //model==>employees
            //view name==>index
            List<Employee> employees = db.Employees.ToList();
            return View(employees);
        }
        public IActionResult GetById(int id)
        {
            Employee? employee = db.Employees.SingleOrDefault(s => s.SSN == id);
            if(employee ==null)
            {
                return View("Error");
            }
            return View(employee);

        }
        //to add employee
        public IActionResult Add()
        {
            List<Employee> employees = db.Employees.ToList();
            return View(employees);
        }

        public IActionResult AddEmployee(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
            List<Employee> employees = db.Employees.ToList();
            return View("Index",employees);
        }

        //update employee
        public IActionResult Edit(int id)
        {
            Employee employee = db.Employees.SingleOrDefault(s => s.SSN == id);
            List<Employee> employees = db.Employees.ToList();
            ViewBag.emp = employees;
            return View(employee);
        }
        public IActionResult EditEmployee(Employee employee)
        {
            Employee oldemp = db.Employees.SingleOrDefault(s => s.SSN == employee.SSN);
            oldemp.fname = employee.fname;
            oldemp.lname = employee.lname;
            oldemp.Minit = employee.Minit;
            oldemp.sex = employee.sex;
            oldemp.address = employee.address;
            oldemp.salary = employee.salary;
            oldemp.BirthDate = employee.BirthDate;
            oldemp.SupervisorSSN = employee.SupervisorSSN;
            db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        //to delete
        public IActionResult Delete(int id)
        {
            Employee employee = db.Employees.SingleOrDefault(s => s.SSN == id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        //to login 
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult SaveLogin(Employee employeeTologin)
        {

            Employee employee = db.Employees.SingleOrDefault(e => e.SSN == employeeTologin.SSN && e.fname == employeeTologin.lname);

            if (employee == null)
            {
                return View("Error");

            }
               
            else
            {
                HttpContext.Session.SetInt32("SSN", employee.SSN);
                return GetById(employee.SSN);
            }

        }

        public IActionResult AllEmployeeManger()
        {

            List<Employee>? employees = db.Departments.Include(e => e.EmpManage).Where(e => e.emp_m != null).Select(e => e.EmpManage).ToList();

            return View(employees);

        }
    }
}
