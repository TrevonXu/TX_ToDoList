using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoListApp.Models;

namespace ToDoListApp.Controllers
{ 
    public class HomeController : Controller
    {
        private ToDoDb db = new ToDoDb();

        //
        // GET: /Home/

        public ViewResult Index()
        {
            return View(db.ToDoItemEntries.ToList());
        }

        //
        // GET: /Home/Details/5

        public ViewResult Details(int id)
        {
            ToDoItem todoitem = db.ToDoItemEntries.Find(id);
            return View(todoitem);
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
        public ActionResult Create(ToDoItem todoitem)
        {
            if (ModelState.IsValid)
            {
                db.ToDoItemEntries.Add(todoitem);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(todoitem);
        }
        
        //
        // GET: /Home/Edit/5
 
        public ActionResult Edit(int id)
        {
            ToDoItem todoitem = db.ToDoItemEntries.Find(id);
            return View(todoitem);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(ToDoItem todoitem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(todoitem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todoitem);
        }

        //
        // GET: /Home/Delete/5
 
        public ActionResult Delete(int id)
        {
            ToDoItem todoitem = db.ToDoItemEntries.Find(id);
            return View(todoitem);
        }

        //
        // POST: /Home/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            ToDoItem todoitem = db.ToDoItemEntries.Find(id);
            db.ToDoItemEntries.Remove(todoitem);
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