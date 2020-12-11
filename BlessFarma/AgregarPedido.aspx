<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarPedido.aspx.cs" Inherits="BlessFarma.AgregarPedido" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <h1>Agregar Pedido </h1>
        <br />
        <h2> Detalle del Pedido </h2>
        <asp:Label ID="Label1" runat="server" Text="N° Pedido"></asp:Label>
            <asp:TextBox ID="txtPedido" runat="server"></asp:TextBox>

            <br />
            Estado:<asp:TextBox ID="txtEstado" runat="server"></asp:TextBox>
            <br />
            Fecha de Emision:<asp:TextBox ID="txtFechaE" runat="server"></asp:TextBox>
            <br />
            Feha de Entrega:<asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            <br />
            Medio de Pago:<asp:DropDownList ID="ddlMedioPago" runat="server">
            <asp:ListItem  Value="">Seleccione</asp:ListItem>
            <asp:ListItem Text="Efectivo" Value="Efectivo">Efectivo</asp:ListItem>
            <asp:ListItem Text="Crédito" Value="Crédito">Crédito</asp:ListItem>
            </asp:DropDownList>

            <br />
            Proveedor:<asp:DropDownList ID="ddlProveedor" runat="server">
            </asp:DropDownList>

        <br />
        <h2> Detalle del Producto </h2>
            <div>
                <asp:Label ID="Label2" runat="server" Text="Producto:"></asp:Label>
                <asp:DropDownList ID="ddlProducto" runat="server">
                </asp:DropDownList>
            </div>
            <asp:Label ID="Label3" runat="server" Text="Cantidad:"></asp:Label>
            <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnAgregarPedido" runat="server" Text="Agregar Pedido" />
        </div>
    </form>
</body>
</html>
