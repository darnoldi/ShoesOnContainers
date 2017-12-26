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
    [Route("api/EntityAddresses")]
    public class EntityAddressesController : Controller
    {
        private readonly EntityRelationshipDbContext _context;

        public EntityAddressesController(EntityRelationshipDbContext context)
        {
            _context = context;
        }

        // GET: api/EntityAddresses
        [HttpGet]
        public IEnumerable<EntityAddress> GetEntityAddress()
        {
            return _context.EntityAddress;
        }

        // GET: api/EntityAddresses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntityAddress([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entityAddress = await _context.EntityAddress.SingleOrDefaultAsync(m => m.Id == id);

            if (entityAddress == null)
            {
                return NotFound();
            }

            return Ok(entityAddress);
        }

        // GET: api/EntityAddresses/5
        [HttpGet("ForEntityId/{id}")]
        public async Task<IActionResult> GetEntityAddressForId([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entityAddresses = _context.EntityAddress
                .Where(c => c.EntityItemId == id)
                .ToList();
               

            if (entityAddresses == null)
            {
                return NotFound();
            }

            return Ok(entityAddresses);
        }


        // PUT: api/EntityAddresses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntityAddress([FromRoute] int id, [FromBody] EntityAddress entityAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entityAddress.Id)
            {
                return BadRequest();
            }

            _context.Entry(entityAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityAddressExists(id))
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

        // POST: api/EntityAddresses
        [HttpPost]
        public async Task<IActionResult> PostEntityAddress([FromBody] EntityAddress entityAddress)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EntityAddress.Add(entityAddress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntityAddress", new { id = entityAddress.Id }, entityAddress);
        }

        // DELETE: api/EntityAddresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntityAddress([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entityAddress = await _context.EntityAddress.SingleOrDefaultAsync(m => m.Id == id);
            if (entityAddress == null)
            {
                return NotFound();
            }

            _context.EntityAddress.Remove(entityAddress);
            await _context.SaveChangesAsync();

            return Ok(entityAddress);
        }

        private bool EntityAddressExists(int id)
        {
            return _context.EntityAddress.Any(e => e.Id == id);
        }
    }
}