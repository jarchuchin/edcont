<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MenuAdministracion.ascx.vb" Inherits="Sec_Administracion_Controles_MenuAdministracion" %>






<table width="96%" border="0" cellpadding="0" cellspacing="5" class="box-brdr-botom-blue">
    <tr>
        <td width="45" align="right" scope="row"><asp:HyperLink ID="lnkUsuarios2" runat="server" ImageUrl="~/Images/bull-left2.png" NavigateUrl="~/Sec/Administracion/Default.aspx"></asp:HyperLink></td>
        <td><asp:HyperLink ID="lnkUsuarios3" runat="server" text="Administración de usuarios" NavigateUrl="~/Sec/Administracion/Default.aspx" CssClass="txt-left"></asp:HyperLink></td>
    </tr>
</table>


<asp:Panel ID="panelPermisos" runat="server" Visible="false" >



<table width="96%" border="0" cellpadding="0" cellspacing="5" class="box-brdr-botom-blue">
    <tr>
        <td width="45" align="right" scope="row"><asp:HyperLink ID="lnkPermisos2" runat="server" ImageUrl="~/Images/bull-left2.png" NavigateUrl="~/Sec/Administracion/Permisos.aspx"></asp:HyperLink></td>
        <td><asp:HyperLink ID="lnkPermisos3" runat="server" text="Permisos" NavigateUrl="~/Sec/Administracion/Permisos.aspx" CssClass="txt-left"></asp:HyperLink></td>
    </tr>
</table>

</asp:Panel>



<asp:Panel ID="panelsalones" runat="server" Visible="false" >

<table width="96%" border="0" cellpadding="0" cellspacing="5" class="box-brdr-botom-blue">
    <tr>
        <td width="45" align="right" scope="row"><asp:HyperLink ID="lnksalones2" runat="server" ImageUrl="~/Images/bull-left2.png" NavigateUrl="~/Sec/Administracion/salones.aspx"></asp:HyperLink></td>
        <td><asp:HyperLink ID="lnksalones3" runat="server" text="Salones" NavigateUrl="~/Sec/Administracion/salones.aspx" CssClass="txt-left"></asp:HyperLink></td>
    </tr>
</table>

</asp:Panel>




<asp:Panel ID="panellibros" runat="server" Visible="true" >



<table width="96%" border="0" cellpadding="0" cellspacing="5" class="box-brdr-botom-blue">
    <tr>
        <td width="45" align="right" scope="row"><asp:HyperLink ID="HyperLink2" runat="server" ImageUrl="~/Images/bull-left2.png" NavigateUrl="~/Sec/Administracion/libros.aspx"></asp:HyperLink></td>
        <td><asp:HyperLink ID="HyperLink3" runat="server" text="Libros de trabajo" NavigateUrl="~/Sec/Administracion/libros.aspx" CssClass="txt-left"></asp:HyperLink></td>
    </tr>
</table>

</asp:Panel>



<asp:Panel ID="panelConfiguracion" runat="server" Visible="true" >



<table width="96%" border="0" cellpadding="0" cellspacing="5" class="box-brdr-botom-blue">
    <tr>
        <td width="45" align="right" scope="row"><asp:HyperLink ID="lnkconf1" runat="server" ImageUrl="~/Images/bull-left2.png" NavigateUrl="~/Sec/Administracion/ConfiguracionGeneral.aspx"></asp:HyperLink></td>
        <td><asp:HyperLink ID="lnkconf2" runat="server" text="Configuraciones generales" NavigateUrl="~/Sec/Administracion/ConfiguracionGeneral.aspx" CssClass="txt-left"></asp:HyperLink></td>
    </tr>
</table>



</asp:Panel>








