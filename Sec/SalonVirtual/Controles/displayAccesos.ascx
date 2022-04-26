<%@ Control Language="VB" AutoEventWireup="false" CodeFile="displayAccesos.ascx.vb" Inherits="Sec_SalonVirtual_Controles_displayAccesos" %>
 
 <div id="Caja"  style=" height:57px">

     <table style="width:100%;">
        <tr>
            <td style="width:53px; ">
                <asp:HyperLink ID="lnkSalon1" runat="server" ImageUrl="~/Images/pagina/iconAcceso.jpg" NavigateUrl="~/Sec/SalonVirtual/Accesos.aspx"></asp:HyperLink>
            </td>
            <td>
                <asp:HyperLink ID="lnkSalon2" runat="server" 
                    text="Accesos al curso" NavigateUrl="~/Sec/SalonVirtual/Accesos.aspx" CssClass="LigaRojoMenu"></asp:HyperLink><br />
                    <asp:Label ID="Label1" runat="server" CssClass="TextoDescripcionSalon" Text="Hoy:"></asp:Label>&nbsp;
                    <asp:Label ID="lblAccesosDia" runat="server" CssClass="TextoDescripcionNumero"  Font-Bold="true" ></asp:Label><br />
                    <asp:Label ID="Label2" runat="server" CssClass="TextoDescripcionSalon" Text="Semanal:"></asp:Label>&nbsp;
                    <asp:Label ID="lblAccesossemana" runat="server" CssClass="TextoDescripcionNumero"  Font-Bold="true" ></asp:Label><br />
           </td>
           
        </tr>
     </table>
     


</div>

