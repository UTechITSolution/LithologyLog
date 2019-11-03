using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LithologyLog.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Required")]
        [DisplayName("Password")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Required")]
        [DisplayName("UserName")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
