<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="AsistenciaSalonVirtualPase.aspx.vb" Inherits="Sec_SalonVirtual_AsistenciaSalonVirtualPase" title="Lista de asistencia" %>

<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>

<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server"  Text="Control de asistencia" ></asp:Label> </h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/default.aspx" ></asp:HyperLink></li>
           <li><asp:HyperLink ID="lnkCurso" runat="server"  Text="Curso nombre"  NavigateUrl="~/sec/Sa/default.aspx" ></asp:HyperLink></li>
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Registro de asistencia" ></asp:Label></li>
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

                        <h3 class="panel-title"><asp:Label ID="lblActividad" runat="server" text="Registro de asistencia"></asp:Label> --  <asp:Label ID="lblFechaActual"  runat="server" Text=""></asp:Label></h3>
                </div>
                <div class="panel-body">
  
 
      <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <div > <asp:Image ID="Image1" runat="server"  ImageUrl ="~/Images/indicator.gif" /><asp:Label ID="lbltexto" runat="server"   Text="Actualizando datos..." ></asp:Label></div>
                    </ProgressTemplate>
       </asp:UpdateProgress>
       <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional" >
               <ContentTemplate>

<div style=" text-align:right">
    <asp:Button ID="btngrabar1" runat="server" Text="Enviar lista" CssClass="btn btn-primary btn-sm" /></div>
 
                          


                       <asp:GridView ID="gvAsistenciaFechas" runat="server" AllowSorting="True"  DataKeyNames="idUserProfile" CssClass="table table-hover table-striped"
                           AutoGenerateColumns="False" Width="100%" GridLines="None">
                      
                           <columns>
                               
                                <asp:boundfield DataField="claveAux1" HeaderText="Matrícula" 
                                   HtmlEncode="False" SortExpression="claveAux1"></asp:boundfield>
                               <asp:boundfield DataField="Apellidos" HeaderText="Apellidos" 
                                   HtmlEncode="False" SortExpression="Apellidos"></asp:boundfield>
                               <asp:boundfield DataField="Nombre" HeaderText="Nombre" 
                                   HtmlEncode="False" SortExpression="Nombre"></asp:boundfield>
                                   
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:RadioButtonList ID="rdbList" runat="server"   RepeatDirection="Horizontal">
                                            <asp:ListItem Value="Asistencia" >Asistencia</asp:ListItem>
                                            <asp:ListItem Value="Tardanza">Tardanza</asp:ListItem>
                                            <asp:ListItem Value="Ausencia">Ausencia</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </ItemTemplate>
                                    <HeaderStyle Width="250px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                           </columns>
                         
                       </asp:GridView>
                   
                   <div style=" text-align:right">
    <asp:Button ID="btngrabar2" runat="server" Text="Enviar lista" CssClass="btn btn-primary btn-sm" /></div>
</ContentTemplate></asp:UpdatePanel>


                    
  </div>

             </div>
        </div>

    </div>

        <asp:Label ID="labelCursosComoDocente" runat="server" Text="Cursos como docente" Visible="false"></asp:Label>
    <asp:Label ID="labelCursosComoAlumno" runat="server" Text="Cursos como alumno"  Visible="false"></asp:Label>




</asp:Content>

