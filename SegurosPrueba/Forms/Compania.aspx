<%@ Page Title="Compañia" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="Compania.aspx.cs" Inherits="SegurosPrueba.Compania" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID="PnlListas" runat="server">
        <h3>Compañías</h3>
        <asp:ListBox ID="LstCompanias" runat="server" OnSelectedIndexChanged="LstCompanias_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox>
        <br />
        <asp:Button ID="BtnNuevaCompania" runat="server" Text="Agregar Compañía" OnClick="BtnNuevaCompania_Click" />

        <h3>Productos</h3>
        <asp:ListBox ID="LstProductos" runat="server"></asp:ListBox>
        <br />
        <asp:Button ID="BtnNuevoProducto" runat="server" Text="Agregar Producto" OnClick="BtnNuevoProducto_Click" />
        <asp:Button ID="BtnEditarProducto" runat="server" Text="Modificar Producto" OnClick="BtnEditarProducto_Click" />
    </asp:Panel>
    <asp:Panel ID="PnlNuevaCompania" runat="server" Visible="False">
        <h3>Agregar Compañía</h3>
        Nombre de la compañía: 
        <asp:TextBox ID="TxtNombreCompania" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="BtnGuardarCompania" runat="server" Text="Guardar" OnClick="BtnGuardarCompania_Click" />
        <asp:Button ID="BtnAtrasCompania" runat="server" Text="Atrás" OnClick="BtnAtrasCompania_Click" />
    </asp:Panel>
    <asp:Panel ID="PnlNuevoProducto" runat="server" Visible="False">
        <h3>Agregar Producto</h3>
        <asp:HiddenField ID="HddIdProducto" runat="server" />
        Nombre de la producto: 
        <asp:TextBox ID="TxtNombreProducto" runat="server"></asp:TextBox>
        <br />
        Prima: 
        <asp:TextBox ID="TxtPrima" runat="server"></asp:TextBox>
        <br />
        Cobertura: 
        <asp:TextBox ID="TxtCobertura" runat="server"></asp:TextBox>
        <br />
        Asistencia: 
        <asp:TextBox ID="TxtAsistencia" runat="server"></asp:TextBox>
        <br />
        Compañía: 
        <asp:DropDownList ID="CmbCompania" runat="server"></asp:DropDownList>
        <br />
        <asp:Button ID="BtnGuardarProducto" runat="server" Text="Guardar" OnClick="BtnGuardarProducto_Click" />
        <asp:Button ID="BtnAtrasProducto" runat="server" Text="Atrás" OnClick="BtnAtrasProducto_Click" />
    </asp:Panel>

</asp:Content>
