using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlessFarma.Paginas
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                if (Session["1"] != null)
                {
                    Response.Redirect("Principal");
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
                DtoUsuario dtoU = new DtoUsuario
                {
                    Usuario = txtUsuario.Text,
                    Password = txtContraseña.Text
                };
                dtoU = new CtrUsuario().Usp_Login(dtoU);
                if (!dtoU.HuboError)
                {
                   
                    if (perfiles.Count == 1)
                    {
                        dtoU.Rol = perfiles[0].IdRol;
                        dtoU.NomRol = perfiles[0].NomRol;
                        Session["Usuario"] = dtoU;
                        Response.Redirect("Principal.aspx");
                    }
                    else
                    {
                        repeater.DataSource = perfiles;
                        repeater.DataBind();
                        Session["Usuario"] = dtoU;
                        ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "$('#myModal').modal('show');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + dtoU.ErrorMsj + "', 'error');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + ex.Message + "', 'error');", true);
            }

        }


    }
}