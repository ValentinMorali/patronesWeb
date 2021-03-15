using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    public class LineasController : ControllerBase
    {
        private readonly OperationsDbContext _context;

        public LineasController(OperationsDbContext context)
        {
            _context = context;
        }

        public class plantline
        {
            public string id { get; set; }
            public string description { get; set; }

        }




        // GET: api/Lineas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Linea>>> GetLinea()
        {
            return await _context.Linea.ToListAsync();
        }

        // GET: api/Lineas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Linea>> GetLinea(int id)
        {
            var linea = await _context.Linea.FindAsync(id);

            if (linea == null)
            {
                return NotFound();
            }

            return linea;
        }

        // PUT: api/Lineas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLinea(int id, Linea linea)
        {
            if (id != linea.Id)
            {
                return BadRequest();
            }

            _context.Entry(linea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineaExists(id))
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

        // POST: api/Lineas
        [HttpPost]
        public async Task<ActionResult<Linea>> PostLinea(Linea linea)
        {
            _context.Linea.Add(linea);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLinea", new { id = linea.Id }, linea);
        }

        // DELETE: api/Lineas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Linea>> DeleteLinea(int id)
        {
            var linea = await _context.Linea.FindAsync(id);
            if (linea == null)
            {
                return NotFound();
            }

            _context.Linea.Remove(linea);
            await _context.SaveChangesAsync();

            return linea;
        }

        /// ////////////////////////////////////////////////////////////////////

        //api/Lineas/GetPlantLinea
        [HttpGet("GetPlantLinea/{usuario}")]
        public List<plantline> GetPlantLinea(string usuario)
        {
            List<plantline> list = new List<plantline>();


            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                SqlParameter param = new SqlParameter();

                command.CommandText = " exec  qryPlantaLinea @Registro ";

                param.ParameterName = "@Registro";
                param.Value = usuario;
                command.Parameters.Add(param);

                _context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    // do something with result
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {

                            var a = result.GetValue(0);

                               list.Add(new plantline
                               {
                                     id = result.GetValue(0).ToString(), //id
                                     description = result.GetValue(1).ToString(),//description

                               });

                        }
                    }
                }
            }




            return list;
        }














            /// ////////////////////////////////////////////////////////////////////


            private bool LineaExists(int id)
        {
            return _context.Linea.Any(e => e.Id == id);
        }
    }
}
