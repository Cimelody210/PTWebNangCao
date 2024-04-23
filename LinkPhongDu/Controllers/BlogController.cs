using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityController;
using EntityModel;
namespace MvcBlog.Controllers
{
    public class BlogController : Controller
    {
        private EF db= new EF();
        // GET: Blog
        public string Index()
        {
			string result = "";
			foreach (BlogSet blog in db.BlogSets)
			{
				result += "\n" + blog.BlogId + "\t " + blog.Name + "\t" + blog.Url;
			}
			return result;
		}

		// GET: BlogSets/Get/5
		public string Get(int id)
		{
			BlogSet result = db.BlogSets.Where(blog => blog.BlogId == id).FirstOrDefault();
			return result.Name + " " + result.Url;
		}

	}
}