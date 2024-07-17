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
    public class TbTableController : ControllerBase
    {
        private readonly GamecenterContext _context;

        public TbTableController(GamecenterContext context)
        {
            _context = context;
        }

        // GET: api/TbTable
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbTable>>> GetTbTables()
        {
            return await _context.TbTables.ToListAsync();
        }

        // GET: api/TbTable/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbTable>> GetTbTable(int id)
        {
            var tbTable = await _context.TbTables.FindAsync(id);

            if (tbTable == null)
            {
                return NotFound();
            }

            return tbTable;
        }

        // PUT: api/TbTable/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbTable(int id, TbTable tbTable)
        {
            if (id != tbTable.TId)
            {
                return BadRequest();
            }

            _context.Entry(tbTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbTableExists(id))
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

        // POST: api/TbTable
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbTable>> PostTbTable(TbTable tbTable)
        {
            _context.TbTables.Add(tbTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbTable", new { id = tbTable.TId }, tbTable);
        }

        // DELETE: api/TbTable/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbTable(int id)
        {
            var tbTable = await _context.TbTables.FindAsync(id);
            if (tbTable == null)
            {
                return NotFound();
            }

            _context.TbTables.Remove(tbTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbTableExists(int id)
        {
            return _context.TbTables.Any(e => e.TId == id);
        }
    }
}
