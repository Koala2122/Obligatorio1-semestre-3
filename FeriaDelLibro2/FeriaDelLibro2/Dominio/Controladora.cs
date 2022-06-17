using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using FeriaDelLibro2.Persistencia;
namespace FeriaDelLibro2.Dominio
{
    public class Controladora
    {

        private static List<Libro> _listaL = new List<Libro>();
        private static List<Autor> _listaA = new List<Autor>();
        private static List<Lector> _listaLec = new List<Lector>();
        private static List<Genero> _listaGen = new List<Genero>();
        private static List<Pais> _listaPais = new List<Pais>();
        private static List<Venta> _listaVenta = new List<Venta>();
        private ControladoraPersistencia _persistencia;

        public Controladora()
        {
            this._persistencia = new ControladoraPersistencia();
           _listaA = _persistencia.ListaAutor();
           _listaLec = _persistencia.ListaLector();
           _listaPais = _persistencia.ListaPais();
           _listaGen = _persistencia.ListaGenero();

        }

        #region ABMLibro
        public List<Libro> ListaL()
        {
            return _listaL;
        }

        public List<Libro> ListaOrdenadaLibro()
        {
            List<Libro> LibroOrdenados = new List<Libro>(_listaL);
            Libro auxLibro;
            for (int i = 0; i < LibroOrdenados.Count; i++)
            {
                for (int j = 0; j < LibroOrdenados.Count - 1; j++)
                {
                    if (LibroOrdenados[j].Titulo.ToUpper().CompareTo(LibroOrdenados[j + 1].Titulo.ToUpper()) > 0)
                    {
                        auxLibro = LibroOrdenados[j];
                        LibroOrdenados[j] = LibroOrdenados[j + 1];
                        LibroOrdenados[j + 1] = auxLibro;
                    }
                }
            }
            return LibroOrdenados;
        }

        public Libro buscarLibro(short pIdLibro)
        {
            if (_listaL.Count > 0)
            {
                foreach (Libro unLibro in _listaL)
                {
                    if (unLibro.IdLibro == pIdLibro)
                        return unLibro;
                }
            }
            return null;
        }
        public bool AgregarLibro(Libro pLibro)
        {
            Libro unLibro = this.buscarLibro(pLibro.IdLibro);
            if (unLibro == null)
            {
                _listaL.Add(pLibro);
                return true;
            }
            return false;
        }
        public bool EliminarLibro(short pIdLibro)
        {
            Libro unLibro = this.buscarLibro(pIdLibro);
            if (unLibro != null)
            {
                _listaL.Remove(unLibro);
                return true;
            }
            return false;
        }
        public bool ModificarLibro(short pIdLibro, string pTitulo, Genero pGenero, string pAño, Autor pAutor, Double pPrecio, int pStock, Pais pPais)
        {
            Libro unLibro = this.buscarLibro(pIdLibro);
            if (unLibro != null)
            {
                unLibro.Titulo = pTitulo;
                unLibro.Genero = pGenero;
                unLibro.Año = pAño;
                unLibro.Autor = pAutor;
                unLibro.Precio = pPrecio;
                unLibro.Stock = pStock;
                unLibro.Pais = pPais;
                return true;
            }
            return false;
        }

       

        #endregion

        #region ABMAutor

        public List<Autor> ListaA()
        {
            return _listaA;
        }
        public Autor buscarAutor(short pId)
        {
            if (_listaA.Count > 0)
            {
                foreach (Autor unAutor in _listaA)
                {
                    if (unAutor.Id == pId)
                        return unAutor;
                }
            }
            return null;
        }



        public List<Autor> ListaOrdenadaAutor()
        {
            List<Autor> AutorOrdenados = new List<Autor>(_listaA);
            Autor auxAutor;
            for (int i = 0; i < AutorOrdenados.Count; i++)
            {
                for (int j = 0; j < AutorOrdenados.Count - 1; j++)
                {
                    if (AutorOrdenados[j].Nombre.ToUpper().CompareTo(AutorOrdenados[j + 1].Nombre.ToUpper()) > 0)
                    {
                        auxAutor = AutorOrdenados[j];
                        AutorOrdenados[j] = AutorOrdenados[j + 1];
                        AutorOrdenados[j + 1] = auxAutor;
                    }
                }
            }
            return AutorOrdenados;
        }





        public bool AgregarAutor(Autor pAutor)
        {
            Autor unAutor = this.buscarAutor(pAutor.Id);

            if (unAutor == null)
            {
                if (_persistencia.AltaAutor(pAutor))
                {
                    _listaA.Add(pAutor);
                    return true;
                }
            }
            return false;
        }

        public bool BajaAutor(short pId)
        {
            Autor unAutor = this.buscarAutor(pId);
            if (unAutor != null)
            {
                if (this._persistencia.BajaAutor(unAutor))
                {
                    _listaA.Remove(unAutor);
                    return true;
                }
            }
            return false;
        }

