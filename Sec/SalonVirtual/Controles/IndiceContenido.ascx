<%@ Control Language="VB" AutoEventWireup="false" CodeFile="IndiceContenido.ascx.vb" Inherits="Sec_SalonVirtual_Controles_IndiceContenido" %>

<%--<%@ Register src="DisplayExplorarContenido.ascx" tagname="DisplayExplorarContenido" tagprefix="uc1" %>--%>






<div class="panel">
 
    <div class="panel-body">



        <ul class="nav nav-tabs" >
          <li class="active"><a data-toggle="tab" href="#general"><asp:Literal ID="Literal1" runat="server" Text="Unidades"></asp:Literal></a></li>
          <li><a data-toggle="tab" href="#explorar"><asp:Literal ID="Literal2" runat="server" Text="Explorar" ></asp:Literal></a></li>
        </ul>


        <div class="tab-content">
         
          <div id="general" class="tab-pane fade in active">

                <div style="padding:10px;">
                    <asp:HyperLink ID="lnkRegreso" runat="server" CssClass="btn-link">Regresar</asp:HyperLink>
                </div>
        

                <div class="mar-btm">
	
	                <div class="list-group bg-trans">

                        <asp:Repeater ID="rptUnidades" runat="server">
                            <ItemTemplate>
                                 <asp:HyperLink ID="lnkSalon2" runat="server" navigateurl='<%# "~/sec/salonVirtual/verCarpeta.aspx?idSalonVirtual=" & claveSalon & "&idClasificacion=" & Eval("idClasificacion") %>' CssClass="list-group-item">
                                     <span class='<%# "badge badge-" & getColorRandom() & " badge-icon badge-fw pull-left" %>'></span> <asp:Literal ID="Literal2" runat="server" Text='<%# Eval("Titulo") %>' ></asp:Literal>
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>

           </div>
          <%--  <div id="explorar" class="tab-pane fade">
                
                <uc1:DisplayExplorarContenido ID="DisplayExplorarContenido1" runat="server" />
            </div>--%>


       </div>

    </div>


</div>


