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
    public class PostSetsController : Controller
    {
        private DatabaseBloggingContextEntities1 db = new DatabaseBloggingContextEntities1();

        // GET: PostSets
        public ActionResult Index()
        {
            var postSets = db.PostSets.Include(p => p.BlogSet);
            return View(postSets.ToList());
        }

        // GET: PostSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostSet postSet = db.PostSets.Find(id);
            if (postSet == null)
            {
                return HttpNotFound();
            }
            return View(postSet);
        }

        // GET: PostSets/Create
        public ActionResult Create()
        {
            ViewBag.BlogBlogId = new SelectList(db.BlogSets, "BlogId", "Name");
            return View();
        }

        // POST: PostSets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostId,Title,Content,BlogBlogId")] PostSet postSet)
        {
            if (ModelState.IsValid)
            {
                db.PostSets.Add(postSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BlogBlogId = new SelectList(db.BlogSets, "BlogId", "Name", postSet.BlogBlogId);
            return View(postSet);
        }

        // GET: PostSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostSet postSet = db.PostSets.Find(id);
            if (postSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.BlogBlogId = new SelectList(db.BlogSets, "BlogId", "Name", postSet.BlogBlogId);
            return View(postSet);
        }

        // POST: PostSets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostId,Title,Content,BlogBlogId")] PostSet postSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BlogBlogId = new SelectList(db.BlogSets, "BlogId", "Name", postSet.BlogBlogId);
            return View(postSet);
        }

        // GET: PostSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostSet postSet = db.PostSets.Find(id);
            if (postSet == null)
            {
                return HttpNotFound();
            }
            return View(postSet);
        }

        // POST: PostSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostSet postSet = db.PostSets.Find(id);
            db.PostSets.Remove(postSet);
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
