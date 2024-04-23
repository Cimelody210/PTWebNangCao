namespace CodeFirstToExistingDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Blog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BlogId { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Url { get; set; }
    }
}
