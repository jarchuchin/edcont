<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayFlash.ascx.vb" Inherits="Sec_Workbook_Controles_DisplayFlash" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
      <h2 class="text-center"><asp:Label ID="Label1" runat="server" Text="Editar flash" meta:resourcekey="Label1Resource1"  ></asp:Label> </h2>
   <div style="height:10px;"></div>


<div class="alert alert-success" id="alertSuccess" runat="server" visible="false">
  <span class="glyphicon glyphicon-saved"></span><strong>&nbsp; <asp:Label ID="Label10" runat="server" Text="Listo!" meta:resourcekey="Label10Resource1"></asp:Label>&nbsp;&nbsp; </strong> <asp:Label ID="Label9" runat="server" Text="Cambios realizados correctamente." meta:resourcekey="Label9Resource1"></asp:Label>
</div>


<div class="alert alert-danger" id="lblMensajeBorrar" runat="server" visible="false">
  <span class="glyphicon glyphicon-saved"></span><strong>&nbsp; <asp:Label ID="Label11" runat="server" Text="Error!" meta:resourcekey="Label11Resource1"></asp:Label>&nbsp;&nbsp; </strong> <asp:label id="lblMensajeBorrarinside" runat="server"  text="Para borrar, debes eliminar todos los elementos asociados (En caso de tener respuestas asociadas este elemento no podrá ser borrado)" meta:resourcekey="lblMensajeBorrarinsideResource1"></asp:label>
</div>

 <asp:validationsummary id="ValidationSummary1" runat="server"  headertext="Los campos marcados con * son requeridos o no estan en formato apropiado"  displaymode="List" CssClass="alert alert-danger" meta:resourcekey="ValidationSummary1Resource1"></asp:validationsummary>


<div class="alert alert-danger" id="lblNoarchivo" runat="server" visible="false">
  <span class="glyphicon glyphicon-saved"></span><strong>&nbsp; <asp:Label ID="Label6" runat="server" Text="Error!" meta:resourcekey="Label6Resource1"></asp:Label>&nbsp;&nbsp; </strong><asp:Label ID="lblNoarchivo12" runat="server"  text="Se esperaba una archivo flash. Selecciona el archivo flash e intenta nuevamente." meta:resourcekey="lblNoarchivo12Resource1"></asp:Label>
</div>
                                   
 <asp:Label ID="lblMensajeEspacio" runat="server" ForeColor="Red"  Visible="False"  Text="No hay espacio en su cuenta para subir este contenido" meta:resourcekey="lblMensajeEspacioResource1"></asp:Label>




     <div class="form-horizontal" style="margin: auto; max-width: 650px;" >

      <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                         <asp:Image ID="Image1" runat="server"  ImageUrl ="~/Images/indicator.gif" meta:resourcekey="Image1Resource1" /><asp:Label ID="lbltexto" runat="server"   Text="Actualizando datos..." meta:resourcekey="lbltextoResource1" ></asp:Label>
                    </ProgressTemplate>
       </asp:UpdateProgress>
       <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional" >
               <ContentTemplate>

<div class="form-group">
    <label class="col-sm-3 control-label">
        <asp:Label ID="Label5" runat="server" Text="Libro de trabajo" meta:resourcekey="Label5Resource1"></asp:Label>
    </label>
    <div class="col-sm-9">
        <asp:Label ID="lblLibro" runat="server" meta:resourcekey="lblLibroResource1" ></asp:Label>
   
    </div>
</div>

<div class="form-group">
    <label class="col-sm-3 control-label">
         <asp:Label ID="lblUbicacion" runat="server"   Text="Seleccionar unidad" meta:resourcekey="lblUbicacionResource1"></asp:Label>
    </label>
    <div class="col-sm-9">
         <asp:DropDownList ID="drpUbicacion" runat="server"  CssClass="form-control" meta:resourcekey="drpUbicacionResource1" > </asp:DropDownList>
    </div>
</div>


<div class="form-group">
    <label class="col-sm-3 control-label">
        <asp:Label ID="lbltituloContenido" runat="server" Text="Título de archivo" meta:resourcekey="lbltituloContenidoResource1" ></asp:Label>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                       ControlToValidate="txtTitulo" Display="Dynamic" meta:resourcekey="RequiredFieldValidator1Resource1">*</asp:RequiredFieldValidator>
    </label>
    <div class="col-sm-9">
        <asp:TextBox ID="txtTitulo" runat="server"  CssClass="form-control" MaxLength="200" meta:resourcekey="txtTituloResource1"></asp:TextBox>
				<asp:TextBox ID="txtid" runat="server" Visible="False" meta:resourcekey="txtidResource1"></asp:TextBox>
    </div>
</div>

<div class="form-group">
    <label class="col-sm-3 control-label">
        	<asp:label id="lblTextoCorto" runat="server" Text="Descripción" meta:resourcekey="lblTextoCortoResource1" ></asp:label>
				<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" Display="Dynamic" ControlToValidate="txtTextoCorto" meta:resourcekey="RequiredFieldValidator2Resource1">*</asp:requiredfieldvalidator>
				<asp:customvalidator id="CustomValidator1" runat="server" Display="Dynamic" ControlToValidate="txtTextoCorto" meta:resourcekey="CustomValidator1Resource1">*</asp:customvalidator>
    </label>
    <div class="col-sm-9">
        <asp:textbox id="txtTextoCorto" runat="server"  CssClass="form-control"
                    TextMode="MultiLine" Height="60px" meta:resourcekey="txtTextoCortoResource1"></asp:textbox>
    </div>
</div>


