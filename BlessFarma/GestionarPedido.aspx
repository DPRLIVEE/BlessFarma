<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionarPedido.aspx.cs" Inherits="BlessFarma.GestionarPedido" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <h1>Gestionar Pedido</h1>
        <div>
            <asp:Button ID="btnNuevoPedido" runat="server" Text="Nuevo Pedido" OnClick="btnNuevoPedido_Click" />
        </div>
        <br />
        <div>
            <asp:GridView ID="gvPedidos" runat="server" DataKeyNames="idPedido,Estado,razonSocial,FechaEmision,FechaEntrega,idListaCompra,MontoTotal" AutoGenerateColumns="False" OnRowCommand="gvPedidos_RowCommand" OnRowDataBound="gvPedidos_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="N° Pedido" DataField="idPedido"/>
                    <asp:BoundField HeaderText="Estado" DataField="Estado"/>  
                    <asp:BoundField HeaderText="Proveedor" DataField="razonSocial"/>
                    <asp:BoundField HeaderText="Fecha Emsion" DataField="FechaEmision"/>
                    <asp:BoundField HeaderText="Fecha Entrega" DataField="FechaEntrega"/>
                    <asp:BoundField HeaderText="N° Lista Compra" DataField="idListaCompra"/>
                    <asp:BoundField HeaderText="Monto Total" DataField="MontoTotal"/>
                    <asp:TemplateField HeaderText="Ver">
                        <ItemTemplate>
                            <asp:Button ID="btnVer" runat="server" Text="Ver"  CommandName="VerP" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Editar">
                        <ItemTemplate>
                            <asp:Button ID="btnEditar" runat="server" Text="Editar" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Anular">
                        <ItemTemplate>
                            <asp:Button ID="btnAnular" runat="server" Text="Anular" CommandName="AnularP" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button ID="btnEnviar" runat="server" CommandName="EnviarP" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Height="22px" Text="Enviado" Width="57px" />
                            <asp:Button ID="btnAceptar" runat="server" CommandName="AceptarP" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Height="24px" Text="Aceptar" Width="53px" />
                            <asp:Button ID="btnRechazar" runat="server" CommandName="RechazarP" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Height="22px" Text="Rechazar" Width="57px" />
                            <asp:Button ID="btnEntregado" runat="server" CommandName="EntregadoP" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Height="20px" Text="Entregado" Width="58px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
