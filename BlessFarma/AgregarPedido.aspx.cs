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
            objProductoLC = new DTO_ProductoListaCompra();
            objProductoLC.idListaCompra = (int)Session["idListaC"];
            if (!IsPostBack)
            {
                txtEstado.Text = "Creado";
                txtFechaE.Text = DateTime.Now.Date.ToShortDateString();
                llenarDDLProveedor();                              
                llenarDDLProducto(objProductoLC);
               // LLenarPrueba(objProductoLC);

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
            ddlProducto.DataTextField = "nombreProducto";
            ddlProducto.DataValueField = "idProducto";
            ddlProducto.DataSource = dtProducto;
            ddlProducto.DataBind();
            ddlProducto.Items.Insert(0, "Seleccionar");

        }

        public int ObtenerIDProducto(DTO_ProductoListaCompra DTOProducto, string nomProducto)
        {
            string nomP = "";
            int idP = 0;
            CTR_ProductoListCompra objProducto = new CTR_ProductoListCompra();
            DataTable dtProducto = new DataTable();
            dtProducto = objProducto.SelectProductoLC(DTOProducto);
            foreach(DataRow row in dtProducto.Rows)
            {
                nomP = row["nombreProducto"].ToString();
                if (nomP == nomProducto) return idP = int.Parse(row["idProducto"].ToString());

            }
            return 0;
        }
        public void LLenarPrueba(DTO_ProductoListaCompra DTOPLC)
        {
            CTR_ProductoListCompra objProducto = new CTR_ProductoListCompra();
            DataTable dtProducto = new DataTable();
            dtProducto = objProducto.SelectProductoLC(DTOPLC);
            gvPrueba.DataSource = dtProducto;
            gvPrueba.DataBind();
        }
        public bool ValidarTotalidadProductos(DTO_ProductoListaCompra DTOPLC)
        {
            CTR_ProductoListCompra objProducto = new CTR_ProductoListCompra();
            DataTable dtProducto = new DataTable();
            dtProducto = objProducto.SelectProductoLC(DTOPLC);
            if (dtProducto.Rows.Count != gvProductos.Rows.Count) return false;
            return true;       
        }        
        protected void ddlProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCantidad.Text = "";
            lblMensaje.Text = "";
        }

        protected void ddlMedioPago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAgregarP_Click(object sender, EventArgs e)
        {
            DTO_Pedido DTOPedido = new DTO_Pedido();
            objProductoLC = new DTO_ProductoListaCompra();
            objProductoLC.idListaCompra = (int)Session["idListaC"];
            DTOPedido.FechaEmision = Convert.ToDateTime(DateTime.Now.Date.ToShortDateString());
            DTOPedido.FechaEntrega = Calendar1.SelectedDate;
            DTOPedido.modoPago = ddlMedioPago.SelectedValue;
            DTOPedido.idProveedor = int.Parse(ddlProveedor.SelectedValue);
            DTOPedido.idListaCompra = objProductoLC.idListaCompra;
            DTOPedido.MontoTotal = MontoTotal();
            DTOPedido.Estado = 1;         
            CTR_Pedido objPedido = new CTR_Pedido();            
            txtCantidad.Text = "";
            if (ValidarTotalidadProductos(objProductoLC))
            {
                objPedido.InsertPedido(DTOPedido);
                InsertProductos(objProductoLC);
                lblMensaje.Text = "Pedido registrado correctamente!";
            } 
            else lblMensaje.Text = "No se han seleccionado todos los productos.";



        }
  
        public DTO_Producto ObtenerFormato(int idPd)
        {
            int idP = 0;
            DTO_Producto objProducto = new DTO_Producto();
            objProductoLC.idListaCompra = (int)Session["idListaC"];
            CTR_ProductoListCompra objProdLC = new CTR_ProductoListCompra();
            DataTable dtProducto = new DataTable();
            dtProducto = objProdLC.SelectProductoLC(objProductoLC);

            foreach(DataRow row in dtProducto.Rows)
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
        public void ListarProducto()
        {
            DataTable dtProducto = new DataTable();
            if(dtProducto.Columns.Count==0)
            {
                dtProducto.Columns.Add("Cod", System.Type.GetType("System.Int32"));
                dtProducto.Columns.Add("Producto", System.Type.GetType("System.String"));
                dtProducto.Columns.Add("Formato", System.Type.GetType("System.String"));
                dtProducto.Columns.Add("Cantidad", System.Type.GetType("System.Int32"));
                dtProducto.Columns.Add("Precio", System.Type.GetType("System.Decimal"));
                dtProducto.Columns.Add("Total", System.Type.GetType("System.Decimal"));
            }
            DataTable dt_T = new DataTable();
            dt_T = (DataTable)Session["dtTransformacion"];

            if (dt_T != null)
            {
                dtProducto = dt_T;
            }
            DataRow row = dtProducto.NewRow();
            row["Cod"] = Convert.ToInt32(ddlProducto.SelectedValue);
            row["Producto"] = ddlProducto.SelectedItem.Text;
            row["Formato"] = ObtenerFormato(Convert.ToInt32(ddlProducto.SelectedItem.Value)).formato;
            row["Cantidad"] = Convert.ToInt32(txtCantidad.Text);
            row["Precio"]= ObtenerFormato(Convert.ToInt32(ddlProducto.SelectedItem.Value)).precioCompra;
            row["Total"] = Convert.ToDecimal(row["Cantidad"]) * Convert.ToDecimal(row["Precio"]);

            dtProducto.Rows.Add(row);
            gvProductos.DataSource = dtProducto;
            gvProductos.DataBind();
            Session.Add("dtTransformacion", dtProducto);

        }
        public void InsertProductos(DTO_ProductoListaCompra objPLC)
        {
            string nom = "";
            CTR_DetallePedido objDetalleP = new CTR_DetallePedido();
            DTO_DetallePedido DTODetalleP = new DTO_DetallePedido();
            
            foreach (GridViewRow row in  gvProductos.Rows)
            {
                nom= row.Cells[2].Text;
                DTODetalleP.idProducto = ObtenerIDProducto(objPLC, nom);
                DTODetalleP.cantidad= int.Parse(row.Cells[4].Text);
                DTODetalleP.idPedido = ObtenerIDPedido();
                DTODetalleP.precioTotal= Convert.ToDecimal(row.Cells[6].Text);              
                objDetalleP.CTR_Insert_DetallePedido(DTODetalleP);
            }
        
        
        }
        public decimal MontoTotal()
        {
            decimal total = 0;
            CTR_DetallePedido objDetalleP = new CTR_DetallePedido();
            DTO_DetallePedido DTODetalleP = new DTO_DetallePedido();

            foreach (GridViewRow row in gvProductos.Rows)
            {               
                total += Convert.ToDecimal(row.Cells[6].Text);               
            }
            return total;
        }
        public int ObtenerIDPedido()
        {
            int idP = 0;
            CTR_Pedido objPedido = new CTR_Pedido();
            DataTable dtPedido = new DataTable();
            dtPedido = objPedido.SelectPedido();
            DataRow lastRow = dtPedido.Rows[dtPedido.Rows.Count - 1];
            return idP = int.Parse(lastRow["idPedido"].ToString());
            
        }
        protected void btnAñadirProducto_Click(object sender, EventArgs e)
        {
            ListarProducto();
            txtTotal.Text = MontoTotal().ToString();
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarPedido.aspx");
        }
        protected void gvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if( e.CommandName == "BorrarP")
            {
                decimal montoT = 0;
                int id = int.Parse(e.CommandArgument.ToString());
                lblMensaje.Text = "Indice del registro: " + id;
                DataTable dt = new DataTable();
                dt = (DataTable)Session["dtTransformacion"];
                dt.Rows[id].Delete();
                montoT = MontoTotal() - Convert.ToDecimal(gvProductos.Rows[id].Cells[4].Text);
                txtTotal.Text = montoT.ToString();
                gvProductos.DataSource = dt;
                gvProductos.DataBind();
            }
           
        }
    }
}