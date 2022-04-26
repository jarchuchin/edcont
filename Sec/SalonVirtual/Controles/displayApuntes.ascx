<%@ Control Language="VB" AutoEventWireup="false" CodeFile="displayApuntes.ascx.vb" Inherits="Sec_SalonVirtual_Controles_displayApuntes" %>


<div class="panel">
    <div class="panel-heading">
            <h3 class="panel-title"><asp:Label ID="Label1" runat="server" Text="Tus apuntes"></asp:Label></h3>
    </div>
    <div class="panel-body">
          <asp:GridView ID="gvApuntes" runat="server" AllowSorting="True" 
    CssClass="Chica"   DataKeyNames="idSalonVirtualApunte" ShowHeader="false"
           AutoGenerateColumns="False" Width="100%" GridLines="None">
           <rowstyle horizontalalign="Left" />
           <columns>
         
           <asp:TemplateField HeaderText="Fecha" >
                <ItemTemplate>


                       <table width="100%" border="0" cellspacing="3" cellpadding="0">
                        <tr>
                        <td width="15" scope="row">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/bull-arrow1.png" /></td>
                        <td> <asp:HyperLink ID="HyperLinkss2" runat="server" 
                        NavigateUrl='<%# Eval("idSalonVirtual", "~/sec/SalonVirtual/Apuntes.aspx?idSalonVirtual={0}") & Eval("idSalonVirtualApunte", "&idSalonVirtualApunte={0}")%>' 
                        ToolTip="Editar apunte" CssClass="link1" 
                        Text='<%#Format(Eval("Fecha"), "dd MMM yyyy - hh:mm") %>'></asp:HyperLink></td>
                        </tr>
                    </table>



                   
                </ItemTemplate>
                <HeaderStyle />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
           
               
           </columns>
           <headerstyle font-bold="True" forecolor="Black" HorizontalAlign="Left" />
       </asp:GridView>
        <div style="height:10px; width:100%;"></div>
         <asp:HyperLink ID="lnkSalon2" runat="server"  CssClass="btn-link pull-right"  text="Nuevo" NavigateUrl="~/Sec/SalonVirtual/Apuntes.aspx"   ></asp:HyperLink>
    </div>
</div>

