<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="Apuntes.aspx.vb" Inherits="Sec_SalonVirtual_Apuntes" title="Apunte" ValidateRequest="false" %>

<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>



<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register src="Controles/displayApuntes.ascx" tagname="displayApuntes" tagprefix="uc2" %>

<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>


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


    
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/default.aspx" ></asp:HyperLink></li>
         <li><asp:HyperLink ID="lnkCurso" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/Sa/default.aspx" ></asp:HyperLink></li>
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Editar apunte" ></asp:Label></li>
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
                        <h3 class="panel-title"><asp:Label ID="Label1" runat="server" Text="Editar apunte"></asp:Label></h3>
                </div>
                <div class="panel-body">
                     <asp:TextBox ID="txtMensaje" runat="server" 
                                                TextMode="MultiLine"   CssClass="form-control" ClientIDMode="Static" ></asp:TextBox>

                     <script>
                         $(document).ready(function () {
                             $("#txtMensaje").cleditor({
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


                            
                          <div style="height:15px"></div>
                            
                     <asp:Button ID="btnGrabar" runat="server" CssClass="btn btn-success" Text="Grabar" />
                <cc1:ConfirmButtonExtender ID="btnGrabar_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Se grabaran lo cambios al apunte. ¿Deseas continuar?" 
                    Enabled="True" TargetControlID="btnGrabar">
                </cc1:ConfirmButtonExtender>
          &nbsp;<asp:Button ID="btnBorrar" runat="server" CssClass="btn btn-danger" 
               Text="Borrar" Visible="False" CausesValidation="false" />
                <cc1:ConfirmButtonExtender ID="btnBoorar_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Se borrar el apunte. ¿Deseas continuar?" 
                    Enabled="True" TargetControlID="btnBorrar">
                </cc1:ConfirmButtonExtender>
   
                &nbsp;<asp:Button ID="btnRegresar" runat="server" CssClass="btn btn-default" 
               Text="Regresar" CausesValidation="false" />
    
    
      
            
   

                    </div>
                </div>
            </div>


          <div class="col-xs-2">

                <uc2:displayApuntes ID="displayApuntes1" runat="server" />
          </div>


          </div>
    
    
        <asp:Label ID="labelCursosComoDocente" runat="server" Text="Cursos como docente" Visible="false"></asp:Label>
    <asp:Label ID="labelCursosComoAlumno" runat="server" Text="Label"  Visible="false"></asp:Label>

</asp:Content>




