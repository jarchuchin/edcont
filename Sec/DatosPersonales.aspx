<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="DatosPersonales.aspx.vb" Inherits="Sec_DatosPersonales" title="Editar datos personales" meta:resourcekey="PageResource1" uiculture="auto" Culture="auto" %>

<%@ Register src="Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc1" %>



<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>



<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="Label4" runat="server" Text="Datos personales"></asp:Label></h1>

       
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">
    <uc1:MenuGeneral ID="MenuGeneral1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
  


<div class="row">
	<div class="col-xs-12">
		<div class="panel">
		<%--	<div class="panel-heading">
                 <h3 class="panel-heading"><asp:Label ID="lblTitulo" runat="server" Text="Datos personales" meta:resourcekey="lblTituloResource1"></asp:Label></h3>
            </div>--%>
             <div class="panel-body">
             
          
   <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <div class="text-left" > <asp:Image ID="Image1ss" runat="server"  ImageUrl ="~/Images/indicator.gif" meta:resourcekey="Image1ssResource1" />
                            &nbsp;<asp:Label ID="lbltexto" runat="server"   Text="Actualizando datos..." meta:resourcekey="lbltextoResource1" ></asp:Label></div>
                    </ProgressTemplate>
       </asp:UpdateProgress>
       <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional" >
               <ContentTemplate>

 

<div class="form-horizontal">

    <div class="form-group">
        <label  class="col-sm-3 control-label">

        </label>
        <div  class="col-sm-6 text-center">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server"  DisplayMode="List" HeaderText="Los campos marcados con * son requeridos o no están en el formato apropiado" meta:resourcekey="ValidationSummary1Resource1" />

        </div>
      </div>


     <div class="form-group">
        <label for="inputEmail3" class="col-sm-3 control-label"><asp:Label ID="lblNombre" runat="server" Text="Nombre" meta:resourcekey="lblNombreResource1" ></asp:Label></label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtNombre" runat="server" Enabled="False" MaxLength="10050" CssClass="form-control" meta:resourcekey="txtNombreResource1"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNombre" Display="Dynamic" meta:resourcekey="RequiredFieldValidator3Resource1">*</asp:RequiredFieldValidator>
        </div>
      </div>


      <div class="form-group">
        <label class="col-sm-3 control-label"> <asp:Label ID="lblApellidos" runat="server" Text="Apellidos" meta:resourcekey="lblApellidosResource1" ></asp:Label></label>
        <div class="col-sm-6">
           <asp:TextBox ID="txtApellidos" runat="server" Columns="30" MaxLength="100" Enabled="False" CssClass="form-control" meta:resourcekey="txtApellidosResource1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="txtApellidos" Display="Dynamic" meta:resourcekey="RequiredFieldValidator4Resource1">*</asp:RequiredFieldValidator>
        </div>
      </div>


     <div class="form-group">
        <label class="col-sm-3 control-label"><asp:Label ID="lblSexo" runat="server" text="Sexo" meta:resourcekey="lblSexoResource1" ></asp:Label></label>
        <div class="col-sm-6">
          <asp:DropDownList ID="DropSexo" runat="server" Enabled="False" CssClass="form-control" Width="90px" meta:resourcekey="DropSexoResource1">
            <asp:ListItem Selected="True" Value="F" meta:resourcekey="ListItemResource1">F</asp:ListItem>
            <asp:ListItem Value="M" meta:resourcekey="ListItemResource2">M</asp:ListItem>
          </asp:DropDownList>
        </div>
      </div>

    <div class="form-group">
        <label class="col-sm-3 control-label"> <asp:Label ID="lblFechadeNacimiento" runat="server" Text="Fecha de Nacimiento" meta:resourcekey="lblFechadeNacimientoResource1"></asp:Label></label>
        <div class="col-sm-6">
            <asp:TextBox ID="txtFechaNacimiento" runat="server" MaxLength="15" class="form-control" Enabled="False" CssClass="form-control" meta:resourcekey="txtFechaNacimientoResource1"></asp:TextBox>
            &nbsp;
            <asp:Label ID="txtFormato" runat="server" ForeColor="Red" Text="dd/mm/yyyy" meta:resourcekey="txtFormatoResource1"></asp:Label>
            &nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                ControlToValidate="txtFechaNacimiento" Display="Dynamic" meta:resourcekey="RequiredFieldValidator5Resource1">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                ControlToValidate="txtFechaNacimiento" Display="Dynamic" 
                ValidationExpression="\d{1,2}\/\d{1,2}/\d{4}" meta:resourcekey="RegularExpressionValidator2Resource1">*</asp:RegularExpressionValidator>
            <asp:CustomValidator ID="CustomValidator1" runat="server" 
                ControlToValidate="txtFechaNacimiento" Display="Dynamic" meta:resourcekey="CustomValidator1Resource1">*</asp:CustomValidator>
         </div>
    </div>

 <div class="form-group">
      <label class="col-sm-3 control-label"><asp:Label ID="Label3" runat="server" Text="Foto" meta:resourcekey="Label3Resource1" ></asp:Label></label>
        <div class="col-sm-6">
          <asp:FileUpload ID="FileUpload1" runat="server" meta:resourcekey="FileUpload1Resource1" CssClass="form-control" />
          &nbsp;<asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Max 800 kb"  meta:resourcekey="Label4Resource1"></asp:Label>
          <asp:CustomValidator ID="CustomValidator3" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Solo se pueden subir archivos de imágenes" meta:resourcekey="CustomValidator3Resource1">*</asp:CustomValidator><br />
          <asp:Image ID="Image2" runat="server" width="140px" meta:resourcekey="Image2Resource1"></asp:Image>
         </div>
 </div>

    <div class="form-group">
        <label class="col-sm-3 control-label"><asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Correo electrónico" ></asp:Label>
        </label>
      <div class="col-sm-6">
       
