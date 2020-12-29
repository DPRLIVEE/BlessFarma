<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActualizarPedido.aspx.cs" Inherits="BlessFarma.ActualizarPedido" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <h1>Actualizar Pedido </h1>
        <br />
        <h2> Detalle del Pedido </h2>
          
            <asp:Label ID="Label1" runat="server" Text="N° Pedido"></asp:Label>
            <asp:TextBox ID="txtPedido" ReadOnly="true" runat="server"></asp:TextBox>
            <br />            
            Fecha de Emision:<asp:TextBox ID="txtFechaE" ReadOnly="true" runat="server"></asp:TextBox>
            <br />
            Feha de Entrega:<asp:TextBox ID="txtFechaEntrega" ReadOnly="true" runat="server"></asp:TextBox>
            <asp:Calendar ID="cldFechaEntrega" runat="server"></asp:Calendar>            
            <br />
            Medio de Pago:<asp:TextBox ID="txtMedioPago" ReadOnly="true"  runat="server" ></asp:TextBox>   
            <asp:DropDownList ID="ddlMedioPago"  runat="server" OnSelectedIndexChanged="ddlMedioPago_SelectedIndexChanged">
            <asp:ListItem  Value="">Seleccione</asp:ListItem>
            <asp:ListItem Text="Efectivo" Value="Efectivo">Efectivo</asp:ListItem>
            <asp:ListItem Text="Crédito" Value="Crédito">Crédito</asp:ListItem>
            </asp:DropDownList>
           <br />
            Proveedor:<asp:TextBox ID="txtProveedor" ReadOnly="true" runat="server"></asp:TextBox>
            <asp:DropDownList ID="ddlProveedor" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlProveedor_SelectedIndexChanged">
            </asp:DropDownList>
            
            
      
        <h2> Detalle del Producto </h2>
                          
             <div>
                <asp:GridView ID="gvProductos" runat="server" ></asp:GridView>
            </div>
  
            <div style="text-align:center" >
                <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />
            </div>
           
        </div>
    </form>
</body>
</html>
