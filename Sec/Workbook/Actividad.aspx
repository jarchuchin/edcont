<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="Actividad.aspx.vb" Inherits="Sec_Workbook_Actividad" title="Actividad"  ValidateRequest="False" meta:resourcekey="PageResource1" uiculture="auto" Culture="auto"%>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register src="Controles/showAdjuntosEdicion2.ascx" tagname="showAdjuntosEdicion2" tagprefix="uc2" %>
<%@ Register src="Controles/showAdjuntosEdicion2Ligas.ascx" tagname="showAdjuntosEdicion2Ligas" tagprefix="uc3" %>

<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:label id="lblTitulo" runat="server" Font-Bold="True" Text="Editar actividad" meta:resourcekey="lblTituloResource1" ></asp:label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">

     <uc22:MenuGeneral ID="MenuGeneral1" runat="server" />

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelBreadcrumb" Runat="Server">
	  <ol class="breadcrumb" >
  <li><asp:HyperLink ID="lnkSalirEdicion" runat="server" Text="Salir de edición" meta:resourcekey="lnkSalirEdicionResource1" ></asp:HyperLink>
      </li>
        </ol>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
     <script type="text/javascript">
        function pageLoad() {
            maintainSelectedTab();
        }
        function maintainSelectedTab() {

            var selectedTab = $("#<% =hidTAB.ClientID %>");
            var tabid = selectedTab.val() != "" ? selectedTab.val() : "1";
            $('.nav-tabs a[href="#' + tabid + '"]').tab('show');
            $(".nav-tabs a").click(function () {
                selectedTab.val($(this).attr("href").substring(1));
            });
        }


</script>


<div class="panel">
    <div class="panel-body">


<div class="form-horizontal" style="margin: auto; max-width: 100%;" >


<div class="alert alert-success" id="alertSuccess" runat="server" visible="false">
  <span class="glyphicon glyphicon-saved"></span><strong>&nbsp; <asp:Label ID="Label10" runat="server" Text="Listo!" meta:resourcekey="Label10Resource1"></asp:Label>&nbsp;&nbsp; </strong> <asp:Label ID="Label9" runat="server" Text="Cambios realizados correctamente." meta:resourcekey="Label9Resource1"></asp:Label>
</div>


<div class="alert alert-danger" id="lblMensajeBorrar" runat="server" visible="false">
  <span class="glyphicon glyphicon-saved"></span><strong>&nbsp; <asp:Label ID="Label11" runat="server" Text="Error!" meta:resourcekey="Label11Resource1"></asp:Label>&nbsp;&nbsp; </strong> <asp:label id="lblMensajeBorrarinside" runat="server"  text="Para borrar, debes eliminar todos los elementos asociados (En caso de tener respuestas asociadas este elemento no podrá ser borrado)" meta:resourcekey="lblMensajeBorrarinsideResource1"></asp:label>
</div>

 <asp:validationsummary id="ValidationSummary1" runat="server" ForeColor="Red" headertext="Los campos marcados con * son requeridos o no estan en formato apropiado"  displaymode="List" CssClass="alert alert-danger" meta:resourcekey="ValidationSummary1Resource1"></asp:validationsummary>

<asp:label id="lblMensajeEspacio" runat="server" Visible="False"  ForeColor="Red" text="No hay suficiente espacio en tu cuenta para grabar estos archivos" meta:resourcekey="lblMensajeEspacioResource1"></asp:label>



      <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <div > <asp:Image ID="Image1" runat="server"  ImageUrl ="~/Images/indicator.gif" meta:resourcekey="Image1Resource1" /><asp:Label ID="lbltexto" runat="server"   Text="Actualizando datos..." meta:resourcekey="lbltextoResource1" ></asp:Label></div>
                    </ProgressTemplate>
       </asp:UpdateProgress>
       <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional" >
  
           <ContentTemplate>


 <ul class="nav nav-tabs">
	<li class="active"> <a  href="#1" data-toggle="tab"><asp:Label ID="Label1" runat="server" Text="Datos de actividad" meta:resourcekey="Label1Resource1"></asp:Label></a></li>
	<li><a href="#2" data-toggle="tab"><asp:Label ID="Label2" runat="server" Text="Configuración avanzada" meta:resourcekey="Label2Resource1"></asp:Label></a></li>
