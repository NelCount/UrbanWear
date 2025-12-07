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
using System.Windows.Forms.DataVisualization.Charting;

namespace UrbanWear
{
    public partial class frmEstadisticaVentas : Form
    {
        public frmEstadisticaVentas()
        {
            InitializeComponent();
        }

        private void frmEstadisticaVentas_Load(object sender, EventArgs e)
        {
            cmbEstadistica.Items.Add("Ventas por mes");
            cmbEstadistica.Items.Add("Ventas por cliente");
            cmbEstadistica.Items.Add("Ventas por vendedor");
            cmbEstadistica.SelectedIndex = -1;

            dtpDesde.Value = new DateTime(DateTime.Today.Year, 1, 1);
            dtpHasta.Value = DateTime.Today;

            lblEstadoFiltro.Text = "";
            lblEstadoFiltro.Visible = false;           
        }

        private void cmbEstadistica_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarEstadistica();
        }

        private void CargarEstadistica()
        {
            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date;

            DateTime fechaInicioSistema = new DateTime(DateTime.Today.Year, 1, 1); 

            if (dtpDesde.Value.Date > fechaInicioSistema || dtpHasta.Value.Date < DateTime.Today)
            {
                timerParpadeo.Start();
            }
            else
            {
                timerParpadeo.Stop();
                lblEstadoFiltro.Visible = false;
            }


            lblEstadoFiltro.Text = "Mostrando ventas entre:\n" + 
                dtpDesde.Value.ToShortDateString() + " y " + dtpHasta.Value.ToShortDateString();

            timerParpadeo.Start();

            chartVentas.Series.Clear();
            chartVentas.Titles.Clear();

            chartVentas.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartVentas.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            chartVentas.ChartAreas[0].AxisX.LabelStyle.Angle = 0; 
            chartVentas.ChartAreas[0].AxisX.Interval = 0; 
            chartVentas.ChartAreas[0].AxisY.Title = "";
            chartVentas.ChartAreas[0].AxisY.LabelStyle.Format = "";

            string tipo = cmbEstadistica.SelectedItem.ToString();
            Series serie = new Series("Ventas");
            serie.ChartType = SeriesChartType.Column;
            serie.IsValueShownAsLabel = true;
            serie.LabelForeColor = Color.Black;
            serie.Font = new Font("Segoe UI", 8, FontStyle.Bold);

            clsEstadisticaVenta estadistica = new clsEstadisticaVenta();

            if (tipo == "Ventas por mes")
            {
                chartVentas.Titles.Add("Total de ventas por mes");
                chartVentas.ChartAreas[0].AxisY.Title = "Total vendido ($)";
                chartVentas.ChartAreas[0].AxisY.LabelStyle.Format = "C0";

                var datos = estadistica.ObtenerVentasPorMes(desde, hasta);
                foreach (var item in datos.OrderBy(x => x.Key)) 
                    serie.Points.AddXY(item.Key, item.Value);
            }
            else if (tipo == "Ventas por cliente")
            {
                chartVentas.Titles.Add("Top 10 clientes por ventas");
                chartVentas.ChartAreas[0].AxisY.Title = "Total vendido ($)";
                chartVentas.ChartAreas[0].AxisY.LabelStyle.Format = "C0";

                chartVentas.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
                chartVentas.ChartAreas[0].AxisX.Interval = 1;

                var datos = estadistica.ObtenerVentasPorCliente(desde, hasta);
                foreach (var item in datos.OrderByDescending(x => x.Value).Take(10))
                    serie.Points.AddXY(item.Key, item.Value);
            }
            else if (tipo == "Ventas por vendedor")
            {
                chartVentas.Titles.Add("Ventas por vendedor");
                chartVentas.ChartAreas[0].AxisY.Title = "Total vendido ($)";
                chartVentas.ChartAreas[0].AxisY.LabelStyle.Format = "C0";

                chartVentas.ChartAreas[0].AxisX.LabelStyle.Angle = -30;
                chartVentas.ChartAreas[0].AxisX.Interval = 1;

                var datos = estadistica.ObtenerVentasPorVendedor(desde, hasta);
                foreach (var item in datos.OrderByDescending(x => x.Value))
                    serie.Points.AddXY(item.Key, item.Value);
            }

            chartVentas.Series.Add(serie);
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            if (cmbEstadistica.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor seleccioná un tipo de estadística.", "Falta selección");
                return;
            }

            CargarEstadistica();
        }

        private void btnBorrarFiltro_Click(object sender, EventArgs e)
        {
            cmbEstadistica.SelectedIndex = -1;

            dtpDesde.Value = new DateTime(DateTime.Today.Year, 1, 1); 
            dtpHasta.Value = DateTime.Today;

            chartVentas.Series.Clear();
            chartVentas.Titles.Clear();

            lblEstadoFiltro.Text = "";
            lblEstadoFiltro.Visible = false;

            timerParpadeo.Stop();
        }

        private void timerParpadeo_Tick(object sender, EventArgs e)
        {
            lblEstadoFiltro.Visible = !lblEstadoFiltro.Visible;
        }
    }
}
