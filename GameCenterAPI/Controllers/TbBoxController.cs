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
    public class TbBoxController : ControllerBase
    {
        private readonly GamecenterContext _context;

        public TbBoxController(GamecenterContext context)
        {
            _context = context;
        }

        // GET: api/TbBox
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbBox>>> GetTbBoxes()
        {
            return await _context.TbBoxes.ToListAsync();
        }

        // GET: api/TbBox/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbBox>> GetTbBox(int id)
        {
            var tbBox = await _context.TbBoxes.FindAsync(id);

            if (tbBox == null)
            {
                return NotFound();
            }

            return tbBox;
        }

        // PUT: api/TbBox/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbBox(int id, TbBox tbBox)
        {
            if (id != tbBox.BoxId)
            {
                return BadRequest();
            }

            _context.Entry(tbBox).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbBoxExists(id))
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

        // POST: api/TbBox
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbBox>> PostTbBox(TbBox tbBox)
        {
            _context.TbBoxes.Add(tbBox);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbBox", new { id = tbBox.BoxId }, tbBox);
        }

        // DELETE: api/TbBox/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbBox(int id)
        {
            var tbBox = await _context.TbBoxes.FindAsync(id);
            if (tbBox == null)
            {
                return NotFound();
            }

            _context.TbBoxes.Remove(tbBox);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbBoxExists(int id)
        {
            return _context.TbBoxes.Any(e => e.BoxId == id);
        }
    }
}
