using InstituteMVC.DAL;
using InstituteMVC.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace InstituteMVC.Controllers
{
    public class SubjectController : Controller
    {
        InstituteContext db = new InstituteContext();
        //
        // GET: /Subject/
        public ActionResult Index()
        {
            var sbjs = db.Subjects.ToList();
            if (sbjs.Count > 0)
                return View(sbjs);
            else
                return RedirectToAction("Create");
        }

        //
        // GET: /Subject/Details/5
        public ActionResult Details(int id)
        {
            Subject sbj = db.Subjects.Find(id);
            return View(sbj);
        }

        //
        // GET: /Subject/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Subject/Create
        [HttpPost]
        public ActionResult Create(Subject sbj)
        {
            
                if (ModelState.IsValid)
                {
                    db.Subjects.Add(sbj);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(sbj);
        }

        //
        // GET: /Subject/Edit/5
        public ActionResult Edit(int id)
        {
            Subject sbj = db.Subjects.Find(id);
            return View(sbj);
        }

        //
        // POST: /Subject/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Subject sbject)
        {
            if(ModelState.IsValid)
            {
                 Subject sbj = db.Subjects.Find(id);
                sbj.sbjName = sbject.sbjName;
                db.Entry(sbj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sbject);
        }

        //
        // GET: /Subject/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject sbj = db.Subjects.Find(id);
            if (sbj == null)
            {
                return HttpNotFound();
            }
            return View(sbj);
        }

        //
        // POST: /Subject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subject sbj = db.Subjects.Find(id);
            db.Subjects.Remove(sbj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
