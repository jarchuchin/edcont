<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="Examen.aspx.vb" Inherits="Sec_Workbook_Examen" title="Agregar o editar exámenes" ValidateRequest="false" meta:resourcekey="PageResource1" uiculture="auto" Culture="auto" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<%@ Register src="Controles/showAdjuntosEdicion2.ascx" tagname="showAdjuntosEdicion2" tagprefix="uc2" %>
<%@ Register src="Controles/showAdjuntosEdicion2Ligas.ascx" tagname="showAdjuntosEdicion2Ligas" tagprefix="uc3" %>





<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>



<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:label id="lblTitulo" runat="server" Font-Bold="True" Text="Editar examen" meta:resourcekey="lblTituloResource1" ></asp:label></h1>
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

<div class="alert alert-warning" id="lblPreguntasError" runat="server" visible="false">
  <span class="glyphicon glyphicon-saved"></span><strong>&nbsp; <asp:Label ID="Label15" runat="server" Text="Alerta!" meta:resourcekey="Label15Resource1"></asp:Label>&nbsp;&nbsp; </strong> <asp:label id="Label16" runat="server"  text="Debes agregar preguntas para terminar la configuración del banco de preguntas" meta:resourcekey="Label16Resource1"></asp:label>
</div>

 <asp:validationsummary id="ValidationSummary1" runat="server" ForeColor="Red" headertext="Los campos marcados con * son requeridos o no estan en formato apropiado"  displaymode="List" CssClass="alert alert-danger" meta:resourcekey="ValidationSummary1Resource1"></asp:validationsummary>

