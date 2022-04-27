<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Header.ascx.vb" Inherits="Controles_Header" %>
<!-- START HEADER -->
	 
	<header>

       

         <div class="top-bar-dark">            
            <div class="container">
                <div class="row">
                    <div class="col-sm-1 hidden-xs">
                     <%--   <div class="top-bar-socials">
                            <a href="https://www.facebook.com/Skolar" target="_blank" class="social-icon-sm si-dark si-gray-round si-colored-facebook">
                                <i class="fa fa-facebook"></i>
                                <i class="fa fa-facebook"></i>
                            </a>
                            <a href="https://twitter.com/Skolar" target="_blank" class="social-icon-sm si-dark si-gray-round si-colored-twitter">
                                <i class="fa fa-twitter"></i>
                                <i class="fa fa-twitter"></i>
                            </a>
                            
                        </div>--%>
                    </div>
                    <div class="col-sm-11 text-right">
                        <ul class="list-inline top-dark-right">
                                               
                            <li><i class="fa fa-home"></i> <asp:HyperLink ID="lnkmiportal" runat="server" NavigateUrl="~/Sec/Home.aspx"  Visible="False" >Inicio</asp:HyperLink> </li>
                            <li><i class="fa fa-desktop"></i><asp:HyperLink ID="lnkCursos" runat="server" NavigateUrl="~/Sec/default.aspx"  >Mis cursos</asp:HyperLink> </li>
                            <li><i class="fa fa-envelope"></i><asp:HyperLink ID="lnkLibrosDeTrabajo" runat="server" NavigateUrl="~/Sec/libros.aspx"  Visible="False" >Libros de Trabajo</asp:HyperLink> </li>
                            <li><i class="fa fa-book"></i><asp:HyperLink ID="lnkBiblioteca" runat="server" NavigateUrl="~/Sec/Biblioteca.aspx"  Visible="False" CssClass="menu-head" >Biblioteca</asp:HyperLink></li>
                             <li id="ctl00_Header1_Li1s" class="dropdown" style="text-align:center;">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
                                    <i class="fa fa-lock"></i> Perfil
                                </a>
                                <ul class="dropdown-menu">
                                    <li><i class="fa fa-user"><asp:HyperLink ID="lnkPerfil" runat="server" NavigateUrl="~/Sec/DatosPersonales.aspx" >Perfil</asp:HyperLink></i></li>
                                    <li><i class="fa fa-space-shuttle"><a id="ctl00_Header1_Hyperlink4" href="../../../sec/Direcciones.aspx">Direcciones de envío</a></i></li>
                                    <li role="separator" class="divider"></li>
                                    <li><a id="ctl00_Header1_lnkInformacionpersonal" href="../../../sec/personalInfo.aspx">Información personal</a></li>
                                    <li><i class="fa fa-signout"><asp:HyperLink ID="lnkSalir" runat="server" NavigateUrl="~/logout.aspx"  CssClass="menu-head" Visible="false" >Salir</asp:HyperLink></i></li>
                                </ul>
                            </li>
                             <li><asp:LinkButton ID="lnkEspanol" runat="server" Text="Español" CausesValidation="false"></asp:LinkButton> <asp:LinkButton ID="lnkIngles" runat="server" Text="English" CausesValidation="false"></asp:LinkButton></li>  
                           
                        </ul>
                        

                    </div>
                </div>
            </div>
        </div><!--top-bar-dark end here-->








     <div class="container">
        <div class="row">
            <div class="col-md-5 col-sm-5"> <asp:hyperlink ID="lnklogo" cssClass="navbar-brand" NavigateUrl="~/Sec/Home.aspx" runat="server">
                    <asp:Image ID="imgLogo" runat="server" ImageUrl="~/images/logoRedondo.png" />
                </asp:hyperlink></div>
            <div class="col-md-1">
               
            </div>
            <div class="col-md-7 col-sm-7">
                <div class="navbar-form pull-right">   
                    <div class="form-group text-right" style="">
                      
                      <asp:Label ID="lblFecha" runat="server"  Font-Size="11px"></asp:Label><br />
                      <asp:Label ID="lblnombre" runat="server"  Font-Size="11px" ></asp:Label><br />
                      <asp:Image ID="imgProfile" runat="server"  ImageUrl="~/Images/foto-head.png"  width="30px"  Visible="false"/>
                    </div>
                </div>
            </div>
        </div>
        <div style="height:10px;">&nbsp;</div>
        <div  style="height:1px; background-color:#dcdcdc">   </div>
        <div  style="height:2px; background-color:#0099FF; width:30%">   </div>
     


    </div>




	</header>
                



                

   <%-- <div class="navbar-wrapper">
      <div class="container">

        <nav class="navbar navbar-inverse navbar-static-top">
          <div class="container">
            <div class="navbar-header">
              <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
              </button>
              <a class="navbar-brand" href="#"><asp:HyperLink ID="lnkhome" NavigateUrl="~/sec/home.aspx" ImageUrl="~/images/logo-Skolar.png" runat="server" Visible="True"></asp:HyperLink></a>
            </div>
            <div id="navbar" class="navbar-collapse collapse">
              <ul class="nav navbar-nav">
                <li class="active"><a href="#">Inicio</a></li>
              
                <li class="dropdown">
                  <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false"> <span class="caret"></span></a>
                  <ul class="dropdown-menu">
                    <li></li>
                    <li></li>
                    <li role="separator" class="divider"></li>
                    <li></li>
                  
                    <li class="dropdown-header">Nav header</li>
                    <li></li>
                      <li></li>
                  </ul>
                </li>
        
                  <li></li>
              </ul>
            </div>
          </div>
        </nav>

      </div>
    </div>
--%>




	<!-- END HEADER -->
 