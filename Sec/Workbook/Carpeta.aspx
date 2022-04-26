<%@ Page Title="" Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="Carpeta.aspx.vb" Inherits="Sec_Workbook_Carpeta" meta:resourcekey="PageResource1" uiculture="auto" Culture="auto" %>


<%@ Register src="~/Sec/Workbook/Controles/displayComentariosVistaPrevia.ascx" tagname="displayComentarios" tagprefix="uc3" %>


<%@ Register src="Controles/MenuCarpeta.ascx" tagname="MenuCarpeta" tagprefix="uc4" %>


<%@ Register src="Controles/DisplayContenidoTipo.ascx" tagname="DisplayContenidoTipo" tagprefix="uc5" %>


<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc2" %>

<%@ Register src="Controles/Menu.ascx" tagname="Menu" tagprefix="uc1" %>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblTitulo" runat="server" meta:resourcekey="lblTituloResource1" ></asp:Label></h1>

       
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelBreadcrumb" Runat="Server">

    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkb1" runat="server" Text="Libro" meta:resourcekey="lnkb1Resource1" ></asp:HyperLink></li>
      <li><asp:HyperLink ID="lnkb2" runat="server"  Text="Explorar contenido" meta:resourcekey="lnkb2Resource1" ></asp:HyperLink></li>
<%--      <li><asp:HyperLink ID="lnkb3" runat="server"></asp:HyperLink></li>--%>
      <li class="active"><asp:Label ID="lbltit" runat="server" Text="Explorar contenido" meta:resourcekey="lbltitResource1" ></asp:Label></li>
    </ol>

</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">



     <uc2:MenuGeneral ID="MenuGeneral1" runat="server" />



</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
  

<div class="row">
	<div class="col-xs-8">

        <div class="panel">

                <div class="panel-heading">

                    

                    <div  ID="PanelIcons" runat="server" class="panel-control">
                           <asp:HyperLink ID="ibLectura" runat="server" ImageUrl="~/Images/iconsDiamante/iconEditarTexto.jpg"  ImageWidth="35px"  ToolTip="Nuevo texto" meta:resourcekey="ibLecturaResource1"  />
                           <asp:HyperLink ID="ibArchivo" runat="server"  ImageUrl="~/Images/iconsDiamante/iconArchivoUpload.jpg"  ImageWidth="35px" ToolTip="Nuevo archivo" meta:resourcekey="ibArchivoResource1"    />
                   <%--      <asp:HyperLink ID="ibArticulate" runat="server"  ImageUrl="~/Images/iconsDiamante/iconArticulate.jpg"  ImageWidth="35px" ToolTip="Nuevo archivo" meta:resourcekey="ibArticulateResource1"    />--%>
                           <asp:HyperLink ID="ibActividad" runat="server"  ImageUrl="~/Images/iconsDiamante/iconActividad.jpg"  ImageWidth="35px"  ToolTip="Nueva actividad" meta:resourcekey="ibActividadResource1"  />
                           <asp:HyperLink ID="ibExamen" runat="server"  ImageUrl="~/Images/iconsDiamante/iconExamen.jpg"  ImageWidth="35px"  ToolTip="Nuevo examen" meta:resourcekey="ibExamenResource1"  />
                          <asp:HyperLink ID="ibForo" runat="server" CausesValidation="False" ImageUrl="~/Images/iconsDiamante/iconForos.jpg"  ImageWidth="35px"  ToolTip="Agregar foro" meta:resourcekey="ibForoResource1"  />
                            <asp:HyperLink ID="ibBuscar" runat="server" ImageUrl="~/Images/iconsDiamante/iconBuscar.jpg" ImageWidth="35px"  ToolTip="Buscar contenido y agregarlo" meta:resourcekey="ibBuscarResource1"    />

                    </div>
                     <h3 class="panel-title">
                         <asp:Label ID="lblTitulobox" runat="server"  ></asp:Label>
                     </h3>
                </div>
              <div class="panel-body">


                  

    
        <div class="pull-right">
            <asp:HyperLink ID="lnkEditarCarpeta" runat="server" Text="Editar"  CssClass="btn btn-primary  btn-sm" meta:resourcekey="lnkEditarCarpetaResource1"></asp:HyperLink>
        </div>
    


                  
<asp:Image id="imagenClasificacion1" runat="server" Height="150px" meta:resourcekey="imagenClasificacion1Resource1" />


	






		

<asp:Panel ID="panelImagen2" runat="server" Visible="False" >
		<asp:Image id="imagenClasificacion2" runat="server" />
