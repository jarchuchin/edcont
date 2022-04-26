<%@ Control Language="VB" AutoEventWireup="false" CodeFile="displayCuadritos.ascx.vb" Inherits="Sec_SalonVirtual_Controles_displayCuadritos" %>


<table cellpadding="0" cellspacing="0" style="width: 700px;">
    <tr>
       
        <td style="">
            <asp:DataList ID="dtlContenidos" runat="server" RepeatDirection="Horizontal" 
                RepeatColumns="15">
    <ItemTemplate>
        <div class='<%# getClase(cint(eval("idClasificacionItem")))%>'>
        <div style="height:8px"></div>
            <asp:HyperLink ID="lnkContenido"   CssClass="LigaCuadrito" runat="server"  NavigateUrl='<%# getLiga(cint(eval("idClasificacionItem")))%>'  ToolTip='<%# Nombre  %>' Text='<%# Numero  %>' Font-Bold='<%# MostrarBold %>'></asp:HyperLink>
        </div>
    </ItemTemplate>
</asp:DataList></td> 
        <td style=" width:50px; vertical-align:top;"></td>
        <td style=" width:30px; vertical-align:top;">
         <div class="CuadritoContenido">
            <div style="height:8px"></div>
                <asp:HyperLink ID="lnkAnterior"   CssClass="LigaCuadrito" runat="server" Font-Bold="true"  ToolTip="Anterior" Text="<<" ></asp:HyperLink>
        </div>
        
        </td>
        <td style=" width:2px; vertical-align:top;"></td>
        <td  style=" width:30px; vertical-align:top;">
            <div class="CuadritoContenido">
            <div style="height:8px"></div>
                <asp:HyperLink ID="lnkSiguiente" CssClass="LigaCuadrito" runat="server"  Font-Bold="true"  ToolTip="Siguiente" Text=">>" ></asp:HyperLink>
            </div>
        </td> 
      
    </tr>
</table>
