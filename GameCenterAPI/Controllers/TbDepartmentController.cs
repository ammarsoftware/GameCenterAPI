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
    public class TbDepartmentController : ControllerBase
    {
        private readonly GamecenterContext _context;

        public TbDepartmentController(GamecenterContext context)
        {
            _context = context;
        }

        // GET: api/TbDepartment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbDepartment>>> GetTbDepartments()
        {
            return await _context.TbDepartments.ToListAsync();
        }

        // GET: api/TbDepartment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbDepartment>> GetTbDepartment(int id)
        {
            var tbDepartment = await _context.TbDepartments.FindAsync(id);

            if (tbDepartment == null)
            {
                return NotFound();
            }

            return tbDepartment;
        }

        // PUT: api/TbDepartment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbDepartment(int id, TbDepartment tbDepartment)
        {
            if (id != tbDepartment.DeId)
            {
                return BadRequest();
            }

            _context.Entry(tbDepartment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbDepartmentExists(id))
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

        // POST: api/TbDepartment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbDepartment>> PostTbDepartment(TbDepartment tbDepartment)
        {
            _context.TbDepartments.Add(tbDepartment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbDepartment", new { id = tbDepartment.DeId }, tbDepartment);
        }

        // DELETE: api/TbDepartment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbDepartment(int id)
        {
            var tbDepartment = await _context.TbDepartments.FindAsync(id);
            if (tbDepartment == null)
            {
                return NotFound();
            }

            _context.TbDepartments.Remove(tbDepartment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbDepartmentExists(int id)
        {
            return _context.TbDepartments.Any(e => e.DeId == id);
        }
    }
}
