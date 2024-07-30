using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinimalAPIWithMongoDB.Services;
using MinimalAPIWithMongoDB.Domains;
using MongoDB.Driver;

namespace MinimalAPIWithMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IMongoCollection<Product> _product;

        public ProductController(MongoDbService mongoDbService)
        {
            _product = mongoDbService.GetDatabase.GetCollection<Product>("products");
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            try
            {
                var products = await _product.Find(FilterDefinition<Product>.Empty).ToListAsync();

                return Ok(products);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<Product>> GetById(string id)
        {
            try
            {
                var products = await _product.Find(x => x.Id == id).FirstOrDefaultAsync();

                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            try
            { 
                await _product.InsertOneAsync(product);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _product.DeleteOneAsync(x => x.Id == id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(string id, Product newProductData)
        {
            try
            {
                newProductData.Id = id;
                await _product.ReplaceOneAsync(x => x.Id == id, newProductData);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
