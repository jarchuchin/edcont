<%@ Page Title="" Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="ActividadesAgendadas.aspx.vb" Inherits="Sec_SalonVirtual_ActividadesAgendadas" %>


<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>


<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server"  Text="Actividades agendadas" ></asp:Label> </h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/default.aspx" ></asp:HyperLink></li>
           <li><asp:HyperLink ID="lnkCurso" runat="server"  Text="Curso nombre"  NavigateUrl="~/sec/Sa/default.aspx" ></asp:HyperLink></li>
           <li><asp:HyperLink ID="lnkCalendario" runat="server"  Text="Agenda"  NavigateUrl="~/sec/Sa/default.aspx" ></asp:HyperLink></li>

      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Actividades Agendads" ></asp:Label></li>
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
                        <h3 class="panel-title"><asp:Label ID="lblCalendario" runat="server" Text="Actividaes agendadas"></asp:Label> </h3>
                </div>
                <div class="panel-body">

    
                           
                      <%--  <div style=" text-align:  left; ">
                            <asp:LinkButton ID="lnkEnviarCorreo1" runat="server" CssClass="btn-link">Enviar correo</asp:LinkButton>
                       </div>--%>
                          <div style="height:3px;"></div>
                       <asp:GridView ID="gvListaAlumnos" runat="server" AllowSorting="True"   CssClass="table table-hover table-striped"
                               DataKeyNames="idUserProfile" AutoGenerateColumns="False" Width="100%" 
                               GridLines="None">
                           <columns>
                               <asp:TemplateField >
                                    <ItemTemplate >
                                        <asp:Label ID="lblNumero" runat="server" Text='<%# numero %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10px" />
                                    <ItemStyle HorizontalAlign="Center" Width="10px" />
                                </asp:TemplateField>
                                
                        
                              <asp:boundfield DataField="fecha" HeaderText="Fecha" 
                                   HtmlEncode="False" SortExpression="Fecha" DataFormatString="{0:dd/MMM/yyyy}"><HeaderStyle HorizontalAlign="Center" CssClass="text-center" />
                                    <ItemStyle HorizontalAlign="Center"  Width="120px" CssClass="text-center" /></asp:boundfield>
                          
                                   
                                  <asp:TemplateField HeaderText="Actividad" SortExpression="Actividad">
                                    <ItemTemplate >
                                           <asp:HyperLink ID="lnknombre" runat="server" 
                                            NavigateUrl='<%# getliga(Eval("idClasificacionItem"), Eval("idSalonVirtual"), Eval("idProc"), Eval("Procedencia")) %>' 
                                             CssClass="btn-link"
                                             
                                            Text='<%# eval("Actividad") %>'></asp:HyperLink>
                                    </ItemTemplate>
                                     <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left"  />
                                 </asp:TemplateField> 
                                
                              

                              
                           
                                 
                             
                              
                               
                               
                               
                               
                                <asp:boundfield DataField="NombreAlumno" HeaderText="Alumno" 
                                   HtmlEncode="False" SortExpression="Alumno"><HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center"  /></asp:boundfield>
                              
                                   
                                   
                           </columns>
                           
                         
                       </asp:GridView>
                     
                       
                       <asp:Label ID="labelCursosComoDocente" runat="server" Text="Cursos como docente" Visible="false"></asp:Label>
    <asp:Label ID="labelCursosComoAlumno" runat="server" Text="Cursos como alumno"  Visible="false"></asp:Label>

                </div>

                </div>

            </div>

        </div>

    



   

              
     

</asp:Content>