<div class="form-group">
    <label class="col-sm-3 control-label">
           <asp:Label ID="lbltags" runat="server"  Text="Tags separados por comas" meta:resourcekey="lbltagsResource1"></asp:Label>
    </label>
    <div class="col-sm-9">
         <asp:TextBox ID="txttags" runat="server"  Height="60px" 
                    TextMode="MultiLine"  CssClass="form-control" meta:resourcekey="txttagsResource1" ></asp:TextBox>
    </div>
</div>

<div class="form-group">
    <label class="col-sm-3 control-label">
           <asp:Label ID="Label2" runat="server"  Text="Url" meta:resourcekey="Label2Resource1"></asp:Label>
    </label>
    <div class="col-sm-9">
         <asp:TextBox ID="txturl" runat="server"  CssClass="form-control" meta:resourcekey="txturlResource1" ></asp:TextBox>
    </div>
</div>


<div class="form-group">
    <label class="col-sm-3 control-label">
          <asp:Label ID="Label3" runat="server" Text="Ancho" meta:resourcekey="Label3Resource1"></asp:Label>&nbsp;<asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" Display="Dynamic" ControlToValidate="txtAncho" meta:resourcekey="RequiredFieldValidator3Resource1">*</asp:RequiredFieldValidator>
				<asp:CustomValidator id="CustomValidator2" runat="server" Display="Dynamic" ControlToValidate="txtAncho" meta:resourcekey="CustomValidator2Resource1">*</asp:CustomValidator>
    </label>
    <div class="col-sm-9">
        
    <asp:TextBox ID="txtancho" runat="server"  CssClass="form-control"  Width="50px" meta:resourcekey="txtanchoResource1" ></asp:TextBox>
    </div>
</div>

<div class="form-group">
    <label class="col-sm-3 control-label"><asp:Label ID="Label4" runat="server" Text="Alto" meta:resourcekey="Label4Resource1"></asp:Label>
        <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" Display="Dynamic" ControlToValidate="txtAlto" meta:resourcekey="RequiredFieldValidator4Resource1">*</asp:RequiredFieldValidator>
				<asp:CustomValidator id="CustomValidator3" runat="server" Display="Dynamic" ControlToValidate="txtAlto" meta:resourcekey="CustomValidator3Resource1">*</asp:CustomValidator>
    </label>
    <div class="col-sm-9">
        <asp:TextBox ID="txtalto" runat="server"  CssClass="form-control"  Width="50px" meta:resourcekey="txtaltoResource1" ></asp:TextBox>
    </div>
 </div>


<div class="form-group">
    <label class="col-sm-3 control-label">
        <asp:label id="lblfile1" runat="server" text="Selecciona el archivo" meta:resourcekey="lblfile1Resource1"></asp:label>
    </label>
    <div class="col-sm-9">
        <INPUT id="File1" type="file" runat="server"  CssClass="form-control">
        &nbsp;<div style="height:10px;">
        </div>
        <asp:Literal ID="litflas" runat="server" meta:resourcekey="litflasResource1" Visible="False"></asp:Literal>
        <script src="../../iefix.js" type="text/javascript">
</script>
        <br />
        <asp:Label ID="lblNombreOriginal" runat="server" meta:resourcekey="lblNombreOriginalResource1" Visible="False"></asp:Label>
        <asp:Label ID="lblEspacio" runat="server" meta:resourcekey="lblEspacioResource1" Visible="False"></asp:Label>
        <br />
        <asp:HyperLink ID="lnkDownload" runat="server" meta:resourcekey="lnkDownloadResource1" Text="Descargar" Visible="False"></asp:HyperLink>

    </div>
</div>





<div class="form-group">
    <label class="col-sm-3 control-label">
    </label>
    <div class="col-sm-9">
        <asp:Button ID="btnGrabar" runat="server" CssClass="btn btn-success" Text="Grabar" meta:resourcekey="btnGrabarResource1" />&nbsp;
				<asp:Button ID="btnBorrar" runat="server" CssClass="btn btn-danger" Text="Borrar" Visible="False" meta:resourcekey="btnBorrarResource1" />
				<cc1:ConfirmButtonExtender ID="btnBorrar_ConfirmButtonExtender" runat="server" ConfirmText="¿Desea borrar este contenido del sistema?" Enabled="True" TargetControlID="btnBorrar"></cc1:ConfirmButtonExtender> 
         &nbsp;<asp:Button ID="btnregresar" runat="server" CssClass="btn btn-default" Text="Cancelar" CausesValidation="False" meta:resourcekey="btnregresarResource1"   />

          <div style="height:40px;"></div>

				<asp:HyperLink ID="lnkVistaPrevia" runat="server" Enabled="False" CssClass="btn btn-primary" Text="Vista previa" meta:resourcekey="lnkVistaPreviaResource1"></asp:HyperLink>
    </div>
</div>



<asp:TextBox ID="txtbase" runat="server" TextMode="MultiLine" Visible="False" >&lt;object classid=&#39;clsid:D27CDB6E-AE6D-11cf-96B8-444553540000&#39; codebase= &#39;http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0&#39; width=&#39;cancho&#39; height=&#39;calto&#39;&gt;&lt;param name=&#39;movie&#39; value=&#39;pelicula&#39;&gt;&lt;param name=&#39;quality&#39; value=&#39;high&#39;&gt;&lt;embed src=&#39;pelicula&#39; width=&#39;cancho&#39; height=&#39;calto&#39; quality=&#39;high&#39; pluginspage=&#39;http://www.macromedia.com/go/getflashplayer&#39; type=&#39;application/x-shockwave-flash&#39; wmode=&#39;transparent&#39;&gt;&lt;/embed&gt;&lt;/object&gt;</asp:TextBox>




         
                 </ContentTemplate> 
                  <Triggers>
                    <asp:PostBackTrigger ControlID="btnGrabar" />
                    </Triggers>

 </asp:UpdatePanel>    

</div>