<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayVerImagen.ascx.vb" Inherits="Sec_Workbook_Controles_DisplayVerImagen" %>


<asp:Panel ID="panelContenidos" runat="server" Visible="false">

    
         
<div class="row">
	<div class="col-xs-9">
		<div class="panel">

            <div class="panel-heading">
           
                 <h3 class="panel-title">
                       <asp:Label ID="lblnombreoriginal2" runat="server" Text=""></asp:Label>
                     </h3>
            </div>
			
             <div class="panel-body">

    
 <asp:literal ID="litdescripcion" runat="server"></asp:literal><br />
                   <asp:Label ID="lblNombreOriginal" runat="server" Text=""></asp:Label><br /><br />
                   
                     <asp:Image ID="imgfoto" runat="server" Width="200px" />
                   
                    <br />
                   
                    <asp:HyperLink ID="lnkDescargar" CssClass="btn-link" runat="server">Descargar</asp:HyperLink><br />
                    <asp:Label ID="lblbites" runat="server" Text=""></asp:Label>  


                 </div>
            </div>

        </div>
    </div>

    <div style="page-break-after: always"></div>
    </asp:Panel>