<%@ Page Title="" Language="VB" MasterPageFile="~/MPUsmart01.master" AutoEventWireup="false" CodeFile="Rubro.aspx.vb" Inherits="Sec_Administracion_Rubro" %>


<%@ Register src="Controles/MenuAdministracion.ascx" tagname="MenuAdministracion" tagprefix="uc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelIzquierdo" Runat="Server">
    <uc1:MenuAdministracion ID="MenuAdministracion1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

 <div id="Caja">
  <table style="width:100%;"  cellspacing="0" cellpadding="0" border="0" >
    <tr>
        <td style=""><asp:Label ID="lblTitulo" runat="server" CssClass="TituloCaja" >Editar rubrica</asp:Label></td>
        
    </tr>
  </table>

    <div style="height:20px;"></div>

    &nbsp;<table style="width: 100%">
         <tr>
             <td style="width: 194px">
                 <b __designer:mapid="9e">Titulo
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtTituloRubro" Display="Dynamic" 
                    ErrorMessage="El título es un campo requerido">*</asp:RequiredFieldValidator>
                <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator4_ValidatorCalloutExtender" 
                    runat="server" Enabled="True" TargetControlID="RequiredFieldValidator4">
                </cc1:ValidatorCalloutExtender>
                </b></td>
             <td>
                <asp:TextBox ID="txtTituloRubro" runat="server" width="150px"></asp:TextBox>
              
             </td>
         </tr>
         <tr>
             <td style="width: 194px">
                 <b __designer:mapid="a2">Valor
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtValorRubro" Display="Dynamic" 
                    ErrorMessage="El valor del rubro son un campo requerido">*</asp:RequiredFieldValidator>
                <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator5_ValidatorCalloutExtender" 
                    runat="server" Enabled="True" TargetControlID="RequiredFieldValidator5">
                </cc1:ValidatorCalloutExtender>
                <asp:RangeValidator ID="RangeValidator2" runat="server" 
                    ControlToValidate="txtValorRubro" ErrorMessage="El valor debe ser entre 0-100" 
                    MaximumValue="100" MinimumValue="0" Type="Integer">*</asp:RangeValidator>
                <cc1:ValidatorCalloutExtender ID="RangeValidator2_ValidatorCalloutExtender" 
                    runat="server" Enabled="True" TargetControlID="RangeValidator2">
                </cc1:ValidatorCalloutExtender>
                </b></td>
             <td>
                <asp:TextBox ID="txtValorRubro" runat="server" width="50px"></asp:TextBox>
             </td>
         </tr>
         <tr>
             <td style="width: 194px">
                 <b __designer:mapid="a8">Descripción</b>
            
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                     ControlToValidate="txtDescripcionRubro" Display="Dynamic" 
                     ErrorMessage="La descripción es un campo requerido" 
                     style="font-weight: 700">*</asp:RequiredFieldValidator>
             </td>
             <td>
                <asp:TextBox ID="txtDescripcionRubro" runat="server" width="300px" 
                    Height="50px" TextMode="MultiLine"></asp:TextBox>
             </td>
         </tr>
         <tr>
             <td style="width: 194px">
                 &nbsp;</td>
             <td>
                 <asp:Button ID="btnGrabar" runat="server" Text="Grabar" />
                 <cc1:ConfirmButtonExtender ID="btnGrabar_ConfirmButtonExtender" runat="server" 
                     ConfirmText="¿Deseas grabar esta rúbrica?" Enabled="True" 
                     TargetControlID="btnGrabar">
                 </cc1:ConfirmButtonExtender>
&nbsp;<asp:Button ID="btnBorrar" runat="server" Text="Borrar" />
                 <cc1:ConfirmButtonExtender ID="btnBorrar_ConfirmButtonExtender" runat="server" 
                     ConfirmText="Deseas borrar esta " Enabled="True" TargetControlID="btnBorrar">
                 </cc1:ConfirmButtonExtender>
&nbsp;<asp:Button ID="btnRegresar" runat="server" Text="Regresar" CausesValidation="False" />
               
             </td>
         </tr>
     </table>
  


  </div>
</asp:Content>

