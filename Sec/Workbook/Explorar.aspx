<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="Explorar.aspx.vb" Inherits="Sec_Workbook_Explorar" title="Explorar contenidos" meta:resourcekey="PageResource1" uiculture="auto" Culture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register src="Controles/Menu.ascx" tagname="Menu" tagprefix="uc5" %>
<%@ Register src="Controles/Folders.ascx" tagname="Folders" tagprefix="uc1" %>
<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc2" %>

<%@ Register src="Controles/DisplayExplorarContenido.ascx" tagname="DisplayExplorarContenido" tagprefix="uc3" %>



<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblTitulo" runat="server" meta:resourcekey="lblTituloResource1">titulo del libro</asp:Label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>


<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPanelMenu">
    <uc2:MenuGeneral ID="MenuGeneral1" runat="server" />
</asp:Content>



<asp:Content ID="contentBreadcrumb" runat="server" contentplaceholderid="ContentPanelBreadcrumb">

<ol class="breadcrumb" >
  <li><asp:HyperLink ID="HyperLink3" runat="server"  Text="Inicio" NavigateUrl="~/sec/home.aspx" meta:resourcekey="HyperLink3Resource1"></asp:HyperLink></li>
     <li><asp:HyperLink ID="HyperLink2" runat="server"  Text="Libros de trabajo" NavigateUrl="~/sec/Libros.aspx" meta:resourcekey="HyperLink2Resource1"></asp:HyperLink></li>
    <li><asp:HyperLink ID="lnkTitulo" runat="server" meta:resourcekey="lnkTituloResource1">[lnkTitulo]</asp:HyperLink></li>
  <li class="active"><asp:Label ID="lbltit" runat="server" Text="Explorar contenido" meta:resourcekey="lbltitResource1" ></asp:Label></li>
</ol>


</asp:Content>



<asp:Content ID="contentCentral" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">




    <div class="row">
	<div class="col-xs-9">

    
	    <div class="panel">


			<div class="panel-heading">

                <div class="panel-control">
                     <asp:HyperLink ID="ibNuevoFolder" runat="server" ImageUrl="~/Images/iconsDiamante/iconFolder.jpg" ImageWidth="35px"  ToolTip="Nueva unidad" meta:resourcekey="ibNuevoFolderResource1" />  
                </div>
                  

                <div  ID="PanelIcons" runat="server" class="panel-control">

                  


                       <asp:HyperLink ID="ibLectura" runat="server" ImageUrl="~/Images/iconsDiamante/iconEditarTexto.jpg"  ImageWidth="35px"  ToolTip="Nuevo texto" meta:resourcekey="ibLecturaResource1"  />
  
                       <asp:HyperLink ID="ibArchivo" runat="server"  ImageUrl="~/Images/iconsDiamante/iconArchivoUpload.jpg"  ImageWidth="35px" ToolTip="Nuevo archivo" meta:resourcekey="ibArchivoResource1"    />
   
                       <asp:HyperLink ID="ibAticulate" runat="server"  ImageUrl="~/Images/iconsDiamante/iconArticulate.jpg"  ImageWidth="35px" ToolTip="Nuevo archivo Articulate" meta:resourcekey="ibAticulateResource1"    />
   
  
                       <asp:HyperLink ID="ibActividad" runat="server"  ImageUrl="~/Images/iconsDiamante/iconActividad.jpg"  ImageWidth="35px"  ToolTip="Nueva actividad" meta:resourcekey="ibActividadResource1"  />
    
  
                       <asp:HyperLink ID="ibExamen" runat="server"  ImageUrl="~/Images/iconsDiamante/iconExamen.jpg"  ImageWidth="35px"  ToolTip="Nuevo examen" meta:resourcekey="ibExamenResource1"  />
    
  
                      <asp:HyperLink ID="ibForo" runat="server" CausesValidation="False" ImageUrl="~/Images/iconsDiamante/iconForos.jpg"  ImageWidth="35px"  ToolTip="Agregar foro" meta:resourcekey="ibForoResource1"  />

 

                        <asp:HyperLink ID="ibBuscar" runat="server" ImageUrl="~/Images/iconsDiamante/iconBuscar.jpg" ImageWidth="35px"  ToolTip="Buscar contenido y agregarlo" meta:resourcekey="ibBuscarResource1"    />

                </div>
                <h3 class="panel-title">
                         <asp:Label ID="lblTitulobox" runat="server"  >asdfas</asp:Label>
                     </h3>
			</div>
            <div class="panel-body">




<ul class="nav nav-tabs" >
  <li class="active"><a data-toggle="tab" href="#contenidos"><asp:Literal ID="Literal1" runat="server" Text="Vista directorios" meta:resourcekey="Literal1Resource1"></asp:Literal></a></li>
 <%-- <li><a data-toggle="tab" href="#resumen"><asp:Literal ID="Literal2" runat="server" Text="Vista concentrada" meta:resourcekey="Literal2Resource1"></asp:Literal></a></li>
  <li><a data-toggle="tab" href="#detalles"> <asp:Literal ID="Literal3" runat="server" Text="Vista detalles" meta:resourcekey="Literal3Resource1"></asp:Literal></a></li>--%>
</ul>

<div class="tab-content">
  <div id="contenidos" class="tab-pane fade in active">
   <uc3:DisplayExplorarContenido ID="DisplayExplorarContenido1" runat="server" />
  </div>
 
  


                </div>
        </div>

  
	</div>

        </div>


        <div class="col-xs-3">
           <div class="panel">
               <div class="panel-body">
                 <uc5:menu ID="Menu1" runat="server" />
               </div>
            </div>
        </div>


      
    </div>
    


</asp:Content>
