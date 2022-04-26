<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="NoLibro.aspx.vb" Inherits="Sec_SalonVirtual_NoLibro" title="Untitled Page" %>



<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>



<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server"  ></asp:Label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
    
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  >Curso</asp:Label></li>
    </ol>


   
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">
   
     <uc22:MenuGeneral ID="MenuGeneral1" runat="server" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
      <div class="row">

        <div class="col-md-12">


            
            <div class="panel">
                <div class="panel-heading">
                        <h3 class="panel-title"><asp:Label ID="Label1" runat="server" Text="Mensaje"></asp:Label></h3>
                </div>
                <div class="panel-body">

	                <asp:Label ID="lblmensaje" runat="server" Text="El maestro no ha colocado contenidos para este curso. Comunícate con tu maestro"></asp:Label>



                     </div>
          </div>




            </div>
          </div>

</asp:Content>

