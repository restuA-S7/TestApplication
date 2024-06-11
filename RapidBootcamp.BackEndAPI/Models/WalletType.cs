namespace RapidBootcamp.BackEndAPI.Models
{
    public class WalletType
    {
        public int WalletTypeId { get; set; }
        public string WalletName { get; set; } = null;

        public IEnumerable<Wallet> Wallets { get; set; }
    }
}
