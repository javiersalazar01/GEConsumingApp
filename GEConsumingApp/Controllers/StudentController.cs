using GEConsumingApp.BussinesObjects;
using GEConsumingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GEConsumingApp.Controllers
{
    public class StudentController : Controller
    {
        private StudentClient client = new StudentClient();
        // GET: Student
        public ActionResult Index()
        {
            List<StudentModel> models = client.GetAll().ToList();

            if (models == null)
            {
                models = new List<StudentModel>();
            }

            return View(models);
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            StudentModel sTUDENT = client.Find(id);

            if (sTUDENT == null)
            {
                return HttpNotFound();
            }
            return View(sTUDENT);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "last_name,middle_name,first_name,gender")] StudentModel sTUDENT)
        {
            if (ModelState.IsValid)
            {
                client.Create(sTUDENT);
                return RedirectToAction("Index");
            }

            return View(sTUDENT);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
