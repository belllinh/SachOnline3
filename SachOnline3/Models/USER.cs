using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SachOnline3.Models
{
    [Table("USER")]
    public partial class USER
    {

        public USER()
        {

        }

        [Key]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public string Avatar { get; set; }

        public string Email { get; set; }

        [Required]
        public string Role { get; set; }


    }
}