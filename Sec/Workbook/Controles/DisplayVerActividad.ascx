<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayVerActividad.ascx.vb" Inherits="Sec_Workbook_Controles_DisplayVerActividad" %>


<%@ Register src="~/Sec/Workbook/Controles/showadjuntos.ascx" tagname="showadjuntos" tagprefix="uc2" %>

<asp:Panel ID="panelContenidos" runat="server" Visible="false">


   

         
<div class="row">
	<div class="col-xs-9">
		<div class="panel">

            <div class="panel-heading">
           
                 <h3 class="panel-title">
                       <asp:label ID="txtTitulo" runat="server"></asp:label>
                     </h3>
            </div>
			
             <div class="panel-body">


                 <div class="row">


			<asp:label ID="txtid" runat="server" 
                       Visible="False" ></asp:label>

 



        <h5> <asp:Label ID="lblLectura" runat="server" text="Instrucciones generales de esta actividad" ></asp:Label>
        </h5>
       
               <asp:label ID="txtInstrucciones" runat="server" 
                                       ClientIDMode="Static"></asp:label>

            
     

   
        <h5>
              <asp:Label ID="Label15" runat="server" text="Sugerencias para instructor" ></asp:Label>
        </h5>

               <asp:label ID="txtparaInstructor" runat="server" ></asp:label>


    

 
        <h5><asp:Label ID="Label4" runat="server" Text="Tipo de actividad"></asp:Label>
        </h5>
      <asp:label ID="txtTipoX" runat="server" ></asp:label>





        <h5><asp:Label ID="Label7" runat="server" Text="Objetivo/Competencia" ></asp:Label>
        </h5>
 
            <asp:label ID="txtObjetivoCompetencia" runat="server"  ></asp:label>
  



        <h5> <asp:Label ID="lbltags" runat="server" Text="Tags separados por comas" ></asp:Label>
        </h5>
       <asp:label ID="txttags" runat="server"  ></asp:label>
      





   
    

       


        <h5><asp:Label ID="Label2" runat="server" Text="Configuracion de actividad" ></asp:Label></h5> 


               

                   <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                       <ContentTemplate>


                             <div class="form-group">
                              <label class="col-sm-2 control-label">
                                  <asp:Label ID="Label8" runat="server" Text="Respuesta grupal" ></asp:Label>
                              </label>
                              <div class="col-sm-10" >
                                  <asp:CheckBox ID="chkActivarRespuestaGrupal" runat="server" Text="Activar respuesta grupal" AutoPostBack="True" CssClass="labelNormal" />
                                  <div class="form-inline">
                                  <asp:DropDownList ID="drpRespuestaGrupal" runat="server" Visible="False" meta:resourcekey="drpRespuestaGrupalResource1" Width="70px">
                                      <asp:ListItem Text="2" Value="2" ></asp:ListItem>
                                      <asp:ListItem Text="3" Value="3" ></asp:ListItem>
                                      <asp:ListItem Text="4" Value="4" ></asp:ListItem>
                                      <asp:ListItem Text="5" Value="5" ></asp:ListItem>
                                      <asp:ListItem Text="6" Value="6" ></asp:ListItem>
                                      <asp:ListItem Text="7" Value="7" ></asp:ListItem>
                                      <asp:ListItem Text="8" Value="8" ></asp:ListItem>
                                      <asp:ListItem Text="9" Value="9" ></asp:ListItem>
                                      <asp:ListItem Text="10" Value="10" ></asp:ListItem>
                                  </asp:DropDownList>&nbsp; <asp:Label ID="lblAlumnosgrupal" runat="server" Text="Cantidad de alumnos por grupo"></asp:Label>

                                      </div>


                              </div>

                           </div>


                               <div class="form-group">
                                <label class="col-sm-2 control-label">
                                    <asp:label id="lblComoSeCalifica" runat="server" Text="¿Cómo se calificará la actividad?" ></asp:label>
                                </label>
                                <div class="col-sm-10" >
                                    <asp:radiobuttonlist id="rdbComoSeCalifica" runat="server"   CssClass="labelNormal" 
                                        AutoPostBack="True" RepeatLayout="Flow" >
					                    <asp:ListItem Value="1" Selected="True" Text="Se asignará una calificación entre 0-100"  ></asp:ListItem>
					                    <asp:ListItem Value="2" Text="Ranking" ></asp:ListItem>
                                        <asp:ListItem Value="5" text="Usar rúbrica tipo A" ></asp:ListItem>
                                        <asp:ListItem Value="4" Text="Usar rúbrica tipo B" ></asp:ListItem>
				                    </asp:radiobuttonlist>
                                  
                                </div>
                             </div> 


                    

                            <div class="form-group" runat="server" id="panelRubricaB" visible="False">
                                <label class="col-sm-2 control-label">
                                    <asp:label id="Label12" runat="server" Text="Rubrica tipo B" ></asp:label>
                                </label>
                                <div class="col-sm-10" >


                                    <asp:LinkButton ID="lnkVerRubrica" runat="server" CausesValidation="False" Text="Agregar rúbrica" CssClass="btn btn-success btn-sm" meta:resourcekey="lnkVerRubricaResource1"></asp:LinkButton>
                                                                          <div style="height:10px;"></div>
   <asp:Repeater ID="rptRubricas" runat="server">
                            <ItemTemplate>
                                <table style="width: 100%" cellSpacing="2" cellPadding="2">
                               <tr>
                                   <td style="width: 139px">
                                       <strong>
                                           <asp:Label ID="Label16" runat="server" Text="Título :" meta:resourcekey="Label16Resource1"></asp:Label>
                                       </strong></td>
                                   <td style="width: 167px">
                                       <asp:label ID="lblRubricaID" runat="server" Visible="False" meta:resourcekey="lblRubricaIDResource1"></asp:label>
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
                                       <asp:label ID="lblRubricaTitulo" runat="server" Text='<%# Eval("Titulo") %>' ></asp:label>
                                   </td>
                                   <td style="width: 167px">
                                       <asp:label ID="lblRubricaVal4" runat="server" Text='<%# Eval("Val4") %>' Font-Bold="True" ></asp:label>
                                      
                                   </td>
                                   <td style="width: 166px">
                                       <asp:label ID="lblRubricaVal3" runat="server" Text='<%# Eval("Val3") %>' Font-Bold="True" ></asp:label>
                                   </td>
                                   <td style="width: 163px">
                                       <asp:label ID="lblRubricaVal2" runat="server" Text='<%# Eval("Val2") %>' Font-Bold="True" ></asp:label>
                                      
                                   </td>
                                   <td>
                                       <asp:label ID="lblRubricaVal1" runat="server" Text='<%# Eval("Val1") %>' Font-Bold="True" ></asp:label>
                                     
                                   </td>
                               </tr>
                               <tr>
                                   <td style="width: 139px">
                                       <strong>Descripciones</strong></td>
                                   <td style="width: 167px">
                                       <asp:label ID="lblRubricaVal4Descripcion" runat="server" Text='<%# Eval("Val4Descripcion") %>' ></asp:label>
                                   </td>
                                   <td style="width: 166px">
                                       <asp:label ID="lblRubricaVal3Descripcion" runat="server" Text='<%# Eval("Val3Descripcion") %>' ></asp:label>
                                   </td>
                                   <td style="width: 163px">
                                       <asp:label ID="lblRubricaVal2Descripcion" runat="server" Text='<%# Eval("Val2Descripcion") %>'></asp:label>
                                   </td>
                                   <td>
                                       <asp:label ID="lblRubricaVal1Descripcion" runat="server" Text='<%# Eval("Val1Descripcion") %>' ></asp:label>
                                   </td>
                               </tr>
                               <tr>
                                   <td style="width: 139px">
                                       &nbsp;</td>
                                   <td style="width: 167px">
                                       &nbsp;</td>
                                   <td style="width: 166px">
                                       &nbsp;</td>
                                   <td style="width: 163px">
                                       &nbsp;</td>
                                   <td>
                                       <asp:Button ID="btnEditarRubrica" runat="server" CssClass="btn btn-primary btn-sm"  CommandArgument='<%# Eval("idRubrica") %>' CommandName="EditarRubrica" Text="Editar"   CausesValidation="False" meta:resourcekey="btnEditarRubricaResource1" />
                                       
                                      
                                   </td>
                               </tr>
                           </table>
                      
                            
                            </ItemTemplate>
                         </asp:Repeater>


                                </div>
                            </div>


                        <div class="form-group" id="pnlRubrica"  visible="False" runat="server">
                                <label class="col-sm-2 control-label">
                           
                                </label>
                                <div class="col-sm-10" >

                         



                           <table style="width: 100%" cellSpacing="2" cellPadding="2">
                               <tr>
                                   <td style="width: 139px">
                                       <strong>
                                           <asp:Label ID="Label17" runat="server" Text="Título" meta:resourcekey="Label17Resource1"></asp:Label>
                                       </strong>
                                     </td>
                                   <td style="width: 167px">
                                       <asp:label ID="txtRubricaID" runat="server"   
                                           ValidationGroup="rubrica" Visible="False" Width="50px" ></asp:label>
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
                                       <asp:label ID="txtRubricaTitulo" runat="server" Columns="40" MaxLength="250"  ValidationGroup="rubrica" Width="125px" meta:resourcekey="txtRubricaTituloResource1"></asp:label>&nbsp;&nbsp;
                                   </td>
                                   <td style="width: 167px">
                                       <asp:label ID="txtRubricaVal4" runat="server" MaxLength="3"
                                           ValidationGroup="rubrica" Width="50px" Text="4" meta:resourcekey="txtRubricaVal4Resource1"></asp:label>
                                   
                                   </td>
                                   <td style="width: 166px">
                                       <asp:label ID="txtRubricaVal3" runat="server" MaxLength="3"
                                           ValidationGroup="rubrica" Width="50px" Text="3" meta:resourcekey="txtRubricaVal3Resource1"></asp:label>
                                      
                                   </td>
                                   <td style="width: 163px">
                                       <asp:label ID="txtRubricaVal2" runat="server" MaxLength="3"
                                           ValidationGroup="rubrica" Width="50px" Text="2" meta:resourcekey="txtRubricaVal2Resource1"></asp:label>
                                      
                                   </td>
                                   <td>
                                       <asp:label ID="txtRubricaVal1" runat="server" MaxLength="3"
                                           ValidationGroup="rubrica" Width="50px" Text="1" meta:resourcekey="txtRubricaVal1Resource1"></asp:label>
                                     
                                   </td>
                               </tr>
                               <tr>
                                   <td style="width: 139px">
                                       <strong>
                                           <asp:Label ID="Label18" runat="server" Text="Descripciones" meta:resourcekey="Label18Resource1"></asp:Label></strong></td>
                                   <td style="width: 167px">
                                       <asp:label ID="txtRubricaVal4Descripcion" runat="server" Columns="40" Height="61px" MaxLength="250" Text="Excelente" TextMode="MultiLine" ValidationGroup="rubrica" 
                                           Width="118px" meta:resourcekey="txtRubricaVal4DescripcionResource1"></asp:label>
                                   </td>
                                   <td style="width: 166px">
                                       <asp:label ID="txtRubricaVal3Descripcion" runat="server" Columns="40" Height="61px" MaxLength="250" Text="Bueno" TextMode="MultiLine" ValidationGroup="rubrica" 
                                           Width="109px" meta:resourcekey="txtRubricaVal3DescripcionResource1"></asp:label>
                                   </td>
                                   <td style="width: 163px">
                                       <asp:label ID="txtRubricaVal2Descripcion" runat="server" Columns="40" Height="61px" MaxLength="250" Text="Regular" TextMode="MultiLine" ValidationGroup="rubrica" 
                                           Width="105px" meta:resourcekey="txtRubricaVal2DescripcionResource1"></asp:label>
                                   </td>
                                   <td>
                                       <asp:label ID="txtRubricaVal1Descripcion" runat="server" Columns="40" Height="61px" MaxLength="250" Text="Malo" TextMode="MultiLine" ValidationGroup="rubrica" 
                                           Width="131px" meta:resourcekey="txtRubricaVal1DescripcionResource1"></asp:label>
                                   </td>
                               </tr>
                               <tr>
                                   <td style="width: 139px">
                                       &nbsp;</td>
                                   <td style="width: 167px">
                                       &nbsp;</td>
                                   <td style="width: 166px">
                                       &nbsp;</td>
                                  
                                   <td colspan="2" style="text-align:center;">
                                      
                                   </td>
                               </tr>
                           </table>


                       <asp:Button ID="btnGrabarRubrica" runat="server" CssClass="btn btn-success btn-sm" 
                                           Text="Grabar" ValidationGroup="rubrica" meta:resourcekey="btnGrabarRubricaResource1" />
                                     
                                       &nbsp;<asp:Button ID="btnCancelarRubrica" runat="server" CssClass="btn btn-default btn-sm" 
                                           Text="Cancelar" ValidationGroup="rubrica" CausesValidation="False" meta:resourcekey="btnCancelarRubricaResource1" />
                                      
                                      
                                       &nbsp;<asp:Button ID="btnBorrarRubrica" runat="server" CssClass="btn btn-danger btn-sm" 
                                           Text="Borrar" ValidationGroup="rubrica" Visible="False" meta:resourcekey="btnBorrarRubricaResource1" />
                                    
                       

                                 </div>
                            </div>



                                <div class="form-group" runat="server" id="panelRubricaA" visible="False">
                                <label class="col-sm-2 control-label">
                                    <asp:label id="Label13" runat="server" Text="Rúbrica tipo A" meta:resourcekey="Label13Resource1"></asp:label>
                                </label>
                                <div class="col-sm-10" >

                                        <asp:LinkButton ID="lnkVerRubricaA" runat="server" CssClass="btn btn-success btn-sm"  CausesValidation="False" Text="Agregar rúbrica" meta:resourcekey="lnkVerRubricaAResource1"></asp:LinkButton>
                                                                          <div style="height:10px;"></div>

                             <table style="width: 450px;" >
                                 <asp:Repeater ID="rptRubricasA" runat="server">
                                    <ItemTemplate>
                                   
                                       <tr>
                                           <td >
                                               <asp:label ID="lblRubricaTitulo" runat="server" Text='<%# Eval("Titulo") %>'  ><asp:label ID="lblRubricaID" runat="server" 
                                                    Visible="False"   ></asp:label>
