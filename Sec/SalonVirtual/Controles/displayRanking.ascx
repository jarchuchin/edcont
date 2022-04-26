<%@ Control Language="VB" AutoEventWireup="false" CodeFile="displayRanking.ascx.vb" Inherits="Sec_SalonVirtual_Controles_DisplayRanking" %>
<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
	<TR>
		<TD vAlign="bottom" colSpan="2">
			<BR>
			<TABLE id="Table1" cellSpacing="1" cellPadding="0" width="100" border="0">
				<TR>
					<TD align="center" vAlign="bottom">
						<asp:Image id="Image1" runat="server" Width="12px" ImageUrl="~/Images/barritaRanking.jpg"></asp:Image></TD>
					<TD align="center" vAlign="bottom">
						<asp:Image id="Image2" runat="server" Width="12px" ImageUrl="~/Images/barritaRanking.jpg"></asp:Image></TD>
					<TD align="center" vAlign="bottom">
						<asp:Image id="Image3" runat="server" Width="12px" ImageUrl="~/Images/barritaRanking.jpg"></asp:Image></TD>
					<TD align="center" vAlign="bottom">
						<asp:Image id="Image4" runat="server" Width="12px" ImageUrl="~/Images/barritaRanking.jpg"></asp:Image></TD>
					<TD align="center" vAlign="bottom">
						<asp:Image id="Image5" runat="server" Width="12px" ImageUrl="~/Images/barritaRanking.jpg"></asp:Image></TD>
					<TD align="center" vAlign="bottom">
						<asp:Image id="Image6" runat="server" Width="12px" ImageUrl="~/Images/barritaRanking.jpg"></asp:Image></TD>
					<TD align="center" vAlign="bottom">
						<asp:Image id="Image7" runat="server" Width="12px" ImageUrl="~/Images/barritaRanking.jpg"></asp:Image></TD>
					<TD align="center" vAlign="bottom">
						<asp:Image id="Image8" runat="server" Width="12px" ImageUrl="~/Images/barritaRanking.jpg"></asp:Image></TD>
					<TD align="center" vAlign="bottom">
						<asp:Image id="Image9" runat="server" Width="12px" ImageUrl="~/Images/barritaRanking.jpg"></asp:Image></TD>
					<TD align="center" vAlign="bottom">
						<asp:Image id="Image10" runat="server" Width="12px" ImageUrl="~/Images/barritaRanking.jpg"></asp:Image></TD>
				</TR>
				<TR>
					<TD class="Chica" align="center">1</TD>
					<TD class="Chica" align="center">2</TD>
					<TD class="Chica" align="center">3</TD>
					<TD class="Chica" align="center">4</TD>
					<TD class="Chica" align="center">5</TD>
					<TD class="Chica" align="center">6</TD>
					<TD class="Chica" align="center">7</TD>
					<TD class="Chica" align="center">8</TD>
					<TD class="Chica" align="center">9</TD>
					<TD class="Chica" align="center">10</TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
	<TR>
		<TD colspan="2">
		<asp:Label id="lblPersonas" runat="server" CssClass="Chica" 
                Text="Numero de personas que han calificado la actividad: " Font-Bold="True"></asp:Label>
			&nbsp;<asp:Label id="lblNumeroPersonas" runat="server" CssClass="Mediana"></asp:Label></TD>
		
	</TR>
	<tr>
	<TD colspan="2">
			<asp:Label id="lblMensaje" runat="server" CssClass="Chica"></asp:Label></TD>
	</tr>
</TABLE>
