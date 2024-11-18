﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AniosTrabajados.aspx.cs" Inherits="Examen_2.CapaVistas.ATrabajados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Años Trabajados</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <br />
            <label>ID Empleado</label>
            <br />
            <asp:TextBox ID="tidEmpleado" runat="server"></asp:TextBox>
            <br />
            <label>Años Trabajados</label>
            <br />
            <asp:TextBox ID="taniosTrabajados" runat="server"></asp:TextBox>
            <br />
            <label>Años en Puestos Diferentes</label>
            <br />
            <asp:TextBox ID="taniosPuestosDiferentes" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Button ID="Button1" class="button button1" runat="server" Text="Agregar" />
            <asp:Button ID="Button2" class="button button2" runat="server" Text="Modificar" />
            <asp:Button ID="Button3" class="button button3" runat="server" Text="Borrar" />
            <asp:Button ID="Button4" class="button button4" runat="server" Text="Consultar" />
        </div>
    </form>
</body>
</html>
