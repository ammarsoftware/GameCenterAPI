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
    public class TbEmployeeController : ControllerBase
    {
        private readonly GamecenterContext _context;

        public TbEmployeeController(GamecenterContext context)
        {
            _context = context;
        }

        // GET: api/TbEmployee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbEmployee>>> GetTbEmployees()
        {
            return await _context.TbEmployees.ToListAsync();
        }

        // GET: api/TbEmployee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbEmployee>> GetTbEmployee(int id)
        {
            var tbEmployee = await _context.TbEmployees.FindAsync(id);

            if (tbEmployee == null)
            {
                return NotFound();
            }

            return tbEmployee;
        }

        // PUT: api/TbEmployee/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbEmployee(int id, TbEmployee tbEmployee)
        {
            if (id != tbEmployee.EmpId)
            {
                return BadRequest();
            }

            _context.Entry(tbEmployee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbEmployeeExists(id))
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

        // POST: api/TbEmployee
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbEmployee>> PostTbEmployee(TbEmployee tbEmployee)
        {
            _context.TbEmployees.Add(tbEmployee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbEmployee", new { id = tbEmployee.EmpId }, tbEmployee);
        }

        // DELETE: api/TbEmployee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbEmployee(int id)
        {
            var tbEmployee = await _context.TbEmployees.FindAsync(id);
            if (tbEmployee == null)
            {
                return NotFound();
            }

            _context.TbEmployees.Remove(tbEmployee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbEmployeeExists(int id)
        {
            return _context.TbEmployees.Any(e => e.EmpId == id);
        }
    }
}
