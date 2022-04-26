<%@ Page Language="VB" MasterPageFile="~/MPUsmart01.master" AutoEventWireup="false" CodeFile="verContenidos.aspx.vb" Inherits="Sec_SalonVirtual_VerContenidos" title="Explorar contenidos" ValidateRequest="false" %>

<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>

<asp:Content ID="contentBreadCrumb" ContentPlaceHolderID="ContentPanelBreadcrumb" Runat="Server">
</asp:Content>

<asp:Content ID="contentIzquierdo" ContentPlaceHolderID="ContentPanelIzquierdo" Runat="Server">
    <uc1:MenuSalonVirtual ID="MenuSalonVirtual1" runat="server" />
</asp:Content>

<asp:Content ID="contentEdicion" ContentPlaceHolderID="ContentPanelEdicion" Runat="Server">
</asp:Content>

<asp:Content ID="contentCentral" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
	<div id="Caja">
		<asp:Label ID="lblTitulo" runat="server" Text="Explorar contenidos" CssClass="title-big"></asp:Label>
		<div id="CajaInterna">

                 <table  cellpadding="0" border="0" cellspacing="0" style="width:100%">
                    <tr>
                        <td style="width:30px;" > 
                        </td>
                        <td>
                            <asp:TreeView ID="tvFolders" runat="server" ExpandDepth="0" PopulateNodesFromClient="true" ShowLines="true">
                                <NodeStyle HorizontalPadding="5px" CssClass="LigaGris" />
                                <LeafNodeStyle HorizontalPadding="5px" CssClass="LigaGris" />
                            </asp:TreeView>
                        </td>
                     </tr>
                  </table>

    </div>
</div>
</asp:Content>

