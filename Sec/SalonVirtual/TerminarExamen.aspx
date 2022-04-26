<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="TerminarExamen.aspx.vb" Inherits="Sec_SalonVirtual_TerminarExamen" title="Terminar examen" %>

<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>
<%@ Register src="Controles/UbicadorPreguntas.ascx" tagname="UbicadorPreguntas" tagprefix="uc2" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>




<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server"  Text="Terminar examen" ></asp:Label> </h1>
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

        <div class="col-xs-3">
             <uc1:MenuSalonVirtual ID="MenuSalonVirtual2" runat="server" />
        </div>
        <div class="col-xs-9">

                        
            <div class="panel">
             
                <div class="panel-heading">
                 

                        <h3 class="panel-title"><asp:Label ID="lbltitulo" runat="server" Text="Terminar examen: "></asp:Label>

                            <asp:Label ID="lbltituloexamen" runat="server" Font-Bold="True"></asp:Label>
                        </h3>
                </div>
                <div class="panel-body">
 
	

		<uc2:UbicadorPreguntas ID="UbicadorPreguntas1" runat="server" />


	<span style="text-align:center;">
		<asp:Label ID="lblsimulacion" runat="server" Font-Size="Large" ForeColor="Red" Visible="False">Simulación</asp:Label>
		<asp:Label ID="lblerrorUM" runat="server" Font-Bold="True" ForeColor="Red" Visible="False">[ERROR DE CONEXIÓN AL SISTEMA UM] intenta más tarde o contacta la oficina Skolar</asp:Label>
		<asp:Label ID="lblerrorcontestarpreguntas" runat="server" Font-Bold="True" ForeColor="Red" Visible="False">Debes contestar todas la preguntas</asp:Label>
	</span>

	

	<div style="height:25px;"></div>



		<asp:Label ID="lblPreguntasContestadas" runat="server" Font-Bold="true">Preguntas contestadas</asp:Label>&nbsp;
		<asp:Label ID="preguntasContestadas" runat="server" ForeColor="Red"></asp:Label>
	

	<div style="width:350px; ">
		<asp:Label ID="lblMensaje" runat="server" Font-Italic="True">Al terminar el examen no podrás reeditar las preguntas ni acceder a ellas. Verifica que todas 
			las preguntas fueron respondidas. Si es asÍ, presiona UNA SOLA VEZ EL BOTÓN DE TERMINAR EXAMEN para finalizar.</asp:Label>
		<asp:Label ID="lblMensaje2" runat="server" Font-Italic="True" Visible="false" >Verifica que todas las preguntas fueron respondidas. Si es asÍ, presiona UNA SOLA VEZ EL BOTÓN DE 
			TERMINAR EXAMEN para finalizar.</asp:Label>
	</div>


                  

                    <div id="panelResumen" runat="server" >
                          <hr />

		<table style="width:100%;" border="0" cellpadding="1" cellspacing="1">
		<tr>
			<td style="width:220px; height:30px;"><asp:Label ID="lblInicio" runat="server" Font-Bold="true">Hora de inicio</asp:Label></td>
			<td><asp:Label ID="inicio" runat="server"></asp:Label></td>
		</tr>
		<tr>
			<td style="height:30px;"><asp:Label ID="lblFin" runat="server" Font-Bold="true">Hora de conclusión</asp:Label></td>
			<td><asp:Label ID="fin" runat="server"></asp:Label></td>
		</tr>
		<tr>
			<td style="height:30px;"><asp:Label ID="lbltotalminutos" runat="server" Font-Bold="true">Minutos utilizados</asp:Label></td>
			<td><asp:Label ID="totalMinutos" runat="server"></asp:Label></td>
		</tr>
		<tr>
			<td style="height:30px;"><asp:Label ID="lblcalificacion" runat="server" Font-Bold="true">Puntos obtenidos</asp:Label></td>
			<td><asp:Label ID="calificacion" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
		</tr>
		</table>
                    </div>
  <hr />



	<asp:Panel ID="Panel1" runat="server" Visible="False">
		<div >
			<asp:Label ID="lblStatus" runat="server"></asp:Label>
			<asp:Label ID="lblEstatus" runat="server" Text="El examen debe ser revisado por tu maestro para obtener la calificación final" Visible="False"></asp:Label>
			<asp:Label ID="lblFechaVencida" runat="server" CssClass="Chica" ForeColor="Red" Text="La fecha ha vencido para responder esta actividad" Visible="False"></asp:Label>
		</div>
	</asp:Panel>


                    	<div style="height:25px;"></div>

	<div>
		<asp:Button ID="btnGrabar" runat="server" CssClass="btn btn-success" Text="Enviar examen para revisión" />&nbsp;
		<cc1:ConfirmButtonExtender ID="btnGrabar_ConfirmButtonExtender" runat="server" ConfirmText="¿Deseas terminar el examen?" Enabled="True" TargetControlID="btnGrabar"></cc1:ConfirmButtonExtender>
		<asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-default" Text="Cancelar" />&nbsp;<asp:Button ID="btnRecontestar" runat="server" CssClass="btn btn-danger"  Visible="false" Text="Volver a contestar" />
		&nbsp;<asp:Button ID="btnRecontestar0" runat="server" CssClass="btn btn-primary"  
            Visible="false" Text="Ir a evaluación" />
		
		<cc1:ConfirmButtonExtender ID="btnGrabar0_ConfirmButtonExtender" runat="server" ConfirmText="¿Deseas contestar nuevamente el examen?" Enabled="True" TargetControlID="btnRecontestar"></cc1:ConfirmButtonExtender>
	</div>

	<div>
		<asp:DataGrid ID="dtgItem" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#C1CDD8" DataKeyField="idPregunta" GridLines="None" Width="100%">
			<SelectedItemStyle BackColor="#C1CDD8" />
			<HeaderStyle BackColor="#E8F0F1" Font-Bold="True" HorizontalAlign="Left" />
			<Columns>
				<asp:TemplateColumn>
					<HeaderStyle Width="30px" />
					<ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
					<ItemTemplate>
						<asp:Image ID="Imagse9" runat="server" ImageUrl='<%# "~/Images/" & DataBinder.Eval(Container.DataItem, "tipoPregunta") & "quest.gif" %>' />
					</ItemTemplate>
				</asp:TemplateColumn>
				<asp:TemplateColumn HeaderText="Resumen del examen">
					<HeaderStyle HorizontalAlign="Left" />
					<ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
					<ItemTemplate>
						<div style="margin-bottom:10px;">
							<asp:Label ID="lblPregunta" runat="server"><%# GetEnunciado(DataBinder.Eval(Container.DataItem, "enunciado") ) %></asp:Label>
						</div>
						<div style="margin-bottom:10px;">
							<asp:Label ID="labelrespuestafront" runat="server" CssClass="texto11B">Tu respuesta:</asp:Label><br />
							<asp:Literal ID="litRespuesta" runat="server"></asp:Literal>
							<asp:PlaceHolder ID="myplaceholder" runat="server"></asp:PlaceHolder>
						</div>
						<div style="margin-bottom:10px; border-bottom:1px dotted #999;">
							<asp:Label ID="lblclave" runat="server" CssClass="texto11B" ForeColor="Red"> La respuesta correcta es:</asp:Label><br />
							<asp:Literal ID="litClave" runat="server"></asp:Literal>
						</div>
					</ItemTemplate>
				</asp:TemplateColumn>
				<asp:TemplateColumn HeaderText="Puntos">
					<HeaderStyle Width="150px" />
					<ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
					<ItemTemplate>
						<div>
							<asp:Label ID="lblTagObtenidos" runat="server" CssClass="Mediana" Font-Bold="true">Obtenidos:</asp:Label>&nbsp;
							<asp:label ID="txtValorObtenido" runat="server" Columns="4" MaxLength="4" Text='<%# Format(DataBinder.Eval(Container.DataItem, "tipoPregunta"), "0.00") %>'></asp:label>
						</div>
						<div class="texto11B">
							<asp:Label ID="LabelvalorFront" runat="server">Valor:</asp:Label>&nbsp;
							<asp:Label ID="lblval" runat="server" Font-Italic="True" ForeColor="Red"><%# Format(DataBinder.Eval(Container.DataItem, "valor"), "0.00") %> </asp:Label>
						</div>
					</ItemTemplate>
				</asp:TemplateColumn>
			</Columns>
		</asp:DataGrid>
	</div>

	<span>
		<asp:Label ID="lblverdadero" runat="server" Text="Verdadero" Visible="False"></asp:Label>
		<asp:Label ID="lblFalso" runat="server" Text="Falso" Visible="False"></asp:Label>
	</span>


                    </div>

                </div>


            </div>


       </div>

    
        <asp:Label ID="labelCursosComoDocente" runat="server" Text="Cursos como docente" Visible="false"></asp:Label>
    <asp:Label ID="labelCursosComoAlumno" runat="server" Text="Cursos como alumno"  Visible="false"></asp:Label>
    
</asp:Content>

