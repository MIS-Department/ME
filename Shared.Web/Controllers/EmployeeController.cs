using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using PagedList;
using Shared.DataLayer.Interfaces.IServices;

namespace Shared.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
          
            _employeeService = employeeService;
        }

        // GET: Employee
        public async Task<ActionResult> Index(string searchString, string currentFilter, int? page)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var result = await _employeeService.SelectAll();
            var employeeLst = result.ModelList;

            if (!string.IsNullOrEmpty(searchString))
            {
                employeeLst =
                    employeeLst.ToList()
                        .Where(
                            s =>
                                s.FirstName.ToLower().Contains(searchString.ToLower()) ||
                                s.LastName.ToLower().Contains(searchString.ToLower()));
            }
            const int pageSize = 15;
            var pageNumber = (page ?? 1);
            return View(employeeLst.ToPagedList(pageNumber, pageSize));
        }

        // GET: Employee/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
            }

            var model = await _employeeService.SelectById(id);

            if (model.ModelSingle == null)
            {
                return HttpNotFound("Employee not found");
            }

            return View(model.ModelSingle);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = await _employeeService.SelectById(id);
            if (model.ModelSingle == null)
            {
                return HttpNotFound("Employee not found!");
            }

            return View(model.ModelSingle);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
