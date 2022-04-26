<%@ Page Language="VB" MasterPageFile="~/MPUsmart01.master" AutoEventWireup="false" CodeFile="Imagen.aspx.vb" Inherits="Sec_Workbook_Imagen" title="Imagen" ValidateRequest="False" %>
<%@ Register src="Controles/Menu.ascx" tagname="Menu" tagprefix="uc5" %>
 <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelIzquierdo" Runat="Server">
    <uc5:Menu ID="Menu1" runat="server" />
      </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
     
     
     <div id="Caja">
          <asp:Label ID="Label1" runat="server" Text="Agregar o editar imágenes" CssClass="TituloCaja"  ></asp:Label> 
            <div id="CajaInterna">
     
      <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <div align="left" > <asp:Image ID="Image1" runat="server"  ImageUrl ="~/Images/indicator.gif" /><asp:Label ID="lbltexto" runat="server"   Text="Actualizando datos..." ></asp:Label></div>
                    </ProgressTemplate>
       </asp:UpdateProgress>
       <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional" >
               <ContentTemplate>
              <TABLE id="Table6" cellSpacing="1" cellPadding="1" width="100%" border="0">
		<TR>
			<TD >
			 <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    displaymode="List" headertext="Los campos marcados con * son requeridos o no estan en formato apropiado" CssClass="Mediana"
                    Font-Bold="False" />
                    <asp:Label ID="lblNoarchivo" runat="server" ForeColor="Red" Visible="False" 
                    CssClass="Mediana">Se esperaba un archivo. Selecciona un archivo e intenta nuevamente. Si es una imagen utiliza la sección para subir imágenes</asp:Label>
                    &nbsp;<asp:Label ID="lblMensajeBorrar" runat="server" ForeColor="Red" Visible="False" 
                    CssClass="Mediana">Existen elementos relacionados con este contenido</asp:Label>
                    <asp:Label ID="lblMensajeEspacio" runat="server" ForeColor="Red" 
                    Visible="False" CssClass="Mediana">No hay espacio en su cuenta para subir este contenido</asp:Label>
			</TD>
		</TR>
	</TABLE>
	<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="100%" border="0">
		<TR>
			<TD class="style1">
                                    <asp:Label ID="lblUbicacion" runat="server" CssClass="Mediana" 
                       Text="Ubicación del texto"></asp:Label>
                                </TD>
			<TD>
                <asp:DropDownList ID="drpUbicacion" runat="server" CssClass="Chica">
                   </asp:DropDownList>
            </TD>
		</TR>
		<tr>
			<td class="style1">
				<asp:Label ID="lbltituloContenido" runat="server" CssClass="Mediana">Título imagen</asp:Label>
				<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                       ControlToValidate="txtTitulo" Display="Dynamic">*</asp:RequiredFieldValidator></td>
			<td>
				<asp:TextBox ID="txtTitulo" runat="server" Columns="40" MaxLength="200" 
                    Width="350px"></asp:TextBox>
				<asp:TextBox ID="txtid" runat="server" Visible="False"></asp:TextBox></td>
		</tr>
		<TR>
			<TD vAlign="top" class="style1">
				<asp:label id="lblTextoCorto" runat="server" CssClass="Mediana">Descripción</asp:label>
				<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" Display="Dynamic" ControlToValidate="txtTextoCorto">*</asp:requiredfieldvalidator>
				<asp:customvalidator id="CustomValidator1" runat="server" Display="Dynamic" ControlToValidate="txtTextoCorto">*</asp:customvalidator></TD>
			<TD>
				<asp:textbox id="txtTextoCorto" runat="server" Columns="55" Rows="7" 
                    TextMode="MultiLine" Height="80px" Width="350px"></asp:textbox></TD>
		</TR>
		<tr>
            <td class="style1" style="width: 156px" valign="top">
                <asp:Label ID="lbltags" runat="server" CssClass="Mediana">Tags separados por 
                comas</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txttags" runat="server" Columns="55" Height="60px" Rows="7" 
                    TextMode="MultiLine" Width="350px"></asp:TextBox>
            </td>
        </tr>
		<TR>
			<TD class="style1">
				<asp:label id="lblfile1" runat="server" CssClass="Mediana">Selecciona la imagen</asp:label></TD>
			<TD><INPUT id="File1" type="file" name="File1" runat="server"></TD>
		</TR>
		<TR>
			<TD class="style1"></TD>
			<TD>
				<asp:image id="Imagen" runat="server" Visible="False" Width="200px"></asp:image></TD>
		</TR>
		<TR>
			<TD class="style1"></TD>
			<TD>
				<asp:label id="lblNombreOriginal" runat="server" Visible="False" CssClass="Mediana"></asp:label>&nbsp;
				<asp:label id="lblEspacio" runat="server" Visible="False" CssClass="Mediana"></asp:label></TD>
		</TR>
		<TR>
			<TD class="style1"></TD>
			<TD>
				<asp:hyperlink id="lnkDownload" runat="server" Visible="False" CssClass="Mediana">Descargar imagen</asp:hyperlink></TD>
		</TR>
		<TR>
			<TD class="style1"></TD>
			<TD>
				<asp:button id="btnGrabar" runat="server" CssClass="botonsubmit" Text="Grabar"></asp:button>&nbsp;
				<asp:button id="btnBorrar" runat="server" Visible="False" CssClass="botonsubmit" Text="Borrar"></asp:button>			
				<cc1:ConfirmButtonExtender ID="btnBorrar_ConfirmButtonExtender" 
                                        runat="server" ConfirmText="¿Desea borrar este contenido del sistema?" 
                                        Enabled="True" TargetControlID="btnBorrar">
                                    </cc1:ConfirmButtonExtender>
			</TD>
		</TR>
	</TABLE>
           </ContentTemplate> 
                  <Triggers>
                    <asp:PostBackTrigger ControlID="btnGrabar" />
                    </Triggers>

 </asp:UpdatePanel>    

        </div>
    </div>

</asp:Content>

