using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Education.Implementation;
using Education.Infrastructure;

namespace Education.Controllers
{
    public class StudentController : BaseController
    {
        public ActionResult Index()
        {
            var student = EduRepo.Students.Include(s => s.ClassMst);
            return View(student.ToList());
        }

        //
        // GET: /Student/Details/5

        public ActionResult Details(long id = 0)
        {
            Student student = EduRepo.Students.Where(s => s.StudentID == id).DefaultIfEmpty(null).FirstOrDefault();
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //
        // GET: /Student/Create

        public ActionResult Create()
        {
            ViewBag.ClassMstID = new SelectList(EduRepo.ClassMsts, "ClassMstID", "ClassMstName");
            return View();
        }

        //
        // POST: /Student/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                EduRepo.AddStudent(student);
                EduRepo.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassMstID = new SelectList(EduRepo.ClassMsts, "ClassMstID", "ClassMstName", student.ClassMstID);
            return View(student);
        }

        //
        // GET: /Student/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Student student = EduRepo.Students.Where(s => s.StudentID == id).DefaultIfEmpty(null).FirstOrDefault();
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassMstID = new SelectList(EduRepo.ClassMsts, "ClassMstID", "ClassMstName", student.ClassMstID);
            return View(student);
        }

        //
        // POST: /Student/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                EduRepo.UpdateStudent(student);
                EduRepo.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassMstID = new SelectList(EduRepo.ClassMsts, "ClassMstID", "ClassMstName", student.ClassMstID);
            return View(student);
        }

        //
        // GET: /Student/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Student student = EduRepo.Students.Where(s => s.StudentID == id).DefaultIfEmpty(null).FirstOrDefault();
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //
        // POST: /Student/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Student student = EduRepo.Students.Where(s => s.StudentID == id).DefaultIfEmpty(null).FirstOrDefault();
            EduRepo.DeleteStudent(student);
            EduRepo.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            EduRepo.Dispose();
            base.Dispose(disposing);
        }
    }
}