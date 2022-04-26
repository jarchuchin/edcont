<%@ Page Title="" Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="Libros.aspx.vb" Inherits="Sec_Administracion_Libros" %>


<%@ Register src="Controles/MenuAdministracion.ascx" tagname="MenuAdministracion" tagprefix="uc1" %>



<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>



<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>





<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server" Text="Libros de trabajo"  ></asp:Label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
   
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>

    
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Administración"  NavigateUrl="~/sec/Administracion/default.aspx" ></asp:HyperLink></li>
       
       
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Libros de trabajo" ></asp:Label></li>
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
					                    <asp:TextBox ID="txtBuscar"  placeholder="Coloca nombre o clave del libro de trabajo" runat="server" CssClass="form-control" Width="300px"></asp:TextBox>  
        &nbsp;<asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-success btn-sm" Text="Buscar" ></asp:Button>
                                          &nbsp;<asp:Button ID="btncrear" runat="server" CssClass="btn btn-primary btn-sm" Text="Crear Libro" CausesValidation="False" ></asp:Button>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBuscar" Display="Dynamic">*</asp:RequiredFieldValidator>
				                     </div>
                                </div>

  <h3 class="panel-title">
                                        <asp:Label ID="lblTitulo" runat="server" Text="Libros de trabajo"></asp:Label>
                                    </h3>
                            </div>
                            <div class="panel-body">


                 <%--  <table style="width: 100%">
                       <tr>
                           <td>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                   ControlToValidate="txtBuscar" Display="Dynamic">*</asp:RequiredFieldValidator>
                               </td>
                           <td>
                               <div>
                                   <br />
                                   <asp:TextBox ID="txtBuscar" runat="server" Width="200px"></asp:TextBox>
                                   &nbsp;<asp:Button ID="btnBuscar" runat="server" CssClass="BotonSubmit" 
                                       Text="Buscar" />
                                   <br />
                                   <asp:Label ID="lblInstrucción" runat="server" CssClass="Chica" 
                                       Text="Coloca alguna palabra que forme parte del nombre del curso"></asp:Label>
                                   <br />
                               </div>
                           </td>
                           <td style="text-align: right">
                               <asp:Button ID="btnCrear" runat="server" Text="Crear nuevo libro" 
                                   CausesValidation="False" CssClass="BotonSubmit" />&nbsp;</td>
                       </tr>
                   </table>--%>

            <asp:GridView id="gvSalones" runat="server" AllowSorting="True" Width="100%" 
                AutoGenerateColumns="False" GridLines="None"  CssClass="table table-striped table-hover">
                <Columns>


                     <asp:HyperLinkField DataNavigateUrlFields="idRoot"   HeaderText=" "  ControlStyle-CssClass="btn-link" Text="Editar"
                       DataNavigateUrlFormatString="~/sec/workbook/home.aspx?idRoot={0}" > 
                       <HeaderStyle  HorizontalAlign="Left" />
                           <ItemStyle HorizontalAlign="Center"  Width="50px" />
                 </asp:HyperLinkField>
                
                <asp:BoundField DataField="FechaCreacion"  HeaderText="Creado" SortExpression="FechaCreacion"  htmlencode="false" DataFormatString="{0:yyyy, dd MMM}"  >
                    <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                 </asp:BoundField>

                 <asp:BoundField DataField="FechaUltimaActualizacion"  HeaderText="Actualizado" SortExpression="FechaUltimaActualizacion"  htmlencode="false" DataFormatString="{0:yyyy, dd MMM}"  >
                    <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                 </asp:BoundField>
                
               <asp:HyperLinkField DataNavigateUrlFields="idRoot" SortExpression="Titulo"  DataTextField="Titulo" HeaderText="Nombre"  ControlStyle-CssClass="LigaVerde"
                       DataNavigateUrlFormatString="~/sec/workbook/default.aspx?idRoot={0}" > 
                       <HeaderStyle  HorizontalAlign="Left" />
                 </asp:HyperLinkField>
                    
         
                    
                 <asp:BoundField DataField="Texto"  HeaderText="Texto" SortExpression="Texto"  htmlencode="false"  >
                    <HeaderStyle CssClass="text-center" />
                    <ItemStyle CssClass="text-center" Width="60px" />
                 </asp:BoundField>

                    <asp:BoundField DataField="Archivos"  HeaderText="Archivos" SortExpression="Archivos"  htmlencode="false"  >
                    <HeaderStyle CssClass="text-center" />
                    <ItemStyle CssClass="text-center" Width="60px" />
                 </asp:BoundField>

                       <asp:BoundField DataField="Imagenes"  HeaderText="Imagenes" SortExpression="Imagenes"  htmlencode="false"  >
                    <HeaderStyle CssClass="text-center" />
                    <ItemStyle CssClass="text-center" Width="60px" />
                 </asp:BoundField>

                        <asp:BoundField DataField="Actividades"  HeaderText="Actividades" SortExpression="Actividades"  htmlencode="false"  >
                    <HeaderStyle CssClass="text-center" />
                    <ItemStyle CssClass="text-center" Width="60px" />
                 </asp:BoundField>

                           <asp:BoundField DataField="Examenes"  HeaderText="Examenes" SortExpression="Examenes"  htmlencode="false"  >
                    <HeaderStyle CssClass="text-center" />
                    <ItemStyle CssClass="text-center" Width="60px" />
                 </asp:BoundField>


                               <asp:BoundField DataField="Foros"  HeaderText="Foros" SortExpression="Foros"  htmlencode="false"  >
                    <HeaderStyle CssClass="text-center" />
                    <ItemStyle CssClass="text-center" Width="60px" />
                 </asp:BoundField>


                                    <asp:BoundField DataField="ArchivosAdjuntos"  HeaderText="Adjuntos" SortExpression="Foros"  htmlencode="false"  >
                    <HeaderStyle CssClass="text-center" />
                    <ItemStyle CssClass="text-center" Width="60px" />
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

