<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="verActividad.aspx.vb" Inherits="Sec_SalonVirtual_verActividad" title="" ValidateRequest="false" %>

<%@ Register src="~/Sec/Workbook/Controles/showadjuntos.ascx" tagname="showadjuntos" tagprefix="uc2" %>
<%@ Register src="~/Sec/Workbook/Controles/displayComentariosVistaPrevia.ascx" tagname="displayComentarios" tagprefix="uc3" %>

<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>



<%@ Register src="~/Sec/SalonVirtual/Controles/displayBuscadores.ascx" tagname="displayBuscadores" tagprefix="uc1" %>



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


    
   <ol class="breadcrumb" >
  <li><asp:HyperLink ID="HyperLink3" runat="server"  Text="Inicio" NavigateUrl="~/sec/home.aspx" meta:resourcekey="HyperLink3Resource1"></asp:HyperLink></li>
     <li><asp:HyperLink ID="HyperLink2" runat="server"  Text="Libros de trabajo" NavigateUrl="~/sec/Libros.aspx" meta:resourcekey="HyperLink2Resource1"></asp:HyperLink></li>
    <li><asp:HyperLink ID="lnkTitulo" runat="server" meta:resourcekey="lnkTituloResource1">[lnkTitulo]</asp:HyperLink></li>

        <li><asp:HyperLink ID="lbltit" runat="server" ></asp:HyperLink></li>
  <li class="active"><asp:Label ID="lbltits" runat="server" Text="Idiomas" meta:resourcekey="lbltitResource1" ></asp:Label></li>
</ol>


   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">
   
     <uc22:MenuGeneral ID="MenuGeneral1" runat="server" />

</asp:Content>




