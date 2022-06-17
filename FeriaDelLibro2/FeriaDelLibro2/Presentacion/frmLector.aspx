<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLector.aspx.cs" Inherits="FeriaDelLibro2.Presentacion.Lector" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
       
            <p style="margin-left: 360px">  <a href="../Presentacion/frmAutor.aspx"> AUTOR</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <a href="../Presentacion/frmGenero.aspx">GENERO</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <a href="../Presentacion/frmlibro.aspx">LIBRO</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <a href="../Presentacion/frmPais.aspx"> PAIS</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="../Presentacion/frmVenta.aspx"> VENTA</a></p>
    <div>
    
    </div>
        <asp:Label ID="lblId" runat="server" Text="Id"></asp:Label>
        <asp:TextBox ID="txtId" runat="server" style="margin-left: 102px"></asp:TextBox>
        <p style="height: 24px">
            <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server" style="margin-left: 62px" CausesValidation="True"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblApellido" runat="server" Text="Apellido"></asp:Label>
            <asp:TextBox ID="txtApellido" runat="server" style="margin-left: 61px"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lblDireccion" runat="server" Text="Direccion"></asp:Label>
            <asp:TextBox ID="txtDireccion" runat="server" style="margin-left: 55px"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="lbltelefono" runat="server" Text="Telefono"></asp:Label>
            <asp:TextBox ID="txtTelefono" runat="server" style="margin-left: 61px"></asp:TextBox>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:ListBox ID="lstLector" runat="server" Width="463px" OnSelectedIndexChanged="lstLector_SelectedIndexChanged" Height="75px"></asp:ListBox>
        &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSeleccionar" runat="server" Font-Bold="True" ForeColor="#0066FF" Height="27px" OnClick="btnSeleccionar_Click" Text="Seleccionar" Width="87px" />
&nbsp;&nbsp;
            <asp:Button ID="btnLimpiar" runat="server" Font-Bold="True" ForeColor="#0066FF" Height="26px" OnClick="btnLimpiar_Click" Text="Limpiar" Width="93px" />
        </p>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="brnAgregar" runat="server" Text="AGREGAR" Font-Bold="True" OnClick="brnAgregar_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnElimiar" runat="server" Text="ELIMINAR" Font-Bold="True" OnClick="btnElimiar_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click2" Text="MODIFICAR"  Font-Bold="True" />
&nbsp;
        </p>
        <p>
            <asp:Label ID="lblText" runat="server" Text="Text"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
    
    </div>
    </form>
</body>
</html>
