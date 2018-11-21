using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MondoModaAcme.Models;

namespace MondoModaAcme.Models
{
    public class MondoModaAcmeContext : DbContext
    {
        public MondoModaAcmeContext (DbContextOptions<MondoModaAcmeContext> options)
            : base(options)
        {
        }

        public DbSet<MondoModaAcme.Models.TipoProducto> TipoProducto { get; set; }

        public DbSet<MondoModaAcme.Models.Insumo> Insumo { get; set; }
    }
}
