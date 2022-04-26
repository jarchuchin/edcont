<%@ Page Title="" Language="VB" MasterPageFile="~/MPUsmart05_VistaPrevia.master" AutoEventWireup="false" CodeFile="VerCarpeta.aspx.vb" Inherits="Sec_SalonVirtual_VerCarpeta" %>

<%@ Register src="~/Sec/Workbook/Controles/showadjuntos.ascx" tagname="showadjuntos" tagprefix="uc2" %>
<%@ Register src="~/Sec/SalonVirtual/Controles/IndiceClasificacion.ascx" tagname="IndiceClasificacion" tagprefix="uc1" %>
<%@ Register src="~/Sec/Workbook/Controles/displayComentariosVistaPrevia.ascx" tagname="displayComentarios" tagprefix="uc3" %>

<asp:Content ID="contentBreadcrumb" ContentPlaceHolderID="ContentPlaceBreadcrumb" Runat="Server">
Estás en:
<asp:HyperLink ID="lnkPaginaPrincipalCurso" runat="server" Enabled="false">Curso</asp:HyperLink> /
<asp:Label ID="lblClasificacion" runat="server">Clasificacion</asp:Label>
</asp:Content>

<asp:Content ID="contentWorkArea" ContentPlaceHolderID="contentPlaceWorkArea" Runat="Server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
	<tr>

		<!-- area central -->
		<td align="center" valign="top" >

			<div class="areaEdicion">
				<asp:HyperLink ID="lnkSalir" runat="server">Salir de vista previa</asp:HyperLink>
			</div>

			<!-- área del título de la página -->
			<asp:Panel ID="panelImagen1" runat="server" Visible="false">
				<div class="imgSobreTitulo">
					<asp:Image id="imagenClasificacion1" runat="server" />
					<br /><br />
				</div>
			</asp:Panel>
	
			<div class="titulo">
				<asp:Label ID="lblTitulo" runat="server" CssClass="title-big"></asp:Label>
			</div>

			<table width="100%" border="0" cellspacing="10" cellpadding="0">
			<tr>
				<td valign="top">

					<!-- areaContenido central -->
					<div class="areaContenido">

						<div class="cajaSubseccionCentral">
							<h3>DESCRIPCI&Oacute;N</h3>

							<asp:Panel ID="panelImagen2" runat="server" Visible="false">
								<div class="imgEnContenido">
									<asp:Image id="imagenClasificacion2" runat="server" /><br />
								</div>
							</asp:Panel>
	
							<asp:Literal ID="literalTexto" runat="server"></asp:Literal>
						</div>

                        <div class="cajaSubseccionCentral">
							<h3>PLANTEAMIENTO BREVE</h3>

                            <asp:Literal ID="literalPlanteamientoBreve" runat="server"></asp:Literal>
                        </div>
	
						<div class="cajaSubseccionCentral">
							<h3>OBJETIVOS</h3>

							<asp:ListView ID="listViewObjetivos" runat="server">
								<LayoutTemplate>
									<table style="width:100%;">
									<tr runat="server" ID="itemPlaceholder">
									</tr>
								</table>
								</LayoutTemplate>
								<ItemTemplate>
									<tr>
										<td style="width:10px"><asp:Image ID="Image4" runat="server" ImageUrl="~/Images/bull-arrow3.png" /></td>
										<td style="vertical-align:top;"><asp:Label ID="lblObjetivo" runat="server" Text='<%# Replace(Eval("Objetivo"), vbCrLf, "<br/>")  %>'></asp:Label></td>
									</tr>
								</ItemTemplate>
								<EmptyDataTemplate>
									<div style="margin-left:10px;"><asp:Label ID="lblNoData" runat="server" CssClass="textoNoData12" Text="No se han definido"></asp:Label></div>
								</EmptyDataTemplate>
							</asp:ListView>

							<asp:Panel ID="panelImagen3" runat="server" Visible="false">
								<div class="imgEnContenido">
									<asp:Image ID="imagenClasificacion3" runat="server" ></asp:Image>
								</div>
							</asp:Panel>
						</div>

						<div class="cajaSubseccionCentral" style="border:1px solid #999; background-color:#eeeeee; padding:3px; width:98%;">
							<h3>ÍNDICE DE LA SECCIÓN</h3>
							<uc1:IndiceClasificacion ID="IndiceClasificacion1" runat="server" />
						</div>

						<div>
							<uc3:displayComentarios ID="displayComentarios1" runat="server" />
						</div>

					</div>
				</td>
				<td style="width:200px; vertical-align:top;">
					<uc2:showadjuntos ID="showArchivosAdjuntos" runat="server" />
					<uc2:showadjuntos ID="showDirecciones" runat="server" />
					<uc2:showadjuntos ID="showImagenesAdjuntos" runat="server" />
					<uc2:showadjuntos ID="showFlashes" runat="server" />

					<div class="cajaControlColLateral">
						<h3>BIBLIOTECA</h3>
						<asp:HyperLink ID="lnkBiblioteca" runat="server" NavigateUrl="~/Sec/Biblioteca.aspx" >Biblioteca digital</asp:HyperLink>
					</div>
				</td>
			</tr>
			</table>
<p>&nbsp; </p>
		</td>
	</tr>
	</table>
</asp:Content>

