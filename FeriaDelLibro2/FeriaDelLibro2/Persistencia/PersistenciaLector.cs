using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using FeriaDelLibro2.Dominio;
namespace FeriaDelLibro2.Persistencia
{
    public class PersistenciaLector
    {
        readonly Conexion conexión = new Conexion();

        public bool Existe(Lector pLector)
        {
            if (pLector == null) { return false; }

            string sql = "SELECT * FROM Lector WHERE id =" + pLector.Id.ToString();
            DataSet resultado = conexión.Selección(sql);

            if (resultado == null) { return false; }
            return resultado.Tables[0].Rows.Count > 0;  // prueba que existe pLector
        }

        public bool AltaLector(Lector pLector)
        {
            if (pLector == null) { return false; }
            if (this.Existe(pLector)) { return false; }

            string sql = "INSERT INTO lector (Id, Nombre, Apellido, Direccion, Telefono ) VALUES("
                                + pLector.Id.ToString() + ","
                                + "'" + pLector.Nombre.ToString() + " ',"
                                + "'" + pLector.Apellido.ToString() + " ',"
                                + "'" + pLector.Direccion.ToString() + " ',"
                                + "'" + pLector.Telefono.ToString() + " ')";


            return this.conexión.Consulta(sql);
        }

        public bool BajaLector(Lector pLector)
        {
            if (pLector == null) { return false; }
            if (!this.Existe(pLector)) { return false; }

            string sql = "DELETE FROM lector WHERE id=" + pLector.Id.ToString();
            return conexión.Consulta(sql);
        }
        public bool ModificarLector(Lector pLector)
        {
            if (pLector == null) { return false; }
            if (!this.Existe(pLector)) { return false; }

            string sql = "UPDATE lector SET"
                + " Nombre='" + pLector.Nombre
                + "', Apellido='" + pLector.Apellido
                + "', Direccion='" + pLector.Direccion
                + "', Telefono='" + pLector.Telefono
                + "' WHERE Id= " + pLector.Id.ToString();

            return this.conexión.Consulta(sql);
        }
        public List<Lector> ListaLector()
        {
            string sql = "SELECT * FROM lector";
            DataSet datos = this.conexión.Selección(sql);
            List<Lector> lista = new List<Lector>();
            foreach (DataRow fila in datos.Tables[0].Rows)
            {
                Lector unLector = new Lector(
                 short.Parse(fila[0].ToString()),
                    fila[1].ToString(),
                    fila[2].ToString(),
                    fila[3].ToString(),
                    fila[4].ToString());
                lista.Add(unLector);
            }

            return lista;
        }
    }
}