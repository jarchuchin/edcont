<%@ Page Title="Avance de alumnos" Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="ListaSeguimiento.aspx.vb" Inherits="Sec_SalonVirtual_ListaSeguimiento" %>


<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>


<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>

<%@ Register src="Controles/displayEstadisticasSalon.ascx" tagname="displayEstadisticasSalon" tagprefix="uc2" %>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server"  Text="Seguimiento de alumnos" ></asp:Label> </h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/default.aspx" ></asp:HyperLink></li>
           <li><asp:HyperLink ID="lnkCurso" runat="server"  Text="Curso nombre"  NavigateUrl="~/sec/Sa/default.aspx" ></asp:HyperLink></li>
       
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Seguimiento de alumnos" ></asp:Label></li>
    </ol>


   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">
   
     <uc22:MenuGeneral ID="MenuGeneral1" runat="server" />

</asp:Content>

<asp:Content ID="contentCentral" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

		
	<div class="row">

        <div class="col-xs-3">
             <uc1:MenuSalonVirtual ID="MenuSalonVirtual2" runat="server" />
        </div>
        <div class="col-xs-9">


            <uc2:displayEstadisticasSalon ID="displayEstadisticasSalon1" runat="server" />





            </div>

        </div>
       <asp:Label ID="labelCursosComoDocente" runat="server" Text="Cursos como docente" Visible="false"></asp:Label>
    <asp:Label ID="labelCursosComoAlumno" runat="server" Text="Cursos como alumno"  Visible="false"></asp:Label>
    


<script language="javascript" type="text/javascript">

       function SelectAllCheckboxesSpecific(spanChk)
       {
           var IsChecked = spanChk.checked;
           var Chk = spanChk;

              Parent = document.getElementById('ctl00_ContentPanelCentral_gvListaAlumnos');      
              var items = Parent.getElementsByTagName('input');                          
            
              for(i=0;i<items.length;i++)

              {                
                  if(items[i].id != Chk && items[i].type=="checkbox")
                  {            
                      if(items[i].checked!= IsChecked)
                      {     
                          items[i].click();     
                      }
                  }
              }             
       }


 </script>



   

              
     

</asp:Content>

