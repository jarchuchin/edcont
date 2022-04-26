<%@ Page Title="" Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="ExcelDownloadSeguimiento.aspx.vb" Inherits="Sec_SalonVirtual_ExcelDownloadSeguimiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelTitulo" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPanelBreadcrumb" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">



    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped table-bordered" GridLines="None"  Width="10000px" AutoGenerateColumns="false" >

                            <Columns>

                           <%--      <asp:TemplateField  HeaderText="#">
                                    <ItemTemplate >
                                        <asp:Label ID="lblNumeros" runat="server" Text='<%# numero %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10px" CssClass="text-center" />
                                    <ItemStyle HorizontalAlign="Center" Width="30px" CssClass="text-center" />
                                </asp:TemplateField>--%>


<%--                                 <asp:TemplateField HeaderText="Nombre del alumno" SortExpression="Nombre">
                                    <ItemTemplate >
                                      

                                           <asp:HyperLink ID="lnknombreloc" runat="server" 
                                            NavigateUrl='<%# Eval("idSalonVirtual", "~/sec/SalonVirtual/ListaSeguimientoAlumno.aspx?idSalonVirtual={0}") & Eval("idUserProfile", "&idUserProfile={0}") %>' 
                                             CssClass="btn-link"
                                              ToolTip="Clic para ver los detalles de evaluación"
                                            Text='<%# eval("Nombre") %>'></asp:HyperLink>

                                          <asp:Image runat="server" ID="imgtransp" ImageUrl="~/images/transp.gif" Height="1px" Width="180px" />
                                    </ItemTemplate>
                                     <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="180px"  />
                                 </asp:TemplateField> 

                                  <asp:boundfield DataField="claveAux1" HeaderText="Matrícula" 
                                   HtmlEncode="False" SortExpression="claveAux1"><HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center"  Width="50px" /></asp:boundfield>
                                   --%>
                           

                            </Columns>

                        </asp:GridView>



</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceFooterScripts" Runat="Server">
</asp:Content>

