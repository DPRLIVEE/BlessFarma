using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using CTR;

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
                if (s == 5) estado = "Entregado";
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
                    e.Row.Cells[9].FindControl("btnRechazar").Visible = false;
                    e.Row.Cells[9].FindControl("btnAceptar").Visible = false;
                    e.Row.Cells[9].FindControl("btnEntregado").Visible = false;
                }

                if (state == "En Espera")
                {
                    //Actualizar
                    e.Row.Cells[8].Controls.Clear();
                    //Eliminar
                    e.Row.Cells[7].Controls.Clear();
                    e.Row.Cells[9].FindControl("btnEnviar").Visible = false;
                    e.Row.Cells[9].FindControl("btnEntregado").Visible = false;

                }
                if (state == "Aceptado")
                {
                    
                    e.Row.Cells[9].FindControl("btnEnviar").Visible = false;
                    e.Row.Cells[9].FindControl("btnRechazar").Visible = false;
                    e.Row.Cells[9].FindControl("btnAceptar").Visible = false;

                    //Eliminar
                    e.Row.Cells[7].Controls.Clear();
                    //Actualizar
                    e.Row.Cells[8].Controls.Clear();
                 
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

            if (e.CommandName == "EnviarP")
            {
                idPedido = Convert.ToInt32(gvPedidos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["idPedido"].ToString());
                idEstado= 2;  
            }
            if (e.CommandName == "AceptarP")
            {
                 idPedido = Convert.ToInt32(gvPedidos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["idPedido"].ToString());
                 idEstado = 3;

            }
            if (e.CommandName == "RechazarP")
            {
                idPedido = Convert.ToInt32(gvPedidos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["idPedido"].ToString());
                idEstado = 4;
              
            }
            if (e.CommandName == "EntregadoP")
            {
                 idPedido = Convert.ToInt32(gvPedidos.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["idPedido"].ToString());
                 idEstado = 5;
     
            }
            CTR_Pedido CTRPedido = new CTR_Pedido();
            CTRPedido.UpdatePedido(idEstado, idPedido);
            ListarPedido();
        }
    }
}