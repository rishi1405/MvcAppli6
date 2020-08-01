using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcAppli6.Models;

namespace MvcAppli6.Controllers
{
    public class HomeController : Controller
    {
        private hdfcDataModel db = new hdfcDataModel();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View(db.Emps.ToList());
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id)
        {
            hdfcDataModel db = new hdfcDataModel();
            Emp emp = db.Emps.Single(x => x.Id == id);
            return View(emp);

            //Company company = new Company();
            //return View(company);
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(Emp emp)
        {
            if (ModelState.IsValid)
            {
                db.Emps.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emp);
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Emp emp = db.Emps.Find(id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(Emp emp)
        {
            if (ModelState.IsValid)
            {
                hdfcDataModel db = new hdfcDataModel();
                Emp employeeFromDB = db.Emps.Single(x => x.Id == emp.Id);

                // Populate all the properties except EmailAddrees
                employeeFromDB.FullName = emp.FullName;
                employeeFromDB.Gender = emp.Gender;
                employeeFromDB.Age = emp.Age;
                employeeFromDB.HireDate = emp.HireDate;
                employeeFromDB.Salary = emp.Salary;
                employeeFromDB.PersonalWebSite = emp.PersonalWebSite;
                                
                db.Entry(employeeFromDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = emp.Id });
            }
            return View(emp);
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Emp emp = db.Emps.Find(id);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }

        //
        // POST: /Home/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Emp emp = db.Emps.Find(id);
            db.Emps.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}