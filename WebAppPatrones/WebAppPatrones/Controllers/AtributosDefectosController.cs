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
    public class AtributosDefectosController : ControllerBase
    {




        public class effecttypeattributes
        {
            public string IdAtributo { get; set; }
            public string Descripcion { get; set; }
            public string Tolerancia { get; set; }
            public string Unidad { get; set; }

        }


        public class idttributes
        {
            public string Id { get; set; }

        }


        private readonly OperationsDbContext _context;

        public AtributosDefectosController(OperationsDbContext context)
        {
            _context = context;
        }

        // GET: api/AtributosDefectos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AtributosDefecto>>> GetAtributosDefecto()
        {
            return await _context.AtributosDefecto.ToListAsync();
        }

        // GET: api/AtributosDefectos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AtributosDefecto>> GetAtributosDefecto(int id)
        {
            var atributosDefecto = await _context.AtributosDefecto.FindAsync(id);

            if (atributosDefecto == null)
            {
                return NotFound();
            }

            return atributosDefecto;
        }

        // PUT: api/AtributosDefectos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAtributosDefecto(int id, AtributosDefecto atributosDefecto)
        {
            if (id != atributosDefecto.IdAtributo)
            {
                return BadRequest();
            }

            _context.Entry(atributosDefecto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtributosDefectoExists(id))
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

        // POST: api/AtributosDefectos
        [HttpPost]
        public async Task<ActionResult<AtributosDefecto>> PostAtributosDefecto(AtributosDefecto atributosDefecto)
        {
            _context.AtributosDefecto.Add(atributosDefecto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AtributosDefectoExists(atributosDefecto.IdAtributo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAtributosDefecto", new { id = atributosDefecto.IdAtributo }, atributosDefecto);
        }

        // DELETE: api/AtributosDefectos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AtributosDefecto>> DeleteAtributosDefecto(int id)
        {
            var atributosDefecto = await _context.AtributosDefecto.FindAsync(id);
            if (atributosDefecto == null)
            {
                return NotFound();
            }

            _context.AtributosDefecto.Remove(atributosDefecto);
            await _context.SaveChangesAsync();

            return atributosDefecto;
        }



        /// ////////////////////////////////////////////////////////////////////

        //api/AtributosDefectos/geteffecttypeattributes
        [HttpGet("geteffecttypeattributes/{IdTipoDefecto}")]
        public List<effecttypeattributes> geteffecttypeattributes(int IdTipoDefecto)
        {
            List<effecttypeattributes> list = new List<effecttypeattributes>();

            try
            {
                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {

                    command.CommandText = " select TipoAtributo.IdAtributo, TipoAtributo.Descripcion, Tolerancia.Descripcion 'Tolerancia', TipoAtributo.Unidad from AtributosDefecto, TipoAtributo, Tolerancia where Tolerancia.Id = TipoAtributo.Tolerancia and TipoAtributo.IdAtributo = AtributosDefecto.IdAtributo and IdTipoDefecto="+ IdTipoDefecto ;
                    _context.Database.OpenConnection();

                    using (var result = command.ExecuteReader())
                    {
                        // do something with result
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                list.Add(new effecttypeattributes
                                {
                                    IdAtributo = result.GetValue(0).ToString(), //id
                                    Descripcion = result.GetValue(1).ToString(),//description
                                    Tolerancia = result.GetValue(2).ToString(),//Tolerancia
                                    Unidad = result.GetValue(3).ToString(),//Unidad
                                });


                            }
                        }
                    }

                }
            }
            catch (Exception e)
            {
                var a = 0;
            }

            return list;
        }



        /// ////////////////////////////////////////////////////////////////////

        //api/AtributosDefectos/getattributesbyid
        [HttpGet("getattributesbyid/{IdTipoDefecto}")]
        public List<idttributes> getattributesbyid(int IdTipoDefecto)
        {
            List<idttributes> list = new List<idttributes>();

            try
            {
                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {

                    command.CommandText = " select IdAtributo 'Id' from AtributosDefecto where IdTipoDefecto = " + IdTipoDefecto;
                    _context.Database.OpenConnection();

                    using (var result = command.ExecuteReader())
                    {
                        // do something with result
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                list.Add(new idttributes
                                {
                                    Id = result.GetValue(0).ToString(), //id
                                });


                            }
                        }
                    }

                }
            }
            catch (Exception e)
            {
                var a = 0;
            }

            return list;
        }
















        private bool AtributosDefectoExists(int id)
        {
            return _context.AtributosDefecto.Any(e => e.IdAtributo == id);
        }
    }
}
