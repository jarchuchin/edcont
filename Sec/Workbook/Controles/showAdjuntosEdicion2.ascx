<%@ Control Language="VB" AutoEventWireup="false" CodeFile="showAdjuntosEdicion2.ascx.vb" Inherits="Sec_Workbook_Controles_showAdjuntosEdicion2" %>

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
                <asp:hyperlink ID="lnkTitulo" runat="server" Text='<%# Eval("titulo") %>' NavigateUrl='<%# cadena & Eval("idContenido") %>' ></asp:hyperlink> <asp:Label ID="lblTamano" runat="server" Text='<%# BytesToString(Eval("Espacio")) %>'></asp:Label>
                <div style="height:3px;" id="divSepara" visible='<%# esVisible(Eval("idTipoContenido")) %>'></div>
                <asp:Image ID="Image1" runat="server" ImageUrl='<%# getimagen(cadena & Eval("idContenido"), Eval("idTipoContenido"), Eval("idContenido")) %>' Width="50px" visible='<%# esVisible(Eval("idTipoContenido")) %>'   /> 
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:Button ID="btnBorrar" runat="server" Text="Borrar adjuntos" CssClass="btn btn-danger btn-sm" />
<ajaxToolkit:ConfirmButtonExtender ID="btnBorrar_ConfirmButtonExtender" runat="server" BehaviorID="btnBorrar_ConfirmButtonExtender" ConfirmText="¿Deseas borrar los elementos seleccionados?" TargetControlID="btnBorrar">
</ajaxToolkit:ConfirmButtonExtender>
 <div style="height:15px;"></div>

