using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using DTO;

namespace BlessFarma
{
    public partial class AgregarPedido : System.Web.UI.Page
    {
        DTO_ProductoListaCompra objProductoLC;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtEstado.Text = "Creado";
                txtFechaE.Text = DateTime.Now.Date.ToShortDateString();
                llenarDDLProveedor();
                objProductoLC = new DTO_ProductoListaCompra();
               objProductoLC.idListaCompra = (int)Session["idListaC"];
                llenarDDLProducto(objProductoLC);

            }
        }

        public void llenarDDLProveedor()
        {
            CTR_Proveedor objProveedor = new CTR_Proveedor();
            DataSet dsProveedor = new DataSet();
            dsProveedor = objProveedor.SelectProveedor();
            ddlProveedor.DataTextField = "razonSocial";
            ddlProveedor.DataValueField = "idProveedor";
            ddlProveedor.DataSource = dsProveedor;
            ddlProveedor.DataBind();
            ddlProveedor.Items.Insert(0, "Seleccionar");
        }

        public void llenarDDLProducto(DTO_ProductoListaCompra DTOProducto)
        {
            
            CTR_ProductoListCompra objProducto = new CTR_ProductoListCompra();
            DataTable dtProducto = new DataTable();
            dtProducto = objProducto.SelectProductoLC(DTOProducto);
            ddlProveedor.DataTextField = "nombreProducto";
            ddlProveedor.DataValueField = "idProducto";
            ddlProveedor.DataSource = dtProducto;
            ddlProveedor.DataBind();
            ddlProveedor.Items.Insert(0, "Seleccionar");

        }

        protected void btnAgregarPedido_Click(object sender, EventArgs e)
        {
            DTO_Pedido DTOPedido = new DTO_Pedido();
            DTOPedido.FechaEmision = Convert.ToDateTime(DateTime.Now.Date.ToShortDateString());
            DTOPedido.FechaEntrega = Calendar1.SelectedDate;
            DTOPedido.modoPago = ddlMedioPago.SelectedValue;
            DTOPedido.idProveedor = int.Parse(ddlProveedor.SelectedValue);
            DTOPedido.idListaCompra = objProductoLC.idListaCompra;
            //DTOPedido.idListaCompra = 1;
            CTR_Pedido objPedido = new CTR_Pedido();
            objPedido.InsertPedido( DTOPedido);
        }
        protected void ddlProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCantidad.Text = "";
        }

        protected void ddlMedioPago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}