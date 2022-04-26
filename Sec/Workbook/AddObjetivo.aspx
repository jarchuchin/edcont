<%@ Page Title="" Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="AddObjetivo.aspx.vb" Inherits="Sec_Workbook_AddObjetivo" EnableEventValidation="false"  ValidateRequest="false" meta:resourcekey="PageResource1" uiculture="auto" Culture="auto" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc2" %>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Literal ID="Literal1" runat="server" Text="Editar objetivos" meta:resourcekey="Literal1Resource1"></asp:Literal></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelBreadcrumb" Runat="Server">
    <ol class="breadcrumb" >
  <li><asp:HyperLink ID="lnkSalirEdicion" runat="server" Text="Salir de edición" meta:resourcekey="lnkSalirEdicionResource1" ></asp:HyperLink>
      </li>
        </ol>
	
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">



     <uc2:MenuGeneral ID="MenuGeneral1" runat="server" />



</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

   

	<div class="panel">

              <div class="form-horizontal">
              <div class="panel-body">
        <div class="form-group">
            <label  class="col-sm-2 control-label"></label>
            <div class="col-sm-10">

                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    displaymode="List" 
                
                    headertext="Los datos marcados con * (asterisco) son requeridos o son incorrectos" 
                    CssClass="Mediana" meta:resourcekey="ValidationSummary1Resource1" />

                <asp:Label ID="lblMensajeBorrar" runat="server" ForeColor="Red" Visible="False" Text="Para borrar, debes eliminar todos los elementos asociados (En caso de tener respuestas asociadas este elemento no podrá ser borrado)" meta:resourcekey="lblMensajeBorrarResource1"></asp:Label>
                 </div>
        </div>


        <div class="form-group">
            <label  class="col-sm-2 control-label"><asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Descripción de objetivo"></asp:Label>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtobjetivos" ErrorMessage="El campo de objetivos de conocimiento es requerido" ValidationGroup="obj" meta:resourcekey="RequiredFieldValidator3Resource1">*</asp:RequiredFieldValidator></label>
            <div class="col-sm-10"><asp:TextBox ID="txtobjetivos" runat="server" Height="250px" ClientIDMode="Static" TextMode="MultiLine" Width="100%" meta:resourcekey="txtobjetivosResource1" ></asp:TextBox>

                <script>
                 $(document).ready(function () {
                     $("#txtobjetivos").cleditor({
                         height: 140,
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

<%--
         <div class="form-group">
            <label  class="col-sm-2 control-label">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="De habilidad" meta:resourcekey="Label1Resource1"></asp:Label>
			</label>
            <div class="col-sm-10"><asp:TextBox ID="txthabilidad" runat="server" Height="150px" ClientIDMode="Static" TextMode="MultiLine" Width="100%" meta:resourcekey="txthabilidadResource1" ></asp:TextBox>

                 <script>
                 $(document).ready(function () {
                     $("#txthabilidad").cleditor({
                         height: 140,
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
            <label  class="col-sm-2 control-label">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="De aptitud" meta:resourcekey="Label2Resource1"></asp:Label>
			</label>
            <div class="col-sm-10"><asp:TextBox ID="txtaptitud" runat="server" Height="150px" ClientIDMode="Static" TextMode="MultiLine" Width="100%" meta:resourcekey="txtaptitudResource1" ></asp:TextBox>

                <script>
                 $(document).ready(function () {
                     $("#txtaptitud").cleditor({
                         height: 140,
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
         </div>--%>



    </div>

             
               <div class="panel-footer">
                      <div class="row">
                          <div class="col-sm-10 col-sm-offset-2">
 <asp:Button ID="btnGrabarObjetivo" runat="server" CssClass="btn btn-success" Text="Grabar" meta:resourcekey="btnGrabarObjetivoResource1"   />&nbsp;
				
               <asp:Button ID="btnBorrar" runat="server" CausesValidation="False" CssClass="btn btn-danger" Text="Borrar" meta:resourcekey="btnBorrarResource1"  />
                <cc1:ConfirmButtonExtender ID="btnBorrar_ConfirmButtonExtender" runat="server" ConfirmText="¿Deseas borrar estos objetivos?" TargetControlID="btnBorrar" Enabled="True">
                </cc1:ConfirmButtonExtender>
                 &nbsp;
                <asp:Button ID="btnCancelarObjetivo" runat="server" CausesValidation="False" CssClass="btn btn-default" Text="Cancelar" meta:resourcekey="btnCancelarObjetivoResource1"  />

                          </div>
                      </div>
                  </div>


                </div>

            </div>
</asp:Content>

