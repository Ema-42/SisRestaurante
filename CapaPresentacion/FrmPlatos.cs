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
    public partial class FrmPlatos : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public FrmPlatos()
        {
            //mostrar el mensaje de ayuda ttMensaje
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el nombre de la categoria");

        }
        //Mostar mensaje de confirmacion , luego llamaremos a cada metodo cuando lo necesitemos
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Restaurante", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        //Mostrar mensaje de error

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Restaurante", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        //Limpiar todos los controles del formulario
        private void Limpiar()
        {
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtPrecio.Text = string.Empty;
            this.txtTiempo.Text = string.Empty;
            this.txtIdplato.Text = string.Empty;
        }
        //habiliatr los controles de los formulario , recible un valor para habilitar o deshabilitar los campos
        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.txtPrecio.ReadOnly = !valor;
            this.txtTiempo.ReadOnly = !valor;
            this.txtIdplato.ReadOnly = !valor;
        }
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }
        //Metodo para ocultar columanas es decir el la de eliminar de nuestro data grid y la de los id de nuestra BD
        //solo mostratr nombre y descripcion
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }
        //Metodo mostrar  el total de mis registros
        private void Mostrar()
        {
            this.dataListado.DataSource = NPlatos.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros : " + Convert.ToString(dataListado.Rows.Count);
        }

        //Buscar nombre Metodo
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NPlatos.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros : " + Convert.ToString(dataListado.Rows.Count);
        }

        //este evento se carga cuando el fomulario se muestra o se carga la vista
        private void FrmPlatos_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        //buscar con el boton buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        //buscar articulos minetras se modifica la tex box
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        //TAB FORMULARIO

        //para agregar un nuevo artiticulo
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();

        }

        //para registrar una nueva categoria
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                //evaluar caja de texto
                if (this.txtNombre.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, seran remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese un Nombre");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        //insertar un nuevo registro, mandamos los parametros
                        rpta = NPlatos.Insertar(this.txtNombre.Text.Trim().ToUpper(), this.txtDescripcion.Text.Trim(), Convert.ToDecimal(this.txtPrecio.Text), Convert.ToInt32(this.txtTiempo.Text));
                    }
                    else
                    {
                        //este es el caso de editar un registro
                        rpta = NPlatos.Editar(Convert.ToInt32(this.txtIdplato.Text),
                            this.txtNombre.Text.Trim().ToUpper(), this.txtDescripcion.Text.Trim(), 
                            Convert.ToDecimal(this.txtPrecio.Text), Convert.ToInt32(this.txtTiempo.Text));
                    }
                    //la respuesta que nos devuelve el metodo insertar de DCategoria
                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se incerto de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se Actualizo de forma correcta el registro");
                        }
                    }
                    //caundo no se resive un ok
                    else
                    {
                        this.MensajeError(rpta);
                    }
                    //nuevamente dejo deshabilitado y limpio el form
                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                }

            }
            //capturador de errores
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }




        //ir datalistado/eventos/doble click,   para cargar los datos en el formulario y poder editar
        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdplato.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idplato"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["descripcion"].Value);
            this.txtPrecio.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["precio"].Value);
            this.txtTiempo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tiempo"].Value);
            this.tabControl1.SelectedIndex = 1;
        }
        //editar un registro
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdplato.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a modificar");
            }
        }
        //cancelar la operacion y desabiliatar las cajas de texto
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        //se actiav el chek box para que se pueda seleccionar y eliminar
        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            //si el checked esta marcado
            if (chkEliminar.Checked)
            {
                //visibilizar la columna de eliminar
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        //doble click sobre el data listado para activar
        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //habilitamos la seleccion de de los check del data listado
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }
        //eliminar los registros que esten marcados
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                //mensaje en pantalla 
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente desea eliminar los registros", "Sistema de Restaurante", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    //envair la llave primaria
                    string Codigo;

                    string Rpta = "";

                    //revisa fila por fila si la columa esta marcada
                    //
                    foreach (DataGridViewRow row in dataListado.Rows)
                    {

                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            // guardamos el id
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            //pasar a CapaNegocio ->CapaDatos -> Proc Almacenados
                            Rpta = NPlatos.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se elimino correctamente el registro");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }
                        }
                    }
                    //cargar los datos
                    this.Mostrar();
                    chkEliminar.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

    }
}
