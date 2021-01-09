<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AgregarLista.aspx.cs" Inherits="BlessFarma.Paginas.AgregarLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <link href="../../Content/css/select2.min.css" rel="stylesheet" />
    <script src="../../Scripts/select2.min.js"></script>

    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="row">
                <h3 class="h3 mb-3 col-xl-6 text-gray-800">Nueva Lista de Compras </h3>
                <a id="RegistrarLista" onclick="registrarListaCompra();" class="search-micro">
                    <i class="fas fa-microphone"></i>
                </a>
            </div>

            <div class="card shadow mb-4">
                <a href="#filtercollapseCard" data-toggle="collapse" role="button" aria-expanded="true" aria-controls="collapseCardExample" class="d-flex card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary"><i class="<%--fas fa-filter--%>"></i>Datos de la Lista de Compras:</h6>
                </a>
                <div class="collapse show" id="filtercollapseCard">
                    <div class="card-body">

                        <div class="row">
                            <div class="col-xl-3 col-lg-6 mb-3">
                                <label class="my-1 mr-2">Producto:</label>
                                <asp:DropDownList runat="server" ID="ddlProducto" CssClass="form-control" OnSelectedIndexChanged="ddlProducto_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>

                            <div class="col-xl-3 col-lg-6 mb-3">
                                <label class="my-1 mr-2">Laboratorio:</label>
                                <asp:TextBox runat="server" ID="tLaboratorio" CssClass="form-control" MaxLength="10" Enabled="False"></asp:TextBox>
                            </div>

                            <div class="col-xl-3 col-lg-6">
                            </div>

                            <div class="col-xl-3 col-lg-6">
                                <div class="py-3"></div>
                                <asp:Button runat="server" ID="btnAgregarProducto" CssClass="btn btn-primary form-control" OnClick="btnIngresar_Click" Text="Agregar Producto" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="card shadow mb-4">
                <a href="#filtercollapseCard1" data-toggle="collapse" role="button" aria-expanded="true" aria-controls="collapseCardExample" class="d-flex card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary"><i class="<%--fas fa-filter--%>"></i>Detalle de la Lista:</h6>
                </a>
                <div class="collapse show" id="filtercollapseCard1">
                    <div class="card-body">

                        <div class="table-responsive">
                            <asp:GridView ID="gvProducto" runat="server" AutoGenerateColumns="False" Font-Size="Small" GridLines="None" HeaderStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Center"
                                AllowPaging="True" CssClass="table table-thead-style" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                DataKeyNames="IdProducto" EmptyDataText="No se encontro ningun producto." PageSize="15"
                                OnRowCommand="gvProducto_RowCommand"
                                OnRowEditing="gvProducto_RowEditing"
                                OnRowCancelingEdit="gvProducto_RowCancelingEdit"
                                OnRowDataBound="gvProducto_RowDataBound"
                                OnRowUpdating="gvProducto_RowUpdating"
                                OnPageIndexChanging="gvProducto_PageIndexChanging"
                                ShowFooter="false">
                                <Columns>

                                    <asp:TemplateField>

                                        <HeaderTemplate>Codigo de Producto</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCodProducto" runat="server" Text='<%#Eval("idProducto").ToString() == "0" ? "" : Eval("idProducto")%>' />
                                        </ItemTemplate>

                                    </asp:TemplateField>

                                    <asp:TemplateField>

                                        <HeaderTemplate>Nombre del Producto</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblNomProducto" runat="server" Text='<%#Eval("nombreProducto").ToString() == "" ? "" : Eval("nombreProducto")%>' />
                                        </ItemTemplate>

                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>Laboratorio</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblLaboratorio" runat="server" Text='<%#Eval("nombreLaboratorio").ToString() == "" ? "" : Eval("nombreLaboratorio")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Quitar" HeaderStyle-CssClass="center">
                                        <ItemStyle Width="28%" HorizontalAlign="Center" />

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

                            <div class="col-xl-3 col-lg-6 ">
                            </div>
                            <div class="col-xl-3 col-lg-6 ">
                            </div>
                            <div class="col-xl-3 col-lg-6 d-flex ml-auto">
                                <div class="py-3"></div>
                                <asp:Button runat="server" ID="btnRegistrar" CssClass="btn btn-primary form-control" OnClick="btnRegistrar_Click" Text="Registrar Lista" />
                            </div>

                            <div class="col-xl-3 col-lg-6 d-flex ml-auto">
                                <div class="py-3"></div>
                                <asp:Button runat="server" ID="btnCancelar" CssClass="btn btn-danger form-control" OnClick="btnCancelar_Click" Text="Cancelar" />
                            </div>

                        </div>

                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script src="../../js/RegistrarLista.js"></script>
</asp:Content>
