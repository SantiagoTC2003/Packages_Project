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
    public partial class PantallaPaquete : Form
    {
        public PantallaPaquete()
        {
            InitializeComponent();
        }

        public List<Paquete> ListaCargadaP { get; set; }

        private void Limpiar() ///Para hacer limpiesa despues de cada accion
        {
            txtIDCliente.Text = string.Empty;
            txtIDPaquete.Text = string.Empty;
            txtIDArticulo.Text = string.Empty;
            txtDescrpcion.Text = string.Empty;
            txtFecha.Text = string.Empty;
        }

        private void CargarPaquetes(List<Paquete> P_Lista = null)
        {
            //Definicion de variables temporales
            List<Paquete> lstresultado = new List<Paquete>();
            DataTable dt = new DataTable();

            //No viene lista para cargar, se consulta a BD
            if (P_Lista == null)
            {
                lstresultado = Logica.ConsultarP(new Paquete());
                ListaCargadaP = lstresultado;
            }
            else
                lstresultado = P_Lista;

            //Creacion de columnas por mostrar
            dt.Columns.Add("IDPaquete");
            dt.Columns.Add("IDCliente");
            dt.Columns.Add("IDArticulo");
            dt.Columns.Add("Entregado");
            dt.Columns.Add("Descripcion");
            dt.Columns.Add("Fecha");
            
            //Aqui se recorre la lista con su metodo ForEach existente gracias a System.Collection.Generic
            lstresultado.ForEach(item =>
            {
                dt.Rows.Add(item.IDPaquete, item.IDCliente, item.IDArticulo, item.Entregado ? "Si":"No", item.Descripcion, item.Entregado ? "Si" : "No", item.Fecha);
            });

            //Asignacion de fuente de datos
            dgvPaquete.DataSource = dt;
            dgvPaquete.Refresh();

            //Formateo sobre el grid
            dgvPaquete.Columns[0].Width = 107;
            dgvPaquete.Columns[1].Width = 107;
            dgvPaquete.Columns[2].Width = 107;
            dgvPaquete.Columns[3].Width = 107;
            dgvPaquete.Columns[4].Width = 107;
            dgvPaquete.Columns[5].Width = 107;
        }

        private void CargarPaquetesID(List<Paquete> P_Lista = null)
        {
            //Definicion de variables temporales
            List<Paquete> lstresultado = new List<Paquete>();
            DataTable dt = new DataTable();

            //No viene lista para cargar, se consulta a BD
            if (P_Lista == null)
            {
                Paquete a = new Paquete
                {
                    IDPaquete = txtIDPaquete.Text.Trim()
                };
                lstresultado = Logica.ConsultarP(a);
                ListaCargadaP = lstresultado;
            }
            else
                lstresultado = P_Lista;

            //Creacion de columnas por mostrar
            dt.Columns.Add("IDPaquete");
            dt.Columns.Add("IDCliente");
            dt.Columns.Add("IDArticulo");
            dt.Columns.Add("Entregado");
            dt.Columns.Add("Descripcion");
            dt.Columns.Add("Fecha");

            //Aqui se recorre la lista con su metodo ForEach existente gracias a System.Collection.Generic
            lstresultado.ForEach(item =>
            {
                dt.Rows.Add(item.IDPaquete, item.IDCliente, item.IDArticulo, item.Entregado ? "Si" : "No", item.Descripcion, item.Entregado ? "Si" : "No", item.Fecha);
            });

            //Asignacion de fuente de datos
            dgvPaquete.DataSource = dt;
            dgvPaquete.Refresh();

            //Formateo sobre el grid
            dgvPaquete.Columns[0].Width = 107;
            dgvPaquete.Columns[1].Width = 107;
            dgvPaquete.Columns[2].Width = 107;
            dgvPaquete.Columns[3].Width = 107;
            dgvPaquete.Columns[4].Width = 107;
            dgvPaquete.Columns[5].Width = 107;
        }

        private void CargarPaquetesFecha(List<Paquete> P_Lista = null)
        {
            //Definicion de variables temporales
            List<Paquete> lstresultado = new List<Paquete>();
            DataTable dt = new DataTable();

            //No viene lista para cargar, se consulta a BD
            if (P_Lista == null)
            {
                Paquete a = new Paquete
                {
                    Fecha = Convert.ToDateTime(txtFecha.Text.Trim())
                };
                lstresultado = Logica.ConsultarP(a);
                ListaCargadaP = lstresultado;
            }
            else
                lstresultado = P_Lista;

            //Creacion de columnas por mostrar
            dt.Columns.Add("IDPaquete");
            dt.Columns.Add("IDCliente");
            dt.Columns.Add("IDArticulo");
            dt.Columns.Add("Entregado");
            dt.Columns.Add("Descripcion");
            dt.Columns.Add("Fecha");

            //Aqui se recorre la lista con su metodo ForEach existente gracias a System.Collection.Generic
            lstresultado.ForEach(item =>
            {
                dt.Rows.Add(item.IDPaquete, item.IDCliente, item.IDArticulo, item.Entregado ? "Si" : "No", item.Descripcion, item.Entregado ? "Si" : "No", item.Fecha);
            });

            //Asignacion de fuente de datos
            dgvPaquete.DataSource = dt;
            dgvPaquete.Refresh();

            //Formateo sobre el grid
            dgvPaquete.Columns[0].Width = 107;
            dgvPaquete.Columns[1].Width = 107;
            dgvPaquete.Columns[2].Width = 107;
            dgvPaquete.Columns[3].Width = 107;
            dgvPaquete.Columns[4].Width = 107;
            dgvPaquete.Columns[5].Width = 107;
        }

        private void CargarPaquetesDescripcion(List<Paquete> P_Lista = null)
        {
            //Definicion de variables temporales
            List<Paquete> lstresultado = new List<Paquete>();
            DataTable dt = new DataTable();

            //No viene lista para cargar, se consulta a BD
            if (P_Lista == null)
            {
                Paquete a = new Paquete
                {
                    Descripcion = txtDescrpcion.Text.Trim()
                };
                lstresultado = Logica.ConsultarP(a);
                ListaCargadaP = lstresultado;
            }
            else
                lstresultado = P_Lista;

            //Creacion de columnas por mostrar
            dt.Columns.Add("IDPaquete");
            dt.Columns.Add("IDCliente");
            dt.Columns.Add("IDArticulo");
            dt.Columns.Add("Entregado");
            dt.Columns.Add("Descripcion");
            dt.Columns.Add("Fecha");

            //Aqui se recorre la lista con su metodo ForEach existente gracias a System.Collection.Generic
            lstresultado.ForEach(item =>
            {
                dt.Rows.Add(item.IDPaquete, item.IDCliente, item.IDArticulo, item.Entregado ? "Si" : "No", item.Descripcion, item.Entregado ? "Si" : "No", item.Fecha);
            });

            //Asignacion de fuente de datos
            dgvPaquete.DataSource = dt;
            dgvPaquete.Refresh();

            //Formateo sobre el grid
            dgvPaquete.Columns[0].Width = 107;
            dgvPaquete.Columns[1].Width = 107;
            dgvPaquete.Columns[2].Width = 107;
            dgvPaquete.Columns[3].Width = 107;
            dgvPaquete.Columns[4].Width = 107;
            dgvPaquete.Columns[5].Width = 107;
        }

        private bool Validar(int P_Accion = 0)
        {
            //if (string.IsNullOrEmpty(txt.Text))
            if (txtIDPaquete.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe ingresar el id del paquete", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIDPaquete.Focus();
                return false;
            }

            if (P_Accion != 3)
            { //3 = Eliminar
                //if (string.IsNullOrEmpty(txtClave.Text))
                if (txtIDCliente.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Debe ingresar el id del cliente ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIDCliente.Focus();
                    return false;
                }

                if (txtIDArticulo.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Debe ingresar el id del articulo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIDArticulo.Focus();
                    return false;
                }

                if (txtDescrpcion.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Debe ingresar una descripcion", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDescrpcion.Focus();
                    return false;
                }

                if (txtFecha.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Debe ingresar una Fecha", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFecha.Focus();
                    return false;
                }

                if (rbtSi.Checked == false)
                {
                    if (rbtNo.Checked == false)
                        MessageBox.Show("Debe seleccionar un estado de entrega", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    Paquete obj = new Paquete
                    {
                        IDPaquete = txtIDPaquete.Text.Trim(),
                        IDCliente = txtIDCliente.Text.Trim(),
                        IDArticulo = txtIDArticulo.Text.Trim(),
                        Entregado = rbtSi.Checked,
                        Descripcion = txtDescrpcion.Text.Trim(),
                        Fecha = Convert.ToDateTime(txtFecha.TextLength.ToString())
                    };

                    ResultadoP objresultado = Logica.AgregarP(obj);
                    MessageBox.Show(objresultado.MensajePaquete, "Aviso", MessageBoxButtons.OK, objresultado.ResultadoOperacion ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                    CargarPaquetes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    Paquete obj = new Paquete
                    {
                        IDPaquete = txtIDPaquete.Text.Trim(),
                        IDCliente = txtIDCliente.Text.Trim(),
                        IDArticulo = txtIDArticulo.Text.Trim(),
                        Entregado = rbtSi.Checked,
                        Descripcion = txtDescrpcion.Text.Trim(),
                        Fecha = Convert.ToDateTime(txtFecha.TextLength.ToString())
                    };

                    ResultadoP objresultado = Logica.ModificarP(obj);
                    MessageBox.Show("Paquete Modificado correctamente", "Aviso", MessageBoxButtons.OK, objresultado.ResultadoOperacion ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                    CargarPaquetes();
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

                    Paquete obj = new Paquete
                    {
                        IDPaquete = txtIDPaquete.Text.Trim(),
                    };

                    ResultadoP objresultado = Logica.EliminarP(obj);
                    MessageBox.Show(objresultado.MensajePaquete, "Aviso", MessageBoxButtons.OK, objresultado.ResultadoOperacion ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                    Limpiar();
                    CargarPaquetes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPorID_Click(object sender, EventArgs e)
        {
            CargarPaquetesID();
        }

        private void btnPorFecha_Click(object sender, EventArgs e)
        {
            CargarPaquetesFecha();
        }

        private void btnPorDescripcion_Click(object sender, EventArgs e)
        {
            CargarPaquetesDescripcion();
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
