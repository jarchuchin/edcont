<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="Accesos.aspx.vb" Inherits="Sec_SalonVirtual_Accesos" title="Untitled Page" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>
<%@ Register src="Controles/displayAccesos.ascx" tagname="displayAccesos" tagprefix="uc2" %>
<%@ Register src="Controles/displayApuntes.ascx" tagname="displayApuntes" tagprefix="uc3" %>
<%@ Register src="Controles/displayAgenda7dias.ascx" tagname="displayAgenda7dias" tagprefix="uc4" %>
<%@ Register src="Controles/displayForos.ascx" tagname="displayForos" tagprefix="uc5" %>
<%@ Register src="Controles/displayBoletin.ascx" tagname="displayBoletin" tagprefix="uc6" %>
<%@ Register src="Controles/displayCapilla.ascx" tagname="displayCapilla" tagprefix="uc7" %>
<%@ Register src="Controles/displayIntructores.ascx" tagname="displayIntructores" tagprefix="uc9" %>
<%@ Register src="Controles/displayEspectometro.ascx" tagname="displayEspectometro" tagprefix="uc10" %>
<%@ Register src="Controles/displayIntroduccion.ascx" tagname="displayIntroduccion" tagprefix="uc11" %>
<%@ Register src="Controles/displayPreguntasAcces.ascx" tagname="displayPreguntasAcces" tagprefix="uc12" %>
<%@ Register src="Controles/DisplayExploradorContenidos.ascx" tagname="DisplayExploradorContenidos" tagprefix="uc14" %>
<%@ Register src="Controles/displayAlumnos2.ascx" tagname="displayAlumnos2" tagprefix="uc8" %>





<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>



<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server"  ></asp:Label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/default.aspx" ></asp:HyperLink></li>
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  >Accesos</asp:Label></li>
    </ol>


   
</asp:Content>


<asp:Content ID="contentCentral" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

        <div class="row">
      <div class="col-md-3 hidden-sm hidden-xs">

            
             <uc1:MenuSalonVirtual ID="MenuSalonVirtual1" runat="server" />

        </div>

      <div class="col-md-7 col-sm-8 col-xs-12">
            <div class="panel">
                <div class="panel-heading">
                        <h3 class="panel-title"><asp:Label ID="Label1" runat="server" Text="Accesos al sistema"></asp:Label></h3>
                </div>
                <div class="panel-body">



      
	<asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
		<ProgressTemplate>
			<div style="text-align:left;">
				<asp:Image ID="Image1" runat="server" ImageUrl ="~/Images/indicator.gif" />
				<asp:Label ID="lbltexto" runat="server"  Text="Actualizando datos..." ></asp:Label>
			</div>
		</ProgressTemplate>
	</asp:UpdateProgress>

	<asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional" >
		<ContentTemplate>
			<br />
				<asp:DropDownList ID="drpUsuariosAccesos" runat="server" AutoPostBack="True" DataTextField="nombre" DataValueField="idUserProfile">
				</asp:DropDownList>
			<br />

			<asp:GridView ID="gvAccesos" runat="server" AllowSorting="True" DataKeyNames="idSalonVirtualEntrada" AutoGenerateColumns="False" Width="100%">
				<headerstyle font-bold="True" forecolor="Black" HorizontalAlign="Left" />
				<rowstyle horizontalalign="Left" />
				<columns>
					<asp:BoundField DataField="Fecha"  HeaderText="Fecha" htmlencode="false"  DataFormatString="{0:dd MMM yyy hh:mm tt}">
						<HeaderStyle HorizontalAlign="Left" />
						<ItemStyle HorizontalAlign="Left" Width="200px" />
					</asp:BoundField>
					<asp:boundfield DataField="Nombre" HeaderText="Nombre" HtmlEncode="False" ></asp:boundfield>
				</columns>
			</asp:GridView>
		</ContentTemplate>
	</asp:UpdatePanel>

                    </div>
                </div>
          
          </div>

             <div class="col-md-2 col-sm-4 col-xs-12">

                <div class="hidden-lg hidden-md hidden-xs">
                <uc1:MenuSalonVirtual ID="MenuSalonVirtual2" runat="server" />
                </div>

             </div>


        </div>


</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">
   
     <uc22:MenuGeneral ID="MenuGeneral1" runat="server" />

</asp:Content>