<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="Permisos.aspx.vb" Inherits="Sec_SalonVirtual_Permisos" title="Untitled Page" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>

<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server"  Text="Permisos de acceso" ></asp:Label> </h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/default.aspx" ></asp:HyperLink></li>
           <li><asp:HyperLink ID="lnkCurso" runat="server"  Text="Curso nombre"  NavigateUrl="~/sec/Sa/default.aspx" ></asp:HyperLink></li>
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Permisos" ></asp:Label></li>
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
                    <%-- <div class="panel-control pull-right">
                           
                            

                        <asp:Button ID="btnNuevo" CssClass="btn btn-primary btn-sm" runat="server" Text="Crear fecha" />

                    </div>
                      --%>

                        <h3 class="panel-title"><asp:Label ID="lblActividad" runat="server" text="Permisos de acceso"></asp:Label></h3>
                </div>
                <div class="panel-body">
		
     
      <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <div align="left" > <asp:Image ID="Image1" runat="server"  ImageUrl ="~/Images/indicator.gif" /><asp:Label ID="lbltexto" runat="server"   Text="Actualizando datos un momento por favor..." ></asp:Label></div>
                    </ProgressTemplate>
       </asp:UpdateProgress>
       <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional" >
               <ContentTemplate>
               <TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
	
	<TR>
		<TD align="left" width="150">
			<asp:label id="lblEmpresas" runat="server" CssClass="Mediana" Visible="false">Institución</asp:label></TD>
		<TD>
			<asp:dropdownlist id="drpEmpresa" runat="server" Visible="false" AutoPostBack="True" CssClass="Chica"></asp:dropdownlist>
			<asp:TextBox id="txtid" runat="server" Visible="False"></asp:TextBox>
			<asp:TextBox id="txttipopermiso" runat="server" Visible="False"></asp:TextBox></TD>
	</TR>
	<TR>
		<TD align="left" width="150"></TD>
		<TD>&nbsp;</TD>
	</TR>
	<TR>
		<TD align="left" width="150">
			<asp:label id="lblUsuarios" runat="server" Font-Bold="True">Usuarios</asp:label></TD>
		<TD class="form-inline">
			<asp:TextBox id="txtbuscar" runat="server" CssClass="form-control"></asp:TextBox>
			<asp:button id="btnBuscar" runat="server" CssClass="btn btn-primary btn-sm" Text="Buscar"></asp:button></TD>
	</TR>
	<TR>
		<TD align="left" width="150"></TD>
		<TD style="height:33px;">
            <div style="height:10px;"></div>
			<asp:dropdownlist id="drpUsuarios" runat="server" Visible="False" CssClass="form-control" Height="30px" AutoPostBack="True"></asp:dropdownlist></TD>
	</TR>
	<TR>
		<TD vAlign="top" align="left" width="150">
			&#160;</TD>
		<TD>
            <div style="height:15px;"></div>
			<asp:Label ID="lblPermisos" runat="server" Font-Bold="True">Selecciona los permisos para 
            este usuario</asp:Label>
		</TD>
	</TR>
	<tr>
		<td align="left" valign="top" width="150" style="height: 203px">
			</td>
		<td style="height: 203px">
			<table id="Table1" border="0" cellpadding="0" cellspacing="0" width="100%">
				<tr>
					<td>
						<asp:CheckBox ID="chkPRoots" runat="server" 
                       Text="Editar datos generales">
                        </asp:CheckBox></td>
				</tr>
				<tr>
					<td>
						<asp:CheckBox ID="chkPPermisosRoots" runat="server" 
                       Text="Configuración de permisos y calendario">
                        </asp:CheckBox></td>
				</tr>
				<tr>
					<td>
						<asp:CheckBox ID="chkPCategorias" runat="server" Text="Administrar agenda">
                        </asp:CheckBox></td>
				</tr>
				<tr>
					<td>
						<asp:CheckBox ID="chkPRespuestas" runat="server" 
                       Text="Actividades enviadas">
                        </asp:CheckBox></td>
				</tr>
				<tr>
					<td>
						<asp:CheckBox ID="chkPEvaluacion" runat="server" 
                       Text="Evaluación de alumnos">
                        </asp:CheckBox></td>
				</tr>
				<tr>
					<td>
						<asp:CheckBox ID="chkPSalonVirtual" runat="server" 
                       Text="Admitir alumnos solicitando inscripción">
                        </asp:CheckBox></td>
				</tr>
				<tr>
					<td>
						<asp:CheckBox ID="chkPContenidos" runat="server" 
                       Text="Asistencia">
                        </asp:CheckBox></td>
				</tr>
				<tr>
					<td>
						<asp:CheckBox ID="chkPInterfaceGrafica" runat="server" 
                       Text="El usuario puede cambiar la inferface gráfica" Visible="False">
                        </asp:CheckBox></td>
				</tr>
				<tr>
					<td>
						<asp:CheckBox ID="chkPEstadisticas" runat="server" 
                       Text="sadfa" Visible="False">
                        </asp:CheckBox></td>
				</tr>
				<tr>
					<td>
						<asp:CheckBox ID="chkPAdministracion" runat="server" 
                       Text="Usuarios administrador" Visible="False">
                        </asp:CheckBox></td>
				</tr>
			</table>
		</td>
	</tr>
	<TR>
		<TD vAlign="top" align="left" width="150"></TD>
		<TD>
			<asp:button id="btnGrabar" runat="server" Text="Grabar" CssClass="btn btn-success"></asp:button>&nbsp;
			<asp:button id="btnBorrar" runat="server" Visible="False" Text="Borrar" CssClass="btn btn-danger"></asp:button>
            <cc1:ConfirmButtonExtender ID="btnBorrar_ConfirmButtonExtender" runat="server" 
                       ConfirmText="¿Deseas quitar a este usuario de la lista de permisos especiales?" 
                       Enabled="True" TargetControlID="btnBorrar">
            </cc1:ConfirmButtonExtender>
        </TD>
	</TR>
</TABLE>

            <asp:GridView ID="gvPermisos" runat="server" DataKeyNames="idPermiso" Width="100%" AutoGenerateColumns="False"
				 CssClass="table table-striped table-hover" GridLines="none" >
				<columns>
                    <asp:hyperlinkfield HeaderText="Editar" Text="Editar" 
                        DataNavigateUrlFields="idPermiso,idRecurso"  ControlStyle-CssClass="btn-link"
                        DataNavigateUrlFormatString="Permisos.aspx?idSalonVirtual={1}&amp;idPermiso={0}" >
                    <headerstyle width="100px" />
                    </asp:hyperlinkfield>
                    <asp:boundfield DataField="Nombre" HeaderText="Nombre">
                    <headerstyle horizontalalign="Left" />
                    </asp:boundfield>
                </columns>
                

				
                   </asp:GridView>

               
               </ContentTemplate> 
        </asp:UpdatePanel>    


</div>
</div>

            </div>
       </div>

           <asp:Label ID="labelCursosComoDocente" runat="server" Text="Cursos como docente" Visible="false"></asp:Label>
    <asp:Label ID="labelCursosComoAlumno" runat="server" Text="Cursos como alumno"  Visible="false"></asp:Label>


</asp:Content>