<asp:Content ID="contentCentral" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

	  <div class="row">

        <div class="col-xs-3">
               <div class="panel">
                            <div class="panel-heading">
                        

                    <h3 class="panel-title">
                                        <asp:Label ID="Label1" runat="server" Text="Menú del curso"></asp:Label>
                                    </h3>
                            </div>
                            <div class="panel-body text-center">


                                <div style="height: 50px"></div>

                                <asp:hyperlink ID="btnRegresarEdicion" runat="server" Text="Regresar a edición" CssClass="btn btn-primary form-control"  NavigateUrl="javascript:history.back(-1);" />


                                     <div style="height: 250px"></div>

                            </div>
            
                </div>
        </div>
       <div class="col-xs-9">




              <div class="row">
                 <div class="col-xs-8">

                     <div class="panel">
                            <div class="panel-heading">

                                   <div ID="panelEdicion" class="panel-control" runat="server" Visible="false" style="text-align:right">
					              
				                 </div>


                                    <h3 class="panel-title">
                                        <asp:Label ID="lblTitulo" runat="server"></asp:Label>
                                    </h3>
                            </div>
                            <div class="panel-body divPanelLink">

                         <asp:Label ID="Label6" runat="server" Text="Tipo de actividad" Font-Bold="true"></asp:Label>
                         <div style="height:4px;"></div>
                        <asp:Label ID="lblTipoActividad" runat="server"  />
				         <div style="height:10px;"></div>

                        <asp:Label ID="Label2" runat="server" Text="Unidad de actividad" Font-Bold="true"></asp:Label>
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


						 <asp:Label ID="Label5" runat="server" Text="Palabras claves" Font-Bold="true"></asp:Label>
                         <div style="height:4px;"></div>
                        <asp:Label ID="lbltags" runat="server" ></asp:Label>



                         <div style="height:10px;"></div>


						 <asp:Label ID="Label12" runat="server" Text="Tipo de evaluación" Font-Bold="true"></asp:Label>
                         <div style="height:4px;"></div>
                        <asp:Label ID="Label13" runat="server" ></asp:Label>

                        <div style="height:20px;"></div>

                       


                            </div>
                     </div>


                      <div class="panel" id="panelGrupos" runat="server" visible="false">
                            <div class="panel-heading">

                                 <div class="panel-control" style="text-align:right">
             
                                      <asp:button ID="lnknuevogrupo" runat="server" CssClass="btn btn-primary btn-sm" Text="Nuevo grupo"></asp:button>
                                </div>

                                    <h3 class="panel-title"><asp:Label ID="Label15" runat="server" Text="Grupos de alumnos para actividad"  /></h3>
                            </div>
                            <div class="panel-body">


                                <div class="row">

                                </div>

                            </div>
                     </div>


                       <div class="panel" id="panelRubricas" runat="server" visible="false">
                            <div class="panel-heading">
                                    <h3 class="panel-title"><asp:Label ID="Label9" runat="server" Text="Rúbrica de actividad"  /></h3>
                            </div>
                            <div class="panel-body">
                                


                                 <!--
						++++++++++++++++++++++++++++++++++++++++++++++++++
						+++++++++++++++    AQUI VA LA RÚBRICA b ++++++++++++++
						++++++++++++++++++++++++++++++++++++++++++++++++++
						-->
						
					     <asp:Label ID="Label8" runat="server" Text="Rúbrica" Font-Bold="true"></asp:Label>
                         <div style="height:4px;"></div>
						
                          	<asp:Repeater ID="rptRubricas" runat="server">
								<ItemTemplate>
									<table style="width: 100%" cellSpacing="2" cellPadding="2">
									<tr>
										<td style="width: 139px"></td>
										<td style="width: 167px"><asp:label ID="lblRubricaID" runat="server" Visible="False"></asp:label></td>
										<td style="width: 166px">&nbsp;</td>
										<td style="width: 163px">&nbsp;</td>
										<td>&nbsp;</td>
									</tr>
									<tr>
										<td><asp:label ID="lblRubricaTitulo" runat="server" Text='<%#Eval("Titulo") %>'></asp:label></td>
										<td><asp:label ID="lblRubricaVal4" runat="server" Text='<%#Eval("Val4") %>' Font-Bold="true"></asp:label></td>
										<td><asp:label ID="lblRubricaVal3" runat="server" Text='<%#Eval("Val3") %>' Font-Bold="true"></asp:label></td>
										<td><asp:label ID="lblRubricaVal2" runat="server" Text='<%#Eval("Val2") %>' Font-Bold="true"></asp:label></td>
										<td><asp:label ID="lblRubricaVal1" runat="server" Text='<%#Eval("Val1") %>' Font-Bold="true"></asp:label></td>
									</tr>
									<tr>
										<td>&nbsp;</td>
										<td><asp:label ID="lblRubricaVal4Descripcion" runat="server" Text='<%#Eval("Val4Descripcion") %>' Font-Size="10px"></asp:label></td>
										<td><asp:label ID="lblRubricaVal3Descripcion" runat="server" Text='<%#Eval("Val3Descripcion") %>'  Font-Size="10px"></asp:label></td>
										<td><asp:label ID="lblRubricaVal2Descripcion" runat="server" Text='<%#Eval("Val2Descripcion") %>'  Font-Size="10px"></asp:label></td>
										<td><asp:label ID="lblRubricaVal1Descripcion" runat="server" Text='<%#Eval("Val1Descripcion") %>'  Font-Size="10px"></asp:label></td>
									</tr>
									<tr>
										<td>&nbsp;</td>
										<td>&nbsp;</td>
										<td>&nbsp;</td>
										<td>&nbsp;</td>
										<td>&nbsp;</td>
									</tr>
									</table>
								</ItemTemplate>
							</asp:Repeater>

    <!--
						++++++++++++++++++++++++++++++++++++++++++++++++++
						+++++++++++++++    AQUI VA LA RÚBRICA A ++++++++++++++
						++++++++++++++++++++++++++++++++++++++++++++++++++
						-->
                                
                             <table style="width: 350px;" >
                                 <asp:Repeater ID="rptRubricasA" runat="server">
                                    <ItemTemplate>
                                   
                                       <tr>
                                           <td style="height:25px;" >
                                               <asp:label ID="lblRubricaTitulo" runat="server" Text='<%# Eval("Titulo") %>'  ><asp:label ID="lblRubricaID" runat="server" 
                                                    Visible="False"   ></asp:label>