<asp:label id="lblMensajeEspacio" runat="server" Visible="False"  ForeColor="Red" text="No hay suficiente espacio en tu cuenta para grabar estos archivos" meta:resourcekey="lblMensajeEspacioResource1"></asp:label>

 

      <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <div align="left" > <asp:Image ID="Image1" runat="server"  ImageUrl ="~/Images/indicator.gif" meta:resourcekey="Image1Resource1" /><asp:Label ID="lbltexto" runat="server"   Text="Actualizando datos..." meta:resourcekey="lbltextoResource1" ></asp:Label></div>
                    </ProgressTemplate>
       </asp:UpdateProgress>
       <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional" >
               <ContentTemplate>



                   

 <ul class="nav nav-tabs">
	<li class="active"> <a  href="#1" data-toggle="tab"><asp:Label ID="Label1" runat="server" Text="Datos del examen" meta:resourcekey="Label1Resource1"></asp:Label></a></li>
	<li><a href="#2" data-toggle="tab"><asp:Label ID="Label8" runat="server" Text="Configuración avanzada" meta:resourcekey="Label8Resource1"></asp:Label></a></li>
	<li><a href="#3" data-toggle="tab"><asp:Label ID="Label2" runat="server" Text="Lista de preguntas" meta:resourcekey="Label2Resource1"></asp:Label></a></li>
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
        <label class="col-sm-2 control-label">  <asp:Label ID="lblLectura" runat="server" text="Instrucciones generales" meta:resourcekey="lblLecturaResource1"></asp:Label>
        </label>
         <div class="col-sm-10"> <asp:TextBox ID="txtInstrucciones" runat="server" Rows="8" TextMode="MultiLine" CssClass="form-control" meta:resourcekey="txtInstruccionesResource1" ></asp:TextBox></div>
    </div>

   


      



            <div class="form-group">
        <label class="col-sm-2 control-label"> 
        </label>
         <div class="col-sm-10"></div>
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
            <h4><asp:Label ID="Label6" runat="server" Text="Archivos adjuntos" meta:resourcekey="Label6Resource1"></asp:Label></h4>
         <asp:Label ID="lblArchivos1" runat="server"  Text="Arrastra y suelta los archivos que deseas subir" CssClass="control-label" meta:resourcekey="lblArchivos1Resource1"></asp:Label>
 
             <asp:Button ID="btnRefrescar" runat="server" ClientIDMode="Static" CssClass="invisible" meta:resourcekey="btnRefrescarResource1" />

            <div id="fileuploader">Subir archivos</div>
    
            <asp:HiddenField ID="hdUs" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdc" runat="server" ClientIDMode="Static" />


            <uc2:showAdjuntosEdicion2 ID="showAdjuntosEdicion21" runat="server" />


        </div>
         <div class="col-sm-6">
             <h4><asp:Label ID="Label7" runat="server" Text="Ligas y referencias externas" meta:resourcekey="Label7Resource1"></asp:Label></h4>


        <div class="form-group">
       
             <label class="col-sm-2 control-label" style="text-align:left;"><asp:Label ID="lblLigaTitulo" runat="server"  text="Título" meta:resourcekey="lblLigaTituloResource1"></asp:Label></label>
              <div class="col-sm-12">
              <asp:TextBox ID="txtLigatitulo" runat="server" Columns="30" MaxLength="200"   CssClass="form-control" meta:resourcekey="txtLigatituloResource1"></asp:TextBox>
              </div>
        </div>
    


        <div class="form-group">
        
           <label class="col-sm-2 control-label" style="text-align:left;"><asp:Label ID="lblLigaUrl" runat="server" text="URL" meta:resourcekey="lblLigaUrlResource1" ></asp:Label> <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLigaurl" ErrorMessage="La liga de referencia es un campo requerido" ValidationGroup="liga" meta:resourcekey="RequiredFieldValidator3Resource1">*</asp:RequiredFieldValidator>
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

    <div class="form-group">
        <label class="col-sm-2 control-label"> <asp:Label ID="Label14" runat="server" Text="Funcionamiento" meta:resourcekey="Label14Resource1"></asp:Label>
        </label>
        <div class="col-sm-10">
            <asp:CheckBox ID="chkpresentacionAleatoria" runat="server" CssClass="labelNormal" Text="Presentación aleatoria" Checked="True" meta:resourcekey="chkpresentacionAleatoriaResource1" />
               <div style="height:3px"></div>
              <asp:CheckBox ID="chkActivarBanco" runat="server" CssClass="labelNormal" Text="Activar banco de preguntas"  AutoPostBack="True" meta:resourcekey="chkActivarBancoResource1"/>
            <div style="height:3px"></div>
            <asp:label id="Label12" runat="server" text="Al activar el banco de preguntas el sistema hará un examen nuevo para cada alumno sacando preguntas del total" Font-Size="11px" Font-Italic="True" meta:resourcekey="Label12Resource1"></asp:label>

        </div>
    </div>




    <div class="form-group" id="panelTotalPreguntas" runat="server" visible="False">
        <label class="col-sm-2 control-label"> <asp:label id="Label13" runat="server" text="Total de preguntas para usar" meta:resourcekey="Label13Resource1"></asp:label>
        </label>
        <div class="col-sm-10"><asp:DropDownList ID="drpTotalPreguntas" runat="server" CssClass="form-control form-inline" Width="80px" meta:resourcekey="drpTotalPreguntasResource1"></asp:DropDownList></div>
    </div>


     <div class="form-group">
        <label class="col-sm-2 control-label"> <asp:label id="lblPuntosPorRespuesta" runat="server" text="Asignación de puntos" meta:resourcekey="lblPuntosPorRespuestaResource1"></asp:label>
        </label>
        <div class="col-sm-10"><asp:RadioButtonList id="rdbPuntosPorRespuesta" runat="server" CssClass="labelNormal" meta:resourcekey="rdbPuntosPorRespuestaResource1">
																<asp:ListItem Value="1" Selected="True" Text="El sistema asigna el valor de manera automática" meta:resourcekey="ListItemResource1"></asp:ListItem>
																<asp:ListItem Value="2" Text="El valor se asigna a cada pregunta de manera personalizada" meta:resourcekey="ListItemResource2"></asp:ListItem>
															</asp:RadioButtonList></div>
    </div>

      <div class="form-group">
        <label class="col-sm-2 control-label"> 
                                                            <asp:Label ID="lblPuntosTotales" runat="server" text="Valor total de preguntas" meta:resourcekey="lblPuntosTotalesResource1"></asp:Label> <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                                ControlToValidate="txtPuntosTotales" Display="Dynamic" meta:resourcekey="RequiredFieldValidator2Resource1">*</asp:RequiredFieldValidator>
                                                            <asp:CustomValidator ID="CustomValidator1" runat="server" 
                                                                ControlToValidate="txtPuntosTotales" Display="Dynamic" meta:resourcekey="CustomValidator1Resource1">*</asp:CustomValidator>
        </label>
         <div class="col-sm-10"><asp:TextBox ID="txtPuntosTotales" runat="server" Columns="5" MaxLength="4"  Width="90px"   CssClass="form-control" Text="100" meta:resourcekey="txtPuntosTotalesResource1"></asp:TextBox></div>
    </div>

          <div class="form-group">
        <label class="col-sm-2 control-label"> <asp:label id="lblTiempoEnMinutos" runat="server" text="Tiempo para contestar el examen (en minutos)" meta:resourcekey="lblTiempoEnMinutosResource1"></asp:label>	
															<asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ControlToValidate="txttiempoenminutos"
																Display="Dynamic" meta:resourcekey="RequiredFieldValidator4Resource1">*</asp:RequiredFieldValidator>
															<asp:CustomValidator id="CustomValidator2" runat="server" ControlToValidate="txttiempoenminutos" Display="Dynamic" meta:resourcekey="CustomValidator2Resource1">*</asp:CustomValidator>
        </label>
         <div class="col-sm-10"><asp:TextBox id="txttiempoenminutos" runat="server" Columns="5" MaxLength="4" Width="90px"  CssClass="form-control" Text="30" meta:resourcekey="txttiempoenminutosResource1"></asp:TextBox></div>
    </div>

          <div class="form-group">
        <label class="col-sm-2 control-label"> 
        </label>
         <div class="col-sm-10"> 
             <asp:CheckBox ID="chkcontestarSinAgenda" runat="server"  CssClass="labelNormal" Text="Permitir ver el examen antes de la fecha en agenda" meta:resourcekey="chkcontestarSinAgendaResource1" /><br />
              <asp:CheckBox ID="chkAutoevaluacion" runat="server"  CssClass="labelNormal" Text="El examen será una autoevaluación" meta:resourcekey="chkAutoevaluacionResource1" /><br />

             <asp:Label ID="Label4" runat="server" Text="Cuando un examen es una autoevaluación el alumno puede contestar el examen todas las veces que quiera. La calificación que se le asigne al examen sera la última nota que haya obtenido en el sistema" meta:resourcekey="Label4Resource1"></asp:Label>
             <div style="height:3px;"></div>
             <asp:Label ID="Label5" runat="server" Text="El alumno podrá observar las respuestas correctas del examen" ForeColor="Red" meta:resourcekey="Label5Resource1"></asp:Label>

         </div>
    </div>
    </div>
    
    <div class="tab-pane" id="3">
      <div style="height:20px;"></div>   

        <div class="row">
            <div class="col-md-1 text-center">
                <asp:ImageButton ID="ibExamenDirecta" runat="server" CausesValidation="False" ImageUrl="~/Images/iconPregDirecta.gif" ToolTip="Agregar pregunta directa" Width="100px" meta:resourcekey="ibExamenDirectaResource1" /><br />
                Pregunta directa

            </div>
            <div class="col-md-1 text-center">
                <asp:ImageButton ID="ibFalsoVerdadero" runat="server" CausesValidation="False" ImageUrl="~/Images/iconFoV.gif" ToolTip="Agregar pregunta de falso yverdadero" Width="100px" meta:resourcekey="ibFalsoVerdaderoResource1" />
                <br />
                Falso y verdadero
            </div>
            <div class="col-md-1 text-center">
                <asp:ImageButton ID="ibOpcionMultiple" runat="server" CausesValidation="False" ImageUrl="~/Images/iconOpcMul.gif" ToolTip="Agregar pregunta de opción multiple" Width="100px" meta:resourcekey="ibOpcionMultipleResource1" />
                   <br />
                Opción múltiple
            </div>
            <div class="col-md-1 text-center">
                <asp:ImageButton ID="ibRelacionColumnas" runat="server" CausesValidation="False" ImageUrl="~/Images/iconRelCol.gif" ToolTip="Agregar sección de relacionar columnas" Width="100px" meta:resourcekey="ibRelacionColumnasResource1" />
                <br />
                Relacionar columnas
            </div>
        </div>
      
		
		
		

        <div style="height:20px;"></div>  


        	<asp:DataGrid ID="dtgItem" runat="server" AutoGenerateColumns="False" CssClass="table table-hover" DataKeyField="idPregunta" GridLines="None" Width="100%" meta:resourcekey="dtgItemResource1">
							<selecteditemstyle backcolor="#C1CDD8" />
							<headerstyle font-bold="True" horizontalalign="Left" />
							<columns>

                                <asp:TemplateColumn>
                                    <HeaderStyle Width="30px" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# getContador() %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>


								<asp:templatecolumn>
									<headerstyle width="75px" />
									<itemstyle verticalalign="Top" HorizontalAlign="Center" />
									<itemtemplate>
                                        
										<asp:ImageButton ID="Imagebutton8" runat="server" AlternateText="Mover hacia abajo" CausesValidation="False" CommandName="bajar" ImageUrl="~/Images/arrow-down.png"   />&nbsp;
										<asp:ImageButton ID="Imagebutton6" runat="server" AlternateText="Mover hacia arriba" CausesValidation="False" CommandName="subir" ImageUrl="~/Images/arrow-up.png"   />
									</itemtemplate>
								</asp:templatecolumn>
								<asp:templatecolumn>
									<headerstyle width="30px" />
									<itemstyle horizontalalign="Center" verticalalign="Top" />
									<itemtemplate>
										<asp:HyperLink ID="Hyperlink12" runat="server" 
											ImageUrl='<%# "~/Images/" & getImagen(DataBinder.Eval(Container.DataItem, "tipoPregunta")) %>' 
											NavigateUrl='<%# GetLiga(CInt(DataBinder.Eval(Container.DataItem, "idPregunta")), CInt(DataBinder.Eval(Container.DataItem, "tipoPregunta"))) %>'  ></asp:HyperLink>
									</itemtemplate>
								</asp:templatecolumn>
								<asp:templatecolumn HeaderText="Preguntas existentes">
									<headerstyle horizontalalign="Left" />
									<itemstyle horizontalalign="Left" />
									<itemtemplate>
										<asp:HyperLink ID="lnkClasificacion" runat="server" 
											NavigateUrl='<%# GetLiga(CInt(DataBinder.Eval(Container.DataItem, "idPregunta")), CInt(DataBinder.Eval(Container.DataItem, "tipoPregunta"))) %>' 
											Text='<%# GetEnunciado(DataBinder.Eval(Container.DataItem, "enunciado"), CInt(DataBinder.Eval(Container.DataItem, "tipoPregunta"))) %>'  ></asp:HyperLink>
									</itemtemplate>
								</asp:templatecolumn>
								<asp:templatecolumn HeaderText="Puntos">
									<headerstyle width="50px" />
										<itemstyle horizontalalign="Right" />
									<itemtemplate>
										<asp:TextBox ID="txtValor" CssClass="textoNoData12" runat="server" Columns="4" MaxLength="4" ValidationGroup="lista"  style="text-align:right;" Text='<%# DataBinder.Eval(Container.DataItem, "Valor", "{0:.##}") %>' ></asp:TextBox>
										<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtValor" Display="Dynamic" MaximumValue="1000" MinimumValue="0" Type="Double" ValidationGroup="lista" meta:resourcekey="RangeValidator1Resource1">*</asp:RangeValidator>
										<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtValor" Display="Dynamic" ValidationGroup="lista" meta:resourcekey="RequiredFieldValidator1Resource2">*</asp:RequiredFieldValidator>
									</itemtemplate>
								</asp:templatecolumn>
							</columns>
						</asp:DataGrid>

						<div style="border-bottom:1px solid #999; height:20px;"></div>
						<table style="width:100%;" border="0" cellpadding="1" cellspacing="1">
						<tr>
							<td style="text-align:right; height:35px;" colspan="2">
								<asp:Label ID="lblTotalPreguntas" runat="server" ForeColor="Red" Text="Suma" meta:resourcekey="lblTotalPreguntasResource1"></asp:Label>
								<asp:Label ID="totalpreguntas" runat="server"  ></asp:Label>
							</td>
						</tr>
						<tr>
							<td style="text-align:right; height:35px;" colspan="2">
								<asp:Label ID="lblTotalExamen" runat="server" Font-Bold="True" Text="Valor total de preguntas" meta:resourcekey="lblTotalExamenResource1"></asp:Label>
								<asp:Label ID="totalexamen" runat="server"  ></asp:Label>
							</td>
						</tr>
						<tr>
							
							<td style="text-align:right; height:35px;" colspan="2"><asp:Button ID="btnGrabarListas" ValidationGroup="lista" runat="server" CssClass="btn btn-success btn-sm" Text="Actualizar valores" Visible="False" meta:resourcekey="btnGrabarListasResource1"  /><asp:Label ID="lblpdesarrollo" runat="server" Text="Pregunta de desarrollo" Visible="False" meta:resourcekey="lblpdesarrolloResource1"></asp:Label></td>
						</tr>
						</table>


          <div style="height:50px;"></div>   
        
               
  </div>                        

   


               </ContentTemplate> 
                  <Triggers>
                    <asp:PostBackTrigger ControlID="btnGrabar" />
                    <asp:PostBackTrigger ControlID="chkActivarBanco" />
                  </Triggers>

			</asp:UpdatePanel>    

		
	<asp:HiddenField ID="hidTAB" runat="server" Value="1" />
	<asp:HiddenField ID="hiddenIdActividad" runat="server" />
     <asp:Literal ID="litScript" runat="server" meta:resourcekey="litScriptResource1"></asp:Literal>
     <asp:Literal ID="litScript2" runat="server" meta:resourcekey="litScript2Resource1"></asp:Literal>
    </div>



    </div>
</div>
    


</asp:Content>
