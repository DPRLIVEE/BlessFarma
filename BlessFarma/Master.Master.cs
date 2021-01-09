using CTR;
using DTO;
using System;
using System.Data;
using System.Linq;
using System.Web.UI;

namespace BlessFarma
{
    public partial class Master : MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
                if (Session["Correo"] == null)
                {
                    Response.Redirect("../Login/Login.aspx");
                    
                }
                else
                {
                    DtoUsuario dtou = (DtoUsuario)Session["Correo"];
                    
                    imgUsuario.Src = dtou.Foto is null ? "~/imagenes/usuario.png" : "data:image/jpg;base64," + Convert.ToBase64String(dtou.Foto);
                    imgUser.Src = dtou.Foto is null ? "~/imagenes/usuario.png" : "data:image/jpg;base64," + Convert.ToBase64String(dtou.Foto);
                    lblUsuario.InnerText = ' '+dtou.nombreUsuario + ' ' + dtou.apellidoUsuario;
                    lblUser.InnerText = "Bienvenido(a) " + dtou.nombreUsuario;
                    lblTipoUsuario.InnerText = ' '+ dtou.nombreTipoUsuario ;
                    //ltlRol.Text = "<span class='nav-link'>" + dtou.nombreUsuario + "</span>";
                }
            }
        }

        protected void salir_ServerClick(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("../Login/Login.aspx");
        }

      


    }

}