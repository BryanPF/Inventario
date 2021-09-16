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
    public class ProveedorController : ControllerBase
    {
        private InventarioContext _db;
        private readonly ILogger<ProveedorController> _logger;

        public ProveedorController(ILogger<ProveedorController> logger, InventarioContext db)
        {
            _logger = logger;
            _db = db;
        }


        // GET: api/proveedor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProveedorDTO>>> ObtenerProveedor()
        {
            try
            {
                var result = from pro in _db.proveedor
                             select new ProveedorDTO
                             {
                                 id_proveedor = pro.id_proveedor,
                                 descripcion = pro.descripcion

                             };
                return Ok(await result.ToListAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        // GET api/proveedor/id
        [HttpGet("{id}")]
        public async Task<ActionResult<ProveedorDTO>> ObtenerProveedor(int id)
        {
            Proveedor proveEF = await _db.proveedor.FindAsync(id);

            if (proveEF != null)
            {
                ProveedorDTO proDTO = new ProveedorDTO
                {
                    id_proveedor = proveEF.id_proveedor,
                    descripcion = proveEF.descripcion
                };
                return proDTO;

            }
            else
                return NotFound();
        }



        // POST api/proveedor
        [HttpPost]
        public async Task<ActionResult<ProveedorDTO>> AgregarProveedor(ProveedorDTO prove)
        {
            try
            {
                Proveedor pro = new Proveedor
                {

                    descripcion = prove.descripcion

                };

                _db.proveedor.Add(pro);
                int result = await _db.SaveChangesAsync();
                if (result > 0)
                {
                    return CreatedAtAction("AgregarProveedor", new { status = "Agregado exitosamente" });
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

        // PUT api/proveedor/id
        [HttpPut("{id}")]
        public async Task<ActionResult<ProveedorDTO>> EditarProveedor(ProveedorDTO prove)
        {
            try
            {
                Proveedor proEF = _db.proveedor.Find(prove.id_proveedor);
                if (proEF != null)
                {
                    proEF.id_proveedor = prove.id_proveedor;
                    proEF.descripcion = prove.descripcion;

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
                    return NotFound($"No hemos encontrado un proveedor con el id {prove.id_proveedor}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/proveedor/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProveedorDTO>> EliminarProveedor(int id)
        {
            try
            {
                Proveedor proveEF = _db.proveedor.Find(id);
                if (proveEF != null)
                {
                    _db.proveedor.Remove(proveEF);
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
                    return NotFound($"No hemos encontrado un proveedor con el id {id}");
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
