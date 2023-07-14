using Semana2.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana2.Patterns
{
    class FactoryHelado
    {

        public Helado CrearHelado(bool crema, bool choco, bool fresa)
        {
            if (crema)
            {
                return new Crema();
            }
            if (choco)
                return new Chocolate();

            if (fresa) return new Fresa();

            throw new ApplicationException("El sabor no existe");
        }
    }
}
