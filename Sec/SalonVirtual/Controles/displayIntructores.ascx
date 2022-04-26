<%@ Control Language="VB" AutoEventWireup="false" CodeFile="displayIntructores.ascx.vb" Inherits="Sec_SalonVirtual_Controles_displayIntructores" %>
  


<div class="panel">
    <div class="panel-heading">
            <h3 class="panel-title"><asp:Label ID="Label1" runat="server" Text="Docentes"></asp:Label></h3>
    </div>
    <div class="panel-body">
       
        
        <asp:Repeater ID="gvInstructores" runat="server">
            <ItemTemplate>

                    <div class="media">
                        <div class="text-center">
                            <asp:Image ID="Image1" runat="server" CssClass="img-circle img-xs" ImageUrl='<%# getImagen(Eval("imagen"), Eval("claveAux2"), CInt(Eval("idUserProfile"))) %>' />
                    </div>
                        <div class="media-body text-center">
					    <p class="mar-no"><asp:literal ID="lblDocente" runat="server" Text='<%#Eval("Nombre") %>'></asp:literal></p>
					    <small class="text-muted">
                                <asp:HyperLink ID="HyperLink3" runat="server"
                                NavigateUrl='<%# Eval("idRecurso", "~/sec/SalonVirtual/EnviarCorreo.aspx?idSalonVirtual={0}") & Eval("email", "&correos={0}")%>' 
                                CssClass="btn-link" 
                                Text="Contactar">
                            </asp:HyperLink>
					    </small>
				    </div>
                    </div>

                     
            </ItemTemplate>
        </asp:Repeater>
          


    


       

    </div>
</div>