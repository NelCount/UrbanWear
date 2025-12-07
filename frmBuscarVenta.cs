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
    public partial class frmBuscarVenta : Form
    {
        public frmBuscarVenta()
        {
            InitializeComponent();
        }

        private int filaActual = 0;
        private DataTable datosParaImprimir;

        private void frmBuscarVenta_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarVendedores();

            chkFecha.Checked = false;
            dtpDesde.Enabled = false;
            dtpHasta.Enabled = false;

            dtpDesde.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpHasta.Value = DateTime.Today;

            CargarVentas();
            printDocument1.PrintPage += printDocument1_PrintPage;
        }

        private void CargarClientes()
        {
            clsCliente c = new clsCliente();
            cmbCliente.DataSource = c.Listar();

            cmbCliente.DisplayMember = "NombreCompleto";
            cmbCliente.ValueMember = "IDCliente";
            cmbCliente.SelectedIndex = -1;
        }

        private void CargarVendedores()
        {
            clsVendedor v = new clsVendedor();
            cmbVendedor.DataSource = v.Listar();
            cmbVendedor.DisplayMember = "NombreCompleto";
            cmbVendedor.ValueMember = "IDVendedor";
            cmbVendedor.SelectedIndex = -1;
        }

        private void CargarVentas()
        {
            clsVenta objVenta = new clsVenta();

            string consulta = "SELECT V.IDVenta AS Código, V.Fecha, (C.Nombre & ' ' & C.Apellido) AS Cliente, " +
                  "V.Total, (VEN.Nombre & ' ' & VEN.Apellido) AS Vendedor " +
                  "FROM ((Venta V INNER JOIN Cliente C ON V.IDCliente = C.IDCliente) " +
                  "INNER JOIN Vendedor VEN ON V.IDVendedor = VEN.IDVendedor) " +
                  "WHERE 1=1";

            if (cmbCliente.SelectedIndex != -1)
                consulta += $" AND V.IDCliente = {cmbCliente.SelectedValue}";

            if (cmbVendedor.SelectedIndex != -1)
                consulta += $" AND V.IDVendedor = {cmbVendedor.SelectedValue}";

            if (chkFecha.Checked)
            {
                DateTime fechaInicio = dtpDesde.Value.Date;
                DateTime fechaFin = dtpHasta.Value.Date.AddDays(1).AddSeconds(-1);

                if (fechaInicio <= fechaFin)
                {
                    consulta += $" AND V.Fecha BETWEEN #{fechaInicio:MM/dd/yyyy HH:mm:ss}# AND #{fechaFin:MM/dd/yyyy HH:mm:ss}#";
                }
            }

            dgvVentas.DataSource = objVenta.BuscarVentas(consulta);
           
            foreach (DataGridViewColumn col in dgvVentas.Columns)
            {
                if (col.HeaderText == "Vendedor")
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                else
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }

        }

        private void LimpiarFiltros()
        {
            cmbCliente.SelectedIndex = -1;
            cmbVendedor.SelectedIndex = -1;
            dtpDesde.Value = DateTime.Today;
            
            CargarVentas(); 
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarVentas();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
        }

        private void chkFecha_CheckedChanged(object sender, EventArgs e)
        {
            dtpDesde.Enabled = chkFecha.Checked;
            dtpHasta.Enabled = chkFecha.Checked;

            CargarVentas();
        }

        private void btnImprimirReporte_Click(object sender, EventArgs e)
        {
            if (dgvVentas.DataSource is DataTable dt && dt.Rows.Count > 0)
            {
                datosParaImprimir = dt.Copy();
                filaActual = 0;
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay datos para imprimir.");
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font fuente = new Font("Courier New", 10);
            Font fuenteTitulo = new Font("Courier New", 14, FontStyle.Bold);
            Font fuenteNegrita = new Font("Courier New", 10, FontStyle.Bold);
            Brush pincel = Brushes.Black;

            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;
            int alturaFila = 20;

            e.Graphics.DrawString("Reporte de Ventas - UrbanWear", fuenteTitulo, pincel, x, y);
            y += 40;

            int[] posicionesX = { x, x + 80, x + 200, x + 380, x + 460 };
            string[] encabezados = { "Código", "Fecha", "Cliente", "Total", "Vendedor" };

            for (int i = 0; i < encabezados.Length; i++)
                e.Graphics.DrawString(encabezados[i], fuente, pincel, posicionesX[i], y);

            y += alturaFila;

            decimal totalGeneral = 0;

            while (filaActual < datosParaImprimir.Rows.Count)
            {
                DataRow fila = datosParaImprimir.Rows[filaActual];

                for (int i = 0; i < fila.ItemArray.Length; i++)
                {
                    string texto = i == 1 && fila[i] is DateTime fecha
                        ? fecha.ToString("dd/MM/yyyy")
                        : fila[i].ToString();

                    e.Graphics.DrawString(texto, fuente, pincel, posicionesX[i], y);
                }

                
                if (fila["Total"] != DBNull.Value)
                    totalGeneral += Convert.ToDecimal(fila["Total"]);

                filaActual++;
                y += alturaFila;

                if (y + alturaFila > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            
            y += 10;
            e.Graphics.DrawString("TOTAL GENERAL:", fuenteNegrita, pincel, posicionesX[2], y);
            e.Graphics.DrawString("$" + totalGeneral.ToString(), fuenteNegrita, pincel, posicionesX[3], y);

            e.HasMorePages = false;
        }

    }
}
