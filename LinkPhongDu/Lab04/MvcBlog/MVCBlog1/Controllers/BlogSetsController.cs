using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCBlog1.Models;

namespace MVCBlog1.Controllers
{
    public class BlogSetsController : Controller
    {
        private DatabaseBloggingContextEntities1 db = new DatabaseBloggingContextEntities1();

        // GET: BlogSets
        public ActionResult Index()
        {
            return View(db.BlogSets.ToList());
        }

        // GET: BlogSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogSet blogSet = db.BlogSets.Find(id);
            if (blogSet == null)
            {
                return HttpNotFound();
            }
            return View(blogSet);
        }

        // GET: BlogSets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogSets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlogId,Name,Url")] BlogSet blogSet)
        {
            if (ModelState.IsValid)
            {
                db.BlogSets.Add(blogSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blogSet);
        }

        // GET: BlogSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogSet blogSet = db.BlogSets.Find(id);
            if (blogSet == null)
            {
                return HttpNotFound();
            }
            return View(blogSet);
        }

        // POST: BlogSets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlogId,Name,Url")] BlogSet blogSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogSet);

        }

		// GET: BlogSets/Delete/5
		public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogSet blogSet = db.BlogSets.Find(id);
            if (blogSet == null)
            {
                return HttpNotFound();
            }
            return View(blogSet);
        }

        // POST: BlogSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogSet blogSet = db.BlogSets.Find(id);
            db.BlogSets.Remove(blogSet);
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
    }
}
