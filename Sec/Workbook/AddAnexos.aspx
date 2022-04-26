<%@ Page Title="" Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="AddAnexos.aspx.vb" Inherits="Sec_Workbook_Controles_AddAnexos" meta:resourcekey="PageResource1" uiculture="auto" Culture="auto" %>

<%@ Register src="Controles/TabsWorkbook.ascx" tagname="TabsWorkbook" tagprefix="uc1" %>
<%@ Register src="Controles/DisplayObjetosAprendizaje.ascx" tagname="DisplayObjetosAprendizaje" tagprefix="uc2" %>
<%@ Register src="Controles/DisplayArchivo.ascx" tagname="DisplayArchivo" tagprefix="uc3" %>

<%@ Register src="Controles/DisplayImagen.ascx" tagname="DisplayImagen" tagprefix="uc5" %>
<%@ Register src="Controles/DisplayFlash.ascx" tagname="DisplayFlash" tagprefix="uc6" %>
<%@ Register src="Controles/DisplayListaObjetos.ascx" tagname="DisplayListaObjetos" tagprefix="uc4" %>

<%@ Register src="Controles/DisplayArticulate.ascx" tagname="DisplayArticulate" tagprefix="uc7" %>
<%@ Register src="Controles/DisplayMFiles.ascx" tagname="DisplayMFiles" tagprefix="uc8" %>


<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>



<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Literal ID="Literal1" runat="server" Text="Editar contenido" meta:resourcekey="Literal1Resource1"></asp:Literal></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">

     <uc22:MenuGeneral ID="MenuGeneral1" runat="server" />

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelBreadcrumb" Runat="Server">
	  <ol class="breadcrumb" >
  <li><asp:HyperLink ID="lnkSalirEdicion" runat="server" Text="Salir de edición" meta:resourcekey="lnkSalirEdicionResource1" ></asp:HyperLink>
      </li>
        </ol>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
	

	
<div class="panel">
    <div class="panel-body">
        <uc7:DisplayArticulate ID="DisplayArticulate1" runat="server" />
        <uc6:DisplayFlash ID="DisplayFlash1" runat="server" />
        <uc5:DisplayImagen ID="DisplayImagen1" runat="server" />
        <uc3:DisplayArchivo ID="DisplayArchivo1" runat="server" visible="False" />
        <uc8:DisplayMFiles ID="DisplayMFiles1" runat="server" visible="False" />
    </div>
</div>
	



</asp:Content>

