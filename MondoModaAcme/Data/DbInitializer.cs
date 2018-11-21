using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MondoModaAcme.Models;

namespace MondoModaAcme.Data
{
    public class DbInitializer
    {
        public static void Initialize(MondoModaAcmeContext context)
        {
            context.Database.EnsureCreated();
            if (context.Insumo.Any())
            {

            }
            if (context.TipoProducto.Any())
            {

            }
        }
    }
}
