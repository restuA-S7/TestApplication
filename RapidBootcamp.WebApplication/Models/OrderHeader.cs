namespace RapidBootcamp.WebApplication.Models
{
    public class OrderHeader
    {
        public string OrderHeaderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int WalletId { get; set; }

        public Customer? Customer { get; set; }
        public Wallet? Wallet { get; set; }
        public IEnumerable<OrderDetail>? OrderDetails { get; set; }
    }
}
