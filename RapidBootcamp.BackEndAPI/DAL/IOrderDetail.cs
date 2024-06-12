using RapidBootcamp.BackEndAPI.Models;

namespace RapidBootcamp.BackEndAPI.DAL
{
    public interface IOrderDetail : ICrud<OrderDetail>
    {
        IEnumerable<OrderDetail> GetDetailsByHeaderId(string orderHeaderId);
        decimal GetTotalAmount(string orderHeaderId);
        //int CheckProductStock(int productId, int qty);//ini bisa buat disini,bisa juga buat di product intinya kalau masih ada bagian gitu atau masih keterkaitan
    } 
}
