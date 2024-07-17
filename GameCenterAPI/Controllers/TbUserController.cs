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
    public class TbUserController : ControllerBase
    {
        private readonly GamecenterContext _context;

        public TbUserController(GamecenterContext context)
        {
            _context = context;
        }

        // GET: api/TbUser
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbUser>>> GetTbUsers()
        {
            return await _context.TbUsers.ToListAsync();
        }

        // GET: api/TbUser/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbUser>> GetTbUser(int id)
        {
            var tbUser = await _context.TbUsers.FindAsync(id);

            if (tbUser == null)
            {
                return NotFound();
            }

            return tbUser;
        }

        // PUT: api/TbUser/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbUser(int id, TbUser tbUser)
        {
            if (id != tbUser.UId)
            {
                return BadRequest();
            }

            _context.Entry(tbUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbUserExists(id))
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

        // POST: api/TbUser
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbUser>> PostTbUser(TbUser tbUser)
        {
            _context.TbUsers.Add(tbUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbUser", new { id = tbUser.UId }, tbUser);
        }

        // DELETE: api/TbUser/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbUser(int id)
        {
            var tbUser = await _context.TbUsers.FindAsync(id);
            if (tbUser == null)
            {
                return NotFound();
            }

            _context.TbUsers.Remove(tbUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbUserExists(int id)
        {
            return _context.TbUsers.Any(e => e.UId == id);
        }
    }
}
