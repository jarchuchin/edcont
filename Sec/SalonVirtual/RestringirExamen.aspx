<%@ Page Title="" Language="VB" MasterPageFile="~/MPUsmart05.master" AutoEventWireup="false" CodeFile="RestringirExamen.aspx.vb" Inherits="Sec_SalonVirtual_RestringuirExamen" %>

<%@ Register src="../Workbook/Controles/showadjuntos.ascx" tagname="showadjuntos" tagprefix="uc2" %>
<%@ Register src="Controles/displayComentarios.ascx" tagname="displayComentarios" tagprefix="uc3" %>
<%@ Register src="~/Controles/HeaderBreadcrumSalon.ascx" tagname="HeaderBreadcrumSalon" tagprefix="uc4" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceBreadcrumb" Runat="Server">
        <uc4:HeaderBreadcrumSalon ID="HeaderBreadcrumSalon1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceWorkArea" Runat="Server">

    	<table width="100%" border="0" cellspacing="0" cellpadding="0">
	<tbody>
	<tr>

		<!-- area central -->
		<td align="center" valign="top" >

		

			<!-- área del título de la página -->
			<asp:Panel ID="panelImagen" runat="server" Visible="false">
				<div class="imgSobreTitulo">
					<asp:Image id="imagenClasificacion" runat="server"  />
					<br /><br />
				</div>
			</asp:Panel>

			<div class="titulo">
				<asp:Label ID="lblClasificacion" runat="server"></asp:Label><br /><br />
				<asp:Label ID="lblTitulo" runat="server" CssClass="title-big"></asp:Label>
			</div>

			<table width="100%" border="0" cellspacing="10" cellpadding="0">
			<tr>
				<td valign="top">

					<!-- areaContenido central -->
					<div class="areaContenido">

						<div class="cajaSubseccionCentral">
							<h3>SIN PERMISOS PARA ACCESAR AL CONTENIDO</h3>
							<asp:Literal ID="litObjetivo" runat="server"></asp:Literal>
						</div>

						<div class="cajaSubseccionCentral">
							<h3 style="color: #FF0000">SE HA REGISTRADO UN INTENTO POR INGRESAR AL EXAMEN. TU MAESTRO SERÁ NOTIFICADO A TRAVÉS DEL SISTEMA</h3>
							<asp:Literal ID="litInstrucciones" runat="server"></asp:Literal>
						</div>

						<div class="cajaSubseccionCentral">
							<asp:Label ID="lblfecha" runat="server" Text=""></asp:Label>
						</div>

					
					</div>
				</td>
				
			</tr>
			</table>
<p>&nbsp; </p>
		</td>
	</tr>
	</tbody>
	</table>


</asp:Content>

