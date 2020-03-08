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
    public class RaceQueuesController : ControllerBase
    {
        private readonly TimingSystemDbContext _context;

        public RaceQueuesController(TimingSystemDbContext context)
        {
            _context = context;
        }

        // GET: api/RaceQueues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RaceQueue>>> GetRaceQueue()
        {
            return await _context.RaceQueue.ToListAsync();
        }

        // GET: api/RaceQueues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RaceQueue>> GetRaceQueue(int id)
        {
            var raceQueue = await _context.RaceQueue.FindAsync(id);

            if (raceQueue == null)
            {
                return NotFound();
            }

            return raceQueue;
        }

        // PUT: api/RaceQueues/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRaceQueue(int id, RaceQueue raceQueue)
        {
            if (id != raceQueue.Id)
            {
                return BadRequest();
            }

            _context.Entry(raceQueue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaceQueueExists(id))
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

        // POST: api/RaceQueues
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<RaceQueue>> PostRaceQueue(RaceQueue raceQueue)
        {
            _context.RaceQueue.Add(raceQueue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRaceQueue", new { id = raceQueue.Id }, raceQueue);
        }

        // DELETE: api/RaceQueues/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RaceQueue>> DeleteRaceQueue(int id)
        {
            var raceQueue = await _context.RaceQueue.FindAsync(id);
            if (raceQueue == null)
            {
                return NotFound();
            }

            _context.RaceQueue.Remove(raceQueue);
            await _context.SaveChangesAsync();

            return raceQueue;
        }

        private bool RaceQueueExists(int id)
        {
            return _context.RaceQueue.Any(e => e.Id == id);
        }
    }
}
