<%@ Page Title="Información general" Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="Home.aspx.vb" Inherits="Sec_Workbook_Home" meta:resourcekey="PageResource1"  Culture="auto"  UICulture="auto" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc2" %>



<%@ Register src="Controles/Menu.ascx" tagname="Menu" tagprefix="uc1" %>



<%@ Register src="Controles/DisplayProgress.ascx" tagname="DisplayProgress" tagprefix="uc3" %>



<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombredelLibro2" runat="server" meta:resourcekey="lblNombredelLibro2Resource1" ></asp:Label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelBreadcrumb" Runat="Server">

   
<ol class="breadcrumb"  >
  <li><asp:HyperLink ID="HyperLink3" runat="server"  Text="Inicio" NavigateUrl="~/sec/home.aspx" meta:resourcekey="HyperLink3Resource1"></asp:HyperLink></li>
     <li><asp:HyperLink ID="HyperLink2" runat="server"  Text="Libros de trabajo" NavigateUrl="~/sec/Libros.aspx" meta:resourcekey="HyperLink2Resource1"></asp:HyperLink></li>
  <li class="active"><asp:Label ID="lblNombreDelLibro" runat="server" meta:resourcekey="lblNombreDelLibroResource1" ></asp:Label></li>
</ol>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

<div class="row">
	<div class="col-xs-9">
		<div class="panel">

            <div class="panel-heading">
                <div class="panel-control">
 <div class="btn-group pull-right">
                    <button aria-expanded="false" aria-haspopup="true" class="btn btn-info btn-sm dropdown-toggle" data-toggle="dropdown" type="button">
                        <asp:Literal ID="Literal1" runat="server" Text="Idiomas" meta:resourcekey="Literal1Resource1"></asp:Literal>
                        <span class="caret"></span>
                    </button>
                    <ul class="dropdown-menu">
                        <li>
                            <asp:HyperLink ID="lnkIdiomaDefault" runat="server" meta:resourcekey="lnkIdiomaDefaultResource1">[lnkIdiomaDefault]</asp:HyperLink></li>
                        <li class="divider" role="separator"></li>
                        <asp:Repeater ID="rptIdiomas" runat="server">
                            <ItemTemplate>
                                <li>
                                    <asp:HyperLink ID="btnDisplayIdioma" runat="server" CommandName="DisplaIdioma" NavigateUrl='<%# "~/sec/workbook/Home.aspx?idRoot=" & Eval("idRoot") & "&idIdioma=" & Eval("idIdioma") %>' Text='<%# Eval("IdiomaNombre") %>' meta:resourcekey="btnDisplayIdiomaResource1"></asp:HyperLink></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
               <asp:Button ID="btnEditar" runat="server" Text="Editar"  CssClass="btn btn-primary btn-sm pull-right" meta:resourcekey="btnEditarResource1" />
                </div>
                 <h3 class="panel-title">
                         <asp:Label ID="lblTitulobox" runat="server"  ></asp:Label>
                     </h3>
            </div>
			
             <div class="panel-body">




                 



                <div class="alert alert-warning" id="lblNoIdioma" runat="server"  visible="false">
                  <span class="glyphicon glyphicon-exclamation-sign"></span><strong>&nbsp; <asp:Label ID="Label11" runat="server" Text="Alerta!" meta:resourcekey="Label11Resource1"></asp:Label>&nbsp;&nbsp; </strong> <asp:label id="lblMensajeBorrarinside" runat="server"  text="El contenido no esta en el idioma seleccionado" meta:resourcekey="lblMensajeBorrarinsideResource1"></asp:label>
                </div>
    

                <h4><asp:Label ID="Label1" runat="server" Text="Descripcion general" meta:resourcekey="Label1Resource1"></asp:Label></h4>
 
                    <asp:Label ID="labelfecha" runat="server" Text="Última Actualización: " Font-Size="11px" meta:resourcekey="labelfechaResource1" ></asp:Label>&nbsp;<asp:Label ID="lblUltimaActualizacion" runat="server"   Font-Size="11px" meta:resourcekey="lblUltimaActualizacionResource1" ></asp:Label><br />
                <asp:literal ID="lbldescripcion" runat="server" meta:resourcekey="lbldescripcionResource1" ></asp:literal>
                <div style="height:10px;"></div>

                <h4><asp:Label ID="Label2" runat="server" Text="Palabras claves" meta:resourcekey="Label2Resource1"></asp:Label></h4>
                <asp:literal ID="lbltags" runat="server" meta:resourcekey="lbltagsResource1" ></asp:literal>
                <div style="height:10px;"></div>

                <h4><asp:Label ID="Label3" runat="server" Text="Autor" meta:resourcekey="Label3Resource1"></asp:Label></h4>
                <asp:Label ID="lblautor" runat="server" meta:resourcekey="lblautorResource1" ></asp:Label>
                <div style="height:10px;"></div>

                <h4><asp:Label ID="Label4" runat="server" Text="Biblioteca" meta:resourcekey="Label4Resource1"></asp:Label></h4>
                <asp:literal ID="lblbiblioteca" runat="server" meta:resourcekey="lblbibliotecaResource1" ></asp:literal>
                <div style="height:10px;"></div>

                <h4><asp:Label ID="Label5" runat="server" Text="Sugerencias para el instructor" meta:resourcekey="Label5Resource1"></asp:Label></h4>
                <asp:literal ID="lblparainstructor" runat="server" meta:resourcekey="lblparainstructorResource1" ></asp:literal>
                <div style="height:10px;"></div>

                <h4><asp:Label ID="Label6" runat="server" Text="Convenios y derechos de autor" meta:resourcekey="Label6Resource1"></asp:Label></h4>
                <asp:literal ID="lblConvenios" runat="server" meta:resourcekey="lblConveniosResource1" ></asp:literal>
                <div style="height:10px;"></div>

                <h4><asp:Label ID="Label7" runat="server" Text="Archivo de certificación" meta:resourcekey="Label7Resource1"></asp:Label></h4>
                <asp:HyperLink ID="lnkcertificacion" runat="server" Target="_blank" meta:resourcekey="lnkcertificacionResource1">[lnkcertificacion]</asp:HyperLink>


                <div style="height:10px;"></div>

                <h4><asp:Label ID="Label8" runat="server" Text="Idioma default" meta:resourcekey="Label8Resource1"></asp:Label></h4>
                <asp:literal ID="lblIdioma" runat="server" meta:resourcekey="lblIdiomaResource1" ></asp:literal>
                <div style="height:10px;"></div>



                <div style="height:40px;"></div>




            </div>

        </div>

    </div>
    <div class="col-xs-3"><uc3:DisplayProgress ID="DisplayProgress1" runat="server" />
        
        <div class="panel">
			
             <div class="panel-body">
     <uc1:Menu ID="Menu1" runat="server" />
                 </div>
            </div>



        
        
    </div>
</div>








</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPanelMenu">
    <uc2:MenuGeneral ID="MenuGeneral1" runat="server" />
</asp:Content>









