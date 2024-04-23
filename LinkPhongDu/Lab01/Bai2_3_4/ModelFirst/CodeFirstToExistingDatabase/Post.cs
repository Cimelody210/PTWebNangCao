namespace CodeFirstToExistingDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PostId { get; set; }

        [StringLength(80)]
        public string Title { get; set; }

        [StringLength(100)]
        public string Content { get; set; }

        public int? BlogId { get; set; }

        public virtual Post Posts1 { get; set; }

        public virtual Post Post1 { get; set; }
    }
}
