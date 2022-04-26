<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="Calendario.aspx.vb" Inherits="Sec_SalonVirtual_Calendario" title="Calendario del curso" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>

<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server"  Text="Agenda del curso" ></asp:Label> </h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/default.aspx" ></asp:HyperLink></li>
           <li><asp:HyperLink ID="lnkCurso" runat="server"  Text="Curso nombre"  NavigateUrl="~/sec/Sa/default.aspx" ></asp:HyperLink></li>
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Agenda del curso" ></asp:Label></li>
    </ol>


   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">
   
     <uc22:MenuGeneral ID="MenuGeneral1" runat="server" />

</asp:Content>


<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHead" Runat="Server">

     <!--Full Calendar [ OPTIONAL ]-->
  <asp:PlaceHolder runat="server">

     <link href=<%= appName & "plugins/fullcalendar/fullcalendar.min.css""" %> rel="stylesheet">

  </asp:PlaceHolder>

</asp:Content>


<asp:Content ID="contentCentral" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

    
   <div class="row">

        <div class="col-md-3  hidden-xs"> 
             <uc1:MenuSalonVirtual ID="MenuSalonVirtual2" runat="server" />
        </div>
        <div class="col-md-9 col-sm-12 col-xs-12">

              <div class="hidden-lg hidden-md hidden-sm">
                  <uc1:MenuSalonVirtual ID="MenuSalonVirtual1" runat="server" />
            </div>
                        
            <div class="panel">
                <div class="panel-heading">
                      <div class="panel-control" style="text-align:right">
             
                  <asp:HyperLink ID="lnkActividades" runat="server" CssClass="btn btn-success btn-sm" Text="Actividades agendadas"></asp:HyperLink>
            </div>

                        <h3 class="panel-title"><asp:Label ID="Label6" runat="server" Text="Agenda del curso"></asp:Label></h3>
                </div>
                <div class="panel-body">

                   

                    <!-- Calendar placeholder-->
					<!-- ============================================ -->
					<div id='Skolar-calendar'></div>
					<!-- ============================================ -->

                </div>

             </div>
        </div>

    </div>





        <asp:Label ID="labelCursosComoDocente" runat="server" Text="Cursos como docente" Visible="false"></asp:Label>
    <asp:Label ID="labelCursosComoAlumno" runat="server" Text="Cursos como alumno"  Visible="false"></asp:Label>


</asp:Content>




<asp:Content ID="content3" ContentPlaceHolderID="ContentPlaceFooterScripts" Runat="Server">

      <asp:PlaceHolder runat="server">
        <!--Full Calendar [ OPTIONAL ]-->
  
    
     <script src=<%= appName & "plugins/fullcalendar/lib/moment.min.js""" %>></script>
     <script src=<%= appName & "plugins/fullcalendar/lib/jquery-ui.custom.min.js""" %>></script>
   <script src=<%= appName & "plugins/fullcalendar/fullcalendar.min.js""" %>></script>
             <script src=<%= appName & "plugins/fullcalendar/lang-all.js""" %>></script>


</asp:PlaceHolder>


    <asp:Literal runat="server" ID="litScript"></asp:Literal>

 

</asp:Content>