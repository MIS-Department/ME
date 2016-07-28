using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using PagedList;
using Shared.DataLayer.Interfaces.IServices;
using Shared.Models.Tables;

namespace Shared.Web.Controllers
{
    public class TemplateController : Controller
    {
        private readonly ITemplateService _service;

        public TemplateController(ITemplateService service)
        {
            _service = service;
        }

        // GET: Template
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
            var result = await _service.SelectAll();
            var template = result.ModelList;

            if (!string.IsNullOrEmpty(searchString))
            {
                template = template.ToList().Where(s => s.Description.ToLower().Contains(searchString.ToLower()));
            }
            const int pageSize = 10;
            var pageNumber = (page ?? 1);

            return View(template.ToPagedList(pageNumber, pageSize));
        }

        // GET: Template/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
            }
            var result = await _service.SelectById(id);

            if (result.ModelSingle == null)
            {
                return HttpNotFound();
            }

            var template = result.ModelSingle;

            return View(template);
        }

        // GET: Template/Create
        public async Task<ActionResult> Create()
        {
            var result = await _service.TemplateGetIdentity();

            if (result.Status.Code != "Error")
            {
                var identity = result.ModelSingle.ToString();
                string code = null;
                switch (identity.Length)
                {
                    case 1:
                        code = "SCH000" + identity;
                        break;
                    case 2:
                        code = "SCH00" + identity;
                        break;
                    case 3:
                        code = "SCH0" + identity;
                        break;
                    case 4:
                        code = "SCH" + identity;
                        break;
                }
                ViewBag.TemplateCode = code;
            }
            return View();
        }

        // POST: Template/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TemplateCode, Description, StartTime, EndTime")]Template model)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    await _service.Insert(model);
                    return RedirectToAction("Index");
                }

            }
            catch (DataException)
            {
                ModelState.AddModelError("",
                    "Unable to save changes. Try again, and if the problem persist see your system administrator");
            }
            return View();
        }

        // GET: Template/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
            }
            var result = await _service.SelectById(id);
            if (result.ModelSingle == null)
            {
                return HttpNotFound("Template not found");
            }

            var template = result.ModelSingle;
            return View(template);
        }

        // POST: Template/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var templateToUpdate = await _service.SelectById(id);
            if (TryUpdateModel(templateToUpdate.ModelSingle, "", new[]
            {
                "TemplateCode",
                "Description",
                "StartTime",
                "EndTime"
            }))
            {
                try
                {

                    await _service.Insert(templateToUpdate.ModelSingle);
                    return RedirectToAction("Index");
                }
                catch(DataException)
                {
                    ModelState.AddModelError("",
                        "Unable to save changes. Try again, and if the problem persist please see your system administrator.");
                }
            }
            return View(templateToUpdate.ModelSingle);
        }

        // GET: Template/Delete/5
        public async Task<ActionResult> Delete(int? id, bool? saveChangesError = false)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage =
                    "Delete failed. Try again, and if the problem persists please see your system administrator.";
            }

            var result = await _service.SelectById(id);

            if (result == null)
            {
                return HttpNotFound();
            }

            return View(result.ModelSingle);
        }

        // POST: Template/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _service.Delete(id);
            }
            catch(DataException)
            {
                return RedirectToAction("Delete", new {id, saveChangesError = true});
            }
            return RedirectToAction("Index");
        }
    }
}
