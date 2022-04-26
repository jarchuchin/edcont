<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="AddSalonVirtual.aspx.vb" Inherits="Sec_SalonVirtual_AddSalonVirtual" title="Salón virtual" %>

<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server" Text="Preguntas del grupo" ></asp:Label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/default.aspx" ></asp:HyperLink></li>
       <li><asp:HyperLink ID="lnkCurso" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/Sa/default.aspx" ></asp:HyperLink></li>
      <li class="active"><asp:Label ID="lblCursoBread" runat="server" Text="Editar datos generales"  ></asp:Label></li>
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
                        <h3 class="panel-title"><asp:Label ID="lbltitulo" runat="server" Text="Datos generales del curso"></asp:Label></h3>
                </div>
                <div class="panel-body">
     

                       <div style="height:25px;"></div>


 
                   <table id="Table4" border="0" cellpadding="3" cellspacing="1" width="100%">
                       
                       <tr>
                           <td colspan="2" style="padding:3px;">
                               <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                   DisplayMode="List" HeaderText="Los campos marcados con * son requeridos o no tienen el formato apropiado" ForeColor="Red" />
                               <asp:Label ID="lblMensajeBorrar" runat="server" ForeColor="Red" Visible="False">Para 
                               borrar, debes eliminar todos los elementos asociados. (Alumnos,&nbsp; Esquema de evaluación, etc)</asp:Label>
                               <asp:HyperLink ID="lnkmensajebook" runat="server"  ForeColor="Red" Visible="False">Para activar este curso debes   seleccionar algún libro de trabajo o da clic aquí para crear uno</asp:HyperLink>
                           </td>
                       </tr>
                       <tr>
                           <td width="150">
                               <asp:Label ID="lblLibros" runat="server">Libro que utilizará 
                               </asp:Label>
                           </td>
                           <td style="padding:3px;">
                               <asp:DropDownList ID="drpLibros" runat="server" CssClass="form-control" 
                                   Visible="False" Height="35px">
                               </asp:DropDownList>
                               <asp:Label ID="txtLibro" runat="server" Font-Italic="True" Font-Bold="true"></asp:Label>
                               <asp:CustomValidator ID="CustomValidator4" runat="server" 
                                   ControlToValidate="drpLibros">*</asp:CustomValidator>
                               <asp:RequiredFieldValidator ID="ValidadorLibro" runat="server" 
                                   ControlToValidate="drpLibros" Display="Dynamic">*</asp:RequiredFieldValidator>
                               <asp:Label ID="lblcrearlibro" runat="server" 
                                     Text="---Crear libro nuevo en blanco---" 
                                   Visible="False"></asp:Label>
                               &nbsp;&nbsp;&nbsp;&nbsp;
                               <asp:HyperLink ID="lnkQuitarLibro" runat="server" CssClass="btn btn-danger btn-sm" Visible="false">Cambiar libro de trabajo</asp:HyperLink>
                           </td>
                       </tr>
                       <tr>
                           <td width="150">
                               <asp:Label ID="Label3" runat="server">Institución 
                               </asp:Label>
                           </td>
                           <td style="padding:3px;">
                                <asp:DropDownList ID="drpEmpresas" runat="server" Enabled="false" class="form-control" Width="350px" Height="35px">

                               </asp:DropDownList> 
                           </td>
                        </tr>
                       <tr>
                           <td width="150">
                               <asp:Label ID="lblNombre" runat="server" >Nombre</asp:Label>
                           </td>
                           <td style="padding:3px;">
                               <asp:TextBox ID="txtNombre" runat="server" Columns="45" Enabled="True" 
                                   MaxLength="100" CssClass="form-control" Autocomplete="Off"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                   ControlToValidate="txtNombre" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                           </td>
                       </tr>
                       <tr>
                           <td width="150">
                               <asp:Label ID="lblFechaInicio" runat="server" CssClass="Mediana">Fecha de inicio</asp:Label>
                           </td>
                           <td style="padding:3px;" class="form-inline">
                               <asp:TextBox ID="txtFechaInicio" runat="server" Columns="13" CssClass="form-control" Width="120px"  Autocomplete="Off" ></asp:TextBox>
                               <cc1:CalendarExtender ID="txtFechaInicio_CalendarExtender" runat="server" 
                                   Enabled="True" TargetControlID="txtFechaInicio">
                               </cc1:CalendarExtender>
                               &nbsp;
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                   ControlToValidate="txtFechaInicio" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                               <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                   ControlToValidate="txtFechaInicio" Display="Dynamic" 
                                   ValidationExpression="\d{1,2}\/\d{1,2}/\d{4}" ForeColor="Red">*</asp:RegularExpressionValidator>
                               <asp:CustomValidator ID="CustomValidator1" runat="server" 
                                   ControlToValidate="txtFechaInicio" Display="Dynamic" ForeColor="Red">*</asp:CustomValidator>
                               <asp:Label ID="lblFormato1" runat="server" ForeColor="Red">dd/mm/aaaa</asp:Label>
                           </td>
                       </tr>
                       <tr>
                           <td width="150">
                               <asp:Label ID="lblFechaFin" runat="server">Fecha de 
                               finalización</asp:Label>
                           </td>
                           <td style="padding:3px;"  class="form-inline">
                               <asp:TextBox ID="txtFechaFin" runat="server" Columns="13" CssClass="form-control" Width="120px"   Autocomplete="Off"></asp:TextBox>
                               <cc1:CalendarExtender ID="txtFechaFin_CalendarExtender" runat="server" 
                                   Enabled="True" TargetControlID="txtFechaFin">
                               </cc1:CalendarExtender>
                               &nbsp;
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                   ControlToValidate="txtFechaFin" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                               <asp:RegularExpressionValidator ID="Regularexpressionvalidator2" runat="server" 
                                   ControlToValidate="txtFechaFin" Display="Dynamic" 
                                   ValidationExpression="\d{1,2}\/\d{1,2}/\d{4}" ForeColor="Red">*</asp:RegularExpressionValidator>
                               <asp:CustomValidator ID="Customvalidator2" runat="server" 
                                   ControlToValidate="txtFechaFin" Display="Dynamic" ForeColor="Red">*</asp:CustomValidator>
                               <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                   ControlToCompare="txtFechaInicio" ControlToValidate="txtFechaFin" 
                                   Display="Dynamic" Operator="GreaterThan" Type="Date" ForeColor="Red">*</asp:CompareValidator>
                               <asp:Label ID="lblFormato2" runat="server" ForeColor="Red">dd/mm/aaaa</asp:Label>
                           </td>
                       </tr>
                       <tr>
                           <td width="150">
                               <asp:Label ID="lblHorarioAtencion" runat="server" 
                                   >Horario de atención</asp:Label>
                           </td>
                           <td style="padding:3px;">
                               <asp:TextBox ID="txtHorarioAtencion" runat="server" Columns="45" CssClass="form-control" 
                                   MaxLength="100"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                   ControlToValidate="txtHorarioAtencion" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                           </td>
                       </tr>
                        <tr>
                           <td width="150">
                               <asp:Label ID="Label2" runat="server" >Liga a aula virtual externa</asp:Label>
                           </td>
                           <td style="padding:3px;">
                               <asp:TextBox ID="txtLigaSalonVirtual" runat="server"  Enabled="True" 
                                   MaxLength="250" CssClass="form-control"></asp:TextBox>
                             
                           </td>
                       </tr>
                       <tr>
                           <td width="150">
                               <asp:Label ID="lblStatus" runat="server" >Estado del curso</asp:Label>
                           </td>
                           <td style="padding:3px;">
                               <asp:RadioButtonList ID="rdbStatus" runat="server" RepeatDirection="Horizontal">
                                   <asp:ListItem Selected="True" Value="1">En curso</asp:ListItem>
                                   <asp:ListItem Value="0">Terminado</asp:ListItem>
                               </asp:RadioButtonList>
                           </td>
                       </tr>
                       <tr>
                           <td width="150">
                               <asp:Label ID="lblClaveID1" runat="server" >Clave del curso</asp:Label>
                           </td>
                           <td style="padding:3px;">
                               <asp:TextBox ID="txtClaveID1" runat="server" CssClass="form-control" Width="120px"  MaxLength="30"></asp:TextBox>
                           </td>
                       </tr>
                       <tr>
                           <td width="150">
                               <asp:Label ID="lblClaveID2" runat="server" CssClass="Mediana" 
                                   Visible="False">Clave del curso</asp:Label>
                           </td>
                           <td style="padding:3px;">
                               <asp:TextBox ID="txtClaveID2" runat="server" MaxLength="30" Visible="False"></asp:TextBox>
                           </td>
                       </tr>
                       <tr>
                           <td width="150">&nbsp;</td>
                           <td>&nbsp; &nbsp;<asp:CheckBox ID="chkpermitirVerExamenes" runat="server" Text="Permitir ver los examenes sin estar calendarizados" />
                           </td>
                       </tr>

                         <tr>
                           <td width="150">   <b>Imagen display</b></td>
                           <td>  <asp:FileUpload ID="fuInicial" runat="server" Height="35px" Width="250px" />
                                 <div style="height:5px"></div>
                                 <asp:image ID="imgInicial" runat="server" Height="120px" Visible="false" />


                           </td>
                       </tr>

                         <tr>
                           <td width="150">  <b>Video display</b></td>
                           <td>  <asp:FileUpload ID="fuVideo" runat="server" Height="35px" Width="250px" />
                                 <div style="height:5px"></div>
                                 <asp:literal ID="litVideo" runat="server" Visible="false" />
                                <div style="height:5px"></div>
                                <asp:LinkButton ID="lnkBorrarVideo" runat="server" Text="Eliminar video" ForeColor="Red"></asp:LinkButton></td>
                       </tr>

                         <tr>
                           <td width="150"><b>Empotrar video para display</b></td>
                           <td>    <asp:textbox ID="txtEmpotrado" runat="server" Width="342px" Height="250px" TextMode="MultiLine"></asp:textbox>
