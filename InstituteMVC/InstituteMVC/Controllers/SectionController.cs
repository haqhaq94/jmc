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

namespace InstituteMVC.Controllers
{
    public class SectionController : Controller
    {
        private InstituteContext db = new InstituteContext();

        // GET: /Section/
        public ActionResult Index()
        {           
            return View(db.Class.ToList());
        }

        // GET: /Section/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = db.Class.Find(id);
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
                Section sc = new Section();
                sc.classNameCode = section.SectionName;
                sc.SDate = section.Sessions.SlctdSesstion;
                sc.Timeing = (DateTime) section.Timing;
                db.Class.Add(sc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            section = ConfigureSection();
            return View(section);
        }

        // GET: /Section/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = db.Class.Find(id);
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
        public ActionResult Edit([Bind(Include="classId,SDate,classNameCode,Timeing,Fee,IsReady,Issent,isActive")] Section section)
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
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = db.Class.Find(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        // POST: /Section/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Section section = db.Class.Find(id);
            db.Class.Remove(section);
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
    }
}
