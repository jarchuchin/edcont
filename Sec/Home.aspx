<%@ Page Title="SKOLAR - Inicio" Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="Home.aspx.vb" Inherits="Sec_Home"   EnableEventValidation="false" Culture="auto"  UICulture="auto" %>
<%@ Register src="../Controles/HeaderBreadcrumbHome.ascx" tagname="HeaderBreadcrumbHome" tagprefix="uc1" %>
<%@ Register src="Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="Controles/DisplayAgenda.ascx" tagname="DisplayAgenda" tagprefix="uc3" %>


<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lbltitulo" runat="server" Text="Portal de inicio"></asp:Label></h1>

       
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelBreadcrumb" Runat="Server">
 
<ol class="breadcrumb"  >
  <li >
      <asp:Label ID="Label1" runat="server" Text="Inicio"></asp:Label></li>
</ol>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">



<!--Premium Line Icons [ OPTIONAL ]-->
    <link href="../premium/icon-sets/line-icons/premium-line-icons.css" rel="stylesheet">



<!--Tiles - Bright Version-->
<!--===================================================-->
<div class="row">
	<div class="col-sm-6 col-lg-3" id="divLibrosDeTrabajo" runat="server">
					
		<!--Registered User-->
		<!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
		<div class="panel media pad-all">
			<div class="media-left">
			<%--	<span class="icon-wrap icon-wrap-xs bg-success">
					<i class="pli-books icon-3x"></i>
				</span>--%>
                 <asp:HyperLink ID="HyperLink4" runat="server" CssClass="text-muted"  ImageUrl="~/images/otros/t-iconAgregarNota.png"  NavigateUrl="~/Sec/Libros.aspx"></asp:HyperLink>
			</div>
					
			<div class="media-body">
				<p class="text-2x mar-no text-semibold">
                    <asp:Literal ID="litlibros" runat="server"></asp:Literal></p>
				<p class="text-muted mar-no">
                    <asp:HyperLink ID="lnkRoot" runat="server" CssClass="text-muted"  NavigateUrl="~/Sec/Libros.aspx">Libros de trabajo</asp:HyperLink></p>
			</div>
		</div>
		<!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
					
	</div>
	<div class="col-sm-6 col-lg-3">
					
		<!--New Order-->
		<!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
		<div class="panel media pad-all">
			<div class="media-left">
			<%--	<span class="icon-wrap icon-wrap-xs bg-info">
					<i class="pli-calendar icon-3x"></i>
				</span>--%>
                <asp:HyperLink ID="HyperLink5" runat="server" CssClass="text-muted"  ImageUrl="~/images/otros/t-iconAgendarConsulta.png"  NavigateUrl="~/Sec/ActividadePendientes.aspx"></asp:HyperLink>
			</div>
					
			<div class="media-body">
				<p class="text-2x mar-no text-semibold"><asp:Literal ID="litActividadesPendientes" runat="server"></asp:Literal></p>
				<p class="text-muted mar-no"><asp:HyperLink ID="HyperLink3" runat="server" CssClass="text-muted"  NavigateUrl="~/Sec/ActividadePendientes.aspx">Actividades pendientes</asp:HyperLink></p>
			</div>
		</div>
		<!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
					
	</div>
	<div class="col-sm-6 col-lg-3">
					
		<!--Comments-->
		<!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
		<div class="panel media pad-all">
			<div class="media-left">
				<%--<span class="icon-wrap icon-wrap-xs bg-warning">
					<i class="pli-computer icon-3x"></i>
				</span>--%>
                <asp:HyperLink ID="HyperLink6" runat="server" CssClass="text-muted" ImageUrl="~/images/otros/t-iconSaldoProveedores.png"   NavigateUrl="~/Sec/default.aspx"></asp:HyperLink>
			</div>
					
			<div class="media-body">
				<p class="text-2x mar-no text-semibold"> <asp:Literal ID="litCursosA" runat="server"></asp:Literal></p>
				<p class="text-muted mar-no"><asp:HyperLink ID="HyperLink1" runat="server" CssClass="text-muted"  NavigateUrl="~/Sec/default.aspx">Cursos activos como alumno</asp:HyperLink></p>
			</div>
		</div>
		<!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
					
	</div>
	<div class="col-sm-6 col-lg-3" id="divCursosComoDocente" runat="server">
					
		<!--Sales-->
		<!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
		<div class="panel media pad-all">
			<div class="media-left">
				<%--<span class="icon-wrap icon-wrap-xs bg-danger">
					<i class="pli-wacom-tablet icon-3x"></i>
				</span>--%>
                 <asp:HyperLink ID="HyperLink7" runat="server" CssClass="text-muted" ImageUrl="~/images/logousmart.png"  ImageWidth="40px"  NavigateUrl="~/Sec/defaultdocente.aspx"></asp:HyperLink>
			</div>
					
			<div class="media-body">
				<p class="text-2x mar-no text-semibold"> <asp:Literal ID="litCursosD" runat="server"></asp:Literal></p>
				<p class="text-muted mar-no"><asp:HyperLink ID="HyperLink2" runat="server" CssClass="text-muted"  NavigateUrl="~/Sec/defaultdocente.aspx">Cursos activos como docente</asp:HyperLink></p>
			</div>
		</div>
		<!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
					
	</div>
