using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrbanWear
{
    internal class clsVenta
    {
        #region Propiedades públicas
        public int IDVenta { get; set; }
        public DateTime Fecha { get; set; }
        public int IDCliente { get; set; }
        public decimal Total { get; set; }
        public int IDVendedor { get; set; }
        #endregion

        #region Conexión
        private string CadenaConexion = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=UrbanWear.mdb";
        #endregion

        #region Métodos públicos
        public int Registrar()
        {
            int idGenerado = 0;

            try
            {
                using (var conexion = new OleDbConnection(CadenaConexion))
                {
                    conexion.Open();

                    string consulta = $"INSERT INTO Venta (Fecha, IDCliente, IDVendedor, Total) VALUES (?, ?, ?, ?)";
                    using (var comando = new OleDbCommand(consulta, conexion))
                    {
                        comando.Parameters.Add("@Fecha", OleDbType.Date).Value = Fecha;
                        comando.Parameters.AddWithValue("@IDCliente", IDCliente);
                        comando.Parameters.AddWithValue("@IDVendedor", IDVendedor);
                        comando.Parameters.AddWithValue("@Total", Total);

                        int filas = comando.ExecuteNonQuery();

                        if (filas > 0)
                        {
                            comando.CommandText = "SELECT @@IDENTITY";
                            comando.Parameters.Clear();
                            idGenerado = Convert.ToInt32(comando.ExecuteScalar());
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return idGenerado;
        }

        public DataTable BuscarVentas(string consulta)
        {
            var tabla = new DataTable();

            try
            {
                using (var conexion = new OleDbConnection(CadenaConexion))
                using (var adaptador = new OleDbDataAdapter(consulta, conexion))
                {
                    conexion.Open();
                    adaptador.Fill(tabla);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return tabla;
        }
        #endregion
    }
}
