<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayActividadesUnidad.ascx.vb" Inherits="Sec_Workbook_Controles_DisplayActividadesUnidad" %>


	<asp:Repeater ID="rptObjetos" runat="server">
		<ItemTemplate>
			
		        <asp:HyperLink ID="lnkObjeto" runat="server" Text='<%# eval("titulo") %>' NavigateUrl='<%# getUrl(cint(eval("idClasificacionItem")), cint(eval("idClasificacion")), cint(eval("idProc")), eval("procedencia"), cint(eval("idRoot"))) %>'></asp:HyperLink>
			  <div style="height:5px;"></div>
		</ItemTemplate>
	</asp:Repeater>
