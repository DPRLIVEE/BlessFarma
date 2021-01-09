<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GestionarPedido.aspx.cs" Inherits="BlessFarma.Paginas.GestionarPedido.GestionarPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../Content/css/select2.min.css" rel="stylesheet" />
    <script src="../../Scripts/select2.min.js"></script>

    <h3 class="h3 mb-3 text-gray-800">Gestionar Pedido</h3>

    <asp:UpdatePanel runat="server" ID="UpdatePanelUsuario" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="card shadow mb-4">
                <a href="#filtercollapseCard" data-toggle="collapse" role="button" aria-expanded="true" aria-controls="collapseCardExample" class="d-flex card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary"><i class="<%--fas fa-filter--%>"></i>Filtros de busqueda:</h6>
                </a>
                <div class="collapse show" id="filtercollapseCard">
                    <div class="card-body">
                        <div class="row">

                            <div class="col-xl-3 col-lg-6 mb-3">
                                <label class="my-1 mr-2">Codigo de Pedido:</label>
                                <asp:TextBox runat="server" ID="tCodigo" CssClass="form-control" placeholder="Ingresar Codigo" MaxLength="40"></asp:TextBox>
                            </div>
                            <div class="col-xl-3 col-lg-6 mb-3">
                                <label class="my-1 mr-2">Encargado de Almacen:</label>
                                <asp:TextBox runat="server" ID="tNombre" CssClass="form-control" placeholder="Ingresar Nombre" MaxLength="40"></asp:TextBox>
                            </div>
                            <div class="col-xl-3 col-lg-6">
                            </div>
                            <div class="col-xl-3 col-lg-6">
                                <label class="my-1 mr-2">&nbsp;</label>
                                <asp:Button runat="server" ID="btnBuscar" CssClass="btn btn-primary form-control" OnClick="btnBuscar_Click" Text="Consultar Pedido" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="card shadow mb-4">
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:Panel ID="Panel1" runat="server" CssClass="auto-style1">
                            <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="False" Font-Size="Small" GridLines="None" HeaderStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Center"
                                AllowPaging="True" CssClass="table table-thead-style" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                EmptyDataText="No se encontro ninguna categoria." PageSize="15"
                                OnRowCommand="gvPedidos_RowCommand"
                                OnPageIndexChanging="gvPedidos_PageIndexChanging" OnRowDataBound="gvPedidos_RowDataBound">
                                <Columns>

                                    <asp:TemplateField Visible="false">
                                        <HeaderTemplate>Codigo</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="idPedido" runat="server" Text='<%#Bind("idPedido")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField Visible="false">
                                        <HeaderTemplate>id lista compra</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="idListaCompra" runat="server" Text='<%#Bind("idListaCompra")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>Codigo</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="idPedidoCorrelativo" runat="server" Text='<%#Bind("correlativo")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField>
                                        <HeaderTemplate>Encargado de Almacen</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="encargado" runat="server" Text='<%#Bind("NomUsuario")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>Proveedor</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="proveedor" runat="server" Text='<%#Bind("razonSocial")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField>
                                        <HeaderTemplate>Fecha de Emisión</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="fechaEmision" runat="server" Text='<%#Convert.ToDateTime(Eval("fechaEmision")).ToString("dd/MM/yyyy")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>Fecha de Entrega</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="fechaEntrega" runat="server" Text='<%#Convert.ToDateTime(Eval("fechaEntrega")).ToString("dd/MM/yyyy")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>Estado</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnidEstadoPedido" runat="server" Value='<%#Eval("idEstadoPedido")%>' />
                                            <asp:Label ID="NombreEstado" runat="server" Text='<%#Bind("NombreEstado")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>Ver</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton Text="text" ID="lnkVer" runat="server" ToolTip="Consultar" CommandName="Consultar" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'>
                                                            <i class="fas fa-eye fa-1x"></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>Editar</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton Text="text" ID="lnkEditar" runat="server" ToolTip="Editar" CommandName="Editar" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'>
                                                            <i class="fas fa-edit fa-1x"></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Acciones">
                                        <ItemTemplate>
                                            <div class="action-buttons">
                                                <asp:LinkButton runat="server" CssClass="btn btn-success" Text="Procesar" ID="btnProcesar" CommandName="Procesar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                                </asp:LinkButton>
                                                <asp:LinkButton runat="server" CssClass="btn btn-primary" Text="Aceptar" ID="btnAceptar" CommandName="Aceptar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                                </asp:LinkButton>
                                                <asp:LinkButton runat="server" CssClass="btn btn-danger" ID="btnRechazar" Text="Rechazar" CommandName="Rechazar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                                </asp:LinkButton>
                                                <asp:LinkButton runat="server" CssClass="btn btn-success" ID="btnEntregado" Text="Entregado" CommandName="Entregado" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                                </asp:LinkButton>
                                                <asp:LinkButton runat="server" CssClass="btn btn-danger" ID="btnAnulado" Text="Anulado" CommandName="Anulado" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
                                                </asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                            
                            <div class="col-xl-3 col-lg-6 d-flex ml-auto ">
                                <label class="my-1 mr-2">&nbsp;</label>
                                <asp:Button runat="server" ID="btnNuevoPedido" CssClass="btn btn-primary form-control" OnClick="btnSeleccionarLista_Click" Text="Agregar Nuevo Pedido" />
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
