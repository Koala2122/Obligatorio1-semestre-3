using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
namespace FeriaDelLibro2.Dominio
{
    public class Pais
    {
        private short _id;
        private string _nombre;
        private string _continente;

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
        public string Continente
        {
            get
            {
                return _continente;
            }

            set
            {
                _continente = value;
            }
        }
        public Pais() { }
        public override string ToString()
        {
            return this.Id + " " + this.Nombre + " " + this.Continente ;
        }
        public Pais(short pid, string pnombre, string pcontinente)
        {
            this.Id = pid;
            this.Nombre = pnombre;
            this.Continente = pcontinente;
            
        }
    }
    
}