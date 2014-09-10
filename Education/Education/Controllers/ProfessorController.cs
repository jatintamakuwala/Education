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
    public class ProfessorController : BaseController
    {
        public ActionResult Index()
        {
            var professor = EduRepo.Professors.Include(s => s.ClassMst);
            return View(professor.ToList());
        }

        //
        // GET: /Professors/Details/5

        public ActionResult Details(long id = 0)
        {
            Professor professor = EduRepo.Professors.Where(s => s.ProfessorID == id).DefaultIfEmpty(null).FirstOrDefault();
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        //
        // GET: /Professors/Create

        public ActionResult Create()
        {
            ViewBag.ClassMstID = new SelectList(EduRepo.ClassMsts, "ClassMstID", "ClassMstName");
            return View();
        }

        //
        // POST: /Professors/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Professor professor)
        {
            if (ModelState.IsValid)
            {
                EduRepo.AddProfessor(professor);
                EduRepo.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassMstID = new SelectList(EduRepo.ClassMsts, "ClassMstID", "ClassMstName", professor.ClassMstID);
            return View(professor);
        }

        //
        // GET: /Professors/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Professor professor = EduRepo.Professors.Where(s => s.ProfessorID == id).DefaultIfEmpty(null).FirstOrDefault();
            if (professor == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassMstID = new SelectList(EduRepo.ClassMsts, "ClassMstID", "ClassMstName", professor.ClassMstID);
            return View(professor);
        }

        //
        // POST: /Professors/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Professor professor)
        {
            if (ModelState.IsValid)
            {
                EduRepo.UpdateProfessor(professor);
                EduRepo.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassMstID = new SelectList(EduRepo.ClassMsts, "ClassMstID", "ClassMstName", professor.ClassMstID);
            return View(professor);
        }

        //
        // GET: /Professors/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Professor professor = EduRepo.Professors.Where(s => s.ProfessorID == id).DefaultIfEmpty(null).FirstOrDefault();
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        //
        // POST: /Professors/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Professor professor = EduRepo.Professors.Where(s => s.ProfessorID == id).DefaultIfEmpty(null).FirstOrDefault();
            EduRepo.DeleteProfessor(professor);
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