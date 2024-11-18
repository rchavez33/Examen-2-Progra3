<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Examen_2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="styles/stylessLogin.css" rel="stylesheet" />
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css">
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;500;600&display=swap" rel="stylesheet">
    <title>Inicio de sesión</title>
</head>
<body>
        

    <div class="container">
	<div class="screen">
		<div class="screen__content">
			<form class="login" id="form1" runat="server">
				<div class="login__field">
					<i class="login__icon fas fa-user"></i>
					<asp:TextBox ID="tusuario" class="login__input" placeholder="Usuario" required="" runat="server"></asp:TextBox>
				</div>

				<div class="login__field">
					<i class="login__icon fas fa-lock"></i>
					<asp:TextBox ID="tclave" class="login__input" Type="password" placeholder="Contraseña" required="" runat="server"></asp:TextBox>
				</div>

				<asp:Button ID="bingresar" class="button login__submit" Text="Ingresar" runat="server" />

				<br />

				<asp:Label ID="lmensaje" class="screen" runat="server" Text="" Font-Size="Larger" ForeColor="Red"></asp:Label>

				<br />	
                
		</div>
		
		<div class="screen__background">
			<span class="screen__background__shape screen__background__shape4"></span>
			<span class="screen__background__shape screen__background__shape3"></span>		
			<span class="screen__background__shape screen__background__shape2"></span>
			<span class="screen__background__shape screen__background__shape1"></span>
		</div>		
	</div>
</div>
    </form>
</body>
</html> 


