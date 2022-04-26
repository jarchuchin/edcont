<%@ Page Title="" Language="VB" MasterPageFile="~/MPUsmart01.master" AutoEventWireup="false" CodeFile="CalendarioMovil.aspx.vb" Inherits="Sec_SalonVirtual_CalendarioMovil" %>

<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelBreadcrumb" Runat="Server">

    
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td width="189" height="33" align="center" valign="bottom" class="bg-left-head" scope="row"><table width="90%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td style="text-align:left;">
    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/bull-arrow2.png" Width="10px" Height="10px" /> 
    <asp:HyperLink ID="lnkMinilink" runat="server" CssClass="mini-link" Text="Inicio" NavigateUrl="~/sec/Default.aspx"></asp:HyperLink> </td>
<td align="right"><%--<asp:Image ID="imgColapsable" runat="server" ImageUrl="~/images/btn-colapse.png" width="19px" height="20px" />--%></td>
</tr>
</table></td>
<td><table border="0" cellpadding="0" cellspacing="8" style="width:100%;">
<tr>
<td scope="row">Estás en: <asp:HyperLink ID="HyperLink1" runat="server"  Text="Inicio" NavigateUrl="~/sec/Default.aspx"></asp:HyperLink>&nbsp;/&nbsp; <asp:HyperLink ID="lnkMuro" runat="server"  Text="Muro" NavigateUrl=""></asp:HyperLink>&nbsp;/&nbsp;<asp:Label ID="lblNombredelcurso" runat="server" Text="Calendario" ></asp:Label></td>
</tr>
</table></td>
<td style="width:120px;">
<asp:HyperLink ID="lnkApunte1" runat="server"  NavigateUrl="~/sec/Default.aspx" ImageUrl="~/images/ico-apuntes.png"></asp:HyperLink>
<asp:HyperLink ID="lnkApunte2" runat="server"  Text="Tus Apuntes" NavigateUrl="~/sec/Default.aspx"></asp:HyperLink>
</td>
</tr>
</table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelIzquierdo" Runat="Server">
    <uc1:MenuSalonVirtual ID="MenuSalonVirtual1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPanelEdicion" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
    <table class="ui-accordion">
        <tr>
            <td style="width: 200px">
                &nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtemail" ErrorMessage="El correo es un campo requerido">El correo es un campo requerido</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 200px">
                <asp:Label ID="Label1" runat="server" Text="Coloca tu correo electrónico"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtemail" runat="server" Width="300px"></asp:TextBox>
            &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 200px">
                <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtpass" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 200px">&nbsp;</td>
            <td>
                <asp:Button ID="btnCrearCalendario" runat="server" Text="Crear calendario" />
            </td>
        </tr>
    </table>
</asp:Content>

