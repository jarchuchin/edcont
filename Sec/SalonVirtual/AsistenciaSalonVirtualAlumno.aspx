<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="AsistenciaSalonVirtualAlumno.aspx.vb" Inherits="Sec_SalonVirtual_AsistenciaSalonVirtualAlumno" title="Registro de asistencia" %>

<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server"  Text="Registro de asistencia" ></asp:Label> </h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/default.aspx" ></asp:HyperLink></li>
           <li><asp:HyperLink ID="lnkCurso" runat="server"  Text="Curso nombre"  NavigateUrl="~/sec/Sa/default.aspx" ></asp:HyperLink></li>
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Asistencia" ></asp:Label></li>
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
                     <%--  <div class="panel-control">
                            <div class="pull-right">
                              <asp:Button ID="btnNuevo" runat="server" Text="Nueva evaluación" CssClass="btn btn-primary btn-sm" />
                            </div>
                        </div>--%>

                        <h3 class="panel-title"><asp:Label ID="lblActividad" runat="server"  Text="Registro de asistencia"></asp:Label></h3>
                </div>
                <div class="panel-body">




        <asp:datagrid id="dtgLista" runat="server" Width="100%" GridLines="None" DataKeyField="idAsistenciaLista"
		AutoGenerateColumns="False" CssClass="table table-hover table-striped" >
	

		<Columns>
			<asp:TemplateColumn>
				<HeaderStyle Width="25px"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center"></ItemStyle>
				<ItemTemplate>
					<asp:Image id="Image3" runat="server" ImageUrl="../../Images/user.gif"></asp:Image>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="Fecha">
				<HeaderStyle Font-Bold="True" HorizontalAlign="Left"></HeaderStyle>
				<ItemTemplate>
					<asp:Label id="lblTexto" runat="server">
						<%# DataBinder.Eval(Container.DataItem, "Fecha", "{0:D}") %>
					</asp:Label>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:TemplateColumn HeaderText="&lt;IMG alt=&quot;&quot; src=&quot;../../Images/asistenciaA.gif&quot; border=0&gt;&nbsp;&lt;IMG alt=&quot;&quot; src=&quot;../../Images/asistenciaR.gif&quot; border=0&gt;&nbsp;&lt;IMG alt=&quot;&quot; src=&quot;../../Images/asistenciaI.gif&quot; border=0&gt;">
				<HeaderStyle HorizontalAlign="Center" Width="100px"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center"></ItemStyle>
				<ItemTemplate>
					<asp:CheckBox id="CheckBox1" runat="server" Enabled="False" Checked='<%# DataBinder.Eval(Container.DataItem, "Asistencia") %>'>
					</asp:CheckBox>
					<asp:CheckBox id="CheckBox2" runat="server" Enabled="False" Checked='<%# DataBinder.Eval(Container.DataItem, "Retraso") %>'>
					</asp:CheckBox>
					<asp:CheckBox id="CheckBox3" runat="server" Enabled="False" Checked='<%# DataBinder.Eval(Container.DataItem, "Inasistencia") %>'>
					</asp:CheckBox>
				</ItemTemplate>
			</asp:TemplateColumn>
		</Columns>
       
	</asp:datagrid>

  </div>

             </div>
        </div>

    </div>

        &nbsp;&nbsp;&nbsp;&nbsp;

        <asp:Label ID="labelCursosComoDocente" runat="server" Text="Cursos como docente" Visible="false"></asp:Label>
    <asp:Label ID="labelCursosComoAlumno" runat="server" Text="Cursos como alumno"  Visible="false"></asp:Label>
</asp:Content>

