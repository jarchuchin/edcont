<%@ Page Title="" Language="VB" MasterPageFile="~/MPUsmart01.master" AutoEventWireup="false" CodeFile="Rubrica.aspx.vb" Inherits="Sec_Administracion_Rubrica" %>

<%@ Register src="Controles/MenuAdministracion.ascx" tagname="MenuAdministracion" tagprefix="uc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelIzquierdo" Runat="Server">
    <uc1:MenuAdministracion ID="MenuAdministracion1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

 <div id="Caja">
  <table style="width:100%;"  cellspacing="0" cellpadding="0" border="0" >
    <tr>
        <td style="width:300px;"><asp:Label ID="lblTitulo" runat="server" CssClass="TituloCaja" >Editar rubrica</asp:Label></td>
        <td style="text-align:right;">
           </td>
    </tr>
  </table>

    <div style="height:20px;"></div>

    &nbsp;<table style="width: 100%">
         <tr>
             <td style="width: 194px">
                 Título   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                     ControlToValidate="txtTitulo" Display="Dynamic" 
                     ErrorMessage="El título es un campo requerido">*</asp:RequiredFieldValidator>
                 <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" 
                     runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                 </cc1:ValidatorCalloutExtender></td>
             <td>
                 <asp:TextBox ID="txtTitulo" runat="server" Width="200px"></asp:TextBox>
              
             </td>
         </tr>
         <tr>
             <td style="width: 194px">
                 Descripción<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                     ControlToValidate="txtdescripcion" Display="Dynamic" 
                     ErrorMessage="La descripción es un campo requerido">*</asp:RequiredFieldValidator>
                 <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator2_ValidatorCalloutExtender" 
                     runat="server" Enabled="True" TargetControlID="RequiredFieldValidator2">
                 </cc1:ValidatorCalloutExtender></td>
             <td>
                 <asp:TextBox ID="txtdescripcion" runat="server" Height="100px" 
                     TextMode="MultiLine" Width="350px"></asp:TextBox>
             </td>
         </tr>
         <tr>
             <td style="width: 194px">
                 Horas de elaboración<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                     ControlToValidate="txtHoras" Display="Dynamic" 
                     ErrorMessage="Las horas de elaboración son un campo requerido">*</asp:RequiredFieldValidator>
                 <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator3_ValidatorCalloutExtender" 
                     runat="server" Enabled="True" TargetControlID="RequiredFieldValidator3">
                 </cc1:ValidatorCalloutExtender>
                 <asp:RangeValidator ID="RangeValidator1" runat="server"  MaximumValue="1000" MinimumValue="0"
                     ControlToValidate="txtHoras" ErrorMessage="Las horas deben ser entre 0-1000" 
                     Type="Integer">*</asp:RangeValidator>
                 <cc1:ValidatorCalloutExtender ID="RangeValidator1_ValidatorCalloutExtender" 
                     runat="server" Enabled="True" TargetControlID="RangeValidator1">
                 </cc1:ValidatorCalloutExtender>
             </td>
             <td>
                 <asp:TextBox ID="txtHoras" runat="server" Width="100px"></asp:TextBox>
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
     <div style="height:15px"></div>
     <strong>&nbsp;Lista de rubros</strong>
     <div style="height:15px"></div>

   <asp:GridView id="gvRubros" runat="server" AllowSorting="True" Width="100%"  DataKeyNames="idRubro"
                AutoGenerateColumns="False" GridLines="None">
                <Columns>
                


                   <asp:HyperLinkField DataNavigateUrlFields="idRubrica,idRubro" Text="Editar"  ControlStyle-CssClass="LigaVerde"
                       DataNavigateUrlFormatString="~/sec/Administracion/Rubro.aspx?idRubrica={0}&idRubro={1}" > 
                       <HeaderStyle  HorizontalAlign="Left"  Width="50px"/>
                 </asp:HyperLinkField>
                    

                

                   
                    <asp:TemplateField HeaderText="Título" SortExpression="Titulo">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Titulo") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Titulo") %>' Width="150px" ></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="150px" />
                    </asp:TemplateField>
                
                    <asp:TemplateField HeaderText="Valor" SortExpression="Valor">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Valor") %>'  Width="50px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("Valor") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="50px"  />
                    </asp:TemplateField>
              
             <asp:TemplateField HeaderText="Descripcion" SortExpression="Descripción">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Descripcion") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    
              
                        
                </Columns>
                <HeaderStyle Font-Bold="True" ForeColor="Black" horizontalalign="center" 
                    BackColor="White"/>
                <AlternatingRowStyle BackColor="White" />
                
            </asp:GridView>
            <div style="height:7px;width:100%"></div>
    
     <asp:LinkButton ID="lnkpresentarPanel" runat="server" CssClass="LigaVerde">+ Rubro</asp:LinkButton>
     <div style="height:15px;width:100%"></div>


  </div>
</asp:Content>

