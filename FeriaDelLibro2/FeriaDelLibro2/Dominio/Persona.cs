using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeriaDelLibro2.Dominio
{
    public class Persona
    {
        private short _id;
        private string _nombre;
        private string _apellido;
        private string _direccion;
        private string _telefono;
        //* Metodos de la Clase
        public short Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return _apellido;
            }

            set
            {
                _apellido = value;
            }
        }

        public string Direccion
        {
            get
            {
                return _direccion;
            }

            set
            {
                _direccion = value;
            }
        }

        public string Telefono
        {
            get
            {
                return _telefono;
            }

            set
            {
                _telefono = value;
            }
        }
        public override string ToString()
        {
            return this.Id + " " + this.Nombre + " " + this.Apellido + " " + this.Direccion + " " + this.Telefono;
        }
        public Persona(short pid, string pnombre, string papellido, string pdireccion, string ptelefono)
        {
            this.Id = pid;
            this.Nombre = pnombre;
            this.Apellido = papellido;
            this.Direccion = pdireccion;
            this.Telefono = ptelefono;
        }
        
    }
}