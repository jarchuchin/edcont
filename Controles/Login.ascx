<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Login.ascx.vb" Inherits="Controles_Login" %>

  <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <ContentTemplate>


         

        <div class="card card-container text-center">
            
            <!-- <img class="profile-img-card" src="//lh3.googleusercontent.com/-6V8xOA6M7BA/AAAAAAAAAAI/AAAAAAAAAAA/rzlHcD0KYwo/photo.jpg?sz=120" alt="" /> -->
           <asp:Image ID="imgLogo" runat="server"  ImageUrl="~/images/skolar.png" Width="300px" meta:resourcekey="Image1Resource1"  />
           <div style="height:50px;"></div>
            <p id="profile-name" class="profile-name-card"><asp:label id="lblLogin" runat="server" meta:resourcekey="lblLoginResource1"     ></asp:label></p>
            <div  class="form-signin">
               <asp:Label id="lblMensajeError" Visible="False"  runat="server" ForeColor="Red"  Text="Los datos proporcionados no son correctos" meta:resourcekey="lblMensajeErrorResource1"></asp:Label>
               <asp:Label id="lblMensajeerror1" Visible="False"  runat="server" ForeColor="Red" meta:resourcekey="lblMensajeerror1Resource1"  ></asp:Label>

               

                <span id="reauth-email" class="reauth-email"></span>
              
                <asp:TextBox id="txtlogin" runat="server" cssclass="form-control"  placeholder="Usuario" required autofocus meta:resourcekey="txtloginResource1" ></asp:TextBox>
                

                <asp:TextBox id="txtPassword" runat="server" TextMode="Password" placeholder="Contraseña" cssclass="form-control"   meta:resourcekey="txtPasswordResource1"></asp:TextBox>

               <%-- <div id="remember" class="checkbox">
                    <label>
                        <asp:CheckBox ID="chkRecordarme" runat="server" Text="Recordarme" CssClass="labelNormal" meta:resourcekey="chkRecordarmeResource1" />
                    </label>
                </div>--%>

                <div style="height:35px;"></div>

                <asp:Button id="btnLogin" runat="server" Text="Iniciar Sesión" CssClass="btn btn-primary btn-block btn-signin" OnClick="btnLogear_Click" meta:resourcekey="btnLoginResource1"  ></asp:Button>
            </div>
            <div style="height:10px;"></div>
            <asp:HyperLink ID="lnkOlvidaste" runat="server" Text="Olvidaste tu password" NavigateUrl="~/Recordar.aspx" ForeColor="Gray" meta:resourcekey="lnkOlvidasteResource1"></asp:HyperLink>
           

            <div style="height:10px;"></div>
            
        </div>

     
    
        </ContentTemplate>
    </asp:UpdatePanel>
    
