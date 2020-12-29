using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using DTO;
using CTR;

namespace BlessFarma
{
    public partial class ConsultarPedido : System.Web.UI.Page
    {
        DTO_Pedido DTOPedido;
        DataTable dtDetallePedido;
        CTR_DetallePedido CTRDPedido;
        protected void Page_Load(object sender, EventArgs e)
        {
            DTOPedido = new DTO_Pedido();
            CTRDPedido = new CTR_DetallePedido();
            dtDetallePedido = new DataTable();
            DTOPedido= (DTO_Pedido)Session["Pedido"];
            DatosPedido(DTOPedido);
            
            if(!IsPostBack)
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
       

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarPedido");
        }
    }
}