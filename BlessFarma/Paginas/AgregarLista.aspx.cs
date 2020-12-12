using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlessFarma.Paginas
{
    public partial class AgregarLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
        }

        private void InsertCategoria(GridView grid)
        {

        }

        private void UpdateCategoria(GridView grid)
        {


        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

            Response.Redirect("GenerarListaCompras.aspx");

        }
    }
}