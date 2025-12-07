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
    public partial class frmBuscarCliente : Form
    {
        public frmBuscarCliente()
        {
            InitializeComponent();
        }

        private void frmBuscarCliente_Load(object sender, EventArgs e)
        {
            CargarLocalidades();
            BuscarYActualizar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarYActualizar();
        }

        private void BuscarYActualizar()
        {
            string dni = txtDni.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string localidad = cmbLocalidad.Text.Trim();

            clsCliente cli = new clsCliente();
            DataTable resultado = cli.BuscarClientes(dni, nombre, apellido, localidad);

            ConfigurarGrilla(); 
            dgvClientes.DataSource = resultado;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtDni.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            cmbLocalidad.SelectedIndex = -1;

            BuscarYActualizar();
        }

        private void CargarLocalidades()
        {
            try
            {
                clsLocalidad loc = new clsLocalidad();
                cmbLocalidad.DataSource = loc.ObtenerTodas();
                cmbLocalidad.DisplayMember = "Nombre";
                cmbLocalidad.ValueMember = "IDLocalidad";
                cmbLocalidad.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar localidades:\n" + ex.Message);
            }
        }

        private void ConfigurarGrilla()
        {
            dgvClientes.Columns.Clear();
            dgvClientes.AutoGenerateColumns = false;

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Código", DataPropertyName = "Codigo" });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Nombre", DataPropertyName = "Nombre" });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Apellido", DataPropertyName = "Apellido" });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "DNI", DataPropertyName = "DNI" });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Teléfono", DataPropertyName = "Telefono" });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Email", DataPropertyName = "Email" });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Dirección", DataPropertyName = "Direccion" });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Localidad",
                DataPropertyName = "Localidad",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }     
    }
}
