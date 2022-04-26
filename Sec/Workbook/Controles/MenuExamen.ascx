<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MenuExamen.ascx.vb" Inherits="Sec_Workbook_Controles_MenuExamen" %>
<asp:Panel ID="Panel1" runat="server">
<asp:HyperLink ID="lnkExamen" CssClass="Mediana" Font-Bold="True" runat="server"></asp:HyperLink> 
    &nbsp;<asp:Label ID="label1" runat="server" CssClass="Mediana">\</asp:Label>
    &nbsp;<asp:HyperLink ID="lnkLista" CssClass="Mediana" Font-Bold="True" runat="server">Ver lista de preguntas</asp:HyperLink>  
    &nbsp;<asp:Label ID="label2" runat="server" CssClass="Mediana" Visible="false" >\</asp:Label>
    &nbsp;<asp:Label ID="lblpreguntaactual" runat="server" CssClass="Mediana"></asp:Label>
</asp:Panel>
