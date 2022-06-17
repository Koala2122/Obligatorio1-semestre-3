using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FeriaDelLibro2.Dominio;

namespace FeriaDelLibro2.Presentacion
{
    public partial class Lector : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                this.ListarLectores();
            }

        }
        #region Métodos Auxiliares
        private bool faltanDatos()
        {
            if (this.txtId.Text == "" || this.txtNombre.Text == " " 
                || this.txtApellido.Text == "" || this.txtDireccion.Text == "" || this.txtTelefono.Text == "")
            {
                return true;
            }
            return false;
        }
        private void ListarLectores()
        {
            this.lstLector.DataSource = null;
            Dominio.Controladora unaContro = new Dominio.Controladora();
            this.lstLector.DataSource = unaContro.ListaLec();
            this.lstLector.DataBind();
        }
        private void cargarLector(short pId)
        {
            Dominio.Controladora unaContro = new Dominio.Controladora();
            Dominio.Lector unLector = unaContro.buscarLector(pId);
            this.txtId.Text = unLector.Id.ToString();
            this.txtNombre.Text = unLector.Nombre;
            this.txtApellido.Text = unLector.Apellido;
            this.txtDireccion.Text = unLector.Direccion;
            this.txtTelefono.Text = unLector.Telefono;

        }
        private void Limpiar()
        {
            this.txtId.Text = "";
            this.txtNombre.Text = " ";
            this.txtApellido.Text = " ";
            this.txtDireccion.Text = " ";
            this.txtTelefono.Text = ".";
            this.txtId.Focus();
        }


        #endregion
        #region
        protected void brnAgregar_Click(object sender, EventArgs e)
        {
            Dominio.Controladora unaControladora = new Dominio.Controladora();
            if (!this.faltanDatos())
            {

                short id = short.Parse(this.txtId.Text);
                string nombre = this.txtNombre.Text;
                string apellido = this.txtApellido.Text;
                string direccion = this.txtDireccion.Text;
                string telefono = this.txtTelefono.Text;
                Dominio.Lector unLector = new Dominio.Lector(id, nombre, apellido, direccion, telefono);
                if (unaControladora.AgregarLector(unLector))
                {
                    this.lblText.Text = "Se ha ingresado con éxito";
                    this.Limpiar();
                    this.ListarLectores();

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

        protected void btnElimiar_Click(object sender, EventArgs e)
        {
            Dominio.Controladora unLector = new Dominio.Controladora();
            if (this.txtId.Text != "")
            {
                short id = short.Parse(this.txtId.Text);
                if (unLector.EliminarLector(id))
                {
                    this.Limpiar();
                    this.ListarLectores();
                    this.lblText.Text = "Lector eliminado con exito";
                }
                else
                {
                    this.txtId.Focus();
                    this.lblText.Text = "No existe un Lector con ese ID";
                }
            }
            else
            {
                this.lblText.Text = "Ingrese el ID del Lector que desea eliminar";
            }
        }

   
        protected void btnModificar_Click2(object sender, EventArgs e)
        {
            short id = short.Parse(this.txtId.Text);
            string nombre = this.txtNombre.Text;
            string apellido = this.txtApellido.Text;
            string direccion = this.txtDireccion.Text;
            string telefono = this.txtTelefono.Text;

            Dominio.Lector unLector = new Dominio.Lector(id, nombre, apellido, direccion, telefono);
            Dominio.Controladora dominio = new Dominio.Controladora();
            if (dominio.ModificarLector(unLector))
            {


               this.ListarLectores();
                this.Limpiar();
                this.lblText.Text = "Lector modificado con exito";
            }
            else
            {
                this.txtId.Focus();
                this.lblText.Text = "No existe un Lector con ese ID";
            }

        }

 

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }



        #endregion

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (this.lstLector.SelectedIndex > -1)
            {
                string linea = this.lstLector.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                short idLector = short.Parse(partes[1]);
                this.cargarLector(idLector);
             }
            else
            {
                this.lblText.Text = "Debe seleccionar un Lector de la lista.";
            }

            }    
        protected void lstLector_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }

}