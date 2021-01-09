using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using DTO;

namespace BlessFarma.Paginas.GestionarPedido
{
    public partial class SeleccionarLista : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                CargarGrilla();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        public void CargarGrilla()
        {
            try
            {
                DtoListaCompra dtoListaCompra = new DtoListaCompra()
                {
                    Criterio = tCodigo.Text,
                    NomUsuario = tQuimico.Text

                };
                ClassResultV cr = new CtrListaCompra().Usp_GetAllListaCompra(dtoListaCompra);
                if (!cr.HuboError)
                {
                    List<DtoListaCompra> list = cr.List.Cast<DtoListaCompra>().ToList();

                    gvLista.DataSource = list;
                    gvLista.DataBind();
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(UpdatePanelUsuario, UpdatePanelUsuario.GetType(), "script", "verAlerta('No se pudo cargar las ordenes de compra.');", true);


            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionarPedido.aspx");
        }



        protected void gvLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLista.PageIndex = e.NewPageIndex;
            CargarGrilla();
        }

        protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            switch (e.CommandName)
            {
                case "Seleccionar":

                    int index = int.Parse(e.CommandArgument.ToString());
                    int idListaCompra = int.Parse(((Label)gvLista.Rows[index].FindControl("idListaCompra")).Text);

                    string estado = ((Label)gvLista.Rows[index].FindControl("NombreEstado")).Text;
                    if (estado == "Anulado" || estado == "Ingresado" )
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "No se puede seleccionar." + "', 'error');", true);
                        return;
                    }

                    Session["idListaCompra"] = idListaCompra;
                    Response.Redirect("AgregarPedido.aspx");
                    break;

                case "Page":
                    return;
                default:
                    break;
            }

        }
        
        public string mensajeConfirmacion(string titulo, string mensaje, string tipo)
        {
            string script = @"swal({title: '" + titulo + "!',text: '" + mensaje + "', icon: '" + tipo + "', button: 'OK',})";
            CargarGrilla();
            return script;
        }
    }
}