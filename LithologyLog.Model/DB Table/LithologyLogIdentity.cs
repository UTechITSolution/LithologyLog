using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LithologyLog.Model
{
    public class UserApp : IdentityUser
    {
        public UserApp()
        {

        }

        [Required]
        public bool Status { get; set; }
    }

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base()
        {
        
        }

        public ApplicationRole(string roleName)
        {
            Name = roleName;
        }

        public string Description { get; set; }

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }

    }

    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public virtual UserApp User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}
