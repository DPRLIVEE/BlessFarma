using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;

namespace BlessFarma.Paginas
{
    public partial class Login : System.Web.UI.Page
    {
        string email;
        string contrasena;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                if (Session["estaRegistrado"] != null)
                {
                    Response.Redirect("Principal.aspx");
                }
                else
                {
                    txtUsuario.Text = string.Empty;
                    txtContraseña.Text = string.Empty;
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                email = txtUsuario.Text;
                contrasena = txtContraseña.Text;
                CTR_Ususario obj = new CTR_Ususario();
                int respuesta = obj.login(email, contrasena);
                if (respuesta == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Contraseña incorrecta')", true);
                }
                else
                {
                    Session["estaRegistrado"] = respuesta;
                    Response.Redirect("Principal.aspx");
                }
            }
            catch (Exception ex)
            {
               
            }

        }


    }
}