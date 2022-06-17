using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Reflection;
using System.Web.Hosting;
namespace FeriaDelLibro2.Persistencia
{
    public class Conexion
    {
        readonly string cadenaConexion;
        public Conexion()
        {
            
            cadenaConexion = "data source=EQUIPO;" +

                     "Initial Catalog=FeriaDelLibro; uid =sa; pwd =root";

          
        }

        public bool Consulta(string sql)
        {
            try
            {
                SqlConnection conexión = new SqlConnection(cadenaConexion);
                SqlCommand comando = new SqlCommand(sql, conexión);
                conexión.Open();
                comando.ExecuteNonQuery();
                comando.Dispose();
                conexión.Close();
                return true;
            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                System.Diagnostics.Debug.WriteLine("Sql Exception.Number= " + e.Message);
                return false;
            }
        }
        public DataSet Selección(string sql)
        {
            try
            {
                SqlConnection conexión = new SqlConnection(cadenaConexion);
                SqlDataAdapter adaptador = new SqlDataAdapter(sql, conexión);
                DataSet resultado = new DataSet();
                conexión.Open();
                adaptador.Fill(resultado);
                adaptador.Dispose();
                conexión.Close();
                return resultado;

            }
            catch (Exception e)
            {

                return null;
            }

        }
    }
}