using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SachOnline3.Models
{
    public class userLogin
    {
        [Required(ErrorMessage = "User không được đỡ trống hoặc đã tồn tại")]
        [StringLength(50)]

        public string User { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(255, ErrorMessage = "Mật khẩu từ 8 đến 255 kí tự", MinimumLength = 8)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%?&])[A-Za-z\\D@$!%*?&]{8,}$",
        ErrorMessage = "Mật khẩu tối thiểu tám kí tự , ít nhất một chữ hao , một chữn thường , một số và một ký tự đặc biệt" )]

        public string Password { get; set; }
    }
}