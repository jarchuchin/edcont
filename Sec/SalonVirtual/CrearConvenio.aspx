<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="CrearConvenio.aspx.vb" Inherits="Sec_SalonVirtual_CrearConvenio" title="Crear convenio" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server"  Text="Crear convenio" ></asp:Label> </h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/default.aspx" ></asp:HyperLink></li>
           <li><asp:HyperLink ID="lnkCurso" runat="server"  Text="Curso nombre"  NavigateUrl="~/sec/Sa/default.aspx" ></asp:HyperLink></li>
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Crear convenio" ></asp:Label></li>
    </ol>


   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">
   
     <uc22:MenuGeneral ID="MenuGeneral1" runat="server" />

</asp:Content>

<asp:Content ID="content1" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">



               
<div class="panel">
    <div class="panel-heading">
            <h3 class="panel-title"><asp:Label ID="lbltitulo" runat="server">Convenio creado para el alumno:</asp:Label>
	<asp:Label ID="lblNombre" runat="server" ></asp:Label> </h3>
    </div>
    <div class="panel-body">


	<div id="Caja">
	
		<div id="CajaInterna">

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
   
   <asp:Label ID="lblFechaconvenio" runat="server" Font-Bold="True" >Fecha en que finalizará el convenio:</asp:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtFecha" Display="Dynamic">*</asp:RequiredFieldValidator>
            
            <asp:CustomValidator ID="CustomValidator1" runat="server" 
                ControlToValidate="txtFecha" ErrorMessage="CustomValidator">*</asp:CustomValidator>
            
            &nbsp;&nbsp;
            <asp:TextBox ID="txtFecha" runat="server" Width="100px"></asp:TextBox>
   
   
                
                            <cc1:CalendarExtender ID="txtFecha_CalendarExtender" 
                runat="server" Enabled="True" TargetControlID="txtFecha">
            </cc1:CalendarExtender>
   
   
                
                            <br /><br />
                            
                             <asp:Button ID="btnGrabar" runat="server" CssClass="btn btn-success" Text="Grabar" />
                <cc1:ConfirmButtonExtender ID="btnGrabar_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Se enviará la calificación asignada. ¿Deseas continuar?" 
                    Enabled="True" TargetControlID="btnGrabar">
                </cc1:ConfirmButtonExtender>
          
   
   
    
    
            &nbsp;<asp:Button ID="btnBorrar" runat="server" Text="Borrar" Visible="False" CssClass="btn btn-default" />
            <cc1:ConfirmButtonExtender ID="btnBorrar_ConfirmButtonExtender" runat="server" 
                ConfirmText="¿Deseas borrar el convenio con este alumno?" Enabled="True" 
                TargetControlID="btnBorrar">
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

    
</asp:Content>

