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
    public class TbPrivilegeController : ControllerBase
    {
        private readonly GamecenterContext _context;

        public TbPrivilegeController(GamecenterContext context)
        {
            _context = context;
        }

        // GET: api/TbPrivilege
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbPrivilege>>> GetTbPrivileges()
        {
            return await _context.TbPrivileges.ToListAsync();
        }

        // GET: api/TbPrivilege/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbPrivilege>> GetTbPrivilege(int id)
        {
            var tbPrivilege = await _context.TbPrivileges.FindAsync(id);

            if (tbPrivilege == null)
            {
                return NotFound();
            }

            return tbPrivilege;
        }

        // PUT: api/TbPrivilege/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbPrivilege(int id, TbPrivilege tbPrivilege)
        {
            if (id != tbPrivilege.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbPrivilege).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbPrivilegeExists(id))
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

        // POST: api/TbPrivilege
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbPrivilege>> PostTbPrivilege(TbPrivilege tbPrivilege)
        {
            _context.TbPrivileges.Add(tbPrivilege);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbPrivilege", new { id = tbPrivilege.Id }, tbPrivilege);
        }

        // DELETE: api/TbPrivilege/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbPrivilege(int id)
        {
            var tbPrivilege = await _context.TbPrivileges.FindAsync(id);
            if (tbPrivilege == null)
            {
                return NotFound();
            }

            _context.TbPrivileges.Remove(tbPrivilege);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbPrivilegeExists(int id)
        {
            return _context.TbPrivileges.Any(e => e.Id == id);
        }
    }
}
