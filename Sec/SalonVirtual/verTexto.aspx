<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="verTexto.aspx.vb" Inherits="Sec_SalonVirtual_verTexto" title="Untitled Page" ValidateRequest="false" %>

<%@ Register src="~/Sec/Workbook/Controles/showadjuntos.ascx" tagname="showadjuntos" tagprefix="uc2" %>
<%@ Register src="Controles/displayComentarios.ascx" tagname="displayComentarios" tagprefix="uc3" %>
<%@ Register src="Controles/IndiceContenido.ascx" tagname="IndiceContenido" tagprefix="uc4" %>



<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>



<%@ Register src="Controles/displayBuscadores.ascx" tagname="displayBuscadores" tagprefix="uc1" %>



<%@ Register src="Controles/DisplayEstadisticasCotenidos.ascx" tagname="DisplayEstadisticasCotenidos" tagprefix="uc5" %>



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
					                 <asp:HyperLink ID="lnkEdicionContenido" runat="server" CssClass="btn btn-primary btn-sm">Editar texto</asp:HyperLink>
				                 </div>


                                    <h3 class="panel-title">
                                        <asp:Label ID="lblTitulo" runat="server"></asp:Label>
                                    </h3>
                            </div>
                            <div class="panel-body divPanelLink">


                                
                                 <asp:Label ID="Label2" runat="server" Text="Unidad de actividad" Font-Bold="true"></asp:Label>
                                 <div style="height:2px;"></div>
                                <asp:Label ID="lblClasificacion" runat="server"></asp:Label>
						         <div style="height:10px;"></div>


                                <div id="panelSugerencias" runat="server"  visible="false">
                                     <asp:Label ID="Label3" runat="server" Text="Sugerencias para instructor" Font-Bold="true"></asp:Label>
                                     <div style="height:2px;"></div>
                                    <asp:Label ID="lblSugerencias" runat="server"></asp:Label>
						             <div style="height:10px;"></div>
                                </div>


                                


                                  <asp:Label ID="lbltagsasdfas" runat="server" Text="Palabras claves" Font-Bold="true"></asp:Label>
                                 <div style="height:2px;"></div>
                                <asp:Label ID="lblTags" runat="server"></asp:Label>
						         <div style="height:10px;"></div>



                                 <asp:Label ID="Label4" runat="server" Text="Descripción" Font-Bold="true"></asp:Label>
                                 <div style="height:2px;"></div>
                              
                                    <asp:Literal ID="literalDescripcion" runat="server"></asp:Literal>
                               
                              
	                    
                                <asp:Literal ID="literalUrlFrameBox" runat="server"></asp:Literal>
                                <asp:Literal ID="literalTextoLargo" runat="server"></asp:Literal>
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
                   
                      <uc5:DisplayEstadisticasCotenidos ID="DisplayEstadisticasCotenidos1" runat="server" />
                 </div>


              <div class="col-md-4 col-sm-4 col-xs-12">

                     <div class="hidden-lg hidden-md hidden-xs">
                           <uc4:IndiceContenido ID="IndiceContenido2" runat="server" />
                      </div>

                      <uc2:showadjuntos ID="showContenidos" runat="server" />
                            <uc2:showadjuntos ID="showArchivosAdjuntos" runat="server" />
					        <uc2:showadjuntos ID="showDirecciones" runat="server" />
					        <uc2:showadjuntos ID="showImagenesAdjuntos" runat="server" />
					        <uc2:showadjuntos ID="showFlashes" runat="server" />



                    <uc1:displayBuscadores ID="displayBuscadores1" runat="server" />
                   

                </div>
   



        </div>

   </div>


</div>


<asp:Label ID="labelCursosComoDocente" runat="server" Text="Cursos como docente" Visible="false"></asp:Label>
<asp:Label ID="labelCursosComoAlumno" runat="server" Text="Cursos como alumno"  Visible="false"></asp:Label>
    


</asp:Content>