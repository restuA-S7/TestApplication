using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidBootcamp.WebApplication.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        public string OrderHeaderId { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
      

        public OrderHeader OrderHeader { get; set; }
        public Product Product { get; set; }
      
    }
}

