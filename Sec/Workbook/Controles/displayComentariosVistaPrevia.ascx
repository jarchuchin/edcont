<%@ Control Language="VB" AutoEventWireup="false" CodeFile="displayComentariosVistaPrevia.ascx.vb" Inherits="Sec_Workbook_Controles_displayComentariosVistaPrevia" %>
<table style=" width:100%">
<tr>
	<td>
	    <asp:Label ID="Label5" runat="server" Text="Promedio: "></asp:Label>
		<asp:Image ID="Image3" runat="server" ImageUrl="~/Images/UserRating3.jpg" /><br />
	    <asp:LinkButton ID="lnkComentario" runat="server" CausesValidation="false" Enabled="false" CssClass="btn-link">Agregar comentario</asp:LinkButton>
	</td>
</tr>
</table>

<asp:Label ID="lblTagCalificacion" runat="server" Text="Calificación" CssClass="texto12B"></asp:Label>
<asp:RadioButtonList ID="rbdCalificacion" runat="server"  RepeatDirection="Horizontal" CssClass="Mediana">
	<asp:ListItem Value="1" Text="1"></asp:ListItem> 
	<asp:ListItem Value="2" Text="2"></asp:ListItem> 
	<asp:ListItem Value="3" Text="3"></asp:ListItem> 
	<asp:ListItem Value="4" Text="4"></asp:ListItem> 
	<asp:ListItem Value="5" Text="5"></asp:ListItem>  
</asp:RadioButtonList><br />
        
<asp:Label ID="lblTagComentario" runat="server" Text="Comentario:" CssClass="texto12B"></asp:Label><br />
<asp:TextBox ID="txtComentario" runat="server" Height="87px" TextMode="MultiLine" Width="385px"></asp:TextBox><br /><br />

     <div style="height:10px;"></div>


<asp:Button ID="btnEnviar" runat="server" Text="Enviar" CausesValidation="false"  CssClass="btn btn-success" Enabled="false" />&nbsp;
<asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CausesValidation="false"  CssClass="btn btn-default" Enabled="false" />

<%--<asp:Label ID="Label3" runat="server" CssClass="texto12B" Text="Fulano de tal"></asp:Label>&nbsp;
<asp:Label ID="Label4" runat="server" CssClass="texto11" Text="20/jul/2012"></asp:Label><br />
<asp:Image ID="Image1" runat="server" ImageUrl="~/Images/UserRating4.jpg" /><br />
<div>
	Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed ut facilisis dui. Duis in eros ipsum. Pellentesque commodo justo in lorem lacinia sit amet rutrum lectus cursus. Nullam ac mauris arcu.<br />
	In dapibus justo at eros venenatis faucibus. Phasellus blandit elementum massa, pretium accumsan mauris feugiat eu. Donec mauris elit, porttitor quis tempus hendrerit.
</div>
   
<asp:Label ID="Label1" runat="server" CssClass="texto12B" Text="Perengano de tal"></asp:Label>&nbsp;
<asp:Label ID="Label2" runat="server" CssClass="texto11" Text="21/jul/2012"></asp:Label><br />
<asp:Image ID="Image2" runat="server" ImageUrl="~/Images/UserRating2.jpg" /><br />
<div>
	Donec risus magna, rhoncus eu interdum euismod, molestie nec magna.
</div>--%>
