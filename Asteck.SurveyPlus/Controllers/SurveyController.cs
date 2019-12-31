using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asteck.SurveyPlus.Controllers
{
    public class SurveyController : Controller
    {
        // GET: Survey
        public ActionResult Index(int id)
        {

            return View();
        }

        // POST: Survey/Create
        [HttpPost]
        public ActionResult Index(FormCollection collection)
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

    }
}
