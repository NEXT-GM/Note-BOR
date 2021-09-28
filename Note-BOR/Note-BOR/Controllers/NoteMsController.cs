using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Note_BOR.Contexts;
using Note_BOR.Models;

namespace Note_BOR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteMsController : ControllerBase
    {
        private readonly NoteContext _context;

        public NoteMsController(NoteContext context)
        {
            _context = context;
        }

        // GET: api/NoteMs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NoteM>>> GetNoteM()
        {
            return await _context.NoteM.ToListAsync();
        }

        // GET: api/NoteMs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NoteM>> GetNoteM(int id)
        {
            var noteM = await _context.NoteM.FindAsync(id);

            if (noteM == null)
            {
                return NotFound();
            }

            return noteM;
        }

        // PUT: api/NoteMs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNoteM(int id, NoteM noteM)
        {
            if (id != noteM.Id)
            {
                return BadRequest();
            }

            _context.Entry(noteM).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoteMExists(id))
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

        // POST: api/NoteMs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NoteM>> PostNoteM(NoteM noteM)
        {
            _context.NoteM.Add(noteM);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNoteM", new { id = noteM.Id }, noteM);
        }

        // DELETE: api/NoteMs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NoteM>> DeleteNoteM(int id)
        {
            var noteM = await _context.NoteM.FindAsync(id);
            if (noteM == null)
            {
                return NotFound();
            }

            _context.NoteM.Remove(noteM);
            await _context.SaveChangesAsync();

            return noteM;
        }

        private bool NoteMExists(int id)
        {
            return _context.NoteM.Any(e => e.Id == id);
        }
    }
}
