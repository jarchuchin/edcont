<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayVerFlash.ascx.vb" Inherits="Sec_Workbook_Controles_DisplayVerFlash" %>


<asp:Panel ID="panelContenidos" runat="server" Visible="false" >


    
         
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
<asp:Label ID="lblNombreOriginal" runat="server" Text=""></asp:Label><br />
<asp:HyperLink ID="lnkDescargar" runat="server">Descargar</asp:HyperLink><br />
<asp:Label ID="lblbites" runat="server" Text=""></asp:Label>
<br />
<br />
<br />
<asp:literal ID="litflas" runat="server"></asp:literal>
<asp:TextBox id="txtbase" runat="server" TextMode="MultiLine" Visible="False">
    &lt;object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' id='33476' width='cancho' height='calto'&gt;
&lt;param name="movie" value='pelicula'/&gt;
&lt;param name='quality' value='high'/&gt;
&lt;embed src='pelicula' width='cancho' height='calto'  quality='high'  type='application/x-shockwave-flash'&gt;
&lt;/embed&gt;
&lt;/object&gt;
</asp:TextBox>




                 </div>
            </div>

        </div>
    </div>



      <div style="page-break-after: always"></div>

    </asp:Panel>