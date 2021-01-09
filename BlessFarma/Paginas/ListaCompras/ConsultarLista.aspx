<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ConsultarLista.aspx.cs" Inherits="BlessFarma.Paginas.ListaCompras.ConsultarLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="../../Content/css/select2.min.css" rel="stylesheet" />
    <script src="../../Scripts/select2.min.js"></script>

    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <h3 class="h3 mb-3 text-gray-800">Consultar Lista de Compras </h3>
            <div class="card shadow mb-4">
                <a href="#filtercollapseCard" data-toggle="collapse" role="button" aria-expanded="true" aria-controls="collapseCardExample" class="d-flex card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary"><i class="<%--fas fa-filter--%>"></i>Datos de la Lista de Compras:</h6>
                </a>
                <div class="collapse show" id="filtercollapseCard">
                    <div class="card-body">

                        <div class="row">

                            <div class="col-xl-2 col-lg-6">
                            </div>
                            <div class="col-xl-3 col-lg-6 mb-3">
                                <label class="my-1 mr-2">Codigo:</label>
                                <asp:Label runat="server" ID="tCodListaCompra" MaxLength="10"></asp:Label>
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

                            <asp:GridView ID="gvCListaCompra" runat="server" AutoGenerateColumns="False" Font-Size="Small" GridLines="None" HeaderStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Center"
                                AllowPaging="True" CssClass="table table-thead-style" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                EmptyDataText="No se encontro ningun producto." PageSize="15"
                                OnRowCommand="gvCListaCompra_RowCommand"
                                OnRowEditing="gvCListaCompra_RowEditing"
                                OnRowCancelingEdit="gvCListaCompra_RowCancelingEdit"
                                OnRowDataBound="gvCListaCompra_RowDataBound"
                                OnRowUpdating="gvCListaCompra_RowUpdating"
                                OnPageIndexChanging="gvCListaCompra_PageIndexChanging"
                                ShowFooter="false">
                                <Columns>

                                    <asp:TemplateField>

                                        <HeaderTemplate>Nombre del Producto</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="nombreProducto" runat="server" Text='<%#Bind("nombreProducto")%>' />
                                        </ItemTemplate>

                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemStyle Width="55%" HorizontalAlign="Center" />
                                        <HeaderTemplate>Laboratorio</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="nombreLaboratorio" runat="server" Text='<%#Bind("nombreLaboratorio")%>' />
                                        </ItemTemplate>
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
                                <asp:Button runat="server" ID="Button4" CssClass="btn btn-secondary form-control" OnClick="btnCancelar_Click" Text="Cerrar" />

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
