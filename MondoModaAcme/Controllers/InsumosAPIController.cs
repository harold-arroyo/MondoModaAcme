using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MondoModaAcme.Models;

namespace MondoModaAcme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsumosAPIController : ControllerBase
    {
        private readonly MondoModaAcmeContext _context;

        public InsumosAPIController(MondoModaAcmeContext context)
        {
            _context = context;
        }

        // GET: api/InsumosAPI
        [HttpGet]
        [Produces("application/json","application/xml")]
        public IEnumerable<Insumo> GetInsumo()
        {
            return _context.Insumo;
        }

        // GET: api/InsumosAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInsumo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var insumo = await _context.Insumo.FindAsync(id);

            if (insumo == null)
            {
                return NotFound();
            }

            return Ok(insumo);
        }

        // PUT: api/InsumosAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsumo([FromRoute] int id, [FromBody] Insumo insumo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != insumo.Id)
            {
                return BadRequest();
            }

            _context.Entry(insumo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsumoExists(id))
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

        // POST: api/InsumosAPI
        [HttpPost]
        public async Task<IActionResult> PostInsumo([FromBody] Insumo insumo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Insumo.Add(insumo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInsumo", new { id = insumo.Id }, insumo);
        }

        // DELETE: api/InsumosAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsumo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var insumo = await _context.Insumo.FindAsync(id);
            if (insumo == null)
            {
                return NotFound();
            }

            _context.Insumo.Remove(insumo);
            await _context.SaveChangesAsync();

            return Ok(insumo);
        }

        private bool InsumoExists(int id)
        {
            return _context.Insumo.Any(e => e.Id == id);
        }
    }
}