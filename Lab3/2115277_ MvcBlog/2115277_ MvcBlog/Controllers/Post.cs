namespace Cau1.Controllers.Core
{
    public class Post
    {
        public int PostsId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }

        public virtual Blog Blog
        {
            get;
            set;
        }

    }
}