using Semana2.Clases;
using Semana2.Interfaces;
using Semana2.Patterns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semana2
{
    public partial class FrmHeladeria : Form, IObserver
    {
        public static bool HayInstancia = true;
        public static FrmHeladeria InstanciaActiva = null;

        public FrmHeladeria()
        {
            InitializeComponent();
            rdbCrema.Checked = true;
        }
        //Metodo predefinido del patron Observer
        public void Update(string message)
        {
            txtTotal.Text = message;
        }

        OrdenCompra orderCompra;

        private void FrmHeladeria_Load(object sender, EventArgs e)
        {
            HayInstancia = true;
            InstanciaActiva = this;
      }

        private void FrmHeladeria_FormClosed(object sender, FormClosedEventArgs e)
        {
            HayInstancia = false;
            InstanciaActiva = null;
        }

        private void btnCrearOrden_Click(object sender, EventArgs e)
        {
            try
            {
                OrdenCompra orden = new OrdenCompra();
                frmTotal frm = new frmTotal();

                //Metodo predefinido del patron Observer
                orden.Register(this);
                orden.Register(frm);

                frm.Show();

                //if (rbtCrema.Checked)
                //{
                //    Helado c = new Crema();
                //    orden.AgregarHelado(c);
                //}

                orden.AgregarHelado(new FactoryHelado().CrearHelado
                    (rdbCrema.Checked, rdbChocolate.Checked, rdbFresa.Checked));                //if (rbtChocolate.Checked)
                //    orden.AgregarHelado(new Chocolate());

                //if (rbtFresa.Checked)
                //    orden.AgregarHelado(new Fresa());

                if (chkCaramelo.Checked)
                    orden.AgregarTopping(new Caramelo());

                if (chkMani.Checked)
                    orden.AgregarTopping(new Mani());

                if (chkOreo.Checked)
                    orden.AgregarTopping(new Oreo());

                orden.Notify();//Metodo predefinido del patron Observer
                //txtTotal.Text = orden.CalcularTotal().ToString();               
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message);
                string s = ex.StackTrace;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message);
            }
        }
    }

  }