</asp:label>
                                           </td>
                                           <td style="width: 50px" class="text-center">
                                               <asp:label ID="lblRubricaVal4" runat="server" Text='<%# Eval("Val1") %>' Font-Bold="True" ></asp:label>%
                                      
                                           </td>
                                         <%-- <td>
                                               <asp:Button ID="btnEditarRubricaA" runat="server" CssClass="btn btn-primary btn-sm"  CommandArgument='<%# Eval("idRubrica") %>' CommandName="EditarRubricaA" Text="Editar"   CausesValidation="False" meta:resourcekey="btnEditarRubricaAResource1" />
                                       
                                      
                                           </td>--%>
                                       </tr>
                              
                               
                            
                                    </ItemTemplate>
                                 </asp:Repeater>
                                  <tr>
                                      <td><asp:Label ID="Label14" runat="server" Text="TOTAL" Font-Bold="True" meta:resourcekey="Label14Resource1"></asp:Label></td>
                                      <td style="width: 50px; color:red;" class="text-center"><asp:label ID="lblTotalRubricaA" runat="server"  Font-Bold="True"  ></asp:label>%</td>
                                      <td></td>
                                  </tr>
                             </table>
                                  <div style="height:20px;"></div>

                            </div>

                      </div>


                     <div class="panel">
                            <div class="panel-heading">
                                    <h3 class="panel-title"><asp:Label ID="Label10" runat="server" Text="Comentarios de alumnos"  /></h3>
                            </div>
                            <div class="panel-body">
                                <uc3:displayComentarios ID="displayComentarios1" runat="server" />
                            </div>

                      </div>


                </div>
                <div class="col-xs-4">


                     <div class="panel">
                        <div class="panel-heading">
                                <h3 class="panel-title"><asp:Label ID="Respuesta" runat="server" text="Responder actividad"  /></h3>
                        </div>
                        <div class="panel-body" style="font-size:11px;">
                            <asp:Label ID="lblNoFecha" runat="server"  Text="Sin fecha de envío definida"></asp:Label>
                            <br />
                          <div runat="server" id="panelDesplegarFechas" visible="false">
                            <asp:Label ID="Label11" runat="server" Text="Abierta desde:" Font-Bold="true"></asp:Label>
                            <div style="height:3px"></div>
						<asp:Label ID="lblFechaEntrega" runat="server" Text=""></asp:Label>
                            <div style="height:6px"></div>
                        <asp:Label ID="Label16" runat="server" Text="Puede ser enviada hasta:" Font-Bold="true"></asp:Label>
                            <div style="height:3px"></div>
                            <asp:Label ID="lblFechaEntrega2" runat="server" Text=""></asp:Label>
                            <div style="height:15px"></div>
                            <asp:Label ID="lblFechaVencida" Visible="False"  runat="server"  Text="Ya no puede ser enviada esta actividad" ForeColor="Red"></asp:Label>
                        </div>
						    <div style="text-align:center;">
                                  <div style="height:15px"></div>
							    <asp:Button ID="btnEnviarTarea" Visible="false" runat="server" Text="Responder actividad" CssClass="btn btn-success form-control"  />
                                <div style="height:5px"></div>
							    <asp:Button ID="btnCalificar" Visible="false" runat="server" Text="Calificación grupal" CssClass="btn btn-default  form-control"   />
                                  <div style="height:5px"></div>
							    <asp:Button ID="btnVerRespuestas" Visible="false" runat="server" Text="Ver respuestas" CssClass="btn btn-default  form-control"   />
						    </div>
                        </div>

                     </div>
               

                   	<div class="panel">
                        <div class="panel-heading">
                                <h3 class="panel-title"><asp:Label ID="Label7" runat="server" Text="Adjuntos"></asp:Label></h3>
                        </div>
                        <div class="panel-body">
                            <asp:HyperLink ID="lnkBiblioteca" runat="server" NavigateUrl="~/Sec/Biblioteca.aspx" CssClass="btn-link" >Biblioteca digital</asp:HyperLink>
                            <div style="height:10px;"></div>

                            <uc2:showadjuntos ID="showContenidos" runat="server" />
                            <uc2:showadjuntos ID="showArchivosAdjuntos" runat="server" />
					        <uc2:showadjuntos ID="showDirecciones" runat="server" />
					        <uc2:showadjuntos ID="showImagenesAdjuntos" runat="server" />
					        <uc2:showadjuntos ID="showFlashes" runat="server" />


                        </div>
                    </div>



                    <uc1:displayBuscadores ID="displayBuscadores1" runat="server" />
                   

                </div>
   






</div>


            </div>

</div>

    

<asp:Label ID="labelCursosComoDocente" runat="server" Text="Cursos como docente" Visible="false"></asp:Label>
<asp:Label ID="labelCursosComoAlumno" runat="server" Text="Cursos como alumno"  Visible="false"></asp:Label>
    



</asp:Content>