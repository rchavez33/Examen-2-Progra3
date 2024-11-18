<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="Examen_2.CapaVistas.Usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../styles/styleBoton.css" rel="stylesheet" />
    <title>Usuarios</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <label>
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <br />
            <br />
            ID </label>
            <br />
            <asp:TextBox ID="tid" runat="server"></asp:TextBox>
            <br />
            <label>Nombre </label>
            <br />
            <asp:TextBox ID="tnombre" runat="server"></asp:TextBox>
            <br />
            <label>Clave </label>
            <br />
            <asp:TextBox ID="tclave" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" class="button button1" runat="server" Text="Agregar" OnClick="Button1_Click" />
            <asp:Button ID="Button2" class="button button2" runat="server" Text="Modificar" OnClick="Button2_Click" />
            <asp:Button ID="Button3" class="button button3" runat="server" Text="Borrar" OnClick="Button3_Click" />
            <asp:Button ID="Button4" class="button button4" runat="server" Text="Consultar" OnClick="Button4_Click" />

        </div>
    </form>
</body>
</html>
