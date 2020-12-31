using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using CTR;
using DTO;

namespace BlessFarma
{
    public partial class GestionarPedido : System.Web.UI.Page
    {
        string estado="";
        int idEstado = 0;
        int idPedido = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListarPedido();
            }
        }

        public void ListarPedido()
        {
            CTR_Pedido objPedido = new CTR_Pedido();
            DataTable dt = new DataTable();
            dt = objPedido.SelectPedido();
            dt.Columns.Add("Estado", typeof(string));
            AsignarEstado(dt);
            Session.Add("dt",dt);
            gvPedidos.DataSource = dt;
            gvPedidos.DataBind();
        }
        protected void btnNuevoPedido_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeleccionarListaC.aspx");
        }
        public void AsignarEstado(DataTable dt)
        {
                        
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int s = int.Parse(dt.Rows[i]["estadoPedido"].ToString());
                if (s == 1) estado = "Creado";
                if (s == 2) estado = "En Espera";
                if (s == 3) estado = "Aceptado";
                if (s == 4) estado = "Rechazado";
                if (s == 5) estado = "Entregado Total";
                dt.Rows[i]["Estado"] = estado;

            }                                                 
        }

        protected void gvPedidos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string state = e.Row.Cells[1].Text;

                if(state=="Creado")
                {
                    e.Row.Cells[10].FindControl("btnRechazar").Visible = false;
                    e.Row.Cells[10].FindControl("btnAceptar").Visible = false;
                    e.Row.Cells[10].FindControl("btnEntregado").Visible = false;
                }
                if (state == "En Espera")
                {
                    e.Row.Cells[8].FindControl("btnEditar").Visible = false;
                    e.Row.Cells[9].FindControl("btnAnular").Visible = false;
                    e.Row.Cells[10].FindControl("btnEnviar").Visible = false;
                    e.Row.Cells[10].FindControl("btnEntregado").Visible = false;

                }
                if (state == "Aceptado")
                {
                    e.Row.Cells[8].FindControl("btnEditar").Visible = false;
                    e.Row.Cells[10].FindControl("btnEnviar").Visible = false;
                    e.Row.Cells[10].FindControl("btnRechazar").Visible = false;
                    e.Row.Cells[10].FindControl("btnAceptar").Visible = false;
                    e.Row.Cells[9].FindControl("btnAnular").Visible = false;                  
                 
                }
                if (state == "Rechazado")
                {
                    e.Row.Cells[7].Controls.Clear();
                    e.Row.Cells[8].Controls.Clear();
                    e.Row.Cells[9].FindControl("btnEnviar").Visible = false;
                    e.Row.Cells[9].FindControl("btnRechazar").Visible = false;
                    e.Row.Cells[9].FindControl("btnAceptar").Visible = false;
                    e.Row.Cells[9].FindControl("btnEntregado").Visible = false;
                }
            }
        }

        protected void gvPedidos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            CTR_Pedido CTRPedido = new CTR_Pedido();
            if (e.CommandName == "EnviarP")
            {
                idPedido = Convert.ToInt32(gvPedidos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["idPedido"].ToString());
                idEstado= 2;
                CTRPedido.CTR_UpdateEstadoPedido(idPedido, idEstado);
            }
            if (e.CommandName == "AceptarP")
            {
                 idPedido = Convert.ToInt32(gvPedidos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["idPedido"].ToString());
                 idEstado = 3;
                CTRPedido.CTR_UpdateEstadoPedido(idPedido, idEstado);

            }
            if (e.CommandName == "RechazarP")
            {
                idPedido = Convert.ToInt32(gvPedidos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["idPedido"].ToString());
                idEstado = 4;
                CTRPedido.CTR_UpdateEstadoPedido(idPedido, idEstado);
            }
            if (e.CommandName == "EntregadoP")
            {
                 idPedido = Convert.ToInt32(gvPedidos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["idPedido"].ToString());
                 idEstado = 5;
                CTRPedido.CTR_UpdateEstadoPedido(idPedido, idEstado);
            }
           
            if (e.CommandName == "VerP")
            {
                DTO_Pedido objPedido = new DTO_Pedido();               
                objPedido.idPedido = Convert.ToInt32(gvPedidos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["idPedido"]);
                objPedido.razonSocial = gvPedidos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["razonSocial"].ToString();                
                objPedido.FechaEntrega = Convert.ToDateTime(gvPedidos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["FechaEntrega"].ToString());
                objPedido.MontoTotal = Convert.ToDecimal(gvPedidos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["MontoTotal"].ToString());
                objPedido.modoPago = gvPedidos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["modoPago"].ToString();
                objPedido.FechaEmision = Convert.ToDateTime(gvPedidos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["FechaEmision"].ToString());
                Session.Add("Pedido",objPedido);
                Response.Redirect("ConsultarPedido.aspx");
            }
            if (e.CommandName == "AnularP")
            {
                idPedido = Convert.ToInt32(gvPedidos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["idPedido"].ToString());
                
                CTRPedido.DeletePedido(idPedido);
               
            }
            if(e.CommandName  == "EditarP")
            {
                DTO_Pedido objPedido = new DTO_Pedido();
                objPedido.idPedido = Convert.ToInt32(gvPedidos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["idPedido"]);
                objPedido.razonSocial = gvPedidos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["razonSocial"].ToString();
                objPedido.FechaEntrega = Convert.ToDateTime(gvPedidos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["FechaEntrega"].ToString());
                objPedido.MontoTotal = Convert.ToDecimal(gvPedidos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["MontoTotal"].ToString());
                objPedido.modoPago = gvPedidos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["modoPago"].ToString();
                objPedido.FechaEmision = Convert.ToDateTime(gvPedidos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["FechaEmision"].ToString());               
                objPedido.idListaCompra = Convert.ToInt32(gvPedidos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["idListaCompra"].ToString());
                Session.Add("Pedido", objPedido);
                Response.Redirect("ActualizarPedido.aspx");
            }
            
           
            ListarPedido();
        }

        protected void btnVer_Click(object sender, EventArgs e)
        {

        }
    }
}