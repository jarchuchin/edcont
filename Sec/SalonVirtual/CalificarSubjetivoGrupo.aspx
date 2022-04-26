<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="CalificarSubjetivoGrupo.aspx.vb" Inherits="Sec_SalonVirtual_CalificarSubjetivoGrupo" title="Calificar alumnos" %>

<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

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

                        <h3 class="panel-title"><asp:Label ID="lbltitulo" runat="server" ></asp:Label></h3>
                </div>
                <div class="panel-body">

      <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <div align="left" > <asp:Image ID="Image1" runat="server"  ImageUrl ="~/Images/indicator.gif" /><asp:Label ID="lbltexto" runat="server"   Text="Actualizando datos..." ></asp:Label></div>
                    </ProgressTemplate>
       </asp:UpdateProgress>
       <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional" >
               <ContentTemplate>
            
                       <asp:GridView ID="gvAsistenciaFechas" runat="server" AllowSorting="True"  DataKeyNames="idUserProfile"  CssClass="table table-hover table-striped"
                           AutoGenerateColumns="False" Width="100%" GridLines="None">
                           <rowstyle horizontalalign="Left" />
                           <columns>
                           
                               <asp:TemplateField>
                                    <ItemTemplate >
                                        <asp:Label ID="lblNumero"  Font-Bold="true" runat="server" Text='<%# numero %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="30px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                           
                               
                            <%--   <asp:boundfield DataField="Apellidos" HeaderText="Apellidos" 
                                   HtmlEncode="False" SortExpression="Apellidos">
                               <HeaderStyle HorizontalAlign="Left" />
                               </asp:boundfield>
                               <asp:boundfield DataField="Nombre" HeaderText="Nombre" 
                                   HtmlEncode="False" SortExpression="Nombre">
                               <HeaderStyle HorizontalAlign="Left" />
                               </asp:boundfield>
                                   --%>
                                   
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


                                
                                <asp:TemplateField HeaderText="Calificación">
                                    <ItemTemplate  >
                                         <asp:TextBox ID="txtClave" Width="30px" Text='<%# eval("idUserProfile") %>' runat="server" Visible="false" CssClass="Chica"></asp:TextBox>
                                        <asp:TextBox ID="txtCalificacion" Width="40px" Text='<%# GetCalificacion(cint(eval("idUserProfile"))) %>' runat="server" CssClass="Chica" style="text-align:right;"></asp:TextBox>
                                        <asp:RangeValidator ID="RangeValidator1" runat="server"  Text="*" ControlToValidate="txtCalificacion" MaximumValue="10" MinimumValue="0" Type="Double"></asp:RangeValidator>
                                    </ItemTemplate>
                                    <HeaderStyle Width="50px"  />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                
                                    
                                   
                                   
                           </columns>
                           <headerstyle font-bold="True" forecolor="Black" HorizontalAlign="Left" />
                       </asp:GridView>
                   <div style="height:20px;"></div>
                   <div  style="text-align:right">
                   <asp:Button ID="btngrabar" runat="server" Text="Calificar" CssClass="btn btn-success" />
                       <cc1:ConfirmButtonExtender ID="btngrabar_ConfirmButtonExtender" runat="server" 
                           ConfirmText="Las calificaciones deben ser evaluadas sobre 10 puntos, pudiendo usar hasta un decimal ¿Desea enviar calificaciones?" Enabled="True" 
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

