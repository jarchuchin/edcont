<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="RegistroAdmin.aspx.vb" Inherits="registroAdmin" title="Registro de usuarios" %>



<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>


<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server" Text="Editar usuarios"  ></asp:Label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
   
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>

    
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Administración"  NavigateUrl="~/sec/Administracion/Home.aspx" ></asp:HyperLink></li>
       
       
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Editar usuarios" ></asp:Label></li>
    </ol>


   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">
   
     <uc22:MenuGeneral ID="MenuGeneral1" runat="server" />

</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
    


      <div class="row">

 
        <div class="col-xs-12">

               <div class="panel">
                            <div class="panel-heading">

                                    <h3 class="panel-title">
                                        <asp:Label ID="Label1" runat="server" Text="Editar datos usuarios"></asp:Label>
                                    </h3>
                            </div>
                            <div class="panel-body">


                                   <div id="divMensaje" runat="server"  class="alert alert-success" visible="false">
                                       <asp:Label ID="lblMensaje" runat="server" ></asp:Label>
                    </div>





    <asp:UpdatePanel runat="server" id="content1233">
   <contentTemplate>
<FIELDSET style="WIDTH: 600px"><LEGEND><asp:Label id="lblTitulo" runat="server" Font-Bold="True">Forma de registro</asp:Label></LEGEND>
    
    <TABLE style="WIDTH: 100%" border=0><TBODY>
        <TR><TD colSpan=2><asp:ValidationSummary id="ValidationSummary1" runat="server" DisplayMode="List" HeaderText="Los campos marcados con * son requeridos o no estan en el formato apropiado" CssClass="alert alert-danger"></asp:ValidationSummary></TD></TR>
        <TR><TD><strong>Institución</strong></TD><TD>
            &nbsp;</TD>

        </TR>
        
        <tr>
            <td><asp:DropDownList ID="drpEmpresas" runat="server" Enabled="false" >

                </asp:DropDownList> </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        
        <TR><TD>
            <asp:Label ID="lblLogin" runat="server" Font-Bold="True">Login</asp:Label>
            <asp:RequiredFieldValidator ID="Requiredfieldvalidator2" runat="server" ControlToValidate="txtLogin" Display="Dynamic" ForeColor="Red" ErrorMessage="El login es un campo requerido">*</asp:RequiredFieldValidator>
            <asp:CustomValidator ID="validadorlogin" runat="server" ControlToValidate="txtLogin" Display="Dynamic" ForeColor="Red" ErrorMessage="El login ya existe">*</asp:CustomValidator>
            </TD><TD>
                <asp:Label ID="lblConfirmarPassword0" runat="server" Font-Bold="True">Matrícula</asp:Label>
                <asp:RequiredFieldValidator ID="Requiredfieldvalidator8" runat="server" ControlToValidate="txtLogin" Display="Dynamic" ForeColor="Red" ErrorMessage="La matricula es un campo requerido">*</asp:RequiredFieldValidator>
        </TD></TR>
    <tr>
        <td>
            <asp:TextBox ID="txtLogin" runat="server" CssClass="form-control" MaxLength="12" autocomplete="off"  ></asp:TextBox>
        </td>
        <td>
            <asp:TextBox ID="txtMatricula" runat="server" CssClass="form-control" MaxLength="12"  autocomplete="off"></asp:TextBox>
        </td>
    </tr>
    <TR><TD><asp:Label id="lblCaracteresLogin" runat="server" Font-Italic="True">El login debe tener entre 5 y 10 Caracteres</asp:Label> </TD><TD>&nbsp;</TD></TR><TR><TD>
        <asp:Label ID="lblPassword" runat="server" Font-Bold="True">Password</asp:Label>
        <asp:RequiredFieldValidator ID="Requiredfieldvalidator3" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ForeColor="Red" ErrorMessage="El password es un campo requerido">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ForeColor="Red" ValidationExpression="[A-Za-z0-9]{4,12}" ErrorMessage="El password no esta en el formamto apropiado">*</asp:RegularExpressionValidator>
        &nbsp;</TD><TD>&nbsp;<asp:Label ID="lblConfirmarPassword" runat="server" Font-Bold="True">Confirmar password</asp:Label>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmar" Display="Dynamic" ForeColor="Red" ErrorMessage="El password no coincide con el de confirmación. Verifica que sean iguales">*</asp:CompareValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtConfirmar" Display="Dynamic" ForeColor="#CC0000" ErrorMessage="La confirmación del password es un campo requerido">*</asp:RequiredFieldValidator>
        </TD></TR><TR><TD>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="formControl" MaxLength="12" TextMode="Password"  autocomplete="off" ></asp:TextBox>
            &nbsp;<asp:Label ID="lblPass" runat="server" Visible="true"></asp:Label></TD><TD>
                <asp:TextBox ID="txtConfirmar" runat="server" CssClass="formControl" MaxLength="12" TextMode="Password"  autocomplete="off"></asp:TextBox>
            </TD></TR><TR><TD>
            <asp:Label ID="lblCaracteresPassword" runat="server" Font-Italic="True">4 a 12 caracteres</asp:Label>
            </TD><TD></TD></TR><TR><TD>
        &nbsp;</TD><TD>
            &nbsp;</TD></TR><TR><TD>
            <asp:Label ID="lblNombre" runat="server" Font-Bold="True">Nombre</asp:Label>
            <asp:RequiredFieldValidator ID="Requiredfieldvalidator4" runat="server" ControlToValidate="txtNombre" Display="Dynamic" ForeColor="Red" ErrorMessage="El Nombre es un campo requerido">*</asp:RequiredFieldValidator>
        </TD><TD>
                <asp:Label ID="lblApellidos" runat="server" CssClass="textoNormal-titulo-1" Font-Bold="True">Apellidos</asp:Label>
                <asp:RequiredFieldValidator ID="Requiredfieldvalidator5" runat="server" ControlToValidate="txtApellidos" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
        </TD></TR><TR><TD>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"  autocomplete="off"></asp:TextBox>
        </TD><TD> 
                <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control" MaxLength="100"  autocomplete="off"></asp:TextBox>
        </TD></TR><TR><TD>
            <asp:Label ID="lblSexo" runat="server" Font-Bold="True">Sexo</asp:Label>
        </TD><TD>
            <asp:Label ID="lblFechadeNacimiento" runat="server" Font-Bold="True">Fecha de nacimiento</asp:Label>
                <asp:RequiredFieldValidator ID="Requiredfieldvalidator6" runat="server" ControlToValidate="txtFechaNacimiento" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtFechaNacimiento" Display="Dynamic" ForeColor="Red" ValidationExpression="\d{1,2}\/\d{1,2}/\d{4}">*</asp:RegularExpressionValidator>
                <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtFechaNacimiento" Display="Dynamic" ForeColor="Red">*</asp:CustomValidator>
        </TD></TR>
    <tr>
        <td>
            <asp:DropDownList ID="DropSexo" runat="server" CssClass="cajaChica">
                <asp:ListItem Selected="True" Value="F">Femenino</asp:ListItem>
                <asp:ListItem Value="M">Masculino</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" MaxLength="15" Width="96px"  autocomplete="off"></asp:TextBox>
            <asp:Label ID="txtFormato" runat="server" CssClass="required">dd/mm/aaaa</asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblNombre0" runat="server" Font-Bold="True">Email</asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"  autocomplete="off"></asp:TextBox>
        </td>
        <td>
            <asp:CheckBox ID="chkEsAdministrador" runat="server" Text="Es administrador" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblNombre2" runat="server" Font-Bold="True">Tipo de usuario</asp:Label>
        </td>
        <td>&nbsp;</td>
    </tr>
        <tr>
            <td>
                <asp:DropDownList ID="drpTipoUsuario" runat="server" CssClass="cajaChica">
                    <asp:ListItem Selected="True" Value="Alumno">Alumno</asp:ListItem>
                    <asp:ListItem Value="Docente">Docente</asp:ListItem>
                    <asp:ListItem Value="Administrador">Administrador</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
    <tr>
        <td>
            <asp:CheckBox ID="chkbloqueado" runat="server" Text="Bloquear alumno el acceso al portal" />
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblNombre1" runat="server" Font-Bold="True">Mensaje de finanzas</asp:Label>
        </td>
        <td>&nbsp;</td>
    </tr>
        <tr>
            <td colspan="2">
                <asp:TextBox ID="txtbloqueadoMensaje" runat="server" CssClass="form-control" Height="86px" TextMode="MultiLine" Width="423px"  autocomplete="off"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </TBODY></TABLE></FIELDSET>  <BR />
       
       <asp:Button id="btnGrabar" runat="server"  CssClass="btn btn-success" Text="Grabar"></asp:Button> 
       &nbsp;
                  <asp:Button ID="btnBorrar" runat="server" Text="Borrar usuario"  CssClass="btn btn-danger"   Visible="true" />
         <asp:ConfirmButtonExtender ID="btnBorrar_ConfirmButtonExtender" runat="server" ConfirmText="¿Deseas borrar este usuario? La operación no podrá ser recuperada" Enabled="True" TargetControlID="btnBorrar">
         </asp:ConfirmButtonExtender>
        &nbsp;
       <asp:Button ID="btnRegresar" runat="server" CssClass="btn btn-default" Text="Regresar" CausesValidation="false" />
       &nbsp;

        <asp:Button ID="btnEnviarDatos" runat="server" CssClass="btn btn-info" Text="Enviar email" Visible="false" />
</contentTemplate> 
</asp:UpdatePanel>  
<asp:UpdateProgress id="UpdateProgress1" runat="server" DisplayAfter="200">
        <progresstemplate>
<div align=left><asp:Image id="Image1" runat="server" ImageUrl="~/Images/indicator.gif"></asp:Image> <asp:Label id="lbltexto" runat="server" Text="Grabando datos..."></asp:Label></div>
</progresstemplate>
    </asp:UpdateProgress>


                                </div>
                   </div>
            


            </div>
          </div>

</asp:Content>

