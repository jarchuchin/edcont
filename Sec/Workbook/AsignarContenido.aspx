<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="AsignarContenido.aspx.vb" Inherits="Sec_Workbook_AsignarContenido" title="Untitled Page" ValidateRequest="false"%>

<%@ Register src="Controles/Menu.ascx" tagname="Menu" tagprefix="uc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:label id="Label1" runat="server" Font-Bold="true" Text="Usar o copiar contenido" ></asp:label></h1>
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


<div class="form-horizontal" style="margin: auto; max-width: 100%;">
    
    
     <asp:UpdateProgress id="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                    <ProgressTemplate>
                        <div align="left" > <asp:Image ID="Image1" runat="server"  ImageUrl ="~/Images/indicator.gif" />
                            &nbsp;<asp:Label ID="lbltexto" runat="server"   Text="Ubicando el contenido en el lugar seleccionado..." ></asp:Label></div>
                    </ProgressTemplate>
       </asp:UpdateProgress>
       <asp:UpdatePanel id="UpdatePanel2" runat="server" >
               <ContentTemplate>
               

                  <div class="form-group">
                    <label class="col-sm-2 control-label">
                        <asp:Label ID="Label4" runat="server" Text="Libro de trabajo"></asp:Label>
                    </label>
                    <div class="col-sm-10"> 
                        <asp:Label ID="lblLibro" runat="server" ></asp:Label>
                    </div>
                 </div>

                    <div class="form-group">
                    <label class="col-sm-2 control-label">
                        <asp:Label ID="Label7" runat="server"  Text="Título de contenido"></asp:Label>
                    </label>
                    <div class="col-sm-10"> 
                          <asp:Label ID="lblTitulo" runat="server" ></asp:Label>
                    </div>
                 </div>


                 <div class="form-group">
                    <label class="col-sm-2 control-label">
                        <asp:Label ID="Label3" runat="server"  Text="Fecha de creación"></asp:Label>
                    </label>
                    <div class="col-sm-10"> 
                         <asp:Label ID="lblFecha" runat="server" Font-Bold="True"></asp:Label>
                    </div>
                 </div>

                       <div class="form-group">
                    <label class="col-sm-2 control-label">
                        <asp:Label ID="Label2" runat="server"  Text="Tipo de contenido"></asp:Label>
                    </label>
                    <div class="col-sm-10"> 
                        <asp:Label ID="lblTipo" runat="server"  ></asp:Label>
                    </div>
                 </div>

                    <div class="form-group">
                    <label class="col-sm-2 control-label">
                        <asp:Label ID="Label5" runat="server"  Text="Descripción"></asp:Label>
                    </label>
                    <div class="col-sm-10"> 
                        <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
                    </div>
                 </div>


                    <div class="form-group">
                    <label class="col-sm-2 control-label">
                        <asp:Label ID="Label6" runat="server"   Text="Seleccion la unidad"></asp:Label>
                    </label>
                    <div class="col-sm-10"> 
                         <asp:DropDownList ID="drpUbicacion" runat="server" CssClass="form-control" >
                            </asp:DropDownList>
                    </div>
                 </div>


                   


                       <div class="form-group">
                    <label class="col-sm-2 control-label">

                    </label>
                    <div class="col-sm-10"> 
                            <asp:RadioButtonList ID="rdbTipo" runat="server" CssClass="labelNormal">
                                <asp:ListItem Selected="True" Value="M" Text="Usar el mismo contenido"></asp:ListItem>
                                <asp:ListItem Value="N" Text="Crear una copia nueva"></asp:ListItem>
                            </asp:RadioButtonList>
                    </div>
                 </div>


                       <div class="form-group">
                    <label class="col-sm-2 control-label">

                    </label>
                    <div class="col-sm-10"> 
<asp:Button ID="btnUbicar" runat="server" Text="Grabar"  CssClass="btn btn-success"/>
                             <cc1:ConfirmButtonExtender ID="btnUbicar_ConfirmButtonExtender" runat="server" 
                                 ConfirmText="¿Deseas ubicar el contenido en el lugar seleccionado?" 
                                 Enabled="True" TargetControlID="btnUbicar">
                             </cc1:ConfirmButtonExtender>
                    </div>
                 </div>

               
                  
                 
               
               
               </ContentTemplate>
               </asp:UpdatePanel>
    
    
      
    

</div>

    <div style="height:200px"></div>  
    <asp:Label ID="lblActividadEtiqueta" runat="server" Text="Actividad" Visible="false"></asp:Label>
    <asp:Label ID="lblExamenEtiqueta" runat="server" Text="Examen" Visible="false"></asp:Label>
    <asp:Label ID="lblContenidoEtiqueta" runat="server" Text="Contenido" Visible="false"></asp:Label>
    <asp:Label ID="lblForoEtiueta" runat="server" Text="Foro" Visible="false"></asp:Label>
    

        </div>

        </div>

</asp:Content>

