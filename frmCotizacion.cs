using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace UrbanWear
{
    public partial class frmCotizacion : Form
    {
        public frmCotizacion()
        {
            InitializeComponent();
        }

        private async void frmCotizacion_Load(object sender, EventArgs e)
        {
            await ObtenerCotizacionDolarAsync();
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            await ObtenerCotizacionDolarAsync();
        }

        private async Task ObtenerCotizacionDolarAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = "https://api.bluelytics.com.ar/v2/latest";
                    string json = await client.GetStringAsync(url);

                    JObject data = JObject.Parse(json);

                    decimal compra = data["blue"]["value_buy"].ToObject<decimal>();
                    decimal venta = data["blue"]["value_sell"].ToObject<decimal>();
                    

                    lblDolarBlue.Text = $"💵 Dólar Blue\nCompra: ${compra} | Venta: ${venta}";

                    decimal oficialCompra = data["oficial"]["value_buy"].ToObject<decimal>();
                    decimal oficialVenta = data["oficial"]["value_sell"].ToObject<decimal>();

                    lblDolarBlue.Text += $"\n🪙 Dólar Oficial\nCompra: ${oficialCompra} | " +
                        $"Venta: ${oficialVenta}";

                    lblUltimaActualizacion.Text = "Actualizado: " + 
                        DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                }
            }
            catch (Exception ex)
            {
                lblDolarBlue.Text = "Error al obtener cotización.";
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}
