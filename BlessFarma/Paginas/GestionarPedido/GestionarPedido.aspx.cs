using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using DTO;
using System.Net;
using System.Net.Mail;

namespace BlessFarma.Paginas.GestionarPedido
{
    public partial class GestionarPedido : Page
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

        protected void btnSeleccionarLista_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeleccionarLista.aspx");
        }
        public void CargarGrilla()
        {
            try
            {
                DtoPedido dtoPedido = new DtoPedido()
                {
                    Criterio = tCodigo.Text,
                    NomUsuario = tNombre.Text
                };
                ClassResultV cr = new CtrPedido().Usp_GetAllPedido(dtoPedido);
                if (!cr.HuboError)
                {
                    List<DtoPedido> list = cr.List.Cast<DtoPedido>().ToList();

                    gvPedidos.DataSource = list;
                    gvPedidos.DataBind();
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(UpdatePanelUsuario, UpdatePanelUsuario.GetType(), "script", "verAlerta('No se pudo cargar las ordenes de compra.');", true);


            }
        }

        protected void gvPedidos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPedidos.PageIndex = e.NewPageIndex;
            CargarGrilla();

        }

        protected void gvPedidos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idEstadoPedido = 0;
            string idPedid;
            switch (e.CommandName)
            {
                case "Consultar":

                    int index = int.Parse(e.CommandArgument.ToString());
                    int idPedido = int.Parse(((Label)gvPedidos.Rows[index].FindControl("idPedido")).Text);
                    Session["idPedido"] = idPedido;
                    Response.Redirect("ConsultarPedido.aspx");
                    break;

                case "Editar":

                    int indexE = int.Parse(e.CommandArgument.ToString());
                    int idPedidoE = int.Parse(((Label)gvPedidos.Rows[indexE].FindControl("idPedido")).Text);
                    int idListaCompra = int.Parse(((Label)gvPedidos.Rows[indexE].FindControl("idListaCompra")).Text);


                    switch (((Label)gvPedidos.Rows[indexE].FindControl("NombreEstado")).Text)
                    {
                        case "En Espera":
                            ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "No se puede editar un Pedido en espera." + "', 'error');", true);
                            return;
                            
                        case "Aceptado":
                            ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "No se puede editar un Pedido aceptado." + "', 'error');", true);
                            return;
                            
                        case "Rechazado":
                            ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "No se puede editar un Pedido rechazado." + "', 'error');", true);
                            return;
                        case "Entregado":
                            ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "Hubo un error al Procesar el pedido." + "', 'error');", true);
                            return;
                        case "Anulado":
                            ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "No se puede editar un Pedido anulado." + "', 'error');", true);
                            return;

                        default:
                            break;
                    }


                    Session["idPedidoE"] = idPedidoE;
                    Session["idListaCompra"] = idListaCompra;
                    Response.Redirect("ActualizarPedido.aspx");
                    break;

                case "Procesar":
                    int index1 = int.Parse(e.CommandArgument.ToString());
                    idPedid = ((Label)gvPedidos.Rows[index1].FindControl("idPedido")).Text;
                    DtoPedido dto = new DtoPedido()
                    {
                        idPedido = int.Parse(idPedid),
                        idTipo = 2
                    };

                    ClassResultV cr = new CtrPedido().Usp_UpdateProcesar(dto);
                    if (!cr.HuboError)
                    {
                        List<DtoPedido> list = cr.List.Cast<DtoPedido>().ToList();
                        string subject = "Envio de Pedido Numero - " + idPedid;
                        var DocumentHtml = list[0].httpPedido;
                        var fromAddress = "blessfarma20@gmail.com";
                        var toAddress = "edsonjeanpier98@gmail.com";
                        const string fromPassword = "helenitadx3";
                        var smtp = new SmtpClient
                        {
                            Host = "smtp.gmail.com",
                            Port = 587,
                            EnableSsl = true,
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            UseDefaultCredentials = false,
                            Credentials = new NetworkCredential(fromAddress, fromPassword)
                        };
                        MailMessage message = new MailMessage(fromAddress, toAddress);
                        message.Subject = subject;
                        message.Body = DocumentHtml;
                        message.IsBodyHtml = true;
                        smtp.Send(message);

                        ScriptManager.RegisterStartupScript(this, GetType(), "Pop", mensajeConfirmacion("Exito", "Se Proceso correctamente.", "success"), true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "Hubo un error al Procesar el pedido." + "', 'error');", true);
                    }
                    break;


                case "Page":
                    return;
                case "Aceptar":
                    int index2 = int.Parse(e.CommandArgument.ToString());
                    idEstadoPedido = int.Parse(((HiddenField)gvPedidos.Rows[index2].FindControl("hdnidEstadoPedido")).Value);
                    idPedid = ((Label)gvPedidos.Rows[index2].FindControl("idPedido")).Text;
                    DtoPedido dto2 = new DtoPedido()
                    {
                        idPedido = int.Parse(idPedid),
                        idTipo = 3
                    };

                    ClassResultV cr2 = new CtrPedido().Usp_UpdateProcesar(dto2);
                    if (!cr2.HuboError)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Pop", mensajeConfirmacion("Exito", "Se Acepto correctamente.", "success"), true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "Hubo un error al Acepto el pedido." + "', 'error');", true);
                    }
                    break;


                case "Rechazar":
                    int index3 = int.Parse(e.CommandArgument.ToString());
                    idEstadoPedido = int.Parse(((HiddenField)gvPedidos.Rows[index3].FindControl("hdnidEstadoPedido")).Value);
                    idPedid = ((Label)gvPedidos.Rows[index3].FindControl("idPedido")).Text;
                    DtoPedido dto3 = new DtoPedido()
                    {
                        idPedido = int.Parse(idPedid),
                        idTipo = 4
                    };

                    ClassResultV cr3 = new CtrPedido().Usp_UpdateProcesar(dto3);
                    if (!cr3.HuboError)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Pop", mensajeConfirmacion("Exito", "Se Rechazo correctamente.", "success"), true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "Hubo un error al Rechazar el pedido." + "', 'error');", true);
                    }
                    break;
                case "Entregado":
                    int index5 = int.Parse(e.CommandArgument.ToString());
                    idEstadoPedido = int.Parse(((HiddenField)gvPedidos.Rows[index5].FindControl("hdnidEstadoPedido")).Value);
                    idPedid = ((Label)gvPedidos.Rows[index5].FindControl("idPedido")).Text;
                    DtoPedido dto5 = new DtoPedido()
                    {
                        idPedido = int.Parse(idPedid),
                        idTipo = 5
                    };

                    ClassResultV cr5 = new CtrPedido().Usp_UpdateProcesar(dto5);
                    if (!cr5.HuboError)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Pop", mensajeConfirmacion("Exito", "Se Entrego correctamente.", "success"), true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "Hubo un error al Entregar el pedido." + "', 'error');", true);
                    }
                    break;
                case "Anulado":
                    int index4 = int.Parse(e.CommandArgument.ToString());
                    idEstadoPedido = int.Parse(((HiddenField)gvPedidos.Rows[index4].FindControl("hdnidEstadoPedido")).Value);
                    idPedid = ((Label)gvPedidos.Rows[index4].FindControl("idPedido")).Text;
                    DtoPedido dto4 = new DtoPedido()
                    {
                        idPedido = int.Parse(idPedid),
                        idTipo = 6
                    };

                    ClassResultV cr4 = new CtrPedido().Usp_UpdateProcesar(dto4);
                    if (!cr4.HuboError)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Pop", mensajeConfirmacion("Exito", "Se Anulo correctamente.", "success"), true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Pop", @"swal('Error!', '" + "Hubo un error al Anular el pedido." + "', 'error');", true);
                    }
                    break;

                default:
                    break;
            }
        }

        public string mensajeConfirmacion(string titulo, string mensaje, string tipo)
        {
            string script = @"swal({title: '" + titulo + "!',text: '" + mensaje + "', icon: '" + tipo + "', button: 'OK',})";
            script += ".then((willDelete) => { if (willDelete) { window.location = 'GestionarPedido.aspx'; } else { window.location = 'GestionarPedido.aspx'; }});";
            return script;
        }
        protected void gvPedidos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DtoPedido dto = (DtoPedido)e.Row.DataItem;

                if (dto.idEstadoPedido == 1)
                {
                    ((LinkButton)e.Row.FindControl("btnProcesar")).Visible = true;
                    ((LinkButton)e.Row.FindControl("btnAceptar")).Visible = false;
                    ((LinkButton)e.Row.FindControl("btnRechazar")).Visible = false;
                    ((LinkButton)e.Row.FindControl("btnEntregado")).Visible = false;
                    ((LinkButton)e.Row.FindControl("btnAnulado")).Visible = false;
                }
                if (dto.idEstadoPedido == 2)
                {
                    ((LinkButton)e.Row.FindControl("btnProcesar")).Visible = false;
                    ((LinkButton)e.Row.FindControl("btnAceptar")).Visible = true;
                    ((LinkButton)e.Row.FindControl("btnRechazar")).Visible = true;
                    ((LinkButton)e.Row.FindControl("btnEntregado")).Visible = false;
                    ((LinkButton)e.Row.FindControl("btnAnulado")).Visible = false;
                }
                if (dto.idEstadoPedido == 3)
                {
                    ((LinkButton)e.Row.FindControl("btnProcesar")).Visible = false;
                    ((LinkButton)e.Row.FindControl("btnAceptar")).Visible = false;
                    ((LinkButton)e.Row.FindControl("btnRechazar")).Visible = false;
                    ((LinkButton)e.Row.FindControl("btnEntregado")).Visible = true;
                    ((LinkButton)e.Row.FindControl("btnAnulado")).Visible = true;
                }
                if (dto.idEstadoPedido == 4)
                {
                    ((LinkButton)e.Row.FindControl("btnProcesar")).Visible = false;
                    ((LinkButton)e.Row.FindControl("btnAceptar")).Visible = false;
                    ((LinkButton)e.Row.FindControl("btnRechazar")).Visible = false;
                    ((LinkButton)e.Row.FindControl("btnEntregado")).Visible = false;
                    ((LinkButton)e.Row.FindControl("btnAnulado")).Visible = false;
                }
                if (dto.idEstadoPedido == 5)
                {
                    ((LinkButton)e.Row.FindControl("btnProcesar")).Visible = false;
                    ((LinkButton)e.Row.FindControl("btnEntregado")).Visible = false;
                    ((LinkButton)e.Row.FindControl("btnAceptar")).Visible = false;
                    ((LinkButton)e.Row.FindControl("btnRechazar")).Visible = false;
                    ((LinkButton)e.Row.FindControl("btnAnulado")).Visible = false;
                }

                if (dto.idEstadoPedido == 6)
                {
                    ((LinkButton)e.Row.FindControl("btnProcesar")).Visible = false;
                    ((LinkButton)e.Row.FindControl("btnEntregado")).Visible = false;
                    ((LinkButton)e.Row.FindControl("btnAceptar")).Visible = false;
                    ((LinkButton)e.Row.FindControl("btnRechazar")).Visible = false;
                    ((LinkButton)e.Row.FindControl("btnAnulado")).Visible = false;
                }



                //((LinkButton)e.Row.FindControl("btnEC")).Visible = dto.idEstadoPedido == 1 || dto.idEstadoPedido == 2;
            }
        }
    }
}