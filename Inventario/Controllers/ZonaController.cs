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
    public class ZonaController : ControllerBase
    {
        private InventarioContext _db;
        private readonly ILogger<ZonaController> _logger;

        public ZonaController(ILogger<ZonaController> logger, InventarioContext db)
        {
            _logger = logger;
            _db = db;
        }


        // GET: api/zona
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ZonaDTO>>> ObtenerZona()
        {
            try
            {
                var result = from z in _db.zona
                             select new ZonaDTO
                             {
                                 id_zona = z.id_zona,
                                 descripcion = z.descripcion

                             };
                return Ok(await result.ToListAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        // GET api/zona/id
        [HttpGet("{id}")]
        public async Task<ActionResult<ZonaDTO>> ObtenerZona(int id)
        {
            Zona zonaEF = await _db.zona.FindAsync(id);

            if (zonaEF != null)
            {
                ZonaDTO zonaDTO = new ZonaDTO
                {
                    id_zona = zonaEF.id_zona,
                    descripcion = zonaEF.descripcion
                };
                return zonaDTO;

            }
            else
                return NotFound();
        }



        // POST api/zona
        [HttpPost]
        public async Task<ActionResult<ZonaDTO>> AgregarZona(ZonaDTO zona)
        {
            try
            {
                Zona zon = new Zona
                {

                    descripcion = zona.descripcion

                };

                _db.zona.Add(zon);
                int result = await _db.SaveChangesAsync();
                if (result > 0)
                {
                    return CreatedAtAction("AgregarZona", new { status = "Agregado exitosamente" });
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

        // PUT api/zona/id
        [HttpPut("{id}")]
        public async Task<ActionResult<ZonaDTO>> EditarZona(ZonaDTO zona)
        {
            try
            {
                Zona zonaEF = _db.zona.Find(zona.id_zona);
                if (zonaEF != null)
                {
                    zonaEF.id_zona = zona.id_zona;
                    zonaEF.descripcion = zona.descripcion;

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
                    return NotFound($"No hemos encontrado una zona con el id {zona.id_zona}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/zona/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<ZonaDTO>> EliminarZona(int id)
        {
            try
            {
                Zona zonaEF = _db.zona.Find(id);
                if (zonaEF != null)
                {
                    _db.zona.Remove(zonaEF);
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
                    return NotFound($"No hemos encontrado una zona con el id {id}");
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
