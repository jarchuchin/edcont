<%@ Page Title="" Language="VB" MasterPageFile="~/MPUsmart01.master" AutoEventWireup="false" CodeFile="nopermiso.aspx.vb" Inherits="Sec_Workbook_nopermiso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelBreadcrumb" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelIzquierdo" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPanelEdicion" Runat="Server">
        <div style=" height:150px;"></div>
    <div style=" width:100%; text-align:center;"><asp:Label ID="lblMensaje" runat="server" Text="El usuario no tiene permisos para editar este libro de trabajo" ForeColor="Red"></asp:Label></div>
    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
</asp:Content>

