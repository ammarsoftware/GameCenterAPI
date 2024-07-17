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
    public class TbStoreController : ControllerBase
    {
        private readonly GamecenterContext _context;

        public TbStoreController(GamecenterContext context)
        {
            _context = context;
        }

        // GET: api/TbStore
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbStore>>> GetTbStores()
        {
            return await _context.TbStores.ToListAsync();
        }

        // GET: api/TbStore/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbStore>> GetTbStore(int id)
        {
            var tbStore = await _context.TbStores.FindAsync(id);

            if (tbStore == null)
            {
                return NotFound();
            }

            return tbStore;
        }

        // PUT: api/TbStore/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbStore(int id, TbStore tbStore)
        {
            if (id != tbStore.StoreId)
            {
                return BadRequest();
            }

            _context.Entry(tbStore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbStoreExists(id))
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

        // POST: api/TbStore
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbStore>> PostTbStore(TbStore tbStore)
        {
            _context.TbStores.Add(tbStore);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbStore", new { id = tbStore.StoreId }, tbStore);
        }

        // DELETE: api/TbStore/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbStore(int id)
        {
            var tbStore = await _context.TbStores.FindAsync(id);
            if (tbStore == null)
            {
                return NotFound();
            }

            _context.TbStores.Remove(tbStore);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbStoreExists(int id)
        {
            return _context.TbStores.Any(e => e.StoreId == id);
        }
    }
}
