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
    public class PedidosController : ControllerBase
    {
        private readonly OperationsDbContext _context;

        public PedidosController(OperationsDbContext context)
        {
            _context = context;
        }


        public class set
        {
            public string id { get; set; }
            public string description { get; set; }

        }










        /*

        public Id?:number, 
    public Codigo?:string,
    public Linea?:number,
    public IdTipo?:number,
    public Longitud?:string,
    public Diametro?:string,
    public Espesor?:string,
    public Acero?:string,
    public Grado?:string,
    public TratamientoTermico?:string,
    public Expediente?:string,
    public FechaPedido?:Date,
    public FechaEsperado?:Date,
    public IdPadre?:number,
    public IdEstado?:number,
    public Prioridad?:number,
    public Secuencia?:number,
    public IdRemitente?:number,
    public Cliente?:string,
    public Entregado?:Date,
    public IdBancal?:number,
    public Ciclo?:number,
    public Colada?:number,
    public Producto?:string,
    public Numero?:number,
    public Ubicacion?:string,
    public IdDestino?:number,
    public NotificarAuditor?:boolean,
    public Traceability?:number,
    public Acustica?:boolean,
    public Auditor?:string,
    public FechaUltimaModif?:Date,
    public Motivo?:string,
    public Ot?:string,
    public Obs?:string,
            */

        // GET: api/Pedidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedidos>>> GetPedidos()
        {
            return await _context.Pedidos.ToListAsync();
        }

        // GET: api/Pedidos/5
        [HttpGet("GetPedidosByCode/{code}")]
        public  Pedidos GetPedidosByCode(string code)
        {
            var pedidos =  _context.Pedidos.Where(t => t.Codigo == code).FirstOrDefault();

   
            return pedidos;
        }



        // GET: api/Pedidos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedidos>> GetPedidos(int id)
        {
            var pedidos = await _context.Pedidos.FindAsync(id);

            if (pedidos == null)
            {
                return NotFound();
            }

            return pedidos;
        }

        // PUT: api/Pedidos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedidos(int id, Pedidos pedidos)
        {
            if (id != pedidos.Id)
            {
                return BadRequest();
            }

            _context.Entry(pedidos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidosExists(id))
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

        // POST: api/Pedidos
        [HttpPost]
        public async Task<ActionResult<Pedidos>> PostPedidos(string pedidosaux)
        {
            var pedidos = JsonConvert.DeserializeObject<Pedidos>(pedidosaux);

            _context.Pedidos.Add(pedidos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedidos", new { id = pedidos.Id }, pedidos);
        }

        // DELETE: api/Pedidos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pedidos>> DeletePedidos(int id)
        {
            var pedidos = await _context.Pedidos.FindAsync(id);
            if (pedidos == null)
            {
                return NotFound();
            }

            _context.Pedidos.Remove(pedidos);
            await _context.SaveChangesAsync();

            return pedidos;
        }


        /////////////////////////////////////////////////////////////////////////////



        /// ////////////////////////////////////////////////////////////////////

        //api/Pedidos/GetTubeTypes
        [HttpGet("qryProximoNumeroFromPedido/{IdTipoTubo}/{planta}")]
        public int qryProximoNumeroFromPedido(long IdTipoTubo, long planta)
        {
            //    List<tubetypes> list = new List<tubetypes>();
            string r="";


            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                SqlParameter param = new SqlParameter();
                SqlParameter param2 = new SqlParameter();

                command.CommandText = " exec  qryProximoNumeroFromPedido @Tipo, @Planta ";

                param.ParameterName = "@Tipo";
                param.Value = IdTipoTubo;
                command.Parameters.Add(param);

                param2.ParameterName = "@Planta";
                param2.Value = planta;
                command.Parameters.Add(param2);


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




            return int.Parse(r);
        }

        /// ////////////////////////////////////////////////////////////////////

        //api/Pedidos/GetTubeTypes
        [HttpGet("GetLastIdPedido")]
        public int GetLastIdPedido()
        {
            return _context.Pedidos.Last().Id;
        }

        /// ////////////////////////////////////////////////////////////////////

        [HttpPost("updateOrder")]
        public async Task<ActionResult<Pedidos>> updateOrder(string pedidosaux)
        {
            var pedido = JsonConvert.DeserializeObject<Pedidos>(pedidosaux);

            /*
            Pedidos Pedidoaux = new Pedidos
            {
                Id = pedido.Id,
                Longitud= pedido.Longitud,
                Diametro= pedido.Diametro,
                Espesor= pedido.Espesor,
                Acero= pedido.Acero,
                Grado= pedido.Grado,
                TratamientoTermico= pedido.TratamientoTermico,
                Ciclo= pedido.Ciclo,
                Expediente= pedido.Expediente,
                Colada= pedido.Colada,
                Cliente = pedido.Cliente,
                Auditor = pedido.Auditor,
                Acustica = pedido.Acustica,
                NotificarAuditor = pedido.NotificarAuditor,
                Traceability = pedido.Traceability,
                Prioridad = pedido.Prioridad,
                Ubicacion = pedido.Ubicacion
            };
            */
            var aux2 = _context.Pedidos.Where(l => l.Id == pedido.Id).FirstOrDefault(); //consultas por ID en la tabla 'lead'
            aux2.Longitud = pedido.Longitud;
            aux2.Diametro = pedido.Diametro;
            aux2.Espesor = pedido.Espesor;
            aux2.Acero = pedido.Acero;
            aux2.Grado = pedido.Grado;
            aux2.TratamientoTermico = pedido.TratamientoTermico;
            aux2.Ciclo = pedido.Ciclo;
            aux2.Expediente = pedido.Expediente;
            aux2.Colada = pedido.Colada;
            aux2.Cliente = pedido.Cliente;
            aux2.Auditor = pedido.Auditor;
            aux2.Acustica = pedido.Acustica;
            aux2.NotificarAuditor = pedido.NotificarAuditor;
            aux2.Traceability = pedido.Traceability;
            aux2.Prioridad = pedido.Prioridad;
            aux2.Ubicacion = pedido.Ubicacion;

            _context.SaveChanges();  //guardas cambios

            return null;
        }


        /// /////////////////////////////////////////////////////////////////////////////////

        [HttpPost("updatestate/{idPedido}")]
        public async Task<ActionResult<Pedidos>> updateOrder(long idPedido)
        {
     
            var aux2 = _context.Pedidos.Where(l => l.Id == idPedido).FirstOrDefault(); //consultas por ID en la tabla 'lead'
            aux2.IdEstado = 1;
            _context.SaveChanges();  //guardas cambios

            return null;
        }



        /// ////////////////////////////////////////////////////////////////////

        //api/Pedidos/uservalidate
        [HttpGet("uservalidate/{idpedido}/{user}")]
        public string uservalidate(long idpedido, string user)
        {
            string r = "";

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
  

                command.CommandText = " select NRegistro from pedidos, remitentes where pedidos.IdRemitente = Remitentes.Id and pedidos.Id=" + idpedido + " and Remitentes.NRegistro= '" + user + "' ";

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
            return r;
        }




        /// ////////////////////////////////////////////////////////////////////

        //api/Pedidos/deleteordercomplete
        [HttpGet("deleteordercomplete/{idpedido}")]
        public int deleteordercomplete(long idpedido)
        {
            //    List<tubetypes> list = new List<tubetypes>();
            string r = "";


            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                SqlParameter param = new SqlParameter();
                SqlParameter param2 = new SqlParameter();

                command.CommandText = " delete from valoresatributospedido where iddefecto in (select id from defectospedido where idpedido = " + idpedido + ") " +
                                       " delete from defectospedido where IdPedido = " + idpedido +
                                       " delete from patron where IdPedido = " + idpedido +
                                       " delete from pedidos where Id = " + idpedido +" ";


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
























        private bool PedidosExists(int id)
        {
            return _context.Pedidos.Any(e => e.Id == id);
        }
    }
}
