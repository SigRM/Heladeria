using Semana2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana2.Clases
{
    class Cono
    {
        public Helado Helado { set; get; }
        public List<ITopping> Toppings { get; set; }

        #region Singleton
        private static Cono instance;

        /// <summary>
        /// OJO constructor privado !
        /// </summary>
        private Cono() { }

        /// <summary>
        /// Obtener Instancia
        /// </summary>
        public static Cono GetInstance()
        {

            // Si la instancia es NULL osea NO SE HA CREADO 
            // entonces debe crearla
            if (instance == null)
            {
                instance = new Cono();
            }

            // Si no entra al IF anterior devuelve la Instancia actual
            return instance;

        }
        #endregion

    }
}
