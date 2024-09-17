using System;
using Negocio;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class PantallaCorreo : Form
    {
        public PantallaCorreo()
        {
            InitializeComponent();
        }

        private void EnvioCorreo()
        {
            Logica.EnvioCorreo();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Thread hiloenvio = new Thread(EnvioCorreo);
            hiloenvio.Start();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Inicio frm = new Inicio();
            frm.Show();
            this.Hide(); //Esconde el frm de login
        }
    }
}
