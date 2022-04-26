<%@ Control Language="VB" AutoEventWireup="false" CodeFile="displayIntroduccion.ascx.vb" Inherits="Sec_SalonVirtual_Controles_displayIntroduccion" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<div class="contenido">
	<asp:Label ID="lblTitulo" runat="server" CssClass="TituloCaja" Text=""></asp:Label>

	<asp:Panel ID="Panel1" runat="server">
		<asp:Literal ID="litTexto" runat="server"></asp:Literal>
		<asp:TreeView ID="tvFolders" runat="server" ExpandDepth="0" PopulateNodesFromClient="true" ShowLines="true">
			<NodeStyle HorizontalPadding="5px" CssClass="LigaGris" />
			<LeafNodeStyle HorizontalPadding="5px" CssClass="LigaGris" />
		</asp:TreeView>
	</asp:Panel>
</div>
<asp:HiddenField ID="hdRoot" runat="server" />
<asp:HiddenField ID="hdSalon" runat="server" />