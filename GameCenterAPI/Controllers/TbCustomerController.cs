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
    public class TbCustomerController : ControllerBase
    {
        private readonly GamecenterContext _context;

        public TbCustomerController(GamecenterContext context)
        {
            _context = context;
        }

        // GET: api/TbCustomer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbCustomer>>> GetTbCustomers()
        {
            return await _context.TbCustomers.ToListAsync();
        }

        // GET: api/TbCustomer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbCustomer>> GetTbCustomer(int id)
        {
            var tbCustomer = await _context.TbCustomers.FindAsync(id);

            if (tbCustomer == null)
            {
                return NotFound();
            }

            return tbCustomer;
        }

        // PUT: api/TbCustomer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbCustomer(int id, TbCustomer tbCustomer)
        {
            if (id != tbCustomer.CuId)
            {
                return BadRequest();
            }

            _context.Entry(tbCustomer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbCustomerExists(id))
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

        // POST: api/TbCustomer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbCustomer>> PostTbCustomer(TbCustomer tbCustomer)
        {
            _context.TbCustomers.Add(tbCustomer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbCustomer", new { id = tbCustomer.CuId }, tbCustomer);
        }

        // DELETE: api/TbCustomer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbCustomer(int id)
        {
            var tbCustomer = await _context.TbCustomers.FindAsync(id);
            if (tbCustomer == null)
            {
                return NotFound();
            }

            _context.TbCustomers.Remove(tbCustomer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbCustomerExists(int id)
        {
            return _context.TbCustomers.Any(e => e.CuId == id);
        }
    }
}
