using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mime;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstNewDatabase
{
	internal class Program
	{
		static void Main(string[] args)
		{
			using (var db = new BloggingContext())
			{
				//// Create and save a new Blog
				//Console.Write("Enter a name for a new Blog: ");
				//var name = Console.ReadLine();
				//var blog = new Blog { Name = name };
				//db.Blogs.Add(blog);
				//db.SaveChanges();

				//// Display all Blogs from the database
				//var query = from b in db.Blogs
				//			orderby b.Name
				//			select b;

				//Console.WriteLine("All blogs in the database:");
				//foreach (var item in query)
				//{
				//	Console.WriteLine(item.Name);
				//}

				//===c. Them Post ===
				//int k = 1;
				//while (k == 1)
				//{
				//	// Create and save a new Posts
				//	Console.Write("Enter a title, Content,BlogId for a new Blog: ");
				//	var title = Console.ReadLine();
				//	var content = Console.ReadLine();
				//	string input = Console.ReadLine();
				//	int blog_id = int.Parse(input);
				//	var post = new Post { Title = title, Content = content, BlogId = blog_id };
				//	db.Posts.Add(post);
				//	db.SaveChanges();
				//	Console.Write("nhap 1 tiep tuc, 0 ket thuc: ");
				//	string input1 = Console.ReadLine(); 
				//	k = int.Parse(input1);
				//}

				////Display all Posts from the database
				//var query = from b in db.Posts
				//			orderby b.Title
				//			select b;

				//Console.WriteLine("All post in the database:");
				//foreach (var item in query)
				//{
				//	Console.WriteLine(item.Title);
				//}

				//===d. Truy van Post co BlogId ten "Xa hoi".===
				//var query = from p in db.Posts
				//			join b in db.Blogs on p.BlogId equals b.BlogId
				//			where b.Name.Contains("Xa hoi")
				//			select new { p.PostId, p.Title, p.Content };

				//Console.WriteLine("All post in BlogId name 'Xa hoi' :");
				//foreach (var item in query)
				//{
				//	Console.WriteLine($"PostId: {item.PostId}, Title: {item.Title}, Content: {item.Content}");
				//}

				//===e. Xoa Post có id la 4 ===
				//var postToRemove = db.Posts.SingleOrDefault(post => post.PostId == 4);
				//if (postToRemove != null)
				//{
				//	db.Posts.Attach(postToRemove);
				//	db.Posts.Remove(postToRemove);
				//	db.SaveChanges();
				//	Console.WriteLine("PostID = 4 delete.");
				//}
				//else
				//{
				//	Console.WriteLine("Not found post with ID 4");
				//}

				//===f. Cap nhat postId 3 thay Title "Tin khong tu nhien" ===
				//var postToUpdate = db.Posts.SingleOrDefault(post => post.PostId == 3);
				//if (postToUpdate != null)
				//{
				//	postToUpdate.Title = "Tin khong tu nhien"; 
				//	db.Entry(postToUpdate).State = EntityState.Modified; 
				//	db.SaveChanges();
				//	Console.WriteLine("The post with ID 3 has been updated.");
				//}
				//else
				//{
				//	Console.WriteLine("Not found post with Id 3");
				//}


				//===g.Truy van toan bo blog voi tung noi dung post ===
				var query = from b in db.Blogs
							select new
							{
								BlogID = b.BlogId,
								BlogName = b.Name,
								Post = from post in b.Posts
									   select post
							};
				foreach (var item in query)
				{
					Console.WriteLine($"Blog ID: {item.BlogID}, Blog Name: {item.BlogName}");
					foreach (var post in item.Post)
					{
						Console.WriteLine($"	Post ID: {post.PostId}, Post Content: {post.Content}");
					}
				}
			
				Console.WriteLine("Press any key to exit...");
				Console.ReadKey();
			}
		}
	}
}
