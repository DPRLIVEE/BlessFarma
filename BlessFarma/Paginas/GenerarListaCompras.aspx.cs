using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;

namespace BlessFarma.Paginas
{
    public partial class GenerarListaCompras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SelectCategorias();
        }

        protected void gvCategoria_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
        }

        protected void gvCategoria_RowEditing(object sender, GridViewEditEventArgs e)
        {
          
        }

        protected void gvCategoria_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            
        }

        protected void gvCategoria_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvCategoria_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }

        protected void gvCategoria_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
           
        }

        public void SelectCategorias()
        {
            try
            {
                CTR_ListaCompra obj = new CTR_ListaCompra();
                DataTable data = obj.SelectListaCompra();

                gvCategoria.DataSource = data;
                gvCategoria.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InsertCategoria(GridView grid)
        {
            
        }

        private void UpdateCategoria(GridView grid)
        {
            

        }

        protected void btnAgregarLista_Click(object sender, EventArgs e)
        {
            CTR_ListaCompra obj = new CTR_ListaCompra();
            obj.insertar();
            
            Response.Redirect("AgregarLista.aspx");

        }
    }
}