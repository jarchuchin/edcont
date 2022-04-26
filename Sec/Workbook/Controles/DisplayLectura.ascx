<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayLectura.ascx.vb" Inherits="Sec_Workbook_Controles_DisplayLectura"  %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="showadjuntosedicion.ascx" tagname="showadjuntosedicion" tagprefix="uc1" %>


<%@ Register src="showAdjuntosEdicion2.ascx" tagname="showAdjuntosEdicion2" tagprefix="uc2" %>
<%@ Register src="showAdjuntosEdicion2Ligas.ascx" tagname="showAdjuntosEdicion2Ligas" tagprefix="uc3" %>






	<div class="panel">

        <div class="panel-heading">
             <h3 class="panel-title">
<asp:label id="lblTitulo" runat="server"  Text="Editar datos del contenido" meta:resourcekey="lblTituloResource1" ></asp:label>

             </h3>
        </div>

        <div class="panel-body">
     
<div class="form-horizontal" style="margin: auto; max-width: 100%;" >
     


<div class="alert alert-success" id="alertSuccess" runat="server" visible="false">
  <span class="glyphicon glyphicon-saved"></span><strong>&nbsp; <asp:Label ID="Label10" runat="server" Text="Listo!" meta:resourcekey="Label10Resource1"></asp:Label>&nbsp;&nbsp; </strong> <asp:Label ID="Label9" runat="server" Text="Cambios realizados correctamente." meta:resourcekey="Label9Resource1"></asp:Label>
</div>


<div class="alert alert-danger" id="lblMensajeBorrar" runat="server" visible="false">
  <span class="glyphicon glyphicon-saved"></span><strong>&nbsp; <asp:Label ID="Label11" runat="server" Text="Error!" meta:resourcekey="Label11Resource1"></asp:Label>&nbsp;&nbsp; </strong> <asp:label id="lblMensajeBorrarinside" runat="server"  text="Para borrar, debes eliminar todos los elementos asociados (En caso de tener respuestas asociadas este elemento no podrá ser borrado)" meta:resourcekey="lblMensajeBorrarinsideResource1"></asp:label>
</div>

<div class="alert alert-warning" id="lblMensajePublicar" runat="server" visible="false">
  <span class="glyphicon glyphicon-saved"></span><strong>&nbsp; <asp:Label ID="Label1" runat="server" Text="Recuerda!" meta:resourcekey="Label1Resource1"></asp:Label>&nbsp;&nbsp; </strong> <asp:label id="Label7" runat="server"  text="Estas modificando una versión de borrador. Da clic en publicar para presentar los datos" meta:resourcekey="Label7Resource1"></asp:label>
</div>

 <asp:validationsummary id="ValidationSummary1" runat="server" ForeColor="Red" headertext="Los campos marcados con * son requeridos o no estan en formato apropiado"  displaymode="List" CssClass="alert alert-danger" meta:resourcekey="ValidationSummary1Resource1"></asp:validationsummary>
    
<asp:label id="lblMensajeEspacio" runat="server" Visible="False"  ForeColor="Red" text="No hay suficiente espacio en tu cuenta para grabar estos archivos" meta:resourcekey="lblMensajeEspacioResource1"></asp:label>
 

<asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
    <ProgressTemplate>
        <div > <asp:Image ID="Image1" runat="server"  ImageUrl ="~/Images/indicator.gif" meta:resourcekey="Image1Resource1" />
            &nbsp;<asp:Label ID="lbltexto" runat="server"   Text="Actualizando datos..." meta:resourcekey="lbltextoResource1" ></asp:Label></div>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional" >
