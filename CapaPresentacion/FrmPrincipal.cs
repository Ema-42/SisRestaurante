using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
//importar
using FontAwesome.Sharp;
using Color = System.Drawing.Color;

namespace CapaPresentacion
{
    public partial class FrmPrincipal : Form
    {
        //***********PARA RECIBIR LOS DATOS DEL LOGIN

        public string idusuario = "";
        public string nombres = "";
        public string apellidos = "";
        public string numero_documento = "";
        public int idrol = 0 ;
        //*******************************



        //marcar seleccionactual
        private Panel BordeIzqBtn;
        private IconButton BtnActual;

        private Form FormHijoActual;

        public FrmPrincipal()
        {
            InitializeComponent();
            BordeIzqBtn = new Panel();
            BordeIzqBtn.Size = new Size(8, 60);
            panelMenu.Controls.Add(BordeIzqBtn);
            lblNombre2.Text = nombres;
            //Form
            //this.Text = string.Empty;
            //this.ControlBox = false;
            //this.DoubleBuffered = true;
            //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        //Metodos
        //para resaltar el boton activo
        //param botonremitente y color
        private void ActivateButton(object BtnRemitente, Color color)
        {
            if (BtnRemitente != null)
            {
                DisableButton();
                //Button
                BtnActual = (IconButton)BtnRemitente;
                BtnActual.BackColor = Color.FromArgb(16, 184, 79);
                BtnActual.ForeColor = color;
                BtnActual.TextAlign = ContentAlignment.MiddleCenter;
                BtnActual.IconColor = color;
                BtnActual.TextImageRelation = TextImageRelation.TextBeforeImage;
                BtnActual.ImageAlign = ContentAlignment.MiddleRight;
                //borde
                BordeIzqBtn.BackColor = color;
                BordeIzqBtn.Location = new Point(0, BtnActual.Location.Y);
                BordeIzqBtn.Visible = true;
                BordeIzqBtn.BringToFront();
                //formulario hijo icono casa
                //Current Child Form Icon
                //que el icono sea igual
                iconoFormHijoActual.IconChar = BtnActual.IconChar;
                iconoFormHijoActual.IconColor = color;

            }

        }
        //desactivar el boton seleccionado actualmente
        private void DisableButton()
        {
            if (BtnActual != null)
            {
                BtnActual.BackColor = Color.FromArgb(35, 49, 74);
                BtnActual.ForeColor = Color.Gainsboro;
                BtnActual.TextAlign = ContentAlignment.MiddleLeft;
                BtnActual.IconColor = Color.Gainsboro;
                BtnActual.TextImageRelation = TextImageRelation.ImageBeforeText;
                BtnActual.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        //lista de colores (opcional)
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(255, 255, 255);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }


        //resetear
        private void Reset()
        {
            DisableButton();
            BordeIzqBtn.Visible = false;
            iconoFormHijoActual.IconChar = IconChar.Home;
            iconoFormHijoActual.IconColor = Color.White;
            lblFormHijo.Text = "Inicio";
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (FormHijoActual != null)
            {
                FormHijoActual.Hide();
                Reset();
            }
        }
        //formularios hijos
        private void AbrirFormHijo(Form FormHijo)
        {
            //abrir solo un form
            if (FormHijoActual != null)
            {
                FormHijoActual.Hide();
            }
            FormHijoActual = FormHijo;
            //
            FormHijo.TopLevel = false;
            FormHijo.FormBorderStyle = FormBorderStyle.None;
            //llene el cont
            FormHijo.Dock = DockStyle.Fill;
            //asociamos los controles para que sea manipulable desde el panel
            panelEscritorio.Controls.Add(FormHijo);
            panelEscritorio.Tag = FormHijo;
            FormHijo.BringToFront();
            FormHijo.Show();
            lblFormHijo.Text = FormHijo.Text;
        }


        private void btnRoles_Click(object remitente, EventArgs e)
        {
            ActivateButton(remitente, RGBColors.color1);
            AbrirFormHijo(new FrmRoles());
        }

        private void btnClientes_Click(object remitente, EventArgs e)
        {
            ActivateButton(remitente, RGBColors.color1);
            AbrirFormHijo(new FrmClientes());
        }
        private void btnCategorias_Click(object remitente, EventArgs e)
        {
            ActivateButton(remitente, RGBColors.color1);
            AbrirFormHijo(new FrmCategoria());
        }

        private void btnPlatos_Click(object remitente, EventArgs e)
        {
            ActivateButton(remitente, RGBColors.color1);
            AbrirFormHijo(new FrmPlatos());
        }

        private void btnUsuarios_Click(object remitente, EventArgs e)
        {
            ActivateButton(remitente, RGBColors.color1);
            AbrirFormHijo(FrmUsuarios.GetInstancia());
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            GestionUsuario();
            lblNombre2.Text = nombres;
        }


        //controla los accesos al sistema
        private void GestionUsuario()
        {
            //controla los accesos
            if (idrol == 1 )
            {
                this.btnPlatos.Enabled = true;
                this.btnRoles.Enabled = true;
                this.btnUsuarios.Enabled = true;
                this.btnClientes.Enabled = true;
                this.btnCategorias.Enabled = true;
            }
            else if (idrol != 1)
            {
                this.btnPlatos.Enabled = true;
                this.btnRoles.Visible = false;
                this.btnUsuarios.Visible = false;
                this.btnClientes.Enabled = true;
                this.btnCategorias.Visible = false;
            }
        }

        private void iconButton1_Click(object remitente, EventArgs e)
        {
            ActivateButton(remitente, RGBColors.color1);
            AbrirFormHijo(new FrmProductos());
        }

        private void iconButton2_Click(object remitente, EventArgs e)
        {
            ActivateButton(remitente, RGBColors.color1);
            AbrirFormHijo(FrmOrdenes.GetInstancia());
            //le pasamos el id del usuario logueado
            FrmOrdenes.GetInstancia().Idusuario = Convert.ToInt32(this.idusuario);
        }
    }
}
