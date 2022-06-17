using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FeriaDelLibro2.Dominio;

namespace FeriaDelLibro2.Presentacion
{
    public partial class Genero : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.ListarGenero();
            }

        }
        #region Métodos Auxiliares
        private bool faltanDatos()
        {
            if (this.txtId.Text == "" || this.txtClasificacion.Text == " " )
            {
                return true;
            }
            return false;
        }
        private void ListarGenero()
        {
            this.lstGenero.DataSource = null;
            Controladora unaContro = new Controladora();
            this.lstGenero.DataSource = unaContro.ListaGen();
            this.lstGenero.DataBind();
        }
        private void cargarGenero(short pId)
        {
            Dominio.Controladora unaContro = new Dominio.Controladora();
            Dominio.Genero unGenero = unaContro.buscarGenero(pId);
            this.txtId.Text = unGenero.Id.ToString();
            this.txtClasificacion.Text = unGenero.Clasificacion;
        }
        private void Limpiar()
        {
            this.txtId.Text = "";
            this.txtClasificacion.Text = " ";
            this.txtId.Focus();
        }

        #endregion
        #region
        protected void btnAlta_Click(object sender, EventArgs e)
        {
            Dominio.Controladora unaControladora = new Dominio.Controladora();
            if (!this.faltanDatos())
            {

                short id = short.Parse(this.txtId.Text);
                string clasificacion = this.txtClasificacion.Text;
             
                Dominio.Genero unGenero = new Dominio.Genero(id, clasificacion);
                if (unaControladora.AgregarGenero(unGenero))
                {
                    this.lblTexto.Text = "Se ha ingresado con éxito";
                    this.Limpiar();
                    this.ListarGenero();
                }
                else
                {
                    this.lblTexto.Text = "Ya existe un Genero con ese ID";
                    this.txtId.Focus();
                }

            }
            else
            {
                this.lblTexto.Text = "Ingrese todos los datos";
            }
        }
       

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (this.lstGenero.SelectedIndex > -1)
            {
                string linea = this.lstGenero.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                short id = Convert.ToInt16(partes[0]);
                this.cargarGenero(id);
                this.lstGenero.SelectedIndex = -1;
            }
            else
            {
                this.lblTexto.Text = "Debe seleccionar un Genero de la lista.";
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

            short id = short.Parse(this.txtId.Text);
            string clasificacion = this.txtClasificacion.Text;
            Dominio.Genero unGenero = new Dominio.Genero(id, clasificacion);
            Controladora dominio = new Dominio.Controladora();
            if (dominio.ModificarGenero(unGenero))
            {


                this.ListarGenero();
                this.Limpiar();
                this.lblTexto.Text = "Genero modificado con exito";
            }
            else
            {
                this.txtId.Focus();
                this.lblTexto.Text = "No existe un Genero con ese ID";
            }
        }


        protected void btnBaja_Click(object sender, EventArgs e)
        {
            Dominio.Controladora unGenero = new Dominio.Controladora();
            if (this.txtId.Text != "")
            {
                short id = short.Parse(this.txtId.Text);
                if (unGenero.EliminarGenero(id))
                {
                    this.Limpiar();
                    this.ListarGenero();
                    this.lblTexto.Text = "Genero eliminado con exito";
                }
                else
                {
                    this.txtId.Focus();
                    this.lblTexto.Text = "No existe un Genero con ese ID";
                }
            }
            else
            {
                this.lblTexto.Text = "Ingrese el ID del Genero que desea eliminar";
            }
        }
        #endregion

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
    }
}