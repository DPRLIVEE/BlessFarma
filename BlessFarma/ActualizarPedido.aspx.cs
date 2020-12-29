using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTO;
using CTR;

namespace BlessFarma
{
    public partial class ActualizarPedido : System.Web.UI.Page
    {
        DTO_Pedido DTOPedido;
        DataTable dtDetallePedido;
        CTR_DetallePedido CTRDPedido;
        protected void Page_Load(object sender, EventArgs e)
        {
          

            DTOPedido = new DTO_Pedido();
            CTRDPedido = new CTR_DetallePedido();
            dtDetallePedido = new DataTable();
            DTOPedido = (DTO_Pedido)Session["Pedido"];
            DatosPedido(DTOPedido);

            if (!IsPostBack)
            {

                dtDetallePedido = CTRDPedido.CTR_SelectDetallePedido(DTOPedido.idPedido);
                gvProductos.DataSource = dtDetallePedido;
                gvProductos.DataBind();
            }
        }

        public void DatosPedido(DTO_Pedido DTOPedido)
        {
            txtPedido.Text = DTOPedido.idPedido.ToString();
            txtFechaEntrega.Text = DTOPedido.FechaEntrega.ToString();
            txtFechaE.Text = DTOPedido.FechaEmision.ToString();
            txtMedioPago.Text = DTOPedido.modoPago;
            txtProveedor.Text = DTOPedido.razonSocial;
        }

        public void UpdatePedido(DTO_Pedido DTOPedido)
        {
            DTO_Pedido objPedido = new DTO_Pedido();
            if (cldFechaEntrega.SelectedDate != null) objPedido.FechaEntrega = cldFechaEntrega.SelectedDate;
            objPedido.FechaEntrega = Convert.ToDateTime(txtFechaEntrega.Text);
            objPedido.FechaEmision = Convert.ToDateTime(txtFechaE.Text);
            objPedido.idPedido = DTOPedido.idPedido;
            if (ddlProveedor.SelectedValue == "" || Convert.ToInt32(ddlProveedor.SelectedValue) == 0)
            objPedido.idProveedor = 1;
            else objPedido.idProveedor = Convert.ToInt32(ddlProveedor.SelectedValue);
            if (ddlMedioPago.SelectedValue == "" || Convert.ToInt32(ddlMedioPago.SelectedValue) == 0)
            objPedido.idProveedor = 1;
            else objPedido.modoPago = ddlProveedor.SelectedValue.ToString();
        }

        protected void ddlMedioPago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}