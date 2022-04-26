<%@ Page Language="VB" MasterPageFile="~/MPUsmart04.master" AutoEventWireup="false" CodeFile="ListaDePreguntas.aspx.vb" Inherits="Sec_ListaDePreguntas" title="Untitled Page" %>

<%@ Register src="Controles/MenuExamen.ascx" tagname="MenuExamen" tagprefix="uc1" %>

<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPanelBreadcrumb">
	<asp:HyperLink ID="lnkSalirEdicion" runat="server">Editar datos del examen</asp:HyperLink>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
	<div style="padding:15px;">
		<uc1:MenuExamen ID="MenuExamen1" runat="server" />
		<asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
			<ProgressTemplate>
				<div style="text-align:left;">
					<asp:Image ID="Image1" runat="server"  ImageUrl ="~/Images/indicator.gif" /><asp:Label ID="lbltexto" runat="server"   Text="Actualizando datos..." ></asp:Label>
				</div>
			</ProgressTemplate>
		</asp:UpdateProgress>

		<asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional" >
			<ContentTemplate>
				<div style="height:10px;"></div>

				<table style="width:100%;" border="0" cellpadding="1" cellspacing="1">
				<tr>
					<td>
						<asp:ImageButton ID="ibExamenDirecta" runat="server" CausesValidation="False" ImageUrl="~/Images/iconPregDirecta.gif" ToolTip="Agregar pregunta directa" />
						<asp:ImageButton ID="ibFalsoVerdadero" runat="server" CausesValidation="False" ImageUrl="~/Images/iconFoV.gif" ToolTip="Agregar pregunta de falso yverdadero" />
						<asp:ImageButton ID="ibOpcionMultiple" runat="server" CausesValidation="False" ImageUrl="~/Images/iconOpcMul.gif" ToolTip="Agregar pregunta de opción multiple" />
						<asp:ImageButton ID="ibRelacionColumnas" runat="server" CausesValidation="False" ImageUrl="~/Images/iconRelCol.gif" ToolTip="Agregar sección de relacionar columnas" />
					</td>
				</tr>
				<tr>
					<td>&nbsp; &nbsp;</td>
				</tr>
				<tr>
					<td>
						<asp:DataGrid ID="dtgItem" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#C1CDD8" DataKeyField="idPregunta" GridLines="None" Width="100%">
							<selecteditemstyle backcolor="#C1CDD8" />
							<headerstyle font-bold="True" horizontalalign="Left" />
							<columns>

                                <asp:TemplateColumn>
                                    <HeaderStyle Width="30px" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%# getContador() %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>


								<asp:templatecolumn>
									<headerstyle width="45px" />
									<itemstyle verticalalign="Top" />
									<itemtemplate>
										<asp:ImageButton ID="Imagebutton8" runat="server" AlternateText="Mover hacia abajo" CausesValidation="False" CommandName="bajar" ImageUrl="~/Images/arrow-down.png" />&nbsp;
										<asp:ImageButton ID="Imagebutton6" runat="server" AlternateText="Mover hacia arriba" CausesValidation="False" CommandName="subir" ImageUrl="~/Images/arrow-up.png" />
									</itemtemplate>
								</asp:templatecolumn>
								<asp:templatecolumn>
									<headerstyle width="30px" />
									<itemstyle horizontalalign="Center" verticalalign="Top" />
									<itemtemplate>
										<asp:HyperLink ID="Hyperlink12" runat="server" 
											ImageUrl='<%# "~/Images/" & getImagen(DataBinder.Eval(Container.DataItem, "tipoPregunta"))  %>' 
											NavigateUrl='<%#  GetLiga(cint(DataBinder.Eval(Container.DataItem, "idPregunta")), cint(DataBinder.Eval(Container.DataItem, "tipoPregunta"))  )%>'>
										</asp:HyperLink>
									</itemtemplate>
								</asp:templatecolumn>
								<asp:templatecolumn HeaderText="Preguntas existentes">
									<headerstyle horizontalalign="Left" />
									<itemstyle horizontalalign="Left" />
									<itemtemplate>
										<asp:HyperLink ID="lnkClasificacion" runat="server" 
											NavigateUrl='<%#  GetLiga(cint(DataBinder.Eval(Container.DataItem, "idPregunta")), cint(DataBinder.Eval(Container.DataItem, "tipoPregunta"))  )%>' 
											Text='<%# GetEnunciado(DataBinder.Eval(Container.DataItem, "enunciado"),  cint(DataBinder.Eval(Container.DataItem, "tipoPregunta")) ) %>'>
										</asp:HyperLink>
									</itemtemplate>
								</asp:templatecolumn>
								<asp:templatecolumn HeaderText="Puntos">
									<headerstyle width="50px" />
										<itemstyle horizontalalign="Right" />
									<itemtemplate>
										<asp:TextBox ID="txtValor" CssClass="textoNoData12" runat="server" Columns="4" MaxLength="4"  style="text-align:right;" Text='<%# DataBinder.Eval(Container.DataItem,"Valor", "{0:.##}" ) %>'></asp:TextBox>
										<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtValor" Display="Dynamic" MaximumValue="1000" MinimumValue="0" Type="Double">*</asp:RangeValidator>
										<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtValor" Display="Dynamic">*</asp:RequiredFieldValidator>
									</itemtemplate>
								</asp:templatecolumn>
							</columns>
						</asp:DataGrid>

						<div style="border-bottom:1px solid #999; height:20px;"></div>
						<table style="width:100%;" border="0" cellpadding="1" cellspacing="1">
						<tr>
							<td style="text-align:right;" colspan="2">
								<asp:Label ID="lblTotalPreguntas" runat="server" ForeColor="Red">Suma</asp:Label>
								<asp:Label ID="totalpreguntas" runat="server"></asp:Label>
							</td>
						</tr>
						<tr>
							<td style="text-align:right;" colspan="2">
								<asp:Label ID="lblTotalExamen" runat="server" Font-Bold="True">Valor total de preguntas</asp:Label>
								<asp:Label ID="totalexamen" runat="server"></asp:Label>
							</td>
						</tr>
						<tr>
							<td><asp:Label ID="lblpdesarrollo" runat="server" Text="Pregunta de desarrollo" Visible="False"></asp:Label></td>
							<td style="width:100px; text-align:center;"><asp:Button ID="btnGrabar" runat="server" CssClass="button" Text="Grabar" Visible="False"  /></td>
						</tr>
						</table>
					</td>
				</tr>
				</table>
			</ContentTemplate> 
		</asp:UpdatePanel>

		<div style="height:200px;"></div>
	</div>
</asp:Content>