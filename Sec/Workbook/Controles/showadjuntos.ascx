<%@ Control Language="VB" AutoEventWireup="false" CodeFile="showadjuntos.ascx.vb" Inherits="Sec_Workbook_Controles_showadjuntos" %>




<div class="panel" id="panelBox" runat="server">
    <div class="panel-heading">
            <h3 class="panel-title"><asp:Label ID="lblTitulo" runat="server" Text=""></asp:Label></h3>
    </div>
    <div class="panel-body">
       
        <asp:ListView ID="listViewAdjuntos" runat="server">
        
		<LayoutTemplate>
			<asp:PlaceHolder ID="itemPlaceholder" runat="server" />
		</LayoutTemplate>
		<ItemTemplate>
			<asp:PlaceHolder ID="holder" runat="server"></asp:PlaceHolder>
		</ItemTemplate>
		<EmptyDataTemplate>
			
		</EmptyDataTemplate>
	</asp:ListView>


    </div>
</div>


<asp:Label ID="lblprueba" runat="server" Text="aqui" ForeColor="Red" Visible ="false"></asp:Label>