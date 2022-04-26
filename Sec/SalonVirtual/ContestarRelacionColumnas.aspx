<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="ContestarRelacionColumnas.aspx.vb" Inherits="Sec_SalonVirtual_ContestarRelacionColumnas" title="Relacionar columnas" %>



<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>
<%@ Register src="Controles/UbicadorPreguntas.ascx" tagname="UbicadorPreguntas" tagprefix="uc2" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title--><!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~--><div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server" Text="Relacionar columnas"  ></asp:Label></h1>
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
			<asp:HyperLink ID="lnkEdicionContenido" runat="server">Editar contenido</asp:HyperLink>
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

	<div style="margin-bottom:20px;">
		<asp:Label ID="pregunta" runat="server" Font-Bold="True"></asp:Label>
		<asp:TextBox ID="txtid" runat="server" Visible="False"></asp:TextBox>
	</div>

	<div>
		<asp:HyperLink ID="imgPreguntalink" runat="server" Visible="true" Target="_blank">
			<asp:Image ID="imgPregunta" runat="server" Visible="False" Width="150px" />
		</asp:HyperLink>
	</div>

	<div style="border-bottom:1px dotted #999;">
		<asp:Label ID="lblTagCuadroCompleto" runat="server" Font-Italic="true" Text="Vista completa de las columnas"></asp:Label>
		<table style="width:100%;" border="0" cellpadding="1" cellspacing="1">
		<tr>
			<td style="width:50%; vertical-align:top;">
				<asp:DataGrid ID="dtgItem0" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#C1CDD8" DataKeyField="idOP" EnableViewState="False" GridLines="None" ShowHeader="False" Width="100%">
					<SelectedItemStyle BackColor="#C1CDD8" />
					<HeaderStyle Font-Bold="True" HorizontalAlign="Left" />
					<Columns>
						<asp:TemplateColumn HeaderText="Opciones">
							<ItemStyle HorizontalAlign="Left" />
							<ItemTemplate>
								<div style="clear:both;">
									<div style="width:10px; float:left;"><asp:Image ID="Image9" runat="server" ImageUrl="~/Images/bull-arrow1.png" /></div>
									<div style="float:left;"><asp:Label ID="lblEnunciado" runat="server"><%# DataBinder.Eval(Container.DataItem,"enunciado" ) %></asp:Label></div>
								</div>
							</ItemTemplate>
						</asp:TemplateColumn>
					</Columns>
				</asp:DataGrid>
			</td>
			<td style="width:50%; vertical-align:top;">
				<asp:DataGrid ID="dtgItem" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#C1CDD8" DataKeyField="idOR" EnableViewState="False" GridLines="None" ShowHeader="False" Width="100%">
					<SelectedItemStyle BackColor="#C1CDD8" />
					<HeaderStyle Font-Bold="True" HorizontalAlign="Left" />
					<Columns>
						<asp:TemplateColumn HeaderText="Opciones">
							<ItemStyle HorizontalAlign="Left" />
							<ItemTemplate>
								<div style="clear:both;">
									<div style="width:10px; float:left;"><asp:Image ID="Image9" runat="server" ImageUrl="~/Images/bull-arrow1.png" /></div>
									<div style="float:left;"><asp:Label ID="lblEnunciado" runat="server"><%# DataBinder.Eval(Container.DataItem,"enunciado" ) %></asp:Label></div>
								</div>
							</ItemTemplate>
						</asp:TemplateColumn>
					</Columns>
				</asp:DataGrid>
			</td>
		</tr>
		</table>
   </div>


               <div style="height:15px;"></div>
	
		<asp:Label ID="lblrespuesta" runat="server" Font-Bold="False" Text="Relaciona correctamente las columnas"></asp:Label>
        <div style="height:5px;"></div>
		<asp:DataGrid ID="dtgSeleccion" runat="server" AutoGenerateColumns="False"  CssClass="table" DataKeyField="idOP" GridLines="None" Width="100%">

			<HeaderStyle Font-Bold="True" HorizontalAlign="Left" />
			<Columns>
				<asp:TemplateColumn HeaderText="COLUMNA 1">
					<HeaderStyle Width="50%" />
					<ItemTemplate>
						<asp:Label ID="lblEnunciado" runat="server"><%# DataBinder.Eval(Container.DataItem,"enunciado" ) %></asp:Label>
					</ItemTemplate>
				</asp:TemplateColumn>
				<asp:TemplateColumn HeaderText="COLUMNA 2">
					<HeaderStyle Width="50%" />
					<ItemTemplate>
						<asp:DropDownList ID="drpChido" runat="server" DataSource="<%# GetOpciones() %>" DataTextField="Enunciado" DataValueField="idOR" Width="250px" CssClass="form-control">
						</asp:DropDownList>
					</ItemTemplate>
				</asp:TemplateColumn>
			</Columns>
		</asp:DataGrid>

    
		<div style="margin-bottom:20px;">
		<asp:Label ID="valor" runat="server" Font-Bold="true"></asp:Label>&nbsp;
		<asp:Label ID="lblValor" runat="server" Text="Puntos" Font-Bold="true" ></asp:Label>
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