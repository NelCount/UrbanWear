using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static UrbanWear.clsVenta;

namespace UrbanWear
{
    public partial class frmNuevaVenta : Form
    {
        public frmNuevaVenta()
        {
            InitializeComponent();
        }

        private void frmNuevaVenta_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarProductos();
            CargarVendedores();
            InicializarGrilla();
            numCantidad.Minimum = 1; 
            numCantidad.Value = 1;
        }

        private void CargarClientes()
        {
            clsCliente c = new clsCliente();
            cmbCliente.DataSource = c.Listar();
            cmbCliente.DisplayMember = "NombreCompleto"; 
            cmbCliente.ValueMember = "IDCliente";
            cmbCliente.SelectedIndex = -1;
        }

        private void CargarProductos()
        {
            clsProducto prod = new clsProducto();
            cmbProducto.DataSource = prod.ListarProductos();
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "IDProducto";
            cmbProducto.SelectedIndex = -1;
        }

        private void CargarVendedores()
        {
            clsVendedor v = new clsVendedor();
            cmbVendedor.DataSource = v.Listar();
            cmbVendedor.DisplayMember = "NombreCompleto";
            cmbVendedor.ValueMember = "IDVendedor";
            cmbVendedor.SelectedIndex = -1;
        }

        private void InicializarGrilla()
        {
            dgvDetalle.Columns.Clear();
            dgvDetalle.AutoGenerateColumns = false;

            dgvDetalle.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "IDProducto",
                HeaderText = "IDProducto",
                Visible = false
            });

            dgvDetalle.Columns.Add("Producto", "Producto");
            dgvDetalle.Columns.Add("Cantidad", "Cantidad");
            dgvDetalle.Columns.Add("PrecioUnitario", "Precio Unitario");
            dgvDetalle.Columns.Add("Subtotal", "Subtotal");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccioná un producto.");
                return;
            }

            int idProducto = Convert.ToInt32(cmbProducto.SelectedValue);
            string nombre = cmbProducto.Text;
            int cantidad = (int)numCantidad.Value;
            clsProducto prod = new clsProducto();
            decimal precio = prod.ObtenerPrecio(idProducto);
            decimal subtotal = precio * cantidad;

            dgvDetalle.Rows.Add(idProducto, nombre, cantidad, precio, subtotal);
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow fila in dgvDetalle.Rows)
            {
                if (!fila.IsNewRow)
                {
                    total += Convert.ToDecimal(fila.Cells["Subtotal"].Value);
                }
            }

            lblTotal.Text = total.ToString();
        }
              
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedIndex == -1 || dgvDetalle.Rows.Count == 0)
            {
                MessageBox.Show("Completá los datos para confirmar la venta.");
                return;
            }

            try
            {
                clsVenta venta = new clsVenta
                {
                    Fecha = DateTime.Now,
                    IDCliente = Convert.ToInt32(cmbCliente.SelectedValue),
                    Total = Convert.ToDecimal(lblTotal.Text),
                    IDVendedor = Convert.ToInt32(cmbVendedor.SelectedValue)
                };

                int idVenta = venta.Registrar();
                

                foreach (DataGridViewRow fila in dgvDetalle.Rows)
                {
                    if (fila.IsNewRow) continue;

                    clsDetalleVenta detalle = new clsDetalleVenta
                    {
                        IDVenta = idVenta,
                        IDProducto = Convert.ToInt32(fila.Cells["IDProducto"].Value),
                        Cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value),
                        PrecioUnitario = Convert.ToDecimal(fila.Cells["PrecioUnitario"].Value),
                        Subtotal = Convert.ToDecimal(fila.Cells["Subtotal"].Value)
                    };

                    detalle.Registrar();
                    clsProducto p = new clsProducto();
                    p.ActualizarStock(detalle.IDProducto, detalle.Cantidad);
                }
                
                MessageBox.Show("Venta registrada correctamente.");
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al confirmar venta: " + ex.Message);
            }

        }

        private void LimpiarFormulario()
        {
            cmbCliente.SelectedIndex = -1;
            cmbProducto.SelectedIndex = -1;
            numCantidad.Value = 1;
            dgvDetalle.Rows.Clear();
            lblTotal.Text = "0";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }
    }
}
