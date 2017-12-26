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
    [Route("api/EntityEmailAddressTypes")]
    public class EntityEmailAddressTypesController : Controller
    {
        private readonly EntityRelationshipDbContext _context;

        public EntityEmailAddressTypesController(EntityRelationshipDbContext context)
        {
            _context = context;
        }

        // GET: api/EntityEmailAddressTypes
        [HttpGet]
        public IEnumerable<EntityEmailAddressType> GetEntityEmailAddressTypes()
        {
            return _context.EntityEmailAddressTypes;
        }

        // GET: api/EntityEmailAddressTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntityEmailAddressType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entityEmailAddressType = await _context.EntityEmailAddressTypes.SingleOrDefaultAsync(m => m.Id == id);

            if (entityEmailAddressType == null)
            {
                return NotFound();
            }

            return Ok(entityEmailAddressType);
        }

        // PUT: api/EntityEmailAddressTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntityEmailAddressType([FromRoute] int id, [FromBody] EntityEmailAddressType entityEmailAddressType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entityEmailAddressType.Id)
            {
                return BadRequest();
            }

            _context.Entry(entityEmailAddressType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityEmailAddressTypeExists(id))
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

        // POST: api/EntityEmailAddressTypes
        [HttpPost]
        public async Task<IActionResult> PostEntityEmailAddressType([FromBody] EntityEmailAddressType entityEmailAddressType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EntityEmailAddressTypes.Add(entityEmailAddressType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntityEmailAddressType", new { id = entityEmailAddressType.Id }, entityEmailAddressType);
        }

        // DELETE: api/EntityEmailAddressTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntityEmailAddressType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entityEmailAddressType = await _context.EntityEmailAddressTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (entityEmailAddressType == null)
            {
                return NotFound();
            }

            _context.EntityEmailAddressTypes.Remove(entityEmailAddressType);
            await _context.SaveChangesAsync();

            return Ok(entityEmailAddressType);
        }

        private bool EntityEmailAddressTypeExists(int id)
        {
            return _context.EntityEmailAddressTypes.Any(e => e.Id == id);
        }
    }
}