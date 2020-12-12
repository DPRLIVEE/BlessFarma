
using System;
using System.Data;
using System.Linq;
using System.Web.UI;

namespace BlessFarma
{
    public partial class Master : MasterPage
    {


        protected void salir_ServerClick(object sender, EventArgs e)
        {
            Session["estaRegistrado"] = null;
            Response.Redirect("Login.aspx");
        }

    }

}