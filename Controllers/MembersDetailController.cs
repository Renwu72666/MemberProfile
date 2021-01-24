using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MemberProfile.Models;

namespace MemberProfile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersDetailController : ControllerBase
    {
        private readonly MembersDetailContext _context;

        public MembersDetailController(MembersDetailContext context)
        {
            _context = context;
        }

        // GET: api/MembersDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Members>>> GetMembersDetails()
        {
            return await _context.MembersDetails.ToListAsync();
        }

        // GET: api/MembersDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Members>> GetMembers(int id)
        {
            var members = await _context.MembersDetails.FindAsync(id);

            if (members == null)
            {
                return NotFound();
            }

            return members;
        }

        // PUT: api/MembersDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMembers(int id, Members members)
        {
            if (id != members.MemberDetailId)
            {
                return BadRequest();
            }

            _context.Entry(members).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembersExists(id))
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

        // POST: api/MembersDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Members>> PostMembers(Members members)
        {
            _context.MembersDetails.Add(members);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMembers", new { id = members.MemberDetailId }, members);
        }

        // DELETE: api/MembersDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMembers(int id)
        {
            var members = await _context.MembersDetails.FindAsync(id);
            if (members == null)
            {
                return NotFound();
            }

            _context.MembersDetails.Remove(members);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MembersExists(int id)
        {
            return _context.MembersDetails.Any(e => e.MemberDetailId == id);
        }
    }
}
