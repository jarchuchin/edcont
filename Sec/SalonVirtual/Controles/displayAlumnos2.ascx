<%@ Control Language="VB" AutoEventWireup="false" CodeFile="displayAlumnos2.ascx.vb" Inherits="Sec_SalonVirtual_Controles_displayAlumnos2" %>

<div class="panel">
    <div class="panel-heading">
            <h3 class="panel-title"><asp:Label ID="Label4" runat="server" Text="Alumnos"></asp:Label></h3>
    </div>
    <div class="panel-body">
                   
        <asp:DataList id="gvAlumnos" runat="server" Width="100%" RepeatColumns="10">
	        <ItemTemplate>
		       <%-- <asp:HyperLink ID="lnkAlumno" runat="server" NavigateUrl='<%# Eval("idSalonVirtual", "~/sec/SalonVirtual/EnviarCorreo.aspx?idSalonVirtual={0}") & Eval("emailgoogle", "&correos={0}") & Eval("email", ",{0}")%>' ToolTip='<%#Eval("claveAux1") & "-" & Eval("Nombre") %>'>
			        <asp:Image id="imgAlumno" runat="server"  Width="50px" ImageUrl='<%# getImagen(Eval("imagen"), Eval("claveAux1"), CInt(Eval("idUserProfile"))) %>' />
		        </asp:HyperLink>--%>


                  <div class="media">
                        <div class="text-center">
                            <asp:Image ID="Image1" runat="server" CssClass="img-circle" Width="50px" ImageUrl='<%# getImagen(Eval("imagen"), Eval("claveAux1"), CInt(Eval("idUserProfile"))) %>' AlternateText='<%#Eval("Nombre") %>' />
                    </div>
                        <div class="media-body text-center">
					
					    <small class="text-muted">
                                <asp:HyperLink ID="HyperLink3" runat="server"
                                NavigateUrl='<%# Eval("idSalonVirtual", "~/sec/SalonVirtual/EnviarCorreo.aspx?idSalonVirtual={0}") & Eval("email", "&correos={0}")%>' 
                                CssClass="btn-link" 
                                 Text='<%#Eval("Nombre") %>'>
                            </asp:HyperLink>
					    </small>
				    </div>
                    </div>

	        </ItemTemplate>
        </asp:DataList>
 

        <asp:LinkButton ID="lnkVerTodos" runat="server" CausesValidation="False" CssClass="btn-link pull-left">Ver todos</asp:LinkButton>

    </div>
</div>	


