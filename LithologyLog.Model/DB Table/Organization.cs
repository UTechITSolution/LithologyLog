using System.ComponentModel.DataAnnotations;

namespace LithologyLog.Model
{
    public class Organization
    {
        [Key]
        public int Id { get; set; }
        
        [StringLength(50), MinLength(3), Required]
        public string Name { get; set; }

        [StringLength(50), MinLength(1), Required]
        public string ShortName { get; set; }

        [Phone]
        public string MobileNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [StringLength(50)]
        public string Fax { get; set; }

        [StringLength(10)]
        public string TIN { get; set; }

    }
}
