<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarPedido.aspx.cs" Inherits="BlessFarma.AgregarPedido"    %>

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
            <asp:TextBox ID="txtPedido" ReadOnly="true" runat="server"></asp:TextBox>

            <br />
            Estado:<asp:TextBox ID="txtEstado" ReadOnly="true" runat="server"></asp:TextBox>
            <br />
            Fecha de Emision:<asp:TextBox ID="txtFechaE" ReadOnly="true" runat="server"></asp:TextBox>
            <br />
            Feha de Entrega:<asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            <br />
            Medio de Pago:<asp:DropDownList ID="ddlMedioPago"  runat="server" OnSelectedIndexChanged="ddlMedioPago_SelectedIndexChanged">
            <asp:ListItem  Value="">Seleccione</asp:ListItem>
            <asp:ListItem Text="Efectivo" Value="Efectivo">Efectivo</asp:ListItem>
            <asp:ListItem Text="Crédito" Value="Crédito">Crédito</asp:ListItem>
            </asp:DropDownList>
           <br />
            Proveedor:<asp:DropDownList ID="ddlProveedor" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlProveedor_SelectedIndexChanged">
            </asp:DropDownList>
            
            
      
        <h2> Detalle del Producto </h2>
          
                <div>
                <asp:Label ID="Label2" runat="server" Text="Producto:"></asp:Label>
                <asp:DropDownList ID="ddlProducto" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlProducto_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <asp:Label ID="Label3" runat="server" Text="Cantidad:"></asp:Label>
            <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
            
            <div>
<br />
                <asp:Button ID="btnAñadirProducto" runat="server" Text="Añadir Producto" OnClick="btnAñadirProducto_Click" />
            </div>
            <br />
             <div>
                <asp:GridView ID="GridView1" runat="server" ></asp:GridView>
            </div>
  
            <div style="text-align:center" >
                <asp:Button ID="btnAgregarP" runat="server" Text="Guardar" OnClick="btnAgregarP_Click" />
            </div>
            <br />
             <div style="text-align:center" >
                <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />
            </div>
           
        </div>
    </form>
</body>
</html>
