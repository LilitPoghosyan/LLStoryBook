using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Context;
using Domain.Entities;
using Domain.Concrete;
using Microsoft.AspNet.Identity;

namespace StoryBook.Controllers
{
    public class GroupsController : Controller
    {
        private StoryBookRepository<Group> db = new StoryBookRepository<Group>();

        // GET: Groups
        [Authorize]
        public ActionResult Index()
        {
            return View(db.GetItems().ToList());
        }

        // GET: Groups/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.GetItems().Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // GET: Groups/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupID,Name,Description")] Group group)
        {
            if (ModelState.IsValid)
            {
                db.GetItems().Add(group);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(group);
        }

        // GET: Groups/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.GetItems().Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupID,Name,Description")] Group group)
        {
            if (ModelState.IsValid)
            {
                db.Entry(group).State = EntityState.Modified;
                db.Save();
                return RedirectToAction("Index");
            }
            return View(group);
        }

        // GET: Groups/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.GetItems().Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Group group = db.GetItems().Find(id);
            db.GetItems().Remove(group);
            db.Save();
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
    }
}
