using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CodeFirstNewDatabase
{
	public class BloggingContext : DbContext
	{
		public BloggingContext() : base("BloggingContextConnectionString") { }
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<Post> Posts { get; set; }
	}

}
