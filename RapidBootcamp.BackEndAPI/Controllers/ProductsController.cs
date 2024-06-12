using Microsoft.AspNetCore.Mvc;
using RapidBootcamp.BackEndAPI.DAL;
using RapidBootcamp.BackEndAPI.DTO;
using RapidBootcamp.BackEndAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RapidBootcamp.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProduct _product;
        public ProductsController(IProduct product)
        {
            _product = product;
        }
        // GET: api/<ProductsController>
        [HttpGet] //kalau pakai ini jadina A possible object cycle was detected harus buat DTO
        //public IEnumerable<Product> Get()
        //{
        //    var products = _product.GetByProductWithCategory();
        //    return products;
        //}
        
        public IEnumerable<ProductDTO> Get()
        {
            List<ProductDTO> productDTOs = new List<ProductDTO>();
            var products = _product.GetByProductWithCategory();

            foreach (var product in products)
            {
                ProductDTO productDTO = new ProductDTO()
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    Stock = product.Stock,
                    Price = product.Price,
                    Category = new CategoryDTO
                    {
                        CategoryId = product.Category.CategoryId,
                        CategoryName = product.Category.CategoryName
                    }
                };
                productDTOs.Add(productDTO);
            }
            return (productDTOs);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var product = _product.GetById(id);
            return product;
        }

        [HttpGet("ByCategory/{categoryId}")]  //ini customm routing ini gak boleh sama
        public IEnumerable<Product> GetByCategory(int categoryId)
        {
            var product = _product.GetByCategory(categoryId);
            return product;
        }

        [HttpGet("ByProductName")]  //ini customm gak usah pakai kurung kurawal soalnya mau cari pakai tanda tanya
        // penggunaan /api/Products/ByProductName?ProductName=adooo
        // atau api/Products/ByProductName?name=a  bedanya pneggunaan name dan ProductName itu sesuai parameter disini
        public IEnumerable<Product> GetByProductName(string name) //ini boleh pakai parameter c
        {
            var product = _product.GetByProductName(name); //ProductName bedanya dicara pemangilan aja
            return product;
        }

        // POST api/<ProductsController>
        [HttpPost]
        public ActionResult Post(Product product)
        {
            try
            {
                var result = _product.Add(product);
                return CreatedAtAction(nameof(Get), new { id = product.ProductId }, product);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Product product)
        {
            var updateProduct = _product.GetById(id);
            if (updateProduct == null)
            {
                return NotFound();
            };
            try
            {
                updateProduct.CategoryId = product.CategoryId;
                updateProduct.ProductName = product.ProductName;
                updateProduct.Stock = product.Stock;
                updateProduct.Price = product.Price;
                var result = _product.Update(updateProduct);
                return Ok(result);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var deleteProduct = _product.GetById(id);
            if(deleteProduct == null)
            {
                return NotFound();
            }
            try
            {
                _product.Delete(id);
                return Ok($"Product {id} Delete Berhasil");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
