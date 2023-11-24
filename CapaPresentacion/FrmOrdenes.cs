using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
namespace CapaPresentacion
{
    public partial class FrmOrdenes : Form
    {

        //variable para poder enviar el idusuario desde la frmPrincipal
        public int Idusuario;

        private bool IsNuevo;
        //para almacenar los detalles de la orden
        private DataTable dtDetalle;
        //para almacenar el total de la orden
        private decimal total = 0;


        private static FrmOrdenes _instancia;
        //Metodo para crear un instancia, solo si no hay una , 
        public static FrmOrdenes GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new FrmOrdenes();
            }
            return _instancia;
        }

        //recibe los valores para cliente desde los formulario
        public void setCliente(string idcliente, string nombre)
        {
            this.txtIdcliente.Text = idcliente;
            this.txtCliente.Text = nombre;
        }
        //recibe valores para producto...
        public void setProducto(string idproducto, string nombre, string precio)
        {
            this.txtIdproducto.Text = idproducto;
            this.txtProducto.Text = nombre;
            this.txtPrecio_Original.Text = precio;
            this.txtPrecio_Venta.Text = precio;

        }

        //AGREGAR FORMULARIO EXTRA FRMVISTAPRODCUTO_ORDEN

        public FrmOrdenes()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtCliente, "Seleccione el clinte");
            this.ttMensaje.SetToolTip(this.txtProducto, "Ingrese el producto");
            this.ttMensaje.SetToolTip(this.txtCantidad, "Ingrese una cantidad");
            this.ttMensaje.SetToolTip(this.txtPrecio_Venta, "Puede cambia el precio del item");
            this.txtIdcliente.Visible = false;
            this.txtIdproducto.Visible = false;
            this.txtCliente.ReadOnly = true;
            this.txtProducto.ReadOnly = true;
        }


        //Mostar Mensaje de confiramcion
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        //Mostrar mensaje de error

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        //Limpiar todos los controles del formulario
        private void Limpiar()
        {
            this.txtIdcliente.Text = string.Empty;
            this.txtIdorden.Text = string.Empty;
            this.txtCliente.Text = string.Empty;
            this.crearTabla();

        }

        private void limpiarDetalle()
        {
            this.txtProducto.Text = string.Empty;
            this.txtPrecio_Original.Text = string.Empty;
            this.txtPrecio_Venta.Text = string.Empty;
            this.txtIdproducto.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
            this.lblTotal_Pagado.Text = "0,0";
        }
        //habiliatr los controles de los formulario
        private void Habilitar(bool valor)
        {
            this.txtIdorden.ReadOnly = !valor;
            this.txtIdcliente.ReadOnly = !valor;
            this.txtCliente.ReadOnly = !valor;
            this.txtProducto.ReadOnly = !valor;
            this.dtFecha.Enabled = valor;
            this.txtPrecio_Original.ReadOnly = valor;
            this.txtPrecio_Venta.ReadOnly = valor;
            this.txtCantidad.ReadOnly = !valor;
            this.txtIdproducto.ReadOnly = valor;


            this.btnBuscarCliente.Enabled = valor;
            this.btnBuscarProducto.Enabled = valor;
            this.btnAgregar.Enabled = valor;
            this.btnQuitar.Enabled = valor;
        }

        //habilitar los botones

        private void Botones()
        {
            if (this.IsNuevo)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;

            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
        }

        //Metodo para ocultar columanas de la tabla art

        private void OcultarColumnas()
        {

            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;


        }

        //Metodo mostar

        private void Mostrar()
        {
            this.dataListado.DataSource = NOrdenes.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros : " + Convert.ToString(dataListado.Rows.Count);
        }

        //Metodo buscar por fecha

        private void BuscarFechas()
        {
            this.dataListado.DataSource = NOrdenes.BuscarFechas(this.dtFecha1.Value.ToString("dd/MM/yyyy"));
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros : " + Convert.ToString(dataListado.Rows.Count);
        }


        private void MostrarDetalle()
        {
            this.dataListadoDetalle.DataSource = NOrdenes.MostrarDetalle(this.txtIdorden.Text);
        }


        private void FrmOrdenes_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.crearTabla();
        }

        //al cerrar quitar las instancias
        private void FrmOrdenes_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            FrmVistaCliente_Orden vista = new FrmVistaCliente_Orden();
            vista.ShowDialog();
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            FromVistaProducto_Orden vista = new FromVistaProducto_Orden();
            vista.ShowDialog(); 
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFechas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente desea Anular los registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    //revisa fila por fila si la columa esta marcada
                    foreach (DataGridViewRow row in dataListado.Rows)
                    {

                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NOrdenes.Anular(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Anuló correctamente la orden");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }
                        }
                    }
                    this.Mostrar();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }
        private void crearTabla()
        {
            //usamos la variable que declaramos en un inicio
            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("idproducto", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("item", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("precio", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("cantidad", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));
            //Relacionar nuetsro DataGridview con nuestro DataTable
            this.dataListadoDetalle.DataSource = this.dtDetalle;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtCliente.Focus();
            this.limpiarDetalle();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            this.limpiarDetalle();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtIdcliente.Text == string.Empty || this.txtCliente.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, seran remarcados");
                    errorIcono.SetError(txtCliente, "Ingrese un Valor");

                }
                else
                {
                    if (this.IsNuevo)
                    {
                        //de acuerdo a los parametros que espera NOrdenes
                        rpta = NOrdenes.Insertar(Idusuario, Convert.ToInt32(this.txtIdcliente.Text),
                            dtFecha.Value, "1", dtDetalle);
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se inserto de forma correcta el registro");
                        }

                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                    this.IsNuevo = false;
                    this.Botones();
                    this.Limpiar();
                    this.limpiarDetalle();
                    this.Mostrar();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtIdproducto.Text == string.Empty || this.txtProducto.Text == string.Empty
                    || this.txtCantidad.Text == string.Empty || this.txtPrecio_Venta.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, seran remarcados");
                    errorIcono.SetError(txtProducto, "Ingrese un Valor");
                    errorIcono.SetError(txtIdcliente, "Ingrese un Valor");
                    errorIcono.SetError(txtCantidad, "Ingrese un Valor");
                    errorIcono.SetError(txtPrecio_Venta, "Ingrese un Valor");
                }
                else
                {
                    bool registrar = true;
                    //Para verificar si ya esta agregado
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["idproducto"]) == Convert.ToInt32(this.txtIdproducto.Text))
                        {
                            registrar = false;
                            this.MensajeError("Ya se encuentra el Item en el detalle");
                        }
                    }
                    if (registrar)
                    {
                        decimal subTotal = Convert.ToDecimal(this.txtCantidad.Text) * Convert.ToDecimal(this.txtPrecio_Venta.Text);
                        total = total+ subTotal;
                        this.lblTotal_Pagado.Text = total.ToString("#0.00##");
                        //Agreagr ese detalle al datalistado detalle
                        DataRow row = this.dtDetalle.NewRow();
                        row["idproducto"] = Convert.ToInt32(this.txtIdproducto.Text);
                        row["item"] = this.txtProducto.Text;
                        row["precio"] = Convert.ToDecimal(this.txtPrecio_Venta.Text);
                        row["cantidad"] = Convert.ToInt32(this.txtCantidad.Text);
                        row["subtotal"] = subTotal;
                        this.dtDetalle.Rows.Add(row);
                        this.limpiarDetalle();


                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                int indiceFila = this.dataListadoDetalle.CurrentCell.RowIndex;
                DataRow row = this.dtDetalle.Rows[indiceFila];
                //Disminuir el total pagado
                this.total = this.total - Convert.ToDecimal(row["subtotal"].ToString());
                this.lblTotal_Pagado.Text = total.ToString("#0.00##");
                //removemos la fila
                this.dtDetalle.Rows.Remove(row);
            }
            catch (Exception ex)
            {
                MensajeError("No hay fila para remover");
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdorden.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idorden"].Value);
            this.txtCliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cliente"].Value);
            //this.txtIdcliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cliente"].Value);
            this.dtFecha.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fecha"].Value);
            //this.lblTotal_Pagado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["total"].Value);
            this.MostrarDetalle();
            this.tabControl1.SelectedIndex = 1;
        }
    }
}
