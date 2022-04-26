<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="AddItemEvaluacion.aspx.vb" Inherits="Sec_SalonVirtual_AddItemEvaluacion" title="Editar evaluación" %>

<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server"  Text="Editar evaluación" ></asp:Label> </h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/default.aspx" ></asp:HyperLink></li>
           <li><asp:HyperLink ID="lnkCurso" runat="server"  Text="Curso nombre"  NavigateUrl="~/sec/Sa/default.aspx" ></asp:HyperLink></li>
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Editar evaluación" ></asp:Label></li>
    </ol>


   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">
   
     <uc22:MenuGeneral ID="MenuGeneral1" runat="server" />

</asp:Content>


<asp:Content ID="contentCentral" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

	  
   <div class="row">

        <div class="col-xs-3">
             <uc1:MenuSalonVirtual ID="MenuSalonVirtual2" runat="server" />
        </div>
        <div class="col-xs-9">

                        
            <div class="panel">
             
                <div class="panel-heading">
                      

                        <h3 class="panel-title"><asp:Label ID="Label6" runat="server" Text="Editar evaluación"></asp:Label></h3>
                </div>
                <div class="panel-body">
	
         
         
        
         
        <table id="Table6" border="0"  width="100%">
      
        
            <tr>
                <td style="width: 175px; padding:2px;">
                    <asp:Label ID="lblTituloEtiqueta" runat="server" Text="Título" Font-Bold="True"></asp:Label>
                </td>
                <td style="padding:2px;">
                    <asp:TextBox ID="txtTitulo" runat="server" Columns="45" MaxLength="150" cssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtTitulo" Display="Dynamic">*</asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtid" runat="server" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 175px">
                    <asp:Label ID="lblValor" runat="server" text="Porcentaje (%)" Font-Bold="True"></asp:Label>
                </td>
                <td style="padding:2px;">
                    <asp:TextBox ID="txtValor" runat="server" Columns="5" MaxLength="3" Width="60px" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtValor" Display="Dynamic">*</asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtValor" Display="Dynamic" MaximumValue="100" MinimumValue="1" Type="Integer">*</asp:RangeValidator>
                </td>
            </tr>
        <tr>
            <td style="width: 175px">
                <asp:Label ID="lblTipo" runat="server"  text="Tipo de evaluación" Font-Bold="True" ></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="rdbTipo" Display="Dynamic" 
                     >*</asp:RequiredFieldValidator>
            </td>
            <td style="padding:2px;">
                <table id="Table4" border="0" cellpadding="1" cellspacing="1" width="100%">
                    <tr>
                        <td width="20">
                            <table id="Table5" border="0" cellpadding="1" cellspacing="1" width="15">
                                <tr>
                                    <td>
                                        <asp:Image ID="Image11" runat="server" ImageUrl="~/Images/eval1.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Image ID="Image10" runat="server" Height="7px" 
                                            ImageUrl="~/Images/transp.gif" Width="1px"  />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Image ID="Image9" runat="server" ImageUrl="~/Images/eval3.gif" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="padding:2px;">
                            <asp:RadioButtonList ID="rdbTipo" runat="server" 
                                meta:resourcekey="rdbTipoResource1">
                                <asp:ListItem Value="1" Text="El alumno deberá enviar una respuesta"  ></asp:ListItem>
                                <asp:ListItem Value="3"  Text="El maestro asigna directamente la calificación." > </asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
            <tr>
            <td  colspan="2" style="padding:2px;">
                <asp:Label ID="lblMensajeBorrar" runat="server" ForeColor="Red" Visible="False" Text="Para poder borrar esta evaluación es necesario eliminar las actividades relacionadas" ></asp:Label>
             
                <asp:Label ID="lblMensajeSistema" runat="server" ForeColor="Red" 
                    Visible="False" text="Los datos alterados no podrán ser sinconizados con el sistema académico. El curso ya fué cerrado." ></asp:Label>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    DisplayMode="List" 
                    HeaderText="Los campos marcados con * son requeridos o no están en el formato apropiado" 
                      />
                <asp:Label ID="lblMensajeSubjetivo" runat="server" Font-Bold="True" 
                    ForeColor="Red" Visible="False" text="El ítem de evaluación no puede tener 
                actividades relacionadas">
                     </asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 175px">
                &nbsp;</td>
            <td>
                &nbsp;&nbsp;</td>
        </tr>
        
            <tr>
                <td style="width: 175px">
                </td>
                <td>
                    <asp:Button ID="btnGrabar" runat="server" CssClass="btn btn-primary" Text="Grabar" />
                    &nbsp;
                    <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-default" Text="Regresar" 
                        Visible="False" />
                    &nbsp;
                    <asp:Button ID="btnBorrar" runat="server" CssClass="btn btn-danger" Text="Borrar" 
                        Visible="False" />
                    <cc1:confirmbuttonextender ID="btnBorrar_ConfirmButtonExtender" runat="server" 
                        ConfirmText="¿Deseas borrar este item de evaluación?" Enabled="True" 
                        TargetControlID="btnBorrar">
                    </cc1:confirmbuttonextender>
                </td>
            </tr>
        
</table>
         
         
         
         </div>
</div>

            </div>
       </div>
    

</asp:Content>

