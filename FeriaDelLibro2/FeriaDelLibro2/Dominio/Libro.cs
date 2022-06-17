using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace FeriaDelLibro2.Dominio
{
    public class Libro
    {
        private short _idLibro;
        private string _titulo;
        private Genero _genero;
        private string _año;
        private Autor _autor;
        private Double _precio;
        private int _stock;
        private Pais _pais;


        #region Metodos de la Clase
        public short IdLibro
        {
            get
            {
                return _idLibro;
            }

            set
            {
                _idLibro = value;
            }
        }

        public string Titulo
        {
            get
            {
                return _titulo;
            }

            set
            {
                _titulo = value;
            }
        }

        public Genero Genero
        {
            get
            {
                return _genero;
            }

            set
            {
                _genero = value;
            }
        }

        public string Año
        {
            get
            {
                return _año;
            }

            set
            {
                _año = value;
            }
        }

        public Autor Autor
        {
            get
            {
                return _autor;
            }

            set
            {
                _autor = value;
            }
        }
        public Double Precio
        {
            get
            {
                return _precio;
            }

            set
            {
                _precio = value;
            }
        }
        public int Stock
        {
            get
            {
                return _stock;
            }

            set
            {
                _stock = value;
            }
        }
        public Pais Pais
        {
            get
            {
                return _pais;
            }

            set
            {
                _pais = value;
            }
        }

        public override string ToString()
        {

            return "ID: " + this.IdLibro + " TITULO: " + this.Titulo + " GENERO: " + this.Genero + " AÑO: " + this.Año + " AUTOR: " + this.Autor 
                + " PRECIO " + this.Precio + " STOCK " + this.Stock + " PAIS " + this.Pais;


        }

        public Libro(short pidLibro, string ptitulo, Genero pgenero, string paño, Autor pautor, Double pprecio, int pstock, Pais ppais)
        {
            this.IdLibro = pidLibro;
            this.Titulo = ptitulo;
            this.Genero = pgenero;
            this.Año = paño;
            this.Autor = pautor;
            this.Precio = pprecio;
            this.Stock = pstock;
            this.Pais = ppais;

        }


    }
    #endregion

}
