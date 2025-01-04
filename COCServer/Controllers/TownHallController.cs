using DLA.Models.TownHallModels;
using DLA.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace COCServer.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class TownHallController : ControllerBase
    {
        private readonly IRepository<TownHallLevels> _repository;

        public TownHallController(IRepository<TownHallLevels> repository)
        {
            _repository = repository;
        }

        // GET: api/townHall
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var allItems = await _repository.GetAll();
            return Ok(allItems);
        }

        // GET: api/townHall/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Details(string id)
        {
            // Replace with actual logic to get town hall details
            var townHall = await _repository.GetById(id);
            if (townHall == null)
            {
                return NotFound($"Town Hall with ID {id} not found.");
            }
            return Ok(townHall);
        }

        [Authorize(Roles = "Admin")]
        // POST: api/townHall/Create
        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] TownHallLevels townHall)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.Add(townHall);
                    return Created($"/townHall/{townHall.Id}", townHall);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
            return BadRequest(ModelState);
        }

        [Authorize(Roles = "Admin")]
        // PUT: api/townHall/Edit/5
        [HttpPut("Edit/{id}")]
        public async Task<ActionResult> Edit(string id, [FromBody] TownHallLevels updatedTownHall)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Check if town hall exists before updating
                    var existingTownHall = await _repository.GetById(id);
                    if (existingTownHall == null)
                    {
                        return NotFound($"Town Hall with ID {id} not found.");
                    }

                    await _repository.Update(updatedTownHall);
                    return NoContent(); // 204 No Content
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }

            return BadRequest(ModelState);
        }

        [Authorize(Roles = "Admin")]
        // DELETE: api/townHall/Delete/5
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var townHall = await _repository.GetById(id);
                if (townHall == null)
                {
                    return NotFound($"Town Hall with ID {id} not found.");
                }

                await _repository.Delete(id);
                return NoContent(); // 204 No Content
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}