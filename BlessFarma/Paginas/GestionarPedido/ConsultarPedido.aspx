<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ConsultarPedido.aspx.cs" Inherits="BlessFarma.Paginas.GestionarPedido.ConsultarPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../Content/css/select2.min.css" rel="stylesheet" />
    <script src="../../Scripts/select2.min.js"></script>

    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <h3 class="h3 mb-3 text-gray-800">Consultar Pedido</h3>

            <div class="card shadow mb-4">
                <a href="#filtercollapseCard" data-toggle="collapse" role="button" aria-expanded="true" aria-controls="collapseCardExample" class="d-flex card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary"><i class="<%--fas fa-filter--%>"></i>Datos del Pedido:</h6>
                </a>
                <div class="collapse show" id="filtercollapseCard">
                    <div class="card-body">

                        <div class="row align-items-end">

                            <div class="col-xl-4 col-lg-6 mb-3">
                            </div>
                            <div class="col-xl-2 col-lg-6 mb-3">
                                <label class="my-1 mr-2">Código de Pedido:</label>
                            </div>
                            <div class="col-xl-4 col-lg-6 mb-3">
                                <asp:Label runat="server" ID="tCodigoPedido" MaxLength="40"></asp:Label>
                            </div>


                            <div class="col-xl-4 col-lg-6 mb-3">
                            </div>
                            <div class="col-xl-2 col-lg-6 mb-3">
                                <label class="my-1 mr-2">Estado:</label>
                            </div>
                            <div class="col-xl-4 col-lg-6 mb-3">
                                <asp:Label runat="server" ID="tEstado" MaxLength="40"></asp:Label>
                            </div>


                            <div class="col-xl-4 col-lg-6 mb-3">
                            </div>
                            <div class="col-xl-2 col-lg-6 mb-3">
                                <label class="my-1 mr-2">Fecha de Emisión:</label>
                            </div>
                            <div class="col-xl-4 col-lg-6 mb-3">
                                <asp:Label runat="server" ID="tFechaEmision" MaxLength="40"></asp:Label>
                            </div>


                            <div class="col-xl-4 col-lg-6 mb-3">
                            </div>
                            <div class="col-xl-2 col-lg-6 mb-3">
                                <label class="my-1 mr-2">Fecha de Entrega:</label>
                            </div>
                            <div class="col-xl-4 col-lg-6 mb-3">
                                <asp:Label runat="server" ID="tFechaEntrega" MaxLength="40"></asp:Label>
                            </div>


                            <div class="col-xl-4 col-lg-6 mb-3">
                            </div>
                            <div class="col-xl-2 col-lg-6 mb-3">
                                <label class="my-1 mr-2">Medio de Pago:</label>
                            </div>
                            <div class="col-xl-4 col-lg-6 mb-3">
                                <asp:Label runat="server" ID="tMedioPago" MaxLength="40"></asp:Label>
                            </div>


                            <div class="col-xl-4 col-lg-6 mb-3">
                            </div>
                            <div class="col-xl-2 col-lg-6 mb-3">
                                <label class="my-1 mr-2">Proveedor:</label>
                            </div>
                            <div class="col-xl-4 col-lg-6 mb-3">
                                <asp:Label runat="server" ID="tProveedor" MaxLength="40"></asp:Label>
                            </div>


                        </div>
                    </div>
                </div>
            </div>

            <div class="card shadow mb-4">
                <a href="#filtercollapseCard1" data-toggle="collapse" role="button" aria-expanded="true" aria-controls="collapseCardExample" class="d-flex card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary"><i class="<%--fas fa-filter--%>"></i>Detalle del Pedido:</h6>
                </a>
                <div class="collapse show" id="filtercollapseCard1">
                    <div class="card-body">

                        <div class="table-responsive">

                            <asp:GridView ID="gvCPedido" runat="server" AutoGenerateColumns="False" Font-Size="Small" GridLines="None" HeaderStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Center"
                                AllowPaging="True" CssClass="table table-thead-style" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                EmptyDataText="No se encontro ningun producto." PageSize="15"
                                OnRowCommand="gvCPedido_RowCommand"
                                OnRowEditing="gvCPedido_RowEditing"
                                OnRowCancelingEdit="gvCPedido_RowCancelingEdit"
                                OnRowDataBound="gvCPedido_RowDataBound"
                                OnRowUpdating="gvCPedido_RowUpdating"
                                OnPageIndexChanging="gvCPedido_PageIndexChanging"
                                ShowFooter="false">
                                <Columns>

                                    <asp:TemplateField>

                                        <HeaderTemplate>Nombre del Producto</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="nombreProducto" runat="server" Text='<%#Bind("nombreProducto")%>' />
                                        </ItemTemplate>

                                    </asp:TemplateField>

                                    <asp:TemplateField>

                                        <HeaderTemplate>Cantidad</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="cantidad" runat="server" Text='<%#Bind("cantidad")%>' />
                                        </ItemTemplate>

                                    </asp:TemplateField>

                                    <asp:TemplateField>

                                        <HeaderTemplate>Formato</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="formato" runat="server" Text='<%#Bind("formato")%>' />
                                        </ItemTemplate>

                                    </asp:TemplateField>

                                    <asp:TemplateField>

                                        <HeaderTemplate>Precio U.</HeaderTemplate>
                                        <ItemTemplate>
                                            S/. <asp:Label ID="precioCompra" runat="server" Text='<%#Bind("precioCompra")%>' />
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:TemplateField>

                                        <HeaderTemplate>Total</HeaderTemplate>
                                        <ItemTemplate>
                                            S/. <asp:Label ID="precioTotal" runat="server" Text='<%#Bind("precioTotal")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <%--<asp:TemplateField Visible="false">
                                        <HeaderTemplate>Codigo</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCodigo" runat="server" Text='<% #Bind("idCodigo") %>' />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lblCodigoEdit" runat="server" Text='<% #Bind("idCodigo") %>' />
                                        </EditItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>

                        </div>

                        <div class="row">

                            <div class="col-xl-8 col-lg-6 mb-3">
                            </div>

                            <div class="col-xl-2 col-lg-6 mb-3">
                                <label class="my-1 mr-2">Importe Total:</label>
                            </div>
                            <div class="col-xl-2 col-lg-6 mb-3">
                                S/. <asp:Label runat="server" ID="tPrecioTotal" MaxLength="40"> </asp:Label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-xl-3 col-lg-6 d-flex ml-auto">
                                <label class="my-1 mr-2">&nbsp;</label>
                                <asp:Button runat="server" ID="btnCancelar" CssClass="btn btn-secondary form-control" OnClick="btnCancelar_Click" Text="Cerrar" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
