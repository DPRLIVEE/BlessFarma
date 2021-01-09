using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;
namespace BlessFarma.Paginas.GestionarPedido
{
    public partial class ConsultarPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrilla();
            }
        }

        protected void gvCPedido_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvCPedido_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvCPedido_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void gvCPedido_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvCPedido_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvCPedido_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

            Response.Redirect("GestionarPedido.aspx");

        }

        public void CargarGrilla()
        {
            try
            {
                DtoPedido dtoPedido = new DtoPedido()
                {
                    Criterio = Session["idPedido"].ToString()

                };
                ClassResultV cr = new CtrPedido().Usp_GetPedidoLista(dtoPedido);
                if (!cr.HuboError)
                {
                    DtoPedido val = new DtoPedido();
                    List<DtoPedido> list = cr.List.Cast<DtoPedido>().ToList();
                    tCodigoPedido.Text = list[0].correlativo.ToString();
                    tEstado.Text = list[0].NombreEstado.ToString();
                    tFechaEmision.Text = list[0].fechaEmision.ToString("dd/MM/yyyy");
                    tFechaEntrega.Text = list[0].fechaEntrega.ToString("dd/MM/yyyy");
                    tMedioPago.Text = list[0].metodoPago.ToString();
                    tProveedor.Text = list[0].razonSocial.ToString();
                    
                    gvCPedido.DataSource = list;
                    gvCPedido.DataBind();

                    decimal montTotal = 0;
                    if (list.Count > 0)
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            montTotal += list[i].precioTotal;
                            tPrecioTotal.Text = montTotal.ToString();
                        }
                    }
                    else
                    {
                        tPrecioTotal.Text = "0";
                    }

                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "No se pudo cargar los productos de la lista." + "', 'error');", true);
            }
        }
    }
}