using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MondoModaAcme.Models
{
    public class Insumo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdTipoProducto { get; set; }
        [Required]
        [StringLength(50)]
        public string NombreProducto { get; set; }
        [StringLength(250)]
        public string Descripcion { get; set; }
        [Required]
        [StringLength(45)]        
        public string Proveedor { get; set; }
        [Required]
        public int cantidad { get; set; }
        public TipoProducto IdTipoProductoNavigation { get; set; }
    }
}
