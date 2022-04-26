<%@ Control Language="VB" AutoEventWireup="false" CodeFile="displayRespuestasComentarios.ascx.vb" Inherits="Sec_SalonVirtual_Controles_displayComentarios"  %>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

           
 
   
<asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <div style="text-align: left">
                <asp:Image runat="server" ID="Image1" ImageUrl="~/Images/indicator.gif" ></asp:Image>
                &nbsp;<asp:Label runat="server" Text="Actualizando datos..." ID="lblProgress" ></asp:Label>
            </div>

        </ProgressTemplate>
    </asp:UpdateProgress>



            <asp:Label ID="lblactividadid" runat="server" visible="false"></asp:Label>
        
  
    <asp:TextBox ID="txtComentario" runat="server" Height="87px"  ValidationGroup="respuesta"
        TextMode="MultiLine" Width="100%"></asp:TextBox>
     <div style="height:5px;"></div>

   
  
    <asp:Button ID="btnEnviar" runat="server" Text="Enviar comentario" CssClass="btn btn-primary btn-sm" ValidationGroup="respuesta"/>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtComentario" ForeColor="Red" Text="El mensaje es un campo requerido" ValidationGroup="respuesta"></asp:RequiredFieldValidator>
    <asp:CustomValidator ID="CustomValidator1" ControlToValidate="txtComentario" runat="server" ForeColor="Red" Text="Se ha alcanzado el límite de comentarios diarios" ValidationGroup="respuesta"></asp:CustomValidator>


    <asp:HiddenField ID="hdidRespuesta" runat="server" />
        


   
<asp:Repeater ID="Repeater1" runat="server">
<ItemTemplate> 

    <div style="height:10px;"></div>

    <asp:Label ID="Label3" runat="server" Font-Bold="true" Text='<%#Eval("Nombre") %>'></asp:Label> 
    <asp:Label ID="Label4" runat="server"  Text='<%#Eval("Fecha") %>'></asp:Label> 
  
    <div style="height:3px;"></div>
  
    <%#colocarTexto(Eval("Observacion"))%>


   
  
</ItemTemplate>
</asp:Repeater>


</ContentTemplate>
</asp:UpdatePanel>