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
    public class ClientController : ControllerBase
    {
        private readonly IMongoCollection<Client> _client;

        public ClientController(MongoDbService mongoDbService)
        {
            _client = mongoDbService.GetDatabase.GetCollection<Client>("clients");
        }

        [HttpGet]
        public async Task<ActionResult<List<Client>>> GetAll()
        {
            try
            {
                var products = await _client.Find(FilterDefinition<Client>.Empty).ToListAsync();

                return Ok(products);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<Client>> GetById(string id)
        {
            try
            {
                var products = await _client.Find(x => x.Id == id).FirstOrDefaultAsync();

                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Client client)
        {
            try
            { 
                await _client.InsertOneAsync(client);

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
                await _client.DeleteOneAsync(x => x.Id == id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(string id, Client newClientData)
        {
            try
            {
                newClientData.Id = id;
                await _client.ReplaceOneAsync(x => x.Id == id, newClientData);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}