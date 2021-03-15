using System;
using System.Collections.Generic;
using System.Data;
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
    public class DefectosPedidosController : ControllerBase
    {
        private readonly OperationsDbContext _context;



        public class defects
        {
            public string Letra { get; set; }
            public string id { get; set; }
            public string IdPedido { get; set; }
            public string Descripcion { get; set; }
            public string codigo { get; set; }
            public string valor { get; set; }
        }








        public DefectosPedidosController(OperationsDbContext context)
        {
            _context = context;
        }

        // GET: api/DefectosPedidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DefectosPedido>>> GetDefectosPedido()
        {
            return await _context.DefectosPedido.ToListAsync();
        }

        // GET: api/DefectosPedidos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DefectosPedido>> GetDefectosPedido(int id)
        {
            var defectosPedido = await _context.DefectosPedido.FindAsync(id);

            if (defectosPedido == null)
            {
                return NotFound();
            }

            return defectosPedido;
        }

        // PUT: api/DefectosPedidos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDefectosPedido(int id, DefectosPedido defectosPedido)
        {
            if (id != defectosPedido.Id)
            {
                return BadRequest();
            }

            _context.Entry(defectosPedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DefectosPedidoExists(id))
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

        // POST: api/DefectosPedidos
        [HttpPost]
        public async Task<ActionResult<DefectosPedido>> PostDefectosPedido(DefectosPedido defectosPedido)
        {
            _context.DefectosPedido.Add(defectosPedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDefectosPedido", new { id = defectosPedido.Id }, defectosPedido);
        }

        // DELETE: api/DefectosPedidos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DefectosPedido>> DeleteDefectosPedido(int id)
        {
            var defectosPedido = await _context.DefectosPedido.FindAsync(id);
            if (defectosPedido == null)
            {
                return NotFound();
            }

            _context.DefectosPedido.Remove(defectosPedido);
            await _context.SaveChangesAsync();

            return defectosPedido;
        }




        /// ////////////////////////////////////////////////////////////////////

        //api/DefectosPedidos/getdefectsbyLetter
        [HttpGet("getdefectsbyLetter/{IdPedido}/{Letra}")]
        public List<defects> getdefectsbyLetter(int IdPedido, string Letra)
        {
            List<defects> list = new List<defects>();

            try
            {
                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {

                    command.CommandText = " select Letra, id, IdPedido, Descripcion, codigo, valoresatributospedido.valor from defectospedido, tipodefecto, valoresatributospedido where DefectosPedido.IdTipoDefecto = TipoDefecto.IdTipoDefecto and valoresatributospedido.iddefecto = defectospedido.id and valoresatributospedido.idatributo=1 and IdPedido = " + IdPedido + "and Letra ='"+ Letra + "' order by valoresatributospedido.valor ";
                    _context.Database.OpenConnection();

                    using (var result = command.ExecuteReader())
                    {
                        // do something with result
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                list.Add(new defects
                                {
                                    Letra = result.GetValue(0).ToString(), //
                                    id = result.GetValue(1).ToString(),//
                                    IdPedido = result.GetValue(2).ToString(),//
                                    Descripcion = result.GetValue(3).ToString(),//
                                    codigo = result.GetValue(4).ToString(),//
                                    valor = result.GetValue(5).ToString(),//

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

        //api/DefectosPedidos/getdefects
        [HttpGet("getdefects/{IdPedido}")]
        public List<defects> getdefects(int IdPedido)
        {
            List<defects> list = new List<defects>();

            try
            {
                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {

                    command.CommandText = " select Letra, id, IdPedido, Descripcion, codigo, valoresatributospedido.valor from defectospedido, tipodefecto, valoresatributospedido where DefectosPedido.IdTipoDefecto = TipoDefecto.IdTipoDefecto and valoresatributospedido.iddefecto = defectospedido.id and valoresatributospedido.idatributo=1 and IdPedido = " + IdPedido + " order by valoresatributospedido.valor ";
                    _context.Database.OpenConnection();

                    using (var result = command.ExecuteReader())
                    {
                        // do something with result
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                list.Add(new defects
                                {
                                    Letra = result.GetValue(0).ToString(), //
                                    id = result.GetValue(1).ToString(),//
                                    IdPedido = result.GetValue(2).ToString(),//
                                    Descripcion = result.GetValue(3).ToString(),//
                                    codigo = result.GetValue(4).ToString(),//
                                    valor = result.GetValue(5).ToString(),//

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

        //api/DefectosPedidos/SetDefect
        [HttpPost("SetDefect/{IdPedido}/{IdTipoDefecto}")]
        public int SetDefect(int IdPedido, int IdTipoDefecto)
        {
            List<defects> list = new List<defects>();
            string a;
            try
            {
                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    SqlParameter param = new SqlParameter();
                    SqlParameter param2 = new SqlParameter();
                    SqlParameter param3 = new SqlParameter();

                    command.CommandText = " exec InsertaDefecto @IdPedido,@IdTipoDefecto,@IdDefecto ";


                    param.ParameterName = "@IdPedido";
                    param.Value = IdPedido;
                    command.Parameters.Add(param);

                    param2.ParameterName = "@IdTipoDefecto";
                    param2.Value = IdTipoDefecto;
                    command.Parameters.Add(param2);

                    SqlParameter outPutVal = new SqlParameter("@IdDefecto", SqlDbType.Int);
                    outPutVal.Direction = ParameterDirection.Output;
                    command.Parameters.Add(outPutVal);

                    _context.Database.OpenConnection();

                    using (var result = command.ExecuteReader())
                    {
                        // do something with result
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                 a = result.GetValue(0).ToString();
                                return Int32.Parse(a);

                            }
                        }
                    }

                }
            }
            catch (Exception e)
            {
                var b = 0;
            }

            return -1;
        }



















        private bool DefectosPedidoExists(int id)
        {
            return _context.DefectosPedido.Any(e => e.Id == id);
        }
    }
}
