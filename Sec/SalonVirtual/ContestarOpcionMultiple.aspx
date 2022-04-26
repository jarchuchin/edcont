<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="ContestarOpcionMultiple.aspx.vb" Inherits="Sec_SalonVirtual_ContestarOpcionMultiple" title="Opción múltiple" %>

<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>
<%@ Register src="Controles/UbicadorPreguntas.ascx" tagname="UbicadorPreguntas" tagprefix="uc2" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title--><!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~--><div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server" Text="Cuaderno de apuntes"  ></asp:Label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Cursos como docente"  NavigateUrl="~/sec/default.aspx" ></asp:HyperLink></li>
         <li><asp:HyperLink ID="lnkCurso" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/Sa/default.aspx" ></asp:HyperLink></li>
          <li><asp:HyperLink ID="lnkUnidad" runat="server"  Text="Unidad"  ></asp:HyperLink></li>
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Editar apunte" ></asp:Label></li>
    </ol>


   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">
   
     <uc22:MenuGeneral ID="MenuGeneral1" runat="server" />

</asp:Content>

<asp:Content ID="contentCentral" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

     <div class="row">

         <div class="col-xs-12">


	<asp:Panel ID="panelEdicion" runat="server" Visible="false">
		<div class="areaEdicion">
			<asp:HyperLink ID="lnkEdicionContenido" runat="server" Text="Editar contenido"></asp:HyperLink>
		</div>
	</asp:Panel>


	  <div class="panel">
           <div class="panel-body">
		<uc2:UbicadorPreguntas ID="UbicadorPreguntas1" runat="server" />
	     </div>
	</div>

      <div class="panel">
           <div class="panel-body">

	<asp:ValidationSummary ID="ValidationSummary1" runat="server" displaymode="List" headertext="Los campos marcados con * son requeridos" />

<%--	<div><asp:Label ID="lblpregunta" runat="server" Font-Bold="False">Enunciado</asp:Label></div>--%>
	<div style="margin-bottom:20px;">
		<asp:Label ID="pregunta" runat="server" Font-Bold="True"></asp:Label>
		<asp:TextBox ID="txtid" runat="server" Visible="False"></asp:TextBox>
	</div>

	<div>
		<asp:HyperLink ID="imgPreguntalink" runat="server" Visible="true" Target="_blank">
			<asp:Image ID="imgPregunta" runat="server" Visible="False" Width="150px" />
		</asp:HyperLink>
	</div>

	<div>
		<asp:Label ID="lblrespuesta" runat="server" Font-Bold="False" Text="Selecciona la respuesta correcta"></asp:Label>&nbsp;
		<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rdbOpcionesDisponibles" Display="Dynamic">*</asp:RequiredFieldValidator>
	</div>

	<div style="padding-top:15px; padding-bottom:15px;">
		<asp:RadioButtonList ID="rdbOpcionesDisponibles" runat="server" Font-Bold="True">
		</asp:RadioButtonList>
	</div>

		<div style="margin-bottom:20px;">
		<asp:Label ID="valor" runat="server" Font-Bold="true"></asp:Label>&nbsp;
		<asp:Label ID="lblValor" runat="server"  Text="Puntos" Font-Bold="true"></asp:Label>
	</div>


	<table style="width:400px;" border="0" cellpadding="1" cellspacing="4">
	<tr>
		<td style="width:50px;"><asp:Button ID="btnGrabar" runat="server" CssClass="btn btn-success" Text="Grabar respuesta" ToolTip="Grabar respuesta" /></td>
		<td></td>
		<td style="width:10px;">
			<asp:Button ID="btnAnterior" runat="server" CssClass="btn btn-default" Text="&lt;&lt;&lt;" ToolTip="Anterior" CausesValidation="False" />
			<cc1:ConfirmButtonExtender ID="btnAnterior_ConfirmButtonExtender" runat="server" ConfirmText="¿Deseas retroceder una pregunta sin haber grabado la respuesta de la pregunta actual?" Enabled="True" TargetControlID="btnAnterior"></cc1:ConfirmButtonExtender>
		</td>
		<td style="width:10px;padding:3px;">
			<asp:Button ID="btnSiguiente" runat="server" CssClass="btn btn-default" Text="&gt;&gt;&gt;" ToolTip="Siguiente" CausesValidation="False" />
			<cc1:ConfirmButtonExtender ID="btnSiguiente_ConfirmButtonExtender" runat="server" ConfirmText="¿Deseas continuar con el examen sin haber grabado la respuesta de la pregunta actual?" Enabled="True" TargetControlID="btnSiguiente"></cc1:ConfirmButtonExtender>
		</td>
	</tr>
	</table>
	     </div>
         </div>


             </div>

    </div>


      <asp:Label ID="labelCursosComoDocente" runat="server" Text="Cursos como docente" Visible="false"></asp:Label>
    <asp:Label ID="labelCursosComoAlumno" runat="server" Text="Cursos como alumno"  Visible="false"></asp:Label>
</asp:Content>

