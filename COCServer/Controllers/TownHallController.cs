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
        [HttpGet("Details/{id}")]
        public ActionResult Details(string id)
        {
            return Ok($"Details for item with id {id}"); // Replace with actual logic
        }

        [Authorize(Roles = "Admin")]
        // POST: api/townHall/Create
        [HttpPost("Create")]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create([FromBody]TownHallLevels townHall)
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
        public ActionResult Edit(string id, [FromBody] TownHallLevels updatedTownHall)
        {
            if (ModelState.IsValid)
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

            return BadRequest(ModelState);
        }

        [Authorize(Roles = "Admin")]
        // DELETE: api/townHall/Delete/5
        [HttpDelete("Delete/{id}")]
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