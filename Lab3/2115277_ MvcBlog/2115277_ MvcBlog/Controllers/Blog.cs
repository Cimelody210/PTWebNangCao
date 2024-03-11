using System.Collections.Generic;
using System;
using System.IO;
using System.Data.Entity;
using System.Linq.Dynamic.Core;
namespace Cau1.Controllers.Core
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }

        public virtual List<Post> Posts
        {
            get; set;
        }
    }
}
