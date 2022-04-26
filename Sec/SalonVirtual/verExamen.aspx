<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="verExamen.aspx.vb" Inherits="Sec_SalonVirtual_verExamen" title="Untitled Page" ValidateRequest="false"%>

<%@ Register src="../Workbook/Controles/showadjuntos.ascx" tagname="showadjuntos" tagprefix="uc2" %>
<%@ Register src="Controles/displayComentarios.ascx" tagname="displayComentarios" tagprefix="uc3" %>
<%@ Register src="Controles/IndiceContenido.ascx" tagname="IndiceContenido" tagprefix="uc4" %>

<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>



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
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Cursos como docente"  NavigateUrl="~/sec/default.aspx" ></asp:HyperLink></li>
         <li><asp:HyperLink ID="lnkCurso" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/Sa/default.aspx" ></asp:HyperLink></li>
          <li><asp:HyperLink ID="lnkUnidad" runat="server"  Text="Unidad"  ></asp:HyperLink></li>
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

            <div class="hidden-lg hidden-md hidden-sm">
                  <uc4:IndiceContenido ID="IndiceContenido3" runat="server" />
            </div>


              <div class="row">
                 <div class="col-md-8 col-sm-8 col-xs-12">

                     <div class="panel">
                            <div class="panel-heading">

                                   <div ID="panelEdicion" class="panel-control" runat="server" Visible="false" style="text-align:right">
					                 <asp:HyperLink ID="lnkEdicionContenido" runat="server" CssClass="btn btn-primary btn-sm">Editar examen</asp:HyperLink>
				                 </div>


                                    <h3 class="panel-title">
                                        <asp:Label ID="lblTitulo" runat="server"></asp:Label>
                                    </h3>
                            </div>
                            <div class="panel-body">

                         <asp:Label ID="Label6" runat="server" Text="Tipo" Font-Bold="true"></asp:Label>
                         <div style="height:4px;"></div>
                        <asp:Label ID="lblTipoActividad" runat="server"  Text="Examen" />
				         <div style="height:10px;"></div>

                        <asp:Label ID="Label2" runat="server" Text="Unidad de examen" Font-Bold="true"></asp:Label>
                         <div style="height:4px;"></div>
                        <asp:Label ID="lblClasificacion" runat="server"></asp:Label>
						 <div style="height:10px;"></div>

                         <asp:Label ID="Label3" runat="server" Text="Objetivo" Font-Bold="true"></asp:Label>
                         <div style="height:4px;"></div>
                        <asp:Label ID="lblObjetivo" runat="server" Text="---"></asp:Label>
                         <div style="height:10px;"></div>

                         <asp:Label ID="Label4" runat="server" Text="Instrucciones" Font-Bold="true"></asp:Label>
                         <div style="height:4px;"></div>
                      <asp:Literal ID="litInstrucciones" runat="server"></asp:Literal>
                         <div style="height:10px;"></div>


						

                       


                            </div>
                     </div>



                     <div class="panel">
                            <div class="panel-heading">
                                    <h3 class="panel-title"><asp:Label ID="Label1" runat="server" Text="Comentarios de alumnos"  /></h3>
                            </div>
                            <div class="panel-body">
                                <uc3:displayComentarios ID="displayComentarios1" runat="server" />
                            </div>

                      </div>


                </div>
                <div class="col-md-4 col-sm-4 col-xs-12">

                     <div class="hidden-lg hidden-md hidden-xs">
                           <uc4:IndiceContenido ID="IndiceContenido2" runat="server" />
                      </div>


                     <div class="panel">
                        <div class="panel-heading">
                                <h3 class="panel-title"><asp:Label ID="Respuesta" runat="server" text="Responder examen"  /></h3>
                        </div>
                        <div class="panel-body" style="font-size:11px;">
                            <asp:Label ID="lblNoFecha" runat="server" CssClass="textoNoData11" Text="La fecha no ha sido definida"></asp:Label>
                            <br />
                             <div runat="server" id="panelDesplegarFechas" visible="false">
                            <asp:Label ID="Label10" runat="server" Text="Abierto desde:" Font-Bold="true"></asp:Label>
                            <div style="height:3px"></div>
						<asp:Label ID="lblFechaEntrega" runat="server" Text=""></asp:Label>
                            <div style="height:6px"></div>
                        <asp:Label ID="Label11" runat="server" Text="Puede ser contestado hasta:" Font-Bold="true"></asp:Label>
                            <div style="height:3px"></div>
                            <asp:Label ID="lblFechaEntrega2" runat="server" Text=""></asp:Label>
                            <div style="height:15px"></div>
                            <asp:Label ID="lblFechaVencida" Visible="False"  runat="server"  Text="Ya no puede ser contestado este examen" ForeColor="Red"></asp:Label>
                                 </div>
						    <div style="text-align:center;">
                                  <div style="height:15px"></div>
							    <asp:Button ID="btnEnviarTarea" Visible="false" runat="server" Text="Responder examen" CssClass="btn btn-success form-control"  />
                                <asp:Button ID="btnRevisarExamen" Visible="false" runat="server" Text="Revisar examen" CssClass="btn btn-warning form-control"  />
							    <asp:Button ID="btnCalificar" Visible="false" runat="server" Text="Calificación grupal" CssClass="btn btn-default  form-control"   />
							    <asp:Button ID="btnVerRespuestas" Visible="false" runat="server" Text="Ver respuestas" CssClass="btn btn-default  form-control"   />
						    </div>
                        </div>

                     </div>
               


              
					  <uc2:showadjuntos ID="showContenidos" runat="server" />
                            <uc2:showadjuntos ID="showArchivosAdjuntos" runat="server" />
					        <uc2:showadjuntos ID="showDirecciones" runat="server" />
					        <uc2:showadjuntos ID="showImagenesAdjuntos" runat="server" />
					        <uc2:showadjuntos ID="showFlashes" runat="server" />


                </div>
             </div>



		

            </div>

         </div>



    <asp:Label ID="labelCursosComoDocente" runat="server" Text="Cursos como docente" Visible="false"></asp:Label>
    <asp:Label ID="labelCursosComoAlumno" runat="server" Text="Cursos como alumno"  Visible="false"></asp:Label>
    
</asp:Content>
