<%@ Page Title="" Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="ListaAC.aspx.vb" Inherits="Sec_Administracion_ListaAC" %>

<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelTitulo" Runat="Server">

       <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server" Text="Actividades y contenidos"  ></asp:Label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPanelBreadcrumb" Runat="Server">

      
   
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>

    
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Administración"  NavigateUrl="~/sec/Administracion/home.aspx" ></asp:HyperLink></li>
       
       
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Actividaes y contenido" ></asp:Label></li>
    </ol>


</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

      <div class="row">

 
        <div class="col-xs-12">
               <div class="panel">
                            <div class="panel-heading">
                                 <h3 class="panel-title">
                                        <asp:Label ID="lblTitulo" runat="server" Text="Configuración de actividades"></asp:Label>
                                    </h3>

                            </div>
                            <div class="panel-body">
                                
                                <asp:HyperLink ID="lnkconf" runat="server" NavigateUrl="~/Sec/Administracion/configurarAC.aspx?TipoC=Actividad" CssClass="btn btn-primary btn-sm pull-right" Text="Agregar actividad" ></asp:HyperLink>


                                <div style="height:10px;"></div>

                            <asp:GridView id="gvActivdiades" runat="server" AllowSorting="True" Width="100%"  CssClass="table table-hover table-striped"
                                AutoGenerateColumns="False" GridLines="None">
                                <Columns>
            
                                 <asp:TemplateField  HeaderText=" " >
                                   <ItemTemplate>
                                       <asp:HyperLink ID="lnkEditar" runat="server" Text="Editar" CssClass="btn btn-success btn-sm" NavigateUrl='<%# "~/sec/Administracion/configurarAC.aspx?idCatalogoActividadHP=" & Eval("idCatalogoActividadHP") %>'></asp:HyperLink>
                                   </ItemTemplate>
                                     <ItemStyle Width="70px" />
                                 </asp:TemplateField>
                

                                         <asp:BoundField DataField="TipoHP"  HeaderText="Tipo" SortExpression="TipoHP"  htmlencode="false">
                                     <ItemStyle  CssClass="text-center" Width="90px" />
                                      <HeaderStyle  CssClass="text-center" />
                                 </asp:BoundField>


                                         <asp:BoundField DataField="TiempoRealización"  HeaderText="Tiempo min." SortExpression="TiempoRealización"  htmlencode="false">
                                     <ItemStyle  CssClass="text-center" Width="90px" />
                                      <HeaderStyle  CssClass="text-center" />
                                 </asp:BoundField>

                                      <asp:BoundField DataField="Nombre"  HeaderText="Nombre" SortExpression="Nombre"  htmlencode="false">
                                    <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left"  />
                                 </asp:BoundField>
                 
                                
                
               
              

                               <asp:TemplateField  HeaderText="Formato" >
                                   <ItemTemplate>
                                   <asp:hyperlink ID="lnkFormato" runat="server" text="Descargar" Visible='<%# existeFile(Eval("FileFormato")) %>'  NavigateUrl='<%# "~/sec/displayFile.aspx?idCatalogoActividadesHP=" & Eval("idCatalogoActividadesHP") & "&display=formato" %>'></asp:hyperlink>
                                       
                                       </ItemTemplate>
                                   <ItemStyle  CssClass="text-center" Width="90px" />
                                      <HeaderStyle  CssClass="text-center" />
                               </asp:TemplateField>

       
                                 <asp:TemplateField  HeaderText="Ejemplo" >
                                   <ItemTemplate>
                                   <asp:hyperlink ID="lnkEjemplo" runat="server" text="Descargar" Visible='<%# existeFile(Eval("FileEjemplo")) %>'  NavigateUrl='<%# "~/sec/displayFile.aspx?idCatalogoActividadesHP=" & Eval("idCatalogoActividadesHP") & "&display=ejemplo" %>'></asp:hyperlink>
                                       
                                       </ItemTemplate>
                                   <ItemStyle  CssClass="text-center" Width="90px" />
                                      <HeaderStyle  CssClass="text-center" />
                               </asp:TemplateField>
                
               
                    
               
                    
              
                        
                                </Columns>
               
                
                            </asp:GridView>


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

