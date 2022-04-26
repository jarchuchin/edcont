<%@ Control Language="VB" AutoEventWireup="false" CodeFile="displayExamenes.ascx.vb" Inherits="Sec_SalonVirtual_Controles_displayExamenes" %>
   <div class="panel">
        <div class="panel-heading">
                <h3 class="panel-title"><asp:Label ID="Label2" runat="server" Text="Examenes"></asp:Label></h3>
        </div>
        <div class="panel-body">

	        <asp:Repeater ID="rptObjetos" runat="server">
		        <ItemTemplate>
                    <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/bull-arrow3.png" />
		                <asp:HyperLink ID="lnkObjeto" runat="server" CssClass="btn-link" Text='<%#Eval("titulo") %>' NavigateUrl='<%# getUrl(CInt(Eval("idClasificacionItem")), CInt(Eval("idClasificacion")), CInt(Eval("idProc")), Eval("procedencia"), CInt(Eval("idRoot"))) %>'></asp:HyperLink>
			          <div style="height:5px;"></div>
		        </ItemTemplate>
	        </asp:Repeater>
        </div>
   </div>