</div>
<!--===================================================-->
<!--End Tiles - Bright Version-->


<div class="row">
	<div class="col-sm-12 col-lg-6">
		<div class="panel">
			<div class="panel-heading">
                <h3 class="panel-title"> <asp:Label ID="Label2" runat="server" Text="Mensajes generales" ></asp:Label></h3>

            </div>
             <div class="panel-body">

                   <div class="alert alert-danger" id="divmensajeDirecto" runat="server" visible="false">
                     <asp:label id="lblMensajeDirecto" runat="server" text="ddddd"></asp:label>
                 </div>


                 <div class="mensajeFinanzas" >
     
                     <asp:label id="lblMensajeFinanzas" runat="server" Visible="false" ForeColor="Red"></asp:label>

                     <asp:Literal ID="lblMensajeUM" runat="server" ></asp:Literal>

<%-- <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/images/utils/pasosmatriculaEnero2018.jpg" Target="_blank">
            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/utils/pasosmatriculaEnero2018.jpg" CssClass="img-responsive"  />

                      </asp:HyperLink>--%>
 
                </div>
            </div>


        </div>
    </div>
    <div class="col-sm-12 col-lg-6">


        <div class="panel">
              <div class="panel-body">
              <%--    <asp:HyperLink ID="lnkBanner" runat="server" NavigateUrl="https://www.escuelasuperiordenegocios.mx/">
                      </asp:HyperLink>--%>
            <asp:Image ID="imgEmrpesa" runat="server" ImageUrl="~/images/diamantebaners/ban1.jpg" CssClass="img-responsive"  />
                  <asp:Literal ID="litEmpresa" runat="server" ></asp:Literal>

                  </div>
        </div>


    </div>
</div>


<div class="row">
	<div class="col-xs-12">
		<div class="panel">
			<div class="panel-heading">
                <h3 class="panel-title"> <asp:Label ID="Label4" runat="server" Text="Agenda general"></asp:Label></h3>

            </div>
             <div class="panel-body">
 <%--<uc3:DisplayAgenda ID="DisplayAgenda1" runat="server" />--%>



                   <!-- Calendar placeholder-->
					<!-- ============================================ -->
					<div id='Skolar-calendar'></div>
					<!-- ============================================ -->



            </div>


        </div>
    </div>
</div>




 

     
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">



     <uc2:MenuGeneral ID="MenuGeneral1" runat="server" />



</asp:Content>




<asp:Content ID="content2" ContentPlaceHolderID="ContentPlaceHead" Runat="Server">

     <!--Full Calendar [ OPTIONAL ]-->
  <asp:PlaceHolder runat="server">

     <link href=<%= appName & "plugins/fullcalendar/fullcalendar.min.css""" %> rel="stylesheet">
     <link href=<%= appName & "plugins/jquery.qtip.custom/jquery.qtip.min.css""" %> rel="stylesheet">

     </asp:PlaceHolder>

</asp:Content>




<asp:Content ID="content6" ContentPlaceHolderID="ContentPlaceFooterScripts" Runat="Server">

      <asp:PlaceHolder runat="server">
        <!--Full Calendar [ OPTIONAL ]-->
  
    
     <script src=<%= appName & "plugins/fullcalendar/lib/moment.min.js""" %>></script>
     <script src=<%= appName & "plugins/fullcalendar/lib/jquery-ui.custom.min.js""" %>></script>
   <script src=<%= appName & "plugins/fullcalendar/fullcalendar.min.js""" %>></script>
   <script src=<%= appName & "plugins/fullcalendar/lang-all.js""" %>></script>
   <script src=<%= appName & "plugins/jquery.qtip.custom/jquery.qtip.min.js""" %>></script>

</asp:PlaceHolder>


    <asp:Literal runat="server" ID="litScript"></asp:Literal>

 

</asp:Content>