using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeSystem.Domain;
using TimeSystem.Persistence;

namespace NinjaWarriorTimingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeedWallsController : ControllerBase
    {
        private readonly TimingSystemDbContext _context;

        public SpeedWallsController(TimingSystemDbContext context)
        {
            _context = context;
        }

        // GET: api/SpeedWalls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpeedWall>>> GetSpeedWalls()
        {
            return await _context.SpeedWalls.ToListAsync();
        }

        // GET: api/SpeedWalls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SpeedWall>> GetSpeedWall(int id)
        {
            var speedWall = await _context.SpeedWalls.FindAsync(id);

            if (speedWall == null)
            {
                return NotFound();
            }

            return speedWall;
        }

        // PUT: api/SpeedWalls/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpeedWall(int id, SpeedWall speedWall)
        {
            if (id != speedWall.Id)
            {
                return BadRequest();
            }

            _context.Entry(speedWall).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpeedWallExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SpeedWalls
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<SpeedWall>> PostSpeedWall(SpeedWall speedWall)
        {
            _context.SpeedWalls.Add(speedWall);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpeedWall", new { id = speedWall.Id }, speedWall);
        }

        // DELETE: api/SpeedWalls/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SpeedWall>> DeleteSpeedWall(int id)
        {
            var speedWall = await _context.SpeedWalls.FindAsync(id);
            if (speedWall == null)
            {
                return NotFound();
            }

            _context.SpeedWalls.Remove(speedWall);
            await _context.SaveChangesAsync();

            return speedWall;
        }

        private bool SpeedWallExists(int id)
        {
            return _context.SpeedWalls.Any(e => e.Id == id);
        }
    }
}
