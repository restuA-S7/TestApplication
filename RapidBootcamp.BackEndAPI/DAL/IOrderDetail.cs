using RapidBootcamp.BackEndAPI.Models;

namespace RapidBootcamp.BackEndAPI.DAL
{
    public interface IOrderDetail : ICrud<OrderDetail>
    {
        IEnumerable<OrderDetail> GetDetailsByHeaderId(string orderHeaderId);
        decimal GetTotalAmount(string orderHeaderId);
    }
}
