using Semana2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana2.Clases
{
    class OrdenCompra
    {

        private Cono cono;
      //  public List<Helado> helados = new List<Helado>();
        private List<IObserver> observadores;


        public OrdenCompra()
        {
            cono = Cono.GetInstance();
            cono.Toppings = new List<ITopping>();
            observadores = new List<IObserver>();
        }

        public void AgregarHelado(Helado helado)
        {
            cono.Helado= helado;
        }

        public void AgregarTopping(ITopping topping)
        {
            cono.Toppings.Add(topping);
        }

        public double CalcularTotal()
        {
            double total = 0;

            if (cono != null)
            {
                total += cono.Helado.Costo();
                total += cono.Toppings.Sum(x => x.Precio);
            }

            return total;

        }

        //Metodos predefinidos para aplicar el patron Observer
        public void Notify()
        {
            string msg = this.CalcularTotal().ToString("0.00");
            foreach (var ob in observadores)
            {
                ob.Update(msg);
            }
        }

        public void Register(IObserver obs)
        {
            observadores.Add(obs);
        }

        public void Remove(IObserver obs)
        {
            observadores.Remove(obs);
        }



    }
}

