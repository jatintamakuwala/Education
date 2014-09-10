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
    public class ClassMstController : BaseController
    {
         public ActionResult Index()
        {
            return View(EduRepo.ClassMsts.ToList());
        }

        //
        // GET: /ClassMst/Details/5

        public ActionResult Details(long id = 0)
        {
            ClassMst classmst = EduRepo.ClassMsts.Where(s => s.ClassMstID == id).DefaultIfEmpty(null).FirstOrDefault();
            if (classmst == null)
            {
                return HttpNotFound();
            }
            return View(classmst);
        }

        //
        // GET: /ClassMst/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ClassMst/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClassMst classmst)
        {
            if (ModelState.IsValid)
            {
                EduRepo.AddClassMst(classmst);
                EduRepo.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classmst);
        }

        //
        // GET: /ClassMst/Edit/5

        public ActionResult Edit(long id = 0)
        {
            ClassMst classmst = EduRepo.ClassMsts.Where(s => s.ClassMstID == id).DefaultIfEmpty(null).FirstOrDefault();
            if (classmst == null)
            {
                return HttpNotFound();
            }
            return View(classmst);
        }

        //
        // POST: /ClassMst/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClassMst classmst)
        {
            if (ModelState.IsValid)
            {
                EduRepo.UpdateClassMst(classmst);
                EduRepo.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classmst);
        }

        //
        // GET: /ClassMst/Delete/5

        public ActionResult Delete(long id = 0)
        {
            ClassMst classmst = EduRepo.ClassMsts.Where(s => s.ClassMstID == id).DefaultIfEmpty(null).FirstOrDefault();
            if (classmst == null)
            {
                return HttpNotFound();
            }
            return View(classmst);
        }

        //
        // POST: /ClassMst/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ClassMst classmst = EduRepo.ClassMsts.Where(s => s.ClassMstID == id).DefaultIfEmpty(null).FirstOrDefault();
            if (classmst == null)
            {
                return HttpNotFound();
            }
            else
            {
                List<Student> lstStud = new List<Student>();
                lstStud = classmst.Student.ToList();
                foreach (Student stud in lstStud)
                    EduRepo.DeleteStudent(stud);
                List<Professor> lstProf = new List<Professor>();
                lstProf = classmst.Professor.ToList();
                foreach (Professor prof in lstProf)
                    EduRepo.DeleteProfessor(prof);
                EduRepo.UpdateClassMst(classmst);
                EduRepo.SaveChanges();
                EduRepo.DeleteClassMst(classmst);
                EduRepo.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            EduRepo.Dispose();
            base.Dispose(disposing);
        }
    }
}