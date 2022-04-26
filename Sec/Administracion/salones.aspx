<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="salones.aspx.vb" Inherits="Sec_Administracion_salones" title="Untitled Page" %>

<%@ Register src="Controles/MenuAdministracion.ascx" tagname="MenuAdministracion" tagprefix="uc1" %>




<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>



<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>





<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server" Text="Administración de cursos"  ></asp:Label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
   
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>

    
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Administración"  NavigateUrl="~/sec/Administracion/default.aspx" ></asp:HyperLink></li>
       
       
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Administración de cursos" ></asp:Label></li>
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
					                    <asp:TextBox ID="txtBuscar"  placeholder="Coloca nombre o clave del curso" runat="server" CssClass="form-control" Width="300px"></asp:TextBox>  
        &nbsp;<asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-success btn-sm" Text="Buscar" ></asp:Button>
                                           <asp:Button ID="Button1" runat="server" Text="Crear salon" CausesValidation="False" CssClass="btn btn-primary btn-sm" />

        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBuscar" Display="Dynamic">*</asp:RequiredFieldValidator>
				                     </div>
                                </div>


                                    <h3 class="panel-title">
                                        <asp:Label ID="lblTitulo" runat="server" Text="Administración de cursos"></asp:Label>
                                    </h3>
                            </div>
                            <div class="panel-body">

  






            <asp:GridView id="gvSalones" runat="server" AllowSorting="True" Width="100%" 
                AutoGenerateColumns="False" GridLines="None" CssClass="table table-striped table-hover">
                <Columns>


                       <asp:HyperLinkField DataNavigateUrlFields="idSalonVirtual"    Text="Ver detalles" HeaderText=" "  ControlStyle-CssClass="btn-link"
                       DataNavigateUrlFormatString="~/sec/administracion/datossalon.aspx?idSalonVirtual={0}" > 
                       <HeaderStyle  HorizontalAlign="Left" />
                           <ItemStyle HorizontalAlign="Center"  Width="90px" />
                 </asp:HyperLinkField>
                
                <asp:BoundField DataField="FechaInicio"  HeaderText="Inicia" SortExpression="FechaInicio"  htmlencode="false" DataFormatString="{0:yyyy, dd MMM}"  >
                    <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="120px" />
                 </asp:BoundField>

                        <asp:BoundField DataField="ClaveAux1"  HeaderText="Clave" 
                        SortExpression="ClaveAux1" > 
                    <ItemStyle HorizontalAlign="Center"  Width="100px" />
                    </asp:BoundField>
                
               <asp:HyperLinkField DataNavigateUrlFields="idSalonVirtual" SortExpression="Nombre"  DataTextField="Nombre" HeaderText="Nombre"  ControlStyle-CssClass="LigaVerde"
                       DataNavigateUrlFormatString="~/sec/administracion/datossalon.aspx?idSalonVirtual={0}" > 
                       <HeaderStyle  HorizontalAlign="Left" />
                 </asp:HyperLinkField>
                    
            
                         <asp:BoundField DataField="Alumnos"  HeaderText="Alumnos" 
                        SortExpression="Alumnos" > 
                    <ItemStyle HorizontalAlign="Center"  Width="100px" />
                    </asp:BoundField>
              
                        

                             <asp:BoundField DataField="CalificacionPromedio"  HeaderText="Calificación promedio" 
                        SortExpression="CalificacionPromedio" > 
                    <ItemStyle HorizontalAlign="center"  Width="150px" />
                    </asp:BoundField>

                </Columns>
                <HeaderStyle Font-Bold="True" ForeColor="Black" horizontalalign="center" 
                    BackColor="White"/>
                <AlternatingRowStyle BackColor="White" />
                
            </asp:GridView>

       
                     </div>

                           </div>
                     </div>

          </div>




</asp:Content>

