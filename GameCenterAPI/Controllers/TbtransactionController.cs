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
    public class TbtransactionController : ControllerBase
    {
        private readonly GamecenterContext _context;

        public TbtransactionController(GamecenterContext context)
        {
            _context = context;
        }

        // GET: api/Tbtransaction
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbtransaction>>> GetTbtransactions()
        {
            return await _context.Tbtransactions.ToListAsync();
        }

        // GET: api/Tbtransaction/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tbtransaction>> GetTbtransaction(int id)
        {
            var tbtransaction = await _context.Tbtransactions.FindAsync(id);

            if (tbtransaction == null)
            {
                return NotFound();
            }

            return tbtransaction;
        }

        // PUT: api/Tbtransaction/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbtransaction(int id, Tbtransaction tbtransaction)
        {
            if (id != tbtransaction.TransactionId)
            {
                return BadRequest();
            }

            _context.Entry(tbtransaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbtransactionExists(id))
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

        // POST: api/Tbtransaction
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tbtransaction>> PostTbtransaction(Tbtransaction tbtransaction)
        {
            _context.Tbtransactions.Add(tbtransaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbtransaction", new { id = tbtransaction.TransactionId }, tbtransaction);
        }

        // DELETE: api/Tbtransaction/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbtransaction(int id)
        {
            var tbtransaction = await _context.Tbtransactions.FindAsync(id);
            if (tbtransaction == null)
            {
                return NotFound();
            }

            _context.Tbtransactions.Remove(tbtransaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbtransactionExists(int id)
        {
            return _context.Tbtransactions.Any(e => e.TransactionId == id);
        }
    }
}
