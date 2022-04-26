<%@ Control Language="VB" AutoEventWireup="false" CodeFile="displayAgenda7dias.ascx.vb" Inherits="Sec_SalonVirtual_Controles_displayAgenda7dias" %>


<div class="panel">
    <div class="panel-heading">
            <h3 class="panel-title"><asp:Label ID="Label1" runat="server" Text="Agenda semanal"></asp:Label></h3>
    </div>
    <div class="panel-body">
                   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
             <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    <div style="text-align: left">
                        <asp:Image runat="server" ID="Image1" ImageUrl="~/Images/indicator.gif" ></asp:Image>
                        <asp:Label runat="server" Text="Buscando actividades..." ID="lblProgress" ></asp:Label>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
             <asp:datagrid id="dtgAgenda" AutoGenerateColumns="False" Width="100%" 
                runat="server"  GridLines="None">
                <AlternatingItemStyle BackColor="#EBEBEB"></AlternatingItemStyle>
                <HeaderStyle HorizontalAlign="Center" Font-Size="11px" Font-Bold="false"></HeaderStyle>
                <Columns>
                    <asp:TemplateColumn>
	                    <HeaderStyle Width="50px"></HeaderStyle>
	                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
	                    <ItemTemplate>
		                    <asp:Label id="Label1" runat="server" Font-Bold="True" Text='<%# DataBinder.Eval(Container, "DataItem.fecha", "{0:dd}") %>' Font-Size="13px">
		                    </asp:Label><br />
		                    <asp:Label id="Label2"  Font-Size="11px" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.fecha", "{0:dddd}") %>'>
		                    </asp:Label>
	                    </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn DataField="actividad">
	                    <ItemStyle VerticalAlign="Top"></ItemStyle>
                    </asp:BoundColumn>
                </Columns>
            </asp:datagrid>
            <asp:label id="lblHoy" runat="server" Visible="False" Text="Hoy es: "></asp:label>
            <asp:label id="lblFechaActual" runat="server" Visible="False" ></asp:label>
            
            </ContentTemplate>
            
     </asp:UpdatePanel>
<div class="text-right">
	<asp:LinkButton ID="lnkAnterior" runat="server"  CssClass="btn-link">Anterior</asp:LinkButton> |
	<asp:LinkButton ID="lnkSiguiente" runat="server" CssClass="btn-link">Siguiente</asp:LinkButton>
</div>   
    </div>
</div>



  