using EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Linq.Dynamic;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace MvcBlog.Controllers
{
    public class PostController : Controller
    {
        private EF db= new EF();
		// GET: Post
		public string Index()
		{
			string result = "";
			foreach (PostSet post in db.PostSets)
			{
				result += "\n" + post.PostId + "\t " + post.Title + "\t" + post.Content;
			}
			return result;
		}
		public string Get(int id)
		{
			PostSet result = db.PostSets.Where(post => post.PostId == id).FirstOrDefault();
			return result.Title + " " + result.Title;
		}
	}
}