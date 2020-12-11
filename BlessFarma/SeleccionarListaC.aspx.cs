using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using CTR;
using DTO;
using System.Web.UI.WebControls;

namespace BlessFarma
{
    public partial class SeleccionarListaC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            llenarGVListaC();
        }
        public void llenarGVListaC()
        {
            CTR_ListaCompra objListaC = new CTR_ListaCompra();
            DataTable dtListaCompra = new DataTable();
            dtListaCompra=objListaC.SelectListaCompra();
            gvListaCompra.DataSource = dtListaCompra;
            gvListaCompra.DataBind();
        
        }
       

        protected void gvListaCompra_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SeleccionarListaC")
            {
                int idListaCompra = Convert.ToInt32(gvListaCompra.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["idListaCompra"].ToString());
                Session.Add("idListaC", idListaCompra);
                Response.Redirect("AgregarPedido.aspx");
            }
        }
    }
}