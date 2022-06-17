using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace FeriaDelLibro2.Dominio
{
    public class Genero
    {
        private short _id;
        private string _clasificacion;

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

        public string Clasificacion
        {
            get
            {
                return _clasificacion;
            }

            set
            {
                _clasificacion = value;
            }
        }
        public override string ToString()
        {
            return this.Id + " " + this.Clasificacion;
        }
        public Genero(short pid, string pclasificacion)
        {
            this.Id = pid;
            this.Clasificacion = pclasificacion;
        }
    }
}