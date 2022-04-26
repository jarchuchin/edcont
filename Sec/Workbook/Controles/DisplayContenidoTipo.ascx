<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayContenidoTipo.ascx.vb" Inherits="Sec_Workbook_Controles_DisplayContenidoTipo" %>




    <div  class="list-group">     
        <a href="#" class="list-group-item disabled"><asp:Label ID="lbltitulogrupo" runat="server" meta:resourcekey="lbltitulogrupoResource1" ></asp:Label></a>
        <asp:Repeater ID="rptDatos" runat="server">
               <ItemTemplate>
                   
                  <asp:HyperLink ID="lnkPortal1" runat="server" cssClass="list-group-item"  NavigateUrl='<%# getLinkAnexos(Eval("idRoot"), Eval("idClasificacionItem"), Eval("tipoAnexo"), Eval("idTipo")) %>' ><asp:Image ID="Image1" runat="server" ImageUrl='<%# getImagen(Eval("idTipo"), Eval("extension"), Eval("tipoAnexo")) %>'  Width="25px"   />
 &nbsp; <%# Eval("titulo") %></asp:HyperLink>
               </ItemTemplate>
        </asp:Repeater>
    </div>





<asp:Label ID="Label1" runat="server" Text="Contenidos"  Visible="False" meta:resourcekey="Label1Resource1"></asp:Label>
<asp:Label ID="Label2" runat="server" Text="Actividades"  Visible="False" meta:resourcekey="Label2Resource1"></asp:Label>
<asp:Label ID="Label3" runat="server" Text="Exámenes"  Visible="False" meta:resourcekey="Label3Resource1"></asp:Label>
<asp:Label ID="Label4" runat="server" Text="Foros"  Visible="False" meta:resourcekey="Label4Resource1"></asp:Label>

<asp:HiddenField ID="HiddenTipo" runat="server" />
<asp:HiddenField ID="HiddenidRoot" runat="server" />
<asp:HiddenField ID="hiddenIdClasificacion" runat="server" />