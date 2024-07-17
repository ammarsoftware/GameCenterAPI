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
    public class TbItemController : ControllerBase
    {
        private readonly GamecenterContext _context;

        public TbItemController(GamecenterContext context)
        {
            _context = context;
        }

        // GET: api/TbItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbItem>>> GetTbItems()
        {
            return await _context.TbItems.ToListAsync();
        }

        // GET: api/TbItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbItem>> GetTbItem(int id)
        {
            var tbItem = await _context.TbItems.FindAsync(id);

            if (tbItem == null)
            {
                return NotFound();
            }

            return tbItem;
        }

        // PUT: api/TbItem/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbItem(int id, TbItem tbItem)
        {
            if (id != tbItem.IId)
            {
                return BadRequest();
            }

            _context.Entry(tbItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbItemExists(id))
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

        // POST: api/TbItem
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbItem>> PostTbItem(TbItem tbItem)
        {
            _context.TbItems.Add(tbItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbItem", new { id = tbItem.IId }, tbItem);
        }

        // DELETE: api/TbItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbItem(int id)
        {
            var tbItem = await _context.TbItems.FindAsync(id);
            if (tbItem == null)
            {
                return NotFound();
            }

            _context.TbItems.Remove(tbItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbItemExists(int id)
        {
            return _context.TbItems.Any(e => e.IId == id);
        }
    }
}
