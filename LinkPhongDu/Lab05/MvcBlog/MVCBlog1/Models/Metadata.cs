using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBlog1.Models
{
	public class BlogSetMetadata
	{
		[Required(ErrorMessage = "Tên bài viết là bắt buộc")]
		[StringLength(50)]
		[Display(Name = "Tên bài viết")]
		public string Name ;

		[Required(ErrorMessage = "Đường dẫn là bắt buộc")]
		[StringLength(50)]
		[Display(Name = "Đường dẫn")]
		public string Url ;

		[Required(ErrorMessage = "Mô tả là bắt buộc")]
		[StringLength(500)]
		[Display(Name = "Mô tả")]
		public string Description ;

		[Required(ErrorMessage = "Tác giả là bắt buộc")]
		[StringLength(50)]
		[Display(Name = "Tác giả")]
		public string Owner ;

		[Required(ErrorMessage = "Cấp độ là bắt buộc")]
		[Display(Name = "Cấp độ")]
		[Range(1, 100, ErrorMessage = "Cấp độ phải nằm trong khoảng từ 1 đến 100")]
		public Nullable<int> Rank ;
	}

	public class PostSetMetadata
	{
		[Required(ErrorMessage = "Tiêu đề là bắt buộc.")]
		[StringLength(50, MinimumLength = 5, ErrorMessage = "Tiêu đề phải nằm trong khoảng từ 5 đến 50 ký tự.")]
		[Display(Name = "Tiêu đề")]
		public string Title ;

		[Required(ErrorMessage = "Nội dung là bắt buộc.")]
		[StringLength(500, MinimumLength = 10, ErrorMessage = "Nội dung phải nằm trong khoảng từ 10 đến 500")]
		[Display(Name = "Nội dung")]
		public string Content ;

		[Required(ErrorMessage = "Hãy chọn loại bài viết")]
		[Display(Name = "Thuộc bài viết")]
		[Range(1, int.MaxValue, ErrorMessage = "BlogID khác 0")]
		public int BlogBlogId ;

		[Display(Name = "Thời gian tạo")]
		[Required(ErrorMessage = "Hãy chọn ngày tháng")]
		[DataType(DataType.Date, ErrorMessage = "Nhập đúng định dạng dd/mm/yyyy")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		public Nullable<System.DateTime> CreatedDate ;
	}
}