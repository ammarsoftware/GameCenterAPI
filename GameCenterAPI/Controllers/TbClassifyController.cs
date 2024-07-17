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
    public class TbClassifyController : ControllerBase
    {
        private readonly GamecenterContext _context;

        public TbClassifyController(GamecenterContext context)
        {
            _context = context;
        }

        // GET: api/TbClassify
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbClassify>>> GetTbClassifies()
        {
            return await _context.TbClassifies.ToListAsync();
        }

        // GET: api/TbClassify/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbClassify>> GetTbClassify(int id)
        {
            var tbClassify = await _context.TbClassifies.FindAsync(id);

            if (tbClassify == null)
            {
                return NotFound();
            }

            return tbClassify;
        }

        // PUT: api/TbClassify/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbClassify(int id, TbClassify tbClassify)
        {
            if (id != tbClassify.ClId)
            {
                return BadRequest();
            }

            _context.Entry(tbClassify).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbClassifyExists(id))
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

        // POST: api/TbClassify
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbClassify>> PostTbClassify(TbClassify tbClassify)
        {
            _context.TbClassifies.Add(tbClassify);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbClassify", new { id = tbClassify.ClId }, tbClassify);
        }

        // DELETE: api/TbClassify/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbClassify(int id)
        {
            var tbClassify = await _context.TbClassifies.FindAsync(id);
            if (tbClassify == null)
            {
                return NotFound();
            }

            _context.TbClassifies.Remove(tbClassify);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbClassifyExists(int id)
        {
            return _context.TbClassifies.Any(e => e.ClId == id);
        }
    }
}
