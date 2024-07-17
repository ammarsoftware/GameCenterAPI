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
    public class TbServiceController : ControllerBase
    {
        private readonly GamecenterContext _context;

        public TbServiceController(GamecenterContext context)
        {
            _context = context;
        }

        // GET: api/TbService
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbService>>> GetTbServices()
        {
            return await _context.TbServices.ToListAsync();
        }

        // GET: api/TbService/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbService>> GetTbService(int id)
        {
            var tbService = await _context.TbServices.FindAsync(id);

            if (tbService == null)
            {
                return NotFound();
            }

            return tbService;
        }

        // PUT: api/TbService/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbService(int id, TbService tbService)
        {
            if (id != tbService.SeId)
            {
                return BadRequest();
            }

            _context.Entry(tbService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbServiceExists(id))
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

        // POST: api/TbService
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbService>> PostTbService(TbService tbService)
        {
            _context.TbServices.Add(tbService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbService", new { id = tbService.SeId }, tbService);
        }

        // DELETE: api/TbService/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbService(int id)
        {
            var tbService = await _context.TbServices.FindAsync(id);
            if (tbService == null)
            {
                return NotFound();
            }

            _context.TbServices.Remove(tbService);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbServiceExists(int id)
        {
            return _context.TbServices.Any(e => e.SeId == id);
        }
    }
}
