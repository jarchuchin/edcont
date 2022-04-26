<%@ Page Language="VB" MasterPageFile="~/MPUsmart01.master" AutoEventWireup="false" CodeFile="MensajeError.aspx.vb" Inherits="Sec_SalonVirtual_MensajeError" title="Untitled Page" %>

<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>

<asp:Content ID="contentBreadCrumb" ContentPlaceHolderID="ContentPanelBreadcrumb" Runat="Server">
</asp:Content>

<asp:Content ID="contentIzquierdo" ContentPlaceHolderID="ContentPanelIzquierdo" Runat="Server">
    <uc1:MenuSalonVirtual ID="MenuSalonVirtual1" runat="server" />
</asp:Content>

<asp:Content ID="contentEdicion" ContentPlaceHolderID="ContentPanelEdicion" Runat="Server">
</asp:Content>

<asp:Content ID="contentCentral" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
	<div id="Caja">
		<div id="CajaInterna">
    <asp:Label ID="Label1" runat="server" Font-Size="12px" ForeColor="Red" 
        Text="El mensaje de confirmación para el alumno no ha sido enviado. El alumno debe configurar su cuenta de correo. "></asp:Label>
    </div>
</div>
</asp:Content>

