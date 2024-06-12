using Microsoft.EntityFrameworkCore;
using RapidBootcamp.BackEndAPI.Models;
using RapidBootcamp.BackEndAPI.ViewModels;

namespace RapidBootcamp.BackEndAPI.DAL
{
    public class OrderHeadersEF : IOrderHeader
    {
        private readonly AppDBContext _appDBContext;
        public OrderHeadersEF(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public OrderHeader Add(OrderHeader entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderHeader> GetAll()
        {
            var result = _appDBContext.OrderHeaders
                .Include(oh => oh.Wallet).ThenInclude(w => w.Customer)
                .Include(oh => oh.Wallet).ThenInclude(w => w.WalletType)
                .Include(oh => oh.OrderDetails).ThenInclude(od => od.Product).ThenInclude(p => p.Category).ToList();
            return result;
        }

        public IEnumerable<ViewOrderHeaderInfo> GetAllWithView()
        {
            throw new NotImplementedException();
        }

        public OrderHeader GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderHeader> GetByOrderHeader(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderHeader> GetByOrderHeaderName(string productName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderHeader> GetByOrderHeaderWithCategory()
        {
            throw new NotImplementedException();
        }

        public string GetOrderLastHeaderId()
        {
            throw new NotImplementedException();
        }

        public OrderHeader Update(OrderHeader entity)
        {
            throw new NotImplementedException();
        }
    }
}
