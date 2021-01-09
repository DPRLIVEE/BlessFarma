using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using DTO;

namespace BlessFarma.Paginas
{
    public partial class Login : Page
    {
        

        //    protected void Page_Load(object sender, EventArgs e)
        //    {
        //        if (!IsPostBack) {

        //            if (Session["estaRegistrado"] != null)
        //            {
        //                Response.Redirect("Principal.aspx");
        //            }
        //            else
        //            {
        //                txtUsuario.Text = string.Empty;
        //                txtContraseña.Text = string.Empty;
        //            }
        //        }
        //    }

        //    protected void btnLogin_Click(object sender, EventArgs e)
        //    {

        //        try
        //        {
        //            email = txtUsuario.Text;
        //            contrasena = txtContraseña.Text;
        //            CTR_Ususario obj = new CTR_Ususario();
        //            int respuesta = obj.login(email, contrasena);
        //            if (respuesta == 0)
        //            {
        //                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Contraseña incorrecta')", true);
        //            }
        //            else
        //            {
        //                Session["estaRegistrado"] = respuesta;
        //                Response.Redirect("Principal.aspx");
        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //        }

        //    }


        //}



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Correo"] != null)
                {
                    Response.Redirect("../Principal/Principal.aspx");
                }
                else
                {
                    tUsuario.Text = string.Empty;
                    tContraseña.Text = string.Empty;
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                DtoUsuario dtoU = new DtoUsuario
                {
                    correo = tUsuario.Text,
                    contraseña = tContraseña.Text
                };

                dtoU = new CtrUsuario().Usp_Login(dtoU);

                if (!dtoU.HuboError)
                {
                    List<DtoTipoUsuario> perfiles = new CtrTipoUsuario().Usp_GetAllPerfiles();
                    
                    if (perfiles.Count >= 1)
                    {
                        //dtoU.idTipoUsuario = perfiles[dtoU.idUsuario].idTipoUsuario;
                        
                        Session["Correo"] = dtoU;
                        Response.Redirect("../Principal/Principal.aspx");
                    }

                    else
                    {
                        Session["Correo"] = dtoU;

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

        protected void repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        


    }
}