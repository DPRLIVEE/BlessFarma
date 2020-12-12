<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="GenerarListaCompras.aspx.cs" Inherits="BlessFarma.Paginas.GenerarListaCompras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="../../Content/css/select2.min.css" rel="stylesheet" />
    <script src="../../Scripts/select2.min.js"></script>

    <h3 class="h3 mb-3 text-gray-800">Generar Lista de Compras </h3>

    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="card shadow mb-4">
                <a href="#filtercollapseCard" data-toggle="collapse" role="button" aria-expanded="true" aria-controls="collapseCardExample" class="d-flex card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary"><i class="fas fa-filter"></i>Filtros de busqueda:</h6>
                </a>
                <div class="collapse show" id="filtercollapseCard">
                    <div class="card-body">
                        <div class="row">

                            <div class="col-xl-3 col-lg-6 mb-3">
                                <label class="my-1 mr-2">Codigo de Lista:</label>
                                <asp:TextBox runat="server" ID="txtNomCategoria" OnKeyPress="return LetrasInt(event)" CssClass="form-control" placeholder="Ingresar Codigo" MaxLength="40"></asp:TextBox>
                            </div>

                            <div class="col-xl-3 col-lg-6 mb-3">
                                <label class="my-1 mr-2">Quimico Farmaceutico:</label>
                                <asp:TextBox runat="server" ID="TextBox1" OnKeyPress="return LetrasInt(event)" CssClass="form-control" placeholder="Ingresar Nombre" MaxLength="40"></asp:TextBox>
                            </div>
                            <div class="col-xl-3 col-lg-6">
                            </div>

                            <div class="col-xl-3 col-lg-6">
                                <label class="my-1 mr-2">&nbsp;</label>
                                <asp:Button runat="server" ID="btnBuscar" CssClass="btn btn-primary form-control" Text="Consultar Lista" />
                            </div>


                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div class="card shadow mb-4">
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:Panel ID="Panel1" runat="server" CssClass="auto-style1">
                            <asp:GridView ID="gvCategoria" runat="server" AutoGenerateColumns="False" Font-Size="Small" GridLines="None" HeaderStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Center"
                                AllowPaging="True" CssClass="table table-thead-style" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                                DataKeyNames="idListaCompra" EmptyDataText="No se encontro ninguna categoria." PageSize="15"
                                OnRowCommand="gvCategoria_RowCommand"
                                OnRowEditing="gvCategoria_RowEditing"
                                OnRowCancelingEdit="gvCategoria_RowCancelingEdit"
                                OnRowDataBound="gvCategoria_RowDataBound"
                                OnRowUpdating="gvCategoria_RowUpdating"
                                OnPageIndexChanging="gvCategoria_PageIndexChanging"
                                ShowFooter="true">
                                <Columns>

                                    <%--<asp:TemplateField Visible="false">
                                        <HeaderTemplate>Codigo</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCat" runat="server" Text='<% #Bind("IdCategoria") %>' />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lblCategoriaEdit" runat="server" Text='<% #Bind("IdCategoria") %>' />
                                        </EditItemTemplate>
                                    </asp:TemplateField>--%>



                                    <asp:TemplateField>
                                        <HeaderTemplate>Id</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCategoria" runat="server" Text='<%#Bind("idListaCompra")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>Estado</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCategoria" runat="server" Text='<%#Bind("estado")%>' />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" CssClass="form-control" OnKeyPress="return LetrasInt(event)" ID="txtCategoriaEdit" MaxLength="20" Text='<% #Bind("estado") %>' />
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>Ver</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton Text="text" ID="lnkEdit" runat="server" ToolTip="Editar" CommandName="Edit" CommandArgument='<%# Container.DataItemIndex %>'>
                                                            <i class="fas fa-eye fa-1x"></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>Editar</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton Text="text" ID="lnkEdit" runat="server" ToolTip="Editar" CommandName="Edit" CommandArgument='<%# Container.DataItemIndex %>'>
                                                            <i class="fas fa-edit fa-1x"></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>Anular</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton Text="text" ID="lnkEdit" runat="server" ToolTip="Editar" CommandName="Edit" CommandArgument='<%# Container.DataItemIndex %>'>
                                                            <i class="fas fa-trash fa-1x"></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                           </asp:GridView>

                            <div class="row">
                            <div class="col-xl-3 col-lg-6">
                            </div>
                            <div class="col-xl-3 col-lg-6">
                            </div>                              
                            <div class="col-xl-3 col-lg-6">
                            </div>
                            <div class="col-xl-3 col-lg-6">
                                <label class="my-1 mr-2">&nbsp;</label> 
                                <asp:Button runat="server" ID="Button1" CssClass="btn btn-primary form-control" OnClick="btnAgregarLista_Click" Text="Agregar Lista de Compras" />
                            </div>
                                </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
            </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
