<%@ Page Title="Quitar libro de trabajo" Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="QuitarLibro.aspx.vb" Inherits="Sec_SalonVirtual_QuitarLibro" %>

<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server" Text="Preguntas del grupo" ></asp:Label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/default.aspx" ></asp:HyperLink></li>
       <li><asp:HyperLink ID="lnkCurso" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/Sa/default.aspx" ></asp:HyperLink></li>
      <li class="active"><asp:Label ID="lblCursoBread" runat="server" Text="Quitar libro de trabajo"  ></asp:Label></li>
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
                        <h3 class="panel-title"><asp:Label ID="lbltitulo" runat="server" Text="Cambiar libro de trabajo"></asp:Label></h3>
                </div>
                <div class="panel-body">

                    <asp:Label ID="Label1" runat="server" Text="Un Momento !!!!" Font-Bold="true" ForeColor="Red" font-size="40px"></asp:Label>
                    <div style="height:10px;"></div>
                    <asp:Label ID="Label3" runat="server" Text="Al quitar el libro se eliminarán el esquema de evaluación y la agenda del curso" Font-Bold="true" ForeColor="#800000" font-size="25px"></asp:Label>
                     <div style="height:30px;"></div>

                    <asp:Label ID="Label2" runat="server" Text="¿Estás seguro que deseas desligar el libro de trabajo de este curso?"  Font-Size="17px"></asp:Label>
                    <div style="height:5px;"></div>
                    Curso:  <asp:Label ID="lblSalon" runat="server"  Font-Bold="true"></asp:Label>
                      <div style="height:30px;"></div>
                    <asp:Button ID="btnBorrar" runat="server" Text="Quitar libro de trabajo" CssClass="btn btn-danger btn-lg" />
                    <cc1:ConfirmButtonExtender ID="btnBorrar_ConfirmButtonExtender" runat="server" BehaviorID="btnBorrar_ConfirmButtonExtender" ConfirmText="¿Deseas continuar?" TargetControlID="btnBorrar">
                    </cc1:ConfirmButtonExtender>
                </div>
            </div>

         </div>

      </div>



    
        <asp:Label ID="labelCursosComoDocente" runat="server" Text="Cursos como docente" Visible="false"></asp:Label>
    <asp:Label ID="labelCursosComoAlumno" runat="server" Text="Label"  Visible="false"></asp:Label>



           
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceFooterScripts" Runat="Server">
</asp:Content>