        public bool ModificarAutor(Autor pAutor)
        {
            Autor unAutor = this.buscarAutor(pAutor.Id);
            if (unAutor != null)
            {
                if (this._persistencia.ModificarAutor(pAutor)) 
                {
                    unAutor.Nombre = pAutor.Nombre;
                    unAutor.Apellido = pAutor.Apellido;
                    unAutor.Direccion = pAutor.Direccion;
                    unAutor.Telefono = pAutor.Telefono;
                    unAutor.FechaDemuerte = pAutor.FechaDemuerte;
                    unAutor.FechaDeNacimiento = pAutor.FechaDeNacimiento;
                    unAutor.Nacionalidad = pAutor.Nacionalidad;
                    return true;
                }
            }

            return false;

        }

        #endregion



        #region ABMLector


        public List<Lector> ListaLec()
        {
            return _listaLec;
        }

        public Lector buscarLector(short pId)
        {
            if (_listaLec.Count > 0)
            {
                foreach (Lector unLector in _listaLec)
                {
                    if (unLector.Id == pId)
                        return unLector;
                }

            }

            return null;
        }

        public bool AgregarLector(Lector pLector)
        {
            Lector unLector = this.buscarLector(pLector.Id);
            if (unLector == null)
            {
                if (_persistencia.AltaLector(pLector))
                {
                    _listaLec.Add(pLector);
                    return true;
                }
            }
            return false;
        }


        public bool EliminarLector(short pId)
        {
            Lector unLector = this.buscarLector(pId);
            if (unLector != null)
            {
                if (this._persistencia.BajaLector(unLector))
                {
                    _listaLec.Remove(unLector);
                    return true;
                }
            }
            return false;
        }


        public bool ModificarLector(Lector pLector)
        {
            Lector unLector = this.buscarLector(pLector.Id);
            if (unLector != null)
            { 
                if (this._persistencia.ModificarLector(pLector))
                
                    {
                        unLector.Nombre = pLector.Nombre;
                        unLector.Apellido = pLector.Apellido;
                        unLector.Direccion = pLector.Direccion;
                        unLector.Telefono = pLector.Telefono;
                        return true;
                    }
             }
            return false;
        }



        #endregion
        #region  ABMVentas
        public List<Venta> ListaVenta()
        {
            return _listaVenta;
        }


        public bool AgregarVenta(Venta pVenta)
        {
            Venta unaVenta = this.buscarVenta(pVenta.IdVenta);
            if (unaVenta == null)
            {
                _listaVenta.Add(pVenta);
                pVenta.StockLibro = pVenta.StockLibro - 1;
                return true;
            }

            return false;

        }

        public Venta buscarVenta(short pId)
        {
            if (_listaL.Count > 0)
            {
                foreach (Venta unaVenta in _listaVenta)
                {
                    if (unaVenta.IdVenta == pId)
                        return unaVenta;
                }
            }
            return null;
        }
        #endregion



        #region Consulta
        public bool DevolucionVenta(short pId)
        {
            Venta unaVenta = this.buscarVenta(pId);
            if (unaVenta != null)
            {
                _listaVenta.Remove(unaVenta);
                unaVenta.StockLibro = unaVenta.StockLibro + 1;
                return true;

            }
            return false;
        }

        public List<Double> RecaudacionTotal()
        {
            double importeTotal = 0;
            List<Double> rem = new List<Double>();
            foreach (Venta unaVenta in _listaVenta)
            {
                importeTotal = importeTotal + unaVenta.Precio;

            }

            rem.Add(importeTotal);
            return rem;

        }

        public List<Libro> LibrosYautores()
        {
            if (_listaL.Count == 0)
            {
                return null;
            }
            else
            {
                List<Libro> LibrosMásVendidos = new List<Libro>(_listaL);
                if (_listaL.Count == 1)
                {
                    List<Libro> max = _listaL;
                    return max;

                }
                else
                {
                    int[] cantidad = new int[_listaL.Count];
                    for (int i = 0; i < cantidad.Length; i++)
                    {
                        cantidad[i] = 0;
                    }



                    for (int i = 0; i < _listaL.Count; i++)
                    {
                        for (int j = 0; j < _listaA.Count; j++)
                        {
                            if (_listaL[i].Autor.Id == _listaL[j].IdLibro)
                            {
                                cantidad[j]++;
                                break;
                            }
                        }
                    }


                    for (int i = 0; i < _listaL.Count - 1; i++)
                    {
                        if (cantidad[i] > cantidad[i + 1])
                        {
                            int auxI = cantidad[i];
                            Autor auxA = _listaA[i];

                            cantidad[i] = cantidad[i + 1];
                            _listaL[i] = _listaL[i + 1];

                            cantidad[i + 1] = auxI;
                            _listaA[i + 1] = auxA;


                        }
                    }

                    int maxC = cantidad[cantidad.Length - 1];
                    List<Libro> maxL = new List<Libro>();
                    for (int i = 0; i < cantidad.Length; i++)
                    {
                        if (cantidad[i] == maxC)
                        {
                            maxL.Add(_listaL[i]);
                        }
                    }

                    return maxL;
                }


            }


        }
        public List<Pais> ListaPais()
        {
            return _listaPais;
        }

