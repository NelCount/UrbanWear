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
    public partial class frmNuevoProducto : Form
    {
        public frmNuevoProducto()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }

        private void frmNuevoProducto_Load(object sender, EventArgs e)
        {
            CargarColoresYTalles();
            CargarCategorias();
            ListarProductos();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            cmbTalle.SelectedIndex = -1;
            cmbColor.SelectedIndex = -1;
            numPrecio.Value = 0;
            numCantidad.Value = 0;
            cmbCategoria.SelectedIndex = -1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {               
                clsProducto prod = new clsProducto
                {
                    Nombre = txtNombre.Text.Trim(),
                    Talle = cmbTalle.Text,
                    Color = cmbColor.Text,
                    Precio = numPrecio.Value,
                    Cantidad = (int)numCantidad.Value,
                    IDCategoria = Convert.ToInt32(cmbCategoria.SelectedValue)
                };

                string error = prod.ValidarDatos();
                if (!string.IsNullOrEmpty(error))
                {
                    MessageBox.Show(error, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                prod.Agregar();
                ListarProductos();
                MessageBox.Show("Producto guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombre.Clear();
                cmbTalle.SelectedIndex = -1;
                cmbColor.SelectedIndex = -1;
                numPrecio.Value = 0;
                numCantidad.Value = 0;
                cmbCategoria.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el producto:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ListarProductos()
        {
            clsProducto prod = new clsProducto();
            dgvProductos.DataSource = prod.Listar();
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
    }
}
