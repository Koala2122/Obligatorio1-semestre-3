using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FeriaDelLibro2.Dominio;
namespace FeriaDelLibro2.Presentacion
{
    public partial class frmAutor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                this.ListarAutor();
            }
        }
        #region Métodos Auxiliares
        private bool faltanDatos()
      
        {
            if (this.txtNombre.Text == "" || this.txtApellido.Text == "" || this.txtDireccion.Text == ""
            || this.txtTelefono.Text == "" || this.txtFechaNac.Text == "" || this.txtNacionalidad.Text == "")
            {
                return true;
            }

            return false;
        }

            
        private void ListarAutor()
        {
            this.lstAutor.DataSource = null;
            Controladora unaContro = new Controladora();
            this.lstAutor.DataSource = unaContro.ListaA();
            this.lstAutor.DataBind();
        }
        private void cargarAutor(short pId)
        {
            this.Limpiar();
            Dominio.Controladora unaControladora = new Dominio.Controladora();
            Dominio.Autor unAutor = unaControladora.buscarAutor(pId);
            this.txtId.Text = unAutor.Id.ToString();
            this.txtNombre.Text = unAutor.Nombre.ToString();
            this.txtApellido.Text = unAutor.Apellido.ToString();
            this.txtDireccion.Text = unAutor.Direccion.ToString();
            this.txtTelefono.Text = unAutor.Telefono.ToString();
            this.txtFechaMuerte.Text = unAutor.FechaDemuerte.ToString();
            this.txtFechaNac.Text = unAutor.FechaDeNacimiento.ToString();     
            this.txtNacionalidad.Text = unAutor.Nacionalidad.ToString();

        }
        private void Limpiar()
        {
            this.txtId.Text = " ";
            this.txtNombre.Text = " ";
            this.txtApellido.Text = " ";
            this.txtDireccion.Text = " ";
            this.txtTelefono.Text = " ";
            this.txtFechaMuerte.Text = " ";
            this.txtFechaNac.Text = " ";
            this.txtNacionalidad.Text = ".";
            this.txtId.Focus();
        }

        #endregion
        #region
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Dominio.Controladora Controladora = new Dominio.Controladora();
            if (!this.faltanDatos())
            {
                short id = short.Parse(this.txtId.Text);
                string nombre = this.txtNombre.Text;
                string apellido = this.txtApellido.Text;
                string direccion = this.txtDireccion.Text;
                string telefono = this.txtTelefono.Text;
                DateTime fechaDeMuerte = DateTime.Parse(this.txtFechaMuerte.Text);
                DateTime fechaNacimiento = DateTime.Parse(this.txtFechaNac.Text);
                string nacionalidad = this.txtNacionalidad.Text;

                if (this.txtFechaMuerte.Text != string.Empty)
                {
                    DateTime fechaMuerte = DateTime.Parse(this.txtFechaMuerte.Text);
                    Dominio.Autor unAutor = new Dominio.Autor(id, nombre, apellido, direccion, telefono, fechaMuerte, fechaNacimiento, nacionalidad);
                    if (Controladora.ModificarAutor(unAutor))
                    {
                        ListarAutor();
                        Limpiar();
                        this.lblText.Text = "Autor modificado con exito";
                    }
                    else
                    {
                        this.txtId.Focus();
                        this.lblText.Text = "Ya existe un Autor con ese Id";
                    }
                }
                else if (this.txtFechaMuerte.Text == string.Empty)
                {
                    DateTime fechaNac = DateTime.Parse(this.txtFechaNac.Text);
                    Dominio.Autor unAutor = new Dominio.Autor(id, nombre, apellido, direccion, telefono, fechaNacimiento, nacionalidad);
                    if (Controladora.ModificarAutor(unAutor))
                    {
                        ListarAutor();
                        Limpiar();
                        this.lblText.Text = "Autor modificado con exito";
                    }
                    else
                    {
                        this.txtId.Focus();
                        this.lblText.Text = "Ya existe un Autor con ese Id";
                    }
                }

                else
                {
                    this.lblText.Text = "Ingrese todos los datos";
                }
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            Dominio.Controladora Controladora = new Dominio.Controladora();
            if (!this.faltanDatos())
            {
                short id = short.Parse(this.txtId.Text);
                string nombre = this.txtNombre.Text;
                string apellido = this.txtApellido.Text;
                string direccion = this.txtDireccion.Text;
                string telefono = this.txtTelefono.Text;
                DateTime fechaDeMuerte = DateTime.Parse(this.txtFechaMuerte.Text);
                DateTime fechaNacimiento = DateTime.Parse(this.txtFechaNac.Text);
                string nacionalidad = this.txtNacionalidad.Text;

                if (this.txtFechaMuerte.Text != string.Empty)
                {
                    DateTime fechaMuerte = DateTime.Parse(this.txtFechaMuerte.Text);
                    Dominio.Autor unAutor = new Dominio.Autor(id, nombre, apellido, direccion, telefono, fechaMuerte, fechaNacimiento, nacionalidad);
                    if (Controladora.AgregarAutor(unAutor))
                    {
                        this.Limpiar();

                        this.ListarAutor();
                    }
                    else
                    {
                      
                        this.txtId.Focus();

                    }
                }
                else
                {
                    Dominio.Autor unAutor = new Dominio.Autor(id, nombre, apellido, direccion, telefono, fechaNacimiento, nacionalidad);
                    if (Controladora.AgregarAutor(unAutor))
                    {
                        this.Limpiar();
                        this.ListarAutor();
                        this.lblText.Text = "Autor agregado con exito";
                    }
                    else
                    {
                       
                        this.txtId.Focus();
                        this.lblText.Text = "Ya existe un Autor con ese ID";
                    }

                }

            }
            else
            {
                this.lblText.Text = "Ingrese todos los datos";
            }
        }
        #endregion

        protected void btnElimiar_Click(object sender, EventArgs e)
        {
            Dominio.Controladora unAutor = new Dominio.Controladora();
            if (this.txtId.Text != "")
            {
                short id = short.Parse(this.txtId.Text);
                if (unAutor.BajaAutor(id))
                {
                    this.ListarAutor();
                    this.lblText.Text   = "Autor eliminado con exito";
                    this.Limpiar();
                }
                else
                {
                    
                    this.txtId.Focus();
                    this.lblText.Text = "Ya existe un Autor con ese ID";
                }
            }
            else
            {
                this.lblText.Text = "Seleccione el Autor que desea eliminar";
            }
        }

     
        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {

            if (this.lstAutor.SelectedIndex > -1)
            {

                string linea = this.lstAutor.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                short idAutor = short.Parse(partes[1]);
                this.cargarAutor(idAutor);
            }
            else
            {
                this.lblText.Text = "Debe seleccionar un Autor de la lista.";
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
    }
}