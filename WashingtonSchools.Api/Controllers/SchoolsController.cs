using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WashingtonSchools.Api.Models;

namespace WashingtonSchools.Api.Controllers
{
    public class SchoolsController : ControllerBase
    {
        private readonly WSDbContext _context;

        public SchoolsController(WSDbContext context)
        {
            _context = context;
        }

        // GET: api/Schools
        [HttpGet]
        [EnableQuery()]
        public IEnumerable<School> GetSchools()
        {
            return _context.Schools;
        }

        // GET: api/Schools/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSchool([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var school = await _context.Schools.FindAsync(id);

            if (school == null)
            {
                return NotFound();
            }

            return Ok(school);
        }

        // PUT: api/Schools/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchool([FromRoute] Guid id, [FromBody] School school)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != school.SchoolId)
            {
                return BadRequest();
            }

            _context.Entry(school).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolExists(id))
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

        // POST: api/Schools
        [HttpPost]
        public async Task<IActionResult> PostSchool([FromBody] School school)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Schools.Add(school);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSchool", new { id = school.SchoolId }, school);
        }

        // DELETE: api/Schools/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchool([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var school = await _context.Schools.FindAsync(id);
            if (school == null)
            {
                return NotFound();
            }

            _context.Schools.Remove(school);
            await _context.SaveChangesAsync();

            return Ok(school);
        }

        private bool SchoolExists(Guid id)
        {
            return _context.Schools.Any(e => e.SchoolId == id);
        }
    }
}