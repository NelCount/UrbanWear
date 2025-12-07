using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrbanWear
{
    internal class clsDetalleVenta
    {
        #region Propiedades públicas
        public int IDVenta { get; set; }
        public int IDProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        #endregion

        #region Conexión
        private string CadenaConexion = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=UrbanWear.mdb";
        #endregion

        #region Métodos públicos
        public void Registrar()
        {
            try
            {
                using (OleDbConnection conexion = new OleDbConnection(CadenaConexion))
                {
                    conexion.Open();
                    string consulta = @"INSERT INTO DetalleVenta 
                (IDVenta, IDProducto, CantidadVendida, PrecioUnitario, Subtotal)
                VALUES (?, ?, ?, ?, ?)";
                    OleDbCommand cmd = new OleDbCommand(consulta, conexion);
                    cmd.Parameters.AddWithValue("@IDVenta", IDVenta);
                    cmd.Parameters.AddWithValue("@IDProducto", IDProducto);
                    cmd.Parameters.AddWithValue("@CantidadVendida", Cantidad);
                    cmd.Parameters.Add("@PrecioUnitario", OleDbType.Double).Value = Convert.ToDouble(PrecioUnitario);
                    cmd.Parameters.Add("@Subtotal", OleDbType.Double).Value = Convert.ToDouble(Subtotal);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        #endregion
    }
}
