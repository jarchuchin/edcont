<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayObjetosAprendizaje.ascx.vb" Inherits="Sec_Workbook_Controles_DisplayObjetosAprendizaje" %>
<div class="cajaControlColLateral">
	<h3>OBJETOS GUARDADOS</h3>
	<asp:Repeater ID="rptObjetos" runat="server">
		<ItemTemplate>
			
				<asp:HyperLink ID="lnkObjeto" runat="server"   Text='<%# eval("titulo") %>' NavigateUrl='<%# getUrl(cint(eval("idClasificacionItem")), cint(eval("idClasificacion")), cint(eval("idProc")), eval("procedencia"), cint(eval("idRoot"))) %>'></asp:HyperLink>
	        <div style=" height:5px;"></div>
		</ItemTemplate>
	</asp:Repeater>
	<asp:Label ID="lblNoData" runat="server" Text="No hay objetos actualmente en esta sección" Visible="false" CssClass="textoNoData12"></asp:Label>
</div>