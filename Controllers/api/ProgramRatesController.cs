#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rater_api.Data;
using rater_api.Models;

namespace rater_api.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramRatesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProgramRatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProgramRates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgramRate>>> GetProgramRate()
        {
            return await _context.ProgramRate.ToListAsync();
        }

        // GET: api/ProgramRates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProgramRate>> GetProgramRate(int id)
        {
            var programRate = await _context.ProgramRate.FindAsync(id);

            if (programRate == null)
            {
                return NotFound();
            }

            return programRate;
        }

        // PUT: api/ProgramRates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProgramRate(int id, ProgramRate programRate)
        {
            if (id != programRate.ProgramRateId)
            {
                return BadRequest();
            }

            _context.Entry(programRate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramRateExists(id))
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

        // POST: api/ProgramRates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProgramRate>> PostProgramRate(ProgramRate programRate)
        {
            programRate.Created_At = DateTime.Now;
            _context.ProgramRate.Add(programRate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProgramRate", new { id = programRate.ProgramRateId }, programRate);
        }

        // DELETE: api/ProgramRates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgramRate(int id)
        {
            var programRate = await _context.ProgramRate.FindAsync(id);
            if (programRate == null)
            {
                return NotFound();
            }

            _context.ProgramRate.Remove(programRate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProgramRateExists(int id)
        {
            return _context.ProgramRate.Any(e => e.ProgramRateId == id);
        }
    }
}
