using DLA.Interface;
using DLA.Models;
using DLA.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace COCServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MongoTownHallController : ControllerBase
    {
        private readonly IRepository<TownHallLevels> _repository;

        public MongoTownHallController(IRepository<TownHallLevels> repository)
        {
            _repository = repository;
        }

        // GET: api/MongoTownHall
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var allItems = await _repository.GetAll();
            return Ok(allItems);
        }

        // GET: api/MongoTownHall/Details/5
        [HttpGet("Details/{id}")]
        public ActionResult Details(string id)
        {
            return Ok($"Details for item with id {id}"); // Replace with actual logic
        }

        // POST: api/MongoTownHall/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TownHallLevels townHall)
        {
            try
            {
                await _repository.Add(townHall);
                return Created($"/api/MongoTownHall/{townHall.Id}", townHall);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/MongoTownHall/Edit/5
        [HttpPut("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, [FromBody] TownHallLevels updatedTownHall)
        {
            try
            {
                return Ok($"Updated item with id {id}"); // Replace with actual logic
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/MongoTownHall/Delete/5
        [HttpDelete("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id)
        {
            try
            {
                return Ok($"Deleted item with id {id}"); // Replace with actual logic
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}