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
    public partial class FrmVistaCliente_Orden : Form
    {
        public FrmVistaCliente_Orden()
        {
            InitializeComponent();
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
            this.dataListado.DataSource = NClientes.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros : " + Convert.ToString(dataListado.Rows.Count);
        }

        //Buscar nombre Metodo
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NClientes.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros : " + Convert.ToString(dataListado.Rows.Count);
        }

        private void FrmVistaCliente_Orden_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            FrmOrdenes form = FrmOrdenes.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["idcliente"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["nombres"].Value);
            form.setCliente(par1, par2);
            this.Hide();
        }
    }
}
