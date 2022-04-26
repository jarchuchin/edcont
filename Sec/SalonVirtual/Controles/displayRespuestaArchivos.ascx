<%@ Control Language="VB" AutoEventWireup="false" CodeFile="displayRespuestaArchivos.ascx.vb" Inherits="Sec_SalonVirtual_Controles_displayRespuestaArchivos" %>
<%--<asp:CheckBoxList id="chkAdjuntos" runat="server" Visible="False" CssClass="btn-link" ></asp:CheckBoxList>--%>


<asp:GridView ID="gvRA" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="table table-stripped table-hover" GridLines="None"  >
    <Columns>
        <asp:TemplateField HeaderText="" >
            <ItemTemplate>
                <asp:CheckBox ID="chkAdj" runat="server" />
                <asp:HiddenField ID="hdidgv" runat="server"  Value='<%# Eval("idRespuestaArchivo") %>'/>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Archivo" >
            <ItemTemplate>
                <asp:hyperlink ID="lnkArchivo" runat="server"  Text='<%# Eval("NombreOriginal") %>'  NavigateUrl='<%# "~/pub/showFile.aspx?idRespuestaArchivo=" & Eval("idRespuestaArchivo") %>' cssClass="btn-link" />
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Fecha" >
            <ItemTemplate>
                <asp:label ID="lblfecha" runat="server"  Text='<%# Eval("FechaCreacion") %>'  />
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText=" "  >
            <ItemTemplate>
                <asp:hyperlink ID="btnArchvioVP" runat="server"  Text="Vista Previa"  NavigateUrl='<%# "~/sec/SalonVirtual/VistaPreviaRespuesta.aspx?idSalonVirtual=" & Request("idSalonVirtual") & "&idR=" & Eval("idRespuesta") & "&idRespuestaArchivo=" & Eval("idRespuestaArchivo") & "&visor=ms"  %>' CssClass="btn btn-warning btn-sm" Target="_blank" />
            </ItemTemplate>
             <HeaderStyle  CssClass="text-center" Width="100px"/>
        </asp:TemplateField>
    </Columns>
 </asp:GridView>


<%--<div style="height:10px;"></div>--%>

<asp:LinkButton ID="lnkBorrar" runat="server" ToolTip="Borrar los elementos seleccionados" CssClass="btn btn-danger btn-sm">Eliminar</asp:LinkButton>
<asp:HiddenField ID="hdid" runat="server" />