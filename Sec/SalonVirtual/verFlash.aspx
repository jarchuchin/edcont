<%@ Page Language="VB" MasterPageFile="~/MPUsmart01.master" AutoEventWireup="false" CodeFile="verFlash.aspx.vb" Inherits="Sec_SalonVirtual_verFlash" title="Untitled Page" ValidateRequest="false" %>

<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>
<%@ Register src="Controles/displayBuscadores.ascx" tagname="displayBuscadores" tagprefix="uc22" %>
<%@ Register src="../Workbook/Controles/showadjuntos.ascx" tagname="showadjuntos" tagprefix="uc2" %>
<%@ Register src="Controles/displayComentarios.ascx" tagname="displayComentarios" tagprefix="uc3" %>
<%@ Register src="Controles/displayCuadritos.ascx" tagname="displayCuadritos" tagprefix="uc4" %>

<asp:Content ID="contentBreadCrumb" ContentPlaceHolderID="ContentPanelBreadcrumb" Runat="Server">
</asp:Content>

<asp:Content ID="contentIzquierdo" ContentPlaceHolderID="ContentPanelIzquierdo" Runat="Server">
    <uc1:MenuSalonVirtual ID="MenuSalonVirtual1" runat="server" />
</asp:Content>

<asp:Content ID="contentEdicion" ContentPlaceHolderID="ContentPanelEdicion" Runat="Server">
</asp:Content>

<asp:Content ID="contentCentral" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
	<div id="Caja">
		<asp:Panel ID="panelForo" runat="server" Width="770px" Height="500px" ScrollBars="Auto">
<asp:Image id="imagenClasificacion" runat="server"  Visible="False" />
<div style="height:10px; width:100%;" ></div>


    <asp:Label ID="lblTitulo" runat="server" CssClass="title-big" Text="Titulo actividad" ></asp:Label>
      <div style="height:10px; width:100%;" ></div> 

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
             
</asp:Panel>
                     <div style="height:25px; width:100%;" ></div>
                
                <uc4:displaycuadritos ID="displayCuadritos1" runat="server" />
                <div style="height:25px; width:100%;" ></div>
                 <uc3:displayComentarios ID="displayComentarios1" runat="server" />
                <div style="height:25px; width:100%;" ></div>


                <table style="width: 100%">
                    <tr>
                        <td style="width:220px; vertical-align:top;">  <asp:Panel ID="panelBuscadores" runat="server" ScrollBars="Auto" Width="220px" Height="250px">
                        <uc22:displayBuscadores ID="displayBuscadores1" runat="server" />
                        </asp:Panel>
                        
                            
                                </td>
                       <td style="width:220px; vertical-align:top;">
                           
                        <div id="Div1" >
                               
                                <asp:Panel ID="PanelEdicion" runat="server"  Visible="False">
                                               <asp:Button ID="btnEditarActividad" runat="server" Text="Editar flash" Width="180px" />
                                </asp:Panel>
                       </div>
                            
                            </td>
                        <td style="width:220px; vertical-align:top;">
                         </td>
                        <td style="width:220px;  vertical-align:top;">
                        
                        
                            </td>
                        <td style="">
                            </td>
                    </tr>
                </table>
                   
             
      
</div>

</asp:Content>
