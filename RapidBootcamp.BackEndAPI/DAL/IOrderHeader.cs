using RapidBootcamp.BackEndAPI.Models;
using RapidBootcamp.BackEndAPI.ViewModels;

namespace RapidBootcamp.BackEndAPI.DAL
{
    public interface IOrderHeader : ICrud<OrderHeader>
    {
        IEnumerable<OrderHeader> GetByOrderHeader(int categoryId);
        IEnumerable<OrderHeader> GetByOrderHeaderName(string productName);
        IEnumerable<OrderHeader> GetByOrderHeaderWithCategory();

        IEnumerable<ViewOrderHeaderInfo> GetAllWithView();
        public string GetOrderLastHeaderId();
    }
}
