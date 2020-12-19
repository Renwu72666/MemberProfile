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
        public async Task<ActionResult<IEnumerable<MembersDetail>>> GetMembersDetails()
        {
            return await _context.MembersDetails.ToListAsync();
        }

        // GET: api/MembersDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MembersDetail>> GetMembersDetail(int id)
        {
            var membersDetail = await _context.MembersDetails.FindAsync(id);

            if (membersDetail == null)
            {
                return NotFound();
            }

            return membersDetail;
        }

        // PUT: api/MembersDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMembersDetail(int id, MembersDetail membersDetail)
        {
            if (id != membersDetail.MemberDetailId)
            {
                return BadRequest();
            }

            _context.Entry(membersDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembersDetailExists(id))
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
        public async Task<ActionResult<MembersDetail>> PostMembersDetail(MembersDetail membersDetail)
        {
            _context.MembersDetails.Add(membersDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMembersDetail", new { id = membersDetail.MemberDetailId }, membersDetail);
        }

        // DELETE: api/MembersDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMembersDetail(int id)
        {
            var membersDetail = await _context.MembersDetails.FindAsync(id);
            if (membersDetail == null)
            {
                return NotFound();
            }

            _context.MembersDetails.Remove(membersDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MembersDetailExists(int id)
        {
            return _context.MembersDetails.Any(e => e.MemberDetailId == id);
        }
    }
}
