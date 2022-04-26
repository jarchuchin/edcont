<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="TareasRecibidas.aspx.vb" Inherits="Sec_SalonVirtual_TareasRecibidas" title="Actividades enviadas por los alumnos para ser calificadas" %>

<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>



<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register src="Controles/displayApuntes.ascx" tagname="displayApuntes" tagprefix="uc2" %>

<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>


<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server"  Text="Tareas recibidas" ></asp:Label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/default.aspx" ></asp:HyperLink></li>
           <li><asp:HyperLink ID="lnkCurso" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/Sa/default.aspx" ></asp:HyperLink></li>
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Tareas recibidas" ></asp:Label></li>
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
                        <h3 class="panel-title"><asp:Label ID="Label1" runat="server" Text="Actividades enviadas por alumnos"></asp:Label></h3>
                </div>
                <div class="panel-body">

      <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <div align="left" > <asp:Image ID="Image1" runat="server"  ImageUrl ="~/Images/indicator.gif" /><asp:Label ID="lbltexto" runat="server"   Text="Actualizando datos..." ></asp:Label></div>
                    </ProgressTemplate>
       </asp:UpdateProgress>
       <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional" >
               <ContentTemplate>
                
                
                       <asp:GridView ID="gvActividades" runat="server" AllowSorting="True"  DataKeyNames="idRespuesta"
                           AutoGenerateColumns="False" Width="100%" GridLines="None" CssClass="table table-striped table-hover">
                           
                           <columns>
                                <asp:hyperlinkfield DataNavigateUrlFields="idRespuesta, idSalonVirtual" 
                                   DataNavigateUrlFormatString="CalificarRespuesta.aspx?idR={0}&idSalonVirtual={1}&pag=next" 
                                   Text="Evaluar"  ControlStyle-CssClass="btn btn-success btn-sm" >
                               <headerstyle width="70px" />
                               <itemstyle horizontalalign="center" />
                               </asp:hyperlinkfield>
                     

                               <asp:TemplateField HeaderText="Fecha" SortExpression="FechaEnvio">
                                   <ItemTemplate>
                                       <asp:Label ID="labelFecha" runat="server" Text='<%# getFecha(Eval("FechaEnvio")) %>' Font-Bold="true"></asp:Label>
                                   </ItemTemplate>
                                       <HeaderStyle Width="150px" /> 
                                <ItemStyle HorizontalAlign="Left" />
                               </asp:TemplateField>
                               
                               <asp:boundfield DataField="nombrecompleto" HeaderText="Alumno" 
                                   HtmlEncode="False" SortExpression="nombrecompleto"></asp:boundfield>
                               <asp:boundfield DataField="tituloActividad" HeaderText="Actividad" 
                                   HtmlEncode="False" SortExpression="tituloActividad"></asp:boundfield>
                            
                           </columns>
                          
                       </asp:GridView>
                

        </ContentTemplate>
        </asp:UpdatePanel>
        
             </div>
                </div>
            </div>


          

          </div>



    

        <asp:Label ID="labelCursosComoDocente" runat="server" Text="Cursos como docente" Visible="false"></asp:Label>
    <asp:Label ID="labelCursosComoAlumno" runat="server" Text="Label"  Visible="false"></asp:Label>
</asp:Content>

