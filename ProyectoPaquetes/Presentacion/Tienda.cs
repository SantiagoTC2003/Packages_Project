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
    public partial class Tienda : Form
    {
        public Tienda()
        {
            InitializeComponent();
            CargarArticulos();
        }

        public List<Articulo> ListaCargadaA { get; set; }

        private void CargarArticulos(List<Articulo> P_Lista = null)
        {
            //Definicion de variables temporales
            List<Articulo> lstresultado = new List<Articulo>();
            DataTable dt = new DataTable();

            //No viene lista para cargar, se consulta a BD
            if (P_Lista == null)
            {
                lstresultado = Logica.ConsultarAR(new Articulo());
                ListaCargadaA = lstresultado;
            }
            else
                lstresultado = P_Lista;

            //Creacion de columnas por mostrar
            dt.Columns.Add("IDArticulo");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Descripcion");
            dt.Columns.Add("Precio");
            dt.Columns.Add("Empresa");
            
            //Aqui se recorre la lista con su metodo ForEach existente gracias a System.Collection.Generic
            lstresultado.ForEach(item =>
            {
                dt.Rows.Add(item.IDArticulo, item.Nombre, item.Descripcion, item.Precio, item.Descripcion, item.Empresa);
            });

            //Asignacion de fuente de datos
            dgvTienda.DataSource = dt;
            dgvTienda.Refresh();

            //Formateo sobre el grid
            dgvTienda.Columns[0].Width = 107;
            dgvTienda.Columns[1].Width = 107;
            dgvTienda.Columns[2].Width = 107;
            dgvTienda.Columns[3].Width = 107;
            dgvTienda.Columns[4].Width = 107;
        }

        private bool Validar(int P_Accion = 0)
        {
            //if (string.IsNullOrEmpty(txt.Text))
            if (txtPaquete.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe ingresar el id del paquete", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPaquete.Focus();
                return false;
            }

            if (P_Accion != 3)
            { //3 = Eliminar
                //if (string.IsNullOrEmpty(txtClave.Text))
                if (txtCliente.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Debe ingresar el id del cliente ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCliente.Focus();
                    return false;
                }

                if (txtArticulo.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Debe ingresar el id del articulo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtArticulo.Focus();
                    return false;
                }

                if (txtDurabilidad.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Debe ingresar una descripcion", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDurabilidad.Focus();
                    return false;
                }

            }
            return true;
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar())
                {
                    Paquete obj = new Paquete
                    {
                        IDPaquete = txtPaquete.Text.Trim(),
                        IDCliente = txtCliente.Text.Trim(),
                        IDArticulo = txtArticulo.Text.Trim(),
                        Entregado = false,
                        Descripcion = txtDurabilidad.Text.Trim(),
                        Fecha = DateTime.Now
                    };
                    //Para buscar el monedero del cliente
                    List<Cliente> lstresultado1 = new List<Cliente>();
                    lstresultado1 = Logica.ConsultarC(new Cliente());
                    Cliente c = new Cliente
                    {
                        IDCliente = txtCliente.Text.Trim()
                    };
                    c = lstresultado1.First();
                    //Para determinar el precio del articulo
                    List<Articulo> lstresultado2 = new List<Articulo>();
                    lstresultado2 = Logica.ConsultarAR(new Articulo());
                    Articulo a = new Articulo
                    {
                        IDArticulo = txtArticulo.Text.Trim()
                    };
                    a = lstresultado2.First();
                    int m = c.Dinero;
                    int p = a.Precio;
                    int r = m - p;
                    if (r<=0) {
                        ResultadoP objresultado = Logica.AgregarP(obj);
                        MessageBox.Show(objresultado.MensajePaquete, "Aviso", MessageBoxButtons.OK, objresultado.ResultadoOperacion ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Dinero insuficiente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
