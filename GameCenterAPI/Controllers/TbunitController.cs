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
    public class TbunitController : ControllerBase
    {
        private readonly GamecenterContext _context;

        public TbunitController(GamecenterContext context)
        {
            _context = context;
        }

        // GET: api/Tbunit
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbunit>>> GetTbunits()
        {
            return await _context.Tbunits.ToListAsync();
        }

        // GET: api/Tbunit/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tbunit>> GetTbunit(int id)
        {
            var tbunit = await _context.Tbunits.FindAsync(id);

            if (tbunit == null)
            {
                return NotFound();
            }

            return tbunit;
        }

        // PUT: api/Tbunit/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbunit(int id, Tbunit tbunit)
        {
            if (id != tbunit.UnitId)
            {
                return BadRequest();
            }

            _context.Entry(tbunit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbunitExists(id))
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

        // POST: api/Tbunit
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tbunit>> PostTbunit(Tbunit tbunit)
        {
            _context.Tbunits.Add(tbunit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbunit", new { id = tbunit.UnitId }, tbunit);
        }

        // DELETE: api/Tbunit/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbunit(int id)
        {
            var tbunit = await _context.Tbunits.FindAsync(id);
            if (tbunit == null)
            {
                return NotFound();
            }

            _context.Tbunits.Remove(tbunit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbunitExists(int id)
        {
            return _context.Tbunits.Any(e => e.UnitId == id);
        }
    }
}
