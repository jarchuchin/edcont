<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayExploradorContenidos.ascx.vb" Inherits="Sec_SalonVirtual_Controles_DisplayExploradorContenidos" %>
<div class="subTitulo">ÍNDICE</div>
<div class="liga">
</div>
<div class="contenido">
	<asp:TreeView ID="tvFolders" runat="server" ExpandDepth="0" PopulateNodesFromClient="true" ShowLines="true">
		<NodeStyle HorizontalPadding="5px" CssClass="LigaGris" />
		<LeafNodeStyle HorizontalPadding="5px" CssClass="LigaGris" />
	</asp:TreeView>
</div>
