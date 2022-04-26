<%@ Control Language="VB" AutoEventWireup="false" CodeFile="displayComentarios.ascx.vb" Inherits="Sec_SalonVirtual_Controles_displayComentarios" %>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
<table style=" width:100%">
<tr>
<td>
    <asp:Label ID="Label5" runat="server" Text="Promedio: "></asp:Label>
    <asp:Image ID="imgrating" runat="server" /><br />
    <asp:LinkButton ID="lnkComentario" runat="server" CssClass="btn-link"  CausesValidation="false" >Comentar contenido</asp:LinkButton>
</td>

</tr>
</table>
<div style="height:15px;"></div> 
<asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <div style="text-align: left">
                <asp:Image runat="server" ID="Image1" ImageUrl="~/Images/indicator.gif" ></asp:Image>
                &nbsp;<asp:Label runat="server" Text="Actualizando datos..." ID="lblProgress" ></asp:Label>
            </div>

        </ProgressTemplate>
    </asp:UpdateProgress>
<asp:Panel ID="Panel1" runat="server" Visible="false" >

    <div style="height:15px;"></div>
<div id="Caja">



    <asp:Label ID="Label2" runat="server" Text="Calificación" CssClass="Mediana" Font-Bold="true" ></asp:Label>
    <div style="height:5px;"></div>
    <asp:RadioButtonList ID="rbdCalificacion" runat="server"  RepeatDirection="Horizontal" CssClass="Mediana">
           <asp:ListItem Value="1" Text="1"></asp:ListItem> 
          <asp:ListItem Value="2" Text="2"></asp:ListItem> 
          <asp:ListItem Value="3" Text="3"></asp:ListItem> 
          <asp:ListItem Value="4" Text="4"></asp:ListItem> 
          <asp:ListItem Value="5" Text="5"></asp:ListItem>  
        </asp:RadioButtonList>
    <div style="height:5px;"></div>
        
    <asp:Label ID="Label1" runat="server" Text="Comentario:"  Font-Bold="true" ></asp:Label> <br />
    <asp:TextBox ID="txtComentario" runat="server" Height="87px" 
        TextMode="MultiLine" Width="385px"></asp:TextBox>
     <div style="height:10px;"></div>

     <asp:Label ID="lblMensaje" runat="server" Text="Debes seleccionar la calificacion y colocar tu comentario" Visible="False" ForeColor="Red"></asp:Label>
     <div style="height:10px;"></div>
    <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CausesValidation="false"  CssClass="btn btn-success"/>
    &nbsp;<asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CausesValidation="false" CssClass="btn btn-default" />
        <div style="height:20px;"></div>
    <asp:HiddenField ID="hdidproc" runat="server" />
    <asp:HiddenField ID="hdProcedencia" runat="server" />
    <asp:HiddenField ID="hdidCI" runat="server" />
    <asp:HiddenField ID="hdpag" runat="server" />
        
    </div>
   </asp:Panel>
   
<asp:Repeater ID="Repeater1" runat="server">
<ItemTemplate> 
       &nbsp;<asp:Label ID="Label3" runat="server" CssClass="Mediana" Font-Bold="true" Text='<%#Eval("Nombre") %>'></asp:Label> 
        <asp:Label ID="Label4" runat="server" CssClass="Chica"  Text='<%#Eval("Fecha") %>'></asp:Label> 
    <br />
   <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/images/userrating" & eval("Calificacion") & ".jpg" %>' /><br />
   <div class="Mediana">
    &nbsp;<%#Replace(Eval("Observacion"), vbCrLf, "<br/>")%>
   </div>
    <asp:HyperLink ID="lnkBorrar" runat="server" CssClass="btn-lnk"   NavigateUrl='<%# "~/sec/SalonVirtual/BorrarComentario.aspx?idSalonVirtual=" & eval("idSalonVirtual") & "&idContenidoCalificacion=" & eval("idContenidoCalificacion")  & "&idCI=" & hdidCI.Value & "&pag=" & hdpag.Value %>'  Visible='<%# esvisible(eval("idUserProfile")) %>' >borrar</asp:HyperLink> 
    <div style="height:10px;"></div>
</ItemTemplate>
</asp:Repeater>


</ContentTemplate>
</asp:UpdatePanel>