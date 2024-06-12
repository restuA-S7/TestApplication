using RapidBootcamp.BackEndAPI.Models;

namespace RapidBootcamp.BackEndAPI.DAL
{
    public interface IWallet :ICrud<Wallet>
    {
        decimal GetWalletSaldo(int walletId);
        void UpdateWalletSaldo(int walletId, decimal amount);
    }
}
