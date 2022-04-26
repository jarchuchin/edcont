<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="verRespuestaCompa.aspx.vb" Inherits="Sec_SalonVirtual_verRespuestaCompa" title="Untitled Page" %>

<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register src="Controles/DisplayRanking.ascx" tagname="DisplayRanking" tagprefix="uc3" %>
<%@ Register src="Controles/displayRespuestaArchivos.ascx" tagname="displayRespuestaArchivos" tagprefix="uc2" %>

<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>


<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server"  Text="Responder actividad" ></asp:Label></h1>
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
          <li><asp:HyperLink ID="lnkActividad" runat="server"  Text="Actividad"  ></asp:HyperLink></li>
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Actividades enviadas por alumnos" ></asp:Label></li>
    </ol>


   
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">
   
     <uc22:MenuGeneral ID="MenuGeneral1" runat="server" />

</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">


    
      <div class="row">

        <div class="col-xs-3">
             <uc1:MenuSalonVirtual ID="MenuSalonVirtual2" runat="server" />
        </div>
        <div class="col-xs-6">

                        
            <div class="panel">
                <div class="panel-heading">
                        <h3 class="panel-title"><asp:Label ID="lblssActividad"  runat="server"   Text="Actividad: " ></asp:Label>	<asp:Label ID="lblActividad"  runat="server"   Text="Actividades enviadas por alumnos" ></asp:Label></h3>
                </div>
                <div class="panel-body">

     
      <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <div align="left" > <asp:Image ID="Image1" runat="server"  ImageUrl ="~/Images/indicator.gif" /><asp:Label ID="lbltexto" runat="server"   Text="Actualizando datos..." ></asp:Label></div>
                    </ProgressTemplate>
       </asp:UpdateProgress>
       <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional" >
               <ContentTemplate>	
                        
                      
                        
						
                        
                <asp:Label ID="lblInstrucciones" runat="server" Font-Bold="true">Instrucciones</asp:Label>
                   <div style="height:5px;"></div>
                    <asp:Label ID="lbltextoinstrucciones" runat="server" ></asp:Label>
                   <div style="height:10px;"></div>
                    <asp:Label ID="lblRespuestaAlumno" runat="server" CssClass="Mediana" 
                                          Font-Bold="True">Respuesta del alumno</asp:Label>
                   <div style="height:5px;"></div>
                    <asp:literal id="littexto" runat="server"></asp:literal>
                   <div style="height:10px;"></div>
                    <asp:Label ID="lblArchivosAdjuntos" runat="server" CssClass="Mediana" Font-Bold="True">Archivos</asp:Label>
                   
                   <uc2:displayRespuestaArchivos ID="displayRespuestaArchivos1" runat="server" />
				
                   <div style="height:10px;"></div>
				
					 <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="Calificacion: "></asp:Label>		<div style="height:5px;"></div>
                       <asp:Label ID="txtcalificacion" runat="server" Text=""></asp:Label>
				
				
				<div style="height:10px;"></div>
							
                   <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Observaciones del maestro"></asp:Label>		

                   <div style="height:5px;"></div>
                       <asp:Label ID="txtMensaje" runat="server" Text=""></asp:Label>
                          

               </ContentTemplate>
         
        </asp:UpdatePanel>

    </div>
    </div>

</div>

    <div class="col-xs-3">
         <div class="panel">
                <div class="panel-heading">
                        <h3 class="panel-title"><asp:Label ID="Label3"  runat="server"   Text="Datos del alumno" ></asp:Label>	</h3>
                </div>
                <div class="panel-body">

                    <div  class="text-center">

                         <asp:Image ID="imgAlumno" runat="server" 
                                        ImageUrl="~/Sec/Usuarios/fotos/0100132.jpg" Height="100px" />

                    </div>

                    

                    
                                     <table id="Table5" cellSpacing="1" cellPadding="1" width="100%" border="0">
            						    <tr>
                                            <td colspan="2" >
                                                <asp:TextBox ID="txtid" runat="server" Visible="False"></asp:TextBox>
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                                    displaymode="List" headertext="Los campos marcados con * son requeridos o no estan en el formato apropiado" />
                                            </td>
                                        </tr>
							            <tr>
                                            <td style="width: 104px">
                                                <asp:Label ID="lblEstudiante" runat="server" CssClass="Mediana">Nombre del alumno</asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="estudiante" runat="server"></asp:Label>
                                            </td>
                                        </tr>
						                <tr>
                                            <td style="width: 104px">
                                                <asp:Label ID="lblFechaEnvio" runat="server" CssClass="Mediana">Fecha de envío</asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="fechaenvio" runat="server"></asp:Label>
                                            </td>
                                        </tr>
						                <tr>
                                            <td style="width: 104px">
                                                <asp:Label ID="lblFechaEnvio0" runat="server" CssClass="Mediana">Título de 
                                                actividad</asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="actividad" runat="server" Font-Bold="True"></asp:Label>
                                            </td>
                                        </tr>
						                <tr>
                                            <td style="width: 104px">
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
						            </table>
                              


                </div>
             </div>
    </div>


          </div>

     <asp:Label ID="labelCursosComoDocente" runat="server" Text="Cursos como docente" Visible="false"></asp:Label>
        <asp:Label ID="labelCursosComoAlumno" runat="server" Text="Cursos como alumno"  Visible="false"></asp:Label>



</asp:Content>

