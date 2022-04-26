<%@ Page Title="Biblioteca" Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="Biblioteca.aspx.vb" Inherits="Sec_Biblioteca" %>

<%@ Register src="Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register src="SalonVirtual/Controles/displayBuscadores.ascx" tagname="displayBuscadores" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelBreadcrumb" Runat="Server">


<ol class="breadcrumb" style="margin-bottom: 5px;">
  <li><asp:HyperLink ID="HyperLink2" runat="server"  Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
  <li class="active">Biblioteca</li>
</ol>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">
    <uc1:MenuGeneral ID="MenuGeneral1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">






  

 <div class="panel">
        <div class="panel-heading">
                <h3 class="panel-title"><asp:Label ID="lblbusquedas" runat="server" text="Búsquedas relacionadas"  /></h3>
        </div>
        <div class="panel-body text-center">

            
            <asp:Literal ID="lblbibliotecas" runat="server"></asp:Literal>







      </div>
</div>




 
 


</asp:Content>

