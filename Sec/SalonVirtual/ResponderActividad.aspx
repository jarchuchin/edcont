<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="ResponderActividad.aspx.vb" Inherits="Sec_SalonVirtual_ResponderActividad" title=""   ValidateRequest="false" %>



<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>



<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register src="Controles/displayApuntes.ascx" tagname="displayApuntes" tagprefix="uc2" %>

<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>

<%@ Register src="Controles/displayRespuestaArchivos.ascx" tagname="displayRespuestaArchivos" tagprefix="uc222" %>


<%@ Register src="Controles/displayRespuestasComentarios.ascx" tagname="displayRespuestasComentarios" tagprefix="uc3" %>


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
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/default.aspx" ></asp:HyperLink></li>
           <li><asp:HyperLink ID="lnkCurso" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/Sa/default.aspx" ></asp:HyperLink></li>
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Responder actividad" ></asp:Label></li>
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
                        <h3 class="panel-title"><asp:Label ID="lbltitulo" runat="server" Text=""></asp:Label></h3>
                </div>
                <div class="panel-body">




               <asp:TextBox ID="txtid" runat="server" Visible="False"></asp:TextBox>
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                displaymode="List" headertext="Los campos marcados con * son requeridos o no estan en el formato apropiado" />
                            <asp:Label ID="lblMensajeBorrar" runat="server" ForeColor="Red" Visible="False" Text="Los datos no pueden ser borrados"></asp:Label>
                            <asp:Label ID="lblerrorUM" runat="server" Font-Bold="True" ForeColor="Red" Visible="False" Text="Error al intentar grabar esta actividad"></asp:Label>
                   
                     <div style="height:5px;"></div>
              

                           <asp:Label ID="lblObservaciones0" runat="server" Font-Bold="True" text="Instrucciones generales"></asp:Label>
                            <div style="height:5px;"></div>
                           <asp:Label ID="lblinstrucciones" runat="server" Font-Italic="False"></asp:Label>
                           
                     <div style="height:5px;"></div>


                            <asp:Label ID="lblObservaciones" runat="server" Font-Bold="True" text="Observaciones del maestro"></asp:Label>
                            <div style="height:5px;"></div>
                            <asp:Label ID="observaciones" runat="server"></asp:Label>
                           <div style="height:5px;"></div>
          

                    <asp:Label ID="lblLectura" runat="server" Font-Bold="true" Text="Coloca tu respuesta o mensaje para el maestro" ></asp:Label>
                    &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtMensaje" Font-Bold="true" ForeColor="Red" Display="Dynamic">¡¡ Debes colocar tu respuesta o mensaje para el maestro en el cuadro de texto !!</asp:RequiredFieldValidator>

                    <div style="height:5px;"></div>

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


                       <div style=" height:25px;"></div>
                         
                      
                    <asp:Label ID="lblArchivos" runat="server" Font-Bold="True" Text="Archivos adjuntos"></asp:Label>
                    <br />
                    <uc222:displayRespuestaArchivos ID="displayRespuestaArchivos1" runat="server" />
                    <br />
                    
         
                <asp:FileUpload ID="File1" runat="server"  Width="80%"  cssClass="form-control" />
                    <div style="height:10px;"></div>
                <asp:FileUpload ID="File2" runat="server"  Width="80%"  cssClass="form-control"  />
                           
                <div style="height:15px;"></div>

                    <div class="alert alert-primary" role="alert">
                         <strong>Recuerda.</strong> El maestro se reserva el derecho de tomar las medidas necesarias en caso de detectarse plagio u otros asuntos que considere formativos
                    </div>

                <div style="height:15px;"></div>

          
                    <asp:Button ID="btnGrabar" runat="server" CssClass="btn btn-success" Text="Enviar respuesta" />
                    <asp:Label ID="lblMensajePermiso" runat="server" ForeColor="Red" 
                        Visible="False">No tienes permiso para responder esta actividad</asp:Label>
                    <asp:Label ID="lblMensajeReenviar" runat="server" ForeColor="Red" 
                        Visible="False">El maestro ha impedido que reenvies esta actividad</asp:Label>
                         <asp:Label ID="lblFechaVencida" Visible="False"  runat="server" CssClass="Chica" Text="La fecha ha vencido para responder ésta actividad" ForeColor="Red"></asp:Label>
               
       


                    

                    </div>
                </div>

                
                <div class="panel">
                <div class="panel-heading">
                        <h3 class="panel-title"><asp:Label ID="lbltitulodsd" runat="server" Text="Comentarios a esta actividad"></asp:Label></h3>
                </div>
                <div class="panel-body">
                       
                        <uc3:displayRespuestasComentarios ID="displayRespuestasComentarios1" runat="server" />
                </div>
            </div>  

             



            </div>
            
           <div class="col-xs-3">

               <style>

                   td {
                    padding:2px; height:27px;
                   
                   }
               </style>
               

                 <div class="panel">
                    <div class="panel-heading">
                            <h3 class="panel-title"><asp:Label ID="lblasdkf" runat="server" Text="Datos generales"></asp:Label></h3>
                    </div>
                    <div class="panel-body">
                              <asp:Panel ID="Panel1" runat="server" Visible="False">
                    <table id="Table11" border="0" cellpadding="1" cellspacing="1" width="100%">
                        <tr>
									<td width="130" style="padding:2px;">
										<asp:Label ID="lblCalificacion" runat="server" Font-Bold="True" >Calificación</asp:Label></td>
									<td>
										<asp:Label ID="Calificacion" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
                        </tr>
                        <tr>
									<td colspan="2" width="100%">
								

                                        <asp:Repeater ID="rptRubricas" runat="server">
                                            <headertemplate>
                                            	   <div style="height:15px;"></div>
                                            </headertemplate>
                                            <ItemTemplate>
                                         
                                                <table cellPadding="2" cellSpacing="2" style="width: 100%">
                                                    <tr>
                                                        <td style="width: 139px">
                                                            <strong>Titulo: </strong>
                                                        </td>
                                                        <td style="width: 50px; text-align:center;"> <strong>Asignado:</strong>
                                                            <asp:Label ID="lblRubricaID" runat="server" Text='<%# eval("idRubrica") %>' 
                                                                Visible="False"></asp:Label>
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
                                                        <td style="width: 50px; text-align:center;">
                                                            <asp:Label ID="txtRubroCalificacion" runat="server" Text='<%# GetCalificacionRubro(cint(eval("idRubrica"))) %>' Font-Bold="true"  ></asp:Label>
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
                                                            <asp:Label ID="lblRubricaVal4Descripcion" runat="server" Font-Size="10px" 
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




                                          <!--
						++++++++++++++++++++++++++++++++++++++++++++++++++
						+++++++++++++++    AQUI VA LA RÚBRICA A ++++++++++++++
						++++++++++++++++++++++++++++++++++++++++++++++++++
						-->
                                
                             <table style="width: 100%;" >
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
                                    
                                    </td>
						</tr>
                      
                      
                        <tr>
                            <td width="130">
                                <asp:Label ID="lblfechacalendario" runat="server" Font-Bold="True" text="Agendado"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblFechaEntrega" runat="server" CssClass="Chica" ForeColor="Red" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="130">
                                <asp:Label ID="lblfechaRevision" runat="server" Font-Bold="True" text="Revisado"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="fechaRevision" runat="server" Font-Italic="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="130">
                                <asp:Label ID="lblfechaRegistro" runat="server" Font-Bold="True">Enviado</asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="fechaRegistro" runat="server" Font-Italic="False"></asp:Label>
                            </td>
                        </tr>

                         
                       
                    </table>


                                  
                                  <div class="text-center" style="padding-top:15px;"
>

  <asp:HyperLink ID="lnkVerRespuestas" runat="server"  cssclass="btn btn-default form-control"
                                            NavigateUrl="~/Sec/SalonVirtual/DesplegarRespuestas.aspx" text="Ver respuestas de 
                                        compañeros"></asp:HyperLink>
                                        <div style="height:6px;"></div>
                                        <asp:HyperLink ID="lnkCalificaciones" runat="server" cssclass="btn btn-default form-control"
                                    NavigateUrl="~/Sec/SalonVirtual/CalificacionesActividad.aspx" text="Ver 
                                        calificaciones"></asp:HyperLink>
                                  </div>                                 
                </asp:Panel>
                    </div>
                </div>  

            </div>

            
          

          </div>

    

        <asp:Label ID="labelCursosComoDocente" runat="server" Text="Cursos como docente" Visible="false"></asp:Label>
     <asp:Label ID="labelCursosComoAlumno" runat="server" Text="Cursos como alumno"  Visible="false"></asp:Label>


</asp:Content>

