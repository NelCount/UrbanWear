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
    internal class clsCliente
    {
        #region Propiedades públicas
        public int IDCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        public long Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public int IDLocalidad { get; set; }
        #endregion

        #region Conexión
        private readonly string CadenaConexion = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=UrbanWear.mdb";
        private readonly string Tabla = "Cliente";
        #endregion

        #region Métodos públicos
        public void Agregar()
        {
            try
            {
                using (var conexion = new OleDbConnection(CadenaConexion))
                {
                    string consulta = $"INSERT INTO {Tabla} (Nombre, Apellido, DNI, Telefono, Email, Direccion, IDLocalidad) " +
                                      "VALUES (?, ?, ?, ?, ?, ?, ?)";

                    using (var comando = new OleDbCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@Nombre", Nombre);
                        comando.Parameters.AddWithValue("@Apellido", Apellido);
                        comando.Parameters.AddWithValue("@DNI", DNI);
                        comando.Parameters.AddWithValue("@Telefono", Telefono);
                        comando.Parameters.AddWithValue("@Email", Email);
                        comando.Parameters.AddWithValue("@Direccion", Direccion);
                        comando.Parameters.AddWithValue("@IDLocalidad", IDLocalidad);

                        conexion.Open();
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable ListarClientes()
        {
            var tabla = new DataTable();

            try
            {
                using (var conexion = new OleDbConnection(CadenaConexion))
                {
                    string consulta = @"
                SELECT 
                    Cliente.IDCliente, 
                    Cliente.Nombre, 
                    Cliente.Apellido, 
                    Cliente.DNI, 
                    Cliente.Telefono, 
                    Cliente.Email, 
                    Cliente.Direccion, 
                    Localidad.Nombre AS Localidad
                FROM 
                    Localidad 
                    INNER JOIN Cliente ON Localidad.IDLocalidad = Cliente.IDLocalidad";

                    using (var comando = new OleDbCommand(consulta, conexion))
                    using (var adaptador = new OleDbDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return tabla;
        }

        public void Modificar()
        {
            try
            {
                using (var conexion = new OleDbConnection(CadenaConexion))
                {
                    string consulta = $@"
                UPDATE {Tabla} 
                SET Nombre = ?, Apellido = ?, DNI = ?, Telefono = ?, Email = ?, Direccion = ?, IDLocalidad = ?
                WHERE IDCliente = ?";

                    using (var comando = new OleDbCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@Nombre", Nombre);
                        comando.Parameters.AddWithValue("@Apellido", Apellido);
                        comando.Parameters.AddWithValue("@DNI", DNI);
                        comando.Parameters.AddWithValue("@Telefono", Telefono);
                        comando.Parameters.AddWithValue("@Email", Email);
                        comando.Parameters.AddWithValue("@Direccion", Direccion);
                        comando.Parameters.AddWithValue("@IDLocalidad", IDLocalidad);
                        comando.Parameters.AddWithValue("@IDCliente", IDCliente); 

                        conexion.Open();
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                using (var conexion = new OleDbConnection(CadenaConexion))
                {
                    string consulta = $"DELETE FROM {Tabla} WHERE IDCliente = ?";

                    using (var comando = new OleDbCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@IDCliente", id);
                        conexion.Open();
                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
     
        /// Devuelve los datos del cliente según el DNI exacto buscado. 
        /// Se usa para modificar o eliminar un cliente.       
        public DataTable BuscarPorDNI(int dniBuscado)
        {
            var tabla = new DataTable();

            try
            {
                using (var conexion = new OleDbConnection(CadenaConexion))
                {
                    string consulta = @"
                SELECT 
                    Cliente.IDCliente AS Codigo, 
                    Cliente.Nombre, 
                    Cliente.Apellido, 
                    Cliente.DNI, 
                    Cliente.Telefono, 
                    Cliente.Email, 
                    Cliente.Direccion,
                    Localidad.Nombre AS Localidad
                FROM 
                    Localidad 
                    INNER JOIN Cliente ON Localidad.IDLocalidad = Cliente.IDLocalidad
                WHERE 
                    Cliente.DNI = ?";

                    using (var comando = new OleDbCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@DNI", dniBuscado);

                        using (var adaptador = new OleDbDataAdapter(comando))
                        {
                            adaptador.Fill(tabla);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return tabla;
        }

        public DataTable BuscarClientes(string dni, string nombre, string apellido, string localidad)
        {
            var tabla = new DataTable();

            try
            {
                using (var conexion = new OleDbConnection(CadenaConexion))
                {
                    string consulta = @"
                SELECT 
                    Cliente.IDCliente AS Codigo, 
                    Cliente.Nombre, 
                    Cliente.Apellido, 
                    Cliente.DNI, 
                    Cliente.Telefono, 
                    Cliente.Email, 
                    Cliente.Direccion, 
                    Localidad.Nombre AS Localidad
                FROM 
                    Cliente 
                    INNER JOIN Localidad ON Cliente.IDLocalidad = Localidad.IDLocalidad
                WHERE 
                    (Cliente.DNI LIKE ? OR ? = '')
                    AND (Cliente.Nombre LIKE ? OR ? = '')
                    AND (Cliente.Apellido LIKE ? OR ? = '')
                    AND (Localidad.Nombre LIKE ? OR ? = '')";

                    using (var comando = new OleDbCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@DNI1", $"%{dni}%");
                        comando.Parameters.AddWithValue("@DNI2", dni);
                        comando.Parameters.AddWithValue("@Nombre1", $"%{nombre}%");
                        comando.Parameters.AddWithValue("@Nombre2", nombre);
                        comando.Parameters.AddWithValue("@Apellido1", $"%{apellido}%");
                        comando.Parameters.AddWithValue("@Apellido2", apellido);
                        comando.Parameters.AddWithValue("@Localidad1", $"%{localidad}%");
                        comando.Parameters.AddWithValue("@Localidad2", localidad);

                        using (var adaptador = new OleDbDataAdapter(comando))
                        {
                            adaptador.Fill(tabla);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return tabla;
        }

        public DataTable Listar()
        {
            var tabla = new DataTable();

            try
            {
                using (var conexion = new OleDbConnection(CadenaConexion))
                {
                    string consulta = "SELECT IDCliente, (Nombre & ' ' & Apellido) AS NombreCompleto FROM Cliente";

                    using (var comando = new OleDbCommand(consulta, conexion))
                    using (var adaptador = new OleDbDataAdapter(comando))
                    {
                        conexion.Open();
                        adaptador.Fill(tabla);
                    }
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
