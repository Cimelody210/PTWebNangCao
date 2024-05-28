using Microsoft.AspNetCore.Mvc;
using HtmlAgilityPack;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var blogDataList = new List<BlogData>();
            return View(blogDataList);
        }

        public IActionResult Scrapwebsite(string website)
        {
            var blogDatalist=new List<BlogData>();
            var web = new HtmlWeb();
            var htmlDoc = web.Load(website);

            var nodeElement = htmlDoc.DocumentNode.SelectNodes("//div[@class='coupon-main-con']");
            foreach (var node in nodeElement)
            {
                var blogImage = node.ChildNodes.FirstOrDefault(x => x.Name == "div").ChildNodes.FirstOrDefault(x => x.Name == "div").ChildNodes.FirstOrDefault(x => x.Name == "a").ChildNodes.FirstOrDefault(x => x.Name == "img").Attributes.FirstOrDefault(x => x.Name == "src").Value;
                var title = node.ChildNodes.LastOrDefault(x => x.Name == "div").ChildNodes.FirstOrDefault(x => x.Name == "div").ChildNodes.FirstOrDefault(x => x.Name == "a").InnerHtml.Trim();
                var author = node.ChildNodes.LastOrDefault(x => x.Name == "div").ChildNodes.FirstOrDefault(x => x.Name == "div").ChildNodes.FirstOrDefault(x => x.Name == "a").InnerText.Trim();
                var publishDate = node.ChildNodes.LastOrDefault(x => x.Name == "div").ChildNodes.FirstOrDefault(x => x.Name == "div").ChildNodes.FirstOrDefault(x => x.Name == "a").InnerText.Trim();

                var blogData = new BlogData
                {
                    BlogImage = blogImage,
                    Title = title,
                    Author = author,
                    PublishDate = publishDate,
                };
                blogDatalist.Add(blogData);
            }
            return View("Index",blogDatalist);
        }
    }
}
