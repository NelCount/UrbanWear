using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrbanWear
{
    internal class clsCategoria
    {
        #region Propiedades Públicas
        public int IDCategoria { get; set; }
        public string Nombre { get; set; }
        #endregion

        #region Conexión
        private readonly string CadenaConexion = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=UrbanWear.mdb";
        private readonly string Tabla = "Categoria";
        #endregion

        #region Métodos Públicos       
        public DataTable Listar()
        {
            var tabla = new DataTable();

            try
            {
                using (var conexion = new OleDbConnection(CadenaConexion))
                {
                    string consulta = $"SELECT * FROM {Tabla}";

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
        #endregion
    }
}
