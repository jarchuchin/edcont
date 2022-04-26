<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="AsistenciaSalonVirtual.aspx.vb" Inherits="Sec_SalonVirtual_AsistenciaSalonVirtual" title="Asistencia" %>

<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

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
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Asistencia" ></asp:Label></li>
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
                     <div class="panel-control pull-right">
                           
                            

                        <asp:Button ID="btnNuevo" CssClass="btn btn-primary btn-sm" runat="server" Text="Crear fecha" />

                    </div>
                      

                        <h3 class="panel-title"><asp:Label ID="lblActividad" runat="server" text="Fechas de asistencia"></asp:Label></h3>
                </div>
                <div class="panel-body">
		
  
      <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <div align="left" > <asp:Image ID="Image1" runat="server"  ImageUrl ="~/Images/indicator.gif" /><asp:Label ID="lbltexto" runat="server"   Text="Actualizando datos..." ></asp:Label></div>
                    </ProgressTemplate>
       </asp:UpdateProgress>
       <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional" >
               <ContentTemplate>
                   <asp:Panel ID="PanelFecha" runat="server" Visible="False">
                  

                       <div class="form-inline">
                               <asp:Label ID="Label1" runat="server" Text="Ingresar fecha" Font-Bold="true"></asp:Label>
                          
                               &nbsp;&nbsp;<asp:TextBox ID="txtfecha" runat="server" CssClass="form-control" Width="130px" style="text-align:center"></asp:TextBox>
                               <cc1:CalendarExtender ID="txtfecha_CalendarExtender" runat="server" BehaviorID="txtfecha_CalendarExtender" TargetControlID="txtfecha">
                               </cc1:CalendarExtender>
                               &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                   ControlToValidate="txtFecha" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                   ControlToValidate="txtFecha" Display="Dynamic" 
                                   ValidationExpression="\d{1,2}\/\d{1,2}/\d{4}" ForeColor="Red">*</asp:RegularExpressionValidator>
                               <asp:CustomValidator ID="gvAsistencias" runat="server" 
                                   ControlToValidate="txtFecha" Display="Dynamic" ForeColor="Red">*</asp:CustomValidator>

                            &nbsp;&nbsp;


                           <asp:Button CssClass="btn btn-success btn-sm" ID="btnGrabar" runat="server" Text="Grabar"  />
                               &nbsp;<asp:Button CssClass="btn btn-danger btn-sm" ID="btnBorrar" runat="server" Text="Borrar"  Visible="false"  />
                               
                               <cc1:ConfirmButtonExtender ID="btnBorrar_ConfirmButtonExtender" runat="server" 
                                   ConfirmText="¿Desea borrar esta fecha de la lista de asistencia?" 
                                   Enabled="True" TargetControlID="btnBorrar">
                               </cc1:ConfirmButtonExtender>

                        </div>

                       <div style="height:15px;"></div>
                   
                   </asp:Panel>
                
               
                       <asp:GridView ID="gvAsistenciaFechas" runat="server" AllowSorting="True"  DataKeyNames="idAsistencia"
                           AutoGenerateColumns="False" Width="100%" GridLines="None" CssClass="table table-hover table-striped">
                           <columns>
                               
                               <asp:hyperlinkfield DataNavigateUrlFields="idSalonVirtual, idAsistencia" 
                                   DataNavigateUrlFormatString="AsistenciaSalonVirtualPase.aspx?idSalonVirtual={0}&idAsistencia={1}"    ControlStyle-CssClass ="btn btn-default btn-sm"
                                   Text="Asistencia">
                                  <ControlStyle  />
                               <headerstyle width="70px" />
                               <itemstyle horizontalalign="Center" />
                               </asp:hyperlinkfield>
                               <asp:boundfield DataField="Fecha" DataFormatString="{0:D}" HeaderText="Fecha para tomar asistencia" 
                                   HtmlEncode="False" SortExpression="Fecha">
                                  <HeaderStyle HorizontalAlign="Left" />
                                  </asp:boundfield>


                                  <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkBorrar" runat="server" CausesValidation="false"  CommandName="Delete"  Text="Eliminar" CssClass="btn btn-danger btn-sm"></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle Width="80px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>


                           </columns>
                          
                       </asp:GridView>
               
               </ContentTemplate>
       </asp:UpdatePanel>

  </div>

             </div>
        </div>

    </div>

        <asp:Label ID="labelCursosComoDocente" runat="server" Text="Cursos como docente" Visible="false"></asp:Label>
    <asp:Label ID="labelCursosComoAlumno" runat="server" Text="Cursos como alumno"  Visible="false"></asp:Label>




</asp:Content>

<asp:Content ID="Content6" runat="server" contentplaceholderid="ContentPlaceHead">
    </asp:Content>


