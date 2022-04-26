<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="Buscar.aspx.vb" Inherits="Sec_Workbook_Buscar" title="Buscar contenidos" meta:resourcekey="PageResource1" uiculture="auto" Culture="auto" %>

<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>




<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:label id="lblTitulo" runat="server" Font-Bold="True" Text="Editar examen" meta:resourcekey="lblTituloResource1" ></asp:label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">

     <uc22:MenuGeneral ID="MenuGeneral1" runat="server" />

</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPanelBreadcrumb">
  	  <ol class="breadcrumb" >
  <li><asp:HyperLink ID="lnkSalirEdicion" runat="server" Text="Salir de edición" meta:resourcekey="lnkSalirEdicionResource1" ></asp:HyperLink>
      </li>
        </ol>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">


    <div class="panel">
    <div class="panel-body">



    
 <div class="form-horizontal"  >   
    
    <div class="alert alert-success" id="alertSuccess" runat="server" visible="false">
      <span class="glyphicon glyphicon-saved"></span><strong>&nbsp; <asp:Label ID="Label10" runat="server" Text="Listo!" meta:resourcekey="Label10Resource1"></asp:Label>&nbsp;&nbsp; </strong> <asp:Label ID="Label9" runat="server" Text="Cambios realizados correctamente." meta:resourcekey="Label9Resource1"></asp:Label>
    </div>

  
 
  
  


                   
  <div class="form-group">
    <label class="col-sm-2 control-label">
        <asp:Label ID="Label3" runat="server" Text="Libro de trabajo" meta:resourcekey="Label3Resource1"></asp:Label>
    </label>
    <div class="col-sm-10"> 
        <asp:Label ID="lblLibro" runat="server" meta:resourcekey="lblLibroResource1" ></asp:Label>
    </div>
 </div>


   

                   
  <div class="form-group">
    <label class="col-sm-2 control-label">
        <asp:Label ID="Label2" runat="server" Text="Buscar" meta:resourcekey="Label2Resource1"></asp:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBuscar" Display="Dynamic" meta:resourcekey="RequiredFieldValidator1Resource1">*</asp:RequiredFieldValidator>
    </label>
    <div class="col-sm-10 form-inline"> 
<asp:TextBox ID="txtBuscar" runat="server"  CssClass="form-control" placeholder="Coloca parte del título" Width="400px" meta:resourcekey="txtBuscarResource1"/>
    </div>
    </div>

<div class="form-group">
    <label class="col-sm-2 control-label">
      
    </label>
    <div class="col-sm-10 form-inline"> 
 <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-success" Text="Buscar" meta:resourcekey="btnBuscarResource1"></asp:Button>
    </div>
    </div>
   

     <div style="height:20px"></div>   

            <asp:GridView id="gvContenidos" runat="server" AllowSorting="True" Width="100%" 
                AutoGenerateColumns="False" GridLines="None" CssClass="table table-hover" meta:resourcekey="gvContenidosResource1">
                <Columns>
                
                
                
                   <asp:BoundField DataField="FechaCreacion"  HeaderText="Fecha" SortExpression="FechaCreacion"  htmlencode="False"  DataFormatString="{0:yyyy, dd MMM}" meta:resourcekey="BoundFieldResource1"  >
                    <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="110px" />
                 </asp:BoundField>
                
                    <asp:TemplateField HeaderText="Título del contenido" SortExpression="Titulo" meta:resourcekey="TemplateFieldResource1">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" runat="server"  CssClass="btn-link"
                                NavigateUrl='<%# Eval("id", "~/sec/Workbook/AsignarContenido.aspx?id={0}") & Eval("Procedencia", "&Procedencia={0}") & "&idRoot=" & root & "&idClasificacion=" & claveClasificacion & "&regreso=" & Request("regreso") %>' 
                                Text='<%# Eval("titulo") %>' ></asp:HyperLink>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Tipo" SortExpression="id" meta:resourcekey="TemplateFieldResource2">
                    
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# getTipo(CInt(Eval("tipo")), Eval("Procedencia")) %>' ></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" Width="80px" />
                    </asp:TemplateField>
                    
              
                        
                </Columns>
                <HeaderStyle Font-Bold="True" ForeColor="Black" horizontalalign="Center" 
                    BackColor="White"/>
                <AlternatingRowStyle BackColor="White" />
                
            </asp:GridView>

        
    
    
     </div>

                </div>
        </div>
</asp:Content>


