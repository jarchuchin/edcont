<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="Sincronizacion.aspx.vb" Inherits="Sec_SalonVirtual_Sincronizacion" title="Sincronización con sistemas UM" %>

<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server"  Text="Sincronización con sistema UM" ></asp:Label> </h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/default.aspx" ></asp:HyperLink></li>
           <li><asp:HyperLink ID="lnkCurso" runat="server"  Text="Curso nombre"  NavigateUrl="~/sec/Sa/default.aspx" ></asp:HyperLink></li>
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Sincronización" ></asp:Label></li>
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
                    
                      

                        <h3 class="panel-title"><asp:Label ID="lblActividad" runat="server" text="Sincronización con el sistema UM"></asp:Label></h3>
                </div>
                <div class="panel-body">


                    <div class="text-center">

                    <div style="height:25px;"></div>
 <asp:Label ID="lblmensaje" runat="server" ForeColor="Red" 
                    Text="El curso no puede ser sincronizado porque ya ha sido evaluado en el sistema académico" 
                    Visible="False"></asp:Label> <asp:Label ID="lblmensaje2" runat="server" ForeColor="Red" 
                    Text="Debe ser maestro para ejecutar la sincronización" 
                    Visible="False"></asp:Label>
            <asp:Label ID="lblsincronizacion" runat="server" ForeColor="Red" 
                Text="Sincronización completada a las: " Visible="False"></asp:Label>
           
                         <div style="height:10px;"></div>
        
                         <asp:Label ID="lblMensajeinicio" runat="server" 
               >
                             Al hacer clic en el botón se enviarán al sistema académico el  esquema de
                              evaluación actualizado y todas las actividades de los alumnos
                         </asp:Label>

                        
                        <div style="height:20px;"></div>

            <asp:Button ID="btnSincronizar" runat="server"  Visible="true"  CssClass="btn btn-warning"
                Text="Sincronizar calificaciones"  />
            <cc1:ConfirmButtonExtender ID="btnSincronizar_ConfirmButtonExtender" 
                runat="server" 
                ConfirmText="Las calificaciones de todas las actividades revisadas serán sincronizados con el sistema académico. ¿Deseas continuar?" 
                Enabled="True" TargetControlID="btnSincronizar">
            </cc1:ConfirmButtonExtender>




</div>


                         <div style="height:400px;"></div>
     

  </div>

             </div>
        </div>

    </div>

        <asp:Label ID="labelCursosComoDocente" runat="server" Text="Cursos como docente" Visible="false"></asp:Label>
    <asp:Label ID="labelCursosComoAlumno" runat="server" Text="Cursos como alumno"  Visible="false"></asp:Label>





</asp:Content>

