<%@ Page Language="VB" MasterPageFile="~/MPUsmart01.master" AutoEventWireup="false" CodeFile="ContestarExamen.aspx.vb" Inherits="Sec_SalonVirtual_ContestarExamen" title="Contestar examen" ValidateRequest="false" %>

<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>

<asp:Content ID="contentBreadCrumb" ContentPlaceHolderID="ContentPanelBreadcrumb" Runat="Server">
</asp:Content>

<asp:Content ID="contentIzquierdo" ContentPlaceHolderID="ContentPanelIzquierdo" Runat="Server">
    <uc1:MenuSalonVirtual ID="MenuSalonVirtual1" runat="server" />
</asp:Content>

<asp:Content ID="contentEdicion" ContentPlaceHolderID="ContentPanelEdicion" Runat="Server">
</asp:Content>

<asp:Content ID="contentCentral" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
</asp:Content>

