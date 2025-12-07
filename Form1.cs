using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrbanWear
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void acercaDeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAcercaDe frmAcercaDe = new frmAcercaDe();
            frmAcercaDe.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cargarNuevoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNuevoProducto frmNuevoProducto = new frmNuevoProducto();
            frmNuevoProducto.Show();
        }

        private void modificarEliminarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmModificarProducto frmModificarProducto = new frmModificarProducto();
            frmModificarProducto.Show();
        }

        private void cargarNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNuevoCliente frmNuevoCliente = new frmNuevoCliente();
            frmNuevoCliente.Show();
        }

        private void modificarEliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmModificarCliente frmModificarCliente = new frmModificarCliente();
            frmModificarCliente.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmBuscarProducto frmBuscarProducto = new frmBuscarProducto();
            frmBuscarProducto.Show();
        }

        private void productosConBajoStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStock frmStock = new frmStock();
            frmStock.Show();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBuscarCliente frmBuscarCliente = new frmBuscarCliente();
            frmBuscarCliente.Show();
        }

        private void nuevaVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNuevaVenta frmNuevaVenta = new frmNuevaVenta();
            frmNuevaVenta.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmBuscarVenta frmBuscarVenta = new frmBuscarVenta();
            frmBuscarVenta.Show();
        }

        private void estadísticasDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstadisticaVentas frmEstadisticaVentas = new frmEstadisticaVentas();
            frmEstadisticaVentas.Show();
        }

        private void cotizaciónDolarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCotizacion frmCotizacion = new frmCotizacion();
            frmCotizacion.Show();
        }
    }
}
