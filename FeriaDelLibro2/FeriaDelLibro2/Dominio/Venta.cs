using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using FeriaDelLibro2.Presentacion;

namespace FeriaDelLibro2.Dominio
{
    public class Venta
    {
        private short _idVenta;
        private DateTime _fechaVenta;
        private string _tituloLibro;
        private int _stockLibro;
        private Autor _autor;
        private Lector _lector;
        private short _precio;
        private Genero _genero;

        public short IdVenta
        {
            get
            {
                return _idVenta;
            }

            set
            {
                _idVenta = value;
            }
        }

        public DateTime FechaVenta
        {
            get
            {
                return _fechaVenta;
            }

            set
            {
                _fechaVenta = value;
            }
        }

        public string TituloLibro
        {
            get
            {
                return _tituloLibro;
            }

            set
            {
                _tituloLibro = value;
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

        public Lector Lector
        {
            get
            {
                return _lector;
            }

            set
            {
                _lector = value;
            }
        }

        public short Precio
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


        public int StockLibro
        {
            get
            {
                return _stockLibro;
            }

            set
            {
                _stockLibro = value;
            }
        }

        public Genero genero
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

        public override string ToString()
        {
            return "ID: " + this.IdVenta + " FECHA DE LA VENTA: " + this.FechaVenta + " TITULO: " + this.TituloLibro + " STOCK: " 
                + this.StockLibro + " AUTOR: " + this.Autor.Id + " LECTOR: " + this.Lector.Id + " PRECIO: " + this.Precio + " GENERO: " + this.genero;
        }

        public string DetalleAutor()
        {

            return "ID" + this.Autor.Id + "NOMBRE" + this.Autor.Apellido + "APELLIDO";
        }
        public string DetalleLector()
        {

            return "ID" + this.Lector.Id + "NOMBRE" + this.Lector.Apellido + "APELLIDO";
        }

        public string DetalleLibro()
        {

            return "TITULO" + this.TituloLibro + "TITULO" + this.StockLibro + "STOCK" + this.Precio + "PRECIO";
        }
        public Venta(short pIdVenta, DateTime pFechaVenta, string pTituloLibro, int pStockLibro, Autor pAutor, Lector pLector, short pPrecio, Genero pgenero)
        {
            this._idVenta = pIdVenta;
            this._fechaVenta = pFechaVenta;
            this._tituloLibro = pTituloLibro;
            this._stockLibro = pStockLibro;
            this._autor = pAutor;
            this._lector = pLector;
            this._precio = pPrecio;
            this._genero = pgenero;
        }
    }
}
