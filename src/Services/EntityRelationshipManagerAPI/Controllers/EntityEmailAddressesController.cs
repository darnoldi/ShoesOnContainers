using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Arnoldi.Services.EntityRelationshipManagerAPI.Data;
using Arnoldi.Services.EntityRelationshipManagerAPI.Domain;

namespace EntityRelationshipManagerAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/EntityEmailAddresses")]
    public class EntityEmailAddressesController : Controller
    {
        private readonly EntityRelationshipDbContext _context;

        public EntityEmailAddressesController(EntityRelationshipDbContext context)
        {
            _context = context;
        }

        // GET: api/EntityEmailAddresses
        [HttpGet]
        public IEnumerable<EntityEmailAddress> GetEntityEmailAddress()
        {
            return _context.EntityEmailAddress;
        }

        // GET: api/EntityEmailAddresses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntityEmailAddress([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entityEmailAddress = await _context.EntityEmailAddress.SingleOrDefaultAsync(m => m.Id == id);

            if (entityEmailAddress == null)
            {
                return NotFound();
            }

            return Ok(entityEmailAddress);
        }

        // PUT: api/EntityEmailAddresses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntityEmailAddress([FromRoute] int id, [FromBody] EntityEmailAddress entityEmailAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entityEmailAddress.Id)
            {
                return BadRequest();
            }

            _context.Entry(entityEmailAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityEmailAddressExists(id))
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

        // POST: api/EntityEmailAddresses
        [HttpPost]
        public async Task<IActionResult> PostEntityEmailAddress([FromBody] EntityEmailAddress entityEmailAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EntityEmailAddress.Add(entityEmailAddress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntityEmailAddress", new { id = entityEmailAddress.Id }, entityEmailAddress);
        }

        // DELETE: api/EntityEmailAddresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntityEmailAddress([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entityEmailAddress = await _context.EntityEmailAddress.SingleOrDefaultAsync(m => m.Id == id);
            if (entityEmailAddress == null)
            {
                return NotFound();
            }

            _context.EntityEmailAddress.Remove(entityEmailAddress);
            await _context.SaveChangesAsync();

            return Ok(entityEmailAddress);
        }

        private bool EntityEmailAddressExists(int id)
        {
            return _context.EntityEmailAddress.Any(e => e.Id == id);
        }
    }
}