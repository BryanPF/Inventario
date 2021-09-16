using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Model
{
    public class Producto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id_Producto { get; set; }
        public int codigo { get; set; }
        public string descripcion_producto { get; set; }
        public double precio { get; set; }
        public int stock { get; set; }
        public int iva { get; set; }
        public double peso { get; set; }


        [ForeignKey("marca")]
        public int id_marca { get; set; }
        [ForeignKey("presentacion")]
        public int id_presentacion { get; set; }
        [ForeignKey("proveedor")]
        public int id_proveedor { get; set; }
        [ForeignKey("zona")]
        public int id_zona { get; set; }


    }
}
