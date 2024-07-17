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
    public class TbRoleController : ControllerBase
    {
        private readonly GamecenterContext _context;

        public TbRoleController(GamecenterContext context)
        {
            _context = context;
        }

        // GET: api/TbRole
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbRole>>> GetTbRoles()
        {
            return await _context.TbRoles.ToListAsync();
        }

        // GET: api/TbRole/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbRole>> GetTbRole(int id)
        {
            var tbRole = await _context.TbRoles.FindAsync(id);

            if (tbRole == null)
            {
                return NotFound();
            }

            return tbRole;
        }

        // PUT: api/TbRole/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbRole(int id, TbRole tbRole)
        {
            if (id != tbRole.RoId)
            {
                return BadRequest();
            }

            _context.Entry(tbRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbRoleExists(id))
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

        // POST: api/TbRole
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbRole>> PostTbRole(TbRole tbRole)
        {
            _context.TbRoles.Add(tbRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbRole", new { id = tbRole.RoId }, tbRole);
        }

        // DELETE: api/TbRole/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbRole(int id)
        {
            var tbRole = await _context.TbRoles.FindAsync(id);
            if (tbRole == null)
            {
                return NotFound();
            }

            _context.TbRoles.Remove(tbRole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbRoleExists(int id)
        {
            return _context.TbRoles.Any(e => e.RoId == id);
        }
    }
}
