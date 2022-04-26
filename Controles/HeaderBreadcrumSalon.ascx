<%@ Control Language="VB" AutoEventWireup="false" CodeFile="HeaderBreadcrumSalon.ascx.vb" Inherits="Controles_HeaderBreadcrumSalon" %>
Estás en:
<asp:HyperLink ID="lnkPaginaPrincipalCurso" runat="server" NavigateUrl="~/Sec/SalonVirtual/Default.aspx?idSalonVirtual=">Curso</asp:HyperLink> /
<asp:HyperLink ID="lnkClasificacion" runat="server" NavigateUrl="~/Sec/SalonVirtual/VerCarpeta.aspx">Unidad</asp:HyperLink> /
<asp:Label ID="lblUbicacion" runat="server">Contenidos</asp:Label>
<asp:HiddenField ID="hiddenIdClasificacion" runat="server" />
