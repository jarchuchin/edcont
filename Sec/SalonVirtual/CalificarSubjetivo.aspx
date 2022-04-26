<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="CalificarSubjetivo.aspx.vb" Inherits="Sec_SalonVirtual_CalificarSubjetivo" title="Asignar calificación subjetiva" ValidateRequest="false" %>

<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>


<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server"  Text="Tareas recibidas" ></asp:Label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/default.aspx" ></asp:HyperLink></li>
           <li><asp:HyperLink ID="lnkCurso" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/Sa/default.aspx" ></asp:HyperLink></li>
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Calificar subjetivo" ></asp:Label></li>
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
        <div class="col-xs-9">

                        
            <div class="panel">
                <div class="panel-heading">
                        <h3 class="panel-title"> <asp:Label ID="actividad" runat="server" ></asp:Label></h3>
                </div>
                <div class="panel-body">

 <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <div style="text-align: left">
                <asp:Image runat="server" ID="Image1" ImageUrl="~/Images/indicator.gif" ></asp:Image>
                <asp:Label runat="server" Text="Actualizando calificación..." ID="lblProgress" ></asp:Label>
            </div>

        </ProgressTemplate>
    </asp:UpdateProgress>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>  
         <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    displaymode="List" 
                    headertext="Los datos marcados con (*) son requeridos o no estan en el formato apropiado" />
   
            <strong>Alumno:</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   
   <asp:Label ID="lblAlumno" runat="server" Font-Bold="False" ></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Font-Bold="True">Calificación:</asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtCalificacion" Display="Dynamic">*</asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" 
                ControlToValidate="txtCalificacion" MaximumValue="10" MinimumValue="0" 
                Type="Double">0-10</asp:RangeValidator>
            &nbsp;&nbsp;
            <asp:TextBox ID="txtCalificacion" runat="server" Width="45px"></asp:TextBox>
            &nbsp;(0-10) Puedes utilizar hasta un decimal ejemplo 9.7<br />
            <br />
 
   
   <asp:Label ID="lblTexto" runat="server" Font-Bold="true" >Mensaje general</asp:Label>
             
                    
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
                            
                             <asp:Button ID="btnGrabar" runat="server" CssClass="BotonSubmit" Text="Grabar" />
                <cc1:ConfirmButtonExtender ID="btnGrabar_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Se enviará la calificación asignada. ¿Deseas continuar?" 
                    Enabled="True" TargetControlID="btnGrabar">
                </cc1:ConfirmButtonExtender>
          
   
   
    
    
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    
    </ContentTemplate>
</asp:UpdatePanel>
    
    
    </div>
    </div>


          </div>


         </div>
    

        <asp:Label ID="labelCursosComoDocente" runat="server" Text="Cursos como docente" Visible="false"></asp:Label>
    <asp:Label ID="labelCursosComoAlumno" runat="server" Text="Cursos como alumno"  Visible="false"></asp:Label>

</asp:Content>