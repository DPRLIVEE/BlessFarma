<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ConsultarLista.aspx.cs" Inherits="BlessFarma.Paginas.ConsultarLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <link href="../../Content/css/select2.min.css" rel="stylesheet" />
    <script src="../../Scripts/select2.min.js"></script>

    <h3 class="h3 mb-3 text-gray-800">Consultar Lista de Compras </h3>

    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="card shadow mb-4">
                <a href="#filtercollapseCard" data-toggle="collapse" role="button" aria-expanded="true" aria-controls="collapseCardExample" class="d-flex card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary"><i class="fas fa-filter"></i>&nbsp;Datos de la lista:</h6>
                </a>
                <div class="collapse show" id="filtercollapseCard">
                    <div class="card-body">
                        <div class="row">

                            <div class="col-xl-4 col-lg-6 mb-3">
                                <label class="my-1 mr-2">Codigo de Lista: <label class="my-1 mr-2">0000001</label></label>
                            </div>
                   
                            <div class="col-xl-4 col-lg-6 mb-3">
                                <label class="my-1 mr-2">Quimico Farmaceutico: <label class="my-1 mr-2">Diego Rodas</label></label>
                            </div>

                            <div class="col-xl-4 col-lg-6">
                                <label class="my-1 mr-2">Fecha de Registro: <label class="my-1 mr-2">06/11/2020</label></label>
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
                                DataKeyNames="IdCategoria" EmptyDataText="No se encontro ninguna categoria." PageSize="15"
                                OnRowCommand="gvCategoria_RowCommand"
                                OnRowEditing="gvCategoria_RowEditing"
                                OnRowCancelingEdit="gvCategoria_RowCancelingEdit"
                                OnRowDataBound="gvCategoria_RowDataBound"
                                OnRowUpdating="gvCategoria_RowUpdating"
                                OnPageIndexChanging="gvCategoria_PageIndexChanging"
                                ShowFooter="true">
                                <Columns>

                                    <asp:TemplateField Visible="false">
                                        <HeaderTemplate>Codigo</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCat" runat="server" Text='<% #Bind("idListaCompra") %>' />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lblCategoriaEdit" runat="server" Text='<% #Bind("estado") %>' />
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField Visible="false" HeaderText="Nro. Fila">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <%--<asp:TemplateField>
                                        <HeaderTemplate>Nombre del Producto</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCategoria" runat="server" Text='<%#Bind("Categoria")%>' />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" CssClass="form-control" OnKeyPress="return LetrasInt(event)" ID="txtCategoriaEdit" MaxLength="20" Text='<% #Bind("Categoria") %>' />
                                        </EditItemTemplate>
                                        
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <HeaderTemplate>Laboratorio</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCategoria" runat="server" Text='<%#Bind("Categoria")%>' />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" CssClass="form-control" OnKeyPress="return LetrasInt(event)" ID="txtCategoriaEdit" MaxLength="20" Text='<% #Bind("Categoria") %>' />
                                        </EditItemTemplate>
                                        

                                    </asp:TemplateField>--%>

                                   
                               
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
                                <asp:Button runat="server" ID="Button1" CssClass="btn btn-secondary form-control" OnClick="btnCancelar_Click" Text="Atras" />
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
