<%@ Page Title="" Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="VerCarpeta.aspx.vb" Inherits="Sec_SalonVirtual_VerCarpeta" %>

<%@ Register src="~/Sec/Workbook/Controles/showadjuntos.ascx" tagname="showadjuntos" tagprefix="uc2" %>
<%@ Register src="Controles/displayComentarios.ascx" tagname="displayComentarios" tagprefix="uc3" %>
<%--<%@ Register src="Controles/IndiceClasificacion.ascx" tagname="IndiceClasificacion" tagprefix="uc1" %>--%>



<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>


<%@ Register src="Controles/IndiceContenido.ascx" tagname="IndiceContenido" tagprefix="uc4" %>


<%@ Register src="Controles/displayObjetivos.ascx" tagname="displayObjetivos" tagprefix="uc5" %>



<%@ Register src="Controles/displayActividades.ascx" tagname="displayActividades" tagprefix="uc6" %>



<%@ Register src="Controles/displayExamenes.ascx" tagname="displayExamenes" tagprefix="uc7" %>



<%@ Register src="Controles/displayForos.ascx" tagname="displayForos" tagprefix="uc8" %>



<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server" Text="Cuaderno de apuntes"  ></asp:Label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/default.aspx" ></asp:HyperLink></li>
         <li><asp:HyperLink ID="lnkCurso" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/Sa/default.aspx" ></asp:HyperLink></li>
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Editar apunte" ></asp:Label></li>
    </ol>


   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">
   
     <uc22:MenuGeneral ID="MenuGeneral1" runat="server" />

</asp:Content>




<asp:Content ID="contentCentral" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

	  <div class="row">

        <div class="col-md-3 hidden-sm hidden-xs">
             
        
            <uc4:IndiceContenido ID="IndiceContenido1" runat="server" />
        </div>
        <div class="col-md-9 col-sm-12 col-xs-12">


           
                        
            <div class="panel">
                <div class="panel-heading">

                   
                    <div ID="panelEdicion" class="panel-control" runat="server" Visible="false" style="text-align:right">
					        <asp:HyperLink ID="lnkEdicionContenido" runat="server" CssClass="btn btn-primary btn-sm">Editar datos</asp:HyperLink>
				    </div>

                    <h3 class="panel-title"><asp:Label ID="lblTituloClasificacionCentro" runat="server" Text="titulo"></asp:Label></h3>

                    
                </div>
                <div class="panel-body">

                       
                       <asp:Image id="imagenClasificacion1" runat="server" CssClass="img-responsive" Visible="false" />

		
				</div>
            </div>


             <div class="hidden-lg hidden-md hidden-sm">
                  <uc4:IndiceContenido ID="IndiceContenido3" runat="server" />
            </div>
	


             <div class="row">
                 <div class="col-md-8 col-sm-8 col-lg-8 col-xs-12">


                      <div class="panel">
                
                        <div class="panel-body">
	
							     

                            <asp:Label ID="asdfasdf" runat="server" Text="Planteamiento breve" Font-Bold="true" ></asp:Label>
                            <div style="height:4px;"></div>
                            <asp:Literal ID="literalPlanteamientoBreve" runat="server"></asp:Literal>
                            <div style="height:10px;"></div>

                            <div id="panelExamen" runat="server">
                                <asp:Label ID="Label3" runat="server" Text="Examen de diagnóstico" font-bold="true" ></asp:Label>
                                <asp:HyperLink ID="lnkExamenDiagnostico" runat="server" Visible="False">[lnkExamenDiagnostico]</asp:HyperLink>
                                <div style="height:10px;"></div>
                            </div>
                            <asp:Label ID="listasdf" runat="server" Text="Descripcion"  font-bold="true"></asp:Label>
                             <div style="height:4px;"></div>
	                        <asp:Literal ID="literalTexto" runat="server"></asp:Literal>
                            <div style="height:10px;"></div>

                            <asp:Label ID="Label10" runat="server" Text="Día de presentación"  font-bold="true"></asp:Label>
	                        <asp:Literal ID="literalDia" runat="server"></asp:Literal>
                            <div style="height:10px;"></div>

						        
					  

                    
                       </div>
                    </div>

                      <uc5:displayObjetivos ID="displayObjetivos1" runat="server" />

                     <div class="row">
                         <div class="col-sm-6">
                             <uc6:displayActividades ID="displayActividades1" runat="server" />
                         </div>
                         <div class="col-sm-6">
                             <uc7:displayExamenes ID="displayExamenes1" runat="server" />
                         </div>
                     </div>
                     
                     
                          

                 </div>
                 <div class="col-md-4 col-sm-4  col-lg-4 col-xs-12">

                      <div class="hidden-lg hidden-md hidden-xs">
                           <uc4:IndiceContenido ID="IndiceContenido2" runat="server" />
                      </div>

                        <uc2:showadjuntos ID="showContenidos" runat="server" />
                                 <uc2:showadjuntos ID="showContenidosArticulate" runat="server" />
                                <uc2:showadjuntos ID="showArchivosAdjuntos" runat="server" />
					            <uc2:showadjuntos ID="showDirecciones" runat="server" />
					            <uc2:showadjuntos ID="showImagenesAdjuntos" runat="server" />
					            <uc2:showadjuntos ID="showFlashes" runat="server" />



                       <uc8:displayForos ID="displayForos1" runat="server" />
                          


                  </div>
            </div>

                 
            
			             
           
            </div>

         


    </div>


     <asp:Label ID="labelCursosComoDocente" runat="server" Text="Cursos como docente" Visible="false"></asp:Label>
    <asp:Label ID="labelCursosComoAlumno" runat="server" Text="Cursos como alumno"  Visible="false"></asp:Label>
</asp:Content>

