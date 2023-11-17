using Microsoft.AspNetCore.Mvc;
using Rentler.Interview.Api.Context;
using Rentler.Interview.Api.Entities;
using Rentler.Interview.Api.Repositories;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rentler.Interview.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly IFoodsRepository _repo;

        public FoodsController(IFoodsRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Food>>> GetFoods([FromQuery] PagingModel pagingData)
        {
            var result = await _repo.GetAllFoods(pagingData);
            HttpContext.Response.Headers.Add("Paging-Headers", JsonSerializer.Serialize(result.Item2));
            return result.Item1;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Food>> Get(int id)
        {
            return await _repo.GetFood(id);
        }

        [HttpPost]
        public async Task<ActionResult<Food>> Post([FromBody] Food food)
        {
            return Ok(await _repo.SaveFood(food));
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Food food)
        {
            await _repo.UpdateFood(food);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repo.DeleteFood(id);
            return Ok();
        }
    }
}
