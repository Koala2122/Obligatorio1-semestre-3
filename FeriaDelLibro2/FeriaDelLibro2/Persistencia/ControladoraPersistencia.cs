using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using FeriaDelLibro2.Dominio;
namespace FeriaDelLibro2.Persistencia
{
    public class ControladoraPersistencia
    {
        public bool ExisteAutor(Autor pAutor)
        {
            return new PersistenciaAutor().Existe(pAutor);
        }
        public bool AltaAutor(Autor pAutor)
        {
            return new PersistenciaAutor().AltaAutor(pAutor);
        }
        public bool BajaAutor(Autor pAutor)
        {
            return new PersistenciaAutor().BajaAutor(pAutor);
        }
        public bool ModificarAutor(Autor pAutor)
        {
            return new PersistenciaAutor().ModificarAutor(pAutor);
        }
        public List<Autor> ListaAutor()
        {
            return new PersistenciaAutor().ListaAutor();
        }
        public bool ExisteLector(Lector pLector)
        {
            return new PersistenciaLector().Existe(pLector);
        }
        public bool AltaLector(Lector pLector)
        {
            return new PersistenciaLector().AltaLector(pLector);
        }
        public bool BajaLector(Lector pLector)
        {
            return new PersistenciaLector().BajaLector(pLector);
        }
        public bool ModificarLector(Lector pLector)
        {
            return new PersistenciaLector().ModificarLector(pLector);
        }
        public List<Lector> ListaLector()
        {
            return new PersistenciaLector().ListaLector();
        }
        public bool ExistePais(Pais pPais)
        {
            return new PersistenciaPais().Existe(pPais);
        }
        public bool AltaPais(Pais pPais)
        {
            return new PersistenciaPais().AltaPais(pPais);
        }
        public bool BajaPais(Pais pPais)
        {
            return new PersistenciaPais().BajaPais(pPais);
        }
        public bool ModificarPais(Pais pPais)
        {
            return new PersistenciaPais().ModificarPais(pPais);
        }
        public List<Pais> ListaPais()
        {
            return new PersistenciaPais().ListaPais();
        }
        public bool ExisteGenero(Genero pGenero)
        {
            return new PersistenciaGenero().Existe(pGenero);
        }
        public bool AltaGenero(Genero pGenero)
        {
            return new PersistenciaGenero().AltaGenero(pGenero);
        }
        public bool BajaGenero(Genero pGenero)
        {
            return new PersistenciaGenero().BajaGenero(pGenero);
        }
        public bool ModificarGenero(Genero pGenero)
        {
            return new PersistenciaGenero().ModificarGenero(pGenero);
        }
        public List<Genero> ListaGenero()
        {
            return new PersistenciaGenero().ListaGenero();
        }

    }
}