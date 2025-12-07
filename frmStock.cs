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
    public partial class frmStock : Form
    {
        public frmStock()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int cantidad = Convert.ToInt32(numStock.Value);

                clsProducto producto = new clsProducto();
                DataTable tabla = producto.BuscarBajoStock(cantidad);

                dgvProductos.Columns.Clear();
                dgvProductos.DataSource = tabla;

                lblTotal.Text = tabla.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la búsqueda:\n" + ex.Message);
            }
        }
    }
}
