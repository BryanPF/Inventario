using Inventario.Model;
using Inventario.Model.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Inventario.Controllers
{
    [EnableCors("InventarioPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private InventarioContext _db;
        private readonly ILogger<ProductoController> _logger;

        public ProductoController(ILogger<ProductoController> logger, InventarioContext db)
        {
            _logger = logger;
            _db = db;
        }


        // GET: api/producto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDTO>>> ObtenerProducto()
        {
            try
            {
                var result = from p in _db.producto
                             select new ProductoDTO
                             {
                                 id_Producto = p.id_Producto,
                                 id_marca = p.id_marca,
                                 id_presentacion = p.id_presentacion,
                                 id_proveedor = p.id_proveedor,
                                 id_zona = p.id_zona,
                                 codigo = p.codigo,
                                 descripcion_producto = p.descripcion_producto,
                                 precio = p.precio,
                                 stock = p.stock,
                                 iva = p.iva,
                                 peso = p.peso

                             };
                return Ok(await result.ToListAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        // GET api/producto/id
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDTO>> ObtenerProducto(int id)
        {
            Producto productoEF = await _db.producto.FindAsync(id);

            if (productoEF != null)
            {
                ProductoDTO productoDTO = new ProductoDTO
                {
                    id_Producto = productoEF.id_Producto,
                    id_marca = productoEF.id_marca,
                    id_presentacion = productoEF.id_presentacion,
                    id_proveedor = productoEF.id_proveedor,
                    id_zona = productoEF.id_zona,
                    codigo = productoEF.codigo,
                    descripcion_producto = productoEF.descripcion_producto,
                    precio = productoEF.precio,
                    stock = productoEF.stock,
                    iva = productoEF.iva,
                    peso = productoEF.peso
                };
                return productoDTO;
            }
            else
                return NotFound();
        }


        // POST api/producto
        [HttpPost]
        public async Task<ActionResult<ProductoDTO>> AgregarPtoducto(ProductoDTO producto)
        {
            try
            {
                Producto product = new Producto
                {
                   
                    id_marca = producto.id_marca,
                    id_presentacion = producto.id_presentacion,
                    id_proveedor = producto.id_proveedor,
                    id_zona = producto.id_zona,
                    codigo = producto.codigo,
                    descripcion_producto = producto.descripcion_producto,
                    precio = (float)producto.precio,
                    stock = producto.stock,
                    iva = producto.iva,
                    peso = (float)producto.peso
                };

                _db.producto.Add(product);
                int result = await _db.SaveChangesAsync();
                if (result > 0)
                {
                    return CreatedAtAction("AgregarProducto", new { status = "Agregado exitosamente" });
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

        // PUT api/producto/id
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductoDTO>> EditarProducto(ProductoDTO producto)
        {
            try
            {
                Producto productoEF = _db.producto.Find(producto.id_Producto);
                if (productoEF != null)
                {
                    productoEF.id_Producto = producto.id_Producto;
                    productoEF.id_marca = producto.id_marca;
                    productoEF.id_presentacion = producto.id_presentacion;
                    productoEF.id_proveedor = producto.id_proveedor;
                    productoEF.id_zona = producto.id_zona;
                    productoEF.codigo = producto.codigo;
                    productoEF.descripcion_producto = producto.descripcion_producto;
                    productoEF.precio = producto.precio;
                    productoEF.stock = producto.stock;
                    productoEF.iva = producto.iva;
                    productoEF.peso = producto.peso;

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
                    return NotFound($"No hemos encontrado un producto con el id {producto.id_Producto}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/producto/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductoDTO>> EliminarProducto(int id)
        {
            try
            {
                Producto productoEF = _db.producto.Find(id);
                if (productoEF != null)
                {
                    _db.producto.Remove(productoEF);
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
                    return NotFound($"No hemos encontrado un producto con el id {id}");
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
