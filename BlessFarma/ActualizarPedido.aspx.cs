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
        DTO_ProductoListaCompra DTOPLC;
        DataTable dtDetallePedido;
        CTR_DetallePedido CTRDPedido;
        DataSet dsProveedor;
        DataTable dtProducto;
        CTR_ProductoListCompra objProducto;
        protected void Page_Load(object sender, EventArgs e)
        {
            CTR_Proveedor objProveedor = new CTR_Proveedor();
            dsProveedor = new DataSet();
            dsProveedor = objProveedor.SelectProveedor();
            DTOPedido = new DTO_Pedido();
            CTRDPedido = new CTR_DetallePedido();
            dtDetallePedido = new DataTable();
           
            DTOPedido = (DTO_Pedido)Session["Pedido"];
            DatosPedido(DTOPedido);
            objProducto = new CTR_ProductoListCompra();
            DTOPLC = new DTO_ProductoListaCompra();
            dtProducto = new DataTable();
            DTOPLC.idListaCompra = DTOPedido.idListaCompra;

            if (!IsPostBack)
            {

               
                CargarDDLProducto(DTOPLC);
                CargarDLLProveedor();
                dtDetallePedido = CTRDPedido.CTR_SelectDetallePedido(DTOPedido.idPedido);
                gvProductos.DataSource = dtDetallePedido;
                gvProductos.DataBind();
                Session.Add("dtP", dtDetallePedido);
               // ListarProductos();


            }
        }
        public decimal MontoTotal()
        {
            decimal total = 0;
            CTR_DetallePedido objDetalleP = new CTR_DetallePedido();
            DTO_DetallePedido DTODetalleP = new DTO_DetallePedido();

            foreach (GridViewRow row in gvProductos.Rows)
            {
                total += Convert.ToDecimal(row.Cells[5].Text);
            }
            return total;
        }
        public DTO_Producto ObtenerFormato(int idPd)
        {
            int idP = 0;
            DTO_Producto objProducto = new DTO_Producto();
            DTOPLC.idListaCompra = (int)Session["idListaC"];
            CTR_ProductoListCompra objProdLC = new CTR_ProductoListCompra();
            DataTable dtProducto = new DataTable();
            dtProducto = objProdLC.SelectProductoLC(DTOPLC);

            foreach (DataRow row in dtProducto.Rows)
            {
                idP = Convert.ToInt32(row["idProducto"].ToString());
                if (idP == idPd)
                {
                    objProducto.formato = row["formato"].ToString();
                    objProducto.precioCompra = Convert.ToDecimal(row["precioCompra"].ToString());
                }
            }
            return objProducto;
        }
        public void DatosPedido(DTO_Pedido DTOPedido)
        {
            txtPedido.Text = DTOPedido.idPedido.ToString();
            txtFechaEntrega.Text = DTOPedido.FechaEntrega.ToString();
            txtFechaE.Text = DTOPedido.FechaEmision.ToString();
            txtMedioPago.Text = DTOPedido.modoPago;
            txtProveedor.Text = DTOPedido.razonSocial;
            txtTotal.Text = DTOPedido.MontoTotal.ToString();
        }
        public void CargarDLLProveedor()
        {
           
            ddlProveedor.DataTextField = "razonSocial";
            ddlProveedor.DataValueField = "idProveedor";
            ddlProveedor.DataSource = dsProveedor;
            ddlProveedor.DataBind();
            ddlProveedor.Items.Insert(0, "Seleccionar");
        }
        public void CargarDDLProducto(DTO_ProductoListaCompra DTOProducto)
        {
           
            dtProducto = objProducto.SelectProductoLC(DTOProducto);
            ddlProducto.DataTextField = "nombreProducto";
            ddlProducto.DataValueField = "idProducto";
            ddlProducto.DataSource = dtProducto;
            ddlProducto.DataBind();
            ddlProducto.Items.Insert(0, "Seleccionar");

        }
        public int GetIDProveedor(string razonSocial)
        {
            int idProveedor = 0;
            foreach(DataRow dr in dsProveedor.Tables[0].Rows)
            {
                string  razonS = dr["razonSocial"].ToString();
                if(razonS==razonSocial) return idProveedor= int.Parse(dr["idProveedor"].ToString());

            }
            return 0;
        }
        public void UpdatePedido(DTO_Pedido DTOPedido)
        {
            DTO_Pedido objPedido = new DTO_Pedido();
            if (cldFechaEntrega.SelectedDate != null) objPedido.FechaEntrega = cldFechaEntrega.SelectedDate;
            else objPedido.FechaEntrega = Convert.ToDateTime(txtFechaEntrega.Text);
            objPedido.FechaEmision = Convert.ToDateTime(txtFechaE.Text);
            objPedido.idPedido = DTOPedido.idPedido;
            if (ddlProveedor.SelectedValue == "Seleccionar")
            objPedido.idProveedor = GetIDProveedor(DTOPedido.razonSocial);
            else objPedido.idProveedor = Convert.ToInt32(ddlProveedor.SelectedValue);
            if (ddlMedioPago.SelectedValue == "")
            objPedido.modoPago = DTOPedido.modoPago;
            else objPedido.modoPago = ddlMedioPago.SelectedValue.ToString();
            CTR_Pedido CTRPedido = new CTR_Pedido();
            CTRPedido.CTR_UpdatePedido(objPedido);
        }
        public bool ValidarTotalidadProductos(DTO_ProductoListaCompra DTOPLC)
        {
            CTR_ProductoListCompra objProducto = new CTR_ProductoListCompra();
            DataTable dtProducto = new DataTable();
            dtProducto = objProducto.SelectProductoLC(DTOPLC);
            if (dtProducto.Rows.Count != gvProductos.Rows.Count) return false;
            return true;
        }

        public void ListarProductos()
        {
            DataTable dtProducto = new DataTable();
            DataRow row = dtProducto.NewRow();  
            if (dtProducto.Columns.Count == 0)
            {
                dtProducto.Columns.Add("Producto", System.Type.GetType("System.String"));
                dtProducto.Columns.Add("Formato", System.Type.GetType("System.String"));
                dtProducto.Columns.Add("Cantidad", System.Type.GetType("System.Int32"));
                dtProducto.Columns.Add("Precio", System.Type.GetType("System.Decimal"));
                dtProducto.Columns.Add("Total", System.Type.GetType("System.Decimal"));

                foreach (GridViewRow gvrow in gvProductos.Rows)
                {
                    row["Producto"] = gvrow.Cells[2].Text.ToString();
                    row["Formato"] = gvrow.Cells[3].Text.ToString();
                    row["Cantidad"] = Convert.ToInt32(gvrow.Cells[4].Text);
                    row["Total"] = Convert.ToDecimal(gvrow.Cells[5].Text.ToString());
                    row["Precio"] = Convert.ToDecimal(row["Total"])/ Convert.ToDecimal(row["Cantidad"]);
                    
                }
                Session.Add("dtListaProducto", dtProducto);
            }
          
           

        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarPedido.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            DTO_ProductoListaCompra DTOPLC = new DTO_ProductoListaCompra();
            DTOPLC.idListaCompra = DTOPedido.idListaCompra;
            if (ValidarTotalidadProductos(DTOPLC))
            {
                UpdatePedido(DTOPedido);
                lblMsj.Text = "Actualizacion Correcta!";
            }
            else lblMsj.Text = "No se han seleccionado todos los productos.";
        }

        protected void ddlMedioPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMedioPago.Text = ddlMedioPago.SelectedValue;
        }

        protected void ddlProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
           txtProveedor.Text= ddlProveedor.SelectedItem.Text;
        }

        protected void cldFechaEntrega_SelectionChanged(object sender, EventArgs e)
        {
            txtFechaEntrega.Text = cldFechaEntrega.SelectedDate.ToShortDateString();
        }

        protected void gvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "BorrarP")
            {
                decimal montoT = 0;
                int id = int.Parse(e.CommandArgument.ToString());               
                DataTable dt = new DataTable();
                dt = (DataTable)Session["dtP"];
                //if (dt.Rows.Count != 0)
                //{
                    dt.Rows[id].Delete();
                    montoT = MontoTotal() - Convert.ToDecimal(gvProductos.Rows[id].Cells[4].Text);
                    txtTotal.Text = montoT.ToString();
                    gvProductos.DataSource = dt;
                    gvProductos.DataBind();
                    Session.Add("dtListaProducto", dt);
                //}
           
            }
        }

        protected void btnAñadirP_Click(object sender, EventArgs e)
        {
            ListarProductos();
            DataTable dtTemp = new DataTable();
            dtTemp = (DataTable)Session["dtListaProducto"];
            DataRow row = dtProducto.NewRow();
            row["Producto"] = ddlProducto.SelectedItem.Text;
            row["Formato"] = ObtenerFormato(Convert.ToInt32(ddlProducto.SelectedItem.Value)).formato;
            row["Cantidad"] = Convert.ToInt32(txtCantidad.Text);
            row["Precio"] = ObtenerFormato(Convert.ToInt32(ddlProducto.SelectedItem.Value)).precioCompra;
            row["Total"] = Convert.ToDecimal(row["Cantidad"]) * Convert.ToDecimal(row["Precio"]);

            dtTemp.Rows.Add(row);
            gvProductos.DataSource = dtTemp;
            gvProductos.DataBind();
            Session.Add("dtListaProducto", dtProducto);
        }
    }
}