</asp:label>
                                           </td>
                                           <td style="width: 50px" class="text-center">
                                               <asp:label ID="lblRubricaVal4" runat="server" Text='<%# Eval("Val1") %>' Font-Bold="True" ></asp:label>%
                                      
                                           </td>
                                          <td>
                                               <asp:Button ID="btnEditarRubricaA" runat="server" CssClass="btn btn-primary btn-sm"  CommandArgument='<%# Eval("idRubrica") %>' CommandName="EditarRubricaA" Text="Editar"   CausesValidation="False"  />
                                       
                                      
                                           </td>
                                       </tr>
                              
                               
                            
                                    </ItemTemplate>
                                 </asp:Repeater>
                                  <tr>
                                      <td><asp:Label ID="Label14" runat="server" Text="TOTAL" Font-Bold="True" meta:resourcekey="Label14Resource1"></asp:Label></td>
                                      <td style="width: 50px; color:red;" class="text-center"><asp:label ID="lblTotalRubricaA" runat="server"  Font-Bold="True"  ></asp:label>%</td>
                                      <td></td>
                                  </tr>
                             </table>
                                     
                                </div>
                                </div>






                              <div class="form-group" ID="pnlRubricaA" visible="False" runat="server">
                                <label class="col-sm-2 control-label">
                           
                                </label>
                                <div class="col-sm-10" >



                           <table style="width: 450px" cellSpacing="2" cellPadding="2">
                               <tr>
                                   <td  >
                                       <strong>
                                           <asp:Label ID="Label19" runat="server" Text="Titulo" meta:resourcekey="Label19Resource1"></asp:Label>
                                       </strong></td>
                                   <td style="width: 50px">
                                       <asp:label ID="txtRubricaAID" runat="server"   
                                           ValidationGroup="rubrica2" Visible="False" Width="50px" ></asp:label>
                                   </td>
                                 
                                   <td style="width: 10px">
                                       &nbsp;</td>
                               </tr>
                               <tr>
                                   <td>
                                       <asp:label ID="txtRubricaATitulo" runat="server" Columns="40" MaxLength="250"  ValidationGroup="rubrica2"  ></asp:label>&nbsp;&nbsp;
                                   </td>
                                   <td style="width: 50px">
                                       <asp:label ID="txtRubricaAVal1" runat="server" MaxLength="3"
                                           ValidationGroup="rubrica2" Width="50px" ></asp:label> 
                                      
                                   </td>
                               <td style="width: 10px">
                                       %</td>
                               </tr>
                              
                           </table>


                       <asp:Button ID="btnGrabarRubricaA" runat="server" CssClass="btn btn-success btn-sm" 
                                           Text="Grabar" ValidationGroup="rubrica2" meta:resourcekey="btnGrabarRubricaAResource1" />
                                     
                                       &nbsp;<asp:Button ID="btnCancelarRubricaA" runat="server" CssClass="btn btn-default btn-sm" 
                                           Text="Cancelar" ValidationGroup="rubrica2" CausesValidation="False" meta:resourcekey="btnCancelarRubricaAResource1" />
                                      
                                      
                                       &nbsp;<asp:Button ID="btnBorrarRubricaA" runat="server" CssClass="btn btn-danger btn-sm" 
                                           Text="Borrar" ValidationGroup="rubrica2" Visible="False"  CausesValidation="false" meta:resourcekey="btnBorrarRubricaAResource1" />
                                     



                                 </div>
                            </div>





                       </ContentTemplate>
                   </asp:UpdatePanel>
                          
        



                         <div class="form-group">
                            <label class="col-sm-2 control-label"><asp:label id="lblQuienCalifica" runat="server"  Text="¿Quién calificará esta actividad?" meta:resourcekey="lblQuienCalificaResource1"></asp:label>
                            </label>
                            <div class="col-sm-10">
                                <asp:radiobuttonlist id="rdbQuiencalifica"   runat="server"   CssClass="labelNormal"  RepeatLayout="Flow" meta:resourcekey="rdbQuiencalificaResource1">
					                    <asp:ListItem Value="1" Selected="True" Text="El maestro calificará la actividad" meta:resourcekey="ListItemResource14"></asp:ListItem>
					                    <asp:ListItem Value="2" Text="Los estudiantes calificarán la actividad" meta:resourcekey="ListItemResource15"></asp:ListItem>
				                    </asp:radiobuttonlist>
                            </div>
                         </div> 


                         <div class="form-group">
                            <label class="col-sm-2 control-label">
                            </label>
                            <div class="col-sm-10">
                               <asp:checkbox id="chkmostrarRespuestas" runat="server" Text="Permitir a los estudiantes ver las respuestas de otros"   CssClass="labelNormal" meta:resourcekey="chkmostrarRespuestasResource1"   ></asp:checkbox><BR>
				                    <asp:checkbox id="chkMostrarCalificacion" runat="server" Text="Permitir a los estudiantes ver la calificación asignada a los otros estudiantes"   CssClass="labelNormal" meta:resourcekey="chkMostrarCalificacionResource1"  ></asp:checkbox><BR>
				                    <asp:checkbox id="chkMostrarObservaciones" runat="server" Text="Permitir a los estudiantes ver las observaciones que el instructor da a las respuestas"   CssClass="labelNormal" meta:resourcekey="chkMostrarObservacionesResource1"  ></asp:checkbox>
                            </div>
                         </div> 

                            
                           
                           
        








     
                     </div>





                




            </div>

        </div>
    </div>
    <div class="col-xs-3">

            <div class="panel">

                <div class="panel-heading">
           
                     <h3 class="panel-title">
                            <asp:label ID="Label1" runat="server">Responder actividad</asp:label>
                         </h3>
                </div>
			
                 <div class="panel-body">
                     	<asp:Button ID="btnEnviarTarea"  runat="server" Text="Responder actividad" CssClass="btn btn-primary btn-sm form-control"  />
							<div style="height:5px"></div>
							<asp:Button ID="btnVerRespuestas" runat="server" Text="Ver respuestas" CssClass="btn btn-success btn-sm  form-control"  />
                 </div>
            </div>


   
							
				
					<uc2:showadjuntos ID="showArchivosAdjuntos" runat="server" />
					<uc2:showadjuntos ID="showDirecciones" runat="server" />
					<uc2:showadjuntos ID="showImagenesAdjuntos" runat="server" />
					<uc2:showadjuntos ID="showFlashes" runat="server" />





         <div class="panel">

                <div class="panel-heading">
           
                     <h3 class="panel-title">
                            <asp:label ID="Label3" runat="server">Biblioteca digital</asp:label>
                         </h3>
                </div>
			
                 <div class="panel-body">
                    
                 </div>
            </div>


					



    </div>

 </div>





                   

			

        <div style="page-break-after: always"></div>
    </asp:Panel>