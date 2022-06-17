using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FeriaDelLibro2.Dominio;
using FeriaDelLibro2.Persistencia;
using System.Data;


namespace FeriaDelLibro2.Presentacion
{
    public partial class Venta : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                this.ListarLectores();
                this.ListarLibros();
                this.ListarAutores();
                this.Listar();
                this.ListarGeneros();
            }
        }

        #region Métodos Auxiliares
        private void Limpiar()
        {
            {
                this.txtId.Text = " ";
                this.txtFecha.Text = " ";
                this.txtLibro.Text = " ";
                this.txtStock.Text = " ";
                this.txtAutor.Text = " ";
                this.txtLector.Text = " ";
                this.txtPrecio.Text = " ";
                this.txtGenero.Text = ".";
                this.txtId.Focus();
            }
        }

        private bool faltanDatos()
        {
            if (this.txtId.Text == "" || this.txtFecha.Text == "" || this.txtLibro.Text == "" ||
                this.txtStock.Text == "" || this.txtAutor.Text == "" || this.txtLector.Text == "" || this.txtPrecio.Text == "" || this.txtGenero.Text == "")

            {
                return true;
            }

            return false;
        }
        private void ListarLibros()
        {

            Controladora unLibro = new Controladora();
            this.lstLibro.DataSource = null;
            this.lstLibro.DataSource = unLibro.ListaL();
            this.lstLibro.DataBind();

        }
     
        
        private void ListarGeneros()
        {

            Controladora unGenero = new Controladora();
            this.lstGenero.DataSource = null;
            this.lstGenero.DataSource = unGenero.ListaGen();
            this.lstGenero.DataBind();

        }
        private void ListarLectores()
        {
            Dominio.Controladora unLector = new Dominio.Controladora();
            this.lstLector.DataSource = null;
            this.lstLector.DataSource = unLector.ListaLec();
            this.lstLector.DataBind();
        }
        private void ListarAutores()
        {
            Dominio.Controladora unAutor = new Dominio.Controladora();
            this.lstAutor.DataSource = null;
            this.lstAutor.DataSource = unAutor.ListaA();
            this.lstAutor.DataBind();

        }

        private void CargarAutor(short pId)
        {
            Dominio.Controladora unaControladora = new Dominio.Controladora();
            Dominio.Autor unAutor = unaControladora.buscarAutor(pId);
            this.txtAutor.Text = Convert.ToString(unAutor.Id);
        }
        private void CargarGenero(short pId)
        {
            Dominio.Controladora unaContro = new Dominio.Controladora();
            Dominio.Genero unGenero = unaContro.buscarGenero(pId);
            this.txtGenero.Text = unGenero.Id.ToString();
        }
        private void CargarVenta(short pId)
        {

            Dominio.Controladora unaControladora = new Dominio.Controladora();
            Dominio.Venta unaVenta = unaControladora.buscarVenta(pId);
            Dominio.Autor unAutor = unaControladora.buscarAutor(pId);
            Dominio.Lector unLector = unaControladora.buscarLector(pId);
            this.txtId.Text = unaVenta.IdVenta.ToString();
            this.txtFecha.Text = unaVenta.FechaVenta.ToString();
            this.txtLibro.Text = unaVenta.TituloLibro.ToString();
            this.txtStock.Text = unaVenta.StockLibro.ToString();
            this.txtAutor.Text = unaVenta.Autor.Id.ToString();
            this.txtLector.Text = unaVenta.Lector.Id.ToString();
            this.txtPrecio.Text = unaVenta.Precio.ToString();
            this.txtGenero.Text = unaVenta.genero.ToString();


        }

        private void CargarLibro(short pId)
        {
            Dominio.Controladora unaControladora = new Dominio.Controladora();
            Dominio.Libro unLib = unaControladora.buscarLibro(pId);

            this.txtLibro.Text = unLib.IdLibro.ToString();

            this.txtPrecio.Text = unLib.Precio.ToString();
            this.txtStock.Text = unLib.Stock.ToString();


        }
        private void CargarLector(short pId)
        {

            Dominio.Controladora unaControladora = new Dominio.Controladora();
            Dominio.Lector unLector = unaControladora.buscarLector(pId);
            this.txtLector.Text = unLector.Id.ToString();

        }

        bool ordenABC = false;
        private void ListaXorden()
        {
            Dominio.Controladora unaControladora = new Dominio.Controladora();
            this.lstVenta.DataSource = null;
            this.lstVenta.DataSource = unaControladora.ListaVenta();
            this.lstVenta.SelectedIndex = -1;
            this.lstVenta.DataBind();
            ordenABC = false;
        }


        private void ListarxABC()
        {
            Dominio.Controladora unaControladora = new Dominio.Controladora();
            this.lstVenta.DataSource = null;
            this.lstVenta.DataSource = unaControladora.ListaVenta();
            this.lstVenta.SelectedIndex = -1;
            this.lstVenta.DataBind();

            ordenABC = true;

        }

        private void Listar()
        {
            if (ordenABC)
            {
                ListarxABC();

            }

            else
            {
                ListaXorden();
            }


        }

        private Dominio.Lector LectorSeleccionado()
        {
            if (this.txtLector.Text != "")
            {
                Dominio.Controladora unaControladora = new Dominio.Controladora();
                short LectorId = short.Parse(this.txtLector.Text);
                Dominio.Lector LectorOb = unaControladora.buscarLector(LectorId);
                if (LectorOb != null)
                {
                    return LectorOb;
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
        private Dominio.Genero GeneroSeleccionado()
        {
            if (this.txtGenero.Text != "")
            {
                Dominio.Controladora unaControladora = new Dominio.Controladora();
                short GeneroId = short.Parse(this.txtGenero.Text);
                Dominio.Genero GeneroOb = unaControladora.buscarGenero(GeneroId);
                if (GeneroOb != null)
                {
                    return GeneroOb;
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
        private Dominio.Libro LibroSeleccionado()
        {
            if (this.txtLibro.Text != "")
            {

                Dominio.Controladora unaControladora = new Dominio.Controladora();

                short idLibro = short.Parse(this.txtLibro.Text);
                Dominio.Libro libroEncontrado = unaControladora.buscarLibro(idLibro);

                if (libroEncontrado != null)
                {
                    return libroEncontrado;
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
        private Dominio.Venta VentaSeleccionada()
        {
            if (this.lstVenta.Text != "")
            {
                Dominio.Controladora unaControladora = new Dominio.Controladora();
                short ventaId = short.Parse(this.lstVenta.Text);
                Dominio.Venta ventaOb = unaControladora.buscarVenta(ventaId);
                if (ventaOb != null)
                {
                    return ventaOb;
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
        #endregion
        #region


        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
        #endregion


        protected void btnAgregar_Click1(object sender, EventArgs e)
        {
            Dominio.Controladora unaControladora = new Dominio.Controladora();

            Dominio.Autor TraerAutor = this.AutorSeleccionado();
            Dominio.Libro TraerLibro = this.LibroSeleccionado();
            Dominio.Lector TraerIdLec = this.LectorSeleccionado();
            Dominio.Genero TraerIdGenero = this.GeneroSeleccionado();


            if (!this.faltanDatos())
            {
                short id = short.Parse(this.txtId.Text);
                DateTime fecha = DateTime.Parse(this.txtFecha.Text);


                short precio = short.Parse(this.txtPrecio.Text);
                Dominio.Venta unaVenta = new Dominio.Venta(id, fecha, TraerLibro.Titulo, TraerLibro.Stock, TraerAutor, TraerIdLec, precio, TraerIdGenero);



                if (unaControladora.AgregarVenta(unaVenta))
                {
                    this.Limpiar();
                    this.Listar();
                    this.lblTexto.Text = "Venta ingresada con exito";
                }
                else
                {

                    this.txtId.Focus();
                    this.lblTexto.Text = "Ya existe un Venta con ese ID";
                }

            }
            else
            {
                this.lblTexto.Text = "Ingrese todos los datos";
            }
        }
        protected void btnLibro_Click(object sender, EventArgs e)
        {
            if (this.lstLibro.SelectedIndex > -1)
            {
                string linea = this.lstLibro.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                short idLibro = short.Parse(partes[1]);
                this.CargarLibro(idLibro);

            }
        }

        protected void btnLector_Click(object sender, EventArgs e)
        {
            if (this.lstLector.SelectedIndex > -1)
            {
                string linea = this.lstLector.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                short idLector = short.Parse(partes[1]);
                this.CargarLector(idLector);

            }
        }

        protected void btnVenta_Click(object sender, EventArgs e)
        {
            if (this.lstVenta.SelectedIndex > -1)
            {
                string linea = this.lstVenta.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                short idVenta = short.Parse(partes[1]);
                this.CargarVenta(idVenta);
            }
        }

        protected void btnDevolucion_Click(object sender, EventArgs e)
        {
            {
                Dominio.Controladora unaVenta = new Dominio.Controladora();
                if (this.txtId.Text != "")
                {
                    short id = short.Parse(this.txtId.Text);
                    if (unaVenta.DevolucionVenta(id))
                    {
                        this.Listar();
                    }
                }
            }
        }

        protected void btnAutorYlibro_Click(object sender, EventArgs e)
        {
            Dominio.Controladora unaControladora = new Dominio.Controladora();
            this.lstLibrosYautores.DataSource = null;
            this.lstLibrosYautores.DataSource = unaControladora.LibrosYautores();
            this.lstLibrosYautores.DataBind();
        }

        protected void btnLibroMasVendido_Click(object sender, EventArgs e)
        {
            Dominio.Controladora unaControladora = new Dominio.Controladora();
            this.lstLibrosMasVendido.DataSource = null;
            this.lstLibrosMasVendido.DataSource = unaControladora.LibroMasVendido();
            this.lstLibrosMasVendido.DataBind();
        }

        protected void btnTotalDeVentas_Click(object sender, EventArgs e)
        {

            Dominio.Controladora unaControladora = new Dominio.Controladora();
            this.lstTotalDeVentas.DataSource = null;
            this.lstTotalDeVentas.DataSource = unaControladora.RecaudacionTotal();
            this.lstTotalDeVentas.DataBind();
        }

        protected void btnCompraLectorTitulo_Click(object sender, EventArgs e)
        {
            Dominio.Controladora unaControladora = new Dominio.Controladora();
            this.lstTotalDeVentas.DataSource = null;
            this.lstTotalDeVentas.DataSource = unaControladora.VentasXCliente(int.Parse(this.txtLector.Text));
            this.lstTotalDeVentas.DataBind();
        }

        protected void btnAutor_Click(object sender, EventArgs e)
        {
            if (this.lstAutor.SelectedIndex > -1)
            {
                string linea = this.lstAutor.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                short idAutor = short.Parse(partes[1]);
                this.CargarAutor(idAutor);

            }
        }

        protected void lstLector_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void lstLibro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnPaisxPublicacion_Click(object sender, EventArgs e)
        {

            Dominio.Controladora unaControladora = new Dominio.Controladora();
            this.lstPublicacionesXPais.DataSource = null;
            this.lstPublicacionesXPais.DataSource = unaControladora.PaisConMasPublicaciones();
            this.lstPublicacionesXPais.DataBind();
        }



        protected void btnGenero_Click(object sender, EventArgs e)
        {
            if (this.lstGenero.SelectedIndex > -1)
            {
                string linea = this.lstGenero.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                short idGenero = short.Parse(partes[0]);
                this.CargarGenero(idGenero);

            }
        }

        protected void btnLibroNombreGenero_Click(object sender, EventArgs e)
        {
            if (this.lstGenero.SelectedIndex > -1)
            {
                string linea = this.lstGenero.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                short idGenero = short.Parse(partes[0]);
                Dominio.Controladora unaControladora = new Dominio.Controladora();
                this.lstLibrosPorNombre.DataSource = null;
                this.lstLibrosPorNombre.DataSource = unaControladora.LibroNombreGenero(idGenero);
                this.lstLibrosPorNombre.DataBind();
            }
        }
    }
}