<ContentTemplate>
              
                 
   <div class="form-group">
    <label class="col-sm-2 control-label">
        <asp:Label ID="Label3" runat="server" Text="Libro de trabajo" meta:resourcekey="Label3Resource1"></asp:Label>
    </label>
    <div class="col-sm-10">
        <asp:Label ID="lblLibro" runat="server" meta:resourcekey="lblLibroResource1" ></asp:Label>   
        </div>
    </div>


    <div class="form-group">
        <label class="col-sm-2 control-label">
                <asp:Label ID="lblUbicacion" runat="server" 
                                        Text="Seleccionar unidad" meta:resourcekey="lblUbicacionResource1"></asp:Label>
        </label>
         <div class="col-sm-10">
              <asp:DropDownList ID="drpUbicacion" runat="server"   CssClass="form-control" meta:resourcekey="drpUbicacionResource1" ></asp:DropDownList>
        </div>
    </div>

        <div class="form-group">
        <label class="col-sm-2 control-label">
                   <asp:Label ID="lbltituloContenido" runat="server" meta:resourcekey="lbltituloContenidoResource1"  >Título</asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="txtTitulo" Display="Dynamic" meta:resourcekey="RequiredFieldValidator1Resource1">*</asp:RequiredFieldValidator>
        </label>
         <div class="col-sm-10">
                 <asp:TextBox ID="txtTitulo" runat="server" MaxLength="200"   CssClass="form-control" meta:resourcekey="txtTituloResource1"></asp:TextBox>
                                    <asp:TextBox ID="txtid" runat="server" Visible="False" meta:resourcekey="txtidResource1"></asp:TextBox>
        </div>
    </div>

        <div class="form-group">
        <label class="col-sm-2 control-label">
             <asp:Label ID="lblLectura" runat="server" meta:resourcekey="lblLecturaResource1"  >Texto</asp:Label>
        </label>
         <div class="col-sm-10">

              <asp:TextBox ID="txtMensaje" runat="server" 
                                        TextMode="MultiLine"   CssClass="form-control" ClientIDMode="Static" meta:resourcekey="txtMensajeResource1"></asp:TextBox>

             <script>
                 $(document).ready(function () {
                     $("#txtMensaje").cleditor({
                         height: 450,
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
              <asp:Label ID="Label4" runat="server" Text="Sugerencias para instructor" meta:resourcekey="Label4Resource1" ></asp:Label>
        </label>
         <div class="col-sm-10">
               <asp:TextBox ID="txtparaInstructor" runat="server" Columns="55" Height="60px" Rows="7" 
                                        TextMode="MultiLine"   CssClass="form-control" meta:resourcekey="txtparaInstructorResource1"></asp:TextBox>
        </div>
    </div>

        <div class="form-group">
        <label class="col-sm-2 control-label">
              <asp:Label ID="lbltags" runat="server" Text="Tags separados por  comas" meta:resourcekey="lbltagsResource1" ></asp:Label>
        </label>
         <div class="col-sm-10">
               <asp:TextBox ID="txttags" runat="server" Columns="55" Height="60px" Rows="7" 
                                        TextMode="MultiLine"   CssClass="form-control" meta:resourcekey="txttagsResource1"></asp:TextBox>
        </div>
    </div>

        <div class="form-group">
        <label class="col-sm-2 control-label">
            <asp:Label ID="Label2" runat="server" Text="Dirección de video" meta:resourcekey="Label2Resource1"></asp:Label>
        </label>
         <div class="col-sm-10"><asp:TextBox ID="txturl" runat="server" MaxLength="200"  CssClass="form-control" meta:resourcekey="txturlResource1"></asp:TextBox>
        </div>
    </div>

    <div style="height:5px;"></div>

     <div class="form-group">
        <label class="col-sm-2 control-label">
        </label>
         <div class="col-sm-10">
             <asp:Button ID="btnGrabar" runat="server" CssClass="btn btn-success" Text="Grabar" meta:resourcekey="btnGrabarResource1" />&nbsp;
									<asp:Button ID="btnBorrar" runat="server" CssClass="btn btn-danger" Text="Borrar" Visible="False" CausesValidation="False" meta:resourcekey="btnBorrarResource1" />
									<cc1:ConfirmButtonExtender ID="btnBorrar_ConfirmButtonExtender" runat="server" ConfirmText="¿Desea borrar este contenido del sistema?" Enabled="True" TargetControlID="btnBorrar"></cc1:ConfirmButtonExtender> 

                                    &nbsp;
					                <asp:Button ID="btnregresar" runat="server" CssClass="btn btn-default" Text="Cancelar" CausesValidation="False" meta:resourcekey="btnregresarResource1"   />

             &nbsp;<asp:Button ID="btnPublicar" runat="server" CssClass="btn btn-warning" Text="Publicar versión" meta:resourcekey="btnPublicarResource1" />
             <cc1:ConfirmButtonExtender ID="btnPublicar_ConfirmButtonExtender" runat="server" ConfirmText="¿Deseas publicar esta versión del contenido?" TargetControlID="btnPublicar" Enabled="True">
             </cc1:ConfirmButtonExtender>
             &nbsp;<div style="height:40px;"></div>
                                    
									<asp:HyperLink ID="lnkVistaPrevia" runat="server" CssClass="btn btn-primary"  Enabled="False" meta:resourcekey="lnkVistaPreviaResource1">Vista previa</asp:HyperLink>
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
           <div class="col-sm-12"> <asp:TextBox ID="txtLigaurl" runat="server"   CssClass="form-control" Placeholder="ejem: http://www.google.com" meta:resourcekey="txtLigaurlResource1"></asp:TextBox></div>
      
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


    <div style="height:20px;"></div>
   

 
                                 
                  
                   
                             
                                  
                            
                              
   
                 </ContentTemplate> 
                  <Triggers>
                    <asp:PostBackTrigger ControlID="btnGrabar" />
                    
                    </Triggers>

               
 </asp:UpdatePanel>    

</div>

            </div>

        </div>


<asp:Literal ID="litScript" runat="server" ></asp:Literal>

