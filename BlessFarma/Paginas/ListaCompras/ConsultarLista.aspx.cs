using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;

namespace BlessFarma.Paginas.ListaCompras
{
    public partial class ConsultarLista : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrilla();
            }
        }

        public void CargarGrilla()
        {
            try
            {
                DtoProdListaCompra dtoProdListaCompra = new DtoProdListaCompra()
                {
                    Criterio = Session["idListaCompra"].ToString()

                };
                ClassResultV cr = new CtrListaCompra().Usp_GetProdListaCompra(dtoProdListaCompra);
                if (!cr.HuboError)
                {
                    DtoProdListaCompra val = new DtoProdListaCompra();
                    List<DtoProdListaCompra> list = cr.List.Cast<DtoProdListaCompra>().ToList();
                    tCodListaCompra.Text = list[0].idListaCorrelativo;
                    tFecha.Text = list[0].fecha.ToString("dd/MM/yyyy");

                    gvCListaCompra.DataSource = list;
                    gvCListaCompra.DataBind();
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "No se pudo cargar los productos de la lista." + "', 'error');", true);
            }
        }
        protected void gvCListaCompra_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvCListaCompra_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvCListaCompra_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void gvCListaCompra_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvCListaCompra_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvCListaCompra_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

            Response.Redirect("ListaCompras.aspx");

        }
    }
}