<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarListaC.aspx.cs" Inherits="BlessFarma.SeleccionarListaC"  %>

<!DOCTYPE html>

<html>

<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <h1>Seleccionar Lista de Compra</h1>
        <div>
           <%-- <asp:UpdatePanel ID="Panel" runat="server">
                <ContentTemplate>--%>
                    <asp:GridView ID="gvListaCompra" runat="server" DataKeyNames="idListaCompra,fecha,estado,nombreUsuario" AutoGenerateColumns="False" OnRowCommand="gvListaCompra_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="N°Lista" DataField="idListaCompra"/>
                    <asp:BoundField HeaderText="Fecha Emision" DataField="fecha"/>
                    <asp:BoundField HeaderText="Farmaceutico" DataField="nombreUsuario"/>
                    <asp:BoundField HeaderText="Estado" DataField="estado"/>
                    <asp:TemplateField HeaderText="Seleccionar">
                        <ItemTemplate>
                            <asp:Button ID="btnSeleccionarL" runat="server"  CommandName="SeleccionarListaC" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Seleccionar" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                </Columns>
            </asp:GridView>
              <%--  </ContentTemplate>
            </asp:UpdatePanel>--%>
                        
        </div>
    </form>
</body>
</html>
