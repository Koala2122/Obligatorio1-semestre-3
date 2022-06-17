using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using FeriaDelLibro2.Dominio;

namespace FeriaDelLibro2.Persistencia
{
    public class PersistenciaGenero
    {
        readonly Conexion conexión = new Conexion();

        public bool Existe(Genero pGenero)
        {
            if (pGenero == null) { return false; }

            string sql = "SELECT * FROM Genero WHERE id =" + pGenero.Id.ToString();
            DataSet resultado = conexión.Selección(sql);

            if (resultado == null) { return false; }
            return resultado.Tables[0].Rows.Count > 0;  // prueba que existe pGenero
        }

        public bool AltaGenero(Genero pGenero)
        {
            if (pGenero == null) { return false; }
            if (this.Existe(pGenero)) { return false; }

            string sql = "INSERT INTO Genero (Id, Clasificacion) VALUES("

                                + pGenero.Id.ToString() + ","
                                + "'" + pGenero.Clasificacion.ToString() + " ')";


            return conexión.Consulta(sql);
        }

        public bool BajaGenero(Genero pGenero)
        {
            if (pGenero == null) { return false; }
            if (!this.Existe(pGenero)) { return false; }

            string sql = "DELETE FROM Genero WHERE id=" + pGenero.Id.ToString();
            return conexión.Consulta(sql);
        }
        public bool ModificarGenero(Genero pGenero)
        {
            if (pGenero == null) { return false; }
            if (!this.Existe(pGenero)) { return false; }

            string sql = "UPDATE genero SET"
                + " Clasificacion='" + pGenero.Clasificacion
                + "'WHERE Id=" + pGenero.Id.ToString();

            return conexión.Consulta(sql);
        }
        public List<Genero> ListaGenero()
        {
            string sql = "SELECT * FROM genero";
            DataSet datos = this.conexión.Selección(sql);
            List<Genero> lista = new List<Genero>();
            foreach (DataRow fila in datos.Tables[0].Rows)
            {
                Genero unGenero = new Genero(
                     short.Parse(fila[0].ToString()),
                     fila[1].ToString());

                lista.Add(unGenero);
            }
            return lista;
        }
    }
}