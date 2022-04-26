<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="verRespuestasCompas.aspx.vb" Inherits="Sec_SalonVirtual_verRespuestasCompas" title="Lista de respuestas de mis compañeros" %>

<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>

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
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Cursos como docente"  NavigateUrl="~/sec/default.aspx" ></asp:HyperLink></li>
         <li><asp:HyperLink ID="lnkCurso" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/Sa/default.aspx" ></asp:HyperLink></li>
          <li><asp:HyperLink ID="lnkUnidad" runat="server"  Text="Unidad"  ></asp:HyperLink></li>
          <li><asp:HyperLink ID="lnkActividad" runat="server"  Text="Actividad"  ></asp:HyperLink></li>
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Actividades enviadas por alumnos" ></asp:Label></li>
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
                        <h3 class="panel-title"> 	<asp:Label ID="lblssActividad"  runat="server"   Text="Actividad: " ></asp:Label>	<asp:Label ID="lblActividad"  runat="server"   Text="Actividades enviadas por alumnos" ></asp:Label></h3>
                </div>
                <div class="panel-body">
 
      <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <div align="left" > <asp:Image ID="Image1" runat="server"  ImageUrl ="~/Images/indicator.gif" /><asp:Label ID="lbltexto" runat="server"   Text="Actualizando datos..." ></asp:Label></div>
                    </ProgressTemplate>
       </asp:UpdateProgress>
       <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional" >
               <ContentTemplate>
               
                           
                           <br />
                           
                       <asp:GridView ID="gvCalificaciones" runat="server" AllowSorting="True"   gridlines="none" DataKeyNames="idUserProfile" CssClass="table table-hover table-striped"
                           AutoGenerateColumns="False" Width="100%">
                           <RowStyle  HorizontalAlign="Center"/>
                           
                           <columns>
                            
                                  <asp:templatefield HeaderText="">
                                       <itemtemplate>
                                           <asp:HyperLink ID="HyperLinkddd1" runat="server" NavigateUrl='<%# getRespuesta(cint(eval("idUserProfile"))) %>' CssClass="btn-link" >Ver</asp:HyperLink>
                                       </itemtemplate>
                                       <headerstyle horizontalalign="Center" width="70px" />
                                       <itemstyle horizontalalign="Center" />
                                </asp:templatefield>
                                <asp:boundfield DataField="Apellidos" HeaderText="Apellidos" 
                                   HtmlEncode="False" SortExpression="Apellidos">
                                <itemstyle horizontalalign="Left" />   
                                </asp:boundfield>
                               <asp:boundfield DataField="Nombre" HeaderText="Nombre" 
                                   HtmlEncode="False" SortExpression="Nombre">
                                <itemstyle horizontalalign="Left" />
                                </asp:boundfield>
                                   <asp:templatefield HeaderText="Enviado">
                                       <headerstyle horizontalalign="Center" width="50px" />
                                       <itemstyle horizontalalign="Center" width="50px"  />
                                       <itemtemplate>
                                           <asp:Image ID="Image2"  ImageUrl='<%# "~/images/" & getEnviada(cint(eval("idUserProfile"))) %>' runat="server" />
                                       </itemtemplate>
                                </asp:templatefield>
                                    <asp:templatefield HeaderText="Enviada">
                                       <itemtemplate>
                                           <asp:Label  ID="Labedsfal1" runat="server" Text='<%# getFecha(cint(eval("idUserProfile"))) %>' ></asp:Label>
                                       </itemtemplate>
                                       <headerstyle horizontalalign="Center" width="80px" />
                                       <itemstyle horizontalalign="Center" />
                                </asp:templatefield>
                                    <asp:templatefield HeaderText="Calificación">
                                       <itemtemplate>
                                           <asp:Label  ID="Label1" runat="server" Text='<%# getCalificacion(cint(eval("idUserProfile"))) %>' ></asp:Label>
                                       </itemtemplate>
                                       <headerstyle horizontalalign="Center" width="90px" />
                                       <itemstyle horizontalalign="Center" />
                                </asp:templatefield>
                           </columns>
                           <headerstyle font-bold="True" forecolor="Black" HorizontalAlign="Left" />
                       </asp:GridView>
                        <br />               
                           <table style="width: 100%">
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td style="width: 230px; text-align:center">
                                        <asp:Label ID="Label2" runat="server" CssClass="Mediana" Font-Bold="true" 
                                            Text="Calificación promedio de esta actividad:"></asp:Label>
                                    </td>
                                    <td style="width: 90px; text-align:center">
                                        <asp:Label ID="lblpromedio" runat="server" CssClass="Mediana" Font-Bold="true"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                       

        </ContentTemplate>
        </asp:UpdatePanel>

             </div>
                </div>
            </div>


          

          </div>



    

        <asp:Label ID="labelCursosComoDocente" runat="server" Text="Cursos como docente" Visible="false"></asp:Label>
        <asp:Label ID="labelCursosComoAlumno" runat="server" Text="Cursos como alumno"  Visible="false"></asp:Label>
</asp:Content>


