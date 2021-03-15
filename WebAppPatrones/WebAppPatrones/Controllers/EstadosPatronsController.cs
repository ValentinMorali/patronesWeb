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
    public class EstadosPatronsController : ControllerBase
    {
        private readonly OperationsDbContext _context;

        public EstadosPatronsController(OperationsDbContext context)
        {
            _context = context;
        }

        // GET: api/EstadosPatrons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadosPatron>>> GetEstadosPatron()
        {
            return await _context.EstadosPatron.ToListAsync();
        }

        // GET: api/EstadosPatrons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadosPatron>> GetEstadosPatron(int id)
        {
            var estadosPatron = await _context.EstadosPatron.FindAsync(id);

            if (estadosPatron == null)
            {
                return NotFound();
            }

            return estadosPatron;
        }

        // PUT: api/EstadosPatrons/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadosPatron(int id, EstadosPatron estadosPatron)
        {
            if (id != estadosPatron.Status)
            {
                return BadRequest();
            }

            _context.Entry(estadosPatron).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadosPatronExists(id))
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

        // POST: api/EstadosPatrons
        [HttpPost]
        public async Task<ActionResult<EstadosPatron>> PostEstadosPatron(EstadosPatron estadosPatron)
        {
            _context.EstadosPatron.Add(estadosPatron);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EstadosPatronExists(estadosPatron.Status))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEstadosPatron", new { id = estadosPatron.Status }, estadosPatron);
        }

        // DELETE: api/EstadosPatrons/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EstadosPatron>> DeleteEstadosPatron(int id)
        {
            var estadosPatron = await _context.EstadosPatron.FindAsync(id);
            if (estadosPatron == null)
            {
                return NotFound();
            }

            _context.EstadosPatron.Remove(estadosPatron);
            await _context.SaveChangesAsync();

            return estadosPatron;
        }




        /// ////////////////////////////////////////////////////////////////////

        //api/EstadosPatrons/qryEstadosPatron
        [HttpGet("qryEstadosPatron")]
        public List<EstadosPatron> qryEstadosPatron()
        {
            //return _context.EstadosPatron.Where(t => t.Status == 5 || t.Status == 6 || t.Status == 7 || t.Status == 8 || t.Status == 9 || t.Status == 1 || t.Status == -1).ToList();
            return _context.EstadosPatron.Where(t => t.Status == 0 || t.Status == 2 || t.Status == 3 || t.Status == 4 || t.Status == 10 || t.Status == 11 || t.Status == 12 || t.Status == 13).ToList();
        }

        /// ////////////////////////////////////////////////////////////////////

        //api/EstadosPatrons/qryEstadosPedido
        [HttpGet("qryEstadosPedido")]
        public List<EstadosPatron> qryEstadosPedido()
        {
            List<EstadosPatron> listresult = new List<EstadosPatron>();
            listresult.Add(new EstadosPatron
            {
           Descripcion="Todos",
           Existe=true,
           Status=0
            });



            var list = _context.EstadosPatron.Where(t => t.Status == 5 || t.Status == 6 || t.Status == 7 || t.Status == 8 || t.Status == 9 || t.Status == 1 || t.Status == 2).OrderBy(y => y.Status).ToList();

            listresult= listresult.Concat(list).ToList();
            return listresult;
        }




















        private bool EstadosPatronExists(int id)
        {
            return _context.EstadosPatron.Any(e => e.Status == id);
        }
    }
}
