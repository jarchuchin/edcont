<%@ Control Language="VB" AutoEventWireup="false" CodeFile="IndiceClasificacion.ascx.vb" Inherits="Sec_SalonVirtual_Controles_IndiceClasificacion" %>



<div class="panel">
 
    <div class="panel-body">



        <div class="mar-btm">
	
	        <div class="list-group bg-trans">

                <asp:Repeater ID="rptUnidades" runat="server">
                    <ItemTemplate>
                         <asp:HyperLink ID="lnkSalon2" runat="server" Text='<%# "~/sec/salonVirtual/verCarpeta.aspx?idSalonVirtual=" & claveSalon & "idClasificacion=" & Eval("idClasificacion") %>' CssClass="list-group-item">
                             <span class="badge badge-purple badge-icon badge-fw pull-left"></span> <asp:Literal ID="Literal2" runat="server" Text='<%# Eval("Titulo") %>' ></asp:Literal>
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>



        <div style="height:50px;"></div>


<div style="margin-bottom:15px;">
	<asp:Image ID="Image3" runat="server" ImageUrl="~/Images/bull-arrow3.png" /><span style="margin-left:5px;"><asp:HyperLink ID="lnkPruebaDiagnostico" runat="server">Prueba de diagnóstico</asp:HyperLink></span>
</div>

<div>
	<div style="margin-left:15px;" class="textoMenu12B">Contenidos</div>
	<div style="height:7px;  clear:both;"></div>
	<asp:ListView ID="listViewContenidos" runat="server">
		<LayoutTemplate>
			<div runat="server" ID="itemPlaceholder" />
		</LayoutTemplate>
		<ItemTemplate>
			<div style="margin-left:15px; clear:both;">
				<div style="float:left;"><asp:Image ID="Image2" runat="server" ImageUrl="~/Images/bull-arrow3.png" /></div>
				<div style="float:left; margin-left:5px; width:96%;">
					<asp:HyperLink ID="lnkContenido" runat="server" NavigateUrl='<%# getLinkAnexos(Eval("idRoot"), Eval("idClasificacionItem"), "Contenido", Eval("idTipo")) %>' text='<%# Eval("titulo")%>' />
					<asp:Label ID="lblTextoCorto" runat="server" Text='<%# getTextoCorto(Eval("textoCorto")) %>'></asp:Label>
				</div>
			</div>
		</ItemTemplate>
		<ItemSeparatorTemplate>
			<div style="height:7px;  clear:both;"></div>
		</ItemSeparatorTemplate>
		<EmptyDataTemplate>
			<div style="margin-left:30px;">
				<asp:Label ID="lblNoData" runat="server" CssClass="textoNoData12" Text="No hay accesibles en esta fecha"></asp:Label>
			</div>
		</EmptyDataTemplate>
	</asp:ListView>
</div>

<div style="height:15px;  clear:both;"></div>

<div>
	<div style="margin-left:15px;" class="textoMenu12B">Actividades</div>
	<div style="height:7px;  clear:both;"></div>
	<asp:ListView ID="listViewActividades" runat="server">
		<LayoutTemplate>
			<div runat="server" ID="itemPlaceholder">
			</div>
		</LayoutTemplate>
		<ItemTemplate>
			<div style="margin-left:15px; clear:both;">
				<div style="float:left;"><asp:Image ID="Image4" runat="server" ImageUrl="~/Images/bull-arrow3.png" /></div>
				<div style="float:left; margin-left:5px; width:96%;">
					<asp:HyperLink ID="lnkActividad" runat="server" NavigateUrl='<%# getLinkAnexos(Eval("idRoot"), Eval("idClasificacionItem"), "Actividad", Eval("idTipo")) %>' text='<%# Eval("titulo")%>' />.&nbsp;
					Evaluación por: <asp:Literal ID="litQuienCalifica" runat="server" Text='<%# evaluador(Eval("quienCalifica")) %>' />;
					resultados mostrados a compañeros: <asp:Literal ID="litSeMuestra" runat="server" Text='<%# seMuestra(Eval("mostrarRespuestas"), Eval("mostrarCalificacion"), Eval("mostrarObservaciones")) %>' />
				</div>
			</div>
		</ItemTemplate>
		<ItemSeparatorTemplate>
			<div style="height:7px;  clear:both;"></div>
		</ItemSeparatorTemplate>
		<EmptyDataTemplate>
			<div style="margin-left:30px;">
				<asp:Label ID="lblNoData" runat="server" CssClass="textoNoData12" Text="No hay accesibles en esta fecha"></asp:Label>
			</div>
		</EmptyDataTemplate>
	</asp:ListView>
