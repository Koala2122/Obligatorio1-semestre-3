<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmGenero.aspx.cs" Inherits="FeriaDelLibro2.Presentacion.Genero" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
              
            <p style="margin-left: 360px">  <a href="../Presentacion/frmAutor.aspx"> AUTOR</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <a href="../Presentacion/frmLector.aspx">LECTOR</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <a href="../Presentacion/frmlibro.aspx">LIBRO</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <a href="../Presentacion/frmPais.aspx"> PAIS</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="../Presentacion/frmVenta.aspx"> VENTA</a></p>

        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblId" runat="server" Text="Id"></asp:Label>
&nbsp;
        <asp:TextBox ID="txtId" runat="server" Font-Bold="True" Height="23px" style="margin-left: 15px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblClasificacion" runat="server" Text="Clasificacion"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtClasificacion" runat="server" Height="23px"></asp:TextBox>
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ListBox ID="lstGenero" runat="server" Height="114px" Width="410px">
            <asp:ListItem></asp:ListItem>
        </asp:ListBox>
        <asp:Button ID="btnSeleccionar" runat="server" Font-Bold="True" ForeColor="#66CCFF" Height="28px" OnClick="btnSeleccionar_Click" Text="Seleccionar" Width="92px" />
        <br />
        <asp:Label ID="lblTexto" runat="server" Text="Texto"></asp:Label>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAlta" runat="server" Font-Bold="True" Height="30px" OnClick="btnAlta_Click" Text="Alta" Width="75px" />
        <asp:Button ID="btnModificar" runat="server" Font-Bold="True" Height="30px" Text="Modificar" Width="75px" OnClick="btnModificar_Click" />
        <asp:Button ID="btnBaja" runat="server" Font-Bold="True" Height="30px" Text="Baja" Width="75px" OnClick="btnBaja_Click" />
        <asp:Button ID="btnLimpiar" runat="server" Font-Bold="True" ForeColor="#66CCFF" Height="30px" Text="Limpiar" Width="75px" OnClick="btnLimpiar_Click" />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