</td>
                       </tr>


                       <tr>
                           <td width="150">&nbsp;</td>
                           <td>&nbsp;</td>
                       </tr>
                       <tr>
                           <td width="150">
                           </td>
                           <td>
                               <asp:Button ID="btnGrabar" runat="server" CssClass="btn btn-success" Text="Grabar" />
                               &nbsp;<asp:Button ID="btnBorrar" runat="server" CssClass="btn btn-default" Text="Borrar" 
                                   Visible="False" />
                           </td>
                       </tr>
                       <tr>
                           <td width="150">
                               &nbsp;</td>
                           <td>
                               &nbsp;</td>
                       </tr>
                       <tr>
                           <td width="150">
                               &nbsp;</td>
                           <td>
                               <asp:HyperLink ID="lnkCompartirRoom" runat="server" 
                                   NavigateUrl="CompartirRoom.aspx">Compartir Sala de videoconferencia BBB</asp:HyperLink>
                           </td>
                       </tr>
                       <tr>
                           <td width="150">
                               &nbsp;</td>
                           <td>
                               <asp:Button ID="btnCrearVirtualRom" runat="server" 
                                   Text="Crear room en BigBlueButton" Visible="False" />
                           </td>
                       </tr>
                       <tr>
                           <td width="150">
                               &nbsp;</td>
                           <td>
                               <asp:Label ID="Label1" runat="server"></asp:Label>
                           </td>
                       </tr>
                   </table>
               
         

   </div>
                </div>

            </div>

      </div>



    
        <asp:Label ID="labelCursosComoDocente" runat="server" Text="Cursos como docente" Visible="false"></asp:Label>
    <asp:Label ID="labelCursosComoAlumno" runat="server" Text="Label"  Visible="false"></asp:Label>



           
</asp:Content>

