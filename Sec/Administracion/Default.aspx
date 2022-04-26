<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Sec_Administracion_Default" title="Usuarios del Skolar" %>

<%@ Register src="~/Sec/Workbook/Controles/showadjuntos.ascx" tagname="showadjuntos" tagprefix="uc2" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>



<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>





<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server" Text="Administración de usuarios"  ></asp:Label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
   
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>

    
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Administración"  NavigateUrl="~/sec/Administracion/default.aspx" ></asp:HyperLink></li>
       
       
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Administración de usuarios" ></asp:Label></li>
    </ol>


   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">
   
     <uc22:MenuGeneral ID="MenuGeneral1" runat="server" />

</asp:Content>




<asp:Content ID="contentCentral" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

	  <div class="row">

 
        <div class="col-xs-12">


         
              
                       <div class="panel">
                            <div class="panel-heading">

                                  <div ID="panelEdicion" class="panel-control form-inline" runat="server" style="text-align:right">
                                      <div class="form-group">
					                    <asp:TextBox ID="txtBuscar"  placeholder="Coloca matrícula, nombre o apellido." runat="server" CssClass="form-control" Width="300px"></asp:TextBox>&nbsp;
                                          <asp:DropDownList ID="drpEmpresas" runat="server" Width="200px" Height="35px"></asp:DropDownList>
        &nbsp;<asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-success btn-sm" Text="Buscar" ></asp:Button>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBuscar" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>

                                             &nbsp;<asp:Button ID="btnVerTodos" runat="server" CssClass="btn btn-primary btn-sm" Text="Ver todos" CausesValidation="false"></asp:Button>&nbsp;
                                            <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-warning btn-sm" Text="Agregar usuario" CausesValidation="false" ></asp:Button>

				                     </div>
                                </div>


                                    <h3 class="panel-title">
                                        <asp:Label ID="lblTitulo" runat="server" Text="Administración de usuarios"></asp:Label>
                                    </h3>
                            </div>
                            <div class="panel-body">

  







            <asp:GridView id="gvSalones" runat="server" AllowSorting="True" Width="100%"  CssClass="table table-hover table-striped"
                AutoGenerateColumns="False" GridLines="None">
                <Columns>
             <%--     <asp:HyperLinkField DataNavigateUrlFields="idUserProfile"  Text="Ingresar" HeaderText=" "   ItemStyle-CssClass="btn btn-succcess btn-sm" 
                       DataNavigateUrlFormatString="~/sec/Administracion/Default.aspx?idUserProfile={0}" > 
                      <ItemStyle  Width="80px" />
                 </asp:HyperLinkField>--%>

                 <asp:TemplateField  HeaderText=" " >
                   <ItemTemplate>
                       <asp:HyperLink ID="lnkIngresar" runat="server" Text="Ingresar" CssClass="btn btn-success btn-sm" NavigateUrl='<%# "~/sec/Administracion/default.aspx?idUserProfile=" & Eval("iduserProfile") %>'></asp:HyperLink>
                   </ItemTemplate>
                     <ItemStyle Width="70px" />
                 </asp:TemplateField>
                
                       <asp:TemplateField  HeaderText=" " >
                   <ItemTemplate>
                       <asp:HyperLink ID="lnkEditar" runat="server" Text="Editar" CssClass="btn btn-primary btn-sm" NavigateUrl='<%# "~/sec/Administracion/RegistroAdmin.aspx?idUserProfile=" & Eval("iduserProfile") %>'></asp:HyperLink>
                   </ItemTemplate>
                     <ItemStyle Width="70px" />
                 </asp:TemplateField>


                         <asp:BoundField DataField="idUserProfile"  HeaderText="UserProfile" SortExpression="idUserProfile"  htmlencode="false">
                    <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="70px" />
                 </asp:BoundField>

                      <asp:BoundField DataField="claveaux1"  HeaderText="Matrícula" SortExpression="claveaux1"  htmlencode="false">
                    <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="70px" />
                 </asp:BoundField>
                 
                   <asp:BoundField DataField="claveaux2"  HeaderText="#Nómina" SortExpression="claveaux2"  htmlencode="false">
                    <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="70px" />
                 </asp:BoundField>
                
               
              

               <asp:TemplateField  HeaderText="Nombre" >
                   <ItemTemplate>
                   <asp:Label ID="lblapellidos" runat="server" Text='<%# Eval("Apellidos") %>'></asp:Label>
                        <asp:Label ID="lblnombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                       </ItemTemplate>
               </asp:TemplateField>


                      <asp:BoundField DataField="tipoUsuario"  HeaderText="Tipo" SortExpression="tipoUsuario"  htmlencode="false">
                    <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="70px" />
                 </asp:BoundField>


              <%--  <asp:HyperLinkField DataNavigateUrlFields="idUserProfile" SortExpression="Nombre"  DataTextField="Nombre" HeaderText="Nombre"  ControlStyle-CssClass="LigaVerde"
                       DataNavigateUrlFormatString="~/sec/Administracion/Default.aspx?idUserProfile={0}" > 
                       <ControlStyle CssClass="LigaVerde" />
                       <HeaderStyle  HorizontalAlign="Left" />
                 </asp:HyperLinkField>
                 <asp:HyperLinkField DataNavigateUrlFields="idUserProfile" SortExpression="Apellidos"  DataTextField="Apellidos" HeaderText="Apellidos"  ControlStyle-CssClass="LigaVerde"
                       DataNavigateUrlFormatString="~/sec/Administracion/Default.aspx?idUserProfile={0}" > 
                       <ControlStyle CssClass="LigaVerde" />
                       <HeaderStyle  HorizontalAlign="Left" />
                 </asp:HyperLinkField>
                <asp:BoundField DataField="claveaux1"  HeaderText="Matrícula" SortExpression="claveaux1"  htmlencode="false">
                    <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="70px" />
                 </asp:BoundField>
                 
                   <asp:BoundField DataField="claveaux2"  HeaderText="#Nómina" SortExpression="claveaux2"  htmlencode="false">
                    <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="70px" />
                 </asp:BoundField>
                
               --%>
                    
               
                    
              
                        
                </Columns>
               
                
            </asp:GridView>


                                <div style="height:450px;" runat="server" id="divespacio" visible="true"></div>
        
          
    
    </div>

                           </div>
                     </div>

          </div>


    

 

</asp:Content>




