using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DLA.Models.TownHallModels;
using DLA.Repository;

namespace COCServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TownHallLevelsController(TownHallRepository repository) : ControllerBase
    {
        // GET: api/TownHallLevels
        [HttpGet]
        public ActionResult GetTownHallLevels()
        {
            return Ok(repository.GetAll());
        }

        // GET: api/TownHallLevels/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetTownHallLevels(int id)
        {
            var townHallLevels = await repository.GetById(id);

            if (townHallLevels == null)
            {
                return NotFound();
            }

            return Ok(townHallLevels);
        }

        // PUT: api/TownHallLevels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTownHallLevels(int id, TownHallLevels townHallLevels)
        {
            if (id != townHallLevels.Id)
            {
                return BadRequest();
            }

            try
            {
                await repository.Update(townHallLevels);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TownHallLevelsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return Conflict("Concurrency conflict occurred while updating the entity.");
                }
            }
            catch (Exception ex)
            {
                // General exception handling if needed
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return NoContent();
        }

        // POST: api/TownHallLevels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TownHallLevels>> PostTownHallLevels(TownHallLevels townHallLevels)
        {
            await repository.Add(townHallLevels);

            return CreatedAtAction("GetTownHallLevels", new { id = townHallLevels.Id }, townHallLevels);
        }

        // DELETE: api/TownHallLevels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTownHallLevels(int id)
        {
            var townHallLevels = await GetTownHallLevels(id);
            if (townHallLevels == NotFound())
            {
                return NotFound();
            }

            await repository.Delete(id);

            return NoContent();
        }

        private async Task<bool> TownHallLevelsExists(int id)
        { 
            var townHallLevels = await repository.GetById(id);
            return townHallLevels != null;
        }
    }
}
