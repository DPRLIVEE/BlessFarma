<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ActualizarLista.aspx.cs" Inherits="BlessFarma.Paginas.ListaCompras.ActualizarLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="../../Content/css/select2.min.css" rel="stylesheet" />
    <script src="../../Scripts/select2.min.js"></script>

    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <h3 class="h3 mb-3 text-gray-800">Actualizar Lista de Compras </h3>
            <div class="card shadow mb-4">
                <a href="#filtercollapseCard" data-toggle="collapse" role="button" aria-expanded="true" aria-controls="collapseCardExample" class="d-flex card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary"><i class="<%--fas fa-filter--%>"></i>Datos de la Lista de Compras:</h6>
                </a>
                <div class="collapse show" id="filtercollapseCard">
                    <div class="card-body">

                        <div class="row">

                            <div class="col-xl-2 col-lg-6">
                            </div>
                            <div class="col-xl-3 col-lg-6 mb-3" style="display:none;">
                                <label class="my-1 mr-2">Codigo:</label>
                                <asp:Label runat="server" ID="tCodListaCompra" MaxLength="10"></asp:Label>
                            </div>
                            <div class="col-xl-3 col-lg-6">
                                <label class="my-1 mr-2">Codigo:</label>
                                <asp:Label runat="server" ID="tCodListaCompraCorrelativo" MaxLength="10"></asp:Label>
                            </div>
                            <div class="col-xl-2 col-lg-6">
                            </div>
                            <div class="col-xl-3 col-lg-6 mb-3">
                                <label class="my-1 mr-2">Fecha de Registro:</label>
                                <asp:Label runat="server" ID="tFecha" MaxLength="10"></asp:Label>
                            </div>

                            <div class="col-xl-3 col-lg-6">
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="card shadow mb-4">
                <a href="#filtercollapseCard1" data-toggle="collapse" role="button" aria-expanded="true" aria-controls="collapseCardExample" class="d-flex card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary"><i class="<%--fas fa-filter--%>"></i>Productos de la Lista:</h6>
                </a>
                <div class="collapse show" id="filtercollapseCard1">
                    <div class="card-body">

                        <div class="table-responsive">

                            <asp:GridView ID="gvActualizarLista" runat="server" AutoGenerateColumns="False" Font-Size="Small" GridLines="None" HeaderStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Center"
                                AllowPaging="True" CssClass="table table-thead-style" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                EmptyDataText="No se encontro ningun producto." PageSize="15"
                                OnRowCommand="gvActualizarLista_RowCommand"
                                OnRowEditing="gvActualizarLista_RowEditing"
                                OnRowCancelingEdit="gvActualizarLista_RowCancelingEdit"
                                OnRowDataBound="gvActualizarLista_RowDataBound"
                                OnRowUpdating="gvActualizarLista_RowUpdating"
                                OnPageIndexChanging="gvActualizarLista_PageIndexChanging">
                                <Columns>

                                    <asp:TemplateField>

                                        <HeaderTemplate>Nombre del Producto</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="nombreProducto" runat="server" Text='<%#Bind("nombreProducto")%>' />
                                        </ItemTemplate>

                                        <EditItemTemplate>
                                            <asp:HiddenField runat="server" ID="hdnProducto" Value='<% #Bind("nombreProducto")%>' />
                                            <asp:DropDownList runat="server" ID="ddlProductoEdit" CssClass="form-control" OnSelectedIndexChanged="ddlProducto_SelectedIndexChanged" AutoPostBack="true" />
                                        </EditItemTemplate>

                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>Laboratorio</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="nombreLaboratorio" runat="server" Text='<%#Bind("nombreLaboratorio")%>' />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox Width="50%" runat="server" CssClass="form-control" ID="tNombreLaboratorio" MaxLength="20" Enabled="False" Text='<% #Bind("nombreLaboratorio") %>' />
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Editar" HeaderStyle-CssClass="center">
                                        <ItemStyle Width="35%" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkEdit" CommandName="Edit" CommandArgument='<%# Container.DataItemIndex %>'
                                                ToolTip="Editar" CssClass="btn btn-link">
                                                <i class="fas fa-pencil-alt fa-lg"></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>

                                        <EditItemTemplate>
                                            <asp:LinkButton ID="lnkUpdate" runat="server" ToolTip="Guardar" CommandName="Update" CommandArgument='<%# Container.DataItemIndex %>'
                                                CssClass="btn btn-link">
                                                                <i class="fas fa-save fa-lg"></i>
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="lnkCancel" ToolTip="Cancelar" runat="server" CommandName="Cancel" CommandArgument='<%# Container.DataItemIndex %>'
                                                CssClass="btn btn-link">
                                                                <i class="fas fa-ban fa-lg"></i>
                                            </asp:LinkButton>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField Visible="false">
                                        <HeaderTemplate>Codigo</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCodigo" runat="server" Text='<% #Bind("idCodigo") %>' />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lblCodigoEdit" runat="server" Text='<% #Bind("idCodigo") %>' />
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>

                        </div>
                        <div class="row">
                            <div class="col-xl-3 col-lg-6 d-flex ml-auto">

                                <label class="my-1 mr-2">&nbsp;</label>
                                <asp:Button runat="server" ID="btnCerrar" CssClass="btn btn-secondary form-control" OnClick="btnCerrar_Click" Text="Cerrar" />

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
