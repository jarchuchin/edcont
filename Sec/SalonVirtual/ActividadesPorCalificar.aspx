<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="ActividadesPorCalificar.aspx.vb" Inherits="Sec_SalonVirtual_ActividadesPorCalificar" title="Calificaciones por actividad" %>

<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>
<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server"  Text="Tareas recibidas" ></asp:Label></h1>
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
          <li><asp:HyperLink ID="lnkActividad" runat="server"  Text="Actividad"  ></asp:HyperLink></li>
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Actividades enviadas por alumnos" ></asp:Label></li>
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
                        <h3 class="panel-title"> 	<asp:Label ID="lblssActividad"  runat="server"   Text="Actividad: " ></asp:Label>	<asp:Label ID="lblActividad"  runat="server"   Text="Actividades enviadas por alumnos" ></asp:Label></h3>
                </div>
                <div class="panel-body">

	
	<asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
		<ProgressTemplate>
			<div style="text-align:left;">
				<asp:Image ID="Image1" runat="server" ImageUrl ="~/Images/indicator.gif" />
				<asp:Label ID="lbltexto" runat="server"  Text="Actualizando datos..."></asp:Label>
			</div>
		</ProgressTemplate>
	</asp:UpdateProgress>

	<asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
		<ContentTemplate>
			<br />
			<asp:GridView ID="gvCalificaciones" runat="server" AllowSorting="True"  GridLines="None" DataKeyNames="idUserProfile" AutoGenerateColumns="False" Width="100%" CssClass="table table-striped table-hover">
			
				<RowStyle  HorizontalAlign="Center"/>
				<columns>
					<asp:templatefield HeaderText="">
						<headerstyle horizontalalign="Center" width="70px" />
						<itemstyle horizontalalign="Center" />
						<itemtemplate>
							<asp:HyperLink ID="HyperLink1s" runat="server" NavigateUrl='<%# getRespuesta(cint(eval("idUserProfile"))) %>' CssClass="btn btn-link">Calificar</asp:HyperLink>
						</itemtemplate>
					</asp:templatefield>
					<asp:templatefield HeaderText="">
						<headerstyle horizontalalign="Center" width="70px" />
						<itemstyle horizontalalign="Center" />
						<itemtemplate>
							<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# getRespuesta2(cint(eval("idUserProfile"))) %>' CssClass="btn btn-link">Detalle</asp:HyperLink>
						</itemtemplate>
					</asp:templatefield>
					<asp:BoundField DataField="Apellidos" HeaderText="Apellidos" HtmlEncode="False" SortExpression="Apellidos">
						<itemstyle horizontalalign="Left" />
					</asp:BoundField>
					<asp:BoundField DataField="Nombre" HeaderText="Nombre" HtmlEncode="False" SortExpression="Nombre">
						<itemstyle horizontalalign="Left" />
					</asp:BoundField>
					<asp:templatefield HeaderText="Enviado">
						<headerstyle horizontalalign="Center" width="50px" />
						<itemstyle horizontalalign="Center" width="50px"  />
						<itemtemplate>
   							<asp:Image ID="Image2"  ImageUrl='<%# "~/images/" & getEnviada(cint(eval("idUserProfile"))) %>' runat="server" />
						</itemtemplate>
					</asp:templatefield>
					<asp:templatefield HeaderText="Enviada">
						<headerstyle horizontalalign="Center" width="80px" />
						<itemstyle horizontalalign="Center" />
						<itemtemplate>
   							<asp:Label  ID="lblFecha" runat="server" Text='<%# getFecha(cint(eval("idUserProfile"))) %>'></asp:Label>
						</itemtemplate>
					</asp:templatefield>
					<asp:templatefield HeaderText="Calificación">
						<headerstyle horizontalalign="Center" width="90px" />
						<itemstyle horizontalalign="Center" />
						<itemtemplate>
	   						<asp:Label  ID="lblCalificacion" runat="server" Text='<%# getCalificacion(cint(eval("idUserProfile"))) %>' ></asp:Label>
						</itemtemplate>
					</asp:templatefield>
				</columns>
			</asp:GridView>
			<br />
			<table style="width: 100%">
			<tr>
				<td>&nbsp;</td>
				<td style="width: 230px; text-align:center">
					<asp:Label ID="Label2" runat="server" CssClass="Mediana" Font-Bold="true" Text="Calificación promedio de esta actividad:"></asp:Label>
				</td>
				<td style="width:90px; text-align:center"><asp:Label ID="lblpromedio" runat="server"  Font-Bold="true"></asp:Label></td>
			</tr>
			</table>
		</ContentTemplate>
	</asp:UpdatePanel>


                          </div>
                </div>
            </div>


          

          </div>



    

        <asp:Label ID="labelCursosComoDocente" runat="server" Text="Cursos como docente" Visible="false"></asp:Label>
        <asp:Label ID="labelCursosComoAlumno" runat="server" Text="Cursos como alumno"  Visible="false"></asp:Label>
</asp:Content>




