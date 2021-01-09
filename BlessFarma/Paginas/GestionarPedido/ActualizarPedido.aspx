<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ActualizarPedido.aspx.cs" Inherits="BlessFarma.Paginas.GestionarPedido.ActualizarPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../Content/css/select2.min.css" rel="stylesheet" />
    <script src="../../Scripts/select2.min.js"></script>

    <h3 class="h3 mb-3 text-gray-800">Actualizar Pedido</h3>

    <asp:UpdatePanel runat="server" ID="UpdatePanelUsuario" UpdateMode="Conditional">
        <ContentTemplate>

            <div class="row">
                <div class="col-xl-6 col-lg-6 col-md-6 col-sm-12 col-12">
                    <div class="card shadow mb-4">
                        <a href="#filtercollapseCard1" data-toggle="collapse" role="button" aria-expanded="true" aria-controls="collapseCardExample" class="d-flex card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">Datos del Pedido:</h6>
                        </a>
                        <div class="collapse show" id="filtercollapseCard1">
                            <div class="card-body">
                                <div class="row align-items-end">

                                    <div class="col-xl-12 col-lg-6 mb-3">
                                    </div>
                                    <div class="col-xl-12 col-lg-6 mb-3">
                                    </div>
                                    <div class="col-xl-1 col-lg-6 mb-3">
                                    </div>
                                    <div class="col-xl-4 col-lg-6 mb-3">
                                        <label class="my-1 mr-2">Fecha de Emisión:</label>
                                    </div>
                                    <div class="col-xl-1 col-lg-6 mb-3">
                                    </div>
                                    <div class="col-xl-5 col-lg-6 mb-3">
                                        <asp:Label runat="server" ID="tFechaEmision" MaxLength="40"></asp:Label>
                                        <%--<asp:TextBox runat="server" ID="tFechaEmision" CssClass="form-control" Enabled="false" MaxLength="40"></asp:TextBox>--%>
                                    </div>
                                    <div class="w-100"></div>

                                    <div class="col-xl-1 col-lg-6 mb-3">
                                    </div>
                                    <div class="col-xl-4 col-lg-6 mb-3">
                                        <label class="my-1 mr-2">Fecha de Entrega:</label>
                                    </div>
                                    <div class="col-xl-1 col-lg-6 mb-3">
                                    </div>
                                    <div class="col-xl-5 col-lg-6 mb-3">
                                        <asp:TextBox runat="server" ID="tFechaEntrega" CssClass="form-control" TextMode="Date" />
                                    </div>
                                    <div class="w-100"></div>

                                    <div class="col-xl-1 col-lg-6 mb-3">
                                    </div>
                                    <div class="col-xl-4 col-lg-6 mb-3">
                                        <label class="my-1 mr-2">Medio de Pago:</label>
                                    </div>
                                    <div class="col-xl-1 col-lg-6 mb-3">
                                    </div>
                                    <div class="col-xl-5 col-lg-6 mb-3">
                                        <asp:DropDownList runat="server" ID="ddlMedioPago" CssClass="form-control" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="w-100"></div>

                                    <div class="col-xl-1 col-lg-6 mb-3">
                                    </div>
                                    <div class="col-xl-4 col-lg-6 mb-3">
                                        <label class="my-1 mr-2">Proveedor:</label>
                                    </div>
                                    <div class="col-xl-1 col-lg-6 mb-3">
                                    </div>
                                    <div class="col-xl-5 col-lg-6 mb-3">
                                        <asp:DropDownList runat="server" ID="ddlProveedor" CssClass="form-control" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="w-100"></div>

                                    <div class="col-xl-12 col-lg-6 mb-3">
                                    </div>
                                    <div class="col-xl-12 col-lg-6 mb-3">
                                    </div>
                                    <div class="col-xl-12 col-lg-6 mb-3">
                                    </div>
                                    <div class="col-xl-12 col-lg-6 mb-3">
                                    </div>
                                    <div class="col-xl-12 col-lg-6 mb-3">
                                    </div>
                                    <div class="col-xl-12 col-lg-6 mb-3">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-xl-6 col-lg-6 col-md-6 col-sm-12 col-12">
                    <div class="card shadow mb-4">
                        <a href="#filtercollapseCard" data-toggle="collapse" role="button" aria-expanded="true" aria-controls="collapseCardExample" class="d-flex card-header py-3">
                            <h6 class="m-0 font-weight-bold text-primary">Detalle del Producto:</h6>
                        </a>
                        <div class="collapse show" id="filtercollapseCard">
                            <div class="card-body">
                                <div class="row align-items-end">

                                    <div class="col-xl-1 col-lg-6 mb-3">
                                    </div>
                                    <div class="col-xl-4 col-lg-6 mb-3">
                                        <label class="my-1 mr-2">Nombre del Producto:</label>
                                    </div>
                                    <div class="col-xl-1 col-lg-6 mb-3">
                                    </div>
                                    <div class="col-xl-5 col-lg-6 mb-3">
                                        <asp:DropDownList runat="server" ID="ddlProducto" CssClass="form-control" OnSelectedIndexChanged="ddlProducto_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="w-100"></div>

                                    <div class="col-xl-1 col-lg-6 mb-3">
                                    </div>
                                    <div class="col-xl-4 col-lg-6 mb-3">
                                        <label class="my-1 mr-2">Cantidad:</label>
                                    </div>
                                    <div class="col-xl-1 col-lg-6 mb-3">
                                    </div>
                                    <div class="col-xl-5 col-lg-6 mb-3">
                                        <asp:TextBox runat="server" ID="tCantidad" CssClass="form-control" placeholder="Ingresar Cantidad" MaxLength="40"></asp:TextBox>
                                    </div>
                                    <div class="w-100"></div>

                                    <div class="col-xl-1 col-lg-6 mb-3">
                                    </div>
                                    <div class="col-xl-4 col-lg-6 mb-3">
                                        <label class="my-1 mr-2">Formato:</label>
                                    </div>
                                    <div class="col-xl-1 col-lg-6 mb-3">
                                    </div>
                                    <div class="col-xl-5 col-lg-6 mb-3">
                                        <asp:Label runat="server" ID="tFormato" MaxLength="40"></asp:Label>
                                        <%--<asp:TextBox runat="server" ID="tFormato" CssClass="form-control" Enabled="false" MaxLength="40"></asp:TextBox>--%>
                                    </div>
                                    <div class="w-100"></div>

                                    <div class="col-xl-1 col-lg-6 mb-3">
                                    </div>
                                    <div class="col-xl-4 col-lg-6 mb-3">
                                        <label class="my-1 mr-2">Laboratorio:</label>
                                    </div>
                                    <div class="col-xl-1 col-lg-6 mb-3">
                                    </div>
                                    <div class="col-xl-5 col-lg-6 mb-3">
                                        <asp:Label runat="server" ID="tLaboratorio" MaxLength="40"></asp:Label>
                                        <%--<asp:TextBox runat="server" ID="tLaboratorio" CssClass="form-control" Enabled="false" MaxLength="40"></asp:TextBox>--%>
                                    </div>
                                    <div class="w-100"></div>

                                    <div class="col-xl-1 col-lg-6 mb-3">
                                    </div>
                                    <div class="col-xl-4 col-lg-6 mb-3">
                                        <label class="my-1 mr-2">Precio Unitario:</label>
                                    </div>
                                    <div class="col-xl-1 col-lg-6 mb-3">
                                    </div>
                                    <div class="col-xl-5 col-lg-6 mb-3">
                                        <asp:Label runat="server" ID="tPrecio" MaxLength="40"></asp:Label>
                                        <%-- <asp:TextBox runat="server" ID="tPrecio" CssClass="form-control" Enabled="false" MaxLength="40"></asp:TextBox>--%>
                                    </div>
                                    <div class="w-100"></div>

                                    <div class="col-xl-12 col-lg-6 mb-3">
                                    </div>
                                    <div class="col-xl-12 col-lg-6 mb-3">
                                    </div>
                                    <div class="col-xl-2 col-lg-6 mb-3">
                                    </div>
                                    <div class="col-xl-4 col-lg-6 mb-3">
                                    </div>
                                    <div class="col-xl-5 col-lg-6 mb-3">
                                        <asp:Button runat="server" ID="btnAgregarProducto" CssClass="btn btn-primary form-control" OnClick="btnIngresar_Click" Text="Agregar Producto" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

            <div class="card shadow mb-4">
                <a href="#filtercollapseCard2" data-toggle="collapse" role="button" aria-expanded="true" aria-controls="collapseCardExample" class="d-flex card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary"><i class="<%--fas fa-filter--%>"></i>Detalle del Pedido:</h6>
                </a>
                <div class="collapse show" id="filtercollapseCard2">
                    <div class="card-body">
                        <div class="table-responsive">

                            <asp:GridView ID="gvAgregarPedido" runat="server" AutoGenerateColumns="False" Font-Size="Small" GridLines="None" HeaderStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Center"
                                AllowPaging="True" CssClass="table table-thead-style" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                EmptyDataText="No se encontro ninguna categoria." PageSize="15"
                                OnRowCommand="gvAgregarPedido_RowCommand"
                                OnPageIndexChanging="gvAgregarPedido_PageIndexChanging">
                                <Columns>

                                    <asp:TemplateField Visible="false">
                                        <HeaderTemplate>Codigo</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="idProducto" runat="server" Text='<%#Eval("idProducto").ToString() == "0" ? "" : Eval("idProducto")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>Producto</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="nombreProducto" runat="server" Text='<%#Eval("nombreProducto").ToString() == "" ? "" : Eval("nombreProducto")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>Cantidad</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="cantidad" runat="server" Text='<%#Eval("cantidad").ToString() == "" ? "" : Eval("cantidad")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>Formato</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="formato" runat="server" Text='<%#Eval("formato").ToString() == "" ? "" : Eval("formato")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>Precio U.</HeaderTemplate>
                                        <ItemTemplate>
                                            S/.<asp:Label ID="precioUnitario" runat="server" Text='<%#Eval("precioCompra").ToString() == "" ? "" : Eval("precioCompra")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>Total</HeaderTemplate>
                                        <ItemTemplate>
                                            S/.<asp:Label ID="total" runat="server" Text='<%#Bind("precioTotal")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Quitar" HeaderStyle-CssClass="center">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkQuitar" CommandName="Quitar" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'
                                                ToolTip="Quitar" CssClass="btn btn-link">
                                                <i class="fa fa-times" style="color:red"></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

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

                            <div class="col-xl-3 col-lg-6 mb-3">
                            </div>
                            <div class="col-xl-3 col-lg-6 mb-3">
                            </div>
                            <div class="col-xl-3 col-lg-6 mb-3">
                                <div class="py-3"></div>
                                <asp:Button runat="server" ID="btnActualizarPedido" CssClass="btn btn-primary form-control" OnClick="btnActualizar_Click" Text="Actualizar Pedido" />
                            </div>

                            <div class="col-xl-3 col-lg-6 mb-3">
                                <div class="py-3"></div>
                                <asp:Button runat="server" ID="btnCancelar" CssClass="btn btn-danger form-control" OnClick="btnCancelar_Click" Text="Cancelar" />
                            </div>
                        </div>


                    </div>
                </div>
            </div>


        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
