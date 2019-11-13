using LithologyLog.Web.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LithologyLog.Web.Models
{
    public class OrganizationList
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public string MobileNumber { get; set; }

        public string Email { get; set; }

        public string Fax { get; set; }

        public string TIN { get; set; }
    }


    public class OrganizationCreateViewModel
    {

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(SharedResources))]
        [Display(Name = "Name", ResourceType = typeof(SharedResources))]
        public string Name { get; set; }


        [Display(Name = "ShortName", ResourceType = typeof(SharedResources))]
        public string ShortName { get; set; }

        [Display(Name = "MobileNumber", ResourceType = typeof(SharedResources))]
        public string MobileNumber { get; set; }

        [Display(Name = "Email", ResourceType = typeof(SharedResources))]
        public string Email { get; set; }

        [Display(Name = "Fax", ResourceType = typeof(SharedResources))]
        public string Fax { get; set; }

        [Display(Name = "TIN", ResourceType = typeof(SharedResources))]
        public string TIN { get; set; }
    }

    public class OrganizationEditViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(SharedResources))]
        [Display(Name = "Name", ResourceType = typeof(SharedResources))]
        public string Name { get; set; }

        [Display(Name = "ShortName", ResourceType = typeof(SharedResources))]
        public string ShortName { get; set; }

        [Display(Name = "MobileNumber", ResourceType = typeof(SharedResources))]
        public string MobileNumber { get; set; }

        [Display(Name = "Email", ResourceType = typeof(SharedResources))]
        public string Email { get; set; }

        [Display(Name = "Fax", ResourceType = typeof(SharedResources))]
        public string Fax { get; set; }

        [Display(Name = "TIN", ResourceType = typeof(SharedResources))]
        public string TIN { get; set; }
    }
}
