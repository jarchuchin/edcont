<%@ Page Title="Libros de trabajo" Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="Libros.aspx.vb" Inherits="Sec_Libros" Culture="auto"  UICulture="auto"  EnableEventValidation="false" meta:resourcekey="PageResource1" %>

<%@ Register src="Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc1" %>
<%@ Register src="Workbook/Controles/MyWorkBooks.ascx" tagname="MyWorkBooks" tagprefix="uc2" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>



<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lbltitulo" runat="server" Text="Mis libros de trabajo"></asp:Label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelBreadcrumb" Runat="Server">


<ol class="breadcrumb" >
  <li><asp:HyperLink ID="HyperLink2" runat="server"  Text="Inicio" NavigateUrl="~/sec/home.aspx" meta:resourcekey="HyperLink2Resource1"></asp:HyperLink></li>
  <li class="active">
      <asp:Label ID="Label1" runat="server" Text="Libros de trabajo" meta:resourcekey="Label1Resource1"></asp:Label></li>
</ol>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
    





    <div class="row">
	<div class="col-xs-12">
    
                 <uc2:myworkbooks ID="MyWorkBooks1" runat="server" />

           </div>
</div>

    
      

         
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">


  <uc1:MenuGeneral ID="MenuGeneral1" runat="server" />





</asp:Content>

