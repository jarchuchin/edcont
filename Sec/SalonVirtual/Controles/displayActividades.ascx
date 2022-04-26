<%@ Control Language="VB" AutoEventWireup="false" CodeFile="displayActividades.ascx.vb" Inherits="Sec_SalonVirtual_Controles_displayActividades" %>


   <div class="panel">
        <div class="panel-heading">
                <h3 class="panel-title"><asp:Label ID="Label2" runat="server" Text="Actividades"></asp:Label></h3>
        </div>
        <div class="panel-body">

	        <asp:Repeater ID="rptObjetos" runat="server">
		        <ItemTemplate>
                        <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/bull-arrow3.png" />
		                <asp:HyperLink ID="lnkObjeto" runat="server" Text='<%# eval("titulo") %>' NavigateUrl='<%# getUrl(cint(eval("idClasificacionItem")), cint(eval("idClasificacion")), cint(eval("idProc")), eval("procedencia"), cint(eval("idRoot"))) %>' CssClass="btn-link"></asp:HyperLink>
			          <div style="height:5px;"></div>
		        </ItemTemplate>
	        </asp:Repeater>
        </div>
   </div>