<asp:TextBox ID="txtemailgoogle" runat="server" Columns="30" MaxLength="100" CssClass="form-control" meta:resourcekey="txtemailgoogleResource1"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtemailgoogle" meta:resourcekey="RequiredFieldValidator6Resource1">El correo electrónico es un campo requerido</asp:RequiredFieldValidator>
        &nbsp;<br /><asp:Label ID="Label2" runat="server" Text="Ejemplo: nombreusuario@gmail.com" meta:resourcekey="Label2Resource1"></asp:Label>
        <br /><asp:Label ID="lblEmail2" runat="server" meta:resourcekey="lblEmail2Resource1" >ejem: nombreusuario@gmail.com</asp:Label>
      
          </div>
    </div>
     


<div class="form-group">
    <label class="col-sm-3 control-label">
                    <asp:Label ID="lblwebpage" runat="server" Text="Página web" meta:resourcekey="lblwebpageResource1" ></asp:Label></label>
     <div class="col-sm-6">
                    <asp:TextBox ID="txtwebpage" runat="server" Columns="30" MaxLength="100" CssClass="form-control" meta:resourcekey="txtwebpageResource1"></asp:TextBox>
     </div>
</div>

<div class="form-group">
    <label class="col-sm-3 control-label">
         <asp:Label ID="lblTelefono" runat="server" Text="Télefono" meta:resourcekey="lblTelefonoResource1" ></asp:Label></label>
       <div class="col-sm-6">         
                    <asp:TextBox ID="txtTelefono" runat="server" Columns="30" MaxLength="50" CssClass="form-control" meta:resourcekey="txtTelefonoResource1"></asp:TextBox>
     </div>
</div>
 
<div class="form-group">
    <label class="col-sm-3 control-label">
                        <asp:Label ID="lblDireccion" runat="server" Text="Dirección" meta:resourcekey="lblDireccionResource1" ></asp:Label></label>
     <div class="col-sm-6">
                    <asp:TextBox ID="txtDireccion" runat="server" Columns="30" MaxLength="50" CssClass="form-control" meta:resourcekey="txtDireccionResource1"></asp:TextBox>
     </div>
</div>   
               
<div class="form-group">
    <label class="col-sm-3 control-label">
                        <asp:Label ID="lblCiudad" runat="server" text="Ciudad" meta:resourcekey="lblCiudadResource1"></asp:Label></label>
     <div class="col-sm-6">
                    <asp:TextBox ID="txtCiudad" runat="server" Columns="30" MaxLength="50" CssClass="form-control" meta:resourcekey="txtCiudadResource1"></asp:TextBox>
     </div>
</div>

<div class="form-group">
    <label class="col-sm-3 control-label">
                        <asp:Label ID="lblEstado" runat="server" Text="Estado" meta:resourcekey="lblEstadoResource1" ></asp:Label></label>

     <div class="col-sm-6">
                    <asp:TextBox ID="txtEstado" runat="server" Columns="30" MaxLength="50" CssClass="form-control" meta:resourcekey="txtEstadoResource1"></asp:TextBox>
     </div>
</div>

<div class="form-group">
    <label class="col-sm-3 control-label">
                        <asp:Label ID="lblPais" runat="server" Text="País de origen" meta:resourcekey="lblPaisResource1" ></asp:Label></label>
     <div class="col-sm-6">
                    <asp:DropDownList ID="DropPais" runat="server" CssClass="form-control" meta:resourcekey="DropPaisResource1">
                    </asp:DropDownList>
     </div>
</div>

<div class="form-group">
    <label class="col-sm-3 control-label"><asp:Label ID="lblEtiqueta" runat="server" text="Universidad" meta:resourcekey="lblEtiquetaResource1"></asp:Label></label>
     <div class="col-sm-6">
            <asp:RadioButtonList ID="rdbEmpresas" runat="server" CssClass="radio" meta:resourcekey="rdbEmpresasResource1">
            </asp:RadioButtonList>
     </div>
</div>

<div class="form-group">
    <label class="col-sm-3 control-label"></label>
     <div class="col-sm-6">
    <asp:Button ID="btnGrabar" runat="server" Text="Grabar"  CssClass="btn btn-primary"   />

x
    </div>
</div>
</div>         

       </ContentTemplate>
       <Triggers>
        <asp:PostBackTrigger ControlID="btnGrabar" />
       </Triggers>
    </asp:UpdatePanel>
    
</div>


         </div>


        </div>
    </div>


 
</asp:Content>

<asp:Content ID="Content3" runat="server"  contentplaceholderid="ContentPanelBreadcrumb">


<ol class="breadcrumb" >
  <li><asp:HyperLink ID="HyperLink2" runat="server"  Text="Inicio" NavigateUrl="~/sec/home.aspx" meta:resourcekey="HyperLink2Resource1"></asp:HyperLink></li>
  <li><asp:Literal ID="Literal1" runat="server" Text="Datos personales" meta:resourcekey="Literal1Resource1"></asp:Literal></li>
</ol>


</asp:Content>


