using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidBootcamp.WebApplication.Models
{
    public class OrderHeader
    {
        [Key]
        public string OrderHeaderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime TransactionDate { get; set; }
        //[ForeignKey("WalletId")]
        //public int WalletId { get; set; }

        public Customer? Customer { get; set; }
        //public Wallet? Wallet { get; set; }
        public IEnumerable<OrderDetail>? OrderDetails { get; set; }
    }
}
