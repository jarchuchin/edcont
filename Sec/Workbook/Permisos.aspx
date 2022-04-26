<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="Permisos.aspx.vb" Inherits="Sec_Workbook_Permisos" title="Configuración de permisos" meta:resourcekey="PageResource1" uiculture="auto" Culture="auto" %>
<%@ Register src="Controles/Menu.ascx" tagname="Menu" tagprefix="uc5" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc1" %>



<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblTitulo" runat="server" Text="Editar permisos" meta:resourcekey="lblTituloResource1"></asp:Label></h1>

       
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="contentIzquierdo" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">
     <uc1:MenuGeneral ID="MenuGeneral1" runat="server" />
</asp:Content>


<asp:Content ID="contentBreadcrumb" runat="server" contentplaceholderid="ContentPanelBreadcrumb">

<ol class="breadcrumb" >
  <li><asp:HyperLink ID="HyperLink3" runat="server"  Text="Inicio" NavigateUrl="~/sec/home.aspx" meta:resourcekey="HyperLink3Resource1"></asp:HyperLink></li>
     <li><asp:HyperLink ID="HyperLink4" runat="server"  Text="Libros de trabajo" NavigateUrl="~/sec/Libros.aspx" meta:resourcekey="HyperLink4Resource1"></asp:HyperLink></li>
    <li><asp:HyperLink ID="lnkTitulo" runat="server" meta:resourcekey="lnkTituloResource1">[lnkTitulo]</asp:HyperLink></li>
  <li class="active"><asp:Label ID="lbltit" runat="server" Text="Permisos" meta:resourcekey="lbltitResource1" ></asp:Label></li>
</ol>


</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
     
 
    <div class="panel">
              <div class="panel-body">

    <div class="row">
	<div class="col-xs-9">
		

<div class="alert alert-success" id="alertSuccess" runat="server" visible="false">
  <span class="glyphicon glyphicon-saved"></span><strong>&nbsp; <asp:Label ID="Label10" runat="server" Text="Listo!" meta:resourcekey="Label10Resource1"></asp:Label>&nbsp;&nbsp; </strong> <asp:Label ID="Label9" runat="server" Text="Cambios realizados correctamente." meta:resourcekey="Label9Resource1"></asp:Label>
</div>



