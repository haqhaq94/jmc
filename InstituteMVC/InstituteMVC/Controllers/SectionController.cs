using InstituteMVC.DAL;
using InstituteMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstituteMVC.Controllers
{
    public class SectionController : Controller
    {
        InstituteContext db = new InstituteContext();
        //
        // GET: /Section/
        public ActionResult Index()
        {
            SectionVM vm = new SectionVM();
            vm.Sessions.Sessions = new SelectList(db.Session, "SstartDate", "SstartDate");
            return View(vm);
        }
	}
}