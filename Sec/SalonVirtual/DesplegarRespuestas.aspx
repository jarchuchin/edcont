<%@ Page Language="VB" MasterPageFile="~/MPUsmart01.master" AutoEventWireup="false" CodeFile="DesplegarRespuestas.aspx.vb" Inherits="Sec_SalonVirtual_DesplegarRespuestas" title="Untitled Page" %>

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
		<asp:Label ID="Label3"  runat="server"  CssClass="title-big" >Calificaciones de: </asp:Label> <asp:Label ID="lblActividad"  runat="server"  CssClass="title-big" ></asp:Label><br />
		<asp:Label ID="Label4"  runat="server"  CssClass="title-big" >Enviada por: </asp:Label><asp:Label ID="lblNombre"  runat="server"  CssClass="title-big" ></asp:Label>
		 <div id="CajaInterna">
 
      <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <div align="left" > <asp:Image ID="Image1" runat="server"  ImageUrl ="~/Images/indicator.gif" /><asp:Label ID="lbltexto" runat="server"   Text="Actualizando datos..." ></asp:Label></div>
                    </ProgressTemplate>
       </asp:UpdateProgress>
       <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional" >
               <ContentTemplate>
               
                           
                           <br />
                           
                       <asp:GridView ID="gvCalificaciones" runat="server" AllowSorting="True"  DataKeyNames="idUserProfile"
                           AutoGenerateColumns="False" Width="100%">
                           <RowStyle  HorizontalAlign="Center"/>
                           
                           <columns>
                             <asp:templatefield HeaderText="">
                                       <itemtemplate>
                                           <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# getRespuesta(cint(eval("idUserProfile"))) %>' Visible='<%# esmaestrovar %>'>Editar</asp:HyperLink>
                                       </itemtemplate>
                                       <headerstyle horizontalalign="Center" width="70px" />
                                       <itemstyle horizontalalign="Center" />
                                </asp:templatefield>
                                <asp:boundfield DataField="Apellidos" HeaderText="Apellidos" 
                                   HtmlEncode="False" SortExpression="Apellidos">
                                <itemstyle horizontalalign="Left" />   
                                </asp:boundfield>
                               <asp:boundfield DataField="Nombre" HeaderText="Nombre" 
                                   HtmlEncode="False" SortExpression="Nombre">
                                <itemstyle horizontalalign="Left" />
                                </asp:boundfield>
                                   <asp:templatefield HeaderText="Enviado">
                                       <headerstyle horizontalalign="Center" width="50px" />
                                       <itemstyle horizontalalign="Center" width="50px"  />
                                       <itemtemplate>
                                           <asp:Image ID="Image2"  ImageUrl='<%# "~/images/" & getEnviada(cint(eval("idUserProfile"))) %>' runat="server" />
                                       </itemtemplate>
                                </asp:templatefield>
                                    <asp:templatefield HeaderText="Fecha">
                                       <itemtemplate>
                                           <asp:Label  ID="Label1" runat="server" Text='<%# getFecha(cint(eval("idUserProfile"))) %>' ></asp:Label>
                                       </itemtemplate>
                                       <headerstyle horizontalalign="Center" width="70px" />
                                       <itemstyle horizontalalign="Center" />
                                </asp:templatefield>
                                    <asp:templatefield HeaderText="Calificación">
                                       <itemtemplate>
                                           <asp:Label  ID="Label1" runat="server" Text='<%# getCalificacion(cint(eval("idUserProfile"))) %>' ></asp:Label>
                                       </itemtemplate>
                                       <headerstyle horizontalalign="Center" width="90px" />
                                       <itemstyle horizontalalign="Center" />
                                </asp:templatefield>
                           </columns>
                           <headerstyle font-bold="True" forecolor="Black" HorizontalAlign="Left" />
                       </asp:GridView>
                        <br />               
                           <table style="width: 100%">
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td style="width: 230px; text-align:center">
                                        <asp:Label ID="Label2" runat="server" CssClass="Mediana" Font-Bold="true" 
                                            Text="Calificación promedio de esta actividad:"></asp:Label>
                                    </td>
                                    <td style="width: 90px; text-align:center">
                                        <asp:Label ID="lblpromedio" runat="server" CssClass="Mediana" Font-Bold="true"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                       

        </ContentTemplate>
        </asp:UpdatePanel>


 </div>
 </div>

</asp:Content>

