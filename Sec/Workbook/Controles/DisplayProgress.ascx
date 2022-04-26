<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayProgress.ascx.vb" Inherits="Sec_Workbook_Controles_DisplayProgress" %>

<div class="panel">
	<div class="panel-heading">
		<h3 class="panel-title">
            <asp:Label ID="Label1" runat="server" Text="Avance y revisión"></asp:Label></h3>
	</div>
	<div class="panel-body">
					
		<!--Progress bars with labels-->
		<!--===================================================-->
		

        <asp:Literal ID="litProgreso" runat="server"></asp:Literal>
		
		<!--===================================================-->



        <asp:HyperLink ID="lnkverdetalle" runat="server"  Text="ver detalle" CssClass="btn-link pull-right"></asp:HyperLink>

	</div>
</div>
<asp:Label ID="lblCarpetas" runat="server" Text="3" Visible="False"></asp:Label>
<asp:Label ID="lblContenidos" runat="server" Text="6" Visible="False"></asp:Label>
<asp:Label ID="lblForos" runat="server" Text="2" Visible="False"></asp:Label>
<asp:Label ID="lblActividades" runat="server" Text="3" Visible="False"></asp:Label>
<asp:Label ID="lblExamenes" runat="server" Text="3" Visible="False"></asp:Label>
                        
