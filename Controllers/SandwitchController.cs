using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSandwitch.Model;

namespace WebApiSandwitch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SandwitchController : ControllerBase
    {
        private readonly SandwitchContext _context;

        public SandwitchController(SandwitchContext context)
        {
            _context = context;
        }

        // GET: api/Sandwitch
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sandwitch>>> GetSandswitches()
        {
            return await _context.Sandswitches.ToListAsync();
        }

        // GET: api/Sandwitch/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sandwitch>> GetSandwitch(int id)
        {
            var sandwitch = await _context.Sandswitches.FindAsync(id);

            if (sandwitch == null)
            {
                return NotFound();
            }

            return sandwitch;
        }

        // PUT: api/Sandwitch/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSandwitch(int id, Sandwitch sandwitch)
        {
            if (id != sandwitch.Id)
            {
                return BadRequest();
            }

            _context.Entry(sandwitch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SandwitchExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(sandwitch);
        }

        // POST: api/Sandwitch
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sandwitch>> PostSandwitch(Sandwitch sandwitch)
        {
            _context.Sandswitches.Add(sandwitch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSandwitch", new { id = sandwitch.Id }, sandwitch);
        }

        // DELETE: api/Sandwitch/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSandwitch(int id)
        {
            var sandwitch = await _context.Sandswitches.FindAsync(id);
            if (sandwitch == null)
            {
                return NotFound();
            }

            _context.Sandswitches.Remove(sandwitch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SandwitchExists(int id)
        {
            return _context.Sandswitches.Any(e => e.Id == id);
        }
    }
}
