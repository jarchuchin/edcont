<%@ Page Title="Skolar" Language="VB" MasterPageFile="~/MPDiamante02.master" AutoEventWireup="false" CodeFile="Recordar.aspx.vb" Inherits="Recordar" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">



     <!-- Create your own class to load custum image [ SAMPLE ]-->
     <asp:Literal ID="litnum" runat="server" Visible="false" ></asp:Literal>
    <asp:Literal ID="litscript" runat="server" ></asp:Literal>


      



       <div class="wrapper">
        <div class="row">
              <div class="col-sm-1"></div>
              <div class="col-sm-2 col-md-2">

                   <div class="card card-container text-center">
            
           
                        <asp:Image ID="Image1" runat="server"  ImageUrl="~/images/skolar.png" Width="300px"   />
           
                            <p id="profile-name" class="profile-name-card"><asp:label id="lblLogin" runat="server" meta:resourcekey="lblLoginResource1"     ></asp:label></p>
                            <div  class="form-signin">
                               <asp:Label id="lblMensajeError" Visible="False"  runat="server" ForeColor="Red"  Text="El correo colocado no está relacionado con ninguna cuenta sistema" meta:resourcekey="lblMensajeErrorResource1"  ></asp:Label>
                               <asp:Label id="lblMensajeerror1" Visible="False"  runat="server" ForeColor="Red" meta:resourcekey="lblMensajeerror1Resource1"   ></asp:Label>

               

                                <span id="reauth-email" class="reauth-email"></span>
                                <asp:TextBox id="txtlogin" runat="server" cssclass="form-control"  placeholder="Escribe tu correo electrónico" required autofocus  Type="email" meta:resourcekey="txtloginResource1" ></asp:TextBox>
               
                                  <div style="height:10px;"></div>
                                <p>
                
                                        <asp:Label ID="Label1" runat="server" Text="Se enviará un correo con la información de acceso"  ForeColor="Gray" meta:resourcekey="Label1Resource1"></asp:Label>
                 
                                </p>
                                     <div style="height:10px;"></div>


                                <asp:Button id="btnLogin" runat="server" Text="Recordar mi password" CssClass="btn btn-primary btn-block btn-signin" meta:resourcekey="btnLoginResource1"   ></asp:Button>
           
                                <div style="height:10px;"></div>
                            <asp:HyperLink ID="lnkOlvidaste" runat="server" Text="Ingresar al sistema" NavigateUrl="~/Default.aspx"  ForeColor="Gray" meta:resourcekey="lnkOlvidasteResource1" ></asp:HyperLink>
         

                            <div style="height:10px;"></div>
            
                        </div>
                    </div>
                 
            </div>
            <div class="col-sm-6"></div>
      
      
        <div class="col-sm-2 col-md-1"></div>


       </div>

   </div>

    <asp:Label ID="lblRecordar" runat="server" Text="Recordar contraseña" Visible="False" meta:resourcekey="lblRecordarResource1"></asp:Label>
    <asp:Label ID="lblUsuario" runat="server" Text="Usuario: " Visible="False" meta:resourcekey="lblUsuarioResource1"></asp:Label>
    <asp:Label ID="lblPass" runat="server" Text="Contraseña: " Visible="False" meta:resourcekey="lblPassResource1"></asp:Label>
    <asp:Label ID="lblNombre" runat="server" Text="Nombre: " Visible="False" meta:resourcekey="lblNombreResource1"></asp:Label>
    <asp:Label ID="lblHola" runat="server" Text="Hola " Visible="False" meta:resourcekey="lblHolaResource1"></asp:Label>
    <asp:Label ID="lblTeenviamos" runat="server" Text="A continuación te enviamos los datos que nos pediste " Visible="False" meta:resourcekey="lblTeenviamosResource1"></asp:Label>
    <asp:Label ID="lblMensajeFinal" runat="server" Text="Mensaje enviado por el sistema Skolar " Visible="False" meta:resourcekey="lblMensajeFinalResource1"></asp:Label>

&nbsp; 

</asp:Content>

