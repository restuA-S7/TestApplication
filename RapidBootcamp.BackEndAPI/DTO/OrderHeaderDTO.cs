namespace RapidBootcamp.BackEndAPI.DTO
{
    public class OrderHeaderDTO
    {
        public string OrderHeaderId { get; set; } = null!;
        public DateTime TransactionDate { get; set; }
        public int WalletId { get; set; }
        public decimal Saldo { get; set; }
        public string WalletName { get; set; } = null!;
        public string CustomerName { get; set; } = null!;

        //askesnya bisa gini
        public List<OrderDetailDTO>? OrderDetails { get; set; } //ini harus get set ini harus properti prop
        //public IEnumerable<OrderDetailDTO>? OrderDetails; //IEnum itu objek2 yang bisa di foreach

    }
}
