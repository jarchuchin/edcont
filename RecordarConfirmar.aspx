<%@ Page Title="Skolar" Language="VB" MasterPageFile="~/MPDiamante02.master" AutoEventWireup="false" CodeFile="RecordarConfirmar.aspx.vb" Inherits="RecordarConfirmar" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

     <!-- Create your own class to load custum image [ SAMPLE ]-->
    <style>
        .demo-my-bg{
            background-image : url("images/diamantebaners/ban1.jpg");
        }
    </style>



     <div class="wrapper">
        <div class="row">
              <div class="col-sm-1"></div>
              <div class="col-sm-2 col-md-2">

                 
            </div>
            <div class="col-sm-6"></div>
      
      
        <div class="col-sm-2 col-md-1"></div>
            
       <div class="card card-container text-center">
            
           
           <asp:Image ID="Image1" runat="server"  ImageUrl="~/images/skolar.png" Width="300px"     />
           
            <p id="profile-name" class="profile-name-card"><asp:label id="lblLogin" runat="server" meta:resourcekey="lblLoginResource1"     ></asp:label></p>
            <div  class="form-signin">
               <asp:Label id="lblMensajeError" Visible="False"  runat="server" ForeColor="Red"  Text="El correo colocado no está relacionado con ninguna cuenta sistema" meta:resourcekey="lblMensajeErrorResource1"  ></asp:Label>
               <asp:Label id="lblMensajeerror1" Visible="False"  runat="server" ForeColor="Red" meta:resourcekey="lblMensajeerror1Resource1"   ></asp:Label>

               

                <span id="reauth-email" class="reauth-email"></span>
               
                  <div style="height:40px;"></div>
               
                        <asp:Label ID="Label1" runat="server" Text="Hemos enviado los datos al correo" Font-Bold="False" ForeColor="#339933" meta:resourcekey="Label1Resource1"></asp:Label>
                 <div style="height:5px;"></div>
                    <asp:Label ID="Label2" runat="server" Text="Ingresa a tu cuenta de correo para obtener tu password" Font-Bold="False" ForeColor="#339933" meta:resourcekey="Label2Resource1"></asp:Label>
                 
             
                     <div style="height:40px;"></div>


                <div style="height:10px;"></div>
            <asp:HyperLink ID="lnkOlvidaste" runat="server" Text="Ingresar al sistema" NavigateUrl="~/Default.aspx" CssClass="forgot-password" meta:resourcekey="lnkOlvidasteResource1" ></asp:HyperLink>
         

            <div style="height:10px;"></div>
            
        </div>
    </div>

       </div>

   </div>

   
</asp:Content>

