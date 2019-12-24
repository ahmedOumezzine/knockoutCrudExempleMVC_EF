using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using knockoutCrudExempleMVC_EF.Models;

namespace knockoutCrudExempleMVC_EF.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly NORTHWNDEntities _db = new NORTHWNDEntities();
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListEmployees()
        {
            //return Json(_db.Employees.ToList(), JsonRequestBehavior.AllowGet);
            return Json(from obj in _db.Employees select new { EmployeeID=obj.EmployeeID, FirstName=obj.FirstName, LastName = obj.LastName, Address=obj.Address }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return View();
        }
        // POST: Employee/CreateEmployee
        [HttpPost]
        public string CreateEmployee(Employee employee)
        {
            if (!ModelState.IsValid) return "Model is invalid";
            _db.Employees.Add(employee);
            var result = _db.SaveChanges();
            return "Cource is created";
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var employee = _db.Employees.Find(id);
            if (employee == null)
                return HttpNotFound();
            var serializer = new JavaScriptSerializer();
            ViewBag.SelectedEmployee = serializer.Serialize(employee);
            return View();
        }

        // POST: Employee/Update/5
        [HttpPost]
        public string Update(Employee employee)
        {
            if (!ModelState.IsValid) return "Invalid model";
            _db.Entry(employee).State = EntityState.Modified;
            _db.SaveChanges();
            return "Updated successfully";
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var employee = _db.Employees.Find(id);
            if (employee == null)
                return HttpNotFound();
            var serializer = new JavaScriptSerializer();
            ViewBag.SelectedEmployee = serializer.Serialize(employee);
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        public string Delete(Employee employee)
        {
            if (employee == null) return "Invalid data";
            var getEmployee = _db.Employees.Find(employee.EmployeeID);
            _db.Employees.Remove(getEmployee);
            _db.SaveChanges();
            return "Deleted successfully";
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}