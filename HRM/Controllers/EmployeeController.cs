using HRM.DataAccess.Data;
using HRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HRM.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            // Fetch all employees from db        
            var employees = _db.Employees.Include(x => x.Designation).Include(x => x.Department).ToList();
            /*var employee = _db.Employees.Include(x => x.Department).ToList();*/

            return View(employees);
        }

        /*//Get
		public IActionResult Create()
		{
			return View();
		}*/

        [HttpGet]
        public IActionResult Create()
        {
            var designations = _db.Designations.ToList();
            var designationList = designations.Select(x => new SelectListItem { Text = x.Title, Value = x.Id.ToString() });
            ViewData["DesignationList"] = designationList;

            var departments = _db.Departments.ToList();
            var departmentList = departments.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            ViewData["DepartmentList"] = departmentList;

            return View();
        }


        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee obj)
        {    
            //Server Side Validation
            /*if (ModelState.IsValid)
            {
                _db.Employees.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);*/
            _db.Employees.Add(obj);
            _db.SaveChanges();
            TempData["Success"] = "Employee created successfully";
            return RedirectToAction("Index");

        }

        //Get
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            
            var employeeFromDb = _db.Employees.Find(id);
            //var employeeFromDb = _db.Employees.FirstOrDefault(x => x.Id == Id);

            return View(employeeFromDb);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee obj)
        {
            //Server Side Validation
            if (ModelState.IsValid)
            {
                _db.Employees.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }          

        //Get
        [HttpGet]
        public IActionResult Details(int id)
        {

            var employeeFromDb = _db.Employees.Find(id);
            //var employeeFromDb = _db.Employees.FirstOrDefault(x => x.Id == Id);

            return View(employeeFromDb);
        }
        

        //Get
        [HttpGet]
		public IActionResult Delete(int id)
		{

			var employeeFromDb = _db.Employees.Find(id);
			//var employeeFromDb = _db.Employees.FirstOrDefault(x => x.Id == Id);

			return View(employeeFromDb);
		}
		//Post
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(int? id)
		{
            //Server Side Validation
            /*if (ModelState.IsValid)
            {
                _db.Employees.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);*/
            var obj = _db.Employees.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
			_db.Employees.Remove(obj);
			_db.SaveChanges();
            TempData["Success"] = "Employee deleted successfully";
            return RedirectToAction("Index");

		}
	}
}

