using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parcial02_BM101219_JP100320.Models;

namespace Parcial02_BM101219_JP100320.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class Elecciones2019Controller : ControllerBase
    {
        private readonly Bm101219Jp100320Context _context;

        public Elecciones2019Controller(Bm101219Jp100320Context context)
        {
            _context = context;
        }

        // GET: api/Elecciones2019
        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<Elecciones2019>>> GetElecciones2019s()
        {
          if (_context.Elecciones2019s == null)
          {
              return NotFound();
          }
            return await _context.Elecciones2019s.ToListAsync();
        }
        // GET: api/Elecciones2019
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VCandidato>>> GetElecciones2019View()
        {
            if (_context.VCandidatos == null)
            {
                return NotFound();
            }
            return await _context.VCandidatos.FromSqlRaw("Select * from V_Candidato order by porcentaje desc").ToListAsync();
        }

        // GET: api/Elecciones2019/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Elecciones2019>> GetElecciones2019(int id)
        {
          if (_context.Elecciones2019s == null)
          {
              return NotFound();
          }
            var elecciones2019 = await _context.Elecciones2019s.FindAsync(id);

            if (elecciones2019 == null)
            {
                return NotFound();
            }

            return elecciones2019;
        }

        // PUT: api/Elecciones2019/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElecciones2019(int id, Elecciones2019 elecciones2019)
        {
            if (id != elecciones2019.Id)
            {
                return BadRequest();
            }

            _context.Entry(elecciones2019).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Elecciones2019Exists(id))
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

        // POST: api/Elecciones2019
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Elecciones2019>> PostElecciones2019(Elecciones2019 elecciones2019)
        {
          if (_context.Elecciones2019s == null)
          {
              return Problem("Entity set 'Bm101219Jp100320Context.Elecciones2019s'  is null.");
          }
            _context.Elecciones2019s.Add(elecciones2019);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElecciones2019", new { id = elecciones2019.Id }, elecciones2019);
        }

        // DELETE: api/Elecciones2019/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElecciones2019(int id)
        {
            if (_context.Elecciones2019s == null)
            {
                return NotFound();
            }
            var elecciones2019 = await _context.Elecciones2019s.FindAsync(id);
            if (elecciones2019 == null)
            {
                return NotFound();
            }

            _context.Elecciones2019s.Remove(elecciones2019);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Elecciones2019Exists(int id)
        {
            return (_context.Elecciones2019s?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
