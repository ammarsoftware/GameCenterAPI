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
    public class TbbilldetailController : ControllerBase
    {
        private readonly GamecenterContext _context;

        public TbbilldetailController(GamecenterContext context)
        {
            _context = context;
        }

        // GET: api/Tbbilldetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbbilldetail>>> GetTbbilldetails()
        {
            return await _context.Tbbilldetails.ToListAsync();
        }

        // GET: api/Tbbilldetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tbbilldetail>> GetTbbilldetail(int id)
        {
            var tbbilldetail = await _context.Tbbilldetails.FindAsync(id);

            if (tbbilldetail == null)
            {
                return NotFound();
            }

            return tbbilldetail;
        }

        // PUT: api/Tbbilldetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbbilldetail(int id, Tbbilldetail tbbilldetail)
        {
            if (id != tbbilldetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbbilldetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbbilldetailExists(id))
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

        // POST: api/Tbbilldetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tbbilldetail>> PostTbbilldetail(Tbbilldetail tbbilldetail)
        {
            _context.Tbbilldetails.Add(tbbilldetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbbilldetail", new { id = tbbilldetail.Id }, tbbilldetail);
        }

        // DELETE: api/Tbbilldetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbbilldetail(int id)
        {
            var tbbilldetail = await _context.Tbbilldetails.FindAsync(id);
            if (tbbilldetail == null)
            {
                return NotFound();
            }

            _context.Tbbilldetails.Remove(tbbilldetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbbilldetailExists(int id)
        {
            return _context.Tbbilldetails.Any(e => e.Id == id);
        }
    }
}