</ul>

<div class="tab-content ">
	<div class="tab-pane active" id="1">
        

      <div style="height:20px;"></div>     
                    
                       
   <div class="form-group">
    <label class="col-sm-2 control-label">
        <asp:Label ID="Label3" runat="server" Text="Libro de trabajo" meta:resourcekey="Label3Resource1"></asp:Label>
    </label>
    <div class="col-sm-10"> 
        <asp:Label ID="lblLibro" runat="server" Text="Label" meta:resourcekey="lblLibroResource1"></asp:Label>
    </div>
    </div>

  

    <div class="form-group">
        <label class="col-sm-2 control-label">
                  <asp:label id="lblUbicacion" runat="server"  Text="Selecciona la unidad" meta:resourcekey="lblUbicacionResource1"></asp:label>
        </label>
        <div class="col-sm-10">
            <asp:DropDownList ID="drpUbicacion" runat="server" CssClass="form-control" meta:resourcekey="drpUbicacionResource1"></asp:DropDownList>
		</div>
    </div>

     <div class="form-group">
        <label class="col-sm-2 control-label">  <asp:Label ID="lbltituloContenido" runat="server" 
                       text="Título de actividad" meta:resourcekey="lbltituloContenidoResource1"></asp:Label><asp:RequiredFieldValidator 
                       ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitulo" 
                       Display="Dynamic" meta:resourcekey="RequiredFieldValidator1Resource1">*</asp:RequiredFieldValidator>
        </label>
        <div class="col-sm-10"><asp:TextBox ID="txtTitulo" runat="server"  MaxLength="200"  CssClass="form-control" meta:resourcekey="txtTituloResource1"></asp:TextBox>
							<asp:TextBox ID="txtid" runat="server" 
                       Visible="False" meta:resourcekey="txtidResource1"></asp:TextBox>
        </div>
     </div> 

 


           <div class="form-group">
        <label class="col-sm-2 control-label"> <asp:Label ID="lblLectura" runat="server" text="Instrucciones generales de esta actividad" meta:resourcekey="lblLecturaResource1"></asp:Label>
        </label>
        <div class="col-sm-10">
               <asp:TextBox ID="txtInstrucciones" runat="server" 
                                        TextMode="MultiLine"   CssClass="form-control" ClientIDMode="Static" meta:resourcekey="txtInstruccionesResource1"></asp:TextBox>

             <script>
                 $(document).ready(function () {
                     $("#txtInstrucciones").cleditor({
                         height: 350,
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
        </div>
     </div> 

           <div class="form-group">
        <label class="col-sm-2 control-label">
              <asp:Label ID="Label15" runat="server" text="Sugerencias para instructor" meta:resourcekey="Label15Resource1" ></asp:Label>
        </label>
         <div class="col-sm-10">
               <asp:TextBox ID="txtparaInstructor" runat="server" Columns="55" Height="60px" Rows="7" 
                                        TextMode="MultiLine"   CssClass="form-control" meta:resourcekey="txtparaInstructorResource1"></asp:TextBox>
        </div>
    </div>

    

    <div class="form-group">
        <label class="col-sm-2 control-label"><asp:Label ID="Label4" runat="server" Text="Tipo de actividad" meta:resourcekey="Label4Resource1"></asp:Label>
        </label>
        <div class="col-sm-10"><asp:TextBox ID="txtTipoX" runat="server" Columns="40" MaxLength="200" CssClass="form-control" meta:resourcekey="txtTipoXResource1"></asp:TextBox>
        </div>
     </div> 


    <div class="form-group">
        <label class="col-sm-2 control-label"><asp:Label ID="Label7" runat="server" Text="Objetivo/Competencia" meta:resourcekey="Label7Resource1"></asp:Label>
        </label>
        <div class="col-sm-10">
            <asp:TextBox ID="txtObjetivoCompetencia" runat="server" Columns="40"  Height="70px" CssClass="form-control" TextMode="MultiLine" meta:resourcekey="txtObjetivoCompetenciaResource1" ></asp:TextBox>
        </div>
     </div> 

<div class="form-group">
        <label class="col-sm-2 control-label"> <asp:Label ID="lbltags" runat="server" Text="Tags separados por comas" meta:resourcekey="lbltagsResource1" ></asp:Label>
        </label>
        <div class="col-sm-10"> <asp:TextBox ID="txttags" runat="server" Height="70px" TextMode="MultiLine" 
                            CssClass="form-control" meta:resourcekey="txttagsResource1"></asp:TextBox>
        </div>
     </div> 




     


   
    <div class="form-group">
        <label class="col-sm-2 control-label">
        </label>
        <div class="col-sm-10">
            	  <asp:Button ID="btnGrabar" runat="server" CssClass="btn btn-success" Text="Grabar" meta:resourcekey="btnGrabarResource1" />&nbsp;
									<asp:Button ID="btnBorrar" runat="server" CssClass="btn btn-danger" Text="Borrar" Visible="False" CausesValidation="False" meta:resourcekey="btnBorrarResource1" />
									<cc1:ConfirmButtonExtender ID="btnBorrar_ConfirmButtonExtender" runat="server" ConfirmText="¿Desea borrar este contenido del sistema?" Enabled="True" TargetControlID="btnBorrar"></cc1:ConfirmButtonExtender> 

                                    &nbsp;
					                <asp:Button ID="btnregresar" runat="server" CssClass="btn btn-default" Text="Cancelar" CausesValidation="False" meta:resourcekey="btnregresarResource1"   />

             <div style="height:40px;"></div>
                                    
									<asp:HyperLink ID="lnkVistaPrevia" runat="server" CssClass="btn btn-primary"  Enabled="False" Text="Vista previa" meta:resourcekey="lnkVistaPreviaResource1"></asp:HyperLink>
        </div>
    </div> 

           

    <hr />


    <div class="row" runat="server" id="rowAdjuntos">
        <div class="col-sm-6">
            <h4><asp:Label ID="Label5" runat="server" Text="Archivos adjuntos" meta:resourcekey="Label5Resource1"></asp:Label></h4>
         <asp:Label ID="lblArchivos1" runat="server"  Text="Arrastra y suelta los archivos que deseas subir" CssClass="control-label" meta:resourcekey="lblArchivos1Resource1"></asp:Label>
 
             <asp:Button ID="btnRefrescar" runat="server" ClientIDMode="Static" CssClass="invisible" meta:resourcekey="btnRefrescarResource1" />

            <div id="fileuploader">Subir archivos</div>
    
            <asp:HiddenField ID="hdUs" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdc" runat="server" ClientIDMode="Static" />


            <uc2:showAdjuntosEdicion2 ID="showAdjuntosEdicion21" runat="server" />


        </div>
         <div class="col-sm-6">
             <h4><asp:Label ID="Label6" runat="server" Text="Ligas y referencias externas" meta:resourcekey="Label6Resource1"></asp:Label></h4>


        <div class="form-group">
       
             <label class="col-sm-2 control-label" style="text-align:left;"><asp:Label ID="lblLigaTitulo" runat="server"  text="Título" meta:resourcekey="lblLigaTituloResource1"></asp:Label></label>
              <div class="col-sm-12">
              <asp:TextBox ID="txtLigatitulo" runat="server" Columns="30" MaxLength="200"   CssClass="form-control" meta:resourcekey="txtLigatituloResource1"></asp:TextBox>
              </div>
        </div>
    


        <div class="form-group">
        
           <label class="col-sm-2 control-label" style="text-align:left;"><asp:Label ID="lblLigaUrl" runat="server" text="URL" meta:resourcekey="lblLigaUrlResource1" ></asp:Label> <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLigaurl" ErrorMessage="La liga de referencia es un campo requerido" ValidationGroup="liga" meta:resourcekey="RequiredFieldValidator2Resource1">*</asp:RequiredFieldValidator>
            <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator2_ValidatorCalloutExtender" runat="server" TargetControlID="RequiredFieldValidator2" PopupPosition="BottomLeft" Enabled="True">
            </cc1:ValidatorCalloutExtender>
        </label>
           <div class="col-sm-12">  <asp:TextBox ID="txtLigaurl" runat="server"   CssClass="form-control"  placeholder="ejem: http://www.google.com" meta:resourcekey="txtLigaurlResource1"></asp:TextBox></div>
      
        </div>

        <div class="form-group">
        <label class="col-sm-2 control-label"></label>
              <div class="col-sm-12"> 
             <asp:Button ID="btnGrabarLiga" runat="server" Text="Agregar liga" ValidationGroup="liga" CssClass="btn btn-success  btn-sm" meta:resourcekey="btnGrabarLigaResource1" />
                  </div>
              

        </div>



          <uc3:showAdjuntosEdicion2Ligas ID="showAdjuntosEdicion2Ligas1" runat="server" />



        </div>
      </div>

    </div>

   
          
       

	<div class="tab-pane" id="2">
       


         <div style="height:20px;"></div>     


               

                   <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                       <ContentTemplate>


                             <div class="form-group">
                              <label class="col-sm-2 control-label">
                                  <asp:Label ID="Label8" runat="server" Text="Respuesta grupal" meta:resourcekey="Label8Resource1"></asp:Label>
                              </label>
                              <div class="col-sm-10" >
                                  <asp:CheckBox ID="chkActivarRespuestaGrupal" runat="server" Text="Activar respuesta grupal" AutoPostBack="True" CssClass="labelNormal" meta:resourcekey="chkActivarRespuestaGrupalResource1"/>
                                  <div class="form-inline">
                                  <asp:DropDownList ID="drpRespuestaGrupal" runat="server" Visible="False" CssClass="form-control" meta:resourcekey="drpRespuestaGrupalResource1" Width="70px">
                                      <asp:ListItem Text="2" Value="2" meta:resourcekey="ListItemResource1"></asp:ListItem>
                                      <asp:ListItem Text="3" Value="3" meta:resourcekey="ListItemResource2"></asp:ListItem>
                                      <asp:ListItem Text="4" Value="4" meta:resourcekey="ListItemResource3"></asp:ListItem>
                                      <asp:ListItem Text="5" Value="5" meta:resourcekey="ListItemResource4"></asp:ListItem>
                                      <asp:ListItem Text="6" Value="6" meta:resourcekey="ListItemResource5"></asp:ListItem>
                                      <asp:ListItem Text="7" Value="7" meta:resourcekey="ListItemResource6"></asp:ListItem>
                                      <asp:ListItem Text="8" Value="8" meta:resourcekey="ListItemResource7"></asp:ListItem>
                                      <asp:ListItem Text="9" Value="9" meta:resourcekey="ListItemResource8"></asp:ListItem>
                                      <asp:ListItem Text="10" Value="10" meta:resourcekey="ListItemResource9"></asp:ListItem>
                                  </asp:DropDownList>&nbsp; <asp:Label ID="lblAlumnosgrupal" runat="server" Text="Cantidad de alumnos por grupo"></asp:Label>

                                      </div>


                              </div>

                           </div>


                               <div class="form-group">
                                <label class="col-sm-2 control-label">
                                    <asp:label id="lblComoSeCalifica" runat="server" Text="¿Cómo se calificará la actividad?" meta:resourcekey="lblComoSeCalificaResource1"></asp:label>
                                </label>
                                <div class="col-sm-10" >
                                    <asp:radiobuttonlist id="rdbComoSeCalifica" runat="server"   CssClass="labelNormal" 
                                        AutoPostBack="True" RepeatLayout="Flow" meta:resourcekey="rdbComoSeCalificaResource1">
					                    <asp:ListItem Value="1" Selected="True" Text="Se asignará una calificación entre 0-100" meta:resourcekey="ListItemResource10" ></asp:ListItem>
					                    <asp:ListItem Value="2" Text="Ranking" meta:resourcekey="ListItemResource11"></asp:ListItem>
                                        <asp:ListItem Value="5" text="Usar rúbrica tipo A" meta:resourcekey="ListItemResource12"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="Usar rúbrica tipo B" meta:resourcekey="ListItemResource13"></asp:ListItem>
				                    </asp:radiobuttonlist>
                                  
                                </div>
                             </div> 


                    

                            <div class="form-group" runat="server" id="panelRubricaB" visible="False">
                                <label class="col-sm-2 control-label">
                                    <asp:label id="Label12" runat="server" Text="Rubrica tipo B" meta:resourcekey="Label12Resource1"></asp:label>
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
                                       </strong><asp:RequiredFieldValidator ID="RequiredFieldValidator8" 
                                           runat="server" ControlToValidate="txtRubricaTitulo" 
                                           ErrorMessage="El campo es requerido" ValidationGroup="rubrica" meta:resourcekey="RequiredFieldValidator8Resource1">*</asp:RequiredFieldValidator>
                                       <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator8_ValidatorCalloutExtender" 
                                           runat="server" Enabled="True" TargetControlID="RequiredFieldValidator8">
                                       </cc1:ValidatorCalloutExtender></td>
                                   <td style="width: 167px">
                                       <asp:TextBox ID="txtRubricaID" runat="server"   
                                           ValidationGroup="rubrica" Visible="False" Width="50px" meta:resourcekey="txtRubricaIDResource1"></asp:TextBox>
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
                                       <asp:TextBox ID="txtRubricaTitulo" runat="server" Columns="40" MaxLength="250"  CssClass="form-control" ValidationGroup="rubrica" Width="125px" meta:resourcekey="txtRubricaTituloResource1"></asp:TextBox>&nbsp;&nbsp;
                                   </td>
                                   <td style="width: 167px">
                                       <asp:TextBox ID="txtRubricaVal4" runat="server" MaxLength="3" CssClass="form-control"
                                           ValidationGroup="rubrica" Width="50px" Text="4" meta:resourcekey="txtRubricaVal4Resource1"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                           ControlToValidate="txtRubricaVal4" ErrorMessage="El campo es requerido" 
                                           ValidationGroup="rubrica" meta:resourcekey="RequiredFieldValidator4Resource1">*</asp:RequiredFieldValidator>
                                       <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator4_ValidatorCalloutExtender" 
                                           runat="server" Enabled="True" TargetControlID="RequiredFieldValidator4">
                                       </cc1:ValidatorCalloutExtender>
                                       <asp:RangeValidator ID="RangeValidator1" runat="server" 
                                           ControlToValidate="txtRubricaVal4" ErrorMessage="El rango no es correcto" 
                                           MaximumValue="100" MinimumValue="0" Type="Integer" 
                                           ValidationGroup="rubrica" meta:resourcekey="RangeValidator1Resource1">*</asp:RangeValidator>
                                   </td>
                                   <td style="width: 166px">
                                       <asp:TextBox ID="txtRubricaVal3" runat="server" MaxLength="3" CssClass="form-control"
                                           ValidationGroup="rubrica" Width="50px" Text="3" meta:resourcekey="txtRubricaVal3Resource1"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                           ControlToValidate="txtRubricaVal3" ErrorMessage="El campo es requerido" 
                                           ValidationGroup="rubrica" meta:resourcekey="RequiredFieldValidator5Resource1">*</asp:RequiredFieldValidator>
                                       <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator5_ValidatorCalloutExtender" 
                                           runat="server" Enabled="True" TargetControlID="RequiredFieldValidator5">
                                       </cc1:ValidatorCalloutExtender>
                                       <asp:RangeValidator ID="RangeValidator2" runat="server" 
                                           ControlToValidate="txtRubricaVal3" ErrorMessage="El rango no es correcto" 
                                           MaximumValue="100" MinimumValue="0" Type="Integer" 
                                           ValidationGroup="rubrica" meta:resourcekey="RangeValidator2Resource1">*</asp:RangeValidator>
                                   </td>
                                   <td style="width: 163px">
                                       <asp:TextBox ID="txtRubricaVal2" runat="server" MaxLength="3" CssClass="form-control"
                                           ValidationGroup="rubrica" Width="50px" Text="2" meta:resourcekey="txtRubricaVal2Resource1"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                           ControlToValidate="txtRubricaVal2" ErrorMessage="El campo es requerido" 
                                           ValidationGroup="rubrica" meta:resourcekey="RequiredFieldValidator6Resource1">*</asp:RequiredFieldValidator>
                                       <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator6_ValidatorCalloutExtender" 
                                           runat="server" Enabled="True" TargetControlID="RequiredFieldValidator6">
                                       </cc1:ValidatorCalloutExtender>
                                       <asp:RangeValidator ID="RangeValidator3" runat="server" 
                                           ControlToValidate="txtRubricaVal2" ErrorMessage="El rango no es correcto" 
                                           MaximumValue="100" MinimumValue="0" Type="Integer" 
                                           ValidationGroup="rubrica" meta:resourcekey="RangeValidator3Resource1">*</asp:RangeValidator>
                                   </td>
                                   <td>
                                       <asp:TextBox ID="txtRubricaVal1" runat="server" MaxLength="3" CssClass="form-control"
                                           ValidationGroup="rubrica" Width="50px" Text="1" meta:resourcekey="txtRubricaVal1Resource1"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                           ControlToValidate="txtRubricaVal1" ErrorMessage="El campo es requerido" 
                                           ValidationGroup="rubrica" meta:resourcekey="RequiredFieldValidator7Resource1">*</asp:RequiredFieldValidator>
                                       <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator7_ValidatorCalloutExtender" 
                                           runat="server" Enabled="True" TargetControlID="RequiredFieldValidator7">
                                       </cc1:ValidatorCalloutExtender>
                                       <asp:RangeValidator ID="RangeValidator4" runat="server" 
                                           ControlToValidate="txtRubricaVal1" ErrorMessage="El rango no es correcto" 
                                           MaximumValue="100" MinimumValue="0" Type="Integer" 
                                           ValidationGroup="rubrica" meta:resourcekey="RangeValidator4Resource1">*</asp:RangeValidator>
                                   </td>
                               </tr>
                               <tr>
                                   <td style="width: 139px">
                                       <strong>
                                           <asp:Label ID="Label18" runat="server" Text="Descripciones" meta:resourcekey="Label18Resource1"></asp:Label></strong></td>
                                   <td style="width: 167px">
                                       <asp:TextBox ID="txtRubricaVal4Descripcion" runat="server" Columns="40" CssClass="form-control" Height="61px" MaxLength="250" Text="Excelente" TextMode="MultiLine" ValidationGroup="rubrica" 
                                           Width="118px" meta:resourcekey="txtRubricaVal4DescripcionResource1"></asp:TextBox>
                                   </td>
                                   <td style="width: 166px">
                                       <asp:TextBox ID="txtRubricaVal3Descripcion" runat="server" Columns="40" CssClass="form-control" Height="61px" MaxLength="250" Text="Bueno" TextMode="MultiLine" ValidationGroup="rubrica" 
                                           Width="109px" meta:resourcekey="txtRubricaVal3DescripcionResource1"></asp:TextBox>
                                   </td>
                                   <td style="width: 163px">
                                       <asp:TextBox ID="txtRubricaVal2Descripcion" runat="server" Columns="40" CssClass="form-control" Height="61px" MaxLength="250" Text="Regular" TextMode="MultiLine" ValidationGroup="rubrica" 
                                           Width="105px" meta:resourcekey="txtRubricaVal2DescripcionResource1"></asp:TextBox>
                                   </td>
                                   <td>
                                       <asp:TextBox ID="txtRubricaVal1Descripcion" runat="server" Columns="40" CssClass="form-control" Height="61px" MaxLength="250" Text="Malo" TextMode="MultiLine" ValidationGroup="rubrica" 
                                           Width="131px" meta:resourcekey="txtRubricaVal1DescripcionResource1"></asp:TextBox>
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
                                       <cc1:ConfirmButtonExtender ID="btnBorrarRubrica_ConfirmButtonExtender2" 
                                           runat="server" 
                                           ConfirmText="Se burrará el registro de este rubro. ¿Deseas continuar?" 
                                           Enabled="True" TargetControlID="btnBorrarRubrica">
                                       </cc1:ConfirmButtonExtender>

                       

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
                                               <asp:Button ID="btnEditarRubricaA" runat="server" CssClass="btn btn-primary btn-sm"  CommandArgument='<%# Eval("idRubrica") %>' CommandName="EditarRubricaA" Text="Editar"   CausesValidation="False" meta:resourcekey="btnEditarRubricaAResource1" />
                                       
                                      
                                           </td>
                                       </tr>
                              
                               
                            
                                    </ItemTemplate>
                                 </asp:Repeater>
                                  <tr>
                                      <td><asp:Label ID="Label14" runat="server" Text="TOTAL" Font-Bold="True" meta:resourcekey="Label14Resource1"></asp:Label></td>
                                      <td style="width: 50px; color:red;" class="text-center"><asp:label ID="lblTotalRubricaA" runat="server"  Font-Bold="True" meta:resourcekey="lblTotalRubricaAResource1" ></asp:label>%</td>
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
                                       </strong><asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                                           runat="server" ControlToValidate="txtRubricaTitulo" 
                                           ErrorMessage="El campo es requerido" ValidationGroup="rubrica2" meta:resourcekey="RequiredFieldValidator3Resource1">*</asp:RequiredFieldValidator>
                                       <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" 
                                           runat="server" Enabled="True" TargetControlID="RequiredFieldValidator8">
                                       </cc1:ValidatorCalloutExtender></td>
                                   <td style="width: 50px">
                                       <asp:TextBox ID="txtRubricaAID" runat="server"   
                                           ValidationGroup="rubrica2" Visible="False" Width="50px" ></asp:TextBox>
                                   </td>
                                 
                                   <td style="width: 10px">
                                       &nbsp;</td>
                               </tr>
                               <tr>
                                   <td>
                                       <asp:TextBox ID="txtRubricaATitulo" runat="server" Columns="40" MaxLength="250"  CssClass="form-control" ValidationGroup="rubrica2"  ></asp:TextBox>&nbsp;&nbsp;
                                   </td>
                                   <td style="width: 50px">
                                       <asp:TextBox ID="txtRubricaAVal1" runat="server" MaxLength="3" CssClass="form-control"
                                           ValidationGroup="rubrica2" Width="50px" ></asp:TextBox> 
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                                           ControlToValidate="txtRubricaAVal1" ErrorMessage="El campo es requerido" 
                                           ValidationGroup="rubrica2" meta:resourcekey="RequiredFieldValidator9Resource1">*</asp:RequiredFieldValidator>
                                       <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" 
                                           runat="server" Enabled="True" TargetControlID="RequiredFieldValidator9">
                                       </cc1:ValidatorCalloutExtender>
                                       <asp:RangeValidator ID="RangeValidator5" runat="server" 
                                           ControlToValidate="txtRubricaAVal1" ErrorMessage="El rango no es correcto" 
                                           MaximumValue="100" MinimumValue="0" Type="Integer" 
                                           ValidationGroup="rubrica2" meta:resourcekey="RangeValidator5Resource1">*</asp:RangeValidator>
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
                                       <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" 
                                           runat="server" 
                                           ConfirmText="Se borrará el registro de este rubro. ¿Deseas continuar?" 
                                           Enabled="True" TargetControlID="btnBorrarRubrica">
                                       </cc1:ConfirmButtonExtender>



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
  

               </ContentTemplate> 
                  <Triggers>
                    <asp:PostBackTrigger ControlID="btnGrabar" />
                    <asp:PostBackTrigger ControlID="btnGrabarRubrica" />
                  </Triggers>



 </asp:UpdatePanel>    

	
</div>

    	<asp:HiddenField ID="hidTAB" runat="server" Value="1" />
    <asp:Literal ID="litScript" runat="server" meta:resourcekey="litScriptResource1"></asp:Literal>



    </div>
</div>
     
</asp:Content>
