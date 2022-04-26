<%@ Control Language="VB" AutoEventWireup="false" CodeFile="showAdjuntosEdicion2Ligas.ascx.vb" Inherits="Sec_Workbook_Controles_showAdjuntosEdicion2Ligas" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<div style="height:10px"></div>
<asp:GridView ID="gvAdjuntos" runat="server" CssClass="table table-hover table-bordered" AutoGenerateColumns="False" GridLines="None" Width="100%" ShowHeader="False">
    <Columns>
        <asp:TemplateField ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:CheckBox id="chkid" runat="server"></asp:CheckBox>
                <asp:Label ID="lblid" runat="server" Text='<%# Eval("idContenidoAdjunto") %>' Visible="false"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField>
            <ItemTemplate>
                <asp:hyperlink ID="lnkTitulo" runat="server" Text='<%# Eval("titulo") %>' NavigateUrl='<%# Eval("url") %>' Target="_blank" ></asp:hyperlink>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:Button ID="btnBorrar22" runat="server" Text="Borrar ligas" CssClass="btn btn-danger btn-sm" />
<ajaxToolkit:ConfirmButtonExtender ID="btnBorrar_ConfirmButtonExtender22" runat="server" BehaviorID="btnBorrar_ConfirmButtonExtender22" ConfirmText="¿Deseas borrar los elementos seleccionados?" TargetControlID="btnBorrar22">
</ajaxToolkit:ConfirmButtonExtender>
 <div style="height:15px;"></div>

