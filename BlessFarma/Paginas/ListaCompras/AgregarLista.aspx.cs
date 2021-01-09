using CTR;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;
using System.Drawing;


namespace BlessFarma.Paginas
{
    public partial class AgregarLista : Page
    {
        ClassResultV cr1 = new CtrProducto().Usp_GetAllProductos();
         
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Remove("DetalleP");
                CargarProductos();

            }
        }

        public void CargarProductos()
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

        protected void ddlProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlProducto.SelectedValue == "0")
                {
                    tLaboratorio.Text = "";
                    return;
                }
                List<DtoProducto> list = (List<DtoProducto>)Session["Producto"];
                tLaboratorio.Text = list.Find(x => x.idProducto == int.Parse(ddlProducto.SelectedValue)).nombreLaboratorio;

            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlProducto.SelectedValue == "0")
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "Debe seleccionar un producto." + "', 'error');", true);
                    return;
                }

                List<DtoProducto> list = Session["DetalleP"] is null ? new List<DtoProducto>() : (List<DtoProducto>)Session["DetalleP"];
                int idProducto = int.Parse(ddlProducto.SelectedValue);
                string nomProducto = ddlProducto.Items[ddlProducto.SelectedIndex].Text;
                string nomLaboratorio = tLaboratorio.Text;

                if (list.Exists(x => x.idProducto == idProducto))
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "Ya existe el producto indicado." + "', 'error');", true);
                    return;
                }

                DtoProducto dtoP = new DtoProducto()
                {
                    nombreProducto = nomProducto,
                    nombreLaboratorio = nomLaboratorio,
                    idProducto = idProducto
                };
                list.Add(dtoP);
                gvProducto.DataSource = Session["DetalleP"] = list;
                gvProducto.DataBind();

            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "Hubo un error al ingresar el producto" + "', 'error');", true);
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                List<DtoProducto> list = Session["DetalleP"] is null ? new List<DtoProducto>() : (List<DtoProducto>)Session["DetalleP"];
                if (list.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "No hay productos ingresados." + "', 'error');", true);
                    return;
                }
                TransactionOptions transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted
                };
                using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                {
                    DtoProducto dtp = new DtoProducto()
                    {
                        estado = "1",
                        fecha = DateTime.Now,
                        idUsuario = ((DtoUsuario)Session["Correo"]).idUsuario
                    };
                    dtp = new CtrListaCompra().Usp_InsertListaCompra(dtp);
                    if (!dtp.HuboError)
                    {
                        IEnumerable<IGrouping<int, DtoProducto>> LCxProducto = list.GroupBy(x => x.idProducto);
                        foreach (IGrouping<int, DtoProducto> item in LCxProducto)
                        {
                            List<DtoProducto> listAux = list.Where(x => x.idProducto == item.Key).ToList();
                            DtoProducto dto = new DtoProducto()
                            {
                                idListaCompra = dtp.idListaCompra,
                                idProducto = listAux.Find(x => x.idProducto == item.Key).idProducto,
                            };
                            ClassResultV cr;
                            cr = new CtrListaCompra().Usp_InsertDetalleLista(dto);
                            if (!cr.HuboError)
                            {
                               
                                
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "Hubo un error al registrar las ordenes." + "', 'error');", true);

                                return;
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "Hubo un error al registrar las ordenes." + "', 'error');", true);
                        return;
                    }

                    
                    transaction.Complete();
                    LimpiarDetalle();
                    ScriptManager.RegisterStartupScript(this, GetType(), "Pop",  mensajeConfirmacion("Exito", "Se registro la lista de compra correctamente.", "success"), true);
                    
                }
                
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "Hubo un error al registrar las ordenes." + "', 'error');", true);

            }
        }

        public string mensajeConfirmacion(string titulo, string mensaje, string tipo)
        {
            string script = @"swal({title: '" + titulo + "!',text: '" + mensaje + "', icon: '" + tipo + "', button: 'OK',})";
            script += ".then((willDelete) => { if (willDelete) { window.location = 'ListaCompras.aspx'; } else { window.location = 'ListaCompras.aspx'; }});";
            return script;
        }

        protected void gvProducto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvProducto_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvProducto_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void gvProducto_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvProducto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "Quitar":
                        List<DtoProducto> list = Session["DetalleP"] is null ? new List<DtoProducto>() : (List<DtoProducto>)Session["DetalleP"];
                        int index = int.Parse(e.CommandArgument.ToString());
                        int IdProducto = int.Parse(((Label)gvProducto.Rows[index].FindControl("lblCodProducto")).Text);

                        _ = list.RemoveAll(x => x.idProducto == IdProducto);
                        gvProducto.DataSource = list;
                        gvProducto.DataBind();
                        break;

                    default:
                        break;
                }

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "Hubo un error al realizar la acción." + "', 'error');", true);

            }
        }

        protected void gvProducto_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }



        private void InsertCategoria(GridView grid)
        {

        }

        private void UpdateCategoria(GridView grid)
        {


        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

            Response.Redirect("ListaCompras.aspx");

        }

        protected void LimpiarDetalle()
        {
            Session.Remove("DetalleP");
            gvProducto.DataSource = Session["DetalleP"];
            gvProducto.DataBind();
        }


    }
}