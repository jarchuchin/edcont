<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="datosSalon.aspx.vb" Inherits="Sec_Administracion_datosSalon" title="Untitled Page" %>




<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>



<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>





<%@ Register src="../SalonVirtual/Controles/displayEstadisticasSalon.ascx" tagname="displayEstadisticasSalon" tagprefix="uc1" %>





<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server" Text="Datos del curso"  ></asp:Label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
   
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>

    
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Administración"  NavigateUrl="~/sec/Administracion/default.aspx" ></asp:HyperLink></li>
       
       
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Datos del curso" ></asp:Label></li>
    </ol>


   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">
   
     <uc22:MenuGeneral ID="MenuGeneral1" runat="server" />

</asp:Content>




<asp:Content ID="contentCentral" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

	  <div class="row">

 
        <div class="col-xs-12">


              
                       <div class="panel">
                            <div class="panel-heading"> <h3 class="panel-title">
                                        <asp:Label ID="lblTitulo" runat="server" Text="Datos generales del curso"></asp:Label>
                                    </h3>
                            </div>
                            <div class="panel-body">
     

               
                   <table id="Table4" border="0" cellpadding="1" cellspacing="1" width="100%">
                       
                       <tr>
                           <td colspan="2" >
                               <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                   DisplayMode="List" HeaderText="Los campos marcados con * son requeridos o no tienen el formato apropiado" />
                               <asp:Label ID="lblMensajeBorrar" runat="server" ForeColor="Red" Visible="False">Para 
                               borrar, debes eliminar todos los elementos asociados. (Alumnos,&nbsp; Esquema de evaluación, etc)</asp:Label>
                               <asp:HyperLink ID="lnkmensajebook" runat="server"  ForeColor="Red" Visible="False">Para activar este curso debes   seleccionar algún libro de trabajo o da clic aquí para crear uno</asp:HyperLink>
                           </td>
                       </tr>
                       <tr>
                           <td width="150">
                               &nbsp;</td>
                           <td>
                               <asp:Label ID="lblLibros" runat="server" CssClass="Mediana">Libro que utilizará 
                               este salón virtual</asp:Label>
                           </td>
                       </tr>
                       <tr>
                           <td width="150">
                               <b></b></td>
                           <td style="height:40px;">
                               <asp:Label ID="txtLibro" runat="server" Font-Italic="True" Font-Bold="true"></asp:Label>
                               &nbsp;&nbsp;
                               <asp:Button ID="btnCambiarlibro" runat="server" CausesValidation="False" 
                                   Text="Quitar" CssClass="btn btn-danger btn-sm" />
                           </td>
                       </tr>
                       <tr>
                           <td width="150">
                               <b>
                               <asp:Label ID="lblNombre" runat="server" CssClass="Mediana">Nombre</asp:Label>
                               </b>
                           </td>
                                <td style="padding:4px;">
                               <asp:TextBox ID="txtNombre" runat="server" 
                                   MaxLength="100" Enabled="False" CssClass="form-control" Width="300px"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                   ControlToValidate="txtNombre" Display="Dynamic">*</asp:RequiredFieldValidator>
                           </td>
                       </tr>
                       <tr>
                           <td width="150">
                               <b>
                               <asp:Label ID="lblFechaInicio" runat="server" CssClass="Mediana">Fecha de inicio</asp:Label>
                               </b>
                           </td>
                           <td class="form-inline"  style="padding:4px;" >
                               <asp:TextBox ID="txtFechaInicio" runat="server" CssClass="form-control" Width="180px" ></asp:TextBox>
                               <cc1:CalendarExtender ID="txtFechaInicio_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtFechaInicio">
                               </cc1:CalendarExtender>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                   ControlToValidate="txtFechaInicio" Display="Dynamic">*</asp:RequiredFieldValidator>
                               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                   ControlToValidate="txtFechaInicio" Display="Dynamic" 
                                   ValidationExpression="\d{1,2}\/\d{1,2}/\d{4}">*</asp:RegularExpressionValidator>
                               <asp:CustomValidator ID="CustomValidator1" runat="server" 
                                   ControlToValidate="txtFechaInicio" Display="Dynamic">*</asp:CustomValidator>
                               <asp:Label ID="lblFormato1" runat="server" ForeColor="Red">dd/mm/aaaa</asp:Label>
                           </td>
                       </tr>
                       <tr>
                           <td width="150">
                               <b>
                               <asp:Label ID="lblFechaFin" runat="server" CssClass="Mediana">Fecha de 
                               finalización</asp:Label>
                               </b>
                           </td>
                           <td  class="form-inline" style="padding:4px;">
                               <asp:TextBox ID="txtFechaFin" runat="server" CssClass="form-control" Width="180px" ></asp:TextBox>
                               <cc1:CalendarExtender ID="txtFechaFin_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtFechaFin">
                               </cc1:CalendarExtender>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                   ControlToValidate="txtFechaFin" Display="Dynamic">*</asp:RequiredFieldValidator>
                               <asp:RegularExpressionValidator ID="Regularexpressionvalidator2" runat="server" 
                                   ControlToValidate="txtFechaFin" Display="Dynamic" 
                                   ValidationExpression="\d{1,2}\/\d{1,2}/\d{4}">*</asp:RegularExpressionValidator>
                               <asp:CustomValidator ID="Customvalidator2" runat="server" 
                                   ControlToValidate="txtFechaFin" Display="Dynamic">*</asp:CustomValidator>
                               <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                   ControlToCompare="txtFechaInicio" ControlToValidate="txtFechaFin" 
                                   Display="Dynamic" Operator="GreaterThan" Type="Date" Width="180px">*</asp:CompareValidator>
                               <asp:Label ID="lblFormato2" runat="server" ForeColor="Red">dd/mm/aaaa</asp:Label>
                           </td>
                       </tr>
                       <tr>
                           <td width="150">
                               <b>
                               <asp:Label ID="lblHorarioAtencion" runat="server" 
                                   CssClass="Mediana">Horario de atención</asp:Label>
                               </b>
                           </td>
                           <td class="form-inline"  style="padding:4px;">
                               <asp:TextBox ID="txtHorarioAtencion" runat="server" 
                                   MaxLength="100" CssClass="form-control" Width="300px"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                   ControlToValidate="txtHorarioAtencion" Display="Dynamic">*</asp:RequiredFieldValidator>
                           </td>
                       </tr>
                       <tr>
                           <td width="150">
                               <b>
                               <asp:Label ID="lblCalificacionMaxima" runat="server" 
                                   CssClass="Mediana">Calificación máxima</asp:Label>
                               </b>
                           </td>
                              <td class="form-inline"  style="padding:4px;">
                               <asp:TextBox ID="txtCalificacionMaxima" runat="server" 
                                   MaxLength="6" CssClass="form-control">100</asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                   ControlToValidate="txtCalificacionMaxima" Display="Dynamic" CssClass="form-control" Width="70px">*</asp:RequiredFieldValidator>
                               <asp:CustomValidator ID="Customvalidator3" runat="server" 
                                   ControlToValidate="txtCalificacionMaxima" Display="Dynamic">*</asp:CustomValidator>
                           </td>
                       </tr>
                       <tr>
                           <td width="150">
                               <b>
                               <asp:Label ID="lblStatus" runat="server" CssClass="Mediana">Estado del curso</asp:Label>
                               </b>
                           </td>
                           <td class="form-inline"  style="padding:4px;">
                               <asp:RadioButtonList ID="rdbStatus" runat="server" RepeatDirection="Horizontal">
                                   <asp:ListItem Selected="True" Value="1">En curso</asp:ListItem>
                                   <asp:ListItem Value="0">Terminado</asp:ListItem>
                               </asp:RadioButtonList>
                           </td>
                       </tr>
                       <tr>
                           <td width="150">
                               <b>
                               <asp:Label ID="lblClaveID1" runat="server" CssClass="Mediana">Clave del curso</asp:Label>
                               </b>
                           </td>
                             <td class="form-inline"  style="padding:4px;">
                               <asp:TextBox ID="txtClaveID1" runat="server"  MaxLength="30" Enabled="False" CssClass="form-control" Width="180px"></asp:TextBox>
                           </td>
                       </tr>
                       <tr>
                           <td width="150">
                               <b>
                               <asp:Label ID="lblClaveID2" runat="server" CssClass="Mediana" 
                                   Visible="False">Clave del curso</asp:Label>
                               </b>
                           </td>
                              <td class="form-inline"  style="padding:4px;">
                               <asp:TextBox ID="txtClaveID2" runat="server" MaxLength="30" Visible="False" CssClass="form-control" Width="180px"></asp:TextBox>
                           </td>
                       </tr>
                       <tr>
                           <td width="150">
                               <b>
                               <asp:Label ID="lblUsuarios" runat="server">Asignado a:</asp:Label>
                               </b>
                           </td>
                          <td class="form-inline"  style="padding:4px;">
                               <asp:DropDownList ID="drpUsuarios" runat="server" AutoPostBack="True" 
                                   CssClass="form-control" Width="180px" >
                               </asp:DropDownList>
                           </td>
                       </tr>
                       <tr>
                           <td width="150">
                               &nbsp;</td>
                           <td>
                               <asp:Label ID="lblsincronizacion" runat="server" Font-Bold="True" 
                                   ForeColor="Red"></asp:Label>
                               <asp:Label ID="lblMensajeSistema" runat="server" ForeColor="Red" 
                                   Visible="False">Los datos alterados no podrán ser sinconizados con el 
                sistema académico. El curso ya fué cerrado.</asp:Label>
                               <asp:Label ID="lblmensaje" runat="server" ForeColor="Red" 
                                   Text="El curso no puede ser sincronizado porque ya ha sido evaluado en el sistema académico" 
                                   Visible="False"></asp:Label>
                           </td>
                       </tr>
                       <tr>
                           <td width="150" style="height: 33px">
                           </td>
                           <td style="height: 33px">
                               <asp:Button ID="btnGrabar" runat="server" CssClass="btn btn-success" 
                                   Text="Grabar" />

                               <asp:HyperLink ID="lnkIngresar" runat="server" CssClass="btn btn-default" Text="Ingresar al curso"></asp:HyperLink>
                               &nbsp;<asp:Button ID="btnActualizar" runat="server" Text="Actualizar calificaciones" CssClass="btn btn-warning" />
                               <cc1:ConfirmButtonExtender
                                   ID="ConfirmButtonExtender1" runat="server" TargetControlID="btnActualizar" 
                                   ConfirmText="Las calificaciones serán actualizadas. ¿Desea continuar?">
                               </cc1:ConfirmButtonExtender>
                           </td>
                       </tr>
                   </table>
               
                   <br />
               
  

                     </div>

                           </div>
                     </div>

          </div>
          



      <uc1:displayEstadisticasSalon ID="displayEstadisticasSalon1" runat="server" />
</asp:Content>

