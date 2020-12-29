<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultarPedido.aspx.cs" Inherits="BlessFarma.ConsultarPedido" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <div>
        <h1>Consultar Pedido </h1>
        <br />
        <h2> Detalle del Pedido </h2>
         
              <asp:Label ID="Label1" runat="server" Text="N° Pedido"></asp:Label>
            <asp:TextBox ID="txtPedido" ReadOnly="true" runat="server"></asp:TextBox>

            <br />            
            Fecha de Emision:<asp:TextBox ID="txtFechaE" ReadOnly="true" runat="server"></asp:TextBox>
            <br />
            Feha de Entrega:<asp:TextBox ID="txtFechaEntrega" ReadOnly="true" runat="server"></asp:TextBox>
            <br />
            Medio de Pago:<asp:TextBox ID="txtMedioPago" ReadOnly="true"  runat="server" ></asp:TextBox>                   
           <br />
            Proveedor:<asp:TextBox ID="txtProveedor" ReadOnly="false" runat="server" >
            </asp:TextBox>
            
            
      
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
