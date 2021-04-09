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
    public class PatronsController : ControllerBase
    {
        private readonly OperationsDbContext _context;

        public PatronsController(OperationsDbContext context)
        {
            _context = context;
        }

        public class history
        {
            public string pasillo { get; set; }
            public string cuerpo { get; set; }
            public string nivel { get; set; }
            public string casilla { get; set; }
            public string linea { get; set; }
            public string estado { get; set; }
            public string fecha { get; set; }

        }


        public class order
        {
            public string id { get; set; }
            public string descripcion { get; set; }
            public string longitud { get; set; }
            public string diametro { get; set; }
            public string espesor { get; set; }
            public string idtipo { get; set; }
            public string tipo { get; set; }
            public string acero { get; set; }
            public string grado { get; set; }
            public string ciclo { get; set; }
            public string colada { get; set; }
            public string expediente { get; set; }
            public string codigo { get; set; }
            public string tratamientotermico { get; set; }
            public string fechepedido { get; set; }
            public string fechaesperado { get; set; }
            public string entregado { get; set; }
            public string idpadre { get; set; }
            public string idestado { get; set; }
            public string prioridad { get; set; }
            public string secuencia { get; set; }
            public string cliente { get; set; }
            public string ubicacion { get; set; }



        }





        public class patronaux
        {
            public string requisito { get; set; }

            public int Id { get; set; }
            public int NroPasadas { get; set; }
            public int? NroMaxPasadas { get; set; }
            public double Longitud { get; set; }
            public double Diametro { get; set; }
            public double Espesor { get; set; }

            public string type { get; set; }
            public string linea { get; set; }
            public string motivo { get; set; }
            public string estado { get; set; }


            public string Acero { get; set; }

            public DateTime? FechaAlta { get; set; }
            public int Tipo { get; set; }

            public string TratamientoTermico { get; set; }

            public DateTime? UltimaPasada { get; set; }

            public int? IdUbicacion { get; set; }

            public int? IdPadre { get; set; }

            public string Codigo { get; set; }
            public int Ciclo { get; set; }
            public int Colada { get; set; }

            public string Expediente { get; set; }

            public string UltimoUso { get; set; }

            public string Grado { get; set; }

            public int? IdPedido { get; set; }

            public int IdEstado { get; set; }

            public string Cliente { get; set; }

            public string Descripcion { get; set; }
            public int? Esdefinicion { get; set; }
            public int? Status { get; set; }



            public int? IdBrazoEstiba { get; set; }
            public int? Traceability { get; set; }

            public string Ubicacion { get; set; }

            public string Pasillo { get; set; }

            public string Cuerpo { get; set; }

            public string Nivel { get; set; }

            public string Casilla { get; set; }

            public int? IdMotivo { get; set; }

            public int? IdLinea { get; set; }


            public bool? Replica { get; set; }
            public bool? Acustica { get; set; }

            public string Registo { get; set; }
            public int? PosicionTag { get; set; }



        }




        // GET: api/Patrons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patron>>> GetPatron()
        {
            return await _context.Patron.ToListAsync();
        }

        // GET: api/Patrons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patron>> GetPatron(int? id)
        {
            var patron = await _context.Patron.Where(t => t.IdPedido == id).FirstOrDefaultAsync();

            return patron;
        }

        // PUT: api/Patrons/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatron(int id, Patron patron)
        {
            if (id != patron.Id)
            {
                return BadRequest();
            }

            _context.Entry(patron).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatronExists(id))
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

        // POST: api/Patrons
        [HttpPost]
        public async Task<ActionResult<Patron>> PostPatron(Patron patron)
        {
            _context.Patron.Add(patron);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatron", new { id = patron.Id }, patron);
        }

        // DELETE: api/Patrons/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Patron>> DeletePatron(int id)
        {
            var patron = await _context.Patron.FindAsync(id);
            if (patron == null)
            {
                return NotFound();
            }

            _context.Patron.Remove(patron);
            await _context.SaveChangesAsync();

            return patron;
        }





        /// ////////////////////////////////////////////////////////////////////

        //api/Patrons/GetPatronsByCode
        [HttpGet("GetPatronsByCode/{code}")]
        public Patron GetPatronsByCode(string code)
        {





            Patron list = new Patron();


            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {


                command.CommandText = "  select id, idpedido, longitud, diametro, espesor, acero, grado, tratamientotermico, ciclo, expediente, colada from patron where codigo = '" + code + "' and idestado in (0, 10) ";

                _context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    // do something with result
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {





                            list = new Patron
                            {
                                Id = Int32.Parse(result.GetValue(0).ToString()),
                                Diametro = double.Parse(result.GetValue(3).ToString()),

                                IdPedido = Int32.Parse(result.GetValue(1).ToString()),
                                Grado = result.GetValue(6).ToString() != "" ? result.GetValue(6).ToString() : (string)null,


                                Ciclo = Int32.Parse(result.GetValue(8).ToString()),

                                Espesor = double.Parse(result.GetValue(4).ToString()),

                                Acero = result.GetValue(5).ToString() != "" ? result.GetValue(5).ToString() : (string)null,

                                Colada = Int32.Parse(result.GetValue(10).ToString()),
                                Longitud = double.Parse(result.GetValue(2).ToString()),//

                                TratamientoTermico = result.GetValue(7).ToString() != "" ? result.GetValue(7).ToString() : (string)null,

                                Expediente = result.GetValue(9).ToString() != "" ? result.GetValue(9).ToString() : (string)null,



                            };
                        }
                    }
                }
            }




            return list;







            /*     try { 
                 var a=_context.Patron.Where(s => s.Codigo == code && (s.Status == 0|| s.Status == 10)).FirstOrDefault();
                     return a;

                 }
                 catch 
                 {
                     return null;
                 }*/


        }

        /*
                   public string id { get; set; }
            public string descripcion { get; set; }
            public string longitud { get; set; }
            public string diametro { get; set; }
            public string espesor { get; set; }
            public string idtipo { get; set; }
            public string tipo { get; set; }
            public string acero { get; set; }
            public string grado { get; set; }
            public string ciclo { get; set; }
            public string colada { get; set; }
            public string expediente { get; set; }
            public string codigo { get; set; }
            public string tratamientotermico { get; set; }
            public string fechepedido { get; set; }
            public string fechaesperado { get; set; }
            public string entregado { get; set; }
            public string idpadre { get; set; }
            public string idestado { get; set; }
            public string prioridad { get; set; }
            public string secuencia { get; set; }
            public string cliente { get; set; }
            public string ubicacion { get; set; }
        */
        /// ////////////////////////////////////////////////////////////////////

        //api/Patrons/getOrderByFilter
        [HttpGet("getOrderByFilter")]
        public List<order> getOrderByFilter(string strQuery)
        {
            byte[] data = Convert.FromBase64String(strQuery); //17/09/2019
            strQuery = System.Text.Encoding.UTF8.GetString(data);//17/09/2019


            List<order> list = new List<order>();
            try
            {
                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {

                    command.CommandText = strQuery;

                    _context.Database.OpenConnection();

                    using (var result = command.ExecuteReader())
                    {
                        // do something with result
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                //  var a = result.GetValue(21).ToString();


                                list.Add(new order
                                {
                                    id = result.GetValue(0).ToString() != "" ? result.GetValue(0).ToString() : (string)null,
                                    descripcion = result.GetValue(1).ToString() != "" ? result.GetValue(1).ToString() : (string)null,
                                    longitud = result.GetValue(2).ToString() != "" ? result.GetValue(2).ToString() : (string)null,
                                    diametro = result.GetValue(3).ToString() != "" ? result.GetValue(3).ToString() : (string)null,
                                    espesor = result.GetValue(4).ToString() != "" ? result.GetValue(4).ToString() : (string)null,
                                    idtipo = result.GetValue(5).ToString() != "" ? result.GetValue(5).ToString() : (string)null,
                                    tipo = result.GetValue(6).ToString() != "" ? result.GetValue(6).ToString() : (string)null,
                                    acero = result.GetValue(7).ToString() != "" ? result.GetValue(7).ToString() : (string)null,
                                    grado = result.GetValue(8).ToString() != "" ? result.GetValue(8).ToString() : (string)null,
                                    ciclo = result.GetValue(9).ToString() != "" ? result.GetValue(9).ToString() : (string)null,
                                    colada = result.GetValue(10).ToString() != "" ? result.GetValue(10).ToString() : (string)null,
                                    expediente = result.GetValue(11).ToString() != "" ? result.GetValue(11).ToString() : (string)null,
                                    codigo = result.GetValue(12).ToString() != "" ? result.GetValue(12).ToString() : (string)null,
                                    tratamientotermico = result.GetValue(13).ToString() != "" ? result.GetValue(13).ToString() : (string)null,
                                    fechepedido = result.GetValue(14).ToString() != "" ? result.GetValue(14).ToString() : (string)null,
                                    fechaesperado = result.GetValue(15).ToString() != "" ? result.GetValue(15).ToString() : (string)null,
                                    entregado = result.GetValue(16).ToString() != "" ? result.GetValue(16).ToString() : (string)null,
                                    idpadre = result.GetValue(17).ToString() != "" ? result.GetValue(17).ToString() : (string)null,
                                    idestado = result.GetValue(18).ToString() != "" ? result.GetValue(18).ToString() : (string)null,
                                    prioridad = result.GetValue(19).ToString() != "" ? result.GetValue(19).ToString() : (string)null,

                                    secuencia = result.GetValue(20).ToString() != "" ? result.GetValue(20).ToString() : (string)null,
                                    cliente = result.GetValue(21).ToString() != "" ? result.GetValue(21).ToString() : (string)null,
                                    ubicacion = result.GetValue(22).ToString() != "" ? result.GetValue(22).ToString() : (string)null,
                                });








                                //          list.Add(result.)

                                //         var a = result.GetValue(0); //id
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

        //api/Patrons/getPatternsByFilter
        [HttpGet("getPatternsByFilter")]
        public List<patronaux> getPatternsByFilter(string strQuery)
        {
            byte[] data = Convert.FromBase64String(strQuery); //17/09/2019
            strQuery = System.Text.Encoding.UTF8.GetString(data);//17/09/2019


            List<patronaux> list = new List<patronaux>();
            try
            {
                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {

                    command.CommandText = strQuery;

                    _context.Database.OpenConnection();

                    using (var result = command.ExecuteReader())
                    {
                        // do something with result
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                //  var a = result.GetValue(21).ToString();


                                list.Add(new patronaux
                                {
                                    Cliente = result.GetValue(26).ToString(), //
                                    Diametro = Double.Parse(result.GetValue(6).ToString()),//
                                    Espesor = Double.Parse(result.GetValue(7).ToString()),//
                                    Descripcion = result.GetValue(2).ToString(),//
                                    type = result.GetValue(15).ToString(),//
                                    Codigo = result.GetValue(19).ToString(),//
                                    Ciclo = Int32.Parse(result.GetValue(9).ToString()),//
                                    Longitud = Double.Parse(result.GetValue(5).ToString()),
                                    Colada = Int32.Parse(result.GetValue(10).ToString()),
                                    Expediente = result.GetValue(11).ToString(),
                                    Acero = result.GetValue(8).ToString(),//
                                    Grado = result.GetValue(20).ToString(),//
                                    TratamientoTermico = result.GetValue(14).ToString(),//
                                    estado = result.GetValue(23).ToString(),//
                                    Ubicacion = result.GetValue(24).ToString(),//
                                    requisito = result.GetValue(25).ToString(),//
                                    UltimaPasada = DateTime.Parse(result.GetValue(16).ToString()),//
                                    NroMaxPasadas = Int32.Parse(result.GetValue(4).ToString()),//
                                    IdPedido = result.GetValue(21).ToString() != "" ? Int32.Parse(result.GetValue(21).ToString()) : (int?)null,


                                    Id = Int32.Parse(result.GetValue(1).ToString()),//



                                });








                                //          list.Add(result.)

                                //         var a = result.GetValue(0); //id
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

        //api/Patrons/QryVerDefectosIntra
        [HttpGet("QryVerDefectosIntra/{IdPedido}")]
        public List<patronaux> QryVerDefectosIntra(long IdPedido)
        {
            List<patronaux> list = new List<patronaux>();


            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                SqlParameter param = new SqlParameter();
                SqlParameter param2 = new SqlParameter();

                command.CommandText = " exec  QryVerDefectosIntra @TipoBusque, @IdPedido ";

                param.ParameterName = "@TipoBusque";
                param.Value = 0;
                command.Parameters.Add(param);

                param2.ParameterName = "@IdPedido";
                param2.Value = IdPedido;
                command.Parameters.Add(param2);


                _context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    // do something with result
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {


                            list.Add(new patronaux
                            {
                                Pasillo = result.GetValue(22).ToString() != "" ? result.GetValue(22).ToString() : (string)null,


                                Cuerpo = result.GetValue(23).ToString() != "" ? result.GetValue(23).ToString() : (string)null,


                                Nivel = result.GetValue(24).ToString() != "" ? result.GetValue(24).ToString() : (string)null,

                                Casilla = result.GetValue(25).ToString() != "" ? result.GetValue(25).ToString() : (string)null,

                                linea = result.GetValue(29).ToString(),//
                                estado = result.GetValue(21).ToString(),//
                                motivo = result.GetValue(28).ToString(),//

                            });
                        }
                    }
                }
            }




            return list;
        }


        /// ////////////////////////////////////////////////////////////////////

        //api/Patrons/qryTRKPatron
        [HttpGet("qryTRKPatron/{IdPatron}")]
        public List<history> qryTRKPatron(long IdPatron)
        {
            List<history> list = new List<history>();


            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                SqlParameter param = new SqlParameter();
                SqlParameter param2 = new SqlParameter();

                command.CommandText = " exec  qryTRKPatron @idPatron ";

                param.ParameterName = "@idPatron";
                param.Value = IdPatron;
                command.Parameters.Add(param);



                _context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    // do something with result
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {



                            list.Add(new history
                            {
                                pasillo = result.GetValue(0).ToString() != "" ? result.GetValue(0).ToString() : (string)null,

                                cuerpo = result.GetValue(1).ToString() != "" ? result.GetValue(0).ToString() : (string)null,

                                nivel = result.GetValue(2).ToString() != "" ? result.GetValue(0).ToString() : (string)null,

                                casilla = result.GetValue(3).ToString() != "" ? result.GetValue(0).ToString() : (string)null,

                                linea = result.GetValue(4).ToString(),//
                                estado = result.GetValue(5).ToString(),//
                                fecha = result.GetValue(6).ToString()//

                            });
                        }
                    }
                }
            }




            return list;
        }





        /// ////////////////////////////////////////////////////////////////////

        //api/Patrons/doChkCapacity
        [HttpGet("doChkCapacity/{idLinea}")]
        public int doChkCapacity(long idLinea)
        {
            string r = "";

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                SqlParameter param = new SqlParameter();
                SqlParameter param2 = new SqlParameter();

                command.CommandText = " exec  doChkCapacity @idLine ";

                param.ParameterName = "@idLine";
                param.Value = idLinea;
                command.Parameters.Add(param);

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




            return Int32.Parse(r);
        }



        /// ////////////////////////////////////////////////////////////////////

        //api/Patrons/úpdatepatron
        [HttpGet("úpdatepatron/{pasillo}/{cuerpo}/{nivel}/{casilla}/{idEstado}/{idMotivo}/{idPatron}/{registrousuario}")]
        public int úpdatepatron(string pasillo, string cuerpo, string nivel, string casilla, long idEstado, long idMotivo, long idPatron, string registrousuario)
        {
            string r = "";

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                /*       SqlParameter param = new SqlParameter();
                       SqlParameter param2 = new SqlParameter();

                       command.CommandText = " exec  doChkCapacity @idLine ";

                       param.ParameterName = "@idLine";
                       param.Value = idLinea;
                       command.Parameters.Add(param);

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
                       }*/
            }




            return Int32.Parse(r);
        }























        private bool PatronExists(int id)
        {
            return _context.Patron.Any(e => e.Id == id);
        }
    }
}
