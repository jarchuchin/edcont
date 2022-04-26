<%@ Control Language="VB" AutoEventWireup="false" CodeFile="UbicadorPreguntas.ascx.vb" Inherits="Sec_SalonVirtual_Controles_UbicadorPreguntas" %>
<table cellspacing="1" cellpadding="1" border="0">
<tr>
	<td style="width:10px; vertical-align:middle;"><asp:HyperLink id="lnkLista" ImageUrl="~/Images/gralindex.gif" runat="server" ToolTip="Lista de preguntas" ></asp:HyperLink></td>
	<td style="width:10px; vertical-align:middle;"><asp:HyperLink id="lnkInicio" runat="server" ImageUrl="~/Images/exainicio.gif" ToolTip="Iniciar examen"></asp:HyperLink></td>
	<td style="width:10px; vertical-align:middle;">
		<asp:DataList id="DataList1" runat="server" RepeatDirection="Horizontal" RepeatColumns="30" Height="16px" Width="10px">
			<ItemTemplate >
				<asp:Label id="lblidPregunta" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "idPregunta")%>' Visible="False"></asp:Label>
				<asp:Label id="lblIdTipo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "tipoPregunta")%>' Visible="False"></asp:Label>
			</ItemTemplate>
		</asp:DataList>
	</td>
	<td style="width:10px; vertical-align:middle;"><asp:HyperLink id="lnkFin" runat="server" ImageUrl="~/Images/exafin.gif" ToolTip="Finalizar examen"></asp:HyperLink></td>
</tr>
</table>
