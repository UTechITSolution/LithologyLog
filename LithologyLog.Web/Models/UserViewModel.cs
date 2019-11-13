using LithologyLog.Web.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LithologyLog.Web.Models
{
    public class UserList
    {
        public string Id { get; set; }
       
        public string UserName { get; set; }
       
        public string Status { get; set; }
    }

    public class UserCreateViewModel
    {
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(SharedResources))]
        [Display(Name = "UserName", ResourceType = typeof(SharedResources))]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(SharedResources))]
        [Display(Name = "Password", ResourceType = typeof(SharedResources))]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Status", ResourceType = typeof(SharedResources))]
        public bool Status { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(SharedResources))]
        [Display(Name = "Role", ResourceType = typeof(SharedResources))]
        public IEnumerable<string> GetRoles { get; set; }

    }

    public class UserEditViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(SharedResources))]
        [Display(Name = "UserName", ResourceType = typeof(SharedResources))]
        public string UserName { get; set; }

        [Display(Name = "Password", ResourceType = typeof(SharedResources))]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Status", ResourceType = typeof(SharedResources))]
        public bool Status { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(SharedResources))]
        [Display(Name = "Role", ResourceType = typeof(SharedResources))]
        public IEnumerable<string> GetRoles { get; set; }

    }
}
