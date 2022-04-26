<%@ Page Language="VB" MasterPageFile="~/MPUsmart01.master" AutoEventWireup="false" CodeFile="Video.aspx.vb" Inherits="Sec_Workbook_Video" title="Untitled Page" %>

<%@ Register src="Controles/Menu.ascx" tagname="Menu" tagprefix="uc5" %>

 <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelIzquierdo" Runat="Server">
    <uc5:Menu ID="Menu1" runat="server" />
      </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
     
         <div id="Caja">
          <asp:Label ID="Label1" runat="server" Text="Agregar video a UM youtube" 
                 CssClass="TituloCaja"  ></asp:Label> 
            <div id="CajaInterna">
     
      <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <div align="left" > <asp:Image ID="Image1" runat="server"  ImageUrl ="~/Images/indicator.gif" /><asp:Label ID="lbltexto" runat="server"   Text="Actualizando datos..." ></asp:Label></div>
                    </ProgressTemplate>
       </asp:UpdateProgress> 
     
       <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
       <ContentTemplate>
          
               <TABLE id="Table6" cellSpacing="1" cellPadding="1" width="100%" border="0">
			<TR>
				<TD align="left">
				<asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    displaymode="List" headertext="Los campos marcados con * son requeridos o no estan en formato apropiado" CssClass="Mediana"
                    Font-Bold="False" />
                    <asp:Label ID="lblNoarchivo" runat="server" ForeColor="Red" Visible="False" 
                    CssClass="Mediana">Se esperaba una pelicula flash con la extension swf. Selecciona la película flash e intenta nuevamente.</asp:Label>
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
                       Text="Ubicación del video"></asp:Label>
                                </TD>
				<TD>
                <asp:DropDownList ID="drpUbicacion" runat="server" CssClass="Chica">
                   </asp:DropDownList>
                </TD>
			</TR>
			<tr>
				<td class="style1"><asp:Label ID="lbltituloContenido" runat="server" 
                       CssClass="Mediana">Título</asp:Label><asp:RequiredFieldValidator 
                       ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitulo" 
                       Display="Dynamic">*</asp:RequiredFieldValidator></td>
				<td><asp:TextBox ID="txtTitulo" runat="server" MaxLength="200" Width="350"></asp:TextBox><asp:TextBox 
                       ID="txtid" runat="server" Visible="False"></asp:TextBox>&#160;
					</td>
			</tr>
			<TR>
				<TD vAlign="top" class="style1"><asp:label id="lblTextoCorto" runat="server" CssClass="Mediana">Descripción 
                    del video</asp:label><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ControlToValidate="txtTextoCorto" Display="Dynamic">*</asp:requiredfieldvalidator><asp:customvalidator id="CustomValidator1" runat="server" ControlToValidate="txtTextoCorto" Display="Dynamic">*</asp:customvalidator></TD>
				<TD><asp:textbox id="txtTextoCorto" runat="server" Columns="55" 
                       TextMode="MultiLine" Rows="7" Height="75px" Width="350px"></asp:textbox></TD>
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
				<TD class="style1"></TD>
				<TD>
					<HR width="100%" SIZE="1">
					</TD>
			</TR>
			<TR>
				<TD class="style1"><asp:label id="lblfile1" runat="server" CssClass="Mediana">Selecciona 
                    el archivo</asp:label></TD>
				<TD>
                    <asp:FileUpload ID="File1" runat="server" Width="350px" />
				</TD>
			</TR>
			<TR>
				<TD class="style1"></TD>
				<TD>
					<asp:Literal id="litflas" runat="server" Visible="False"></asp:Literal><script type="text/javascript" src="../../iefix.js"></script></TD>
			</TR>
			<TR>
				<TD class="style1"></TD>
				<TD>&nbsp;
					</TD>
			</TR>
			<TR>
				<TD class="style1"></TD>
				<TD>&nbsp;</TD>
			</TR>
			<TR>
				<TD class="style1"></TD>
				<TD><asp:button id="btnGrabar" runat="server" CssClass="BotonSubmit" Text="Grabar"></asp:button>&nbsp;
					<asp:button id="btnBorrar" runat="server" Visible="False" CssClass="BotonSubmit" Text="Borrar"></asp:button>
					<cc1:ConfirmButtonExtender ID="btnBorrar_ConfirmButtonExtender" 
                                        runat="server" ConfirmText="¿Desea borrar esta película flash?" 
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

