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
    [Route("api/EntityItems")]
    public class EntityItemsController : Controller
    {
        private readonly EntityRelationshipDbContext _context;

        public EntityItemsController(EntityRelationshipDbContext context)
        {
            _context = context;                
        }

        // GET: api/EntityItems
        [HttpGet]
        public IEnumerable<EntityItem> GetEntityItems([FromQuery]bool IncludeDetail)
        {
            using (var context = _context)
            {
                if (IncludeDetail)
                {
                    var entities = context.EntityItems
                      .Include(ea => ea.EntityAddressList)
                      .Include(ee => ee.EntityEmailAddressList)
                      .Include(es => es.StatuatoryIdList)
                      .Include(et => et.EntityTelephoneNumberList)
                      .Include(ett => ett.EntityType)

                      .ToList();


                    foreach (EntityItem en in entities)
                    {
                        foreach (EntityAddress ea in en.EntityAddressList)
                        {
                            var res = context.EntityAddressTypes
                            .Single(b => b.Id == ea.EntityAddressTypeId);
                        }

                        foreach (EntityEmailAddress ee in en.EntityEmailAddressList)
                        {
                            var res = context.EntityEmailAddressTypes
                            .Single(b => b.Id == ee.EntityEmailAddressTypeId);
                        }

                        foreach (EntityStatuatoryId es in en.StatuatoryIdList)
                        {
                            var res = context.EntityStatuatoryIdTypes
                            .Single(b => b.Id == es.EntityStatuatoryIdTypeId);
                        }

                        foreach (EntityTelephoneNumber es in en.EntityTelephoneNumberList)
                        {
                            var res = context.EntityTelephoneNumberTypes
                            .Single(b => b.Id == es.EntityTelephoneNumberTypeId);
                        }

                    }

                    return entities;

                   
                }


                return context.EntityItems.ToList();
            }

        }

        // GET: api/EntityItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntityItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entityItem = await _context.EntityItems.SingleOrDefaultAsync(m => m.Id == id);

            if (entityItem == null)
            {
                return NotFound();
            }

            return Ok(entityItem);
        }

        // PUT: api/EntityItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntityItem([FromRoute] int id, [FromBody] EntityItem entityItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entityItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(entityItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityItemExists(id))
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

        // POST: api/EntityItems
        [HttpPost]
        public async Task<IActionResult> PostEntityItem([FromBody] EntityItem entityItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EntityItems.Add(entityItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntityItem", new { id = entityItem.Id }, entityItem);
        }

        // DELETE: api/EntityItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntityItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entityItem = await _context.EntityItems.SingleOrDefaultAsync(m => m.Id == id);
            if (entityItem == null)
            {
                return NotFound();
            }

            _context.EntityItems.Remove(entityItem);
            await _context.SaveChangesAsync();

            return Ok(entityItem);
        }

        private bool EntityItemExists(int id)
        {
            return _context.EntityItems.Any(e => e.Id == id);
        }
    }
}