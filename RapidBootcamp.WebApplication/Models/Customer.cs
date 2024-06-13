using System.ComponentModel.DataAnnotations;

namespace RapidBootcamp.WebApplication.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(255)]
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
