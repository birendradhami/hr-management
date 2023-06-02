using hr_management.Data;
using hr_management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace hr_management.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            /*var objEmployeeList = _db.Employees.ToList();*/
            IEnumerable<Employee> objEmployeeList = _db.Employees;
            return View(objEmployeeList);
        }
        //Get
		public IActionResult Create()
		{
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
            return RedirectToAction("Index");

        }

        //Get
        [HttpGet]
        public IActionResult Edit(int id)
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
            /*if (ModelState.IsValid)
            {
                _db.Employees.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);*/
            _db.Employees.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

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
			return RedirectToAction("Index");

		}
	}
}

