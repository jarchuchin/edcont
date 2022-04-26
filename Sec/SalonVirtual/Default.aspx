<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Sec_SalonVirtual_Default" title="Curso" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>
<%@ Register src="Controles/displayAccesos.ascx" tagname="displayAccesos" tagprefix="uc2" %>
<%@ Register src="Controles/displayApuntes.ascx" tagname="displayApuntes" tagprefix="uc3" %>
<%@ Register src="Controles/displayAgenda7dias.ascx" tagname="displayAgenda7dias" tagprefix="uc4" %>
<%@ Register src="Controles/displayForos.ascx" tagname="displayForos" tagprefix="uc5" %>
<%@ Register src="Controles/displayBoletin.ascx" tagname="displayBoletin" tagprefix="uc6" %>
<%@ Register src="Controles/displayCapilla.ascx" tagname="displayCapilla" tagprefix="uc7" %>
<%@ Register src="Controles/displayIntructores.ascx" tagname="displayIntructores" tagprefix="uc9" %>
<%@ Register src="Controles/displayEspectometro.ascx" tagname="displayEspectometro" tagprefix="uc10" %>
<%@ Register src="Controles/displayIntroduccion.ascx" tagname="displayIntroduccion" tagprefix="uc11" %>
<%@ Register src="Controles/displayPreguntasAcces.ascx" tagname="displayPreguntasAcces" tagprefix="uc12" %>
<%@ Register src="Controles/DisplayExploradorContenidos.ascx" tagname="DisplayExploradorContenidos" tagprefix="uc14" %>
<%@ Register src="Controles/displayAlumnos2.ascx" tagname="displayAlumnos2" tagprefix="uc8" %>





<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>



<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server"  ></asp:Label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/default.aspx" ></asp:HyperLink></li>
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  ></asp:Label></li>
    </ol>


   
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

    <div class="row">

        <div class="col-md-3 hidden-sm hidden-xs">

            
             <uc1:MenuSalonVirtual ID="MenuSalonVirtual1" runat="server" />
            <uc10:displayEspectometro ID="displayEspectometro1" runat="server" /> 
        </div>
        <div class="col-md-7 col-sm-8 col-xs-12">
           

            <div id="menu" class="hidden-sm hidden-md hidden-lg" >


                <uc1:MenuSalonVirtual ID="MenuSalonVirtual3" runat="server" />
            </div>

            <uc8:displayAlumnos2 ID="displayAlumnos1" runat="server" />
            <uc6:displayBoletin ID="displayBoletin1" runat="server" />
            <uc4:displayAgenda7dias ID="displayAgenda7dias1" runat="server" />
         <%--   <uc7:displayCapilla ID="displayCapilla1" runat="server" />--%>
            
        </div>
        <div class="col-md-2 col-sm-4 col-xs-12">

            <div class="hidden-lg hidden-md hidden-xs">
            <uc1:MenuSalonVirtual ID="MenuSalonVirtual2" runat="server" />
            </div>

            <uc9:displayIntructores ID="displayIntructores1" runat="server" />

            <div class="panel">
                <div class="panel-heading">
                        <h3 class="panel-title"><asp:Label ID="Label1" runat="server" Text="Herramientas"></asp:Label></h3>
                </div>
                <div class="panel-body">
                    <asp:HyperLink ID="lnkApunte2" runat="server"  Text="Tus Apuntes" NavigateUrl="~/sec/Default.aspx" CssClass="btn-link"></asp:HyperLink>
                    <div style="height:3px;"></div>
                    <asp:HyperLink ID="lnkSalaVirtual2" runat="server"  Text="Sala Virtual" CssClass="btn-link" target="_blank"></asp:HyperLink>
                     <div style="height:3px;"></div>
                    <asp:HyperLink ID="lnkPreguntas2" runat="server"  Text="Preguntas y respuestas" CssClass="btn-link"></asp:HyperLink>
                </div>
            </div>

             <uc5:displayForos ID="displayForos1" runat="server" />    
            <uc3:displayApuntes ID="displayApuntes1" runat="server" />
            

        </div>

    </div>

 




      
                   
                   
     
        
          
                          
                        
             
                   
        
             <asp:Label ID="labelCursosComoDocente" runat="server" Text="Cursos como docente" Visible="false"></asp:Label>
     <asp:Label ID="labelCursosComoAlumno" runat="server" Text="Cursos como alumno"  Visible="false"></asp:Label>
                   
                        
                                
             
                       
                                


</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">
   
     <uc22:MenuGeneral ID="MenuGeneral1" runat="server" />

</asp:Content>