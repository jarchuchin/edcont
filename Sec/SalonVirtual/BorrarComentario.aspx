<%@ Page Language="VB" MasterPageFile="~/MPUsmart01.master" AutoEventWireup="false" CodeFile="BorrarComentario.aspx.vb" Inherits="Sec_SalonVirtual_BorrarComentario" title="Borrar comentario" %>

<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPanelBreadcrumb">



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
<td scope="row">Estás en: <asp:HyperLink ID="HyperLink1" runat="server"  Text="Inicio" NavigateUrl="~/sec/Default.aspx"></asp:HyperLink>&nbsp;/&nbsp; <asp:HyperLink ID="lnkMuro" runat="server"  Text="Muro" NavigateUrl=""></asp:HyperLink>&nbsp;/&nbsp;<asp:Label ID="lblNombredelcurso" runat="server" Text="Comentarios de contenidos" ></asp:Label></td>
</tr>
</table></td>
<td style="width:120px;">
<asp:HyperLink ID="lnkApunte1" runat="server"  NavigateUrl="~/sec/Default.aspx" ImageUrl="~/images/ico-apuntes.png"></asp:HyperLink>
<asp:HyperLink ID="lnkApunte2" runat="server"  Text="Tus Apuntes" NavigateUrl="~/sec/Default.aspx"></asp:HyperLink>
</td>
</tr>
</table>




</asp:Content>

<asp:Content ID="contentIzquierdo" ContentPlaceHolderID="ContentPanelIzquierdo" Runat="Server">
    <uc1:MenuSalonVirtual ID="MenuSalonVirtual1" runat="server" />
</asp:Content>

<asp:Content ID="contentEdicion" ContentPlaceHolderID="ContentPanelEdicion" Runat="Server">
</asp:Content>

<asp:Content ID="contentCentral" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

		<asp:Label ID="lblTitulo" CssClass="title-big" runat="server" Text="Comentarios de contenidos"></asp:Label>
	
    <div style="height:15p;"></div>

 <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <div style="text-align: left">
                <asp:Image runat="server" ID="Image1" ImageUrl="~/Images/indicator.gif" ></asp:Image>
                &nbsp;<asp:Label runat="server" Text="Actualizndo datos..." ID="lblProgress" ></asp:Label>
            </div>

        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        

<asp:Panel ID="Panel1" runat="server" Visible="true" >
    <asp:Label ID="Label2" runat="server" Text="Calificación" CssClass="Mediana" Font-Bold="true" ></asp:Label>
    <asp:Label ID="lblMensaje" runat="server" Text="Debes seleccionar la calificacion y colocar tu comentario" Visible="False" ForeColor="Red"></asp:Label><br />
    <asp:RadioButtonList ID="rbdCalificacion" runat="server"  RepeatDirection="Horizontal" CssClass="Mediana">
           <asp:ListItem Value="1" Text="1"></asp:ListItem> 
          <asp:ListItem Value="2" Text="2"></asp:ListItem> 
          <asp:ListItem Value="3" Text="3"></asp:ListItem> 
          <asp:ListItem Value="4" Text="4"></asp:ListItem> 
          <asp:ListItem Value="5" Text="5"></asp:ListItem>  
        </asp:RadioButtonList><br />
        
    <asp:Label ID="Label1" runat="server" Text="Comentario:" CssClass="Mediana" Font-Bold="true" ></asp:Label> <br />
    <asp:TextBox ID="txtComentario" runat="server" Height="87px" 
        TextMode="MultiLine" Width="385px"></asp:TextBox><br />
    <br />
    <br />
    <asp:Button ID="btnEnviar" runat="server" Text="Editar" 
        CausesValidation="false"  CssClass="button"/>
    &nbsp;<asp:Button ID="btnBorrar" runat="server" Text="Borrar"  CssClass="button"/>
    <cc1:ConfirmButtonExtender ID="btnBorrar_ConfirmButtonExtender" runat="server" 
        ConfirmText="¿Deseas borrar este comentario?" Enabled="True" 
        TargetControlID="btnBorrar">
    </cc1:ConfirmButtonExtender>
    &nbsp;<asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CausesValidation="false" CssClass="button" />
    
   </asp:Panel>

</ContentTemplate>
</asp:UpdatePanel>


</asp:Content>