</asp:Panel>
	    



	<h4><asp:Label ID="Label1" runat="server" Text="Planteamiento breve" meta:resourcekey="Label1Resource1"></asp:Label></h4>
    <asp:Literal ID="literalPlanteamientoBreve" runat="server" meta:resourcekey="literalPlanteamientoBreveResource1"></asp:Literal>
    <div style="height:10px;"></div>

    <h4><asp:Label ID="Label3" runat="server" Text="Examen de diagnóstico" meta:resourcekey="Label3Resource1"></asp:Label></h4>
    <asp:HyperLink ID="lnkExamenDiagnostico" runat="server" Visible="False" meta:resourcekey="lnkExamenDiagnosticoResource1">[lnkExamenDiagnostico]</asp:HyperLink>
    <div style="height:10px;"></div>

    <h4><asp:Label ID="Label2" runat="server" Text="Descripcion" meta:resourcekey="Label2Resource1"></asp:Label></h4>
	<asp:Literal ID="literalTexto" runat="server" meta:resourcekey="literalTextoResource1"></asp:Literal>
    <div style="height:10px;"></div>

     <h4><asp:Label ID="Label10" runat="server" Text="Día de presentación" meta:resourcekey="Label10Resource1"></asp:Label></h4>
	<asp:Literal ID="literalDia" runat="server" meta:resourcekey="literalDiaResource1"></asp:Literal>
    <div style="height:10px;"></div>



              </div>

        </div>


          <div class="panel">

                <div class="panel-heading">
                     <div class="panel-control">
                        <asp:HyperLink ID="lnkAgregarObjetivo" runat="server" Text="Agregar objetivo"  CssClass="btn  btn-success btn-sm" meta:resourcekey="lnkAgregarObjetivoResource1"></asp:HyperLink>
                      </div>
                    <h3 class="panel-title"><asp:Label ID="Label5" runat="server" Text="OBJETIVOS y COMPETENCIAS" meta:resourcekey="Label5Resource1"></asp:Label></h3>
                   
                </div>
              <div class="panel-body">
                  <asp:Repeater ID="rptObjetivos" runat="server">
      
                     <ItemTemplate>
            
                        <h4><asp:Label ID="Label4" runat="server" Text="Objetivo" ></asp:Label></h4>
                        <asp:Label ID="lblObjetivo" runat="server" Text='<%# getObjetivo(Eval("Objetivo"))%>' ></asp:Label>
                        <div style="height:10px;"></div>
                       <%-- <h4><asp:Label ID="Label6" runat="server" Text="De habilidad" meta:resourcekey="Label6Resource1"></asp:Label></h4>
                        <asp:Label ID="Label7" runat="server" Text='<%# getObjetivo(Eval("Habilidad")) %>' ></asp:Label>
                        <div style="height:10px;"></div>
                        <h4><asp:Label ID="Label8" runat="server" Text="De actitud" meta:resourcekey="Label8Resource1"></asp:Label></h4>
                        <asp:Label ID="Label9" runat="server" Text='<%# getObjetivo(Eval("aptitud")) %>' ></asp:Label>
                        <div style="height:10px;"></div>--%>



                    <div class="text-right">
                        <asp:HyperLink ID="lnkEditar" runat="server" CssClass="btn btn-primary btn-sm" Text="Editar" NavigateUrl='<%# "addObjetivo.aspx?idObjetivo=" & Eval("idObjetivo") & "&idRoot=" & Request("idRoot") & "&idClasificacion=" & Eval("idClasificacion") & "&idSalonVirtual=" & Request("idSalonVirtual") %>' meta:resourcekey="lnkEditarResource1"></asp:HyperLink>
                    </div>
                 
                     </ItemTemplate>
       
                </asp:Repeater>
              </div>
        </div>




       


    </div>

    <div class="col-xs-4">

        <div class="panel">
              <div class="panel-body">
              
                  <uc1:Menu ID="Menu1" runat="server" />
              </div>
        </div>

         <div class="panel">
             <div class="panel-body">
                 <uc5:DisplayContenidoTipo ID="DisplayContenidoTipo1" runat="server" />
                 <uc5:DisplayContenidoTipo ID="DisplayContenidoTipo2" runat="server" />
                 <uc5:DisplayContenidoTipo ID="DisplayContenidoTipo3" runat="server" />
                 <uc5:DisplayContenidoTipo ID="DisplayContenidoTipo4" runat="server" />
             </div>
         </div>


    </div>
</div>

   






 

<div style="height:5px;"></div>


    
    <hr class="small">

    <div class="row">
        <div class="col-md-10">
            <h4></h4>
        </div>
        <div class="col-md-2 text-right">
            
        </div>
    </div>
	


    



	


<%--	<div class="cajaSubseccionCentral" style="border:1px solid #999; background-color:#eeeeee; padding:3px; width:98%;">
		<h3>ÍNDICE DE LA SECCIÓN</h3>
		<uc1:IndiceClasificacion ID="IndiceClasificacion1" runat="server" />
	</div>--%>




		

 




</asp:Content>

