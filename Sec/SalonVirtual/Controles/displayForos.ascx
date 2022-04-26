<%@ Control Language="VB" AutoEventWireup="false" CodeFile="displayForos.ascx.vb" Inherits="Sec_SalonVirtual_Controles_displayForos" %>


 <div class="panel">
    <div class="panel-heading">
            <h3 class="panel-title"><asp:Label ID="Label1" runat="server" Text="Foros"></asp:Label></h3>
    </div>
    <div class="panel-body">

  <asp:GridView ID="gvFors" runat="server" AllowSorting="True" CssClass="Chica"   
        DataKeyNames="idForo" ShowHeader="false"
           AutoGenerateColumns="False" Width="100%" GridLines="None">
           <rowstyle horizontalalign="Left" />
           <columns>
           
           <asp:TemplateField>
                <ItemTemplate>
                    
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/bull-arrow1.png" />
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%#  "~/sec/SalonVirtual/verForo.aspx?idSalonVirtual=" & claveSalon & Eval("idClasificacionItem", "&idCI={0}")%>' CssClass="btn-link" ToolTip="Participar" Text='<%#Eval("Titulo") & " (" & Eval("Comentarios") & ")" %>'>
                    </asp:HyperLink>

                    <div style="height:5px;"></div>

                </ItemTemplate>
                <HeaderStyle  />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>

           </columns>
           <headerstyle font-bold="True" forecolor="Black" HorizontalAlign="Left" />
       </asp:GridView>


    </div>
</div>

