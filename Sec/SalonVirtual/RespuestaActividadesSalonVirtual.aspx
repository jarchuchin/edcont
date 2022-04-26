<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="RespuestaActividadesSalonVirtual.aspx.vb" Inherits="Sec_SalonVirtual_RespuestaActividadesSalonVirutal" title="Respuestas enviadas" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>



<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server"  Text="Actividades enviadas por alumnos" ></asp:Label> </h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/default.aspx" ></asp:HyperLink></li>
           <li><asp:HyperLink ID="lnkCurso" runat="server"  Text="Curso nombre"  NavigateUrl="~/sec/Sa/default.aspx" ></asp:HyperLink></li>
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Calificaciones de respuesta" ></asp:Label></li>
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
                     <%--  <div class="panel-control">
                            <div class="pull-right">
                              <asp:Button ID="btnNuevo" runat="server" Text="Nueva evaluación" CssClass="btn btn-primary btn-sm" />
                            </div>
                        </div>--%>

                        <h3 class="panel-title"><asp:Label ID="lblActividad" runat="server" ></asp:Label></h3>
                </div>
                <div class="panel-body">
 
      <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <div > <asp:Image ID="Image1" runat="server"  ImageUrl ="~/Images/indicator.gif" /><asp:Label ID="lbltexto" runat="server"   Text="Actualizando datos..." ></asp:Label></div>
                    </ProgressTemplate>
       </asp:UpdateProgress>
       <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional" >
               <ContentTemplate>
               
                           <asp:Label ID="Label3"  runat="server" Text="Respuestas enviadas al: "></asp:Label>
                           <asp:Label ID="lblFechaActual"  runat="server" Text=""></asp:Label>
                           <br /><br />
                           
                       <asp:GridView ID="gvAsistenciaFechas" runat="server" AllowSorting="True"  DataKeyNames="idUserProfile" CssClass="table table-hover table-striped"
                           AutoGenerateColumns="False" Width="100%" GridLines="None">
                           <RowStyle  HorizontalAlign="Center"/>
                           
                           <columns>
                             <asp:templatefield >
                                       <itemtemplate>
                                           <asp:HyperLink CssClass="btn btn-success btn-sm" ID="HyperLink1" runat="server" NavigateUrl='<%# getRespuesta(cint(eval("idUserProfile"))) %>' >Ver actividad</asp:HyperLink>
                                       </itemtemplate>
                                       <headerstyle horizontalalign="Center" width="70px" />
                                       <itemstyle horizontalalign="Center" />
                                </asp:templatefield>
                                <asp:hyperlinkfield DataNavigateUrlFields="idSalonVirtual, idUserProfile" 
                                   DataNavigateUrlFormatString="EvaluacionPorAlumno.aspx?idSalonVirtual={0}&idUserProfile={1}"  
                                   Text="Ver evaluación" ControlStyle-CssClass="btn btn-sm btn-default">
                          
                               <headerstyle width="70px" />
                               <itemstyle horizontalalign="Center"  />
                               </asp:hyperlinkfield>
                               
                                <asp:boundfield DataField="claveAux1" HeaderText="Matrícula" 
                                   HtmlEncode="False" SortExpression="claveAux1">
                                <itemstyle horizontalalign="Left" />   
                                <HeaderStyle HorizontalAlign="Left" Width="70px" />
                                </asp:boundfield>

                                <asp:templatefield HeaderText="Nombre del alumno" >
                                       <itemtemplate>

                                            <asp:Label ID="lblnombrealumno" runat="server" Text='<%# Eval("Apellidos") & " " & Eval("Nombre") %>'></asp:Label>
                                        </itemtemplate>
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:templatefield>
                             <%--  <asp:boundfield DataField="Apellidos" HeaderText="Apellidos" 
                                   HtmlEncode="False" SortExpression="Apellidos">
                                <itemstyle horizontalalign="Left" />   
                                <HeaderStyle HorizontalAlign="Left" />
                                </asp:boundfield>
                               <asp:boundfield DataField="Nombre" HeaderText="Nombre" 
                                   HtmlEncode="False" SortExpression="Nombre">
                                <itemstyle horizontalalign="Left" />
                                <HeaderStyle HorizontalAlign="Left" />
                                </asp:boundfield>--%>
                                   <asp:templatefield HeaderText="Enviado">
                                       <headerstyle horizontalalign="Center" width="50px" />
                                       <itemstyle horizontalalign="Center" width="50px"  />
                                       <itemtemplate>
                                           <asp:Image ID="Image2"  ImageUrl='<%# "~/images/" & getEnviada(cint(eval("idUserProfile"))) %>' runat="server" />
                                       </itemtemplate>
                                </asp:templatefield>
                                    <asp:templatefield HeaderText="Fecha">
                                       <itemtemplate>
                                           <asp:Label  ID="Label1" runat="server" Text='<%# getFecha(cint(eval("idUserProfile"))) %>' ></asp:Label>
                                       </itemtemplate>
                                       <headerstyle horizontalalign="Center" width="70px" />
                                       <itemstyle horizontalalign="Center" />
                                </asp:templatefield>
                               
                                
                                  <asp:TemplateField HeaderText="Calificación">
                                    <ItemTemplate  >
                                         <asp:TextBox ID="txtClave" Width="30px" Text='<%# eval("idUserProfile") %>' runat="server" Visible="false" CssClass="Chica"></asp:TextBox>
                                        <asp:TextBox ID="txtCalificacion" Width="30px" Text='<%# GetCalificacion(cint(eval("idUserProfile"))) %>' runat="server" CssClass="Chica"></asp:TextBox>
                                        <asp:RangeValidator ID="RangeValidator1" runat="server"  Text="*" ControlToValidate="txtCalificacion" MaximumValue="10" MinimumValue="0" ForeColor="Red" Type="Double"></asp:RangeValidator>
                                        <asp:ImageButton ID="imgAsignarCalificacion" runat="server" ImageUrl="~/images/MiniIconEvalua.jpg" Visible='<%# esExamen %>' OnClick="imgAsignarCalificacion_Click" CommandArgument='<%# Eval("idUserProfile")%>' CausesValidation="false"  />
                                         <cc1:ConfirmButtonExtender ID="imgAsignarCalificacion_ConfirmButtonExtender" runat="server" ConfirmText="¿Deseas asignar calificación en forma directa a este alumno?" Enabled="True" TargetControlID="imgAsignarCalificacion">
                                         </cc1:ConfirmButtonExtender>
                                    </ItemTemplate>
                                    <HeaderStyle Width="50px"  />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                
                           </columns>
                         
                       </asp:GridView>   

                
                     
                           <table style="width: 100%">
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td style="width: 230px; text-align:center">
                                        <asp:Label ID="Label2" runat="server" CssClass="Mediana" Font-Bold="true" 
                                            Text="Calificación promedio de esta actividad:"></asp:Label>
                                    </td>
                                    <td style="width: 100px; text-align:center">
                                        <asp:Label ID="lblpromedio" runat="server" CssClass="Mediana" Font-Bold="true"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                       


                          <div  style="text-align:right; padding-right: 20px; padding-top:10px;">
                           <asp:Button ID="btngrabar" runat="server" Text="Calificar" CssClass="btn btn-primary " />
                               <cc1:ConfirmButtonExtender ID="btngrabar_ConfirmButtonExtender" runat="server" 
                                   ConfirmText="El sistema generará respuestas para los alumnos. Las calificaciones deben ser evaluadas sobre 10. ¿Desea enviar calificaciones?" Enabled="True" 
                                   TargetControlID="btngrabar">
                       </cc1:ConfirmButtonExtender>
                    </div>



                    
        </ContentTemplate>
        </asp:UpdatePanel>


  </div>

             </div>
        </div>

    </div>


</asp:Content>

