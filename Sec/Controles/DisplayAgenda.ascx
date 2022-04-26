<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayAgenda.ascx.vb" Inherits="Sec_Controles_DisplayAgenda" %>

asdfasdfasdfasdfasdf<p>
    &nbsp;</p>
<p>
    gsdfgsdfg</p>
<p>
    s</p>
<p>
    dfgsdfg</p>
&nbsp;<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <table style="width:100%">
            <tr>
                <td style="width:50%">
                    <asp:GridView ID="dtgAgenda" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" CssClass="Chica" GridLines="None" PageSize="7" 
                        Width="100%">
                        <PagerStyle CssClass="LigaVerde"  />
                        <HeaderStyle Font-Bold="true" Font-Size="11px" HorizontalAlign="Center" />
                        <PagerSettings LastPageText="Ultima" Mode="NextPrevious"  
                            NextPageText="Siguiente" FirstPageText="Primera" 
                            PreviousPageText="Anterior" />
                        <Columns>
                            <asp:TemplateField>
                                <HeaderStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="11px" 
                                        Text='<%# DataBinder.Eval(Container, "DataItem.fecha", "{0:dd}") %>'>
		                    </asp:Label>
                                    <br />
                                    <asp:Label ID="Label2" runat="server"  Font-Size="9px"
                                        Text='<%# DataBinder.Eval(Container, "DataItem.fecha", "{0:dddd}") %>'>
		                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnkactividad" runat="server" CssClass="LigaVerde"  Text='<%# eval("actividad") %>'  NavigateUrl='<%# "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & eval("idSalonVirtual") %>'></asp:HyperLink>
                                    <br />
                                    <asp:Label ID="Label2x" runat="server" CssClass="Chica" 
                                        Text='<%# eval("nombreSalon") %>'>
		                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            </table>
             <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    <div style="text-align: left">
                        <asp:Image runat="server" ID="Image1" ImageUrl="~/Images/indicator.gif" ></asp:Image>
                        <asp:Label runat="server" Text="Buscando actividades..." ID="lblProgress" ></asp:Label>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:label id="lblHoy" runat="server" Visible="False" Text="Hoy es: "></asp:label>
            <asp:label id="lblFechaActual" runat="server" Visible="False" ></asp:label>
            
            </ContentTemplate>
            
     </asp:UpdatePanel>

