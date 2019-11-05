using LithologyLog.Web.Lang;
using LithologyLog.Web.Resources;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LithologyLog.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(SharedResources))]
        [Display(Name = "UserName",ResourceType = typeof(SharedResources))]
        public string Username { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(SharedResources))]
        [Display(Name = "Password", ResourceType = typeof(SharedResources))]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
