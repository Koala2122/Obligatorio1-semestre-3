using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FeriaDelLibro2.Dominio;
namespace FeriaDelLibro2.Presentacion
{
    public partial class Libro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                this.ListarLibros();
                this.ListaGeneros();
                this.ListarAutores();
                this.ListarPaises();
            }
        }
        #region Métodos Auxiliares
        private bool faltanDatos()

        {
            if (this.txtId.Text == "" || this.txtTitulo.Text == "" || this.txtGenero.Text == ""
            || this.txtAño.Text == "" || this.txtAutor.Text == "" || this.txtPrecio.Text == "" || this.txtStock.Text == "" || this.txtPais.Text == "")
            {
                return true;
            }

            return false;
        }
        private void ListarLibros()
        {
            this.lstLibro.DataSource = null;
            Controladora unaContro = new Controladora();
            this.lstLibro.DataSource = unaContro.ListaL();
            this.lstLibro.DataBind();
        }
        private void ListaGeneros()
        {
            this.lstGenero.DataSource = null;
            Controladora unaContro = new Controladora();
            this.lstGenero.DataSource = unaContro.ListaGen();
            this.lstGenero.DataBind();
        }
        private void ListarAutores()
        {
            this.lstAutor.DataSource = null;
            Controladora unaContro = new Controladora();
            this.lstAutor.DataSource = unaContro.ListaA();
            this.lstAutor.DataBind();
        }
        private void ListarPaises()
        {
            this.lstPais.DataSource = null;
            Controladora unaContro = new Controladora();
            this.lstPais.DataSource = unaContro.ListaPais();
            this.lstPais.DataBind();
        }
        private void cargarLibro(short pId)
        {
            this.Limpiar();
            Dominio.Controladora unaControladora = new Dominio.Controladora();
            Dominio.Libro unLibro = unaControladora.buscarLibro(pId);
            this.txtId.Text = unLibro.IdLibro.ToString();
            this.txtTitulo.Text = unLibro.Titulo.ToString();
            this.txtGenero.Text = unLibro.Genero.Id.ToString();
            this.txtAño.Text = unLibro.Año.ToString();
            this.txtAutor.Text = unLibro.Autor.Id.ToString();
            this.txtPrecio.Text = unLibro.Precio.ToString();
            this.txtStock.Text = unLibro.Stock.ToString();
            this.txtPais.Text = unLibro.Pais.Nombre.ToString();


        }
        private void Limpiar()
        {
            this.txtId.Text = " ";
            this.txtTitulo.Text = " ";
            this.txtGenero.Text = " ";
            this.txtAño.Text = " ";
            this.txtAutor.Text = " ";
            this.txtPrecio.Text = " ";
            this.txtStock.Text = " ";
            this.txtPais.Text = ".";
            this.txtId.Focus();
        }

        #endregion

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {

            
        }
        private Dominio.Genero GeneroSeleccionado()
        {
            if (this.txtGenero.Text != "")
            {
                Dominio.Controladora unaControladora = new Dominio.Controladora();
                short generoId = short.Parse(this.txtGenero.Text);
                Dominio.Genero generoOb = unaControladora.buscarGenero(generoId);
                if (generoOb != null)
                {
                    return generoOb;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        private Dominio.Autor AutorSeleccionado()
        {
            if (this.txtAutor.Text != "")
            {
                Dominio.Controladora unaControladora = new Dominio.Controladora();
                short autorId = short.Parse(this.txtAutor.Text);
                Dominio.Autor autorOb = unaControladora.buscarAutor(autorId);
                if (autorOb != null)
                {
                    return autorOb;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        private Dominio.Pais PaisSeleccionado()
        {
            if (this.txtPais.Text != "")
            {
                Dominio.Controladora unaControladora = new Dominio.Controladora();
                short PaisId = short.Parse(this.txtPais.Text);
                Dominio.Pais PaisOb = unaControladora.buscarPais(PaisId);
                if (PaisOb != null)
                {
                    return PaisOb;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        private Dominio.Libro LibroSeleccionado()
        {
            if (this.txtId.Text != "")
            {
                Dominio.Controladora unaControladora = new Dominio.Controladora();
                string LibroSt = this.txtId.ToString();
                string[] ArrayLibro = LibroSt.Split(' ');
                short idLibro = short.Parse(ArrayLibro[2]);
                Dominio.Libro LibroOb = unaControladora.buscarLibro(idLibro);
                if (LibroOb != null)
                {
                    return LibroOb;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        #region
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Dominio.Controladora unaControladora = new Dominio.Controladora();
            Dominio.Genero TraerGenero = this.GeneroSeleccionado();
            Dominio.Autor TraerAutor = this.AutorSeleccionado();
            Dominio.Pais TraerPais = this.PaisSeleccionado();

            if (!this.faltanDatos())
            {

                short idLibro = short.Parse(this.txtId.Text);
                string titulo = this.txtTitulo.Text;
                string año = this.txtAño.Text;
                Double precio = double.Parse(this.txtPrecio.Text);
                int stock = int.Parse(this.txtStock.Text);
                Dominio.Libro unLibro = new Dominio.Libro(idLibro, titulo, TraerGenero, año, TraerAutor, precio, stock, TraerPais);

                if (unaControladora.AgregarLibro(unLibro))
                {
                    this.Limpiar();
                    this.lblTexto.Text = "Libro ingresado con exito";
                    this.ListarLibros();
                }

                else
                {

                    this.txtId.Focus();
                    this.lblTexto.Text = "Ya existe un Libro con ese ID";
                }

            }
            else
            {
                this.lblTexto.Text = "Ingrese todos los datos";
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Dominio.Controladora unLibro = new Dominio.Controladora();
            if (this.txtId.Text != "")
            {
                short idLibro = short.Parse(this.txtId.Text);
                if (unLibro.EliminarLibro(idLibro))
                {
                    this.ListarLibros();
                    this.lblTexto.Text = "Libro eliminado con exito";
                    this.Limpiar();
                }
                else
                {

                    this.txtId.Focus();
                    this.lblTexto.Text = "No existe un Libro con ese ID";
                }
            }
            else
            {
                this.lblTexto.Text = "Ingrese el ID del Libro que desea eliminar";
            }
        }

      
        private void CargarAutor(short pId)
        {
            Dominio.Controladora unaControladora = new Dominio.Controladora();
            Dominio.Autor unAutor = unaControladora.buscarAutor(pId);
            this.txtAutor.Text = Convert.ToString(unAutor.Id);
        }
        private void CargarGenero(short pId)
        {
            Dominio.Controladora unaControladora = new Dominio.Controladora();
            Dominio.Genero unGenero = unaControladora.buscarGenero(pId);
            this.txtGenero.Text = Convert.ToString(unGenero.Id);
        }
        private void CargarPais(short pId)
        {
            Dominio.Controladora unaControladora = new Dominio.Controladora();
            Dominio.Pais unPais = unaControladora.buscarPais(pId);
            this.txtPais.Text = Convert.ToString(unPais.Id);
        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {

            Dominio.Controladora unaControladora = new Dominio.Controladora();
            Dominio.Genero TraerGenero = this.GeneroSeleccionado();
            Dominio.Autor TraerAutor = this.AutorSeleccionado();
            Dominio.Pais TraerPais = this.PaisSeleccionado();
            if (!this.faltanDatos())
            {
                short idLibro = short.Parse(this.txtId.Text);
                string titulo = this.txtTitulo.Text;
                string genero = this.txtGenero.Text;
                string año = this.txtAño.Text;
                Double precio = double.Parse(this.txtPrecio.Text);
                int stock = int.Parse(this.txtStock.Text);
                Dominio.Libro unaLibro = new Dominio.Libro(idLibro, titulo, TraerGenero, año, TraerAutor, precio, stock, TraerPais);

                if (unaControladora.ModificarLibro(idLibro, titulo, TraerGenero, año, TraerAutor, precio, stock, TraerPais))
                {
                    this.ListarLibros();
                    this.lblTexto.Text = "Libro modificado con exito";
                    this.Limpiar();
                }
                else
                {
                    this.lblTexto.Text = "No existe un Libro con ese ID";
                    this.txtId.Focus();

                }
            }
            else
            {
                this.lblTexto.Text = "Ingrese todos los datos";
            }
            this.lstLibro.SelectedIndex = -1;
            this.lstGenero.SelectedIndex = -1;
            this.lstAutor.SelectedIndex = -1;
        }
        #endregion

        protected void btnSeleccionarAutor_Click(object sender, EventArgs e)
        {
            if (this.lstAutor.SelectedIndex > -1)
            {
                string linea = this.lstAutor.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                short idAutor = short.Parse(partes[1]);
                this.CargarAutor(idAutor);
            }
        }

        protected void btnSeleccionarGenero_Click1(object sender, EventArgs e)
        {

            if (this.lstGenero.SelectedIndex > -1)
            {
                string linea = this.lstGenero.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                short idGenero = short.Parse(partes[0]);
                this.CargarGenero(idGenero);
            }
        }

     
        protected void txtStock_TextChanged(object sender, EventArgs e)
        {


        }

        protected void lstGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSeleccionarLibro_Click1(object sender, EventArgs e)
        {

            if (this.lstLibro.SelectedIndex > -1)
            {

                string linea = this.lstLibro.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                short idLibro = short.Parse(partes[1]);
                this.cargarLibro(idLibro);
            }
            else
            {
                this.lblTexto.Text = "Debe seleccionar un Libro de la lista.";
            }
        }

        protected void btnSeleccionarPais_Click(object sender, EventArgs e)
        {

            if (this.lstPais.SelectedIndex > -1)
            {
                string linea = this.lstPais.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                short idPais = short.Parse(partes[0]);
                this.CargarPais(idPais);
            }
        }
    }
}