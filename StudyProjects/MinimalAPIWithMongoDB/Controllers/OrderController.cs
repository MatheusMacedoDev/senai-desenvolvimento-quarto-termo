using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinimalAPIWithMongoDB.Domains;
using MinimalAPIWithMongoDB.Services;
using MinimalAPIWithMongoDB.ViewModels;
using MongoDB.Driver;

namespace MinimalAPIWithMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class OrderController : ControllerBase
    {
        private readonly IMongoCollection<Order> _order;
        private readonly IMongoCollection<Client> _client;
        private readonly IMongoCollection<Product> _product;

        public OrderController(MongoDbService mongoDbService)
        {
            _order = mongoDbService.GetDatabase.GetCollection<Order>("orders");
            _client = mongoDbService.GetDatabase.GetCollection<Client>("clients");
            _product = mongoDbService.GetDatabase.GetCollection<Product>("products");
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderViewModel orderData)
        {
            try
            {
                var order = new Order
                {
                    Date = DateOnly.Parse(DateTime.Now.ToString().Split(" ")[0]),
                    Status = orderData.Status,
                    ProductsId = orderData.ProductsId,
                    ClientId = orderData.ClientId,
                };

                var client = await _client.Find(x => x.Id == order.ClientId).FirstOrDefaultAsync();

                if (client == null)
                {
                    return NotFound("Cliente informado não existe");
                }

                await _order.InsertOneAsync(order);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<Order>> GetAll()
        {
            try
            {
                var orders = await _order.Find(FilterDefinition<Order>.Empty).ToListAsync();

                foreach (var order in orders)
                {
                    List<Product> productsList = new List<Product>();

                    foreach (var productId in order.ProductsId!)
                    {
                        var product = await _product.Find(product => product.Id == productId).FirstOrDefaultAsync();

                        if (product == null)
                            continue;

                        productsList.Add(product);
                    }

                    order.Products = productsList;

                    var client = await _client.Find(x => x.Id == order.ClientId).FirstOrDefaultAsync();

                    order.Client = client;
                }

                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<Order>> GetById(string id)
        {
            try
            {
                var order = await _order.Find(x => x.Id == id).FirstOrDefaultAsync();

                List<Product> productsList = new List<Product>();

                foreach(var productId in order.ProductsId!)
                {
                    var product = await _product.Find(product => product.Id == productId).FirstOrDefaultAsync();

                    if (product == null)
                        continue;

                    productsList.Add(product);
                }

                order.Products = productsList;

                var client = await _client.Find(x => x.Id == order.ClientId).FirstOrDefaultAsync();
                order.Client = client;

                return Ok(order);
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
                await _order.DeleteOneAsync(x => x.Id == id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(string id, OrderViewModel newOrderData)
        {
            try
            {
                var order = new Order
                {
                    Id = id,
                    Date = DateOnly.Parse(DateTime.Now.ToString().Split(" ")[0]),
                    Status = newOrderData.Status,
                    ProductsId = newOrderData.ProductsId,
                    ClientId = newOrderData.ClientId,
                };

                var client = await _client.Find(x => x.Id == order.ClientId).FirstOrDefaultAsync();

                if (client == null)
                {
                    return NotFound("Cliente informado não existe");
                }

                await _order.ReplaceOneAsync(x => x.Id == id, order);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
