using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InstituteMVC.Model;
using InstituteMVC.DAL;
using InstituteMVC.ViewModels;
using InstituteMVC.RequestResponse;
using InstituteMVC.Models;

namespace InstituteMVC.Controllers
{
    public class SectionController : Controller
    {
        private InstituteContext db = new InstituteContext();
        DAO dao = new DAO();

        // GET: /Section/
        public ActionResult Index()
        {           
            return View(db.Class.ToList());
        }

        // GET: /Section/Details/5
        public ActionResult Details(string id, int sdate)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = db.Class.Find(id,sdate);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        // GET: /Section/Create
        public ActionResult Create()
        {
            
            return View(ConfigureSection());
        }

        // POST: /Section/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SectionVM section)
        {
            if (ModelState.IsValid)
            {

                int maxClassId = Convert.ToInt32((from cls in db.Class.Where(x => x.SDate == section.Sessions.SlctdSesstion && x.classId.Substring(0, 2) == section.Class.SlctdClassVal)
                                  select cls.classId.Substring(2, 2)).Max()) +1 ;

                
                Section sc = new Section();
                sc.classNameCode = section.SectionName;
                sc.Timeing = (System.TimeSpan) section.Timing;
                sc.SDate = section.Sessions.SlctdSesstion;
                if(maxClassId > 9)
                    sc.classId = section.Class.SlctdClassVal + maxClassId;
                else
                    sc.classId = section.Class.SlctdClassVal+ "0" + maxClassId;
                db.Class.Add(sc);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            section = ConfigureSection();
            return View(section);
        }

        // GET: /Section/Edit/5
        public ActionResult Edit(string id, int sdate)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = db.Class.Find(id, sdate);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        // POST: /Section/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SectionVM section)
        {
            if (ModelState.IsValid)
            {
                db.Entry(section).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(section);
        }

        // GET: /Section/Delete/5
        public ActionResult Delete(string id, int sdate)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = db.Class.Find(id,sdate);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        // POST: /Section/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id, int sdate)
        {
            Section section = db.Class.Find(id, sdate);
            section.isActive = false;
            db.Entry(section).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private SectionVM ConfigureSection()
        {
            SectionVM svm = new SectionVM();
            svm.Sessions.Sessions = new SelectList(db.Session, "SName", "SstartDate");
            return svm;
        }

        public ActionResult AddSectionSubject()
        {
            SectionSubjectVM ssvm = new SectionSubjectVM();
            ssvm.Subjects = db.Subjects.ToList();
            ssvm.Class.DisplaySection = true;
            return View(ssvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSectionSubject(SectionSubjectVM vm)
        {
            foreach (var item in vm.SlctdSubjects)
            {
                SectionSubjectMapping ssm = new SectionSubjectMapping();
                ssm.classId = vm.Class.SlctdSection;
                ssm.SbjID = Convert.ToInt32(item);
                ssm.SDate = 2017;
                db.SectionSubjectMapping.Add(ssm);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult GetSections(string classid) {
            var result = (from sec in db.Class.Where(x => x.classId.Substring(0, 2) == classid)
                          select new SectionResponse{ Id = sec.classId, Name = sec.classNameCode  } ).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
