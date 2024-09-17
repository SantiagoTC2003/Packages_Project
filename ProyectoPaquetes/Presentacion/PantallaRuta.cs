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
    public partial class PantallaRuta : Form
    {
        public PantallaRuta()
        {
            InitializeComponent();
            CargarRutas();
            CargarLocalizaciones();
        }

        public List<Ruta> ListaCargadaR { get; set; }
        public List<Localizacion> ListaCargadaL { get; set; }
        private void LimpiarR() ///Para hacer limpiesa despues de cada accion
        {
            txtIDRuta.Text = string.Empty;
            txtLocalizacion.Text = string.Empty;
            txtFecha.Text = string.Empty;
            txtPaquete.Text = string.Empty;
        }

        private void LimpiarL() ///Para hacer limpiesa despues de cada accion
        {
            txtLocalizacionOriginal.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
        }

        private void Limpiar() ///Para hacer limpiesa despues de cada accion
        {
            txtLocalizacionOriginal.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtIDRuta.Text = string.Empty;
            txtLocalizacion.Text = string.Empty;
            txtFecha.Text = string.Empty;
            txtPaquete.Text = string.Empty;
        }

        private void CargarRutas(List<Ruta> P_Lista = null)
        {
            //Definicion de variables temporales
            List<Ruta> lstresultado = new List<Ruta>();
            DataTable dt = new DataTable();

            //No viene lista para cargar, se consulta a BD
            if (P_Lista == null)
            {
                lstresultado = Logica.ConsultarR(new Ruta());
                ListaCargadaR = lstresultado;
            }
            else
                lstresultado = P_Lista;

            //Creacion de columnas por mostrar
            dt.Columns.Add("IDRuta");
            dt.Columns.Add("IDPaquete");
            dt.Columns.Add("Fecha");
            dt.Columns.Add("IDLocalizacion");
            

            //Aqui se recorre la lista con su metodo ForEach existente gracias a System.Collection.Generic
            lstresultado.ForEach(item =>
            {
                dt.Rows.Add(item.IDRuta, item.IDPaquete, item.Fecha, item.IDLocalizacion);
            });

            //Asignacion de fuente de datos
            dgvRuta.DataSource = dt;
            dgvRuta.Refresh();

            //Formateo sobre el grid
            dgvRuta.Columns[0].Width = 107;
            dgvRuta.Columns[1].Width = 107;
            dgvRuta.Columns[2].Width = 107;
            dgvRuta.Columns[3].Width = 107;
        }

        private void CargarRutasPorPaquete(List<Ruta> P_Lista = null)
        {
            //Definicion de variables temporales
            List<Ruta> lstresultado = new List<Ruta>();
            DataTable dt = new DataTable();

            //No viene lista para cargar, se consulta a BD
            if (P_Lista == null)
            {
                Ruta obj = new Ruta
                {
                    IDPaquete = txtPaquete.Text.Trim()
                };
                lstresultado = Logica.ConsultarRporPaquete(obj);
                ListaCargadaR = lstresultado;
            }
            else
                lstresultado = P_Lista;

            //Creacion de columnas por mostrar
            dt.Columns.Add("IDRuta");
            dt.Columns.Add("IDPaquete");
            dt.Columns.Add("Fecha");
            dt.Columns.Add("IDLocalizacion");


            //Aqui se recorre la lista con su metodo ForEach existente gracias a System.Collection.Generic
            lstresultado.ForEach(item =>
            {
                dt.Rows.Add(item.IDRuta, item.IDPaquete, item.Fecha, item.IDLocalizacion);
            });

            //Asignacion de fuente de datos
            dgvRuta.DataSource = dt;
            dgvRuta.Refresh();

            //Formateo sobre el grid
            dgvRuta.Columns[0].Width = 107;
            dgvRuta.Columns[1].Width = 107;
            dgvRuta.Columns[2].Width = 107;
            dgvRuta.Columns[3].Width = 107;
        }

        private void CargarLocalizaciones(List<Localizacion> P_Lista = null)
        {
            //Definicion de variables temporales
            List<Localizacion> lstresultado = new List<Localizacion>();
            DataTable dt = new DataTable();

            //No viene lista para cargar, se consulta a BD
            if (P_Lista == null)
            {
                lstresultado = Logica.ConsultarL(new Localizacion());
                ListaCargadaL = lstresultado;
            }
            else
                lstresultado = P_Lista;

            //Creacion de columnas por mostrar
            dt.Columns.Add("IDLocalizacion");
            dt.Columns.Add("Descripcion");
            
            //Aqui se recorre la lista con su metodo ForEach existente gracias a System.Collection.Generic
            lstresultado.ForEach(item =>
            {
                dt.Rows.Add(item.IDLocalizacion, item.Descripcion);
            });

            //Asignacion de fuente de datos
            dgvLocalizacion.DataSource = dt;
            dgvLocalizacion.Refresh();

            //Formateo sobre el grid
            dgvLocalizacion.Columns[0].Width = 107;
            dgvLocalizacion.Columns[1].Width = 107;
        }

        private void btnAgregarR_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarR())
                {
                    Ruta obj = new Ruta
                    {
                        IDRuta = txtIDRuta.Text.Trim(),
                        IDPaquete = txtPaquete.Text.Trim(),
                        Fecha = Convert.ToDateTime(txtFecha.Text.Trim()),
                        IDLocalizacion = txtLocalizacion.Text.Trim(),
                    };

                    ResultadoR objresultado = Logica.AgregarR(obj);
                    MessageBox.Show(objresultado.MensajeRuta, "Aviso", MessageBoxButtons.OK, objresultado.ResultadoOperacion ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                    LimpiarR();
                    CargarRutas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool ValidarR(int P_Accion = 0)
        {
            //if (string.IsNullOrEmpty(txt.Text))
            if (txtIDRuta.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe ingresar el ID de ruta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIDRuta.Focus();
                return false;
            }

            if (P_Accion != 3)
            { //3 = Eliminar
                //if (string.IsNullOrEmpty(txtClave.Text))
                if (txtPaquete.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Debe ingresar el id del paquete ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPaquete.Focus();
                    return false;
                }

                if (txtFecha.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Debe ingresar una fecha", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFecha.Focus();
                    return false;
                }

                if (txtLocalizacion.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Debe ingresar el id de la localizacion", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLocalizacion.Focus();
                    return false;
                }

            }
            return true;
        }

        private bool ValidarL(int P_Accion = 0)
        {
            //if (string.IsNullOrEmpty(txt.Text))
            if (txtLocalizacionOriginal.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe ingresar un ID", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLocalizacionOriginal.Focus();
                return false;
            }

            if (P_Accion != 3)
            { //3 = Eliminar
                //if (string.IsNullOrEmpty(txtClave.Text))
                if (txtDescripcion.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Debe ingresar una descripcion ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDescripcion.Focus();
                    return false;
                }

            }
            return true;
        }

        private void btnAgregarL_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarL())
                {
                    Localizacion obj = new Localizacion
                    {
                        IDLocalizacion = txtLocalizacionOriginal.Text.Trim(),
                        Descripcion = txtDescripcion.Text.Trim()
                    };

                    ResultadoL objresultado = Logica.AgregarL(obj);
                    MessageBox.Show(objresultado.MensajeLocalizacion, "Aviso", MessageBoxButtons.OK, objresultado.ResultadoOperacion ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                    LimpiarL();
                    CargarLocalizaciones();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModificarR_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarR())
                {
                    Ruta obj = new Ruta
                    {
                        IDRuta = txtIDRuta.Text.Trim(),
                        IDPaquete = txtPaquete.Text.Trim(),
                        Fecha = Convert.ToDateTime(txtFecha.Text.Trim()),
                        IDLocalizacion = txtLocalizacion.Text.Trim(),
                    };

                    ResultadoR objresultado = Logica.ModificarR(obj);
                    MessageBox.Show("Ruta Modificada correctamente", "Aviso", MessageBoxButtons.OK, objresultado.ResultadoOperacion ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                    LimpiarR();
                    CargarRutas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModificarL_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarL())
                {
                    Localizacion obj = new Localizacion
                    {
                        IDLocalizacion = txtLocalizacionOriginal.Text.Trim(),
                        Descripcion = txtDescripcion.Text.Trim()
                    };

                    ResultadoL objresultado = Logica.ModificarL(obj);
                    MessageBox.Show("Localizacion Modificada correctamente", "Aviso", MessageBoxButtons.OK, objresultado.ResultadoOperacion ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                    LimpiarL();
                    CargarLocalizaciones();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminarR_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarR(3))
                {

                    Ruta obj = new Ruta
                    {
                        IDRuta = txtIDRuta.Text.Trim(),
                    };

                    ResultadoR objresultado = Logica.EliminarR(obj);
                    MessageBox.Show(objresultado.MensajeRuta, "Aviso", MessageBoxButtons.OK, objresultado.ResultadoOperacion ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                    CargarRutas();
                    LimpiarR();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminarL_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarL(3))
                {

                    Localizacion obj = new Localizacion
                    {
                        IDLocalizacion = txtLocalizacionOriginal.Text.Trim(),
                    };

                    ResultadoL objresultado = Logica.EliminarL(obj);
                    MessageBox.Show(objresultado.MensajeLocalizacion, "Aviso", MessageBoxButtons.OK, objresultado.ResultadoOperacion ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                    CargarLocalizaciones();
                    LimpiarL();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSeleccionarR_Click(object sender, EventArgs e)
        {
            CargarRutasPorPaquete();
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
