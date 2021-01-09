using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;


namespace BlessFarma.Paginas.ListaCompras
{
    public partial class ActualizarLista : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrilla();

                //CargarProductos();
            }
        }

        public void CargarGrilla()
        {
            try
            {
                DtoProdListaCompra dtoProdListaCompra = new DtoProdListaCompra()
                {
                    Criterio = Session["idListaCompra"].ToString()

                };
                ClassResultV cr = new CtrListaCompra().Usp_GetProdListaCompra(dtoProdListaCompra);
                if (!cr.HuboError)
                {
                    DtoProdListaCompra val = new DtoProdListaCompra();

                    List<DtoProdListaCompra> list = cr.List.Cast<DtoProdListaCompra>().ToList();
                    tCodListaCompraCorrelativo.Text = list[0].idListaCorrelativo;
                    tCodListaCompra.Text = list[0].idListaCompra.ToString();
                    tFecha.Text = list[0].fecha.ToString("dd/MM/yyyy");

                    gvActualizarLista.DataSource = Session["DetalleProducto"] = list;
                    gvActualizarLista.DataBind();
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "No se pudo cargar los productos de la lista." + "', 'error');", true);
            }
        }
        protected void gvActualizarLista_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvActualizarLista_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvActualizarLista.EditIndex = e.NewEditIndex;
            CargarGrilla();

        }

        protected void gvActualizarLista_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvActualizarLista.EditIndex = -1;
            CargarGrilla();

        }

        protected void gvActualizarLista_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit)))
            {
                ((LinkButton)e.Row.FindControl("lnkUpdate")).Attributes.Clear();

                DropDownList ddl1 = (DropDownList)e.Row.FindControl("ddlProductoEdit");
                CargarProductos(ddl1);
                string nom1 = ((HiddenField)e.Row.FindControl("hdnProducto")).Value;
                ddl1.Items.FindByText(nom1).Selected = true;


            }
        }

        public void CargarProductos(DropDownList ddlProducto)
        {
            try
            {
                ClassResultV cr = new CtrProducto().Usp_GetAllProductos();
                if (!cr.HuboError)
                {
                    List<DtoProducto> list = cr.List.Cast<DtoProducto>().ToList();
                    ddlProducto.DataSource = Session["Producto"] = list;
                    ddlProducto.DataTextField = "nombreProducto";
                    ddlProducto.DataValueField = "idProducto";
                    ddlProducto.DataBind();
                    ddlProducto.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
                }
            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "verAlerta('No se pudo cargar los productos.');" + "', 'error');", true);
            }
        }

        protected void gvActualizarLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Update":

                    UpdateProducto(gvActualizarLista);
                    gvActualizarLista.SetEditRow(-1);
                    CargarGrilla();
                    break;
            }
        }

        private void UpdateProducto(GridView grid)
        {
            string nombreproducto = ((DropDownList)grid.Rows[grid.EditIndex].FindControl("ddlProductoEdit")).SelectedValue;
            string nomProducto = ((DropDownList)grid.Rows[grid.EditIndex].FindControl("ddlProductoEdit")).SelectedItem.Text;
            string idCodigo = ((Label)grid.Rows[grid.EditIndex].FindControl("lblCodigoEdit")).Text;

            try
            {
                if (nombreproducto == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "Elija un producto para guardar." + "', 'error');", true);
                }

                List<DtoProdListaCompra> list = Session["DetalleProducto"] is null ? new List<DtoProdListaCompra>() : (List<DtoProdListaCompra>)Session["DetalleProducto"];

                if (list.Exists(x => x.nombreProducto == nomProducto))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "Ya existe el producto indicado." + "', 'error');", true);
                    return;
                }
                else
                {
                    DtoProducto dtoProdListaCompra = new DtoProducto()
                    {
                        idProducto = Convert.ToInt32(nombreproducto),
                        idListaCompra = Convert.ToInt32(tCodListaCompra.Text),
                        idCodigo = Convert.ToInt32(idCodigo)
                    };

                    ClassResultV cr = new CtrListaCompra().Usp_UpdateProdListaCompra(dtoProdListaCompra);
                    if (!cr.HuboError)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Exito!', '" + "Se actualizo correctamente!" + "', 'success');", true);
                        return;
                    }
                }
            }

            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "Error al actualizar el Producto." + "', 'error');", true);
                return;
            }
        }

        protected void gvActualizarLista_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }
        protected void ddlProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.Parent.Parent;
            int rowIndex = row.RowIndex;

            TextBox tNombreLab = (TextBox)row.Cells[1].FindControl("tNombreLaboratorio");
            DropDownList ddlProductoEdit = (DropDownList)row.Cells[0].FindControl("ddlProductoEdit");

            try
            {
                if (ddlProductoEdit.SelectedValue == "0")
                {
                    tNombreLab.Text = "";
                    return;
                }
                List<DtoProducto> list = (List<DtoProducto>)Session["Producto"];
                tNombreLab.Text = list.Find(x => x.idProducto == int.Parse(ddlProductoEdit.SelectedValue)).nombreLaboratorio;

            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {

            Response.Redirect("ListaCompras.aspx");

        }
    }

}