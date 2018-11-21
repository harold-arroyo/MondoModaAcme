using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MondoModaAcme.Models
{
    public class TipoProducto
    {
        [Key]
        public int Id { get ; set ; }
        [Required]
        [StringLength (50)]
        public string NombreTipo { get; set; }
        [StringLength(250)]
        public string Descripcion { get; set; }
        public ICollection<Insumo> Insumo { get; set; }
    }
}
