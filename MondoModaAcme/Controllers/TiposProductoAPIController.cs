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
    public class TiposProductoAPIController : ControllerBase
    {
        private readonly MondoModaAcmeContext _context;

        public TiposProductoAPIController(MondoModaAcmeContext context)
        {
            _context = context;
        }

        // GET: api/TiposProductoAPI
        [HttpGet]
        [Produces("application/json", "application/xml")]
        public IEnumerable<TipoProducto> GetTipoProducto()
        {
            return _context.TipoProducto;
        }

        // GET: api/TiposProductoAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipoProducto([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoProducto = await _context.TipoProducto.FindAsync(id);

            if (tipoProducto == null)
            {
                return NotFound();
            }

            return Ok(tipoProducto);
        }

        // PUT: api/TiposProductoAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoProducto([FromRoute] int id, [FromBody] TipoProducto tipoProducto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoProducto.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoProducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoProductoExists(id))
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

        // POST: api/TiposProductoAPI
        [HttpPost]
        public async Task<IActionResult> PostTipoProducto([FromBody] TipoProducto tipoProducto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TipoProducto.Add(tipoProducto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoProducto", new { id = tipoProducto.Id }, tipoProducto);
        }

        // DELETE: api/TiposProductoAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoProducto([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoProducto = await _context.TipoProducto.FindAsync(id);
            if (tipoProducto == null)
            {
                return NotFound();
            }

            _context.TipoProducto.Remove(tipoProducto);
            await _context.SaveChangesAsync();

            return Ok(tipoProducto);
        }

        private bool TipoProductoExists(int id)
        {
            return _context.TipoProducto.Any(e => e.Id == id);
        }
    }
}