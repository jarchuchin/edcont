<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Sec_Default" title="Mis cursos" %>


<%@ Register src="Workbook/Controles/MyWorkBooks.ascx" tagname="MyWorkBooks" tagprefix="uc2" %>
<%@ Register src="Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc3" %>
<%@ Register src="SalonVirtual/Controles/MisSalonesVirtualesInstructor.ascx" tagname="MisSalonesVirtualesInstructor" tagprefix="uc4" %>
<%@ Register src="SalonVirtual/Controles/MisSalonVirtualesAlumno.ascx" tagname="MisSalonVirtualesAlumno" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<%@ Register src="Controles/DatosUserProfile.ascx" tagname="DatosUserProfile" tagprefix="uc5" %>


<%@ Register src="Controles/DisplayAgenda.ascx" tagname="DisplayAgenda" tagprefix="uc6" %>



<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblTitulo" runat="server"  Text="Mis cursos como alumno" ></asp:Label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelBreadcrumb" Runat="Server">


<ol class="breadcrumb" style="margin-bottom: 5px;">
  <li><asp:HyperLink ID="HyperLink2" runat="server"  Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
  <li class="active">Mis cursos como alumno</li>
</ol>


</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">   




    
<div class="row">
	<div class="col-xs-12">
		
                <uc1:MisSalonVirtualesAlumno ID="MisSalonVirtualesAlumno1" runat="server" Visible="True" />
           
    </div>
</div>

              
  
        
              



   
            

         
</asp:Content>

<asp:Content ID="Content3" runat="server" 
    contentplaceholderid="ContentPanelMenu">


    <uc3:MenuGeneral ID="MenuGeneral1" runat="server" />


</asp:Content>




