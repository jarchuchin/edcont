<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayListaObjetos.ascx.vb" Inherits="Sec_Workbook_Controles_DisplayListaObjetos" %>
<div class="cajaControlColLateral">
	<h3><asp:Label ID="lblTitulo" runat="server" Text=""></asp:Label></h3>
	<asp:ListView ID="listViewObjetos" runat="server">
		<LayoutTemplate>
			<div style="margin-bottom:5px;">
				<asp:PlaceHolder ID="itemPlaceholder" runat="server" />
			</div>
		</LayoutTemplate>
		<ItemTemplate>
	        <asp:HyperLink ID="lnkObjeto" runat="server" Text='<%# eval("titulo") %>' NavigateUrl='<%# getUrl(cint(eval("idClasificacionItem")), cint(eval("idClasificacion")), cint(eval("idProc")), eval("procedencia"), cint(eval("idRoot"))) %>'></asp:HyperLink>
              <div style="height:3px;"></div>
		</ItemTemplate>
      
		<EmptyDataTemplate>
			<asp:Label ID="lblNoData" runat="server" Text="Sin datos actualmente en esta sección" CssClass="textoNoData12"></asp:Label>
		</EmptyDataTemplate>
	</asp:ListView>
	<div style="text-align:right;">
		<asp:Button ID="btnAgregar" runat="server" Text="agregar" CssClass="button" CausesValidation="false" />
	</div>
</div>
<asp:HiddenField ID="hiddenTipo" runat="server" />
<asp:HiddenField ID="hiddenPaginaDestino" runat="server" />
<asp:HiddenField ID="hiddenEsExamen" runat="server" />