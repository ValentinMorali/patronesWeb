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
    public class TipoAtributosController : ControllerBase
    {
        private readonly OperationsDbContext _context;


        public class ValuesAttributesOrder
        {
            public string idDefecto { get; set; }
            public string IdAtributo { get; set; }
            public string Valor { get; set; }
            public string ToleranciaL { get; set; }
            public string ToleranciaH { get; set; }
        }
        public class DescriptionAttributes
        {
            public string Descripcion { get; set; }
            public string Valor { get; set; }
            public string Unidad { get; set; }
        }



        



        public TipoAtributosController(OperationsDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoAtributos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoAtributo>>> GetTipoAtributo()
        {
            return await _context.TipoAtributo.ToListAsync();
        }

        // GET: api/TipoAtributos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoAtributo>> GetTipoAtributo(int id)
        {
            var tipoAtributo = await _context.TipoAtributo.FindAsync(id);

            if (tipoAtributo == null)
            {
                return NotFound();
            }

            return tipoAtributo;
        }

        // PUT: api/TipoAtributos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoAtributo(int id, TipoAtributo tipoAtributo)
        {
            if (id != tipoAtributo.IdAtributo)
            {
                return BadRequest();
            }

            _context.Entry(tipoAtributo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoAtributoExists(id))
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

        // POST: api/TipoAtributos
        [HttpPost]
        public async Task<ActionResult<TipoAtributo>> PostTipoAtributo(TipoAtributo tipoAtributo)
        {
            _context.TipoAtributo.Add(tipoAtributo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoAtributo", new { id = tipoAtributo.IdAtributo }, tipoAtributo);
        }

        // DELETE: api/TipoAtributos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoAtributo>> DeleteTipoAtributo(int id)
        {
            var tipoAtributo = await _context.TipoAtributo.FindAsync(id);
            if (tipoAtributo == null)
            {
                return NotFound();
            }

            _context.TipoAtributo.Remove(tipoAtributo);
            await _context.SaveChangesAsync();

            return tipoAtributo;
        }


        /// ////////////////////////////////////////////////////////////////////

        //api/TipoAtributos/getValuesAttributesOrder
        [HttpGet("getValuesAttributesOrder/{idDefecto}")]
        public List<ValuesAttributesOrder> getValuesAttributesOrder(int idDefecto)
        {
            List< ValuesAttributesOrder> list = new List<ValuesAttributesOrder>();

            try
            {
                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {

                    command.CommandText = " SELECT [idDefecto],[IdAtributo],[Valor],[ToleranciaL],[ToleranciaH] FROM[patrones].[dbo].[ValoresAtributosPedido] where idDefecto = " + idDefecto ;
                    _context.Database.OpenConnection();

                    using (var result = command.ExecuteReader())
                    {
                        // do something with result
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                list.Add(new ValuesAttributesOrder
                                {
                                    idDefecto = result.GetValue(0).ToString(), //
                                    IdAtributo = result.GetValue(1).ToString(),//
                                    Valor = result.GetValue(2).ToString(),//
                                    ToleranciaL = result.GetValue(3).ToString(),//
                                    ToleranciaH = result.GetValue(4).ToString(),//
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

        //api/TipoAtributos/getDescriptionAttributes
        [HttpGet("getDescriptionAttributes/{idDefecto}")]
        public List<DescriptionAttributes> getDescriptionAttributes(int idDefecto)
        {
            List<DescriptionAttributes> list = new List<DescriptionAttributes>();

            try
            {
                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {

                    command.CommandText = " select Descripcion, Valor, Unidad from TipoAtributo, ValoresAtributosPedido where (ValoresAtributosPedido.IdAtributo = TipoAtributo.IdAtributo) and (ValoresAtributosPedido.IdDefecto = "+ idDefecto + ") ";
                    _context.Database.OpenConnection();

                    using (var result = command.ExecuteReader())
                    {
                        // do something with result
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                list.Add(new DescriptionAttributes
                                {
                                    Descripcion = result.GetValue(0).ToString(), //
                                    Valor = result.GetValue(1).ToString(),//
                                    Unidad = result.GetValue(2).ToString(),//

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



































        private bool TipoAtributoExists(int id)
        {
            return _context.TipoAtributo.Any(e => e.IdAtributo == id);
        }
    }
}
