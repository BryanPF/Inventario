using Inventario.Model;
using Inventario.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresentacionController : ControllerBase
    {
        private InventarioContext _db;
        private readonly ILogger<PresentacionController> _logger;

        public PresentacionController(ILogger<PresentacionController> logger, InventarioContext db)
        {
            _logger = logger;
            _db = db;
        }


        // GET: api/presentacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PresentacionDTO>>> ObtenerPresentacion()
        {
            try
            {
                var result = from pre in _db.presentacion
                             select new PresentacionDTO
                             {
                                 id_presentacion = pre.id_presentacion,
                                 descripcion = pre.descripcion

                             };
                return Ok(await result.ToListAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        // GET api/presentacion/id
        [HttpGet("{id}")]
        public async Task<ActionResult<PresentacionDTO>> ObtenerPresentacion(int id)
        {
            Presentacion presentEF = await _db.presentacion.FindAsync(id);

            if (presentEF != null)
            {
                PresentacionDTO presentacionDTO = new PresentacionDTO
                {
                    id_presentacion = presentEF.id_presentacion,
                    descripcion = presentEF.descripcion
                };
                return presentacionDTO;

            }
            else
                return NotFound();
        }



        // POST api/presentacion
        [HttpPost]
        public async Task<ActionResult<PresentacionDTO>> AgregarPresentcion(PresentacionDTO present)
        {
            try
            {
                Presentacion pre = new Presentacion
                {

                    descripcion = present.descripcion

                };

                _db.presentacion.Add(pre);
                int result = await _db.SaveChangesAsync();
                if (result > 0)
                {
                    return CreatedAtAction("AgregarPresentacion", new { status = "Agregado exitosamente" });
                }
                else
                {
                    return StatusCode(500);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        // PUT api/presentacion/id
        [HttpPut("{id}")]
        public async Task<ActionResult<PresentacionDTO>> EditarPresentacion(PresentacionDTO present)
        {
            try
            {
                Presentacion preseEF = _db.presentacion.Find(present.id_presentacion);
                if (preseEF != null)
                {
                    preseEF.id_presentacion = present.id_presentacion;
                    preseEF.descripcion = present.descripcion;

                    int result = await _db.SaveChangesAsync();
                    if (result > 0)
                    {
                        return Ok(new { status = "Modificado exitosamente" });
                    }
                    else
                    {
                        return StatusCode(500);
                    }
                }
                else
                {
                    return NotFound($"No hemos encontrado una presentacion con el id {present.id_presentacion}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/presentacion/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<PresentacionDTO>> EliminarPresentacion(int id)
        {
            try
            {
                Presentacion presentEF = _db.presentacion.Find(id);
                if (presentEF != null)
                {
                    _db.presentacion.Remove(presentEF);
                    int result = await _db.SaveChangesAsync();
                    if (result > 0)
                    {
                        return Ok(new { status = "Eliminado exitosamente" });
                    }
                    else
                    {
                        return StatusCode(500);
                    }
                }
                else
                {
                    return NotFound($"No hemos encontrado una presentacion con el id {id}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
