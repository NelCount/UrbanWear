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

namespace UrbanWear
{
    public partial class frmModificarProducto : Form
    {
        public frmModificarProducto()
        {
            InitializeComponent();
        }

        private void frmModificarProducto_Load(object sender, EventArgs e)
        {
            CargarColoresYTalles();
            CargarCategorias();
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Ingresá un nombre para buscar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                clsProducto producto = new clsProducto();
                DataTable resultado = producto.BuscarPorNombre(nombre);

                if (resultado.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron productos con ese nombre.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvProductos.DataSource = null;
                    return;
                }

                dgvProductos.AutoGenerateColumns = false;
                ConfigurarGrilla();
                dgvProductos.DataSource = resultado;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar productos:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!btnEliminar.Enabled || dgvProductos.CurrentRow == null || dgvProductos.CurrentRow.IsNewRow)
                {
                    MessageBox.Show("Seleccioná un producto de la lista para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idProducto = Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value);

                DialogResult confirmacion = MessageBox.Show("¿Estás seguro de que querés eliminar " +
                    "este producto?", "Confirmar eliminación", MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);
                if (confirmacion == DialogResult.Yes)
                {
                    clsProducto prod = new clsProducto();
                    prod.Eliminar(idProducto);

                    MessageBox.Show("Producto eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvProductos.DataSource = null;

                    btnGuardar.Enabled = false;
                    btnEliminar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar producto:\n" + ex.Message);
            }
        }
       
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProductos.CurrentRow == null)
                {
                    MessageBox.Show("Seleccioná un producto para modificar.");
                    return;
                }

                int idProducto = Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value);

                clsProducto prod = new clsProducto();

                prod.IDProducto = idProducto;
                prod.Nombre = txtNombre.Text.Trim();
                prod.Talle = cmbTalle.Text;
                prod.Color = cmbColor.Text;
                prod.Precio = numPrecio.Value;
                prod.Cantidad = Convert.ToInt32(numCantidad.Value);
                prod.IDCategoria = Convert.ToInt32(cmbCategoria.SelectedValue);

                prod.Modificar();

                MessageBox.Show("Producto modificado con éxito.");

                string nombre = txtNombre.Text.Trim();
                DataTable resultado = prod.BuscarPorNombre(nombre);
                dgvProductos.DataSource = resultado;
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error al modificar el producto:\n" + ex.Message);
            }
        }

        private void CargarCategorias()
        {
            clsCategoria c = new clsCategoria();
            cmbCategoria.DataSource = c.Listar();
            cmbCategoria.ValueMember = "IDCategoria";
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.SelectedIndex = -1;
        }

        private void CargarColoresYTalles()
        {
            cmbTalle.Items.Clear();
            cmbTalle.Items.Add("XS");
            cmbTalle.Items.Add("S");
            cmbTalle.Items.Add("M");
            cmbTalle.Items.Add("L");
            cmbTalle.Items.Add("XL");
            cmbTalle.Items.Add("XXL");

            cmbColor.Items.Clear();
            cmbColor.Items.Add("Negro");
            cmbColor.Items.Add("Blanco");
            cmbColor.Items.Add("Gris");
            cmbColor.Items.Add("Rojo");
            cmbColor.Items.Add("Azul");
            cmbColor.Items.Add("Verde");

            cmbTalle.SelectedIndex = -1;
            cmbColor.SelectedIndex = -1;
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];

                    txtNombre.Text = fila.Cells[1].Value.ToString();
                    cmbTalle.Text = fila.Cells[2].Value.ToString();
                    cmbColor.Text = fila.Cells[3].Value.ToString();
                    numPrecio.Value = Convert.ToDecimal(fila.Cells[4].Value);
                    numCantidad.Value = Convert.ToInt32(fila.Cells[5].Value);
                    cmbCategoria.SelectedIndex = cmbCategoria.FindStringExact(fila.Cells[6].Value.ToString());

                    btnGuardar.Enabled = true;
                    btnEliminar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrilla()
        {
            dgvProductos.Columns.Clear();
            dgvProductos.AutoGenerateColumns = false;

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Código", DataPropertyName = "IDProducto" });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Nombre", DataPropertyName = "Nombre" });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Talle", DataPropertyName = "Talle" });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Color", DataPropertyName = "Color" });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Precio", DataPropertyName = "Precio" });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Cantidad", DataPropertyName = "Cantidad" });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Categoría", DataPropertyName = "Categoria" });
        }
    }
}
