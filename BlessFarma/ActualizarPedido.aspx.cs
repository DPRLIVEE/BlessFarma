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
            dtDetallePedido = CTRDPedido.CTR_SelectDetallePedido(DTOPedido.idPedido);
                    
            if (!IsPostBack)
            {               
                CargarDDLProducto(DTOPLC);
                CargarDLLProveedor();
                Session.Add("dtP", dtDetallePedido);
                gvProductos.DataSource = dtDetallePedido;
                gvProductos.DataBind();                             
            }
            
        }
        public void UpdateProductos()
        {            
            
            for(int i=0; i<dtDetallePedido.Rows.Count;i++)
            {
                
                string p = dtDetallePedido.Rows[i][1].ToString();                
                for (int j = 0; j < gvProductos.Rows.Count;j++)
                {                       
                    string p2 = gvProductos.Rows[j].Cells[1].Text;
                    if (p != p2) 
                    {

                        DTO_Producto objProducto = new DTO_Producto();
                        objProducto.idPedido = DTOPedido.idPedido;
                        objProducto.idProducto= int.Parse(gvProductos.Rows[j].Cells[0].Text);
                        objProducto.cantidad = int.Parse(gvProductos.Rows[j].Cells[3].Text);
                        objProducto.PrecioTotal = Convert.ToDecimal(gvProductos.Rows[j].Cells[5].Text);
                        CTR_ProductoListCompra objPLC = new CTR_ProductoListCompra();
                        objPLC.UpdateProducto_x_DetallePedido(objProducto);

                    }
                    
                }                                 
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
            foreach (DataRow row in dtDetallePedido.Rows)
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
                UpdateProductos();
                lblMsj.Text = "Actualizacion Correcta!";
                txtTotal.Text = MontoTotal().ToString();
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
                    montoT = MontoTotal() - Convert.ToDecimal(gvProductos.Rows[id].Cells[5].Text);
                    txtTotal.Text = montoT.ToString();
                    gvProductos.DataSource = dt;
                    gvProductos.DataBind();
                    Session.Add("dtP", dt);
                //}
           
            }
        }

        protected void btnAñadirP_Click(object sender, EventArgs e)
        {
           
            DataTable dtTemp = new DataTable();
            dtTemp = (DataTable)Session["dtP"];
            DataRow row = dtTemp.NewRow();
            row["idProducto"] = ddlProducto.SelectedValue;
            row["nombreProducto"] = ddlProducto.SelectedItem.Text;
            row["formato"] = ObtenerFormato(Convert.ToInt32(ddlProducto.SelectedItem.Value)).formato;
            row["cantidad"] = Convert.ToInt32(txtCantidad.Text);
            row["precioCompra"] = ObtenerFormato(Convert.ToInt32(ddlProducto.SelectedItem.Value)).precioCompra;         
            row["PrecioTotal"] = Convert.ToDecimal(row["cantidad"]) * Convert.ToDecimal(row["precioCompra"]);           
            dtTemp.Rows.Add(row);
            gvProductos.DataSource = dtTemp;
            gvProductos.DataBind();
            txtTotal.Text = MontoTotal().ToString();
            Session.Add("dtP", dtTemp);
        }
    }
}