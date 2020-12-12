<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BlessFarma.Paginas.Login" EnableEventValidation="false" Async="true" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link rel="icon" type="image/png" sizes="32x32" href="/imagenes/BlessFarmalogo.png" />
    <link rel="icon" type="image/png" sizes="16x16" href="/imagenes/BlessFarmalogo.png" />

    <script src="https://kit.fontawesome.com/64d58efce2.js" crossorigin="anonymous"></script>
    <link href="/csslogin/style.css" rel="stylesheet"  />
   
    <title>BlessFarma</title>

  </head>

  <body>
    <div class="container">
      <div class="forms-container">
        <div class="signin-signup">
          <form runat="server" action="#" class="sign-in-form">
            <h2 class="title">Login</h2>
            <div class="input-field">
              <i class="fas fa-user"></i>
              <asp:TextBox ID="txtUsuario" runat ="server" type="text" placeholder="Usuario" />
            </div>
            <div class="input-field">
              <i class="fas fa-lock"></i>
              <asp:TextBox ID="txtContraseña" type="email" runat ="server" TextMode="Password" placeholder="Contraseña" />
            </div>
            <button runat="server" class="btn solid" onserverclick="btnLogin_Click"> Login</button>
            <p class="social-text">Copyright &copy; BlessFarma 2020</p>
            
          </form>
          <form action="#" class="sign-up-form">
            <h2 class="title">Recuperar Contraseña</h2>
            
            <div class="input-field">
              <i class="fas fa-envelope"></i>
              <input type="email" placeholder="Email" />
            </div>
            
            <input type="submit" class="btn" value="Recuperar" />
            <p class="social-text">Copyright &copy; BlessFarma 2020</p>
            
          </form>
        </div>
      </div>

      <div class="panels-container">
        <div class="panel left-panel">
          <div class="content">
            <h3>¿Olvidaste tu contraseña?</h3>
            <p>
              Si deseas reestablecer tu contraseña no te preocupes, puedes recuperarla aqui.
            </p>
            <button class="btn transparent" id="sign-up-btn">
              Recuperar
            </button>
          </div>
          <img src="/imagenes/log.svg" class="image" alt="" />
        </div>
        <div class="panel right-panel">
          <div class="content">
            <h3>¿Recuperaste tu contraseña?</h3>
            <p>
              Si ya recuperaste tu contraseña puedes ingresar al sistema aqui.
            </p>
            <button class="btn transparent" id="sign-in-btn">
              Ingresar
            </button>
          </div>
          <img src="/imagenes/register.svg" class="image" alt="" />
        </div>
      </div>
    </div>

      <script src="/csslogin/app.js" type="text/javascript"></script>
  </body>
</html>
