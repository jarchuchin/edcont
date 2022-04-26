<%@ Control Language="vb" AutoEventWireup="false" Inherits="usmart.showAdjuntosEdicion" CodeFile="showAdjuntosEdicion.ascx.vb" %>
<asp:CheckBoxList id="chkAdjuntos" runat="server" Visible="False" CssClass="checkbox" ></asp:CheckBoxList>
<div style="height:10px;"></div>
<asp:LinkButton ID="lnkBorrar" runat="server" 
    ToolTip="Borrar los elementos seleccionados" CssClass="btn btn-" 
    CausesValidation="False">Eliminar seleccionados</asp:LinkButton>
<asp:Label id="lblvistaprevia" Visible="False" runat="server" Text="Vista previa" CssClass="Chica"></asp:Label>
<asp:HiddenField ID="hd1" runat="server" />
<asp:HiddenField ID="Hd2" runat="server" />
<asp:HiddenField ID="Hd3" runat="server" />
