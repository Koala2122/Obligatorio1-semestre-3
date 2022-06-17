using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace FeriaDelLibro2.Dominio
{
    public class Lector:Persona
    {


        public override string ToString()
        {
            return "ID: " + this.Id + " NOMBRE: " + this.Nombre + " APELLIDO: " + this.Apellido + " DIRECCION: " + this.Direccion + " TELEFONO: " + this.Telefono;
        }

      

        public Lector(short pId, string pNombre, string pApellido, string pDireccion, string pTelefono) : base(pId, pNombre, pApellido, pDireccion, pTelefono)
        {

            this.Id = pId;
            this.Nombre = pNombre;
            this.Apellido = pApellido;
            this.Direccion = pDireccion;
            this.Telefono = pTelefono;

        }

    }
}