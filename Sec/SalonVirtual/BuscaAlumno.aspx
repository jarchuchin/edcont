<%@ Page Title="" Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="BuscaAlumno.aspx.vb" Inherits="Sec_SalonVirtual_BuscaAlumno" %>


<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>


<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server"  Text="Buscar alumno" ></asp:Label> </h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/default.aspx" ></asp:HyperLink></li>
           <li><asp:HyperLink ID="lnkCurso" runat="server"  Text="Curso nombre"  NavigateUrl="~/sec/Sa/default.aspx" ></asp:HyperLink></li>
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Buscar alumno" ></asp:Label></li>
    </ol>


   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">
   
     <uc22:MenuGeneral ID="MenuGeneral1" runat="server" />
    sssss
</asp:Content>

<asp:Content ID="contentCentral" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

		
	<div class="row">

        <div class="col-xs-3">
             <uc1:MenuSalonVirtual ID="MenuSalonVirtual2" runat="server" />
        </div>
        <div class="col-xs-9">

                        
            <div class="panel">
                <div class="panel-heading">
                        <h3 class="panel-title"><asp:Label ID="lblCalendario" runat="server" Text="Buscar alumno"></asp:Label> </h3>


                </div>
                <div class="panel-body">

                    <div  class="form-inline">
                     <asp:TextBox ID="txtBuscar"  placeholder="Coloca matrícula, nombre o apellido." runat="server" CssClass="form-control" Width="300px"></asp:TextBox>  
                     &nbsp;<asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-success btn-sm" Text="Buscar" ></asp:Button>

                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBuscar" Display="Dynamic" ErrorMessage="Debes colocar el nombre o la matrícula del alumno" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </div>

                    <div style="height:15px;"></div>


                    
  







            <asp:GridView id="gvAlumnos" runat="server" AllowSorting="True" Width="100%"  CssClass="table table-hover table-striped"
                AutoGenerateColumns="False" GridLines="None">
                <Columns>
             <%--     <asp:HyperLinkField DataNavigateUrlFields="idUserProfile"  Text="Ingresar" HeaderText=" "   ItemStyle-CssClass="btn btn-succcess btn-sm" 
                       DataNavigateUrlFormatString="~/sec/Administracion/Default.aspx?idUserProfile={0}" > 
                      <ItemStyle  Width="80px" />
                 </asp:HyperLinkField>--%>

                 <asp:TemplateField  HeaderText=" " >
                   <ItemTemplate>
                       <asp:HyperLink ID="lnkIngresar" runat="server" Text="Ingresar" CssClass="btn btn-primary btn-sm" NavigateUrl='<%# "~/sec/SalonVirtual/Inscribir.aspx?idUserProfile=" & Eval("iduserProfile") & "&idSalonVirtual=" & Request("idSalonVirtual")  %>'></asp:HyperLink>
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
                 
                <%--   <asp:BoundField DataField="claveaux2"  HeaderText="#Nómina" SortExpression="claveaux2"  htmlencode="false">
                    <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="70px" />
                 </asp:BoundField>--%>
                
               
              

               <asp:TemplateField  HeaderText="Nombre" >
                   <ItemTemplate>
                   <asp:Label ID="lblapellidos" runat="server" Text='<%# Eval("Apellidos") %>'></asp:Label>
                        <asp:Label ID="lblnombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                       </ItemTemplate>
               </asp:TemplateField>

              <%--  <asp:HyperLinkField DataNavigateUrlFields="idUserProfile" SortExpression="Nombre"  DataTextField="Nombre" HeaderText="Nombre"  ControlStyle-CssClass="LigaVerde"
                       DataNavigateUrlFormatString="~/sec/Administracion/Default.aspx?idUserProfile={0}" > 
                       <ControlStyle CssClass="LigaVerde" />
                       <HeaderStyle  HorizontalAlign="Left" />
                 </asp:HyperLinkField>
                 <asp:HyperLinkField DataNavigateUrlFields="idUserProfile" SortExpression="Apellidos"  DataTextField="Apellidos" HeaderText="Apellidos"  ControlStyle-CssClass="LigaVerde"
                       DataNavigateUrlFormatString="~/sec/Administracion/Default.aspx?idUserProfile={0}" > 
                       <ControlStyle CssClass="LigaVerde" />
                       <HeaderStyle  HorizontalAlign="Left" />
                 </asp:HyperLinkField>--%>
            <%--    <asp:BoundField DataField="claveaux1"  HeaderText="Matrícula" SortExpression="claveaux1"  htmlencode="false">
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

<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceFooterScripts" Runat="Server">
</asp:Content>

