using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace CapaPresentacion
{
    public partial class FrmUsuarios : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        //para el formulario de roles 
        private static FrmUsuarios _Instancia;
        public static FrmUsuarios GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmUsuarios();
            }
            return _Instancia;
        }

        //Metodo para enviar los valores a la caja de texto

        public void setRol(string idrol, string nombre)
        {
            this.txtIdrol.Text = idrol;
            this.txtRol.Text = nombre;

            this.cbRol.SelectedValue = idrol;
            this.cbRol.DisplayMember = nombre;


        }


        public FrmUsuarios()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombres, "Ingrese el nombre del usuario");
            this.ttMensaje.SetToolTip(this.txtApellidos, "Ingrese el apellidos del usuario");
            this.ttMensaje.SetToolTip(this.txtUsuario, "Ingrese el Usuario para que ingrese al sistema");
            this.ttMensaje.SetToolTip(this.txtPassword, "Ingrese el password de acceso al sistema");
            this.ttMensaje.SetToolTip(this.cbSexo, "Seleccione un genero");

            this.txtIdrol.Visible = false;
            this.txtIdusuario.Visible = false;
            this.txtRol.ReadOnly = true;
            this.LlenarComboRoles();
        }

        //Mostar mensaje de confirmacion
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
            this.txtNombres.Text = string.Empty;
            this.txtApellidos.Text = string.Empty;
            this.txtDocumento.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtCelular.Text = string.Empty;
            this.txtIdrol.Text = string.Empty;
            this.txtRol.Text = string.Empty;
            this.txtUsuario.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
        }

        //habiliatr los controles de los formulario
        private void Habilitar(bool valor)
        {
            this.txtNombres.ReadOnly = !valor;
            this.txtApellidos.ReadOnly = !valor;
            this.txtDocumento.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.txtCelular.ReadOnly = !valor;
            this.txtIdrol.ReadOnly = !valor;
            this.txtRol.ReadOnly = !valor;
            this.cbSexo.Enabled = valor;
            this.cbRol.Enabled = valor;
            this.txtUsuario.ReadOnly = !valor;
            this.txtPassword.ReadOnly = !valor;
        }

        //habilitar los botones

        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
                this.btnCargar.Enabled = true;
                this.btnLimpiar.Enabled = true;
                this.btnBuscarRol.Enabled = true;
                this.cbRol.Enabled = true;
                this.cbSexo.Enabled = true;

            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnCargar.Enabled = false;
                this.btnLimpiar.Enabled = false;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
                this.btnBuscarRol.Enabled = false;
                this.cbRol.Enabled = false;
                this.cbSexo.Enabled = false;
            }
        }

        //Metodo para ocultar columanas

        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
            this.dataListado.Columns[11].Visible = false;
        }

        //Metodo mostar

        private void Mostrar()
        {
            this.dataListado.DataSource = NUsuarios.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros : " + Convert.ToString(dataListado.Rows.Count);
        }

        //Metodo buscar  nombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NUsuarios.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros : " + Convert.ToString(dataListado.Rows.Count);
        }
        private void BuscarDocumento()
        {
            this.dataListado.DataSource = NUsuarios.BuscarDocumento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros : " + Convert.ToString(dataListado.Rows.Count);
        }

        //muestra los roles
        private void LlenarComboRoles()
        {
            cbRol.DataSource = NRoles.Mostrar();
            cbRol.ValueMember = "idrol";
            cbRol.DisplayMember = "nombre";
        }


        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.LlenarComboRoles();
            this.Habilitar(false);
            this.Botones();
        }

        //para cargar la imagen
        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pxImagen.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pxImagen.Image = global::CapaPresentacion.Properties.Resources.cargar;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();         

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void btnBuscarDocumento_Click(object sender, EventArgs e)
        {
            this.BuscarDocumento();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombres.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtNombres.Text == string.Empty || this.cbRol.SelectedValue == null)
                {
                    MensajeError("Falta ingresar algunos datos, seran remarcados");
                    errorIcono.SetError(txtNombres, "Ingrese un Valor");
                    errorIcono.SetError(cbRol, "Ingrese un Valor");
                    errorIcono.SetError(txtIdrol, "Ingrese un Valor");
                    errorIcono.SetError(txtRol, "Ingrese un Valor");
                    errorIcono.SetError(txtApellidos, "Ingrese un Valor");
                    errorIcono.SetError(txtDocumento, "Ingrese un Valor");
                    errorIcono.SetError(txtDireccion, "Ingrese un Valor");
                    errorIcono.SetError(txtUsuario, "Ingrese un Valor");
                    errorIcono.SetError(txtPassword, "Ingrese un Valor");
                }
                else
                {
                    //almacenar en el buffer lo del picture box y luego pasarlo a la variable para insertar luego
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    this.pxImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] imagen = ms.GetBuffer();
                    
                    DateTime dtFechaRegistro = DateTime.Now;
          
                    if (this.IsNuevo)
                    {
                        rpta = NUsuarios.Insertar(this.txtNombres.Text.Trim().ToUpper(), this.txtApellidos.Text.Trim().ToUpper(),
                            txtDocumento.Text, txtDireccion.Text, this.cbSexo.Text, imagen, dtFechaRegistro,this.txtUsuario.Text, this.txtPassword.Text,
                            Convert.ToInt32(this.cbRol.SelectedValue), this.txtCelular.Text
                            );
                    }
                    else
                    {
                        rpta = NUsuarios.Editar(Convert.ToInt32(this.txtIdusuario.Text),
                          this.txtNombres.Text.Trim().ToUpper(), this.txtApellidos.Text.Trim().ToUpper(),
                            txtDocumento.Text, txtDireccion.Text, this.cbSexo.Text, imagen, dtFechaRegistro, this.txtUsuario.Text, this.txtPassword.Text,
                            Convert.ToInt32(this.cbRol.SelectedValue), this.txtCelular.Text);
                    }
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
                    else
                    {
                        this.MensajeError(rpta);
                    }
                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnBuscarRol_Click(object sender, EventArgs e)
        {
            frmVistaRoles_Usuarios form = new frmVistaRoles_Usuarios();
            form.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //diferente de vacio
            if (!this.txtIdusuario.Text.Equals(""))
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdusuario.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idusuario"].Value);
            this.txtNombres.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombres"].Value);
            this.txtApellidos.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["apellidos"].Value);
            this.txtDocumento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["numero_documento"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["direccion"].Value);
            this.cbSexo.SelectedValue = Convert.ToString(this.dataListado.CurrentRow.Cells["sexo"].Value);
            this.txtCelular.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["celular"].Value);
            this.txtUsuario.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["usuario"].Value);
            this.txtPassword.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["password"].Value);


            this.txtIdrol.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idrol"].Value);
            this.txtRol.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["rol"].Value);
            this.cbRol.SelectedValue = Convert.ToString(this.dataListado.CurrentRow.Cells["idrol"].Value);

            //Proceso de muestra de imagen
            byte[] imagenBuffer = (byte[])this.dataListado.CurrentRow.Cells["imagen"].Value;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);

            this.pxImagen.Image = Image.FromStream(ms);
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;

            this.tabControl1.SelectedIndex = 1;
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente desea eliminar los registros", "Sistema de Restaurante", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

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
                            Rpta = NUsuarios.Eliminar(Convert.ToInt32(Codigo));

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
                    this.Mostrar();
                }
                chkEliminar.Checked = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

    }
}
