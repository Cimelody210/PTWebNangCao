using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePizzaWebApplication.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }

        public List<OrderDetail> OrderLines { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên của bạn")]
        [Display(Name = "Tên")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ của bạn")]
        [Display(Name = "Họ")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ của bạn")]
        [StringLength(100)]
        [Display(Name = "Địa chỉ 1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Địa chỉ 2")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mã zip của bạn")]
        [Display(Name = "Mã Zip")]
        [StringLength(10, MinimumLength = 4)]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên thành phố bạn đang sống")]
        [StringLength(50)]
        [Display(Name = "Thành phố")]

        public string City { get; set; }

        [StringLength(10)]
        [Display(Name = "Tỉnh")]

        public string State { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên đất nước bạn đang sống")]
        [StringLength(50)]
        [Display(Name = "Đất nước")]

        public string Country { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại của bạn")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "Email đã nhập không đúng")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        [DisplayName("Tổng tiền đơn")]
        [Precision(18, 2)]
        public decimal OrderTotal { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        [DisplayName("Ngày đặt đơn")]
        public DateTime OrderPlaced { get; set; }

        //[BindNever]
        //[ScaffoldColumn(false)]
        //public string OrderStatus { get; set; }

        public string UserId { get; set; }
        [DisplayName("Tài khoản")]

        public IdentityUser User { get; set; }
        
    }
}
