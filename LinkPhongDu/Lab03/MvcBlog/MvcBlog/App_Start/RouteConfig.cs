using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcBlog
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Blog",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Blog", action = "Index", id = UrlParameter.Optional }
			);

			routes.MapRoute(
			name: "Post",
			url: "{controller}/{action}/{id}",
			defaults: new { controller = "Post", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
