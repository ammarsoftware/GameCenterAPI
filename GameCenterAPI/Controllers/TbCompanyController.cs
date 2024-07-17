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
    public class TbCompanyController : ControllerBase
    {
        private readonly GamecenterContext _context;

        public TbCompanyController(GamecenterContext context)
        {
            _context = context;
        }

        // GET: api/TbCompany
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbCompany>>> GetTbCompanies()
        {
            return await _context.TbCompanies.ToListAsync();
        }

        // GET: api/TbCompany/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbCompany>> GetTbCompany(int id)
        {
            var tbCompany = await _context.TbCompanies.FindAsync(id);

            if (tbCompany == null)
            {
                return NotFound();
            }

            return tbCompany;
        }

        // PUT: api/TbCompany/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbCompany(int id, TbCompany tbCompany)
        {
            if (id != tbCompany.CId)
            {
                return BadRequest();
            }

            _context.Entry(tbCompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbCompanyExists(id))
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

        // POST: api/TbCompany
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbCompany>> PostTbCompany(TbCompany tbCompany)
        {
            _context.TbCompanies.Add(tbCompany);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbCompany", new { id = tbCompany.CId }, tbCompany);
        }

        // DELETE: api/TbCompany/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbCompany(int id)
        {
            var tbCompany = await _context.TbCompanies.FindAsync(id);
            if (tbCompany == null)
            {
                return NotFound();
            }

            _context.TbCompanies.Remove(tbCompany);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbCompanyExists(int id)
        {
            return _context.TbCompanies.Any(e => e.CId == id);
        }
    }
}
