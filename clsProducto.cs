using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace UrbanWear
{
    internal class clsProducto
    {
        #region Campos privados 
        private string nombre;
        private decimal precio;
        private int cantidad;
        #endregion

        #region Propiedades públicas
        public int IDProducto { get; set; }
        public string Nombre
        {
            get => nombre;
            set => nombre = string.IsNullOrWhiteSpace(value) ? "Sin nombre" : value;
        }
        public string Talle { get; set; }
        public string Color { get; set; }
        public decimal Precio
        {
            get => precio;
            set => precio = value < 0 ? 0 : value;
        }
        public int Cantidad
        {
            get => cantidad;
            set => cantidad = value < 0 ? 0 : value;
        }
        public int IDCategoria { get; set; }
        #endregion

        #region Conexión
        private readonly string CadenaConexion = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=UrbanWear.mdb";
        private readonly string Tabla = "Producto";
        #endregion

        #region Métodos públicos
        public DataTable Listar()
        {
            var tabla = new DataTable();

            try
            {
                using (var conexion = new OleDbConnection(CadenaConexion))
                {
                    var consulta = $"SELECT * FROM {Tabla}";
                    using (var adaptador = new OleDbDataAdapter(consulta, conexion))
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

        public void Agregar()
        {
            try
            {
                using (var conexion = new OleDbConnection(CadenaConexion))
                {
                    var query = $"INSERT INTO {Tabla} (Nombre, Talle, Color, Precio, Cantidad, IDCategoria) " +
                                $"VALUES (@Nombre, @Talle, @Color, @Precio, @Cantidad, @IDCategoria)";

                    using (var comando = new OleDbCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Nombre", Nombre);
                        comando.Parameters.AddWithValue("@Talle", Talle);
                        comando.Parameters.AddWithValue("@Color", Color);
                        comando.Parameters.AddWithValue("@Precio", Precio);
                        comando.Parameters.AddWithValue("@Cantidad", Cantidad);
                        comando.Parameters.AddWithValue("@IDCategoria", IDCategoria);

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
                    string consulta = $"DELETE FROM {Tabla} WHERE IDProducto = @ID";

                    using (var comando = new OleDbCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID", id);
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

        public void Modificar()
        {
            try
            {
                using (var conexion = new OleDbConnection(CadenaConexion))
                {
                    string consulta = $"UPDATE {Tabla} SET Nombre = ?, Talle = ?, Color = ?, " +
                        $"Precio = ?, Cantidad = ?, IDCategoria = ? WHERE IDProducto = ?";

                    using (var comando = new OleDbCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@Nombre", Nombre);
                        comando.Parameters.AddWithValue("@Talle", Talle);
                        comando.Parameters.AddWithValue("@Color", Color);
                        comando.Parameters.AddWithValue("@Precio", Precio);
                        comando.Parameters.AddWithValue("@Cantidad", Cantidad);
                        comando.Parameters.AddWithValue("@IDCategoria", IDCategoria);
                        comando.Parameters.AddWithValue("@IDProducto", IDProducto);

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

        public DataTable BuscarPorNombre(string nombreBuscado)
        {
            var tabla = new DataTable();

            try
            {
                using (var conexion = new OleDbConnection(CadenaConexion))
                {
                    string consulta = @"
                SELECT 
                    Producto.IDProducto, 
                    Producto.Nombre, 
                    Producto.Talle, 
                    Producto.Color, 
                    Producto.Precio, 
                    Producto.Cantidad, 
                    Categoria.Nombre AS Categoria
                FROM 
                    Categoria 
                    INNER JOIN Producto ON Categoria.IDCategoria = Producto.IDCategoria
                WHERE 
                    UCASE(Producto.Nombre) LIKE UCASE(?)";

                    using (var comando = new OleDbCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@Nombre", "%" + nombreBuscado + "%");

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

        public string ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
                return "El nombre no puede estar vacío.";
            if (string.IsNullOrWhiteSpace(Talle))
                return "Seleccioná un talle.";
            if (string.IsNullOrWhiteSpace(Color))
                return "Seleccioná un color."; 
            if (Precio <= 0)
                return "El precio debe ser mayor a cero."; 
            if (Cantidad <= 0)
                return "La cantidad debe ser mayor a cero.";
            if (IDCategoria <= 0)
                return "Seleccioná una categoría.";
            return "";
        }

        public static clsProducto DesdeFormulario(TextBox txtNombre, ComboBox cmbTalle, ComboBox cmbColor,
                                          NumericUpDown numPrecio, NumericUpDown numCantidad, 
                                          ComboBox cmbCategoria)
        {
            return new clsProducto
            {
                Nombre = txtNombre.Text.Trim(),
                Talle = cmbTalle.Text,
                Color = cmbColor.Text,
                Precio = numPrecio.Value,
                Cantidad = (int)numCantidad.Value,
                IDCategoria = Convert.ToInt32(cmbCategoria.SelectedValue)
            };
        }

        public DataTable FiltrarProductos(string nombre, string talle, string color, int? idCategoria)
        {
            var tabla = new DataTable();

            try
            {
                using (var conexion = new OleDbConnection(CadenaConexion))
                {
                    string consulta = @"
                SELECT 
                    Producto.IDProducto AS Codigo, 
                    Producto.Nombre, 
                    Producto.Talle, 
                    Producto.Color, 
                    Producto.Precio, 
                    Producto.Cantidad, 
                    Categoria.Nombre AS Categoria
                FROM 
                    Producto
                    INNER JOIN Categoria ON Producto.IDCategoria = Categoria.IDCategoria
                WHERE 
                    (Producto.Nombre LIKE ? OR ? = '')
                    AND (Producto.Talle LIKE ? OR ? = '')
                    AND (Producto.Color LIKE ? OR ? = '')
                    AND (Producto.IDCategoria = ? OR ? IS NULL)";

                    using (var comando = new OleDbCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@Nombre1", $"%{nombre}%");
                        comando.Parameters.AddWithValue("@Nombre2", nombre);
                        comando.Parameters.AddWithValue("@Talle1", $"%{talle}%");
                        comando.Parameters.AddWithValue("@Talle2", talle);
                        comando.Parameters.AddWithValue("@Color1", $"%{color}%");
                        comando.Parameters.AddWithValue("@Color2", color);
                        comando.Parameters.AddWithValue("@Categoria1", idCategoria.HasValue ? (object)idCategoria.Value : DBNull.Value);
                        comando.Parameters.AddWithValue("@Categoria2", idCategoria.HasValue ? (object)idCategoria.Value : DBNull.Value);

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

        public DataTable BuscarBajoStock(int cantidadProductos)
        {
            var tabla = new DataTable();

            try
            {
                using (var conexion = new OleDbConnection(CadenaConexion))
                {
                    string consulta = @"
                SELECT 
                    Producto.IDProducto AS Código, 
                    Producto.Nombre, 
                    Producto.Talle,
                    Producto.Color, 
                    Producto.Precio, 
                    Producto.Cantidad, 
                    Categoria.Nombre AS Categoría
                FROM
                    Categoria
                    INNER JOIN Producto ON Categoria.IDCategoria = Producto.IDCategoria
                WHERE Producto.Cantidad <= ?";

                    using (var comando = new OleDbCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@Cantidad", cantidadProductos);

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

        public DataTable ListarProductos()
        {
            var tabla = new DataTable();

            try
            {
                using (var conexion = new OleDbConnection(CadenaConexion))
                {
                    string consulta = $"SELECT IDProducto, Nombre FROM {Tabla} WHERE Precio > 0 AND Cantidad > 0";

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

        public decimal ObtenerPrecio(int idProducto)
        {
            decimal precio = 0;

            try
            {
                using (var conexion = new OleDbConnection(CadenaConexion))
                {
                    string consulta = $"SELECT Precio FROM {Tabla} WHERE IDProducto = ?";

                    using (var comando = new OleDbCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@ID", idProducto);
                        conexion.Open();

                        var resultado = comando.ExecuteScalar();
                        if (resultado != null && resultado != DBNull.Value)
                        {
                            precio = Convert.ToDecimal(resultado);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return precio;
        }

        public void ActualizarStock(int idProducto, int cantidadRestar)
        {
            try
            {
                using (var conexion = new OleDbConnection(CadenaConexion))
                {
                    string consulta = $"UPDATE {Tabla} SET Cantidad = Cantidad - ? WHERE IDProducto = ?";

                    using (var comando = new OleDbCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@CantidadRestar", cantidadRestar);
                        comando.Parameters.AddWithValue("@ID", idProducto);

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
        #endregion
    }
}
