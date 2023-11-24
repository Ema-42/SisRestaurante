using CapaNegocio;
using System;
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
    public partial class FromVistaProducto_Orden : Form
    {
        public FromVistaProducto_Orden()
        {
            InitializeComponent();
        }

        private void FromVistaProducto_Orden_Load(object sender, EventArgs e)
        {
            this.Mostrar();
   
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
            this.dataListado.DataSource = NProductos.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros : " + Convert.ToString(dataListado.Rows.Count);
        }

        //Buscar nombre Metodo
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NProductos.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros : " + Convert.ToString(dataListado.Rows.Count);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        //configurar en evnetos del data istado (rayo)
        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            //primero debe revisar si ya existe una nstancia, y si no la crea,pero aqui ya va existir
            //current row= fila actual
            FrmOrdenes form = FrmOrdenes.GetInstancia();
            string par1, par2,par3;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["idproducto"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            par3 = Convert.ToString(this.dataListado.CurrentRow.Cells["precio"].Value);
            form.setProducto(par1, par2,par3);
            this.Hide();
        }
    }
}
