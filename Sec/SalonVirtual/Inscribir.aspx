<%@ Page Title="Inscribir Alumno" Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="Inscribir.aspx.vb" Inherits="Sec_SalonVirtual_Inscribir" %>

<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server"  Text="Inscribir alumno" ></asp:Label> </h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/default.aspx" ></asp:HyperLink></li>
           <li><asp:HyperLink ID="lnkCurso" runat="server"  Text="Curso nombre"  NavigateUrl="~/sec/Sa/default.aspx" ></asp:HyperLink></li>
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Inscribir alumno" ></asp:Label></li>
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
                        <h3 class="panel-title"><asp:Label ID="lblCalendario" runat="server" Text="Inscribir alumno"></asp:Label> </h3>


                </div>
                <div class="panel-body">


                    <div id="divMensaje" runat="server"  class="alert alert-danger" visible="false">
                        El alumnos ya está inscrito
                    </div>
                    

                     <div id="divMensajeBaja" runat="server"  class="alert alert-warning" visible="false">
                       El alumnos ha sido dado de baja de este curso
                    </div>
                  

                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style3"><strong>Matrícula</strong></td>
                            <td class="auto-style4">
                                <asp:Label ID="lblmatricula" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3"><strong>Nombre:</strong></td>
                            <td class="auto-style4">
                                <asp:Label ID="lblNombre" runat="server"></asp:Label>
                            </td>
                        </tr>
                    
                    </table>

                    <div style="height:15px;"></div>
                     <asp:Button ID="btnInscribir" runat="server" CssClass="btn btn-success" Text="Inscribir Alumno" />
                  

                    <cc1:ConfirmButtonExtender ID="btnInscribir_ConfirmButtonExtender" runat="server" ConfirmText="¿Deseas inscribri a este alumno al curso?" Enabled="True" TargetControlID="btnInscribir">
                    </cc1:ConfirmButtonExtender>
                  

                </div>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceFooterScripts" Runat="Server">
</asp:Content>

<asp:Content ID="Content7" runat="server" contentplaceholderid="ContentPlaceHead">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            width: 193px;
            height: 35px;
        }
        .auto-style4 {
            height: 35px;
        }
    </style>
</asp:Content>


