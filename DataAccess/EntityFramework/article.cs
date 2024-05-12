namespace DataAccess.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class article
    {
        [Key]
        public int article_id { get; set; }

        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "Vui lòng không để trống tiêu đề bài viết!")]
        public string title { get; set; }

      
        [Display(Name = "Nội dung")]
        [Required(ErrorMessage = "Vui lòng không để trống nội dung!")]
        public string textbody { get; set; }

        public DateTime? create_time { get; set; }

        [Display(Name = "Ảnh")]
        public string image { get; set; }

        public int? user_id { get; set; }

        [Display(Name = "Thể loại")]
        public int? cate_id { get; set; }
    }
}
