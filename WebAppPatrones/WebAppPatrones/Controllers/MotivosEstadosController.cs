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
    public class MotivosEstadosController : ControllerBase
    {
        private readonly OperationsDbContext _context;

        public MotivosEstadosController(OperationsDbContext context)
        {
            _context = context;
        }

        // GET: api/MotivosEstados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MotivosEstados>>> GetMotivosEstados()
        {
            return await _context.MotivosEstados.ToListAsync();
        }

        // GET: api/MotivosEstados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MotivosEstados>> GetMotivosEstados(int id)
        {
            var motivosEstados = await _context.MotivosEstados.FindAsync(id);

            if (motivosEstados == null)
            {
                return NotFound();
            }

            return motivosEstados;
        }

        // PUT: api/MotivosEstados/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMotivosEstados(int id, MotivosEstados motivosEstados)
        {
            if (id != motivosEstados.IdMotivo)
            {
                return BadRequest();
            }

            _context.Entry(motivosEstados).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotivosEstadosExists(id))
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

        // POST: api/MotivosEstados
        [HttpPost]
        public async Task<ActionResult<MotivosEstados>> PostMotivosEstados(MotivosEstados motivosEstados)
        {
            _context.MotivosEstados.Add(motivosEstados);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMotivosEstados", new { id = motivosEstados.IdMotivo }, motivosEstados);
        }

        // DELETE: api/MotivosEstados/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MotivosEstados>> DeleteMotivosEstados(int id)
        {
            var motivosEstados = await _context.MotivosEstados.FindAsync(id);
            if (motivosEstados == null)
            {
                return NotFound();
            }

            _context.MotivosEstados.Remove(motivosEstados);
            await _context.SaveChangesAsync();

            return motivosEstados;
        }

        private bool MotivosEstadosExists(int id)
        {
            return _context.MotivosEstados.Any(e => e.IdMotivo == id);
        }
    }
}
