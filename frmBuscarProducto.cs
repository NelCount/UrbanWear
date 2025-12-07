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
    public partial class frmBuscarProducto : Form
    {
        public frmBuscarProducto()
        {
            InitializeComponent();
        }

        private void frmBuscarProducto_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            CargarColoresYTalles();
            BuscarYActualizar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarYActualizar();
        }

        private void BuscarYActualizar()
        {
            string nombre = txtNombre.Text.Trim();
            string talle = cmbTalle.SelectedIndex != -1 ? cmbTalle.Text : "";
            string color = cmbColor.SelectedIndex != -1 ? cmbColor.Text : "";
            int? idCategoria = cmbCategoria.SelectedIndex != -1 ? (int?)cmbCategoria.SelectedValue : null;

            clsProducto producto = new clsProducto();
            DataTable resultado = producto.FiltrarProductos(nombre, talle, color, idCategoria);

            ConfigurarGrilla();
            dgvProductos.DataSource = resultado;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            cmbTalle.SelectedIndex = -1;
            cmbColor.SelectedIndex = -1;
            cmbCategoria.SelectedIndex = -1;
            dgvProductos.DataSource = null;
            BuscarYActualizar();
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

        private void ConfigurarGrilla()
        {
            dgvProductos.Columns.Clear();
            dgvProductos.AutoGenerateColumns = false;

            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Código", DataPropertyName = "Codigo" });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Nombre", DataPropertyName = "Nombre" });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Talle", DataPropertyName = "Talle" });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Color", DataPropertyName = "Color" });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Precio", DataPropertyName = "Precio" });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Cantidad", DataPropertyName = "Cantidad" });
            dgvProductos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Categoría",
                DataPropertyName = "Categoria",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }
    }
}
