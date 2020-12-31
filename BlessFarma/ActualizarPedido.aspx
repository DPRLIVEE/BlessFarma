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
            Fecha de Emision:<asp:TextBox ID="txtFechaE"  runat="server"></asp:TextBox>
            <br />
            Feha de Entrega:<asp:TextBox ID="txtFechaEntrega"  runat="server"></asp:TextBox>
            <asp:Calendar ID="cldFechaEntrega" runat="server" OnSelectionChanged="cldFechaEntrega_SelectionChanged"></asp:Calendar>            
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
             Productos:
            <asp:DropDownList ID="ddlProducto" AutoPostBack="true" runat="server">
            </asp:DropDownList>
            <br />
             <asp:Label ID="Label3" runat="server" Text="Cantidad:"></asp:Label>
            <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
            <br />
             <div>
                <asp:GridView ID="gvProductos" runat="server"  OnRowCommand="gvProductos_RowCommand" >
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button runat="server" ID="btnBorrar" Text="Borrar" CommandName="BorrarP" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"/>
                            </ItemTemplate>                            
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <br />
            <div style="text-align:center" >
                <asp:Button ID="btnAñadirP" runat="server" Text="Añadir" OnClick="btnAñadirP_Click" />
            </div>
            <br />
            <div>
                <asp:Label ID="lblTotal" runat="server" Text="Total:"></asp:Label>
                <asp:TextBox ID="txtTotal" runat="server"></asp:TextBox>
            </div>
            <br />
            <div style="text-align:center" >
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            </div>
            <br />
            <div style="text-align:center" >
                <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />
            </div>
            <br />
             <div style="text-align:center" >
                <asp:Label ID="lblMsj" runat="server" />
            </div>
           
        </div>
    </form>
</body>
</html>
