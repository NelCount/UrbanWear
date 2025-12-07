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
    public partial class frmModificarCliente : Form
    {
        public frmModificarCliente()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }
        private void frmModificarCliente_Load(object sender, EventArgs e)
        {
            CargarLocalidades();
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow fila = dgvClientes.Rows[e.RowIndex];

                    txtNombre.Text = fila.Cells[1].Value.ToString();
                    txtApellido.Text = fila.Cells[2].Value.ToString();
                    txtDni.Text = fila.Cells[3].Value.ToString();
                    txtTelefono.Text = fila.Cells[4].Value.ToString();
                    txtEmail.Text = fila.Cells[5].Value.ToString();
                    txtDirec.Text = fila.Cells[6].Value.ToString();
                    cmbLocalidad.SelectedIndex = cmbLocalidad.FindStringExact(fila.Cells[7].Value.ToString());

                    btnGuardar.Enabled = true;
                    btnEliminar.Enabled = true;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error al cargar datos del cliente:\n" + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtDni.Text))
                {
                    MessageBox.Show("Ingresá un DNI para buscar.");
                    return;
                }

                if (!int.TryParse(txtDni.Text.Trim(), out int dni))
                {
                    MessageBox.Show("El DNI debe ser un número válido.");
                    return;
                }

                clsCliente cli = new clsCliente();
                DataTable resultado = cli.BuscarPorDNI(dni);

                if (resultado.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron clientes.");
                    dgvClientes.DataSource = null;
                    return;
                }

                ConfigurarGrilla();
                dgvClientes.DataSource = resultado;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar:\n" + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClientes.CurrentRow == null)
                {
                    MessageBox.Show("Seleccioná un cliente para modificar.");
                    return;
                }

                int idCliente = Convert.ToInt32(dgvClientes.CurrentRow.Cells[0].Value);

                clsCliente cli = new clsCliente();
                cli.IDCliente = idCliente;
                cli.Nombre = txtNombre.Text.Trim();
                cli.Apellido = txtApellido.Text.Trim();
                cli.DNI = int.Parse(txtDni.Text.Trim());
                cli.Telefono = long.Parse(txtTelefono.Text.Trim());
                cli.Email = txtEmail.Text.Trim();
                cli.Direccion = txtDirec.Text.Trim();
                cli.IDLocalidad = Convert.ToInt32(cmbLocalidad.SelectedValue);

                cli.Modificar();

                MessageBox.Show("Cliente modificado con éxito.");
                dgvClientes.DataSource = cli.BuscarPorDNI(cli.DNI);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al modificar el cliente:\n" + Ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!btnEliminar.Enabled || dgvClientes.CurrentRow == null)
                {
                    MessageBox.Show("Seleccioná un cliente de la lista para eliminar.");
                    return;
                }

                int idCliente = Convert.ToInt32(dgvClientes.CurrentRow.Cells[0].Value);

                DialogResult confirmacion = MessageBox.Show(
                "¿Estás seguro que querés eliminar este cliente?",
                "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    clsCliente cli = new clsCliente();
                    cli.Eliminar(idCliente);

                    MessageBox.Show("Cliente eliminado con éxito.");
                    dgvClientes.DataSource = null;

                    btnGuardar.Enabled = false;
                    btnEliminar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar cliente:\n" + ex.Message);
            }
        }

        private void CargarLocalidades()
        {
            clsLocalidad loc = new clsLocalidad();
            cmbLocalidad.DataSource = loc.ObtenerTodas();
            cmbLocalidad.ValueMember = "IDLocalidad";
            cmbLocalidad.DisplayMember = "Nombre";
            cmbLocalidad.SelectedIndex = -1;
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
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Localidad", DataPropertyName = "Localidad" });
        }

    }
}
