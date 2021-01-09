using CTR;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace BlessFarma.Paginas.ListaCompras
{
    public partial class ListaCompras : Page
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

                    gvListaCompra.DataSource = list;
                    gvListaCompra.DataBind();
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(UpdatePanelUsuario, UpdatePanelUsuario.GetType(), "script", "verAlerta('No se pudo cargar las ordenes de compra.');", true);


            }
        }
        protected void btnAgregarLista_Click(object sender, EventArgs e)
        {

            Response.Redirect("AgregarLista.aspx");

        }


        protected void gvListaCompra_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListaCompra.PageIndex = e.NewPageIndex;
            CargarGrilla();
        }

        protected void gvListaCompra_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            switch (e.CommandName)
            {
                case "Consultar":

                    int index = int.Parse(e.CommandArgument.ToString());
                    int idListaCompra = int.Parse(((Label)gvListaCompra.Rows[index].FindControl("idListaCompra")).Text);
                    Session["idListaCompra"] = idListaCompra;
                    Response.Redirect("ConsultarLista.aspx");
                    break;

                case "Editar":

                    int indexE = int.Parse(e.CommandArgument.ToString());
                    int idListaCompraE = int.Parse(((Label)gvListaCompra.Rows[indexE].FindControl("idListaCompra")).Text);
                    Session["idListaCompra"] = idListaCompraE;
                    if (((Label)gvListaCompra.Rows[indexE].FindControl("NombreEstado")).Text == "Anulado")
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanelUsuario, UpdatePanelUsuario.GetType(), "Pop", mensajeConfirmacion("Error", "No se puede editar la lista se encuentra anulada.", "error"), true);
                        return;
                    }
                    if (((Label)gvListaCompra.Rows[indexE].FindControl("NombreEstado")).Text == "Ingresado")
                    {
                        ScriptManager.RegisterStartupScript(UpdatePanelUsuario, UpdatePanelUsuario.GetType(), "Pop", mensajeConfirmacion("Error", "No se puede editar la lista se encuentra ingresada.", "error"), true);
                        return;
                    }

                    Response.Redirect("ActualizarLista.aspx");
                    break;

                case "Anular":
                    int indexA = int.Parse(e.CommandArgument.ToString());
                    int idListaCompraA = int.Parse(((Label)gvListaCompra.Rows[indexA].FindControl("idListaCompra")).Text);
                    AnularLista(idListaCompraA);
                    break;

                case "Page":
                    return;
                default:
                    break;
            }

        }
        public void AnularLista(int idListaCompraA)
        {
            DtoListaCompra dtoListaCompra = new DtoListaCompra()
            {
                idListaCompra = idListaCompraA
            };

            DtoListaCompra dto = new CtrListaCompra().Usp_CancelListaCompra(dtoListaCompra);
            if (!dto.HuboError)
            {
                switch (dto.Msj)
                {
                    case "1":
                        ScriptManager.RegisterStartupScript(UpdatePanelUsuario, UpdatePanelUsuario.GetType(), "Pop", mensajeConfirmacion("Error", "La lista ya se encuentra anulada.", "error"), true);
                        break;
                    case "2":
                        ScriptManager.RegisterStartupScript(UpdatePanelUsuario, UpdatePanelUsuario.GetType(), "Pop", mensajeConfirmacion("Error", "No se puede anular una lista ya ingresada a un pedido.", "error"), true);
                        break;
                    case "3":
                        ScriptManager.RegisterStartupScript(UpdatePanelUsuario, UpdatePanelUsuario.GetType(), "Pop", mensajeConfirmacion("Exito", "Se elimino la lista correctamente.", "success"), true);
                        break;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(UpdatePanelUsuario, UpdatePanelUsuario.GetType(), "Pop", mensajeConfirmacion("Error!", "No se puede eliminar la Lista", "error"), true);
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