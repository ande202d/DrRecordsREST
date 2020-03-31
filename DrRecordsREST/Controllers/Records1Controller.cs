using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClassLibrary;
using DrRecordsREST.Models;

namespace DrRecordsREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Records1Controller : ControllerBase
    {
        private readonly RecordsContext _context;

        public Records1Controller(RecordsContext context)
        {
            _context = context;
        }

        // GET: api/Records1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Record>>> Getlist()
        {
            return await _context.list.ToListAsync();
        }

        // GET: api/Records1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Record>> GetRecord(int id)
        {
            var record = await _context.list.FindAsync(id);

            if (record == null)
            {
                return NotFound();
            }

            return record;
        }

        // PUT: api/Records1/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecord(int id, Record record)
        {
            if (id != record.Id)
            {
                return BadRequest();
            }

            _context.Entry(record).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecordExists(id))
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

        // POST: api/Records1
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Record>> PostRecord(Record record)
        {
            _context.list.Add(record);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecord", new { id = record.Id }, record);
        }

        // DELETE: api/Records1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Record>> DeleteRecord(int id)
        {
            var record = await _context.list.FindAsync(id);
            if (record == null)
            {
                return NotFound();
            }

            _context.list.Remove(record);
            await _context.SaveChangesAsync();

            return record;
        }

        private bool RecordExists(int id)
        {
            return _context.list.Any(e => e.Id == id);
        }
    }
}
