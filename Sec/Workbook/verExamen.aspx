<%@ Page Language="VB" MasterPageFile="~/MPUsmart05_VistaPrevia.master" AutoEventWireup="false" CodeFile="verExamen.aspx.vb" Inherits="Sec_SalonVirtual_verExamen" title="Untitled Page" ValidateRequest="false"%>

<%@ Register src="../Workbook/Controles/showadjuntos.ascx" tagname="showadjuntos" tagprefix="uc2" %>
<%@ Register src="~/Sec/Workbook/Controles/displayComentariosVistaPrevia.ascx" tagname="displayComentarios" tagprefix="uc3" %>

<asp:Content ID="contentBreadcrumb" ContentPlaceHolderID="ContentPlaceBreadcrumb" Runat="Server">
	Estás en:
	<asp:HyperLink ID="lnkPaginaPrincipalCurso" runat="server" Enabled="false">Curso</asp:HyperLink> /
	<asp:HyperLink ID="lnkClasificacion" runat="server" Enabled="false">Unidad</asp:HyperLink> /
	<asp:Label ID="lblUbicacion" runat="server">Exámenes</asp:Label>
</asp:Content>

<asp:Content ID="contentWorkArea" ContentPlaceHolderID="contentPlaceWorkArea" Runat="Server">
	<table width="100%" border="0" cellspacing="0" cellpadding="0">
	<tbody>
	<tr>

		<!-- area central -->
		<td align="center" valign="top" >

			<div class="areaEdicion">
				<asp:HyperLink ID="lnkSalir" runat="server">Salir de vista previa</asp:HyperLink>
			</div>

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
							<h3>OBJETIVO</h3>
							<asp:Literal ID="litObjetivo" runat="server"></asp:Literal>
						</div>

						<div class="cajaSubseccionCentral">
							<h3>INSTRUCCIONES</h3>
							<asp:Literal ID="litInstrucciones" runat="server"></asp:Literal>
						</div>

						<div class="cajaSubseccionCentral">
							<div class="teFecha límite para responder"></div>
							<asp:Label ID="lblFechaEntrega" runat="server" Text=""></asp:Label><br />
							<asp:Label ID="lblFechaVencida" Visible="False"  runat="server" Text="La fecha ha vencido para responder este examen" ForeColor="Red"></asp:Label><br />
							<asp:Button ID="btnEnviarTarea" runat="server" Text="Responder examen" 
								CssClass="button" Width="180px" Enabled="False" />
						</div>

						<div>
							<uc3:displayComentarios ID="displayComentarios1" runat="server" />
						</div>

					</div>
				</td>
				<td style="width:200px; vertical-align:top;">
					<uc2:showadjuntos ID="showarchivosAdjuntos" runat="server" />
					<uc2:showadjuntos ID="showdirecciones" runat="server" />
					<uc2:showadjuntos ID="showimagenesAdjuntos" runat="server" />
					<uc2:showadjuntos ID="Showflashes" runat="server" />

					<div class="cajaControlColLateral">
						<h3>BIBLIOTECA3>BIBLIOTECA</h3>
						<asp:HyperLink ID="lnkBiblioteca" runat="server" NavigateUrl="~/Sec/Biblioteca.aspx" >Biblioteca digital</asp:HyperLink>
					</div>

				</td>
			</tr>
			</table>
		</td>
	</tr>
	</tbody>
	</table>

</asp:Content>
