<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="AddPDirecta.aspx.vb" Inherits="Sec_Workbook_AddPDirecta" title="Pregunta directa" ValidateRequest="false" %>
<%@ Register src="~/Sec/workbook/Controles/Menu.ascx" tagname="Menu" tagprefix="uc5" %> <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register src="Controles/MenuExamen.ascx" tagname="MenuExamen" tagprefix="uc1" %>

<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc2" %>


<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Literal ID="Literal1" runat="server" Text="Editar pregunta directa" ></asp:Literal></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPanelBreadcrumb">
          <ol class="breadcrumb" >
  <li><asp:HyperLink ID="lnkSalirEdicion" runat="server" Text="Salir de edición"></asp:HyperLink>
      </li>
        </ol>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">

     <uc2:MenuGeneral ID="MenuGeneral1" runat="server" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">



		<div class="panel">

              <div class="form-horizontal">

            <div class="panel-heading">
                  <h3 class="panel-title">
                         <asp:Label ID="lblTitulobox" runat="server"  Text="Pregunta directa" ></asp:Label>
                     </h3>
            </div>

              <div class="panel-body">


      <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <div align="left" > <asp:Image ID="Image1" runat="server"  ImageUrl ="~/Images/indicator.gif" /><asp:Label ID="lbltexto" runat="server"   Text="Actualizando datos..." ></asp:Label></div>
                    </ProgressTemplate>
       </asp:UpdateProgress>
       <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional" >
               <ContentTemplate>

<asp:ValidationSummary ID="ValidationSummary1" runat="server"  CssClass="alert alert-danger"  displaymode="List" headertext="Los datos marcados con * (asterisco) son requeridos o son incorrectos" />


       <div class="form-group">
    <label class="col-sm-2 control-label">
        <asp:Label ID="Label3" runat="server" Text="Examen"></asp:Label>
    </label>
    <div class="col-sm-10"> 
        <asp:Label ID="lblexamen" runat="server"></asp:Label>
    </div>
    </div>


    <div class="form-group">
    <label class="col-sm-2 control-label">
<asp:Label ID="lblPregunta" runat="server" text="Pregunta"></asp:Label>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtPregunta" Display="Dynamic">*</asp:RequiredFieldValidator>
    </label>
    <div class="col-sm-10"> 
 <asp:TextBox ID="txtPregunta" runat="server" Columns="60" Height="100px"  TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                               <asp:TextBox ID="txtid" runat="server" Visible="False"></asp:TextBox>
    </div>
    </div>

     <div class="form-group">
    <label class="col-sm-2 control-label">
             <asp:Label ID="lblRespuesta0" runat="server" text="Cargar imagen"></asp:Label>
                <asp:CustomValidator ID="CustomValidator1" runat="server" 
                    ControlToValidate="FileUpload1" ErrorMessage="Solo imágenes son permitidas">*</asp:CustomValidator>
    </label>
    <div class="col-sm-10"> 
<asp:FileUpload ID="FileUpload1" runat="server"   CssClass="form-control"/>
   <asp:HyperLink ID="imgPreguntalink" runat="server" Visible="true" Target="_blank">
        <asp:Image ID="imgPregunta" runat="server" Visible="False" Width="150px" />
    </asp:HyperLink>
    </div>
    </div>

     <div class="form-group">
    <label class="col-sm-2 control-label">
 <asp:Label ID="lblRespuesta" runat="server" text="Respuesta correcta"></asp:Label>
    </label>
    <div class="col-sm-10"> 
 <asp:TextBox ID="txtRespuesta" runat="server" Columns="60"  Height="100px"  CssClass="form-control"
                                   TextMode="MultiLine"></asp:TextBox>
    </div>
    </div>


     <div class="form-group">
    <label class="col-sm-2 control-label">

    </label>
    <div class="col-sm-10"> 
<asp:Label ID="lblRespuestaTexto" runat="server" CssClass="Chica" 
                                   Font-Italic="True" 
                                   Text="La respuesta podra ser vista unicamente por el instructor al momento de revisar el examen."></asp:Label>
    </div>
    </div>


     <div class="form-group">
    <label class="col-sm-2 control-label">

    </label>
    <div class="col-sm-10"> 
   <asp:Button ID="btnGrabar" runat="server" CssClass="btn btn-success" Text="Grabar" />
                               &nbsp;
                               <asp:Button ID="btnBorrar" runat="server" CssClass="btn btn-danger" Text="Borrar" 
                                   Visible="False" />
                               <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
                                   ConfirmText="¿Desea borrar esta preguta?" TargetControlID="btnBorrar">
                               </cc1:ConfirmButtonExtender>

          &nbsp;<asp:HyperLink ID="lnkSalirEdicion2" runat="server" Text="Cancelar"  CssClass="btn btn-default"></asp:HyperLink>
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