        public Pais buscarPais(short pId)
        {
            if (_listaPais.Count > 0)
            {
                foreach (Pais unPais in _listaPais)
                {
                    if (unPais.Id == pId)
                        return unPais;
                }

            }

            return null;
        }
        public bool AgregarPais(Pais pPais)
        {
            Pais unPais = this.buscarPais(pPais.Id);
            if (unPais == null)
            {
                if (this._persistencia.AltaPais(pPais))
                {
                    _listaPais.Add(pPais);
                    return true;
                }
            }
            return false;
        }


        public bool BajaPais(short pId)
        {
            Pais unPais = this.buscarPais(pId);
            if (unPais != null)
            {
                if (this._persistencia.BajaPais(unPais))
                {
                   return _listaPais.Remove(unPais);
                   
                }
            }
            return false;
        }
        public bool ModificarPais(Pais pPais)
        {
            Pais unPais = this.buscarPais(pPais.Id);
            if (unPais != null)
            {
                if (this._persistencia.ModificarPais(pPais))
                {
                    unPais.Nombre = pPais.Nombre;
                    unPais.Continente = pPais.Continente;
                    return true;
                }
            }
            return false;
        }


        public List<Genero> ListaGen()
        {
            return _listaGen;
        }

        public Genero buscarGenero(short pId)
        {
            if (_listaGen.Count > 0)
            {
                foreach (Genero unGenero in _listaGen)
                {
                    if (unGenero.Id == pId)
                        return unGenero;
                }

            }

            return null;
        }
        public bool AgregarGenero(Genero pGenero)
        {
            Genero unGenero = this.buscarGenero(pGenero.Id);
            if (unGenero == null)
            {
                if (_persistencia.AltaGenero(pGenero))
                {
                    _listaGen.Add(pGenero);
                    return true;
                }
               
            }
            return false;
        }
        public bool EliminarGenero(short pId)
        {
            Genero unGenero = this.buscarGenero(pId);
            if (unGenero != null)
            {
                if (this._persistencia.BajaGenero(unGenero))
                {
                    _listaGen.Remove(unGenero);

                    return true;
                }
            }
            return false;
        }
        public bool ModificarGenero(Genero pGenero)
        {
            Genero unGenero = this.buscarGenero(pGenero.Id);
            if (unGenero != null)
            {
                if (this._persistencia.ModificarGenero(pGenero))
                {
                    unGenero.Clasificacion = pGenero.Clasificacion;

                    return true;
                }

            }
            return false;
        }

        public List<Libro> LibroMasVendido()
        {
            string titulo = string.Empty;
            int cantidad = 0;

            List<Libro> listaLibro = new List<Libro>();

            foreach (Venta unaVenta in _listaVenta)
            {
                if (cantidad < _listaVenta.Count(venta => venta.TituloLibro.Equals(unaVenta.TituloLibro)))
                {
                    cantidad = _listaVenta.Count(venta => venta.TituloLibro.Equals(unaVenta.TituloLibro));
                    titulo = unaVenta.TituloLibro;
                }
            }

            foreach (Libro unLibro in _listaL)
            {
                if (unLibro.Titulo.Equals(titulo))
                {
                    listaLibro.Add(unLibro);
                    return listaLibro;
                }
            }

            return null;
        }
       public List<Pais> PaisConMasPublicaciones()
        {
            string pais = string.Empty;
            int cantidad = 0;
           
            List<Pais> ListaPais = new List<Pais>();

            foreach (Libro unLibro in _listaL)
            {
                
              
                if (cantidad < _listaL.Count(libro => libro.Pais.Nombre.Equals(unLibro.Pais.Nombre)))
                {
                    cantidad = _listaL.Count(libro => libro.Pais.Nombre.Equals(unLibro.Pais.Nombre));
                    pais = unLibro.Pais.Nombre.ToString();
                    
                }
            }

            foreach (Libro unLibro in _listaL)
            {
                if (unLibro.Pais.Nombre.Equals(pais))
                {
                    ListaPais.Add(unLibro.Pais);
                    return ListaPais;
                }
            }

            return null;
        }
        public List<Venta> VentasXCliente(int pIdLector)
        {
            List<Venta> ventas = new List<Venta>();

            foreach (Venta unaVenta in _listaVenta)
            {
                if (unaVenta.Lector.Id == pIdLector)
                {
                    ventas.Add(unaVenta);
                }
            }

            return ventas;
        }
        public List<Libro> LibroNombreGenero(short pid)
        {
            List<Libro> LibrosPorGenero = new List<Libro>();
            foreach (Libro unLibro in ListaL())
            {
                if (unLibro.Genero.Id.Equals(pid))
                {
                   
                      if (unLibro.Equals(unLibro))
                       {
                       LibrosPorGenero.Add(unLibro);
                       }
                 }
                   
             }
            var final = LibrosPorGenero.OrderBy(libro => libro.Titulo.ToUpper()).ToList();
            return final;
           }

        }

        #endregion
    }

