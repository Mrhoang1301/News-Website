namespace DataAccess.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class comment
    {
        [Key]
        public int cmt_id { get; set; }

        public int? user_id { get; set; }

        public int? article_id { get; set; }

        public string cmt_cotnent { get; set; }

        public DateTime? create_time { get; set; }
    }
}
