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
    public class UserController : ControllerBase
    {
        private readonly IMongoCollection<User> _user;

        public UserController(MongoDbService mongoDbService)
        {
            _user = mongoDbService.GetDatabase.GetCollection<User>("users");
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            try
            {
                var products = await _user.Find(FilterDefinition<User>.Empty).ToListAsync();

                return Ok(products);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<User>> GetById(string id)
        {
            try
            {
                var products = await _user.Find(x => x.Id == id).FirstOrDefaultAsync();

                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            try
            { 
                await _user.InsertOneAsync(user);

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
                await _user.DeleteOneAsync(x => x.Id == id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(string id, User newUserData)
        {
            try
            {
                newUserData.Id = id;
                await _user.ReplaceOneAsync(x => x.Id == id, newUserData);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
