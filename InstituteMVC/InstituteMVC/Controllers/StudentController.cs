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
using InstituteMVC.Models;

namespace InstituteMVC.Controllers
{
    public class StudentController : Controller
    {
        private InstituteContext db = new InstituteContext();
        private DAO jmc = new DAO();
        // GET: /Student/
        public ActionResult Index()
        {
            string s = @"SELECT bd.Name + ' ' + bd.FatherName AS Name, bd.address, 
                        bd.mobile, Students.CR, Students.classid, Students.innerRollNo, 
                        Sections.classNameCode FROM BioDatas bd 
                        INNER JOIN Students ON bd.bioId = Students.bioId 
                        INNER JOIN Sections ON Students.classid = Sections.classId and Students.SDate = Sections.SDate 
                        WHERE (Students.SDate = '" + Contstants.Session + "' and Students.isActive = 1 and Sections.isActive =1)";
            
            
            //var student = db.Student.Include(s => s.BioData);
            List<StudentCreationVM> scm = Contstants.ConvertDataTable<StudentCreationVM>(jmc.getdataTable(s));
            return View(scm);
        }

        // GET: /Student/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: /Student/Create
        public ActionResult Create()
        {
            // ViewBag.bioID = new SelectList(db.BioData, "bioID", "Name");
            StudentCreationVM svm = new StudentCreationVM();
            svm.Class.DisplaySection = true;
            return View(svm);
        }

        // POST: /Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentCreationVM student)
        {
            if (ModelState.IsValid)
            {
                string checkInnerRoll = "select innerRollNo from Student where innerRollNo = '" + student.RollNo + "' and classId ='" + student.Class.SlctdSection + "' and SDate = 2017";
                string match = jmc.GetSingle(checkInnerRoll);
                if (match == "" || match == null)
                {
                   if(doWork(student))
                    return RedirectToAction("Index");
                }
                else
                {

                    string jsMethodName1 = "DuplicateEntry()";
                   // ScriptManager.RegisterClientScriptBlock(this, typeof(string), "uniqueKey", jsMethodName1, true);

                }
               
            }

           
            return View(student);
        }

        // GET: /Student/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.bioID = new SelectList(db.BioData, "bioID", "Name", student.bioID);
            return View(student);
        }

        // POST: /Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bioID = new SelectList(db.BioData, "bioID", "Name", student.bioID);
            return View(student);
        }

        // GET: /Student/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: /Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Student student = db.Student.Find(id);
            db.Student.Remove(student);
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

        private bool doWork(StudentCreationVM Student)
        {
            var std = new Student();
            var bio = new BioData();

            string query = "select max(substring(CR,5,3))+1 from Student where classid = '" + Student.Class.SlctdSection + "' ";
            string results = jmc.GetSingle(query);
            string ClassRollNo;
            if (results == null || results == "")
            {

                ClassRollNo = Student.Class.SlctdSection + "001";

            }
            else if (results.Length == 1)
            {

                ClassRollNo = Student.Class.SlctdSection + 0 + 0 + results;


            }
            else if (results.Length == 2)
            {
                ClassRollNo = Student.Class.SlctdSection + 0 + results;

            }
            else
            {
                ClassRollNo = Student.Class.SlctdSection + results;
            }

            bio.Name = Student.Name;
            bio.FirstName = Student.FirstName;
            bio.FatherName = Student.FathrName;
            bio.Address = Student.Address;
            //bio.Gender = ddlGnd.SelectedValue;
            //bio.emai = txtMail.Text;
            bio.Mobile = Student.Phone;

            std.EnrolDate = DateTime.Parse(Student.EnDate);
            std.ClassID = Student.Class.SlctdSection;
            std.InnerRollNo = Student.RollNo;
            std.IsActive = true;
            std.FeeStatus = false;
            std.AttStatus = true;
            std.CR = ClassRollNo;
            std.SDate = 2017;

            foreach (var item in Student.SlctdSubjects)
            {
                var StdSubjents = new StudentSubjectMapping();
                StdSubjents.CR = ClassRollNo;
                StdSubjents.SDate = 2017;
                StdSubjents.SbjID = Convert.ToInt32(item);
                std.StudentSubjectMappings.Add(StdSubjents);

            }

            bio.Students.Add(std);
            db.BioData.Add(bio);
            if (db.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
