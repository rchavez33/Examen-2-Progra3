<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Direcciones.aspx.cs" Inherits="Examen_2.CapaVistas.Direcciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Direcciones</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <br />
            <label>ID Dirección</label>
            <br />
            <asp:TextBox ID="tidDireccion" runat="server"></asp:TextBox>
            <br />
            <label>ID Empleado</label>
            <br />
            <asp:TextBox ID="tidEmpleado" runat="server"></asp:TextBox>
            <br />
            <label>País</label>
            <br />
            <asp:TextBox ID="tpais" runat="server"></asp:TextBox>
            <br />
            <label>Estado / Provincia</label>
            <br />
            <asp:TextBox ID="testadoProvincia" runat="server"></asp:TextBox>
            <br />
            <label>Ciudad / Distrito</label>
            <br />
            <asp:TextBox ID="tciudadDistrito" runat="server"></asp:TextBox>
            <br />
            <label>Barrio / Suburbio / Calle / Avenida</label>
            <br />
            <asp:TextBox ID="tbarrioSuburbio" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Button ID="Button1" class="button button1" runat="server" Text="Agregar" />
            <asp:Button ID="Button2" class="button button2" runat="server" Text="Modificar" />
            <asp:Button ID="Button3" class="button button3" runat="server" Text="Borrar" />
            <asp:Button ID="Button4" class="button button4" runat="server" Text="Consultar" />
        </div>
    </form>
</body>
</html>
