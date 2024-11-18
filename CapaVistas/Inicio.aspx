<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Examen_2.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="styles/styles.css" rel="stylesheet" />
    <title>Inicio</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="header">
                <h2>Sistema de Empleados</h2>           
            </div>

            <ul>
                <li><a class="active" href="#home">Home</a></li>
                <li><a href="Usuarios.aspx">Usuarios</a></li>
                <li><a href="Empleados.aspx">Empleados</a></li>
                <li><a href="Puestos.aspx">Puestos</a></li>
                <li><a href="Telefonos.aspx">Numeros Telefonicos</a></li>
                <li><a href="ATrabajados.aspx">Años Trabajados</a></li>
                <li><a href="Direcciones.aspx">Direcciones</a></li>
            </ul>
            <br />
            <div>
                <h2>
                    <asp:Label ID="lmensaje" runat="server" Text="Aviso"></asp:Label>
                </h2>
            </div>

            <h3>Sticky Navigation Bar Example</h3>
            <p>The navbar will <strong>stick</strong> to the top when you reach its scroll position.</p>
            <p><strong>Note:</strong> Internet Explorer do not support sticky positioning and Safari requires a -webkit- prefix.</p>
        </div>
    </form>
</body>
</html>
