using Microsoft.AspNetCore.Mvc;
using RapidBootcamp.BackEndAPI.DAL;
using RapidBootcamp.BackEndAPI.Models;
using RapidBootcamp.BackEndAPI.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RapidBootcamp.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderHeadersController : ControllerBase
    {
        private readonly IOrderHeader _orderHeader; //dependensi injection
        private readonly IOrderDetail _orderDetail;
        public OrderHeadersController(IOrderHeader orderHeader, IOrderDetail orderDetail)
        {
            _orderHeader = orderHeader;
            _orderDetail = orderDetail;
        }
        // GET: api/<OrderHeadersController>
        [HttpGet]
        public IEnumerable<OrderHeader> Get()
        {
            var results = _orderHeader.GetAll();
            foreach(var item in results)
            {
                item.OrderDetails = _orderDetail.GetDetailsByHeaderId(item.OrderHeaderId);
            }
            return results;
        }

        [HttpGet("View")]
        public IEnumerable<ViewOrderHeaderInfo> GetAllWithView()
        {
            var results = _orderHeader.GetAllWithView();
            return results;
        }

        // GET api/<OrderHeadersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderHeadersController>
        [HttpPost]
        public IActionResult Post([FromBody] OrderHeader orderHeader)
        {
            try
            {
                //ambil last orderheaderid
                string lastOrderHeaderId = _orderHeader.GetOrderLastHeaderId();

                lastOrderHeaderId = lastOrderHeaderId.Substring(4, 4);
                int newOrderHeaderId = Convert.ToInt32(lastOrderHeaderId) + 1;
                string newOrderHeaderIdString = "INV-" + newOrderHeaderId.ToString().PadLeft(4, '0');

               
                orderHeader.OrderHeaderId = newOrderHeaderIdString;

                var result = _orderHeader.Add(orderHeader);
                //---tambahan kalau mau masukin juga order detail
                foreach (var item in orderHeader.OrderDetails)
                {
                    item.OrderHeaderId = newOrderHeaderIdString;
                    _orderDetail.Add(item);
                }

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<OrderHeadersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderHeadersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
