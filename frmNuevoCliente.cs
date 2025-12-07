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
    public partial class frmNuevoCliente : Form
    {
        public frmNuevoCliente()
        {
            InitializeComponent();
        }

        private void frmNuevoCliente_Load(object sender, EventArgs e)
        {
            ListarClientes();
            CargarLocalidades();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtDirec.Clear();
            cmbLocalidad.SelectedIndex = -1;

        }
         
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                

                if (txtNombre.Text == "" || txtApellido.Text == "" || txtDni.Text == "" ||
                    txtTelefono.Text == "" || txtEmail.Text == "" || txtDirec.Text == "" ||
                    cmbLocalidad.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor completá todos los campos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                if (txtTelefono.Text.Trim().Length != 10)
                {
                    MessageBox.Show("El teléfono debe tener 10 dígitos.");
                    return;
                }
                clsCliente cli = new clsCliente();

                cli.Nombre = txtNombre.Text.Trim();
                cli.Apellido = txtApellido.Text.Trim();
                cli.DNI = Convert.ToInt32(txtDni.Text);
                cli.Telefono = Convert.ToInt64(txtTelefono.Text.Trim());
                cli.Email = txtEmail.Text.Trim();
                cli.Direccion = txtDirec.Text.Trim();
                cli.IDLocalidad = Convert.ToInt32(cmbLocalidad.SelectedValue);

                cli.Agregar();
                ListarClientes();
                LimpiarCampos();

                MessageBox.Show("Cliente agregado con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListarClientes()
        {
            clsCliente c = new clsCliente();
            dgvClientes.DataSource = c.ListarClientes();
        }

        private void CargarLocalidades()
        {
            clsLocalidad loc = new clsLocalidad();
            cmbLocalidad.DataSource = loc.ObtenerTodas();
            cmbLocalidad.ValueMember = "IDLocalidad";
            cmbLocalidad.DisplayMember = "Nombre";
            cmbLocalidad.SelectedIndex = -1;
        }
       
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
