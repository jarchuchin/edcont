<%@ Control Language="VB" AutoEventWireup="false" CodeFile="displayEvaluacionAlumno.ascx.vb" Inherits="Sec_SalonVirtual_Controles_displayEvaluacionAlumno" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>



                
<div class="panel">
    <div class="panel-heading">
            <h3 class="panel-title"><asp:Label ID="lbltitulo" runat="server">Evaluación:</asp:Label>
	<asp:Label ID="lblNombre" runat="server" ></asp:Label> </h3>
    </div>
    <div class="panel-body">



    <div class="row">
        <div class="col-md-2"><asp:Image ID="imgAlumno" runat="server" Width="100px" /></div>
        <div class="col-md-6">
            <asp:Label ID="lblStatus" runat="server">Status del alumno</asp:Label>:&nbsp;
			<asp:Label ID="lblStatusI" runat="server" Text="Inscrito al curso" Font-Bold="true" Visible="false"></asp:Label>
			<asp:Label ID="lblStatusC" runat="server" Text="Calificación final asignada" Font-Bold="true" Visible="false"></asp:Label>
			<asp:Label ID="lblStatusR" runat="server" ForeColor="Red" Text="El alumno fué rechazado" Font-Bold="true" Visible="false"></asp:Label>
			<asp:Label ID="lblStatusS" runat="server" ForeColor="Red" Text="Solicitando inscripción" Font-Bold="true" Visible="false"></asp:Label><asp:Label ID="lblStatusB" runat="server" ForeColor="Red" Text="Alumno dado de baja" Font-Bold="true" Visible="false"></asp:Label>&nbsp;&nbsp;
			<asp:Label ID="lblCalificacionAlumno" runat="server" Font-Bold="True" Visible="False"></asp:Label><br />

			<asp:Label ID="lblDescripcion1" runat="server">El valor total del curso es:</asp:Label>&nbsp;
			<asp:Label ID="lblPuntosSalon" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label><br />
			<asp:Label ID="lblDescripcion2" runat="server">Alcanzado al momento:</asp:Label>&nbsp;
			<asp:Label ID="lblPuntosObtenidos" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label><br />

			<asp:Label ID="lblfechaconvenio" runat="server">Fecha de convenio:</asp:Label>&nbsp;
			<asp:Label ID="fechaConvenio" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label><br />
        </div>
        <div class="col-md-4 text-right">
