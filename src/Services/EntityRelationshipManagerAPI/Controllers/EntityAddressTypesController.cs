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
    [Route("api/EntityAddressTypes")]
    public class EntityAddressTypesController : Controller
    {
        private readonly EntityRelationshipDbContext _context;

        public EntityAddressTypesController(EntityRelationshipDbContext context)
        {
            _context = context;
        }

        // GET: api/EntityAddressTypes
        [HttpGet]
        public IEnumerable<EntityAddressType> GetEntityAddressTypes()
        {
            return _context.EntityAddressTypes;
        }

        // GET: api/EntityAddressTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntityAddressType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entityAddressType = await _context.EntityAddressTypes.SingleOrDefaultAsync(m => m.Id == id);

            if (entityAddressType == null)
            {
                return NotFound();
            }

            return Ok(entityAddressType);
        }

        // PUT: api/EntityAddressTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntityAddressType([FromRoute] int id, [FromBody] EntityAddressType entityAddressType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entityAddressType.Id)
            {
                return BadRequest();
            }

            _context.Entry(entityAddressType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityAddressTypeExists(id))
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

        // POST: api/EntityAddressTypes
        [HttpPost]
        public async Task<IActionResult> PostEntityAddressType([FromBody] EntityAddressType entityAddressType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EntityAddressTypes.Add(entityAddressType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntityAddressType", new { id = entityAddressType.Id }, entityAddressType);
        }

        // DELETE: api/EntityAddressTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntityAddressType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entityAddressType = await _context.EntityAddressTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (entityAddressType == null)
            {
                return NotFound();
            }

            _context.EntityAddressTypes.Remove(entityAddressType);
            await _context.SaveChangesAsync();

            return Ok(entityAddressType);
        }

        private bool EntityAddressTypeExists(int id)
        {
            return _context.EntityAddressTypes.Any(e => e.Id == id);
        }
    }
}