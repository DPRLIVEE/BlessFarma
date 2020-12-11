<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarListaC.aspx.cs" Inherits="BlessFarma.SeleccionarListaC" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Seleccionar Lista de Compra</h1>
        <div>
            <asp:GridView ID="gvListaCompra" runat="server" DataKeyNames="idListaCompra,estado" AutoGenerateColumns="False" OnRowCommand="gvListaCompra_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="N°Lista" DataField="idListaCompra"/>
                    <asp:BoundField HeaderText="Estado" DataField="estado"/>
                    <asp:TemplateField HeaderText="Seleccionar">
                        <ItemTemplate>
                            <asp:Button ID="btnSeleccionarL" runat="server" RowCommand="SeleccionarListaC" CommandName="EnviarEmailOC" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Text="Seleccionar" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                </Columns>
            </asp:GridView>
            
        </div>
    </form>
</body>
</html>
