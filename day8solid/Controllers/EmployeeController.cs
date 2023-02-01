using day8solid.Models;
using day8solid.Reposiotries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace day8solid.Controllers
{
    public class EmployeeController : Controller
    {
        IemployeeReposiotry employeeRep;
        public EmployeeController(IemployeeReposiotry _employeeRep)
        {
            _employeeRep = employeeRep;
        }  
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult getall()
        {
            return View(employeeRep.getAll());
        }
        public IActionResult getbyId(int id)
        {
            return View(employeeRep.getById(id));
        }
        [HttpGet]
        public IActionResult add()
        {

            return View();
        }
        [HttpPost]
        public IActionResult add(employee emp) 
        {
            employeeRep.Add(emp);
            return RedirectToAction(nameof(getall));
        }
        [HttpGet]
        public IActionResult edit(int id)
        {
            employee emp = employeeRep.getById(id);
            var q2 = employeeRep.getAll();
            ViewBag.q2 = new SelectList(q2, "superid", "Fname");
            return View(emp);
        }
        [HttpPost]
        public IActionResult edit (employee emp)
        {
            employeeRep.Edit(emp);
            return RedirectToAction(nameof(getall));
        }
        public IActionResult delete (int id)
        {
            employeeRep.Delete(id);
            return RedirectToAction(nameof(getall));
        }
    }
}
