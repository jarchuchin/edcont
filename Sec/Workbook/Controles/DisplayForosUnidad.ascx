<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayForosUnidad.ascx.vb" Inherits="Sec_Workbook_Controles_DisplayForosUnidad" %>
<asp:Label ID="Label2" runat="server" Text="Foros guardados" Font-Bold="true"> </asp:Label>
  <div style="height:10px;"></div>
<asp:Repeater ID="rptObjetos" runat="server">
    <ItemTemplate>
        <asp:HyperLink ID="lnkObjeto" runat="server"   Text='<%# eval("titulo") %>' NavigateUrl='<%# getUrl(cint(eval("idClasificacionItem")), cint(eval("idClasificacion")), cint(eval("idProc")), eval("procedencia"), cint(eval("idRoot"))) %>'></asp:HyperLink>
        <div style="height:5px;"></div>
    </ItemTemplate>
</asp:Repeater>
                                       
 <asp:HyperLink ID="lnkObjetoAgregar" runat="server"   Text="Agregar foro" ></asp:HyperLink>
        <div style="height:5px;"></div>
<div style="height:400px;"></div>