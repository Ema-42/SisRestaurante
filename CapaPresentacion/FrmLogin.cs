﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            lblHora.Text = DateTime.Now.ToString();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //crear variable para recibir lo que debuelve login que es un datatable
            DataTable Datos = CapaNegocio.NUsuarios.Login(this.txtUsuario.Text, this.txtPassword.Text);
            //MessageBox.Show("Datos: "+ Datos.Rows[0][0].ToString(), "Sistema",MessageBoxButtons.OK, MessageBoxIcon.Error);
            //Evaluar si existe el usuario
            if (Datos.Rows.Count == 0)
            {
                MessageBox.Show("NO tiene acceso al sistema ", "Sistema Restaurante", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //estas variables se deben declarar en el frmPrincipal codigo
                FrmPrincipal frm = new FrmPrincipal();
                frm.idusuario = Datos.Rows[0][0].ToString();
                frm.apellidos = Datos.Rows[0][2].ToString();
                frm.nombres = Datos.Rows[0][1].ToString();
                frm.idrol = Convert.ToInt32(Datos.Rows[0][3]);
                frm.numero_documento = Datos.Rows[0][4].ToString();
                frm.Show();
                this.Hide();
            }
        }
    }
}
