using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameCenterAPI.Models;

namespace GameCenterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TbbillController : ControllerBase
    {
        private readonly GamecenterContext _context;

        public TbbillController(GamecenterContext context)
        {
            _context = context;
        }

        // GET: api/Tbbill
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbbill>>> GetTbbills()
        {
            return await _context.Tbbills.ToListAsync();
        }

        // GET: api/Tbbill/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tbbill>> GetTbbill(int id)
        {
            var tbbill = await _context.Tbbills.FindAsync(id);

            if (tbbill == null)
            {
                return NotFound();
            }

            return tbbill;
        }

        // PUT: api/Tbbill/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbbill(int id, Tbbill tbbill)
        {
            if (id != tbbill.BillId)
            {
                return BadRequest();
            }

            _context.Entry(tbbill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbbillExists(id))
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

        // POST: api/Tbbill
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tbbill>> PostTbbill(Tbbill tbbill)
        {
            _context.Tbbills.Add(tbbill);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbbillExists(tbbill.BillId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbbill", new { id = tbbill.BillId }, tbbill);
        }

        // DELETE: api/Tbbill/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbbill(int id)
        {
            var tbbill = await _context.Tbbills.FindAsync(id);
            if (tbbill == null)
            {
                return NotFound();
            }

            _context.Tbbills.Remove(tbbill);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbbillExists(int id)
        {
            return _context.Tbbills.Any(e => e.BillId == id);
        }
    }
}
