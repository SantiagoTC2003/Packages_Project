using Entidades;
using Negocio;
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
    public partial class CreacionCliente : Form
    {
        public CreacionCliente()
        {
            InitializeComponent();
        }

        //Para entregar el perfil seleccionado
        private string Perfil()
        {
            if (rbtCliente.Checked)
            {
                return "Cliente";
            }
            if (rbtFuncionario.Checked)
            {
                return "Funcionario";
            }
            else
            {
                return "";
            }
        }

        private bool ValidarC(int P_Accion = 0)
        {
            //if (string.IsNullOrEmpty(txt.Text))
            if (txtId.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe ingresar un ID", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtId.Focus();
                return false;
            }

            if (P_Accion != 3)
            { //3 = Eliminar
                //if (string.IsNullOrEmpty(txtClave.Text))
                if (txtContraseña.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Debe ingresar una Contraseña ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContraseña.Focus();
                    return false;
                }

                if (txtNombre.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Debe ingresar un nombre", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return false;
                }

                if (txtDinero.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Debe ingresar una cantidad de dinero", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDinero.Focus();
                    return false;
                }

                if (txtDireccion.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Debe ingresar una direccion", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDireccion.Focus();
                    return false;
                }

                if (txtCorreo.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Debe ingresar un correo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCorreo.Focus();
                    return false;
                }

                if (rbtCliente.Checked == false)
                {
                    if (rbtFuncionario.Checked == false)
                        MessageBox.Show("Debe seleccionar un perfil", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }


            }
            return true;
        }

        private bool ValidarA(int P_Accion = 0)
        {
            //if (string.IsNullOrEmpty(txt.Text))
            if (txtIDAutorizacion.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe ingresar un Id para el autorizado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIDAutorizacion.Focus();
                return false;
            }

            if (P_Accion != 3)
            { //3 = Eliminar
                //if (string.IsNullOrEmpty(txtClave.Text))
                if (txtId.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Debe ingresar su ID", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtId.Focus();
                    return false;
                }

                if (txtNombreAutorizacion.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Debe ingresar un nombre", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombreAutorizacion.Focus();
                    return false;
                }

            }
            return true;
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarC())
                {
                    Cliente obj = new Cliente
                    {
                        IDCliente = txtId.Text.Trim(),
                        Nombre = txtNombre.Text.Trim(),
                        Contraseña = txtContraseña.Text.Trim(),
                        CorreoE = txtCorreo.Text.Trim(),
                        Direccion= txtDireccion.Text.Trim(),
                        Dinero = Convert.ToInt32(txtDinero.TextLength.ToString()),
                        IDPerfil = Perfil()
                    };

                    ResultadoC objresultado = Logica.AgregarC(obj);
                    MessageBox.Show(objresultado.MensajeCliente, "Aviso", MessageBoxButtons.OK, objresultado.ResultadoOperacion ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                    if (Logica.AutenticacionC(obj))
                    {
                        Tienda frm = new Tienda();
                        frm.Show();
                        this.Hide(); //Esconde el frm de login
                    }

                    if (Logica.AutenticacionF(obj))
                    {
                        MenuFuncionario frm = new MenuFuncionario();
                        frm.Show();
                        this.Hide(); //Esconde el frm de login
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAutorizacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarA())
                {
                    Autorizacion obj = new Autorizacion
                    {
                        IDAutorizacion = txtIDAutorizacion.Text.Trim(),
                        IDCliente = txtId.Text.Trim(),
                        Nombre = txtNombre.Text.Trim(),
                    };

                    ResultadoAu objresultado = Logica.AgregarAu(obj);
                    MessageBox.Show(objresultado.MensajeAutorizacion, "Aviso", MessageBoxButtons.OK, objresultado.ResultadoOperacion ? MessageBoxIcon.Information : MessageBoxIcon.Warning);                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