<div class="form-horizontal"  >


   

      <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <div align="left" > <asp:Image ID="Image1sd" runat="server"  ImageUrl ="~/Images/indicator.gif" meta:resourcekey="Image1sdResource1" /><asp:Label ID="lbltexto" runat="server"   Text="Actualizando datos un momento por favor..." meta:resourcekey="lbltextoResource1" ></asp:Label></div>
                    </ProgressTemplate>
       </asp:UpdateProgress>
       <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional" >
               <ContentTemplate>



      <div class="form-group">
    <label class="col-sm-3 control-label">
        <asp:Label ID="Label3" runat="server" Text="Libro de trabajo" meta:resourcekey="Label3Resource1"></asp:Label>
    </label>
    <div class="col-sm-9"> 
        <asp:Label ID="lblLibro" runat="server" meta:resourcekey="lblLibroResource1" Font-Bold="true"  ></asp:Label>
    </div>
    </div>

    
      <div class="form-group">
    <label class="col-sm-3 control-label">
        <asp:label id="lblEmpresas" runat="server" text="Institución" meta:resourcekey="lblEmpresasResource1"></asp:label>
    </label>
    <div class="col-sm-9"> 
        <asp:dropdownlist id="drpEmpresa" runat="server" AutoPostBack="True" CssClass="form-control" meta:resourcekey="drpEmpresaResource1"></asp:dropdownlist>
			<asp:TextBox id="txtid" runat="server" Visible="False" meta:resourcekey="txtidResource1"></asp:TextBox>
			<asp:TextBox id="txttipopermiso" runat="server" Visible="False" meta:resourcekey="txttipopermisoResource1"></asp:TextBox>
    </div>
    </div>

  <div class="form-group">
    <label class="col-sm-3 control-label">
        <asp:label id="lblUsuarios" runat="server" Text="Usuarios" meta:resourcekey="lblUsuariosResource1"></asp:label>
    </label>
    <div class="col-sm-9 form-inline"> 
        <asp:TextBox id="txtbuscar" runat="server" Width="300px" CssClass="form-control" meta:resourcekey="txtbuscarResource1"></asp:TextBox>
	    <asp:button id="btnBuscar" runat="server" CssClass="btn btn-success" Text="Buscar" meta:resourcekey="btnBuscarResource1"></asp:button>
    </div>
    </div>

 


   <div class="form-group" id="panelPermisos" runat="server" visible="False">
    <label class="col-sm-3 control-label">
        <asp:Label ID="lblPermisos" runat="server" text="Seleccionar usuario" meta:resourcekey="lblPermisosResource1"></asp:Label>
    </label>
    <div class="col-sm-9"> 
        <asp:dropdownlist id="drpUsuarios" runat="server" Visible="False" AutoPostBack="True" CssClass="form-control" meta:resourcekey="drpUsuariosResource1"></asp:dropdownlist></TD>
    </div>
    </div>


    <div class="form-group">
    <label class="col-sm-3 control-label">
        
    </label>
    <div class="col-sm-9"> 

         <asp:Label ID="lblUsuario" runat="server" Font-Bold="True" meta:resourcekey="lblUsuarioResource1"></asp:Label>

         <div style="height:5px;"></div>

        	<asp:CheckBox ID="chkPRoots" runat="server"  CssClass="labelNormal"
                       Text="Editar datos principales del libro de trabajo" meta:resourcekey="chkPRootsResource1"></asp:checkbox>
                        
                    <div style="height:3px;"></div>
					
                   	<asp:CheckBox ID="chkPPermisosRoots" runat="server"  CssClass="labelNormal"
                       Text="Editar permisos para este libro de trabajo" meta:resourcekey="chkPPermisosRootsResource1">
                        </asp:CheckBox>
			
                    <div style="height:3px;"></div>

						<asp:CheckBox ID="chkPCategorias" runat="server" Text="Editar carpetas"  CssClass="labelNormal" meta:resourcekey="chkPCategoriasResource1">
                        </asp:CheckBox>

                    <div style="height:3px;"></div>
		
						<asp:CheckBox ID="chkPSalonVirtual" runat="server"  CssClass="labelNormal"
                       Text="El usuario puede utilizar el libro de trabajo en sus salones de clase" meta:resourcekey="chkPSalonVirtualResource1">
                        </asp:CheckBox>
                    <div style="height:3px;"></div>
				
						<asp:CheckBox ID="chkPContenidos" runat="server"  CssClass="labelNormal"
                       Text="Editar el contenido y sus anexos" meta:resourcekey="chkPContenidosResource1">
                        </asp:CheckBox>
                    <div style="height:3px;"></div>
				
						<asp:CheckBox ID="chkPInterfaceGrafica" runat="server"  CssClass="labelNormal"
                       Text="El usuario puede cambiar la inferface gráfica" Visible="False" meta:resourcekey="chkPInterfaceGraficaResource1">
                        </asp:CheckBox>
				
                    <div style="height:3px;"></div>
						<asp:CheckBox ID="chkPEstadisticas" runat="server"  CssClass="labelNormal"
                       Text="Observar espectómetro" Visible="False" meta:resourcekey="chkPEstadisticasResource1">
                        </asp:CheckBox>
                    <div style="height:3px;"></div>
				
						<asp:CheckBox ID="chkPAdministracion" runat="server"  CssClass="labelNormal"
                       Text="Usuarios administrador" Visible="False" meta:resourcekey="chkPAdministracionResource1">
                        </asp:CheckBox>

    </div>
    </div>


                       <div class="form-group">
    <label class="col-sm-3 control-label">
        
    </label>
    <div class="col-sm-9"> 
        <asp:button id="btnGrabar" runat="server" Text="Grabar" CssClass="btn btn-primary" meta:resourcekey="btnGrabarResource1" ></asp:button>&nbsp;
			<asp:button id="btnBorrar" runat="server" Visible="False" Text="Borrar" CssClass="btn btn-danger" meta:resourcekey="btnBorrarResource1" ></asp:button>
            <cc1:ConfirmButtonExtender ID="btnBorrar_ConfirmButtonExtender" runat="server" 
                       ConfirmText="¿Deseas quitar a este usuario de la lista de permisos especiales?" 
                       Enabled="True" TargetControlID="btnBorrar">
            </cc1:ConfirmButtonExtender>

        &nbsp;<asp:button id="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-default" meta:resourcekey="btnCancelarResource1" ></asp:button>
    </div>
    </div>




  
	    <div style="height:20px;"></div>
					
               
            <asp:GridView ID="gvPermisos" runat="server" DataKeyNames="idPermiso" Width="100%" AutoGenerateColumns="False"
				 GridLines="None" CssClass="table table-hover" meta:resourcekey="gvPermisosResource1" >
				<columns>
                    <asp:hyperlinkfield HeaderText=" " Text="Editar" 
                        DataNavigateUrlFields="idPermiso,idRecurso"
                        DataNavigateUrlFormatString="Permisos.aspx?idRoot={1}&amp;idPermiso={0}" meta:resourcekey="HyperLinkFieldResource1" >
                    <ControlStyle CssClass="LigaVerde" />
                    <headerstyle width="70px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:hyperlinkfield>
                    <asp:boundfield DataField="Nombre" HeaderText="Nombre" meta:resourcekey="BoundFieldResource1">
                    <headerstyle horizontalalign="Left" />
                    </asp:boundfield>
                </columns>
                
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" BackColor="#DBEAF5"></HeaderStyle>
				
                   </asp:GridView>
		
               
               


               </ContentTemplate> 
        </asp:UpdatePanel>    




                 
          </div>
        
        </div>
        

        <div class="col-xs-3">
            <uc5:Menu ID="Menu1" runat="server" />
        </div>


        </div>


               </div>


           </div>

 
    

</asp:Content>



