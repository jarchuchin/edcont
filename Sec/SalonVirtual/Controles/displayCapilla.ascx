<%@ Control Language="VB" AutoEventWireup="false" CodeFile="displayCapilla.ascx.vb" Inherits="Sec_SalonVirtual_Controles_displayCapilla" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


  <div class="panel">
   <div class="panel-heading">
          <div class="panel-control" style="text-align:right">
             
                  <asp:HyperLink ID="lnknuevo" runat="server" CssClass="btn btn-primary btn-sm" Text="Publicar"></asp:HyperLink>
            </div>
               <h3 class="panel-title"><asp:Label ID="Label3" runat="server" Text="Capilla virtual"></asp:Label></h3>
     
           
    </div>
    <div class="panel-body">
      
	<asp:DataList id="DataList1" runat="server" Width="100%">
		<ItemTemplate>
		
			
               <div class="media">
              <div class="media-left">
                  <asp:Image id="Image1" runat="server" Width="64px" class="media-object"  ImageUrl='<%# getImagen(Eval("imagen"), Eval("claveAux1"), CInt(Eval("idUserProfile"))) %>' />
              </div>
              <div class="media-body">
       
                <asp:Label id="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Texto") %>'></asp:Label>
                <div style="height:4px;"></div>

                <asp:Label id="Label3" runat="server" Font-Italic="true" Font-Bold="true"  Font-Size="11px"  Text='<%# DataBinder.Eval(Container.DataItem, "Nombre") %>' ></asp:Label>&nbsp;
		        <asp:Label id="Label4" runat="server" Font-Italic="true" Font-Bold="true" Font-Size="11px"  Text='<%# DataBinder.Eval(Container.DataItem, "fecha", "{0:F}")  %>'></asp:Label>
                <div style="height:4px;"></div>
		        <asp:HyperLink  ID="HyperLink1" Visible='<%# presentar(CInt(Eval("idUserProfile"))) %>' NavigateUrl='<%# "~/sec/SalonVirtual/Capilla.aspx?idSalonVirtual=" & Eval("idSalonVirtual") & "&idSalonVirtualCapilla=" & Eval("idSalonVirtualCapilla") %>' runat="server" >
                <span class="badge badge-success"><asp:Literal ID="Literal1" runat="server" Text="Editar"></asp:Literal></span>
		        </asp:HyperLink>


              </div>
            </div>

		</ItemTemplate>
	</asp:DataList>


<div class="row">
    <div class="col-xs-6 text-left"><asp:HyperLink ID="lnkvertodos" runat="server" CssClass="btn-link">Ver Todos</asp:HyperLink></div>
   <%-- <div class="col-xs-6 text-right"><asp:HyperLink ID="lnknuevo" runat="server" CssClass="btn-link">Publicar</asp:HyperLink></div>--%>
</div>
	              
    </div>
</div>





