using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace FeriaDelLibro2.Dominio
{
    public class Autor:Persona
    {

        private DateTime _fechaDemuerte;
        private DateTime _fechaDeNacimiento;
        private string _nacionalidad;

        public DateTime FechaDemuerte
        {
            get
            {
                return _fechaDemuerte;
            }

            set
            {
                _fechaDemuerte = value;
            }
        }

        public DateTime FechaDeNacimiento
        {
            get
            {
                return _fechaDeNacimiento;
            }

            set
            {
                _fechaDeNacimiento = value;
            }
        }

        public string Nacionalidad
        {
            get
            {
                return _nacionalidad;
            }

            set
            {
                _nacionalidad = value;
            }
        }
        public override string ToString()
        {
            return "ID: " + this.Id + " NOMBRE: " + this.Nombre + " APELLIDO: " + this.Apellido + " DIRECCION: " + this.Direccion + " TELEFONO: " + this.Telefono + "FECHA DE NACIMIENTO" + this.FechaDeNacimiento + " FECHA DE MUERTE: " + this.FechaDemuerte + " NACIONALIDAD: " +
            this.Nacionalidad;
        }
        public Autor(short pId, string pNombre, string pApellido, string pDireccion, string pTelefono, DateTime pFechaDemuerte, DateTime pFechaDeNacimiento, string pNacionalidad)
            : base(pId, pNombre, pApellido, pDireccion, pTelefono)

        {

            this.FechaDemuerte = pFechaDemuerte;
            this.FechaDeNacimiento = pFechaDeNacimiento;
            this.Nacionalidad = pNacionalidad;
        }

        public Autor(short pId, string pNombre, string pApellido, string pDireccion, string pTelefono, DateTime pFechaDeNacimiento, string pNacionalidad)
            : base(pId, pNombre, pApellido, pDireccion, pTelefono)

        {
            this.FechaDeNacimiento = pFechaDeNacimiento;
            this.Nacionalidad = pNacionalidad;
        }
    }
}