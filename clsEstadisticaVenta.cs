using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanWear
{
    internal class clsEstadisticaVenta
    {
        #region Conexión
        private readonly string CadenaConexion = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=UrbanWear.mdb";
        #endregion

        #region Métodos Públicos
        public List<KeyValuePair<string, int>> ObtenerVentasPorMes(DateTime desde, DateTime hasta)
        {
            var lista = new List<KeyValuePair<string, int>>();

            try
            {
                string consulta = @"
                    SELECT FORMAT(Fecha, 'mm/yyyy') AS Mes, SUM(Total) AS Total
                    FROM Venta
                    WHERE Fecha BETWEEN ? AND ?
                    GROUP BY FORMAT(Fecha, 'mm/yyyy')
                    ORDER BY MIN(Fecha)";

                using (var conexion = new OleDbConnection(CadenaConexion))
                using (var comando = new OleDbCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("?", desde);
                    comando.Parameters.AddWithValue("?", hasta);

                    conexion.Open();

                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            string mes = lector["Mes"].ToString();
                            int total = Convert.ToInt32(lector["Total"]);
                            lista.Add(new KeyValuePair<string, int>(mes, total));
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return lista;
        }

        public List<KeyValuePair<string, int>> ObtenerVentasPorCliente(DateTime desde, DateTime hasta)
        {
            var lista = new List<KeyValuePair<string, int>>();

            try
            {
                string consulta = @"
            SELECT 
                (C.Nombre & ' ' & C.Apellido) AS Cliente, 
                SUM(V.Total) AS Total
            FROM Venta V
            INNER JOIN Cliente C ON V.IDCliente = C.IDCliente
            WHERE V.Fecha BETWEEN ? AND ?
            GROUP BY C.Nombre, C.Apellido
            ORDER BY SUM(V.Total) DESC";

                using (var conexion = new OleDbConnection(CadenaConexion))
                using (var comando = new OleDbCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("?", desde);
                    comando.Parameters.AddWithValue("?", hasta);

                    conexion.Open();
                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            string cliente = lector["Cliente"].ToString();
                            int total = Convert.ToInt32(lector["Total"]);
                            lista.Add(new KeyValuePair<string, int>(cliente, total));
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return lista;
        }

        public List<KeyValuePair<string, int>> ObtenerVentasPorVendedor(DateTime desde, DateTime hasta)
        {
            var lista = new List<KeyValuePair<string, int>>();

            try
            {
                string consulta = @"
            SELECT 
                (V.Nombre & ' ' & V.Apellido) AS Vendedor, 
                SUM(Ve.Total) AS Total
            FROM Venta Ve
            INNER JOIN Vendedor V ON Ve.IDVendedor = V.IDVendedor
            WHERE Ve.Fecha BETWEEN ? AND ?
            GROUP BY V.Nombre, V.Apellido
            ORDER BY SUM(Ve.Total) DESC";

                using (var conexion = new OleDbConnection(CadenaConexion))
                using (var comando = new OleDbCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("?", desde);
                    comando.Parameters.AddWithValue("?", hasta);

                    conexion.Open();
                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            string vendedor = lector["Vendedor"].ToString();
                            int total = Convert.ToInt32(lector["Total"]);
                            lista.Add(new KeyValuePair<string, int>(vendedor, total));
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return lista;
        }
        #endregion
    }
}
