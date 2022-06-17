<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmAutor.aspx.cs" Inherits="FeriaDelLibro2.Presentacion.frmAutor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
            height: 971px;
        }
    </style>
</head>
<body style="height: 1215px">
    <form id="form1" runat="server">
    
    
         <div>
    
       
            <p style="margin-left: 360px">    <a href="../Presentacion/frmGenero.aspx">GENERO</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="../Presentacion/frmLector.aspx"> LECTOR</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <a href="../Presentacion/frmlibro.aspx">LIBRO</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <a href="../Presentacion/frmPais.aspx"> PAIS</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="../Presentacion/frmVenta.aspx"> VENTA</a></p>
        <div/>
    
    </div/>
        <asp:Label ID="lblId" runat="server" Text="Id"></asp:Label>
        <asp:TextBox ID="txtId" runat="server" style="margin-left: 157px"></asp:TextBox>
        <p style="height: 24px">
            <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
            &nbsp;<asp:TextBox ID="txtNombre" runat="server" style="margin-left: 115px" Font-Bold="True"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblApellido" runat="server" Text="Apellido"></asp:Label>
            &nbsp;<asp:TextBox ID="txtApellido" runat="server" style="margin-left: 116px" Font-Bold="True"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblDireccion" runat="server" Text="Direccion"></asp:Label>
            &nbsp;<asp:TextBox ID="txtDireccion" runat="server" style="margin-left: 109px" Font-Bold="True"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
        <p>
            <asp:Label ID="lbltelefono" runat="server" Text="Telefono"></asp:Label>
            &nbsp;<asp:TextBox ID="txtTelefono" runat="server" style="margin-left: 115px" Font-Bold="True"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblFechaM" runat="server" Text="Fecha de Muerte"></asp:Label>
            &nbsp;<asp:TextBox ID="txtFechaMuerte" runat="server" style="margin-left: 61px" Font-Bold="True"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblFechaN" runat="server" Text="Fecha de Nacimiento"></asp:Label>
            &nbsp;&nbsp; <asp:TextBox ID="txtFechaNac" runat="server" style="margin-left: 29px" Font-Bold="True"></asp:TextBox>
        </p>
        <p>
            Nacionalidad&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtNacionalidad" runat="server" style="margin-left: 61px" Font-Bold="True"></asp:TextBox>
        </p>
        <p>
            <asp:ListBox ID="lstAutor" runat="server" Width="783px" Height="111px" style="margin-top: 0px"></asp:ListBox>
        </p>
        <p>
&nbsp;</p>
        <p>
            <asp:Button ID="btnAgregar" runat="server" Text="AGREGAR" Font-Bold="True" OnClick="btnAgregar_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnElimiar" runat="server" Text="ELIMINAR" Font-Bold="True" OnClick="btnElimiar_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click" Text="MODIFICAR" Font-Bold="True" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnLimpiar" runat="server" Font-Bold="True" ForeColor="#0099FF" OnClick="btnLimpiar_Click" Text="Limpiar" Width="105px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSeleccionar" runat="server" Font-Bold="True" ForeColor="#0099FF" style="margin-left: 22px" Text="Seleccionar" Width="122px" OnClick="btnSeleccionar_Click" />
        </p>
        <p>
            <asp:Label ID="lblText" runat="server" Text="Text"></asp:Label>
        </p>
    </form>
</body>
</html>
