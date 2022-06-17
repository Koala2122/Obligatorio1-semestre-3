using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using FeriaDelLibro2.Dominio;

namespace FeriaDelLibro2.Persistencia
{
    public class PersistenciaPais
    {
        readonly Conexion conexión = new Conexion();

        public bool Existe(Pais pPais)
        {
            if (pPais == null) { return false; }

            string sql = "SELECT * FROM Pais WHERE id =" + pPais.Id.ToString();
            DataSet resultado = conexión.Selección(sql);

            if (resultado == null) { return false; }
            return resultado.Tables[0].Rows.Count > 0;  // prueba que existe pPais
        }

        public bool AltaPais(Pais pPais)
        {
            if (pPais == null) { return false; }
            if (this.Existe(pPais)) { return false; }

            string sql = "INSERT INTO Pais (Id, Nombre, Continente ) VALUES("

                                 + pPais.Id.ToString() + ","
                                + "'" + pPais.Nombre.ToString() + " ',"
                                + "'" + pPais.Continente.ToString() + " ')";
                               

            return this.conexión.Consulta(sql);
        }

        public bool BajaPais(Pais pPais)
        {
            if (pPais == null) { return false; }
            if (!this.Existe(pPais)) { return false; }

            string sql = "DELETE FROM Pais WHERE id=" + pPais.Id.ToString();
            return conexión.Consulta(sql);
        }
        public bool ModificarPais(Pais pPais)

        {
            if (pPais == null) { return false; }
            if (!this.Existe(pPais)) { return false; }

            string sql = "UPDATE pais SET"
                + " Nombre='" + pPais.Nombre
                + "',Continente='" + pPais.Continente
                + "'WHERE Id= " + pPais.Id.ToString();

            return this.conexión.Consulta(sql);
        }
        public List<Pais> ListaPais()
        {
            string sql = "SELECT * FROM pais";
            DataSet datos = this.conexión.Selección(sql);
            List<Pais> lista = new List<Pais>();
            foreach (DataRow fila in datos.Tables[0].Rows)
            {
               Pais unPais = new Pais(
                    short.Parse(fila[0].ToString()),
                    fila[1].ToString(),
                    fila[2].ToString());
                lista.Add(unPais);
            }
            return lista;
        }
    }
}