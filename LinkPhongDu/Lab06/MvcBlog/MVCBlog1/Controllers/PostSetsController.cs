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
		public ActionResult Index(string search, DateTime? fromDate, DateTime? toDate, int blogID = 0)
        {
            //------------1. Ban đầu
            //var postSets = db.PostSets.Include(p => p.BlogSet);
            //return View(postSets.ToList());



            //----------2. Tìm kiếm
            //1. Hiện thị danh sách Blog trên dropDown
            var blogList = from p in db.BlogSets
                           select p;
            ViewBag.BlogID = new SelectList(blogList, "BlogId", "Name");
            //2. Tạo câu truy vấn liên kết 2 bảng bằng lệnh join
            var posts = from p in db.PostSets
                        join b in db.BlogSets on p.BlogBlogId equals b.BlogId
                        select new { p.PostId, p.Title, p.Content, p.CreatedDate, p.BlogBlogId, b.Name };

            //3. Tìm kiếm chuỗi truy vần
            if (!String.IsNullOrEmpty(search))
            {
                posts = posts.Where(b => b.Title.Contains(search));
            }
            //4.Tìm kiếm theo blogId
            if (blogID != 0)
            {
                posts = posts.Where(c => c.BlogBlogId == blogID);
            }
			
			if (fromDate != null)
            {
				if (toDate >= fromDate)
				{
					posts = posts.Where(p => p.CreatedDate >= fromDate && p.CreatedDate <= toDate);
				}
				// Bắt lỗi dữ liệu: toDate >= fromDate
				if ( toDate <= fromDate)
				{
					throw new ArgumentException("Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu.");
				}
			}
			//5. Chuyển đổi kết quả từ var sang danh sách List<post>

			List<PostSet> postList = new List<PostSet>();
			foreach (var item in posts)
			{
				PostSet p = new PostSet();
				p.PostId = item.PostId;
				p.Title = item.Title;
				p.Content = item.Content;
				p.CreatedDate = item.CreatedDate;
				p.BlogBlogId = item.BlogBlogId;
				p.BlogName = item.Name;
				postList.Add(p);

			}
			return View(postList);

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
        public ActionResult Create([Bind(Include = "PostId,Title,Content,BlogBlogId,CreatedDate")] PostSet postSet)
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
        public ActionResult Edit([Bind(Include = "PostId,Title,Content,BlogBlogId,CreatedDate")] PostSet postSet)
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