<%--
<asp:Repeater ID="repeaterClasificaciones" runat="server">
	<ItemTemplate>
		<h3>
			<a href="#"><asp:Label ID="lblTituloClasificacion" runat="server" Text='<%# Eval("titulo") %>'></asp:Label></a>
		</h3>

		<div style="text-align:left;">
			<table class="acordeon">
		<tr>
			<td style="width:10px">
				<asp:Image ID="Image4" runat="server" ImageUrl='<%# "~/Images/" & getImagen(Eval("idRoot"), Eval("idClasificacion"),0, 0) %>' />
			</td>
			<td style="vertical-align:top;">
				<asp:HyperLink ID="lnkClasificacion" runat="server"
					Enabled='<%# getEnabled(Eval("idRoot"), Eval("idClasificacion"), 0, 0) %>'
					NavigateUrl='<%# getLinkClasificacion(Eval("idRoot"), Eval("idClasificacion")) %>'>
					<asp:Label ID="lblTagClasificacion" runat="server" CssClass='<%# getEstilo(Eval("idRoot"), Eval("idClasificacion"), 0, 0) %>'>Generalidades y anexos</asp:Label>
				</asp:HyperLink>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/Images/" & getImagen(Eval("idRoot"), Eval("idClasificacion"), 0, 1, Eval("idActividad")) %>' />
			</td>
			<td>
				<asp:HyperLink ID="lnkPruebaDiagnostico" runat="server"
					NavigateUrl='<%# getLinkDiagnostico(Eval("idRoot"), Eval("idClasificacion"), Eval("idActividad"))%>'
					Enabled='<%# getEnabled(Eval("idRoot"), Eval("idClasificacion"), 0, 1, Eval("idActividad")) %>'
					Visible='<%# getVisible(Eval("idActividad"), true) %>'>
					<asp:Label ID="lblTitulo" runat="server" CssClass='<%# getEstilo(Eval("idRoot"), Eval("idClasificacion"), 0, 1, Eval("idActividad")) %>'>Prueba de diagnóstico</asp:Label>
				</asp:HyperLink>
				<asp:Label ID="lblPruebaDiagnostico" runat="server" CssClass="gris-claro12" Visible='<%# getVisible(Eval("idActividad"), false) %>'>Prueba de diagnóstico</asp:Label>
			</td>
		</tr>
		<tr>
			<td>&nbsp;</td>
			<td class="textoMenu12B">Contenidos</td>
		</tr>
		<tr>
			<td>&nbsp;</td>
			<td>
				<asp:ListView ID="listViewContenidos" runat="server">
					<LayoutTemplate>
						<table style="width:100%;">
						<tr runat="server" ID="itemPlaceholder">
						</tr>
						</table>
					</LayoutTemplate>
					<ItemTemplate>
						<tr>
							<td style="width:10px">
								<asp:Image ID="Image4" runat="server" ImageUrl='<%# "~/Images/" & getImagen(Eval("idRoot"), Eval("idClasificacion"), Eval("idClasificacionItem"), 1) %>' />
							</td>
							<td style="vertical-align:top;">
								<asp:HyperLink ID="lnkContenido" runat="server"
									Enabled='<%# getEnabled(Eval("idRoot"), Eval("idClasificacion"), Eval("idClasificacionItem"), 1) %>'
									NavigateUrl='<%# getLinkAnexos(Eval("idRoot"), Eval("idClasificacionItem"), Eval("idClasificacion"), "Contenido", Eval("idTipo")) %>'>
									<asp:Label ID="lblTitulo" runat="server" CssClass='<%# getEstilo(Eval("idRoot"), Eval("idClasificacion"), Eval("idClasificacionItem"), 1) %>' Text='<%# Eval("titulo")%>'></asp:Label>
								</asp:HyperLink>
							</td>
						</tr>
					</ItemTemplate>
					<EmptyDataTemplate>
						<asp:Label ID="lblNoData" runat="server" CssClass="textoNoData12" Text="No hay accesibles en esta fecha"></asp:Label>
					</EmptyDataTemplate>
				</asp:ListView>
			</td>
		</tr>
		<tr>
			<td>&nbsp;</td>
			<td class="textoMenu12B">Actividades</td>
		</tr>
		<tr>
			<td>&nbsp;</td>
			<td>
				<asp:ListView ID="listViewActividades" runat="server">
					<LayoutTemplate>
						<table style="width:100%;">
						<tr runat="server" ID="itemPlaceHolder">
						</tr>
						</table>
					</LayoutTemplate>
					<ItemTemplate>
						<tr>
							<td style="width:10px">
								<asp:Image ID="Image4" runat="server" ImageUrl='<%# "~/Images/" & getImagen(Eval("idRoot"), Eval("idClasificacion"), Eval("idClasificacionItem"), 1) %>' />
							</td>
							<td style="vertical-align:top;">
								<asp:HyperLink ID="lnkActividad" runat="server"
									Enabled='<%# getEnabled(Eval("idRoot"), Eval("idClasificacion"), Eval("idClasificacionItem"), 1) %>'
									NavigateUrl='<%# getLinkAnexos(Eval("idRoot"), Eval("idClasificacionItem"), Eval("idClasificacion"), "Actividad", Eval("idTipo")) %>'>
									<asp:Label ID="lblTitulo" runat="server" CssClass='<%# getEstilo(Eval("idRoot"), Eval("idClasificacion"), Eval("idClasificacionItem"), 1) %>' Text='<%# Eval("titulo")%>'></asp:Label>
								</asp:HyperLink>
							</td>
						</tr>
					</ItemTemplate>
					<EmptyDataTemplate>
						<asp:Label ID="lblNoData" runat="server" CssClass="textoNoData12" Text="No hay accesibles en esta fecha"></asp:Label>
					</EmptyDataTemplate>
				</asp:ListView>
			</td>
		</tr>
		<tr>
			<td>&nbsp;</td>
			<td class="textoMenu12B">Exámenes</td>
		</tr>
		<tr>
			<td>&nbsp;</td>
			<td>
				<asp:ListView ID="listViewExamenes" runat="server">
					<LayoutTemplate>
						<table style="width:100%;">
						<tr runat="server" ID="itemPlaceHolder">
						</tr>
						</table>
					</LayoutTemplate>
					<ItemTemplate>
						<tr>
							<td style="width:10px">
								<asp:Image ID="Image4" runat="server" ImageUrl='<%# "~/Images/" & getImagen(Eval("idRoot"), Eval("idClasificacion"), Eval("idClasificacionItem"), 1) %>' />
							</td>
							<td style="vertical-align:top;">
								<asp:HyperLink ID="lnkExamen" runat="server"
									Enabled='<%# getEnabled(Eval("idRoot"), Eval("idClasificacion"), Eval("idClasificacionItem"), 1) %>'
									NavigateUrl='<%# getLinkAnexos(Eval("idRoot"), Eval("idClasificacionItem"), Eval("idClasificacion"), "Examen", Eval("idTipo")) %>'>
									<asp:Label ID="lblTitulo" runat="server" CssClass='<%# getEstilo(Eval("idRoot"), Eval("idClasificacion"), Eval("idClasificacionItem"), 1) %>' Text='<%# Eval("titulo")%>'></asp:Label>
								</asp:HyperLink>
							</td>
						</tr>
					</ItemTemplate>
					<EmptyDataTemplate>
						<asp:Label ID="lblNoData" runat="server" CssClass="textoNoData12" Text="No hay accesibles en esta fecha"></asp:Label>
					</EmptyDataTemplate>
				</asp:ListView>
			</td>
		</tr>
		<tr>
			<td>&nbsp;</td>
			<td class="textoMenu12B">Foros</td>
		</tr>
		<tr>
			<td>&nbsp;</td>
			<td>
				<asp:ListView ID="listViewForos" runat="server">
					<LayoutTemplate>
						<table style="width:100%;">
						<tr runat="server" ID="itemPlaceHolder">
						</tr>
						</table>
					</LayoutTemplate>
					<ItemTemplate>
						<tr>
							<td style="width:10px">
								<asp:Image ID="Image4" runat="server" ImageUrl='<%# "~/Images/" & getImagen(Eval("idRoot"), Eval("idClasificacion"), Eval("idClasificacionItem"), 1) %>' />
							</td>
							<td style="vertical-align:top;">
								<asp:HyperLink ID="lnkForo" runat="server"
									Enabled='<%# getEnabled(Eval("idRoot"), Eval("idClasificacion"), Eval("idClasificacionItem"), 1) %>'
									NavigateUrl='<%# getLinkAnexos(Eval("idRoot"), Eval("idClasificacionItem"), Eval("idClasificacion"), "Foro", Eval("idTipo")) %>'>
									<asp:Label ID="lblTitulo" runat="server" CssClass='<%# getEstilo(Eval("idRoot"), Eval("idClasificacion"), Eval("idClasificacionItem"), 1) %>' Text='<%# Eval("titulo")%>'></asp:Label>
								</asp:HyperLink>
							</td>
						</tr>
					</ItemTemplate>
					<EmptyDataTemplate>
						<asp:Label ID="lblNoData" runat="server" CssClass="textoNoData12" Text="No hay accesibles en esta fecha"></asp:Label>
					</EmptyDataTemplate>
				</asp:ListView>
			</td>
		</tr>
		</table>
		</div>

	</ItemTemplate>
	<FooterTemplate>
	</FooterTemplate>
</asp:Repeater>--%>
<asp:HiddenField ID="hiddenModoEdicion" runat="server" />
<asp:HiddenField ID="hiddenModoVistaPrevia" runat="server" />
<asp:HiddenField ID="hiddenIdRoot" runat="server" />