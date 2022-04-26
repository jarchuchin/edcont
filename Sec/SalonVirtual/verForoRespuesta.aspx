<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="verForoRespuesta.aspx.vb" Inherits="Sec_SalonVirtual_verForoRespuesta" title="Enviar comentario" ValidateRequest="false" %>

<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>



<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>


<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lbltitulo" runat="server"  ></asp:Label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>


<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/default.aspx" ></asp:HyperLink></li>
        <li><asp:HyperLink ID="lnkMuro" runat="server" ></asp:HyperLink></li>
      <li class="active"><asp:Label ID="lblCursoBread" runat="server" Text="Editar comentarios"  ></asp:Label></li>
    </ol>

</asp:Content>

<asp:Content ID="content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
      <div class="row">

        <div class="col-xs-3">
             <uc1:MenuSalonVirtual ID="MenuSalonVirtual2" runat="server" />
        </div>
        <div class="col-xs-7">

                        
            <div class="panel">
 

                <div class="panel-heading">
        
                        <h3 class="panel-title"><asp:Label ID="Label4" runat="server" Text="Respuesta de foro"></asp:Label></h3>
                </div>
                <div class="panel-body">

    <table id="Table4" border="0" cellpadding="1" cellspacing="1" width="100%">
   
        <tr>
            <td align="left" colspan="2">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    displaymode="List" 
                    headertext="Los datos marcados con (*) son requeridos o no estan en el formato apropiado" />
            </td>
        </tr>
        <tr>
            <td valign="top" style="width: 68px">
                <asp:Label ID="lbltituloContenido" runat="server" 
                    >Titulo</asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtTitulo" Display="Dynamic">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtTitulo" runat="server" Columns="40"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td valign="top" style="width: 68px">
                <asp:Label ID="lblTexto" runat="server" >Comentario</asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtMensaje" Display="Dynamic">*</asp:RequiredFieldValidator>
            </td>
            <td>
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
            </td>
        </tr>
        <tr>
            <td valign="top" style="width: 68px">
                <asp:Label ID="lblfile" runat="server" >Adjuntar archivo</asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>
        <tr>
            <td valign="top" style="width: 68px">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnGrabar" runat="server" CssClass="btn btn-primary" Text="Enviar comentario" />
                <cc1:ConfirmButtonExtender ID="btnGrabar_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Se enviará tu comentario al foro. ¿Deseas continuar?" 
                    Enabled="True" TargetControlID="btnGrabar">
                </cc1:ConfirmButtonExtender>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                &nbsp;</td>
        </tr>
    </table>
    
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    
    </div>
    </div>
</asp:Content>

