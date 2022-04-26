<%@ Page Language="VB" MasterPageFile="~/MPUsmart01.master" AutoEventWireup="false" CodeFile="Texto.aspx.vb" Inherits="Sec_Workbook_Texto" title="Texto o lectura" ValidateRequest="False" %>
<%@ Register src="Controles/Menu.ascx" tagname="Menu" tagprefix="uc5" %>
<%@ Register src="controles/showadjuntosedicion.ascx" tagname="showadjuntosedicion" tagprefix="uc1" %>
<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc2" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelIzquierdo" Runat="Server">
    <uc5:Menu ID="Menu1" runat="server" />
      </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
     
      <div id="Caja">
             
             <asp:label id="lblTitulo" runat="server" CssClass="TituloCaja">Editar lectura o texto</asp:label>
            <div id="CajaInterna">
     
     
     
      <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <div align="left" > <asp:Image ID="Image1" runat="server"  ImageUrl ="~/Images/indicator.gif" />
                            &nbsp;<asp:Label ID="lbltexto" runat="server"   Text="Actualizando datos..." ></asp:Label></div>
                    </ProgressTemplate>
       </asp:UpdateProgress>
       <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional" >
               <ContentTemplate>
              
                 


<table id="Table3" border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td>
            <br />
            <table id="Table7" border="0" cellpadding="1" cellspacing="1" width="100%">
                <tr>
                    <td>
                        <table id="Table10" border="0" cellpadding="1" cellspacing="1" width="100%">
                            <tr>
                                <td >
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                        displaymode="List" headertext="Los campos marcados con * son requeridos o no estan en formato apropiado" CssClass="Mediana"
                                        Font-Bold="False" />
                                    <asp:Label ID="lblMensajeBorrar" runat="server" ForeColor="Red" Visible="False" 
                                        CssClass="Mediana">Existen elementos relacionados con este contenido</asp:Label>
                                    <asp:Label ID="lblMensajeEspacio" runat="server" ForeColor="Red" 
                                        Visible="False" CssClass="Mediana">No hay espacio en su cuenta para subir este contenido</asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table id="Table5" border="0" cellpadding="1" cellspacing="1" width="100%">
                            <tr>
                                <td width="100">
                                    <asp:Label ID="lblUbicacion" runat="server" CssClass="Mediana" 
                                        Text="Ubicación del texto"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpUbicacion" runat="server" CssClass="Chica" >
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td width="100">
                                    <asp:Label ID="lbltituloContenido" runat="server" CssClass="Mediana">Titulo</asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="txtTitulo" Display="Dynamic">*</asp:RequiredFieldValidator>
                                  
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTitulo" runat="server" MaxLength="200" Width="250px"></asp:TextBox>
                                    <asp:TextBox ID="txtid" runat="server" Visible="False"></asp:TextBox>
                                    &nbsp;
                                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="LigaVerde">Vista 
                                    previa</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td width="100">
                                    <asp:Label ID="lblLectura" runat="server" CssClass="Mediana">Texto</asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                        ControlToValidate="txtMensaje" Display="Dynamic">*</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                     <div style="height:3px;"></div>
                   
                     <asp:TextBox ID="txtMensaje" TextMode="MultiLine" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>


                      <script>
                          $(document).ready(function () {
                              $("#txtMensaje").cleditor({
                                  height: 250,
                                  controls: // controls to add to the toolbar
                              "bold italic underline strikethrough subscript superscript | font size " +
                              "style | color highlight removeformat | bullets numbering | outdent " +
                              "indent | alignleft center alignright justify | undo redo | " +
                              "rule image link unlink | cut copy paste pastetext | print source",
                                  fonts: // font names in the font popup
                             "Verdana, Arial,Arial Black,Comic Sans MS,Courier New,Narrow,Garamond," +
                             "Georgia,Impact,Sans Serif,Serif,Tahoma,Trebuchet MS",
                                  bodyStyle:
                                      "margin:4px; font:10pt Verdana,Arial; cursor:text"
                              });

                          });
                    </script>          


                    <div style="height:20px;"></div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="1">
                                    <asp:Label ID="lbltags" runat="server" CssClass="Mediana">Tags separados por 
                                    comas</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txttags" runat="server" Columns="55" Height="60px" Rows="7" 
                                        TextMode="MultiLine" Width="442px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                                        <td colspan="1" width="150">
                                                            &nbsp;</td>
                                                        <td>
                                                             <asp:Label ID="lblArchivos1" runat="server" CssClass="Chica">Para subir más de dos archivos utilice nuevamente esta pantalla
                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="1" width="150">
                                                            &nbsp;</td>
                                                        <td>
                                                            <asp:Label ID="lblfile4" runat="server" CssClass="Mediana" Font-Bold="False">Subir 
                                                            archivos o imágenes</asp:Label>
                                                        </td>
                            </tr>
                                                    <tr>
                                                        <td colspan="1" width="150">
                                                            &nbsp;</td>
                                                        <td>
                                                            <asp:FileUpload ID="File1" runat="server" Width="350px" />
                                                            <br />
                                                            <asp:FileUpload ID="File2" runat="server" Width="350px" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="1" width="150">
                                                            <asp:Label ID="lblfile2" runat="server" CssClass="Mediana" Font-Bold="False">Archivos
                                                            </asp:Label>
                                                        </td>
                                                        <td><uc1:showadjuntosedicion ID="CUArchivos" runat="server" /></td>
                                                    </tr>
													<tr>
                                                        <td colspan="1" width="150">
                                                            <asp:Label ID="lblfile3" runat="server" CssClass="Mediana" Font-Bold="False">Imágenes</asp:Label>
                                                        </td>
                                                        <td><uc1:showadjuntosedicion ID="CUImagenes" runat="server" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="1" width="150">
                                                            <asp:Label ID="Label1" runat="server" CssClass="Mediana" Font-Bold="False">Películas</asp:Label>
                                                        </td>
                                                        <td><uc1:showadjuntosedicion ID="CUFlash" runat="server" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <hr />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="1" width="150px">
                                                            &nbsp;</td>
                                                        <td>
                                                            <asp:Label ID="lblfile5" runat="server" CssClass="Mediana" Font-Bold="False">Anexar 
                                                            ligas y referencias</asp:Label>
                                                        </td>
                            </tr>
                                                    <tr>
                                                        <td colspan="1" width="150">
                                                            <asp:Label ID="lblLigaTitulo" runat="server" CssClass="Mediana">Título</asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtLigatitulo" runat="server" Columns="30" MaxLength="200" 
                                                                Width="250px"></asp:TextBox>
                                                        </td>
                                                    </tr>
													<tr>
                                                        <td colspan="1" width="150">
                                                            <asp:Label ID="lblLigaUrl" runat="server" CssClass="Mediana">URL ejem: http://google.com </asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtLigaurl" runat="server" Columns="40" MaxLength="200" 
                                                                Width="250px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="1" width="150">
                                                            <asp:Label ID="lblLigas" runat="server" CssClass="Mediana" Font-Bold="False">Ligas
                                                            </asp:Label>
                                                        </td>
                                                        <td>
                                                             <uc1:showadjuntosedicion ID="CULigas" runat="server" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="1" width="150">
                                                            &nbsp;</td>
                                                        <td>
                                                            <asp:Button ID="btnGrabar" runat="server" CssClass="BotonSubmit" 
                                                                Text="Grabar" />
                                                            &nbsp;<asp:Button ID="btnBorrar" runat="server" CssClass="BotonSubmit" Text="Borrar" 
                                                                Visible="False" />
                                                            <cc1:ConfirmButtonExtender ID="btnBorrar_ConfirmButtonExtender" runat="server" 
                                                                ConfirmText="¿Desea borrar este contenido del sistema?" Enabled="True" 
                                                                TargetControlID="btnBorrar">
                                                            </cc1:ConfirmButtonExtender>
                                                            &nbsp;</td>
                                                    </tr>
                        </table>
                       
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
                 </ContentTemplate> 
                  <Triggers>
                    <asp:PostBackTrigger ControlID="btnGrabar" />
                    <asp:PostBackTrigger ControlID="LinkButton1" />
                    
                    </Triggers>

               
 </asp:UpdatePanel>    

</div>
</div>

</asp:Content>

