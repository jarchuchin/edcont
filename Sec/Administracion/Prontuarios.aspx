<%@ Page Title="" Language="VB" MasterPageFile="~/MPUsmart01.master" AutoEventWireup="false" CodeFile="Prontuarios.aspx.vb" Inherits="Sec_Administracion_Prontuarios" %>

<%@ Register src="Controles/MenuAdministracion.ascx" tagname="MenuAdministracion" tagprefix="uc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelBreadcrumb" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelIzquierdo" Runat="Server">
    <uc1:MenuAdministracion ID="MenuAdministracion1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPanelEdicion" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
   <div style="height:20px;"></div>
    <table style="width: 100%" class="title-big">
        <tr>
            <td><asp:Label ID="lblTitulo" runat="server"   >Traer prontuarios</asp:Label></td>
        </tr>
    </table>

    <br />
    <br />

    <asp:TextBox ID="txtfecha" runat="server"></asp:TextBox>
    <asp:CalendarExtender ID="txtfecha_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtfecha">
    </asp:CalendarExtender>
    <br />
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Text="Traer prontuario" />
    <asp:ConfirmButtonExtender ID="Button1_ConfirmButtonExtender" runat="server" ConfirmText="¿Desea traer los prontuarios?" Enabled="True" TargetControlID="Button1">
    </asp:ConfirmButtonExtender>
    <br />
    <br />
    <asp:Label ID="lblmensaje" runat="server" ForeColor="#009900"></asp:Label>
</asp:Content>

