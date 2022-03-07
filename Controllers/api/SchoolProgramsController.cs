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
    [EnableCors]
    public class SchoolProgramsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SchoolProgramsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SchoolPrograms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchoolProgram>>> GetSchoolPrograms()
        {
            return await _context.SchoolPrograms.ToListAsync();
        }

        // GET: api/SchoolPrograms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolProgram>> GetSchoolProgram(string id)
        {
            var schoolProgram = await _context.SchoolPrograms.FindAsync(id);

            if (schoolProgram == null)
            {
                return NotFound();
            }

            return schoolProgram;
        }

        // PUT: api/SchoolPrograms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchoolProgram(string id, SchoolProgram schoolProgram)
        {
            if (id != schoolProgram.Id)
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
            _context.SchoolPrograms.Add(schoolProgram);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SchoolProgramExists(schoolProgram.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSchoolProgram", new { id = schoolProgram.Id }, schoolProgram);
        }

        // DELETE: api/SchoolPrograms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchoolProgram(string id)
        {
            var schoolProgram = await _context.SchoolPrograms.FindAsync(id);
            if (schoolProgram == null)
            {
                return NotFound();
            }

            _context.SchoolPrograms.Remove(schoolProgram);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SchoolProgramExists(string id)
        {
            return _context.SchoolPrograms.Any(e => e.Id == id);
        }
    }
}
