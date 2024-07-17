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
    public class TbPrinterController : ControllerBase
    {
        private readonly GamecenterContext _context;

        public TbPrinterController(GamecenterContext context)
        {
            _context = context;
        }

        // GET: api/TbPrinter
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbPrinter>>> GetTbPrinters()
        {
            return await _context.TbPrinters.ToListAsync();
        }

        // GET: api/TbPrinter/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbPrinter>> GetTbPrinter(int id)
        {
            var tbPrinter = await _context.TbPrinters.FindAsync(id);

            if (tbPrinter == null)
            {
                return NotFound();
            }

            return tbPrinter;
        }

        // PUT: api/TbPrinter/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbPrinter(int id, TbPrinter tbPrinter)
        {
            if (id != tbPrinter.PrinterId)
            {
                return BadRequest();
            }

            _context.Entry(tbPrinter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbPrinterExists(id))
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

        // POST: api/TbPrinter
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbPrinter>> PostTbPrinter(TbPrinter tbPrinter)
        {
            _context.TbPrinters.Add(tbPrinter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbPrinter", new { id = tbPrinter.PrinterId }, tbPrinter);
        }

        // DELETE: api/TbPrinter/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbPrinter(int id)
        {
            var tbPrinter = await _context.TbPrinters.FindAsync(id);
            if (tbPrinter == null)
            {
                return NotFound();
            }

            _context.TbPrinters.Remove(tbPrinter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbPrinterExists(int id)
        {
            return _context.TbPrinters.Any(e => e.PrinterId == id);
        }
    }
}
