namespace CapaPresentacion
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUsuarios = new FontAwesome.Sharp.IconButton();
            this.btnClientes = new FontAwesome.Sharp.IconButton();
            this.btnRoles = new FontAwesome.Sharp.IconButton();
            this.btnPlatos = new FontAwesome.Sharp.IconButton();
            this.btnCategorias = new FontAwesome.Sharp.IconButton();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnInicio = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblFormHijo = new System.Windows.Forms.Label();
            this.iconoFormHijoActual = new FontAwesome.Sharp.IconPictureBox();
            this.panelEscritorio = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnInicio)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconoFormHijoActual)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(49)))), ((int)(((byte)(74)))));
            this.panel1.Controls.Add(this.btnUsuarios);
            this.panel1.Controls.Add(this.btnClientes);
            this.panel1.Controls.Add(this.btnRoles);
            this.panel1.Controls.Add(this.btnPlatos);
            this.panel1.Controls.Add(this.btnCategorias);
            this.panel1.Controls.Add(this.panelMenu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(214, 823);
            this.panel1.TabIndex = 0;
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(49)))), ((int)(((byte)(74)))));
            this.btnUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUsuarios.FlatAppearance.BorderSize = 0;
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.ForeColor = System.Drawing.Color.Transparent;
            this.btnUsuarios.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.btnUsuarios.IconColor = System.Drawing.Color.White;
            this.btnUsuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.Location = new System.Drawing.Point(0, 341);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(214, 61);
            this.btnUsuarios.TabIndex = 5;
            this.btnUsuarios.Text = "USUARIOS";
            this.btnUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUsuarios.UseVisualStyleBackColor = false;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(49)))), ((int)(((byte)(74)))));
            this.btnClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.ForeColor = System.Drawing.Color.Transparent;
            this.btnClientes.IconChar = FontAwesome.Sharp.IconChar.User;
            this.btnClientes.IconColor = System.Drawing.Color.White;
            this.btnClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.Location = new System.Drawing.Point(0, 280);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(214, 61);
            this.btnClientes.TabIndex = 4;
            this.btnClientes.Text = "CLIENTES";
            this.btnClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnRoles
            // 
            this.btnRoles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(49)))), ((int)(((byte)(74)))));
            this.btnRoles.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRoles.FlatAppearance.BorderSize = 0;
            this.btnRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoles.ForeColor = System.Drawing.Color.Transparent;
            this.btnRoles.IconChar = FontAwesome.Sharp.IconChar.UserShield;
            this.btnRoles.IconColor = System.Drawing.Color.White;
            this.btnRoles.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRoles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoles.Location = new System.Drawing.Point(0, 219);
            this.btnRoles.Name = "btnRoles";
            this.btnRoles.Size = new System.Drawing.Size(214, 61);
            this.btnRoles.TabIndex = 3;
            this.btnRoles.Text = "ROLES";
            this.btnRoles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRoles.UseVisualStyleBackColor = false;
            this.btnRoles.Click += new System.EventHandler(this.btnRoles_Click);
            // 
            // btnPlatos
            // 
            this.btnPlatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(49)))), ((int)(((byte)(74)))));
            this.btnPlatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPlatos.FlatAppearance.BorderSize = 0;
            this.btnPlatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlatos.ForeColor = System.Drawing.Color.Transparent;
            this.btnPlatos.IconChar = FontAwesome.Sharp.IconChar.BowlFood;
            this.btnPlatos.IconColor = System.Drawing.Color.White;
            this.btnPlatos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPlatos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlatos.Location = new System.Drawing.Point(0, 159);
            this.btnPlatos.Name = "btnPlatos";
            this.btnPlatos.Size = new System.Drawing.Size(214, 60);
            this.btnPlatos.TabIndex = 2;
            this.btnPlatos.Text = "PLATOS";
            this.btnPlatos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlatos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPlatos.UseVisualStyleBackColor = false;
            this.btnPlatos.Click += new System.EventHandler(this.btnPlatos_Click);
            // 
            // btnCategorias
            // 
            this.btnCategorias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(49)))), ((int)(((byte)(74)))));
            this.btnCategorias.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCategorias.FlatAppearance.BorderSize = 0;
            this.btnCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategorias.ForeColor = System.Drawing.Color.Transparent;
            this.btnCategorias.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            this.btnCategorias.IconColor = System.Drawing.Color.White;
            this.btnCategorias.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCategorias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategorias.Location = new System.Drawing.Point(0, 99);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Size = new System.Drawing.Size(214, 60);
            this.btnCategorias.TabIndex = 1;
            this.btnCategorias.Text = "CATEGORIAS";
            this.btnCategorias.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategorias.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCategorias.UseVisualStyleBackColor = false;
            this.btnCategorias.Click += new System.EventHandler(this.btnCategorias_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.btnInicio);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(214, 99);
            this.panelMenu.TabIndex = 0;
            // 
            // btnInicio
            // 
            this.btnInicio.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnInicio.BackgroundImage")));
            this.btnInicio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInicio.Location = new System.Drawing.Point(71, 18);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(67, 67);
            this.btnInicio.TabIndex = 0;
            this.btnInicio.TabStop = false;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(49)))), ((int)(((byte)(74)))));
            this.panel2.Controls.Add(this.lblFormHijo);
            this.panel2.Controls.Add(this.iconoFormHijoActual);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(214, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1337, 52);
            this.panel2.TabIndex = 1;
            // 
            // lblFormHijo
            // 
            this.lblFormHijo.AutoSize = true;
            this.lblFormHijo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormHijo.ForeColor = System.Drawing.Color.White;
            this.lblFormHijo.Location = new System.Drawing.Point(43, 18);
            this.lblFormHijo.Name = "lblFormHijo";
            this.lblFormHijo.Size = new System.Drawing.Size(70, 29);
            this.lblFormHijo.TabIndex = 1;
            this.lblFormHijo.Text = "Inicio";
            // 
            // iconoFormHijoActual
            // 
            this.iconoFormHijoActual.BackColor = System.Drawing.Color.Transparent;
            this.iconoFormHijoActual.ForeColor = System.Drawing.SystemColors.Control;
            this.iconoFormHijoActual.IconChar = FontAwesome.Sharp.IconChar.HomeLg;
            this.iconoFormHijoActual.IconColor = System.Drawing.SystemColors.Control;
            this.iconoFormHijoActual.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconoFormHijoActual.IconSize = 39;
            this.iconoFormHijoActual.Location = new System.Drawing.Point(6, 12);
            this.iconoFormHijoActual.Name = "iconoFormHijoActual";
            this.iconoFormHijoActual.Size = new System.Drawing.Size(39, 40);
            this.iconoFormHijoActual.TabIndex = 0;
            this.iconoFormHijoActual.TabStop = false;
            // 
            // panelEscritorio
            // 
            this.panelEscritorio.Location = new System.Drawing.Point(220, 58);
            this.panelEscritorio.Name = "panelEscritorio";
            this.panelEscritorio.Size = new System.Drawing.Size(1319, 753);
            this.panelEscritorio.TabIndex = 2;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1551, 823);
            this.Controls.Add(this.panelEscritorio);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmPrincipal";
            this.Text = "FrmPrincipal";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.panel1.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnInicio)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconoFormHijoActual)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btnCategorias;
        private System.Windows.Forms.Panel panelMenu;
        private FontAwesome.Sharp.IconButton btnPlatos;
        private System.Windows.Forms.PictureBox btnInicio;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblFormHijo;
        private FontAwesome.Sharp.IconPictureBox iconoFormHijoActual;
        private System.Windows.Forms.Panel panelEscritorio;
        private FontAwesome.Sharp.IconButton btnRoles;
        private FontAwesome.Sharp.IconButton btnClientes;
        private FontAwesome.Sharp.IconButton btnUsuarios;
    }
}