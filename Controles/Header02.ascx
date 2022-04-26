<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Header02.ascx.vb" Inherits="Controles_Header02" %>


	  
               <%@ Register src="../Sec/SalonVirtual/Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>

                 <asp:Literal ID="litscript" runat="server"></asp:Literal> 
	  
               <table  border="0" style="height:55px; width:978px;"  cellspacing="0" cellpadding="0" align="left"  valign="top" >
                  <tr>
                      <td style="width:100%; height: 21px;">
                           <table  border="0" style="width:980px; height: 21px"  cellspacing="0" cellpadding="0" align="center" >
                                <tr>
                                    <td><asp:Label ID="lblNombreCurso" runat="server" Text="Bienvenido" Font-Names="Arial" Font-Size="11px" ForeColor="White"  Font-Bold="true"></asp:Label></td>
                                   
                                    <td style="width:490px;">
                                        <table  border="0" style="width:490px; height:21px;"  cellspacing="0" cellpadding="0" align="center" >
                                            <tr>
                                                <td style="width:250px; text-align:center;"><asp:Label ID="lblnombre" runat="server" Text="Bienvenido" Font-Names="Arial" Font-Size="11px" ForeColor="White" ></asp:Label></td>
                                                <td style="width:10px;"><asp:Image ID="Image6" ImageUrl="~/images/header/rayita.png" runat="server" /></td>
                                                <td style="width:170px; text-align:center;">
                                                <asp:Label ID="lblHora" runat="server" Visible="false" Font-Names="Arial" Font-Size="11px" ForeColor="White"></asp:Label>
                                                <span id="currentTime" runat="server" style="font-family:Arial; font-size:11px; color:White;" ></span>
                                                </td>
                                                <td style="width:10px;"><asp:Image ID="Image7" ImageUrl="~/images/header/rayita.png" runat="server" /></td>
                                                <td style="width:150px; text-align:center;"><asp:Label ID="lblFecha" runat="server" Font-Names="Arial" Font-Size="11px" ForeColor="White" ></asp:Label></td>
                                            </tr>
                                        </table>  
                                       
                                        
                                     </td>    
                                </tr>
                            </table>
                          
                       </td>
                    </tr>
                    
                    <tr>
                      <td style="width:100%; height:34px;">
                            <table  border="0" style="width:978px; height:34px;"  cellspacing="0" cellpadding="0" align="center" class="FondoMenuHeader">
                                <tr>
                                    <td style="width:14px;"><asp:Image ID="Image1" ImageUrl="~/images/header/botonizq.png" runat="server" /></td>
                                    <td style="width:208px;"> <asp:HyperLink ID="lnkhome" NavigateUrl="~/sec/default.aspx" ImageUrl="~/images/header/LogoSkolar.png" runat="server" Visible="True"></asp:HyperLink> <asp:HyperLink ID="lnkmiportal" runat="server" 
                                            NavigateUrl="~/Sec/Default.aspx" 
                                            ForeColor="#CCCCCC"  Visible="False" BorderWidth="0px" BorderStyle="None" >
                                            <asp:Image ID="img1" runat="server"  ImageUrl="~/images/header/miportal.png"  /></asp:HyperLink></asp:HyperLink></td>
                                    <td style="width:456px;"> &nbsp;</td>
                                        <td style="width:105px;"><asp:HyperLink ID="lnkpregunta" runat="server"  Visible="False" ForeColor="#CCCCCC" ImageUrl="~/images/header/preguntasSalon.png" >Haz preguntas</asp:HyperLink></td>
                                     <td style="width:10px;"><asp:Image ID="Image11" ImageUrl="~/images/header/botonDivision.png" runat="server" /></td>
                                     <td style="width:105px;"><asp:HyperLink ID="lnkbb" runat="server"  Visible="False" 
                                             ForeColor="#CCCCCC" ImageUrl="~/images/salaVirtual.png" Target="_blank" >Sala virtual</asp:HyperLink></td>
                                    <td style="width:10px;"><asp:Image ID="Image10" ImageUrl="~/images/header/botonDivision.png" runat="server" /></td>
                                     <td style="width:105px;"><asp:HyperLink ID="lnkApunte" runat="server"  Visible="False" ForeColor="#CCCCCC" ImageUrl="~/images/header/apunteSalon.png" >Crear apunte de clase</asp:HyperLink></td>
                                    <td style="width:10px;"><asp:Image ID="Image9" ImageUrl="~/images/header/botonDivision.png" runat="server" /></td>
                                    <td style="width:105px;"><asp:HyperLink ID="lnkMail" runat="server" NavigateUrl="http://skolar.online" Target="_blank" Visible="False" ForeColor="#CCCCCC" ImageUrl="~/images/header/mailum.png" >Correo electrónico de la UM</asp:HyperLink></td>
                                    <td style="width:10px;"><asp:Image ID="Image3" ImageUrl="~/images/header/botonDivision.png" runat="server" /></td>
                                    <td style="width:100px;"><asp:HyperLink ID="lnkSalir" runat="server" NavigateUrl="~/logout.aspx" Visible="False" ForeColor="#CCCCCC" ImageUrl="~/images/header/salida.png" >Salir de Skolar</asp:HyperLink></td>
                                    <td style="width:10px;"><asp:Image ID="Image8" ImageUrl="~/images/header/botonDivision.png" runat="server" /></td>
                                    <td style="width:14px;"><asp:Image ID="Image2" ImageUrl="~/images/header/botonder.png" runat="server" /></td>
                                </tr>
                            </table>
                      
                      </td>
                      
                    </tr>
                   
                    
                     
              </table>
              


              <div id="datac1" class="submenu">
                  <uc1:MenuSalonVirtual ID="MenuSalonVirtual1" runat="server" />
              </div>




<script type="text/javascript" language="javascript">
    function updateTime() {
        var label = document.getElementById('ctl00_Header1_currentTime');
        if (label) {
            var time = (new Date()).localeFormat("T");
            label.innerHTML = time;
        }
    }
    updateTime();
    window.setInterval(updateTime, 1000);
 </script>
        
	<!-- END HEADER -->
 