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
    public partial class PantallaCliente : Form
    {
        public PantallaCliente()
        {
            InitializeComponent();
            CargarClientes();
        }

        public List<Cliente> ListaCargadaC { get; set; }

        private void Limpiar() ///Para hacer limpiesa despues de cada accion
        {
            txtIDCliente.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtContraseña.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtDinero.Text = string.Empty;
            txtPerfil.Text = string.Empty;
        }

        private void CargarClientes(List<Cliente> P_Lista = null)
        {
            //Definicion de variables temporales
            List<Cliente> lstresultado = new List<Cliente>();
            DataTable dt = new DataTable();

            //No viene lista para cargar, se consulta a BD
            if (P_Lista == null)
            {
                lstresultado = Logica.ConsultarC(new Cliente());
                ListaCargadaC = lstresultado;
            }
            else
                lstresultado = P_Lista;

            //Creacion de columnas por mostrar
            dt.Columns.Add("IDCliente");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Contraseña");
            dt.Columns.Add("CorreoE");
            dt.Columns.Add("Direccion");
            dt.Columns.Add("Dinero");
            dt.Columns.Add("IDPerfil");


            //Aqui se recorre la lista con su metodo ForEach existente gracias a System.Collection.Generic
            lstresultado.ForEach(item =>
            {
                dt.Rows.Add(item.IDCliente, item.Nombre, item.Contraseña, item.CorreoE, item.Direccion, item.Dinero, item.IDPerfil);
            });

            //Asignacion de fuente de datos
            dgvCliente.DataSource = dt;
            dgvCliente.Refresh();

            //Formateo sobre el grid
            dgvCliente.Columns[0].Width = 107;
            dgvCliente.Columns[1].Width = 107;
            dgvCliente.Columns[2].Width = 107;
            dgvCliente.Columns[3].Width = 107;
            dgvCliente.Columns[4].Width = 107;
            dgvCliente.Columns[5].Width = 107;
            dgvCliente.Columns[6].Width = 107;
        }

        private void CargarClientesPorID(List<Cliente> P_Lista = null)
        {
            //Definicion de variables temporales
            List<Cliente> lstresultado = new List<Cliente>();
            DataTable dt = new DataTable();

            //No viene lista para cargar, se consulta a BD
            if (P_Lista == null)
            {
                Cliente obj = new Cliente
                {
                    IDCliente = txtIDCliente.Text.Trim()
                };
                lstresultado = Logica.ConsultarCporID(obj);
                ListaCargadaC = lstresultado;
            }
            else
                lstresultado = P_Lista;

            //Creacion de columnas por mostrar
            dt.Columns.Add("IDCliente");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Contraseña");
            dt.Columns.Add("CorreoE");
            dt.Columns.Add("Direccion");
            dt.Columns.Add("Dinero");
            dt.Columns.Add("IDPerfil");


            //Aqui se recorre la lista con su metodo ForEach existente gracias a System.Collection.Generic
            lstresultado.ForEach(item =>
            {
                dt.Rows.Add(item.IDCliente, item.Nombre, item.Contraseña, item.CorreoE, item.Direccion, item.Dinero, item.IDPerfil);
            });

            //Asignacion de fuente de datos
            dgvCliente.DataSource = dt;
            dgvCliente.Refresh();

            //Formateo sobre el grid
            dgvCliente.Columns[0].Width = 107;
            dgvCliente.Columns[1].Width = 107;
            dgvCliente.Columns[2].Width = 107;
            dgvCliente.Columns[3].Width = 107;
            dgvCliente.Columns[4].Width = 107;
            dgvCliente.Columns[5].Width = 107;
            dgvCliente.Columns[6].Width = 107;
        }

        private bool Validar(int P_Accion = 0)
        {
            //if (string.IsNullOrEmpty(txt.Text))
            if (txtIDCliente.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe ingresar un ID", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIDCliente.Focus();
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

                if (txtPerfil.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Debe ingresar un Perfil", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPerfil.Focus();
                    return false;
                }


            }
            return true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    Cliente obj = new Cliente
                    {
                        IDCliente = txtIDCliente.Text.Trim(),
                        Nombre = txtNombre.Text.Trim(),
                        Contraseña = txtContraseña.Text.Trim(),
                        CorreoE = txtCorreo.Text.Trim(),
                        Direccion = txtDireccion.Text.Trim(),
                        Dinero = Convert.ToInt32(txtDinero.TextLength.ToString()),
                        IDPerfil = txtPerfil.Text.Trim()
                    };

                    ResultadoC objresultado = Logica.AgregarC(obj);
                    MessageBox.Show(objresultado.MensajeCliente, "Aviso", MessageBoxButtons.OK, objresultado.ResultadoOperacion ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                    CargarClientes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            CargarClientesPorID();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    Cliente obj = new Cliente
                    {
                        IDCliente = txtIDCliente.Text.Trim(),
                        Nombre = txtNombre.Text.Trim(),
                        Contraseña = txtContraseña.Text.Trim(),
                        CorreoE = txtCorreo.Text.Trim(),
                        Direccion = txtDireccion.Text.Trim(),
                        Dinero = Convert.ToInt32(txtDinero.TextLength.ToString()),
                        IDPerfil = txtPerfil.Text.Trim()
                    };

                    ResultadoC objresultado = Logica.ModificarC(obj);
                    MessageBox.Show("Cliente Modificado correctamente", "Aviso", MessageBoxButtons.OK, objresultado.ResultadoOperacion ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                    CargarClientes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar(3))
                {

                    Cliente obj = new Cliente
                    {
                        IDCliente = txtIDCliente.Text.Trim(),
                    };

                    ResultadoC objresultado = Logica.EliminarC(obj);
                    MessageBox.Show(objresultado.MensajeCliente, "Aviso", MessageBoxButtons.OK, objresultado.ResultadoOperacion ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                    Limpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            MenuFuncionario frm = new MenuFuncionario();
            frm.Show();
            this.Hide(); //Esconde el frm de login
        }
    }
}
