<%@ Page Title="" Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="Idiomas.aspx.vb" Inherits="Sec_Workbook_Idiomas" meta:resourcekey="PageResource1" uiculture="auto" Culture="auto" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="Controles/Menu.ascx" tagname="Menu" tagprefix="uc5" %>
<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc2" %>



<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblTitulo" runat="server" meta:resourcekey="lblTituloResource1">Configurar idiomas</asp:Label></h1>

       
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">

     <uc2:MenuGeneral ID="MenuGeneral1" runat="server" />

</asp:Content>



<asp:Content ID="contentBreadcrumb" runat="server" contentplaceholderid="ContentPanelBreadcrumb">

<ol class="breadcrumb" >
  <li><asp:HyperLink ID="HyperLink3" runat="server"  Text="Inicio" NavigateUrl="~/sec/home.aspx" meta:resourcekey="HyperLink3Resource1"></asp:HyperLink></li>
     <li><asp:HyperLink ID="HyperLink2" runat="server"  Text="Libros de trabajo" NavigateUrl="~/sec/Libros.aspx" meta:resourcekey="HyperLink2Resource1"></asp:HyperLink></li>
    <li><asp:HyperLink ID="lnkTitulo" runat="server" meta:resourcekey="lnkTituloResource1">[lnkTitulo]</asp:HyperLink></li>
  <li class="active"><asp:Label ID="lbltit" runat="server" Text="Idiomas" meta:resourcekey="lbltitResource1" ></asp:Label></li>
</ol>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">


<div class="row">
	<div class="col-xs-9">
		<div class="panel">

            <div class="panel-heading">
                <h3 class="panel-title">
                    <asp:Literal ID="lit" runat="server" Text="Idiomas"></asp:Literal>
                </h3>
            </div>

              <div class="panel-body">



<div class="alert alert-success" id="alertSuccess" runat="server" visible="false">
  <span class="glyphicon glyphicon-saved"></span><strong>&nbsp; <asp:Label ID="Label10" runat="server" Text="Listo!" meta:resourcekey="Label10Resource1"></asp:Label>&nbsp;&nbsp; </strong> <asp:Label ID="Label9" runat="server" Text="Cambios realizados correctamente." meta:resourcekey="Label9Resource1"></asp:Label>
</div>



    <asp:GridView ID="gvIdiomas" runat="server" CssClass="table table-hover" AutoGenerateColumns="False" GridLines="None" Width="500px" ShowHeader="False" meta:resourcekey="gvIdiomasResource1">
    <Columns>
        <asp:TemplateField ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" meta:resourcekey="TemplateFieldResource1">
            <ItemTemplate>
                <asp:CheckBox id="chkid" runat="server" Checked='<%# getSeleccionado(Eval("idIdioma")) %>' Enabled='<%# getEnabled(Eval("ididioma")) %>' meta:resourcekey="chkidResource1"></asp:CheckBox>
                <asp:Label ID="lblid" runat="server" Text='<%# Eval("idIdioma") %>' Visible="False" meta:resourcekey="lblidResource1"></asp:Label>
            </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="50px"></ItemStyle>
        </asp:TemplateField>

        <asp:TemplateField meta:resourcekey="TemplateFieldResource2">
            <ItemTemplate>

                <asp:label ID="lnkTitulo" runat="server" Text='<%# Eval("Nombre") %>' meta:resourcekey="lnkTituloResource2"  ></asp:label> 
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:Button ID="btnGrabar" runat="server" Text="Grabar" CssClass="btn btn-success" meta:resourcekey="btnGrabarResource1" />

    <cc1:ConfirmButtonExtender ID="btnGrabar_ConfirmButtonExtender" runat="server" ConfirmText="¿Deseas hacer los cambios de idiomas?" TargetControlID="btnGrabar" Enabled="True">
    </cc1:ConfirmButtonExtender>

 <div style="height:15px;"></div>


                  </div>
            </div>
        </div>
        <div class="col-xs-3">
        <div class="panel">
			
             <div class="panel-body">
              <uc5:Menu ID="Menu1" runat="server" />
              </div>
           
         </div>
    </div>
    </div>
    

</asp:Content>

