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
    public class MarcaController : ControllerBase
    {
        private InventarioContext _db;
        private readonly ILogger<MarcaController> _logger;

        public MarcaController(ILogger<MarcaController> logger, InventarioContext db)
        {
            _logger = logger;
            _db = db;
        }


        // GET: api/marca
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarcaDTO>>> ObtenerMarca()
        {
            try
            {
                var result = from m in _db.marca
                             select new MarcaDTO
                             {
                               id_marca = m.id_marca,
                               descripcion = m.descripcion

                             };
                return Ok(await result.ToListAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        // GET api/marca/id
        [HttpGet("{id}")]
        public async Task<ActionResult<MarcaDTO>> ObtenerMarca(int id)
        {
            Marca marcaEF = await _db.marca.FindAsync(id);

            if (marcaEF != null)
            {
                MarcaDTO marcaDTO = new MarcaDTO
                {
                    id_marca = marcaEF.id_marca,
                    descripcion = marcaEF.descripcion
                };
                return marcaDTO;
              
            }
            else
                return NotFound();
        }



        // POST api/marca
        [HttpPost]
        public async Task<ActionResult<MarcaDTO>> AgregarMarca(MarcaDTO marca)
        {
            try
            {
                Marca marc = new Marca
                {
                
                    descripcion = marca.descripcion
                  
                };

                _db.marca.Add(marc);
                int result = await _db.SaveChangesAsync();
                if (result > 0)
                {
                    return CreatedAtAction("AgregarMarca", new { status = "Agregado exitosamente" });
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

        // PUT api/marca/id
        [HttpPut("{id}")]
        public async Task<ActionResult<MarcaDTO>> EditarMarca(MarcaDTO marca)
        {
            try
            {
                Marca marcaEF = _db.marca.Find(marca.id_marca);
                if (marcaEF != null)
                {
                    marcaEF.id_marca = marca.id_marca;
                    marcaEF.descripcion = marca.descripcion;

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
                    return NotFound($"No hemos encontrado una marca con el id {marca.id_marca}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/marca/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<MarcaDTO>> EliminarMarca(int id)
        {
            try
            {
                Marca marcaEF = _db.marca.Find(id);
                if (marcaEF != null)
                {
                    _db.marca.Remove(marcaEF);
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
                    return NotFound($"No hemos encontrado una marca con el id {id}");
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
