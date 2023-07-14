using Semana2.Interfaces;
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
    public partial class frmTotal : Form, IObserver//Metodo predefinido del patron Observer
    {
        public frmTotal()
        {
            InitializeComponent();
        }

        public void Update(string pMensaje)
        {
            label1.Text = pMensaje;
        }

        private void frmTotal_Load(object sender, EventArgs e)
        {

        }
    }
}
