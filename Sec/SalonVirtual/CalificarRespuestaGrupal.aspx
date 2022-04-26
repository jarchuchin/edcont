<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="CalificarRespuestaGrupal.aspx.vb" Inherits="Sec_SalonVirtual_CalificarRespuestaGrupal" title="Calificar respuesta grupal" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>
<%@ Register src="Controles/DisplayRanking.ascx" tagname="DisplayRanking" tagprefix="uc3" %>
<%@ Register src="Controles/displayRespuestaArchivos.ascx" tagname="displayRespuestaArchivos" tagprefix="uc2" %>


<%@ Register src="Controles/displayRespuestasComentarios.ascx" tagname="displayRespuestasComentarios" tagprefix="uc333" %>


<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>


<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server"  Text="Tareas recibidas" ></asp:Label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/default.aspx" ></asp:HyperLink></li>
           <li><asp:HyperLink ID="lnkCurso" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/Sa/default.aspx" ></asp:HyperLink></li>
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Tareas recibidas" ></asp:Label></li>
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
        <div class="col-xs-7">

                        
            <div class="panel">
                <div class="panel-heading">
                        <h3 class="panel-title"> <asp:Label ID="actividad" runat="server" ></asp:Label></h3>
                </div>
                <div class="panel-body">
     
      <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <div align="left" > <asp:Image ID="Image1" runat="server"  ImageUrl ="~/Images/indicator.gif" /><asp:Label ID="lbltexto" runat="server"   Text="Actualizando datos..." ></asp:Label></div>
                    </ProgressTemplate>
       </asp:UpdateProgress>
       <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional" >
               <ContentTemplate>	
                        
                    <%--    <table id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
                            <tr>
                                <td style="width:105px;" align="center">  
                                    <asp:Image ID="imgAlumno" runat="server" 
                                        ImageUrl="~/Sec/Usuarios/fotos/0100132.jpg" Height="100px" /></td>
                                <td valign="bottom">
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
                                                <asp:HyperLink ID="lnkCalificaciones" runat="server" 
                                                    NavigateUrl="~/Sec/SalonVirtual/CalificacionesActividad.aspx">Ver 
                                                calificaciones</asp:HyperLink>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
						            </table>
                                </td>
                            </tr>
                        </table>--%>
                        
                   <cc1:Accordion  ID="MyAccordion" runat="server" SelectedIndex="1"
             FadeTransitions="false" FramesPerSecond="40" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected"
            ContentCssClass="accordionContent" TransitionDuration="250" AutoSize="None" RequireOpenedPane="false" SuppressHeaderPostbacks="true">
                        <Panes>
                           <cc1:AccordionPane ID="AccordionPane1" runat="server">
                             <Header><a href="" class="accordionLink"><asp:Label ID="lblInstrucciones" runat="server" CssClass="Mediana" Font-Bold="true">Instrucciones</asp:Label></a></Header>
                              <Content> <asp:Label ID="lbltextoinstrucciones" runat="server" CssClass="Chica"></asp:Label></Content>
                           </cc1:AccordionPane>
                           
                            <cc1:AccordionPane ID="AccordionPane2" runat="server">
                             <Header><a href="" class="accordionLink">  <asp:Label ID="lblRespuestaAlumno" runat="server" CssClass="Mediana" 
                                          Font-Bold="True">Respuesta del alumno</asp:Label></a> </Header>
                              <Content>  <asp:literal id="littexto" runat="server"></asp:literal></Content>
                            </cc1:AccordionPane>
                            
                    
                            
                       </Panes>
                   </cc1:Accordion>



                         <div style="height:10px;"></div>
                   <div class="accordionHeader"> <asp:Label ID="lblArchivosAdjuntos" runat="server" CssClass="Mediana" Font-Bold="True">Archivos</asp:Label></div> 
                  <div class="accordionContent">  <uc2:displayRespuestaArchivos ID="displayRespuestaArchivos1" runat="server" /></div>


                         <asp:panel id="PanelRubrica" runat="server" Visible="False">

                                 <table id="Table2" cellspacing="1" cellpadding="1" width="100%" border="0">
											<tr>
												<td width="100"></td>
												<td>
													<asp:checkbox id="chkPermitir2" runat="server" CssClass="Mediana" Text="Permitir que el alumno reenvie la actividad"></asp:checkbox></td>
											</tr>
                                     </table>                      
                            
                                <asp:Repeater ID="rptRubricas" runat="server">
                                    <ItemTemplate>
                                        <table cellPadding="2" cellSpacing="2" style="width: 100%">
                                            <tr>
                                                <td style="width: 139px">
                                                    <strong>Titulo: </strong>
                                                </td>
                                                <td style="width: 50px">
                                                    <asp:Label ID="lblRubricaID" runat="server" Visible="False" Text='<%# eval("idRubrica") %>'></asp:Label>
                                                </td>
                                                 <td style="width: 166px">
                                                    </td>
                                                <td style="width: 166px">
                                                    &nbsp;</td>
                                                <td style="width: 163px">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 139px">
                                                    <asp:Label ID="lblRubricaTitulo" runat="server" Text='<%# eval("Titulo") %>'></asp:Label>
                                                </td>
                                                  <td style="width: 50px"> <asp:DropDownList ID="drpRubricaRow" runat="server" DataSource='<%# getRubricasDrop(cint(eval("idRubrica"))) %>' DataValueField="Valor" DataTextField="Valor"></asp:DropDownList>
                                                    </td>
                                                <td style="width: 167px">
                                                    <asp:Label ID="lblRubricaVal4" runat="server" Font-Bold="true" 
                                                        Text='<%# eval("Val4") %>'> </asp:Label>
                                                </td>
                                                <td style="width: 166px">
                                                    <asp:Label ID="lblRubricaVal3" runat="server" Font-Bold="true" 
                                                        Text='<%# eval("Val3") %>'></asp:Label>
                                                </td>
                                                <td style="width: 163px">
                                                    <asp:Label ID="lblRubricaVal2" runat="server" Font-Bold="true" 
                                                        Text='<%# eval("Val2") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblRubricaVal1" runat="server" Font-Bold="true" 
                                                        Text='<%# eval("Val1") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 139px">
                                                    <strong>Descripciones</strong></td>
                                                <td style="width: 50px">
                                                    </td>
                                                <td style="width: 167px">
                                                    <asp:Label ID="lblRubricaVal4Descripcion" runat="server"  Font-Size="10px"
                                                        Text='<%# eval("Val4Descripcion") %>'></asp:Label>
                                                </td>
                                                <td style="width: 166px">
                                                    <asp:Label ID="lblRubricaVal3Descripcion" runat="server" Font-Size="10px"
                                                        Text='<%# eval("Val3Descripcion") %>'></asp:Label>
                                                </td>
                                                <td style="width: 163px">
                                                    <asp:Label ID="lblRubricaVal2Descripcion" runat="server" Font-Size="10px"
                                                        Text='<%# eval("Val2Descripcion") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblRubricaVal1Descripcion" runat="server" Font-Size="10px"
                                                        Text='<%# eval("Val1Descripcion") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 139px">
                                                    &nbsp;</td>
                                                <td style="width: 50px">
                                                    </td>
                                                <td style="width: 167px">
                                                    &nbsp;</td>
                                                <td style="width: 166px">
                                                    &nbsp;</td>
                                                <td style="width: 163px">
                                                    &nbsp;</td>
                                                <td>
                                                   
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:Repeater>
                            

                            <div style="width:10px;"></div>

                            </asp:panel>


                             <asp:panel id="panelRubricaA" runat="server" Visible="False">
                                
                                
													<asp:checkbox id="chkPermitir2ra" runat="server"  Text="Permitir que el alumno reenvie la actividad"></asp:checkbox></td>
										                
                            

                                  <table cellPadding="2" cellSpacing="2" style="width: 100%">
                                           <tr>
                                              <td style="width: 250px; height:27px;">
                                                  <asp:Label ID="Label7" runat="server" Text="Rubrica" Font-Bold="true"></asp:Label></td>
                                              <td style="width: 90px; height:27px;">
                                                  <asp:Label ID="Label8" runat="server" Text="%" Font-Bold="true"></asp:Label>
                                              </td>
                                              <td><asp:Label ID="Label9" runat="server" Text="Calificar" Font-Bold="true"></asp:Label></td>
                                           </tr>
                                    </table>


                                <asp:Repeater ID="rptRubricaA" runat="server">
                                    <ItemTemplate>
                                        <table cellPadding="2" cellSpacing="2" style="width: 100%">
                                         
                                            <tr>
                                                <td style="width: 250px; height:27px;"> <asp:Label ID="lblRubricaID" runat="server" Visible="False" Text='<%#Eval("idRubrica") %>'></asp:Label>
                                                    <asp:Label ID="lblRubricaTitulo" runat="server" Text='<%# eval("Titulo") %>'></asp:Label>
                                                </td>
                                                
                                            
                                               <td style="width: 90px">
                                                    <asp:Label ID="lblRubricaVal1" runat="server" Font-Bold="true" 
                                                        Text='<%#Eval("Val1") %>'></asp:Label>
                                                </td>
                                                  <td>
                                                  <asp:DropDownList ID="drpRubricaRow" runat="server" DataSource='<%# getRubricasDropA(CInt(Eval("idRubrica"))) %>' CssClass="rubricaAdrop form-control"  Height="30px" Width="60px" DataValueField="Valor" DataTextField="Valor"  ></asp:DropDownList>
                                                    </td>
                                            </tr>
                                          
                                           
                                        </table>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <div style="text-align:right"></div>
                                 <table>
                                     <tr>
                                         <td style="width:340px">
                                             &nbsp;</td>
                                         <td style="text-align:center">
                                             __________</td>
                                     </tr>
                                     <tr>
                                         <td style="width:340px">
                                             <asp:Label ID="Label10" runat="server" Font-Bold="true" Text="Calficación del alumno"></asp:Label>
                                         </td>
                                         <td style="text-align:center">
                                             <asp:Label ID="lblTotalRA" runat="server" ClientIDMode="Static" Font-Bold="true">0</asp:Label>
                                         </td>
                                     </tr>
                                 </table>

                           <script>

                               //$('.rubricaAdrop').each(function(){
                               //    alert(this.text + ' ' + this.value);
                               //});

                               $('.rubricaAdrop').change(function () {
                                   //     alert(this.text + ' ' + this.value);
                                   var total = 0;
                                   $('.rubricaAdrop').each(function () {
                                       total = total + parseInt(this.value);
                                   });
                                   $('#lblTotalRA').html(total);
                               });


                           </script>

                            </asp:panel>

				
							<asp:panel id="PanelCalifica" runat="server" Visible="False">
										<table id="Table8" cellspacing="1" cellpadding="1" width="100%" border="0">
											<tr>
												<td width="100"></td>
												<td>
													<asp:checkbox id="chkPermitir" runat="server" CssClass="Mediana" 
                                                        Text="Permitir que el alumno reenvie la actividad" Visible="False"></asp:checkbox></td>
											</tr>
											<tr>
												<td width="100">
													<asp:Label id="lblCalificacion" runat="server" CssClass="Mediana">Calificacion</asp:Label>
													<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" ControlToValidate="txtCalificacion"
														Display="Dynamic">*</asp:requiredfieldvalidator>
													<asp:RangeValidator id="RangeValidator1" runat="server" 
                                                        ControlToValidate="txtCalificacion" Display="Dynamic"
														MinimumValue="0" MaximumValue="10" Type="Double">*</asp:RangeValidator></td>
												<td>
													<asp:TextBox id="txtCalificacion" runat="server" Columns="4" MaxLength="3"></asp:TextBox>
                                                    (0-10) Puede colocar hasta un decimal ejemplo 9.7</td>
											</tr>
										</table>
							</asp:panel>
							<asp:panel id="PanelRanking" runat="server" Visible="False">
										<table ID="Table11" border="0" cellpadding="1" cellspacing="1" width="120px">
                                            <tr>
                                                <td align="center">
                                                </td>
                                                <td align="center">
                                                    1</td>
                                                <td align="center">
                                                    2</td>
                                                <td align="center">
                                                    3</td>
                                                <td align="center">
                                                    4</td>
                                                <td align="center">
                                                    5</td>
                                                <td align="center">
                                                    6</td>
                                                <td align="center">
                                                    7</td>
                                                <td align="center">
                                                    8</td>
                                                <td align="center">
                                                    9</td>
                                                <td align="center">
                                                    10</td>
                                                <td align="center">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:Label ID="lblPobre" runat="server" CssClass="Mediana">Pobre</asp:Label>
                                                </td>
                                                <td align="center">
                                                    <asp:RadioButton ID="Rate1" runat="server" GroupName="Rate" />
                                                </td>
                                                <td align="center">
                                                    <asp:RadioButton ID="Rate2" runat="server" GroupName="Rate" />
                                                </td>
                                                <td align="center">
                                                    <asp:RadioButton ID="Rate3" runat="server" GroupName="Rate" />
                                                </td>
                                                <td align="center">
                                                    <asp:RadioButton ID="Rate4" runat="server" GroupName="Rate" />
                                                </td>
                                                <td align="center">
                                                    <asp:RadioButton ID="Rate5" runat="server" GroupName="Rate" />
                                                </td>
                                                <td align="center">
                                                    <asp:RadioButton ID="Rate6" runat="server" GroupName="Rate" />
                                                </td>
                                                <td align="center">
                                                    <asp:RadioButton ID="Rate7" runat="server" GroupName="Rate" />
                                                </td>
                                                <td align="center">
                                                    <asp:RadioButton ID="Rate8" runat="server" GroupName="Rate" />
                                                </td>
                                                <td align="center">
                                                    <asp:RadioButton ID="Rate9" runat="server" GroupName="Rate" />
                                                </td>
                                                <td align="center">
                                                    <asp:RadioButton ID="Rate10" runat="server" GroupName="Rate" />
                                                </td>
                                                <td align="center">
                                                    <asp:Label ID="lblexelente" runat="server" CssClass="Mediana">Exelente</asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <uc3:DisplayRanking ID="DisplayRanking1" runat="server" />
							</asp:panel>
							<asp:label id="lblLectura" runat="server" CssClass="Mediana">Observaciones para el alumno</asp:label>
							<asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" ControlToValidate="txtMensaje" Display="Dynamic">*</asp:requiredfieldvalidator>


                     <div style="height:3px;"></div>
                   
                     <asp:TextBox ID="txtMensaje" TextMode="MultiLine" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>


                      <script>
                          $(document).ready(function () {
                              $("#txtMensaje").cleditor({
                                  height: 250,
                                  controls: // controls to add to the toolbar
                              "bold italic underline strikethrough subscript superscript | font size " +
                              "style | color highlight removeformat | bullets numbering | outdent " +
                              "indent | alignleft center alignright justify | undo redo | " +
                              "rule image link unlink | cut copy paste pastetext | print source",
                                  fonts: // font names in the font popup
                             "Verdana, Arial,Arial Black,Comic Sans MS,Courier New,Narrow,Garamond," +
                             "Georgia,Impact,Sans Serif,Serif,Tahoma,Trebuchet MS",
                                  bodyStyle:
                                      "margin:4px; font:10pt Verdana,Arial; cursor:text"
                              });

                          });
                    </script>          


                    <div style="height:20px;"></div>

						<asp:Label ID="lblfile1" runat="server" CssClass="Mediana">Archivos adjuntos</asp:Label><br />
			            <input id="File1" runat="server" name="File1" type="file"/><br />
				        <input id="File2" type="file" name="File2" runat="server"/>
				        <div align="center">
						<asp:button id="btnGrabar" runat="server" CssClass="BotonSubmit" Text="Grabar"></asp:button></div>

               </ContentTemplate>
           <Triggers>
           <asp:PostBackTrigger ControlID="btnGrabar" />
           </Triggers>
        </asp:UpdatePanel>


                      </div>
                </div>


                   <div class="panel">
                <div class="panel-heading">
                        <h3 class="panel-title"><asp:Label ID="lbltitulodsd" runat="server" Text="Comentarios para el alumno"></asp:Label></h3>
                </div>
                <div class="panel-body">
                       
                        <uc333:displayRespuestasComentarios ID="displayRespuestasComentarios1" runat="server" />
                </div>
            </div>  


            </div>
            <div class="col-xs-2">


                 <div class="panel">
                <div class="panel-heading">
                        <h3 class="panel-title"><asp:Label ID="Label5" runat="server" Text="Alumno"></asp:Label></h3>
                </div>
                  <div class="panel-body">
                       
                    <div style="text-align:center; padding-bottom:10px;">
                         <asp:Image ID="imgAlumno" runat="server" 
                                        ImageUrl="~/Sec/Usuarios/fotos/0100132.jpg" Height="100px" />
                    </div>
                       





                   
                                                <asp:Label ID="lblEstudiante" runat="server"  Font-Bold="True" Text="Nombre del alumno:"></asp:Label><br />
                                           
                                                <asp:Label ID="estudiante" runat="server"></asp:Label>
                                           
                    <div style="height:3px;"></div>
                                                <asp:Label ID="lblfechaRegistro" runat="server" Font-Bold="True" Text="Fecha de primer envío:"></asp:Label><br />
                                           
                                                <asp:Label ID="fecharegistro" runat="server"></asp:Label>
                            <div style="height:3px;"></div>              
                                                 <asp:Label ID="lblFechaEnvio" runat="server"   Font-Bold="True" Text="Última actualización:"></asp:Label><br />
                                           
                                                 <asp:Label ID="fechaenvio" runat="server"></asp:Label><br />
                              <div style="height:10px;"></div>              
                                     
                                          
                                               
                                           
                                           
                                                <asp:HyperLink ID="lnkCalificaciones" runat="server" 
                                                    NavigateUrl="~/Sec/SalonVirtual/CalificacionesActividad.aspx" CssClass="btn btn-success form-control">Ver 
                                                calificaciones</asp:HyperLink>
                                           
                              

                </div>
</div>
                     
             

          

          </div>


         </div>
    

        <asp:Label ID="labelCursosComoDocente" runat="server" Text="Cursos como docente" Visible="false"></asp:Label>
    <asp:Label ID="labelCursosComoAlumno" runat="server" Text="Cursos como alumno"  Visible="false"></asp:Label>


</asp:Content>

