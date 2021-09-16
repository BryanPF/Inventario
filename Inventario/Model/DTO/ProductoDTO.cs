using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Model.DTO
{
    public class ProductoDTO
    {
        public int id_Producto { get; set; }
        public int id_marca { get; set; }
        public int id_presentacion { get; set; }
        public int id_proveedor { get; set; }
        public int id_zona { get; set; }
        public int codigo { get; set; }
        public string descripcion_producto { get; set; }
        public double precio { get; set; }
        public int stock { get; set; }
        public int iva { get; set; }
        public double peso { get; set; }
    }
}
