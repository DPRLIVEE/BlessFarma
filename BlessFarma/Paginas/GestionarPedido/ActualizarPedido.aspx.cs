using CTR;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Transactions;
using System.Drawing;

namespace BlessFarma.Paginas.GestionarPedido
{
    public partial class ActualizarPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tFechaEmision.Text = DateTime.Today.ToString("dd/MM/yyyy");
                Session.Remove("DetallePedido2");
                CargarMedioPago();
                CargarProveedor();
                CargarProducto();
                CargarPedido();
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                List<DtoPedido> list = Session["DetallePedido2"] is null ? new List<DtoPedido>() : (List<DtoPedido>)Session["DetallePedido2"];
                if (list.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "No hay Pedido." + "', 'error');", true);
                    return;
                }
                int idMetodoPago = int.Parse(ddlMedioPago.SelectedValue);
                int idProveedor = int.Parse(ddlProveedor.SelectedValue);
                DateTime FechaEntrega = DateTime.Parse(tFechaEntrega.Text);
                int idPedido = int.Parse(Session["idPedidoE"].ToString());
                decimal precioTotal = decimal.Parse(tPrecioTotal.Text);

                TransactionOptions transactionOptions = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted
                };
                using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                {
                    DtoPedido dtp = new DtoPedido()
                    {
                        idMetodoPago = idMetodoPago,
                        fechaEntrega = FechaEntrega,
                        idProveedor = idProveedor,
                        idPedido = idPedido,
                        idUsuario = ((DtoUsuario)Session["Correo"]).idUsuario,
                        precioTotal = precioTotal
                    };
                    dtp = new CtrPedido().Usp_UpdatePedido(dtp);
                    if (!dtp.HuboError)
                    {
                        IEnumerable<IGrouping<int, DtoPedido>> LCxPedido = list.GroupBy(x => x.idProducto);
                        foreach (IGrouping<int, DtoPedido> item in LCxPedido)
                        {
                            List<DtoPedido> listAux = list.Where(x => x.idProducto == item.Key).ToList();
                            DtoPedido dto = new DtoPedido()
                            {
                                idPedido = dtp.idPedido,
                                idProducto = listAux.Find(x => x.idProducto == item.Key).idProducto,
                                cantidad = listAux.Find(x => x.idProducto == item.Key).cantidad,
                                precioCompra = listAux.Find(x => x.idProducto == item.Key).precioCompra,
                            };
                            ClassResultV cr;
                            cr = new CtrPedido().Usp_InsertDetallePedido(dto);
                            if (!cr.HuboError)
                            {


                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "Hubo un error al actualizar el Pedido." + "', 'error');", true);

                                return;
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "Hubo un error al actualizar el Pedido." + "', 'error');", true);
                        return;
                    }


                    transaction.Complete();
                    ScriptManager.RegisterStartupScript(this, GetType(), "Pop", mensajeConfirmacion("Exito", "Se actualizo el Pedido correctamente.", "success"), true);

                }

            }
            catch (Exception z)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "Hubo un error al registrar el pedido." + "', 'error');", true);

            }
        }
        public string mensajeConfirmacion(string titulo, string mensaje, string tipo)
        {
            string script = @"swal({title: '" + titulo + "!',text: '" + mensaje + "', icon: '" + tipo + "', button: 'OK',})";
            script += ".then((willDelete) => { if (willDelete) { window.location = 'GestionarPedido.aspx'; } else { window.location = 'GestionarPedido.aspx'; }});";
            return script;
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {

            Response.Redirect("GestionarPedido.aspx");

        }

        protected void gvAgregarPedido_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvAgregarPedido_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "Quitar":
                        List<DtoPedido> list = Session["DetallePedido2"] is null ? new List<DtoPedido>() : (List<DtoPedido>)Session["DetallePedido2"];
                        int index = int.Parse(e.CommandArgument.ToString());
                        int IdProducto = int.Parse(((Label)gvAgregarPedido.Rows[index].FindControl("idProducto")).Text);

                        _ = list.RemoveAll(x => x.idProducto == IdProducto);
                        gvAgregarPedido.DataSource = list;
                        gvAgregarPedido.DataBind();

                        decimal montTotal = 0;
                        for (int i = 0; i < list.Count; i++)
                        {
                            montTotal += list[i].precioTotal;
                            tPrecioTotal.Text = montTotal.ToString();
                        }
                        if (list.Count < 1)
                        {
                            tPrecioTotal.Text = "0";
                        }

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
        public void CargarMedioPago()
        {
            try
            {
                ClassResultV cr = new CtrPedido().Usp_GetAllMetodoPago();
                if (!cr.HuboError)
                {
                    List<DtoMetodoPago> list = cr.List.Cast<DtoMetodoPago>().ToList();
                    ddlMedioPago.DataSource = list;
                    ddlMedioPago.DataTextField = "metodoPago";
                    ddlMedioPago.DataValueField = "idMetodoPago";
                    ddlMedioPago.DataBind();
                    ddlMedioPago.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "No se pudo cargar los metodos de pago." + "', 'error');", true);
            }
        }
        public void CargarProveedor()
        {
            try
            {
                ClassResultV cr = new CtrPedido().Usp_GetAllProveedores();
                if (!cr.HuboError)
                {
                    List<DtoProveedor> list = cr.List.Cast<DtoProveedor>().ToList();
                    ddlProveedor.DataSource = list;
                    ddlProveedor.DataTextField = "razonSocial";
                    ddlProveedor.DataValueField = "idProveedor";
                    ddlProveedor.DataBind();
                    ddlProveedor.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "No se pudo cargar los proveedores." + "', 'error');", true);
            }
        }
        public void CargarProducto()
        {
            try
            {
                DtoListaCompraSeleccionado dtoPedido = new DtoListaCompraSeleccionado()
                {
                    Criterio = Session["idListaCompra"].ToString()

                };
                ClassResultV cr = new CtrPedido().Usp_GetListaCompraSeleccionada(dtoPedido);
                if (!cr.HuboError)
                {
                    List<DtoListaCompraSeleccionado> list = cr.List.Cast<DtoListaCompraSeleccionado>().ToList();
                    ddlProducto.DataSource = Session["ProductoPedido2"] = list;
                    ddlProducto.DataTextField = "nombreProducto";
                    ddlProducto.DataValueField = "idProducto";
                    ddlProducto.DataBind();
                    ddlProducto.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "No se pudo cargar los pedidos." + "', 'error');", true);
            }
        }

        public void CargarPedido()
        {
            try
            {
                DtoPedido dtoPedido = new DtoPedido()
                {
                    Criterio = Session["idPedidoE"].ToString()

                };
                ClassResultV cr = new CtrPedido().Usp_GetCargarPedido(dtoPedido);
                if (!cr.HuboError)
                {
                    List<DtoPedido> list = cr.List.Cast<DtoPedido>().ToList();

                    tFechaEmision.Text = list[0].fechaEmision.ToString("dd/MM/yyyy");
                    DateTime dtime = Convert.ToDateTime(list[0].fechaEntrega.ToString());
                    tFechaEntrega.Text = String.Format("{0:yyyy-MM-dd}", dtime);
                    ddlMedioPago.Items.FindByText(list[0].metodoPago).Selected = true;
                    ddlProveedor.Items.FindByText(list[0].razonSocial).Selected = true;

                    gvAgregarPedido.DataSource = Session["DetallePedido2"] = list;
                    gvAgregarPedido.DataBind();

                    decimal montTotal = 0;
                    for (int i = 0; i < list.Count; i++)
                    {
                        montTotal += list[i].precioTotal;
                        tPrecioTotal.Text = montTotal.ToString();
                    }
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "No se pudo cargar los pedidos." + "', 'error');", true);
            }
        }

        protected void ddlProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlProducto.SelectedValue == "0")
                {
                    tFormato.Text = "";
                    tLaboratorio.Text = "";
                    tPrecio.Text = "";
                    return;
                }
                List<DtoListaCompraSeleccionado> list = (List<DtoListaCompraSeleccionado>)Session["ProductoPedido2"];

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].idProducto == int.Parse(ddlProducto.SelectedValue))
                    {
                        tFormato.Text = list[i].formato.ToString();
                        tLaboratorio.Text = list[i].nombreLaboratorio.ToString();
                        tPrecio.Text = list[i].precioCompra.ToString();
                    }
                }

                //tFormato.Text = list.Find(x => x.idProducto == int.Parse(ddlProducto.SelectedValue)).formato.ToString();
                //tLaboratorio.Text = list.Find(x => x.idProducto == int.Parse(ddlProducto.SelectedValue)).nombreLaboratorio.ToString();
                //tPrecio.Text = list.Find(x => x.idProducto == int.Parse(ddlProducto.SelectedValue)).precioCompra.ToString();
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

                if (int.Parse(tCantidad.Text) <= 0)
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "No se puede ingresar un producto de 0 cantidades." + "', 'error');", true);
                    return;
                }

                List<DtoPedido> list = Session["DetallePedido2"] is null ? new List<DtoPedido>() : (List<DtoPedido>)Session["DetallePedido2"];

                int idProducto = int.Parse(ddlProducto.SelectedValue);
                string nomProducto = ddlProducto.Items[ddlProducto.SelectedIndex].Text;
                int cantidad = int.Parse(tCantidad.Text);
                string formato = tFormato.Text;
                string nomLaboratorio = tLaboratorio.Text;
                Decimal precioUnitario = Decimal.Parse(tPrecio.Text);
                Decimal precioTotal = precioUnitario * cantidad;


                if (list.Exists(x => x.idProducto == idProducto))
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "Ya existe el producto indicado." + "', 'error');", true);
                    return;
                }

                DtoPedido dtoPedido = new DtoPedido()
                {
                    nombreProducto = nomProducto,
                    cantidad = cantidad,
                    formato = formato,
                    nombreLaboratorio = nomLaboratorio,
                    precioCompra = precioUnitario,
                    idProducto = idProducto,
                    precioTotal = precioTotal
                };
                list.Add(dtoPedido);
                gvAgregarPedido.DataSource = Session["DetallePedido2"] = list;
                gvAgregarPedido.DataBind();

                decimal montTotal = 0;
                for (int i = 0; i < list.Count; i++)
                {
                    montTotal += list[i].precioTotal;
                    tPrecioTotal.Text = montTotal.ToString();
                }
            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "Hubo un error al ingresar el producto" + "', 'error');", true);
            }
        }
    }
}
