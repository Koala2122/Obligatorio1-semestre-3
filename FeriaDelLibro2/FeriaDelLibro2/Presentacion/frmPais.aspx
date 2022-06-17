<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPais.aspx.cs" Inherits="FeriaDelLibro2.Presentacion.Pais" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 421px; width: 1059px">
    
        <br />
            
       
            <p style="margin-left: 360px">    <a href="../Presentacion/frmAutor.aspx">AUTOR</a>&nbsp;&nbsp;&nbsp;&nbsp; <a href="../Presentacion/frmGenero.aspx">GENERO</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="../Presentacion/frmLector.aspx"> LECTOR</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <a href="../Presentacion/frmlibro.aspx">LIBRO</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="../Presentacion/frmVenta.aspx"> VENTA</a></p>
    
        <asp:Label ID="lblId" runat="server" Font-Bold="True" Text="Id" Width="63px" Height="16px"></asp:Label>
        &nbsp;
        <asp:TextBox ID="txtId" runat="server" OnTextChanged="TextBox1_TextChanged" Height="20px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblPais" runat="server" Font-Bold="True" Text="Ingrese Pais"></asp:Label>
        <br />
        <asp:TextBox ID="txtPais" runat="server" Width="106px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblContinente" runat="server" Font-Bold="True" Text="Continente" Width="100px"></asp:Label>
        <asp:TextBox ID="txtContinente" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:ListBox ID="lstPais" runat="server" AutoPostBack="True" Width="296px" OnSelectedIndexChanged="lstPais_SelectedIndexChanged"></asp:ListBox>
        <asp:Button ID="btnSeleccionar" runat="server" BackColor="#66CCFF" BorderStyle="None" Font-Bold="True" OnClick="btnSeleccionar_Click" Text="SELECCIONAR" Width="101px" />
        <br />
        <br />
        <br />
        <asp:Button ID="btnAlta" runat="server" Font-Bold="True" Text="ALTA" Width="100px" OnClick="btnAlta_Click" />
        <asp:Button ID="btnBaja" runat="server" Font-Bold="True" Text="BAJA" Width="100px" OnClick="btnBaja_Click"/>
        <asp:Button ID="btnModificar" runat="server" Font-Bold="True" Text="MODIFICAR" Width="100px" OnClick="btnModificar_Click"/>
    
        <asp:Button ID="btnLimpiar" runat="server" Font-Bold="True" OnClick="btnLimpiar_Click" Text="Limpiar" Width="100px" />
    
    </div>
        <asp:Label ID="lblText" runat="server" Text="text"></asp:Label>
    </form>
</body>
</html>
