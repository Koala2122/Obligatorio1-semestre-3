using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using FeriaDelLibro2.Dominio;
namespace FeriaDelLibro2.Persistencia
{
    public class PersistenciaAutor
    {
        readonly Conexion conexión = new Conexion();

        public bool Existe(Autor pAutor)
        {
            if (pAutor == null) { return false; }

            string sql = "SELECT * FROM autor WHERE id =" + pAutor.Id.ToString();
            DataSet resultado = conexión.Selección(sql);

            if (resultado == null) { return false; }
            return resultado.Tables[0].Rows.Count > 0;  // prueba que existe pAutor
        }

        public bool AltaAutor(Autor pAutor)
        {
            if (pAutor == null) { return false; }
            if (this.Existe(pAutor)) { return false; }

            string sql = "INSERT INTO autor (Id, Nombre, Apellido, Direccion, Telefono, FechaDeMuerte, FechaDeNacimiento , Nacionalidad ) VALUES("

                               + pAutor.Id.ToString()  +","
                               + "'" + pAutor.Nombre.ToString() + " ',"
                               + "'" + pAutor.Apellido.ToString() + " ',"
                               + "'" + pAutor.Direccion.ToString() + " ',"
                               + "'" + pAutor.Telefono.ToString() + " ',"
                               + "'" + pAutor.FechaDemuerte.ToString() + " ',"
                               + "'" + pAutor.FechaDeNacimiento.ToString() + " ',"
                               + "'" + pAutor.Nacionalidad.ToString() + " ')";
            return conexión.Consulta(sql);
        }

        public bool BajaAutor(Autor pAutor)
        {
            if (pAutor == null) { return false; }
            if (!this.Existe(pAutor)) { return false; }

            string sql = "DELETE FROM autor WHERE id=" + pAutor.Id.ToString();
            return conexión.Consulta(sql);
        }
        public bool ModificarAutor(Autor pAutor)
        {
            if (pAutor == null) { return false; }
            if (!this.Existe(pAutor)) { return false; }

            string sql = "UPDATE autor SET"
                + " Nombre='" + pAutor.Nombre
                + "', Apellido='" + pAutor.Apellido
                + "', Direccion='" + pAutor.Direccion
                + "', Telefono='" + pAutor.Telefono
                + "', FechaDeMuerte='" + pAutor.FechaDemuerte.ToString()
                + "', FechaDeNacimiento='" + pAutor.FechaDeNacimiento.ToString()
                + "', Nacionalidad='" + pAutor.Nacionalidad
                + "' WHERE Id= " + pAutor.Id.ToString();

            return conexión.Consulta(sql);
        }
        public List<Autor> ListaAutor()
        {

  
          string sql = "SELECT * FROM autor";
            DataSet datos = this.conexión.Selección(sql);
            List<Autor> lista = new List<Autor>();
            foreach (DataRow fila in datos.Tables[0].Rows)
            {
                Autor unAutor = new Autor(
                     short.Parse(fila[0].ToString()),
                     fila[1].ToString(),
                     fila[2].ToString(),
                     fila[3].ToString(),
                     fila[4].ToString(),
                     DateTime.Parse(fila[5].ToString()),
                     DateTime.Parse(fila[6].ToString()),
                     fila[7].ToString());
                lista.Add(unAutor);
            }

            return lista;
        }
    }

}
