using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppPatrones.Models;

namespace WebAppPatrones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDefectosController : ControllerBase
    {
        private readonly OperationsDbContext _context;

        public TipoDefectosController(OperationsDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoDefectos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoDefecto>>> GetTipoDefecto()
        {
            return await _context.TipoDefecto.ToListAsync();
        }

        // GET: api/TipoDefectos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoDefecto>> GetTipoDefecto(int id)
        {
            var tipoDefecto = await _context.TipoDefecto.FindAsync(id);

            if (tipoDefecto == null)
            {
                return NotFound();
            }

            return tipoDefecto;
        }

        // PUT: api/TipoDefectos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoDefecto(int id, TipoDefecto tipoDefecto)
        {
            if (id != tipoDefecto.IdTipoDefecto)
            {
                return BadRequest();
            }

            _context.Entry(tipoDefecto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoDefectoExists(id))
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

        // POST: api/TipoDefectos
        [HttpPost]
        public async Task<ActionResult<TipoDefecto>> PostTipoDefecto(TipoDefecto tipoDefecto)
        {
            _context.TipoDefecto.Add(tipoDefecto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoDefecto", new { id = tipoDefecto.IdTipoDefecto }, tipoDefecto);
        }

        // DELETE: api/TipoDefectos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoDefecto>> DeleteTipoDefecto(int id)
        {
            var tipoDefecto = await _context.TipoDefecto.FindAsync(id);
            if (tipoDefecto == null)
            {
                return NotFound();
            }

            _context.TipoDefecto.Remove(tipoDefecto);
            await _context.SaveChangesAsync();

            return tipoDefecto;
        }

        private bool TipoDefectoExists(int id)
        {
            return _context.TipoDefecto.Any(e => e.IdTipoDefecto == id);
        }
    }
}
