using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidBootcamp.WebApplication.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }

        public Category? Category { get; set; } // ini masukan utntuk jadi tanda bahwa si product ini nyambung sama category ini jadi navigation properties
        // karen ini berelasi
    }
}
