<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="SeleccionarLista.aspx.cs" Inherits="BlessFarma.Paginas.GestionarPedido.SeleccionarLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="../../Content/css/select2.min.css" rel="stylesheet" />
    <script src="../../Scripts/select2.min.js"></script>

    <h3 class="h3 mb-3 text-gray-800">Agregar Nuevo Pedido</h3>

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
                                <label class="my-1 mr-2">Codigo de Lista:</label>
                                <asp:TextBox runat="server" ID="tCodigo" CssClass="form-control" placeholder="Ingresar Codigo" MaxLength="40"></asp:TextBox>
                            </div>
                            <div class="col-xl-3 col-lg-6 mb-3">
                                <label class="my-1 mr-2">Quimico Farmaceutico:</label>
                                <asp:TextBox runat="server" ID="tQuimico" CssClass="form-control" placeholder="Ingresar Nombre" MaxLength="40"></asp:TextBox>
                            </div>
                            <div class="col-xl-3 col-lg-6 mb-3">
                            </div>
                            <div class="col-xl-3 col-lg-6">
                                <label class="my-1 mr-2">&nbsp;</label>
                                <asp:Button runat="server" ID="btnBuscar" CssClass="btn btn-primary form-control" OnClick ="btnBuscar_Click" Text="Consultar Lista" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="card shadow mb-4">
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:Panel ID="Panel1" runat="server" CssClass="auto-style1">
                            <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" Font-Size="Small" GridLines="None" HeaderStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Center"
                                AllowPaging="True" CssClass="table table-thead-style" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                EmptyDataText="No se encontro ninguna categoria." PageSize="15"
                                OnRowCommand="gvLista_RowCommand"
                                OnPageIndexChanging="gvLista_PageIndexChanging">
                                <Columns>

                                    <asp:TemplateField Visible="false">
                                        <HeaderTemplate>Codigo</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="idListaCompra" runat="server" Text='<%#Bind("idListaCompra")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>Codigo</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="idLista" runat="server" Text='<%#Bind("correlativo")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField>
                                        <HeaderTemplate>Quimico Farmaceutico</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="NomUsuario" runat="server" Text='<%#Bind("NomUsuario")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField>
                                        <HeaderTemplate>Fecha de Registro</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="fecha" runat="server" Text='<%#Convert.ToDateTime(Eval("fecha")).ToString("dd/MM/yyyy")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>Estado</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="NombreEstado" runat="server" Text='<%#Bind("NombreEstado")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>Seleccionar</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton Text="text" ID="lnkVer" runat="server" ToolTip="Consultar" CommandName="Seleccionar" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'>
                                                            <i class="fas fa-chevron-circle-right fa-lg"></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <div class="col-xl-3 col-lg-6 d-flex ml-auto ">
                                <label class="my-1 mr-2">&nbsp;</label>
                                <asp:Button runat="server" ID="btnCancelar" CssClass="btn btn-secondary form-control" OnClick="btnCancelar_Click" Text="Cancelar" />
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
