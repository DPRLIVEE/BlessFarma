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
                if (state == "En Espera")
                {
                    //Actualizar
                    e.Row.Cells[8].Controls.Clear();
                    //Eliminar
                    e.Row.Cells[7].Controls.Clear();

                }
                if (state == "Aceptado")
                {
                    //Enviar
                    e.Row.Cells[7].Controls.Clear();
                    //Eliminar
                    e.Row.Cells[7].Controls.Clear();
                    //Actualizar
                    e.Row.Cells[8].Controls.Clear();
                    //Registrar Movimiento 

                }
                if (state == "Rechazado")
                {
                    //Enviar
                    //e.Row.Cells[7].Controls.Clear();
                    //Actualizar
                    e.Row.Cells[8].Controls.Clear();
                }

            }

        }

        protected void gvPedidos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}