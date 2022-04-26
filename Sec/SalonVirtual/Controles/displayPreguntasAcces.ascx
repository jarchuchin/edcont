<%@ Control Language="VB" AutoEventWireup="false" CodeFile="displayPreguntasAcces.ascx.vb" Inherits="Sec_SalonVirtual_Controles_displayPreguntasAcces" %>
 <div id="Caja"  style=" height:57px">

     <table style="width:100%;">
        <tr>
            <td style="width:53px; ">
                <asp:HyperLink ID="lnkSalon1" runat="server" ImageUrl="~/Images/pagina/iconQuestion.jpg" NavigateUrl="~/Sec/SalonVirtual/Preguntas.aspx"></asp:HyperLink>
            </td>
            <td>
                <asp:HyperLink ID="lnkSalon2" runat="server" 
                    text="Preguntas" NavigateUrl="~/Sec/SalonVirtual/Preguntas.aspx" CssClass="LigaRojoMenu"></asp:HyperLink><br />
                    <asp:Label ID="Label1" runat="server" CssClass="TextoDescripcionSalon" Text="Lista de preguntas generadas "></asp:Label>
           </td>
           
        </tr>
     </table>
     


</div>