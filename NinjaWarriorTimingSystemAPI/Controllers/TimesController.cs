﻿using System;
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
    public class TimesController : ControllerBase
    {
        private readonly TimingSystemDbContext _context;

        public TimesController(TimingSystemDbContext context)
        {
            _context = context;
        }

        // endpoint to get all the times
        // GET: api/Times
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Time>>> GetTimes()
        {
            return await _context.Times.ToListAsync();
        }

        // endpoint to get all the times and users for a speed wall
        [HttpGet]
        [Route("speedwall/{id}")]
        public async Task<ActionResult<IEnumerable<Time>>> GetTimesOfSpeedWall(int id)
        {

            var query = from time in _context.Times
                        join user in _context.Users
                        on time.UserId equals user.Id
                        where time.SpeedWallId == id
                        orderby time.DateTime
                        select new
                        {
                            time = time.DateTime.ToString("mm:ss:ff"),
                            user.FirstName,
                            user.LastName
                        };
            return Ok(await query.ToListAsync());
        }

        [HttpGet]
        [Route("speedwall/{id}/{username}")]
        public async Task<ActionResult<IEnumerable<Time>>> GetTimesOfSpeedWallForUser(int id, string username)
        {
            var query = from time in _context.Times
                        join user in _context.Users
                        on time.UserId equals user.Id
                        where time.SpeedWallId == id 
                        && user.Username == username
                        orderby time.DateTime
                        select new
                        {
                            time = time.DateTime.ToString("mm:ss:ff"),
                            date = time.DateTime.ToString("yyyy-MM-dd")
                        };
            return Ok(await query.ToListAsync());
        }

        // GET: api/Times/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Time>> GetTime(int id)
        {
            var time = await _context.Times.FindAsync(id);

            if (time == null)
            {
                return NotFound();
            }

            return time;
        }

        // PUT: api/Times/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTime(int id, Time time)
        {
            if (id != time.Id)
            {
                return BadRequest();
            }

            _context.Entry(time).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeExists(id))
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

        // POST: api/Times
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Time>> PostTime(Time time)
        {
            _context.Times.Add(time);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTime", new { id = time.Id }, time);
        }

        // DELETE: api/Times/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Time>> DeleteTime(int id)
        {
            var time = await _context.Times.FindAsync(id);
            if (time == null)
            {
                return NotFound();
            }

            _context.Times.Remove(time);
            await _context.SaveChangesAsync();

            return time;
        }

        private bool TimeExists(int id)
        {
            return _context.Times.Any(e => e.Id == id);
        }

        // endpoint to start a timer
        // /api/times/start/
        [HttpGet]
        [Route("start/")]
        public ActionResult<TimeSpan> StartTimer()
        {
            Timer.Start();
            // Ok() return status code 200
            return Ok();
        }

        // endpoint to stop the timer
        // /api/times/start/
        [HttpGet]
        [Route("stop/")]
        public ActionResult<TimeSpan>EndTimer()
        {
            TimeSpan ts = Timer.Stop();
            return Ok(ts);
        }
    }
}
