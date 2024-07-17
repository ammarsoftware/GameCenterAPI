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
    public class TbMenuController : ControllerBase
    {
        private readonly GamecenterContext _context;

        public TbMenuController(GamecenterContext context)
        {
            _context = context;
        }

        // GET: api/TbMenu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbMenu>>> GetTbMenus()
        {
            return await _context.TbMenus.ToListAsync();
        }

        // GET: api/TbMenu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbMenu>> GetTbMenu(int id)
        {
            var tbMenu = await _context.TbMenus.FindAsync(id);

            if (tbMenu == null)
            {
                return NotFound();
            }

            return tbMenu;
        }

        // PUT: api/TbMenu/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbMenu(int id, TbMenu tbMenu)
        {
            if (id != tbMenu.MId)
            {
                return BadRequest();
            }

            _context.Entry(tbMenu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbMenuExists(id))
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

        // POST: api/TbMenu
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbMenu>> PostTbMenu(TbMenu tbMenu)
        {
            _context.TbMenus.Add(tbMenu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbMenu", new { id = tbMenu.MId }, tbMenu);
        }

        // DELETE: api/TbMenu/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbMenu(int id)
        {
            var tbMenu = await _context.TbMenus.FindAsync(id);
            if (tbMenu == null)
            {
                return NotFound();
            }

            _context.TbMenus.Remove(tbMenu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbMenuExists(int id)
        {
            return _context.TbMenus.Any(e => e.MId == id);
        }
    }
}
