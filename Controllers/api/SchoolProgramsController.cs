#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rater_api.Data;
using rater_api.Models;

namespace rater_api.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolProgramsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SchoolProgramsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SchoolPrograms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchoolProgram>>> GetSchoolProgram()
        {
            return await _context.SchoolProgram.ToListAsync();
        }

        // GET: api/SchoolPrograms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolProgram>> GetSchoolProgram(int id)
        {
            var schoolProgram = await _context.SchoolProgram.FindAsync(id);

            if (schoolProgram == null)
            {
                return NotFound();
            }

            return schoolProgram;
        }

        // PUT: api/SchoolPrograms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchoolProgram(int id, SchoolProgram schoolProgram)
        {
            if (id != schoolProgram.SchoolProgramId)
            {
                return BadRequest();
            }

            _context.Entry(schoolProgram).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolProgramExists(id))
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

        // POST: api/SchoolPrograms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SchoolProgram>> PostSchoolProgram(SchoolProgram schoolProgram)
        {
            _context.SchoolProgram.Add(schoolProgram);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSchoolProgram", new { id = schoolProgram.SchoolProgramId }, schoolProgram);
        }

        // DELETE: api/SchoolPrograms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchoolProgram(int id)
        {
            var schoolProgram = await _context.SchoolProgram.FindAsync(id);
            if (schoolProgram == null)
            {
                return NotFound();
            }

            _context.SchoolProgram.Remove(schoolProgram);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SchoolProgramExists(int id)
        {
            return _context.SchoolProgram.Any(e => e.SchoolProgramId == id);
        }

        //Get: api/schoolprogrms/:schoolprogramsId/ProgramRates
        [HttpGet("{schoolprogramsId}/programrates")]
        public async Task<ActionResult<IEnumerable<ProgramRate>>> GetProgramRatesBySchoolProgramId(int schoolprogramsId) {
            return await _context.ProgramRate.Where(s => s.SchoolProgramId == schoolprogramsId).ToListAsync();
        }
    }
}
