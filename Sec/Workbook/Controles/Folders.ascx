<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Folders.ascx.vb" Inherits="Sec_Workbook_Controles_Folders" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<head>
    <style type="text/css">
        .style1
        {
            width: 198px;
             text-align :center;
        }
        .style2
        {
            width: 254px;
        }
        .style4
        {
            width: 15px;
        }
        .style5
        {
            width: 17px;
        }
    </style>
</head>
<table border="0" style="width: 100%">
<tr>
<td>
    <asp:LinkButton ID="lnkMapa1" runat="server" CausesValidation="False" 
        CssClass="Mediana" Font-Bold="True"></asp:LinkButton>
<asp:Label ID="lblflecha" runat="server" CssClass="Mediana" Text=" &gt; "></asp:Label>
    <asp:LinkButton ID="lnkMapa2" runat="server" CausesValidation="False" 
        CssClass="Mediana" Font-Bold="True"></asp:LinkButton>
<asp:Label ID="lblflecha0" runat="server" CssClass="Mediana" Text=" &gt; "></asp:Label>
    <asp:Label ID="lblCarpetaActual" runat="server" CssClass="Mediana" Text="CarpetaActual"></asp:Label>
    </td>
</tr>
<tr>
<td>
    <table  cellpadding="0" border="0" cellspacing="0" style="width:100%">
        <tr>
            <td style="width:30px; height:20px" > 
     <asp:ImageButton ID="ibNuevoFolder" runat="server" CausesValidation="False" 
                    ImageUrl="~/Images/CHCarpetaNueva.gif" ToolTip="Crear un nuevo folder" />
     </td>
            <td><asp:Panel ID="PanelIcons" runat="server">
                <asp:ImageButton ID="ibEditarFolder" runat="server" CausesValidation="False" ImageUrl="~/Images/CHCarpetaEditar.gif" ToolTip="Editar el titulo del folder" />
                <asp:ImageButton ID="ibLectura" runat="server" CausesValidation="False" ImageUrl="~/Images/CHTexto.gif" ToolTip="Agregar una lectura" />
                <asp:ImageButton ID="ibArchivo" runat="server" CausesValidation="False" ImageUrl="~/Images/CHArchivo.gif" ToolTip="Agregar un archivo" />
                <asp:ImageButton ID="ibImagen" runat="server" CausesValidation="False" ImageUrl="~/Images/CHImagen.gif" ToolTip="Agregar una imagen" />
                <asp:ImageButton ID="ibFlash" runat="server" CausesValidation="False" ImageUrl="~/Images/CHFlash.gif" ToolTip="Agregar una pelicula flash" />
                <asp:ImageButton ID="ibActividad" runat="server" CausesValidation="False" ImageUrl="~/Images/CHActividad.gif" ToolTip="Agregar una actividad" />
                <asp:ImageButton ID="ibExamen" runat="server" CausesValidation="False" ImageUrl="~/Images/CHExamen.gif" ToolTip="Agregar un examen" />
                <asp:ImageButton ID="ibForo" runat="server" CausesValidation="False" ImageUrl="~/Images/CHForo.gif" ToolTip="Agregar un foro" />
            </asp:Panel></td>
        </tr>
    </table>
   
            
    </td>
</tr>
</table>
<br /><asp:Panel ID="PanelEdicion" runat="server" Visible="False">   
<FIELDSET style="WIDTH: 620px;margin-top: 0px;" >
    <legend>
            <asp:Label ID="lblTitulofieldset" runat="server" cssClass="Mediana" 
        Font-Bold="true" Text="Editar datos de carpeta"></asp:Label></legend>
                         <table class="style1">
                            <tr>
                                <td class="style2">
                                      <asp:HiddenField ID="hdClave" runat="server" />
                                      <asp:HiddenField ID="hdClasif" runat="server" />
                                      <asp:Label ID="lblmensajeBorrar" runat="server" CssClass="Mediana" 
                                        ForeColor="Red" 
                                        Text="No se puede borrar porque existen elementos asociados a esta carpeta" 
                                        Visible="False"></asp:Label>
                                    <asp:TextBox ID="txtTitulo" runat="server" Width="350px"></asp:TextBox>
                                &#160;&#160;&#160;</td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="txtTitulo" CssClass="Mediana">*</asp:RequiredFieldValidator>
                                </td>
                                <td class="style4">
                                    <asp:ImageButton ID="btnGrabar" runat="server" ImageUrl="~/Images/ok.gif" 
                                        ToolTip="Grabar o editar datos generales de carpeta" />
                                </td>
                                <td class="style5">
                                    <asp:ImageButton ID="btnborrar" runat="server" ImageUrl="~/Images/cancel.gif" 
                                        ToolTip="Borrar carpeta" />
                                   
                                 
                                    <cc1:ConfirmButtonExtender ID="btnborrar_ConfirmButtonExtender" runat="server" 
                                        ConfirmText="¿Desea borrar esta carpeta?" Enabled="True" 
                                        TargetControlID="btnborrar">
                                    </cc1:ConfirmButtonExtender>
                                   
                                 
                                </td>
                            </tr>
                            </table>
        </FIELDSET>
</asp:Panel>

<div align="left">
<asp:DataList ID="dtlFolders" runat="server" RepeatColumns="4" 
    RepeatDirection="Horizontal" Width="616px">
    <ItemTemplate>
    <div align="left"  style="width:155px">
        <table cellpadding="2" cellspacing="0" style="width:100%">
            <tr>
                <td style="width:48px; vertical-align:top"><asp:ImageButton ID="ImageButton1"  
                CommandArgument='<%#Eval("id") & "," & Eval("tipo") & "," & Eval("idClasificacion") %>'  ToolTip='<%#Eval("Titulo")%>'  
                runat="server" ImageUrl='<%# "~/Images/" &  Eval("imagen")%>'  /></td>
                <td style="vertical-align:top"> <asp:LinkButton ID="lnkBoton" runat="server"  CommandArgument='<%#Eval("id") & "," & Eval("tipo") & "," & Eval("idClasificacion") %>' 
                 Text='<%#Eval("Titulo")%>' CssClass="Mediana" />   </td>
            </tr>
        </table>
    </div>
    </ItemTemplate>
    <itemstyle font-bold="False" font-italic="False" font-overline="False" 
        font-strikeout="False" font-underline="False" verticalalign="Top" />
</asp:DataList>
</div><br /><br />
     
        



