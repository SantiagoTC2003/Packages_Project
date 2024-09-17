using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class MenuFuncionario : Form
    {
        public MenuFuncionario()
        {
            InitializeComponent();
        }

        private void btnRutas_Click(object sender, EventArgs e)
        {
            PantallaRuta frm = new PantallaRuta();
            frm.Show();
            this.Hide();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            PantallaCliente frm = new PantallaCliente();
            frm.Show();
            this.Hide();
        }

        private void btnPaquetes_Click(object sender, EventArgs e)
        {
            PantallaPaquete frm = new PantallaPaquete();
            frm.Show();
            this.Hide();
        }
    }
}
