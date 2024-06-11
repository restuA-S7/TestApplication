namespace RapidBootcamp.BackEndAPI.ViewModels
{
    public class ViewOrderHeaderInfo
    {
        public string OrderHeaderId { get; set; } = null;
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null;
        public string WalletName { get; set; } = null;
        public DateTime TransactionDate { get; set; }
    }
}
