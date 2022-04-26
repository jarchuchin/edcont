<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Sec_Workbook_Default" title="Libro de trabajo" ValidateRequest="false" meta:resourcekey="PageResource1" uiculture="auto" Culture="auto" %>
 
<%@ Register src="Controles/GeneralData.ascx" tagname="GeneralData" tagprefix="uc1" %>
<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc2" %>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombredelLibro2" runat="server" meta:resourcekey="lblNombredelLibro2Resource1" >Editar datos generales</asp:Label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelBreadcrumb" Runat="Server">
	
    
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
     
<asp:HyperLink ID="lnkSalirEdicion" runat="server" meta:resourcekey="lnkSalirEdicionResource1" >Salir de edición</asp:HyperLink>
  

    <div class="btn-group pull-right">
        <button aria-expanded="false" aria-haspopup="true" class="btn btn-info btn-sm dropdown-toggle" data-toggle="dropdown" type="button">
            <asp:Literal ID="Literal1" runat="server" Text="Idiomas" meta:resourcekey="Literal1Resource1"></asp:Literal>
            <span class="caret"></span>
        </button>
        <ul class="dropdown-menu">
            <li>
                <asp:HyperLink ID="lnkIdiomaDefault" runat="server" meta:resourcekey="lnkIdiomaDefaultResource1">[lnkIdiomaDefault]</asp:HyperLink></li>
            <li class="divider" role="separator"></li>
            <asp:Repeater ID="rptIdiomas" runat="server">
                <ItemTemplate>
                    <li>
                        <asp:HyperLink ID="btnDisplayIdioma" runat="server" CommandName="DisplaIdioma" NavigateUrl='<%# "~/sec/workbook/default.aspx?idRoot=" & Eval("idRoot") & "&idIdioma=" & Eval("idIdioma") %>' Text='<%# Eval("IdiomaNombre") %>' meta:resourcekey="btnDisplayIdiomaResource1"></asp:HyperLink></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
            
<uc1:GeneralData ID="GeneralData1" runat="server" />
    
    
  
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPanelMenu">
    <uc2:MenuGeneral ID="MenuGeneral1" runat="server" />
</asp:Content>
