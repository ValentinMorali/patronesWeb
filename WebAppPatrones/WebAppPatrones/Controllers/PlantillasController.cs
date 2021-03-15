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
    public class PlantillasController : ControllerBase
    {
        private readonly OperationsDbContext _context;

        public PlantillasController(OperationsDbContext context)
        {
            _context = context;
        }

        // GET: api/Plantillas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plantilla>>> GetPlantilla()
        {

            List<Plantilla> list = new List<Plantilla>();
            List<Plantilla> result = new List<Plantilla>();

    


            List<Plantilla> listaux =await _context.Plantilla.ToListAsync();

            listaux.Add(new Plantilla
            {
                IdPlantilla = 0,
                Nombre = "Ninguna"
            });

            return listaux.OrderBy(b => b.IdPlantilla).ToArray();

        }

        // GET: api/Plantillas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Plantilla>> GetPlantilla(int id)
        {
  
            var plantilla = await _context.Plantilla.FindAsync(id);

            if (plantilla == null)
            {
                return NotFound();
            }

            return plantilla;
        }

        // PUT: api/Plantillas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlantilla(int id, Plantilla plantilla)
        {
            if (id != plantilla.IdPlantilla)
            {
                return BadRequest();
            }

            _context.Entry(plantilla).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantillaExists(id))
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

        // POST: api/Plantillas
        [HttpPost]
        public async Task<ActionResult<Plantilla>> PostPlantilla(Plantilla plantilla)
        {
            _context.Plantilla.Add(plantilla);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlantilla", new { id = plantilla.IdPlantilla }, plantilla);
        }

        // DELETE: api/Plantillas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Plantilla>> DeletePlantilla(int id)
        {
            var plantilla = await _context.Plantilla.FindAsync(id);
            if (plantilla == null)
            {
                return NotFound();
            }

            _context.Plantilla.Remove(plantilla);
            await _context.SaveChangesAsync();

            return plantilla;
        }



        /// ////////////////////////////////////////////////////////////////////

        //api/Tipos/GetTubeTypes
        [HttpGet("DoCopiarDefectosPlantilla/{IdPlantilla}/{IdPedido}")]
        public void DoCopiarDefectosPlantilla(int idPlantilla, int idPedido)
        {

            try {
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                SqlParameter param = new SqlParameter();
                SqlParameter param2 = new SqlParameter();

                command.CommandText = " exec [DoCopiarDefectosPlantilla] @IdPlantilla, @IdPedido ";

                param.ParameterName = "@IdPlantilla";
                param.Value = idPlantilla;
                command.Parameters.Add(param);

                param2.ParameterName = "@IdPedido";
                param2.Value = idPedido;
                command.Parameters.Add(param2);


                _context.Database.OpenConnection();

                    using (var result = command.ExecuteReader())
                    {
                        // do something with result
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {

                                var a= result.GetValue(0).ToString();

                            }
                        }
                    }

                }
            }
            catch(Exception e)
            {
                var a = 0;
            }

        }


















        private bool PlantillaExists(int id)
        {
            return _context.Plantilla.Any(e => e.IdPlantilla == id);
        }
    }
}
