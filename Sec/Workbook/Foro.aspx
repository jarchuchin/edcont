<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="Foro.aspx.vb" Inherits="Sec_Workbook_Foro" title="Foros de discursión" ValidateRequest="false" meta:resourcekey="PageResource1" uiculture="auto" Culture="auto" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<%@ Register src="Controles/TabsWorkbook.ascx" tagname="TabsWorkbook" tagprefix="uc1" %>

<%@ Register src="Controles/DisplayForosUnidad.ascx" tagname="DisplayForosUnidad" tagprefix="uc2" %>
<%@ Register src="Controles/DisplayListaObjetos.ascx" tagname="DisplayListaObjetos" tagprefix="uc4" %>

<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:label id="lbltitulo" runat="server" text="Editar foro" meta:resourcekey="lbltituloResource1"></asp:label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">

     <uc22:MenuGeneral ID="MenuGeneral1" runat="server" />

</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPanelBreadcrumb">
	  <ol class="breadcrumb" >
  <li><asp:HyperLink ID="lnkSalirEdicion" runat="server" Text="Salir de edición" meta:resourcekey="lnkSalirEdicionResource1" ></asp:HyperLink>
      </li>
        </ol>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

    <div class="panel">
    <div class="panel-body">


<div class="form-horizontal" style="margin: auto; max-width: 100%;">



<div class="alert alert-success" id="alertSuccess" runat="server" visible="false">
  <span class="glyphicon glyphicon-saved"></span><strong>&nbsp; <asp:Label ID="Label10" runat="server" Text="Listo!" meta:resourcekey="Label10Resource1"></asp:Label>&nbsp;&nbsp; </strong> <asp:Label ID="Label9" runat="server" Text="Cambios realizados correctamente." meta:resourcekey="Label9Resource1"></asp:Label>
</div>


<div class="alert alert-danger" id="lblMensajeBorrar" runat="server" visible="false">
  <span class="glyphicon glyphicon-saved"></span><strong>&nbsp; <asp:Label ID="Label11" runat="server" Text="Error!" meta:resourcekey="Label11Resource1"></asp:Label>&nbsp;&nbsp; </strong> <asp:label id="lblMensajeBorrarinside" runat="server"  text="Para borrar, debes eliminar todos los elementos asociados (En caso de tener respuestas asociadas este elemento no podrá ser borrado)" meta:resourcekey="lblMensajeBorrarinsideResource1"></asp:label>
</div>

 <asp:validationsummary id="ValidationSummary1" runat="server" ForeColor="Red" headertext="Los campos marcados con * son requeridos o no estan en formato apropiado"  displaymode="List" CssClass="alert alert-danger" meta:resourcekey="ValidationSummary1Resource1"></asp:validationsummary>



     
      <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server"  ImageUrl ="~/Images/indicator.gif" meta:resourcekey="Image1Resource1" /><asp:Label ID="lbltexto" runat="server"   Text="Actualizando datos..." meta:resourcekey="lbltextoResource1" ></asp:Label>
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
                <asp:Label ID="lblUbicacion" runat="server"  Text="Selecciona la unidad" meta:resourcekey="lblUbicacionResource1"></asp:Label>
        </label>
         <div class="col-sm-10">
            <asp:DropDownList ID="drpUbicacion"  runat="server" CssClass="form-control" meta:resourcekey="drpUbicacionResource1"></asp:DropDownList>
        </div>
    </div>

        <div class="form-group">
        <label class="col-sm-2 control-label">
            <asp:Label ID="lbltituloContenido" runat="server" text="Título" meta:resourcekey="lbltituloContenidoResource1"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitulo" Display="Dynamic" meta:resourcekey="RequiredFieldValidator1Resource1">*</asp:RequiredFieldValidator>
             </label>
         <div class="col-sm-10">
             <asp:TextBox   ID="txtTitulo" runat="server"  CssClass="form-control" Columns="40" MaxLength="200" meta:resourcekey="txtTituloResource1"></asp:TextBox>
			<asp:TextBox ID="txtid" runat="server" Visible="False" meta:resourcekey="txtidResource1"></asp:TextBox>
             
                </div>
    </div>
      
      <div class="form-group">
        <label class="col-sm-2 control-label">
                         
             <asp:Label ID="lblTextoCorto" runat="server" Text="Discusión" meta:resourcekey="lblTextoCortoResource1" ></asp:Label>
         </label>
         <div class="col-sm-10">



              <asp:TextBox ID="txtTextoCorto" runat="server" 
                                        TextMode="MultiLine"   CssClass="form-control" ClientIDMode="Static" meta:resourcekey="txtTextoCortoResource1"></asp:TextBox>

             <script>
                 $(document).ready(function () {
                     $("#txtTextoCorto").cleditor({
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

          

        </div>

        </div>


                       <div class="form-group">
        <label class="col-sm-2 control-label">
            <asp:Label ID="lblLectura" runat="server" Text="Objetivo / Competencia" meta:resourcekey="lblLecturaResource1" ></asp:Label>
        </label>
         <div class="col-sm-10">
                <asp:TextBox ID="txtObjetivoCompetencia" runat="server"  
                    Height="60px"  TextMode="MultiLine"  CssClass="form-control" meta:resourcekey="txtObjetivoCompetenciaResource1"></asp:TextBox>

         </div>
    </div>
          

		
                   
                   
                    <div style="height:20px;"></div>

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
                                 
           								


                      </ContentTemplate> 
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnGrabar" />
                </Triggers>

 </asp:UpdatePanel>    

    </div>


        </div>
        </div>

</asp:Content>
