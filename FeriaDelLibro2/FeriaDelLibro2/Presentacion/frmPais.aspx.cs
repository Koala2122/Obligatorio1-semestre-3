using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using FeriaDelLibro2.Dominio;



namespace FeriaDelLibro2.Presentacion
{
    public partial class Pais : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.ListarPais();
            }
           

        }
        #region Métodos Auxiliares
        private bool faltanDatos()
        {
            if (this.txtId.Text == "" || this.txtPais.Text == " " || this.txtContinente.Text == "")
            {
                return true;
            }
            return false;
        }
        private void ListarPais()
        {
            this.lstPais.DataSource = null;
            Controladora unaContro = new Controladora();
            this.lstPais.DataSource = unaContro.ListaPais();
            this.lstPais.DataBind();
        }
        private void cargarPais(short pId)
        {
            Dominio.Controladora unaContro = new Dominio.Controladora();
            Dominio.Pais unPais = unaContro.buscarPais(pId);
            this.txtId.Text = unPais.Id.ToString();
            this.txtPais.Text = unPais.Nombre;
            this.txtContinente.Text = unPais.Continente;
        }
        private void Limpiar()
        {
            this.txtId.Text = "";
            this.txtPais.Text = " ";
            this.txtContinente.Text = ".";
            this.txtId.Focus();
        }

    
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

       

        protected void lstPais_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
        
            Dominio.Controladora unaControladora = new Dominio.Controladora();
            if (!this.faltanDatos())
            {

                short id = short.Parse(this.txtId.Text);
                string nombre = this.txtPais.Text;
                string continente = this.txtContinente.Text;
                Dominio.Pais unPais = new Dominio.Pais(id, nombre, continente);
                if (unaControladora.AgregarPais(unPais))
                {
                    this.lblText.Text = "Se ha ingresado con éxito";
                    this.Limpiar();
                    this.ListarPais();
                }
                else
                {
                    this.lblText.Text = "Ya existe un Pais con ese ID";
                    this.txtId.Focus();
                }

            }
            else
            {
                this.lblText.Text = "Ingrese todos los datos";
            }
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (this.lstPais.SelectedIndex > -1)
            {
                string linea = this.lstPais.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                short id = Convert.ToInt16(partes[0]);
                this.cargarPais(id);
                this.lstPais.SelectedIndex = -1;
            }
            else
            {
                this.lblText.Text = "Debe seleccionar un Pais de la lista.";
            }

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

       
        protected void btnBaja_Click(object sender, EventArgs e)
        {
            Dominio.Controladora unPais = new Dominio.Controladora();
            if (this.txtId.Text != "")
            {
                short id = short.Parse(this.txtId.Text);
                if (unPais.BajaPais(id))
                {
                    this.Limpiar();
                    this.ListarPais();
                    this.lblText.Text = "Pais eliminado con exito";
                }
                else
                {
                    this.txtId.Focus();
                    this.lblText.Text = "No existe un Pais con ese ID";
                }
            }
            else
            {
                this.lblText.Text = "Ingrese el ID del Pais que desea eliminar";
            }
        }

      
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            short id = short.Parse(this.txtId.Text);
            string nombre = this.txtPais.Text;
            string continente = this.txtContinente.Text;
            Dominio.Pais unPais = new Dominio.Pais(id, nombre, continente);
            Controladora dominio = new Dominio.Controladora();
            if (dominio.ModificarPais(unPais))
            {


                this.ListarPais();
                this.Limpiar();
                this.lblText.Text = "Pais modificado con exito";
            }
            else
            {
                this.txtId.Focus();
                this.lblText.Text = "No existe un Pais con ese ID";
            }
        }
    }
    #endregion
}