</div>

<div style="height:15px;  clear:both;"></div>

<div>
	<div style="margin-left:15px;" class="textoMenu12B">Exámenes</div>
	<div style="height:7px;  clear:both;"></div>
	<asp:ListView ID="listViewExamenes" runat="server">
		<LayoutTemplate>
			<div runat="server" ID="itemPlaceholder">
			</div>
		</LayoutTemplate>
		<ItemTemplate>
			<div style="margin-left:15px; clear:both;">
				<div style="float:left;"><asp:Image ID="Image4" runat="server" ImageUrl="~/Images/bull-arrow3.png" /></div>
				<div style="float:left; margin-left:5px; width:96%;">
					<asp:HyperLink ID="lnkExamen" runat="server" NavigateUrl='<%# getLinkAnexos(Eval("idRoot"), Eval("idClasificacionItem"), "Examen", Eval("idTipo")) %>' text='<%# Eval("titulo")%>' />.&nbsp;
					Valor interno <asp:Literal ID="litPuntosTotales" runat="server" Text='<%# Eval("puntosTotales") %>' /> puntos, duración <asp:Literal ID="litTiempo" runat="server" Text='<%# Eval("tiempoEnMinutos") %>' /> minutos
				</div>
			</div>
		</ItemTemplate>
		<ItemSeparatorTemplate>
			<div style="height:7px;  clear:both;"></div>
		</ItemSeparatorTemplate>
		<EmptyDataTemplate>
			<div style="margin-left:30px;">
				<asp:Label ID="lblNoData" runat="server" CssClass="textoNoData12" Text="No hay accesibles en esta fecha"></asp:Label>
			</div>
		</EmptyDataTemplate>
	</asp:ListView>
</div>

<div style="height:15px;  clear:both;"></div>

<div>
	<div style="margin-left:15px;" class="textoMenu12B">Foros</div>
	<div style="height:7px;  clear:both;"></div>
	<asp:ListView ID="listViewForos" runat="server">
		<LayoutTemplate>
			<div runat="server" ID="itemPlaceholder">
			</div>
		</LayoutTemplate>
		<ItemTemplate>
			<div style="margin-left:15px; clear:both;">
				<div style="float:left;"><asp:Image ID="Image4" runat="server" ImageUrl="~/Images/bull-arrow3.png" /></div>
				<div style="float:left; margin-left:5px; width:96%;">
					<asp:HyperLink ID="lnkForo" runat="server" NavigateUrl='<%# getLinkAnexos(Eval("idRoot"), Eval("idClasificacionItem"), "Foro", Eval("idTipo")) %>' text='<%# Eval("titulo")%>' />
				</div>
			</div>
		</ItemTemplate>
		<ItemSeparatorTemplate>
			<div style="height:7px;  clear:both;"></div>
		</ItemSeparatorTemplate>
		<EmptyDataTemplate>
			<div style="margin-left:30px;">
				<asp:Label ID="lblNoData" runat="server" CssClass="textoNoData12" Text="No hay accesibles en esta fecha"></asp:Label>
			</div>
		</EmptyDataTemplate>
	</asp:ListView>
</div>


        </div>
    </div>


<div style="height:15px;"></div>

<asp:HiddenField ID="hiddenModoEdicion" runat="server" />
<asp:HiddenField ID="hiddenModoVistaPrevia" runat="server" />
<asp:HiddenField ID="HiddenidRoot" runat="server" />
<asp:HiddenField ID="hiddenIdClasificacion" runat="server" />