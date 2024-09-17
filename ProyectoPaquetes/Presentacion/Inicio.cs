using System;
using System.Timers;
using Entidades;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace Presentacion
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        int a = 0;
        System.Timers.Timer  b= new System.Timers.Timer(3600000);

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Cliente usuario = new Cliente
            {
                 Nombre = txtNombre.Text.Trim(),
                 Contraseña = txtContraseña.Text.Trim()
            };

            if(txtContraseña.Text == "LCPR0001")
            {
                if (Logica.AutenticacionCnp(usuario))
                {
                    Tienda frm = new Tienda();
                    frm.Show();
                    this.Hide(); //Esconde el frm de login
                }
            }

            if (txtContraseña.Text == "LWPR0001")
            {
                if (Logica.AutenticacionFnp(usuario))
                {
                    Tienda frm = new Tienda();
                    frm.Show();
                    this.Hide(); //Esconde el frm de login
                }
            }

            if (b.Enabled == false)
            {
                try
                {
                    if (Logica.AutenticacionC(usuario))
                    {
                        Tienda frm = new Tienda();
                        frm.Show();
                        this.Hide(); //Esconde el frm de login
                    }

                    if (Logica.AutenticacionF(usuario))
                    {
                        MenuFuncionario frm = new MenuFuncionario();
                        frm.Show();
                        this.Hide(); //Esconde el frm de login
                    }
                    else
                        MessageBox.Show("Usuario y/o contraseña incorrectos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    a++;
                    if (a == 3)
                    {
                        MessageBox.Show("Entrada bloqueada, debe esperar una hora", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        b.Start();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            CreacionCliente frm = new CreacionCliente();
            frm.Show();
            this.Hide(); //Esconde el frm de login
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PantallaCorreo frm = new PantallaCorreo();
            frm.Show();
            this.Hide(); //Esconde el frm de login
        }
    }
}
