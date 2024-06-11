using Microsoft.AspNetCore.Mvc;
using RapidBootcamp.BackEndAPI.DAL;
using RapidBootcamp.BackEndAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RapidBootcamp.BackEndAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        //inject
        private readonly ICategory _category;
        public CategoriesController(ICategory category) 
        {
            _category = category;
        }
        // GET: api/<CategoriesController>
        [HttpGet] //metodnya ini ditulis
        public IEnumerable<Category> Get()
        {
            //List<Category> categories = new List<Category>()
            //{
            //    new Category {CategoryId = 1, CategoryName="Laptop Gaming"},
            //    new Category {CategoryId = 2, CategoryName="Laptop Bussines"}
            //};
            var categories = _category.GetAll();
            return categories; // kalau di sini ini jadinya otomatiss inikan tipenya listof cateogory tapi langsung dijadikan jason
            //return new string[] { "value1", "value2" };
        }
        //jadi dari list categoyr diconversi jadi jason makanya IEnumirabel

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")] //ini ada kurung kurwal karen ada inputnya
        public Category Get(int id) // ini di rubah cadi Category dari string Get ke Category
        {
            var category = _category.GetById(id);
            return category;
        }

        //kika bisa kustem httpgetnya untuk tertentu gunannya custom itu untuk supaya gak bingung soalnya httpGet all itu sudah sempat dipakai
        //cara panggilnya nanti /api/Categories/ByName?name=laptop kalau dua paramater juga bisa tinggal nanti dan
        //kalau pakai url segment bisa juga da jadi gantinya ini tapi ini jarang dipakai dia ntnai gak perlu pakai ?name=
        //bisa langsung sebutkan namenya
        //[HttpGet("ByName/{name}")]
        [HttpGet("ByName")]
        public IEnumerable<Category> GetByName(string name)
        {
            var categories = _category.GetByCategoryName(name);
            return categories;
        }

        // POST api/<CategoriesController>
        [HttpPost]
        //public void Post([FromBody] string value) //FromBody itu boleh dimasukan boleh engga soalnya by default udah from body
        public IActionResult Post(Category category) //returnnya bisa tambil hhtp status gitu, http status 404 not found dll. ini untuk memudahkan nantinya developer frontend
        {
            try
            {
                var result = _category.Add(category);
                //return Ok(result); atau
                return CreatedAtAction(nameof(Get), 
                    new { id = category.CategoryId }, category);// bisa juaga pakai langsung masukan Getnya nameof biar gak typo
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Category category) //boleh juga gak dikasih id tapi ini dikasih soalnya untuk mempermudahkan programer frontend
        {
            var updateData = _category.GetById(id);
            try
            {
                if (updateData != null)
                {
                    updateData.CategoryName = category.CategoryName;
                    var result = _category.Update(updateData); //bisa gitu .Update(category)
                    return Ok(result);
                }
                return BadRequest($"Category {category.CategoryName} not found");
            }
            catch (Exception ex)
            {

                return BadRequest($"{ex.Message}");
            }
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var deleteData = _category.GetById(id);
                if (deleteData != null)
                {
                    _category.Delete(deleteData.CategoryId);
                    return Ok($"Data Category ID {id} berhasil di delete");
                }
                return BadRequest($"Data Category Id {id} not found !");

            }
            catch (Exception ex)
            {

                return BadRequest($"Could not delete {ex.Message}");
            }
        }
    }
}
