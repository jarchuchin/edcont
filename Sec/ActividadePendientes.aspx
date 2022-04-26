<%@ Page Title="" Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="ActividadePendientes.aspx.vb" Inherits="Sec_ActividadePendientes" %>

<%@ Register src="Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc1" %>
<%@ Register src="Workbook/Controles/MyWorkBooks.ascx" tagname="MyWorkBooks" tagprefix="uc2" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>



<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lbltitulo" runat="server" Text="Actividades pendientes"></asp:Label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelBreadcrumb" Runat="Server">


<ol class="breadcrumb" >
  <li><asp:HyperLink ID="HyperLink2" runat="server"  Text="Inicio" NavigateUrl="~/sec/home.aspx" ></asp:HyperLink></li>
  <li class="active">
      <asp:Label ID="Label1" runat="server" Text="Actividades pendientes" ></asp:Label></li>
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
	<div class="col-sm-6 col-lg-3"  id="divCursosComoDocente" runat="server">
					
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
				<p class="text-muted mar-no"><asp:HyperLink ID="HyperLink8" runat="server" CssClass="text-muted"  NavigateUrl="~/Sec/defaultdocente.aspx">Cursos activos como docente</asp:HyperLink></p>
			</div>
		</div>
		<!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
					
	</div>
</div>
<!--===================================================-->
<!--End Tiles - Bright Version-->



    <div class="row">
	<div class="col-xs-12">
    
               <div class="panel">
                <div class="panel-heading">
                        <h3 class="panel-title"><asp:Label ID="lblCalendario" runat="server" Text="Actividades pendientes"></asp:Label> </h3>
                </div>
                <div class="panel-body">
                      <style>

              .table tbody tr td {

                  background-color:transparent;
              }

              .table.table-striped tbody tr td {

                   background-color:transparent !important;
              }


              .table.table-striped tbody tr:nth-child(2n+1) td {
                     background-color:transparent !important;

              }
          </style>
    
                           
                      <%--  <div style=" text-align:  left; ">
                            <asp:LinkButton ID="lnkEnviarCorreo1" runat="server" CssClass="btn-link">Enviar correo</asp:LinkButton>
                       </div>--%>
                          <div style="height:3px;"></div>
                       <asp:GridView ID="gvListaAlumnos" runat="server" AllowSorting="True"   CssClass="table table-hover table-striped"
                               DataKeyNames="idActividadSalonVirtual" AutoGenerateColumns="False" Width="100%" 
                               GridLines="None">
                           <columns>
                               <asp:TemplateField >
                                    <ItemTemplate >
                                        <asp:Label ID="lblNumero" runat="server" Text='<%# numero %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10px" />
                                    <ItemStyle HorizontalAlign="Center" Width="10px" />
                                </asp:TemplateField>
                                
                        
                          <%--    <asp:boundfield DataField="fecha" HeaderText="Fecha agendada" 
                                   HtmlEncode="False" SortExpression="Fecha" DataFormatString="{0:dd/MMM/yyyy}"><HeaderStyle HorizontalAlign="Center" CssClass="text-center" />
                                    <ItemStyle HorizontalAlign="Center"  Width="140px" CssClass="text-center" /></asp:boundfield>--%>
                          

                                 <asp:TemplateField HeaderText="Actividad"  SortExpression="Actividad">
                                    <ItemTemplate >
                                            <asp:Label ID="lblFechaA" runat="server" Text='<%# Format(Eval("fecha"), "dd/MM/yyyy") %>' ></asp:Label>
                                    </ItemTemplate>
                                     <HeaderStyle  CssClass="text-center" Width="140px"  />
                                    <ItemStyle  CssClass="text-center"   />
                                 </asp:TemplateField> 


                                   
                                  <asp:TemplateField HeaderText="Actividad"  SortExpression="Actividad">
                                    <ItemTemplate >
                                           <asp:HyperLink ID="lnknombre" runat="server" 
                                            NavigateUrl='<%# getLiga(Eval("idClasificacionItem"), Eval("idSalonVirtual"), Eval("tipodeActividad")) %>' 
                                             CssClass="btn-link"
                                             
                                            Text='<%# eval("Actividad") %>'></asp:HyperLink>
                                    </ItemTemplate>
                                     <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left"  />
                                 </asp:TemplateField> 
                                
                              

                              
                           
                                 
                             
                              
                               
                               
                               
                               
                                <asp:boundfield DataField="NombreSalon" HeaderText="Nombre del curso" 
                                   HtmlEncode="False" SortExpression="NombreSalon"><HeaderStyle HorizontalAlign="left" />
                                    <ItemStyle HorizontalAlign="left"  /></asp:boundfield>
                              
                                   
                           </columns>
                           
                         
                       </asp:GridView>
                     
                       
                       <asp:Label ID="labelCursosComoDocente" runat="server" Text="Cursos como docente" Visible="false"></asp:Label>
    <asp:Label ID="labelCursosComoAlumno" runat="server" Text="Cursos como alumno"  Visible="false"></asp:Label>

                </div>

                </div>

     </div>
</div>

    
      

         
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">


  <uc1:MenuGeneral ID="MenuGeneral1" runat="server" />





</asp:Content>

