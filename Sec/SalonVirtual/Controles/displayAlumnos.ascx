<%@ Control Language="VB" AutoEventWireup="false" CodeFile="displayAlumnos.ascx.vb" Inherits="Sec_SalonVirtual_Controles_displayAlumnos" %>
    <asp:GridView ID="gvAlumnos" runat="server" AllowSorting="True" 
      DataKeyNames="idUserProfile" ShowHeader="false"
           AutoGenerateColumns="False" Width="100%" GridLines="None">
           <rowstyle horizontalalign="Left" />
           <columns>
           <asp:TemplateField  >
                <ItemTemplate>
                   <%-- <asp:HyperLink ID="HyperLink2" runat="server" 
                        NavigateUrl='<%# Eval("idSalonVirtual", "~/sec/SalonVirtual/EnviarCorreo.aspx?idSalonVirtual={0}") &  Eval("emailgoogle", "&correos={0}") &  Eval("email", ",{0}")%>' 
                        ToolTip='<%# eval("claveAux1") %>' CssClass="LigaGris" 
                        Text='<%# eval("Nombre") %>'></asp:HyperLink>--%>


                       <div class="media">
                        <div class="text-center">
                            <asp:Image ID="Image1" runat="server" CssClass="img-circle" ImageUrl='<%# Eval("idSalonVirtual", "~/sec/SalonVirtual/EnviarCorreo.aspx?idSalonVirtual={0}") & Eval("emailgoogle", "&correos={0}") & Eval("email", ",{0}") %>' />
                    </div>
                        <div class="media-body text-center">
					    <p class="mar-no"><asp:literal ID="lblDocente" runat="server" Text='<%#Eval("Nombre") %>'></asp:literal></p>
					    <small class="text-muted">
                                <asp:HyperLink ID="HyperLink3" runat="server" 
                                NavigateUrl='<%# Eval("idSalonVirtual", "~/sec/SalonVirtual/EnviarCorreo.aspx?idSalonVirtual={0}") & Eval("email", "&correos={0}")%>' 
                                CssClass="btn-link" 
                                Text="Contactar">
                            </asp:HyperLink>
					    </small>
				    </div>
                    </div>

                </ItemTemplate>
                <HeaderStyle />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
           
        
               
               
           </columns>
           <headerstyle font-bold="True" forecolor="Black" HorizontalAlign="Left" />
       </asp:GridView>

  