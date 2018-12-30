<%@ Page Title="Venta" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="Venta.aspx.cs" Inherits="SegurosPrueba.Forms.Venta" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="PnlVenta" runat="server">
        <h3>Ventas</h3>
        Asesor: 
        <asp:DropDownList ID="CmbAsesor" runat="server"></asp:DropDownList>
        <br />
        <asp:Button ID="BtnNuevoAsesor" runat="server" Text="Agregar Asesor" OnClick="BtnNuevoAsesor_Click" />
        <br />
        <br />
        Cliente: 
        <asp:DropDownList ID="CmbCliente" runat="server"></asp:DropDownList>
        <br />
        <asp:Button ID="BtnNuevoCliente" runat="server" Text="Agregar Cliente" OnClick="BtnNuevoCliente_Click" />
        <br />
        <br />
        Producto: 
        <asp:DropDownList ID="CmbProducto" runat="server"></asp:DropDownList>
        <br />
    </asp:Panel>
    <asp:Panel ID="PnlNuevoAsesor" runat="server" Visible="False">
        <h3>Agregar Asesor</h3>
        Nombre del asesor: 
        <asp:TextBox ID="TxtNombreAsesor" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="BtnGuardarAsesor" runat="server" Text="Guardar" OnClick="BtnGuardarAsesor_Click" />
        <asp:Button ID="BtnAtrasAsesor" runat="server" Text="Atrás" OnClick="BtnAtrasAsesor_Click" />
    </asp:Panel>
    <asp:Panel ID="PnlNuevoCliente" runat="server" Visible="False">
        <h3>Agregar Asesor</h3>
        Nombre del cliente: 
        <asp:TextBox ID="TxtNombreCliente" runat="server"></asp:TextBox>
        <br />
        Apellido del cliente: 
        <asp:TextBox ID="TxtApellidoCliente" runat="server"></asp:TextBox>
        <br />
        Cédula del cliente: 
        <asp:TextBox ID="TxtCedulaCliente" runat="server"></asp:TextBox>
        <br />
        Telefono del cliente: 
        <asp:TextBox ID="TxtTelefonoCliente" runat="server"></asp:TextBox>
        <br />
        Dirección del cliente: 
        <asp:TextBox ID="TxtDireccionCliente" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="BtnGuardarCliente" runat="server" Text="Guardar" OnClick="BtnGuardarCliente_Click" />
        <asp:Button ID="BtnAtrasCliente" runat="server" Text="Atrás" OnClick="BtnAtrasCliente_Click" />
    </asp:Panel>
    <br />
    <br />
    <asp:Button ID="BtnVenta" runat="server" Text="Generar Venta" OnClick="BtnVenta_Click" />
    <br />
    <h3>Ventas</h3>
    <asp:ListBox ID="LstVentas" runat="server"></asp:ListBox>
</asp:Content>