<asp:Button ID="btnCrearConvenio" runat="server" CssClass="btn btn-primary  full-width" Text="Calificación diferida" Visible="False" />
               <div style="height:10px;"></div>
            <asp:Button ID="btnDarDeBajaAlumno" runat="server" CssClass="btn btn-danger full-width" Text="Dar de baja alumno" Visible="False" />
		    <cc1:ConfirmButtonExtender ID="btnDarDeBajaAlumno_ConfirmButtonExtender" runat="server" ConfirmText="¿Deseas dar de baja este alumno?" Enabled="True" TargetControlID="btnDarDeBajaAlumno">
            </cc1:ConfirmButtonExtender>

              <div style="height:10px;"></div>
            <asp:Button ID="btnAltaAlumno" runat="server" CssClass="btn btn-danger full-width" Text="Dar de alta alumno" Visible="False" />
		    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="¿Deseas dar de alta este alumno?" Enabled="True" TargetControlID="btnAltaAlumno">
            </cc1:ConfirmButtonExtender>


             <div style="height:10px;"></div>
             <asp:Button ID="btnEnviarCorreo" runat="server" CssClass="btn btn-success  full-width" Text="Enviar correo"  />

        </div>
    </div>
	




        <div style="height:5px;"></div>





		
                <asp:repeater ID="Datalist1" runat="server" >
                    <HeaderTemplate>
                         <table id="Table10" class="table table-striped" width="100%">
                              <th  style="width:40px;">
                                   
                                </th>
                                <th >
                                    <asp:Label ID="lbltituloD" runat="server" Font-Bold="True">Título</asp:Label>
                                </th>
                                <th  style="width:30px;">
                                    <asp:Label ID="lblTipoD" runat="server" Font-Bold="True">Tipo</asp:Label>
                                </th>
                                <th  style="width:30px;">
                                    <asp:Label ID="lblPorcD" runat="server" Font-Bold="True">Valor</asp:Label>
                                </th>
                    </HeaderTemplate>
                    <ItemTemplate>
				<tr>
					<td style="width:25px; vertical-align:top;"><asp:Image ID="Isssmagess10" runat="server" ImageUrl="~/Images/miniIconActvs.gif"></asp:Image></td>
					<td>
						<asp:Label ID="Label1" runat="server" Font-Bold="true"><%# DataBinder.Eval(Container.DataItem,"Titulo")%></asp:Label>
                         <div style="height:10px;"></div>
					<%--	<table style="width:100%" border="0" cellpadding="0" cellspacing="0">
						<tr>
							<td>&nbsp;</td>
							<td style="width:153px ; text-align:left;" class="texto10B">Enviado el</td>
							<td style="width:80px ; text-align:center;" class="texto10B">Calificación</td>
							<td style="width:80px ; text-align:center;" class="texto10B">% valor actividad</td>
							<td style="width:80px ; text-align:center;" class="texto10B">% alcanzado</td>
						</tr>
						</table>--%>
						<asp:DataGrid ID="Datagrid1s" runat="server" ShowHeader="true" AutoGenerateColumns="False" DataSource='<%# GetActivas(CInt(DataBinder.Eval(Container.DataItem, "idItemEvaluacion")), CInt(DataBinder.Eval(Container.DataItem, "idSalonVirtual")), Cint(DataBinder.Eval(Container.DataItem, "tipoItem")), cdec(DataBinder.Eval(Container.DataItem, "valor")) ) %>' CssClass="table table-hover" Font-Size="11px"  GridLines="None" Width="100%" HeaderStyle-Font-Bold="true">
						
							<Columns>

								<asp:templatecolumn>
									<HeaderStyle Width="15px"></HeaderStyle>
									<ItemStyle HorizontalAlign="center" Width="15px"></ItemStyle>
									<ItemTemplate>
										<asp:Image ID="Ismage11" runat="server" ImageUrl="~/Images/bull-arrow1.png"></asp:Image>
									</ItemTemplate>
								</asp:templatecolumn>

								<asp:templatecolumn>
									<HeaderStyle Width="350px"></HeaderStyle>
									<ItemStyle HorizontalAlign="left" VerticalAlign="Top"></ItemStyle>
									<ItemTemplate>
										<asp:HyperLink ID="lnktitulillo" Runat="server" CssClass="LigaVerde" NavigateUrl='<%# GetLigaRespuesta(cint(DataBinder.Eval(Container.DataItem,"idRespuesta")), cint(DataBinder.Eval(Container.DataItem,"idActividad")), cdec(DataBinder.Eval(Container.DataItem,"valorGeneral")), cdec(DataBinder.Eval(Container.DataItem,"ValorCalificacion") ), DataBinder.Eval(Container.DataItem,"tipo"), cdec(DataBinder.Eval(Container.DataItem,"Valor") )    )%>' Text='<%# DataBinder.Eval(Container.DataItem,"Titulo") %>'></asp:HyperLink>
									</ItemTemplate>
								</asp:templatecolumn>

								<asp:templatecolumn HeaderText="Enviado" >
									<HeaderStyle Width="125px"></HeaderStyle>
									<ItemStyle HorizontalAlign="left" VerticalAlign="Top" Width="125px"></ItemStyle>
									<ItemTemplate>
										<asp:Label ID="Label145" runat="server" ForeColor="black" Text='<%# DataBinder.Eval(Container.DataItem,"FechaEnvio", "{0:dd MMM hh:mm}" ) %>'></asp:Label>
									</ItemTemplate>
								</asp:templatecolumn>

								<asp:templatecolumn  HeaderText="Reenviar">
									<HeaderStyle Width="25px"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="25px"></ItemStyle>
									<ItemTemplate>
								      <asp:Image ID="Image2" runat="server" ToolTip="El maestro ha solicitado que reenvíes esta actividad" ImageUrl='<%# getImagenRepetir(cbool(DataBinder.Eval(Container.DataItem, "Repetir"))) %>' />
								  </ItemTemplate>
								</asp:templatecolumn>
								
								<asp:templatecolumn  HeaderText="Calificación">
									<HeaderStyle Width="80px"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="80px"></ItemStyle>
									<ItemTemplate>
										<asp:Label ID="lblCalificacionxyz" runat="server" ToolTip="El maestro ha asignado esta calificación a tu actividad"><%# format(CDec(eval("Calificacion"))/10, "0.0") %> </asp:Label>
									</ItemTemplate>
								</asp:templatecolumn>
								
								<asp:templatecolumn  HeaderText="% Valor">
									<HeaderStyle Width="80px"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="80px"></ItemStyle>
									<ItemTemplate>
										<asp:Label ID="Label9" runat="server" CssClass="Chica"><%# Format((CDec(Eval("Valor")) * CDec(Eval("ValorItem"))) / CDec(100.0), "0.00")%> %</asp:Label>
									</ItemTemplate>
								</asp:templatecolumn>
                                                  
								<asp:templatecolumn  HeaderText="% Alcanzado">
									<HeaderStyle Width="100px"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="80px"></ItemStyle>
									<ItemTemplate>
										<asp:Label ID="Label2" runat="server"><%# Format(CDec(CDec(Eval("Calificacion")) * ((CDec(Eval("Valor")) * CDec(Eval("ValorItem"))) / CDec(100.0))) / CDec(100.0), "0.00")%>%</asp:Label>
									</ItemTemplate>
								</asp:templatecolumn>
							</Columns>
						</asp:DataGrid>
                        
                        <div class="text-right" style="padding-right:5px;">
                              <asp:Label ID="Label6" runat="server" Font-Bold="true" Text="Total"></asp:Label>&nbsp;&nbsp; &nbsp;&nbsp;
                              <asp:Label ID="Label8" runat="server" Font-Bold="true"><%#Format(CDec(totalPorItem), "0.00")  %>%</asp:Label>
                        </div>
                      


				<%--		<table style="width:100%;" border="0" cellpadding="0" cellspacing="1">
						<tr>
							<td style="height:3px; font-size:3px;">&nbsp;</td>
							<td style="height:3px; border-bottom:1px solid #999; text-align:center; font-size:3px;" colspan="3"></td>
						</tr>
						<tr>
							<td>&nbsp;</td>
							<td style="width:80px; text-align:right;"></td>
							<td style="width:25px; text-align:right;"></td>
							<td style="width:30px; text-align:right;"></td>
						</tr>
						<tr>
							<td style="height:3px; font-size:3px;">&nbsp;</td>
							<td style="border-bottom:1px solid #999; text-align:center; font-size:3px;" colspan="3">&nbsp;</td>
						</tr>
						</table>--%>
					</td>
					<td style="width:30px; text-align:center; vertical-align:top;"><asp:Image ID="Image3" runat="server" ImageUrl='<%#"~/Images/Eval" & DataBinder.Eval(Container.DataItem,"tipoItem")  & ".gif"%>'></asp:Image></td>
                    <td style="width:30px; text-align:right; vertical-align:top;" class="texto12"><%# Eval("Valor")%>%</td>
                </tr>
             </ItemTemplate>
		<FooterTemplate>
            </table>
        </FooterTemplate>

        </asp:repeater>
	
		<table style="width:100%;" border="0" cellpadding="1" cellspacing="1">
		<tr>
			<td style="width:25px; height: 20px;"></td>
			<td><asp:Label ID="lbltotalrelativo" runat="server" Visible="False">Porcentaje relativo</asp:Label></td>
			<td></td>
			<td style="width:30px; text-align:center;"><asp:Label ID="lbltotald" runat="server" Font-Bold="True" ForeColor="Red">Total</asp:Label></td>
			<td style="width:30px; text-align:center;"><asp:Label ID="lbltot" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
		</tr>
		<tr>
			<td></td>
			<td style="text-align:right;"><asp:Label ID="lblAlcanzados" runat="server" CssClass="texto12B">Porcentaje general alcanzado:</asp:Label></td>
			<td style="text-align:right;"><asp:Label ID="lblTotalAlcanzado" CssClass="Mediana" runat="server"  Font-Bold="true"></asp:Label>%</td>
			<td></td>
			<td></td>
		</tr>
		<tr>
			<td></td>
			<td style="text-align:right;"><asp:Label ID="lblAlcanzados0" runat="server" CssClass="texto12B" ForeColor="Red">Tu calificación:</asp:Label></td>
			<td style="text-align:right;">
				<asp:Label ID="lblTotalCalificacion" CssClass="texto12B" runat="server" ForeColor="Red"></asp:Label>
				<asp:Label ID="Label3" CssClass="texto12B" runat="server" ForeColor="Red"></asp:Label>
			</td>
			<td></td>
			<td></td>
		</tr>
		</table>




<div style="text-align:right; width:95%">
	<br />
	<asp:HiddenField ID="hdid" runat="server" />
	
	<asp:Button ID="lnkCalificarAlumno" runat="server" Visible="false" CssClass="BotonSubmit" Text="Evaluación final" />
	<cc1:ConfirmButtonExtender ID="lnkCalificarAlumno_ConfirmButtonExtender" runat="server" ConfirmText="Será asignada la calificación final al alumno y cambiara su status. ¿Desea continuar?" Enabled="True" TargetControlID="lnkCalificarAlumno"></cc1:ConfirmButtonExtender>
</div>


        
                </div>

                </div>

         
