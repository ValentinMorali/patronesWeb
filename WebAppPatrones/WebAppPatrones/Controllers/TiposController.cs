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
    public class TiposController : ControllerBase
    {
        private readonly OperationsDbContext _context;

        public TiposController(OperationsDbContext context)
        {
            _context = context;
        }

        public class tubetypes
        {
            public string id { get; set; }
            public string description { get; set; }

        }


        // GET: api/Tipos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tipos>>> GetTipos()
        {
            return await _context.Tipos.ToListAsync();
        }

        // GET: api/Tipos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tipos>> GetTipos(int id)
        {
            var tipos = await _context.Tipos.FindAsync(id);

            if (tipos == null)
            {
                return NotFound();
            }

            return tipos;
        }

        // PUT: api/Tipos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipos(int id, Tipos tipos)
        {
            if (id != tipos.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiposExists(id))
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

        // POST: api/Tipos
        [HttpPost]
        public async Task<ActionResult<Tipos>> PostTipos(Tipos tipos)
        {
            _context.Tipos.Add(tipos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipos", new { id = tipos.Id }, tipos);
        }

        // DELETE: api/Tipos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tipos>> DeleteTipos(int id)
        {
            var tipos = await _context.Tipos.FindAsync(id);
            if (tipos == null)
            {
                return NotFound();
            }

            _context.Tipos.Remove(tipos);
            await _context.SaveChangesAsync();

            return tipos;
        }

        /// ////////////////////////////////////////////////////////////////////

        //api/Tipos/GetTubeTypes
        [HttpGet("GetTubeTypes/{usuario}/{idLinea}")]
        public List<tubetypes> GetTubeTypes(string usuario, long idLinea)
        {
            List<tubetypes> list = new List<tubetypes>();


            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                SqlParameter param = new SqlParameter();
                SqlParameter param2 = new SqlParameter();

                command.CommandText = " exec [qryTipoTubos] @Registro , @Linea ";

                param.ParameterName = "@Registro";
                param.Value = usuario;
                command.Parameters.Add(param);

                param2.ParameterName = "@Linea";
                param2.Value = idLinea;
                command.Parameters.Add(param2);


                _context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    // do something with result
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {

                            var a = result.GetValue(0);

                            list.Add(new tubetypes
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

        //api/Tipos/GetTubeTypes
        [HttpGet("GetPipeCode/{IdTipoTubo}/{idLinea}/{fCodigo}")]
        public string GetPipeCode(long IdTipoTubo, long idLinea, string fCodigo)
        {

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                SqlParameter param = new SqlParameter();
                SqlParameter param2 = new SqlParameter();

                command.CommandText = " select ((case len(label) when 1 then cast(" + idLinea + "as char(1))+label else label end) + '"+ fCodigo + "') as codigo from tipos where id = "+ IdTipoTubo;


                _context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    // do something with result
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {

                            var A= result.GetValue(0).ToString();

                            return A;
                        }
                    }
                }
            }




            return null;
        }



















        private bool TiposExists(int id)
        {
            return _context.Tipos.Any(e => e.Id == id);
        }
    }
}
