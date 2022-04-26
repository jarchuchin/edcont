<%@ Page Title="" Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="Home.aspx.vb" Inherits="Sec_Administracion_Home" %>

<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelTitulo" Runat="Server">

       <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server" Text="Administración general"  ></asp:Label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPanelBreadcrumb" Runat="Server">

    
   
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>

    

       
       
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Administración general" ></asp:Label></li>


    </ol>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">


      
      
  <div class="row">

     <div class="col-md-2 col-sm-4 col-xs-6">
         
         <div class="panel panel-default">

                <div class="panel-body text-center">
                  
							<asp:HyperLink ID="HyperLink7" runat="server" ImageUrl="~/images/t-iconestadocivil.png" NavigateUrl="~/sec/Administracion/Default.aspx"></asp:HyperLink>
                    <div style="height:5px;"></div>
					
							<asp:HyperLink ID="HyperLink13" runat="server" CssClass="btn-link"   NavigateUrl="~/sec/Administracion/Default.aspx">Usuarios</asp:HyperLink>
							<div style="height:2px;"></div>
							<asp:Label ID="Label1" runat="server" Font-Size="11px"  Text="Lista de usuarios" ></asp:Label>
						

                </div>
            </div>




      </div>

      <div class="col-md-2 col-sm-4 col-xs-6">

         <div class="panel panel-default">

                  <div class="panel-body text-center">

                    <asp:HyperLink ID="lnkHospital" runat="server" ImageUrl="~/images/iconsDiamante/iconFolder.jpg" ImageHeight="40px" NavigateUrl="~/sec/Administracion/salones.aspx"></asp:HyperLink>
                    <div style="height:5px;"></div>
						<asp:HyperLink ID="lnkHospital2" runat="server"  CssClass="btn-link"    NavigateUrl="~/sec/Administracion/salones.aspx">Administración de cursos</asp:HyperLink>
                    <div style="height:2px;"></div>
						<asp:Label ID="Label2" runat="server" Font-Size="11px" Text="Curso, alumnos, maestros, libro de trajo" ></asp:Label>
					
                </div>
            </div>



          
      </div>



        <div class="col-md-2 col-sm-4 col-xs-6">

         <div class="panel panel-default">

                  <div class="panel-body text-center">

                    <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/images/iconsDiamante/iconPreguntas.jpg" ImageHeight="40px" NavigateUrl="~/sec/Administracion/ListaAC.aspx"></asp:HyperLink>
                    <div style="height:5px;"></div>
						<asp:HyperLink ID="HyperLink2" runat="server"  CssClass="btn-link"    NavigateUrl="~/sec/Administracion/ListaAC.aspx">Actividades y Contenidos</asp:HyperLink>
                    <div style="height:2px;"></div>
						<asp:Label ID="Label3" runat="server" Font-Size="11px" Text="Lista de tipos de actividades y contenidos" ></asp:Label>
					
                </div>
            </div>



          
      </div>

  </div>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">

         <uc22:MenuGeneral ID="MenuGeneral1" runat="server" />

</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceFooterScripts" Runat="Server">


  
</asp:Content>

