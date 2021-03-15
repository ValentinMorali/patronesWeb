using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebAppPatrones.Models;

namespace WebAppPatrones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValoresAtributosController : ControllerBase
    {
        private readonly OperationsDbContext _context;


        public class ValoresAtributosPedido
        {
            public string IdDefecto { get; set; }
            public string IdAtributo { get; set; }
            public string Valor { get; set; }
            public string ToleranciaL { get; set; }
            public string ToleranciaH { get; set; }

        }





        public ValoresAtributosController(OperationsDbContext context)
        {
            _context = context;
        }

        // GET: api/ValoresAtributos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ValoresAtributos>>> GetValoresAtributos()
        {
            return await _context.ValoresAtributos.ToListAsync();
        }

        // GET: api/ValoresAtributos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ValoresAtributos>> GetValoresAtributos(int id)
        {
            var valoresAtributos = await _context.ValoresAtributos.FindAsync(id);

            if (valoresAtributos == null)
            {
                return NotFound();
            }

            return valoresAtributos;
        }

        // PUT: api/ValoresAtributos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutValoresAtributos(int id, ValoresAtributos valoresAtributos)
        {
            if (id != valoresAtributos.IdDefecto)
            {
                return BadRequest();
            }

            _context.Entry(valoresAtributos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ValoresAtributosExists(id))
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

        // POST: api/ValoresAtributos
        [HttpPost]
        public async Task<ActionResult<ValoresAtributos>> PostValoresAtributos(ValoresAtributos valoresAtributos)
        {
            _context.ValoresAtributos.Add(valoresAtributos);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ValoresAtributosExists(valoresAtributos.IdDefecto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetValoresAtributos", new { id = valoresAtributos.IdDefecto }, valoresAtributos);
        }

        // DELETE: api/ValoresAtributos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ValoresAtributos>> DeleteValoresAtributos(int id)
        {
            var valoresAtributos = await _context.ValoresAtributos.FindAsync(id);
            if (valoresAtributos == null)
            {
                return NotFound();
            }

            _context.ValoresAtributos.Remove(valoresAtributos);
            await _context.SaveChangesAsync();

            return valoresAtributos;
        }



        /// ////////////////////////////////////////////////////////////////////

        //api/ValoresAtributos/setValuesAttributesOrder
        [HttpPost("setValuesAttributesOrder")]
        public void setValuesAttributesOrder(string pedidosaux)
        {
            var atr = JsonConvert.DeserializeObject<ValoresAtributosPedido>(pedidosaux);
            
                        try
                        {
                            using (var command = _context.Database.GetDbConnection().CreateCommand())
                            {

                                command.CommandText = " insert into ValoresAtributosPedido (IdDefecto, IdAtributo, Valor, ToleranciaL, ToleranciaH) values (" + atr.IdDefecto + "," + atr.IdAtributo + "," + atr.Valor + "," + atr.ToleranciaL + "," + atr.ToleranciaH + ")";
                                _context.Database.OpenConnection();

                                using (var result = command.ExecuteReader())
                                {
                                    // do something with result
                                    if (result.HasRows)
                                    {
                                        while (result.Read())
                                        {
                                            var a = result.GetValue(0); //id
                                        }
                                    }
                                }

        }
    }
            catch (Exception e)
            {
                var a = 0;
            }
            

            // return list;
        }



        /// ////////////////////////////////////////////////////////////////////

        //api/ValoresAtributos/updateValuesAttributesOrder
        [HttpPost("updateValuesAttributesOrder")]
        public void updateValuesAttributesOrder(string pedidosaux)
        {
            var atr = JsonConvert.DeserializeObject<ValoresAtributosPedido>(pedidosaux);

            try
            {
                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {

command.CommandText = " UPDATE ValoresAtributosPedido SET Valor=" + atr.Valor + ", ToleranciaL = " + atr.ToleranciaL + ", ToleranciaH = " + atr.ToleranciaH + " where IdDefecto = " + atr.IdDefecto + " and IdAtributo = " + atr.IdAtributo+"; ";

                    _context.Database.OpenConnection();

                    using (var result = command.ExecuteReader())
                    {
                        // do something with result
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                var a = result.GetValue(0); //id
                            }
                        }
                    }

                }
            }
            catch (Exception e)
            {
                var a = 0;
            }


            // return list;
        }


        /// ////////////////////////////////////////////////////////////////////

        //api/ValoresAtributos/deleteValuesAttributesOrder
        [HttpGet("deleteValuesAttributesOrder/{IdDefecto}")]
        public int deleteValuesAttributesOrder(long IdDefecto)
        {
            //    List<tubetypes> list = new List<tubetypes>();
            string r = "";


            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                SqlParameter param = new SqlParameter();
                SqlParameter param2 = new SqlParameter();

                command.CommandText = " delete from ValoresAtributosPedido where IdDefecto = " + IdDefecto + "; " +

                    " delete from DefectosPedido where Id = "+ IdDefecto+ "; ";
                    

          /*      param.ParameterName = "@Tipo";
                param.Value = IdTipoTubo;
                command.Parameters.Add(param);

                param2.ParameterName = "@Planta";
                param2.Value = planta;
                command.Parameters.Add(param2);
                */

                _context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    // do something with result
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {

                            r = result.GetValue(0).ToString();

                        }
                    }
                }
            }




            return 0;
        }













        private bool ValoresAtributosExists(int id)
        {
            return _context.ValoresAtributos.Any(e => e.IdDefecto == id);
        }
    }
}
