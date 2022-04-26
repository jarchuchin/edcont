<%@ Control Language="VB" AutoEventWireup="false" CodeFile="HeaderTest.ascx.vb" Inherits="Controles_HeaderTest" %>

 <!--NAVBAR-->
<!--===================================================-->
<header id="navbar" >

   
    <div id="navbar-container" class="boxed">

      <div class="text-center" style="background-color:#f1f4f7" >
        <div style="height:4px;"></div>
       <asp:HyperLink ID="lnkGeneral" runat="server" NavigateUrl="~/sec/home.aspx"><asp:Image runat="server" ID="logoPrincipal" ImageUrl="~/images/skolar.png"  Height="45px"/></asp:HyperLink> 
        <div style="height:4px;"></div>

    </div>
    </div>

    <div id="navbar-container" class="boxed">

        <!--Brand logo & name-->
        <!--================================-->
        <div class="navbar-header">
            <asp:HyperLink ID="lnkHome" NavigateUrl="~/sec/Home.aspx" CssClass="navbar-brand"  runat="server">
                <asp:Image ID="imgLogo" runat="server" ImageUrl="~/images/skcolarIcon.png" ToolTip="Eskolar" CssClass="brand-icon" />
               <%-- <div class="brand-title">
                    <span class="brand-text">Skolar</span>
                </div>--%>
            </asp:HyperLink>
        </div>
        <!--================================-->
        <!--End brand logo & name-->


        <!--Navbar Dropdown-->
        <!--================================-->
        <div class="navbar-content clearfix">
            <ul class="nav navbar-top-links pull-left">

                <!--Navigation toogle button-->
                <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
                <li class="tgl-menu-btn">
                    <a class="mainnav-toggle" href="#">
                        <i class="pli-view-list"></i>
                    </a>
                </li>
                <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
                <!--End Navigation toogle button-->



                <!--Notification dropdown-->
                <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
                <li class="dropdown">
                    <a href="#" data-toggle="dropdown" class="dropdown-toggle">
                        <i class="pli-bell"></i>
                        <span class="badge badge-header badge-danger"></span>
                    </a>

                    <!--Notification dropdown menu-->
                    <div class="dropdown-menu dropdown-menu-md">
                        <div class="pad-all bord-btm">
                            <p class="text-lg text-semibold mar-no">Centro de notificaciónes.</p>
                        </div>
                        <div class="nano scrollable">
                            <div class="nano-content">
                                <ul class="head-list">

                                    <!-- Dropdown list-->
                                    <li>
                                        <a href="#">
                                            <div class="clearfix">
                                                <p class="pull-left">Progreso de cursos</p>
                                                <p class="pull-right">70%</p>
                                            </div>
                                            <div class="progress progress-sm">
                                                <div style="width: 70%;" class="progress-bar">
                                                    <span class="sr-only">70% Completado</span>
                                                </div>
                                            </div>
                                        </a>
                                    </li>

                                    <!-- Dropdown list-->
                                    <li>
                                        <a href="#">
                                            <div class="clearfix">
                                                <p class="pull-left">Calificaciónes</p>
                                                <p class="pull-right">10%</p>
                                            </div>
                                            <div class="progress progress-sm">
                                                <div style="width: 10%;" class="progress-bar progress-bar-warning">
                                                    <span class="sr-only">10% Completado</span>
                                                </div>
                                            </div>
                                        </a>
                                    </li>

                                    <!-- Dropdown list-->
                                    <li>
                                        <a class="media" href="#">
                                    <span class="badge badge-success pull-right">90%</span>
                                            <div class="media-left">
                                                <i class="pli-data-settings icon-2x"></i>
                                            </div>
                                            <div class="media-body">
                                                <div class="text-nowrap">Respositorio general</div>
                                                <small class="text-muted">50 minutos</small>
                                            </div>
                                        </a>
                                    </li>

                                    <!-- Dropdown list-->
                                    <li>
                                        <a class="media" href="#">
                                            <div class="media-left">
                                                <i class="pli-file-edit icon-2x"></i>
                                            </div>
                                            <div class="media-body">
                                                <div class="text-nowrap">Nuevas tareas</div>
                                                <small class="text-muted">Ultimas tareas</small>
                                            </div>
                                        </a>
                                    </li>

                                 <%--   <!-- Dropdown list-->
                                    <li>
                                        <a class="media" href="#">
                                    <span class="label label-danger pull-right">New</span>
                                            <div class="media-left">
                                                <i class="pli-speech-bubble-7 icon-2x"></i>
                                            </div>
                                            <div class="media-body">
                                                <div class="text-nowrap">Comment Sorting</div>
                                                <small class="text-muted">Last Update 8 hours ago</small>
                                            </div>
                                        </a>
                                    </li>

                                    <!-- Dropdown list-->
                                    <li>
                                        <a class="media" href="#">
                                            <div class="media-left">
                                                <i class="pli-add-user-plus-star icon-2x"></i>
                                            </div>
                                            <div class="media-body">
                                                <div class="text-nowrap">New User Registered</div>
                                                <small class="text-muted">4 minutes ago</small>
                                            </div>
                                        </a>
                                    </li>--%>
                                   
                                   <%-- <!-- Dropdown list-->
                                    <li class="bg-gray">
                                        <a class="media" href="#">
                                            <div class="media-left">
                                                <img class="img-circle img-sm" alt="Profile Picture" src="img/av4.png">
                                            </div>
                                            <div class="media-body">
                                                <div class="text-nowrap">Lucy sent you a message</div>
                                                <small class="text-muted">30 minutes ago</small>
                                            </div>
                                        </a>
                                    </li>

                                    <!-- Dropdown list-->
                                    <li class="bg-gray">
                                        <a class="media" href="#">
                                            <div class="media-left">
                                                <img class="img-circle img-sm" alt="Profile Picture" src="img/av3.png">
                                            </div>
                                            <div class="media-body">
                                                <div class="text-nowrap">Jackson sent you a message</div>
                                                <small class="text-muted">40 minutes ago</small>
                                            </div>
                                        </a>
                                    </li>--%>
                                </ul>
                            </div>
                        </div>

                        <!--Dropdown footer-->
                        <div class="pad-all bord-top">
                            <a href="/sec/ActividadePendientes.aspx" class="btn-link text-dark box-block">
                                <i class="fa fa-angle-right fa-lg pull-right"></i>Mostrar actividades pendientes
                            </a>
                        </div>
                    </div>
                </li>
                <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
                <!--End notifications dropdown-->



                <!--Mega dropdown-->
                <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
                <li class="mega-dropdown">
                    <a href="#" class="mega-dropdown-toggle">
                        <i class="pli-layout-grid"></i>
                    </a>
                    <div class="dropdown-menu mega-dropdown-menu">
                        <div class="clearfix">
                            <div class="col-sm-12 col-md-3">

                                <!--Mega menu widget-->
                                <div class="text-center bg-warning pad-all">
                                    <h3 class="text-thin mar-no">Información financiera</h3>
                                    <div class="pad-ver box-inline">
                                        <span class="icon-wrap icon-wrap-lg icon-circle bg-trans-light">
                                            <i class="psi-coin fa-4x"></i>
                                        </span>
                                    </div>
                                    <p class="pad-btm">
                                        Saldo Global: <span class="text-lg text-bold">
                                            <asp:Literal ID="litsaldoglobal" runat="server"></asp:Literal></span>
                                        
                                    </p>
                                   
                                    <asp:HyperLink runat="server" NavigateUrl="~/sec/pagoenlinea.aspx" CssClass="btn btn-success" Text="Ir a pago en línea"
></asp:HyperLink>                                    
                                </div>

                            </div>
                            <div class="col-sm-4 col-md-3">

                                <!--Mega menu list-->
                                <ul class="list-unstyled">
									<li class="dropdown-header"><asp:Literal ID="Literal3" runat="server" Text="Páginas principales"></asp:Literal></li>
									<li><asp:HyperLink ID="HyperLink1" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
									<li><asp:HyperLink ID="HyperLink2" runat="server" Text="Datos personales" NavigateUrl="~/sec/DatosPersonales.aspx"></asp:HyperLink></li>
									<li><asp:HyperLink ID="HyperLink3" runat="server" Text="Biblioteca" NavigateUrl="~/sec/Biblioteca.aspx"></asp:HyperLink></li>
								<%--	<li><a href="#">Sreen Lock</a></li>
									<li><a href="#" class="disabled">Disabled</a></li>--%>
									<li class="divider"></li>
									<li class="dropdown-header"><asp:Literal ID="Literal4" runat="server" Text="Libros de trabajo"></asp:Literal></li>
									<li><asp:HyperLink ID="HyperLink4" runat="server" Text="Mis ibros de trabajo" NavigateUrl="~/sec/libros.aspx"></asp:HyperLink></li>
								<%--	<li><a href="#">Skycons</a></li>--%>
                                </ul>

                            </div>
                            <div class="col-sm-4 col-md-3">

                                <!--Mega menu list-->
                                <ul class="list-unstyled">
									<li class="dropdown-header"><asp:Literal ID="Literal5" runat="server" Text="Mis cursos como"></asp:Literal></li>
                                    <li><asp:HyperLink ID="HyperLink6" runat="server" Text="Alumno" NavigateUrl="~/sec/default.aspx"></asp:HyperLink></li>
                                    <li><asp:HyperLink ID="HyperLink5" runat="server" Text="Docente" NavigateUrl="~/sec/default.aspx"></asp:HyperLink></li>
							
									<li class="divider"></li>
									<li class="dropdown-header"><asp:Literal ID="Literal6" runat="server" Text="Tutoriales"></asp:Literal></li>
									<li><asp:HyperLink ID="HyperLink9" runat="server" Text="Tutoriales" NavigateUrl="~/sec/tutoriales.aspx" Target="_blank"></asp:HyperLink></li>
								
									
                                </ul>

                            </div>
                            <div class="col-sm-4 col-md-3">

                                <!--Mega menu list-->
                                <ul class="list-unstyled">
									<li class="dropdown-header"><asp:Literal ID="Literal7" runat="server" Text="Servicios Academicos"></asp:Literal></li>
									<li><asp:HyperLink ID="HyperLink10" runat="server" Text="Sitio general" NavigateUrl="https://google.com" Target="_blank"></asp:HyperLink></li>
									
                                </ul>
                            </div>
                        </div>
                    </div>
                </li>
                <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
                <!--End mega dropdown-->

            </ul>
            <ul class="nav navbar-top-links pull-right">

                <!--Language selector-->
                <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
                <li class="dropdown">
                    <a id="demo-lang-switch" class="lang-selector dropdown-toggle" href="#" data-toggle="dropdown">
                        <span class="lang-selected">
                            <asp:Image ID="imgSeleccionada" runat="server" class="lang-flag" />
                        </span>
                    </a>

                    <!--Language selector menu-->
                    <ul class="head-list dropdown-menu">
						<li>
						    <!--English-->
						    <a href="#" >
						        <asp:Image ID="Image1" runat="server" cssclass="lang-flag" imageurl="~/img/flags/usa.jpg" AlternateText="English"/>
						        <span class="lang-id">EN</span>
						        <span class="lang-name">English</span>
						    </a>
						</li>						
						<li>
						    <!--Mexico-->
						    <a href="#">
						        <asp:Image ID="Image2" runat="server" cssclass="lang-flag" imageurl="~/img/flags/mexico.jpg" AlternateText="México"/>
						        <span class="lang-id">ES</span>
						        <span class="lang-name">Espa&ntilde;ol</span>
						    </a>
						</li>
                   
						


                    </ul>
                </li>
                <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
                <!--End language selector-->



                <!--User dropdown-->
                <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
                <li id="dropdown-user" class="dropdown">
                    <a href="#" data-toggle="dropdown" class="dropdown-toggle text-right">
                        <span class="pull-right">
                            <%--<img class="img-circle img-user media-object" src="img/av1.png" alt="Profile Picture">--%>
                            <asp:Image ID="imgProfile" runat="server"  ImageUrl="~/Images/foto-head.png"  class="img-circle img-user media-object"  />
                        </span>
                        <div class="username hidden-xs"><asp:literal ID="lblnombre" runat="server" ></asp:literal></div>
                    </a>


                    <div class="dropdown-menu dropdown-menu-md dropdown-menu-right panel-default">

                        <!-- Dropdown heading  -->
                        <div class="pad-all bord-btm">
                            <p class="text-lg text-semibold mar-btm">750Gb of 1,000Gb Used</p>
                            <div class="progress progress-sm">
                                <div class="progress-bar" style="width: 70%;">
                                    <span class="sr-only">70%</span>
                                </div>
                            </div>
                        </div>


                        <!-- User dropdown menu -->
                        <ul class="head-list">
                            <li>
                                <asp:HyperLink ID="lnkProfile" NavigateUrl="~/sec/DatosPersonales.aspx" runat="server">
                                     <i class="pli-male icon-lg icon-fw"></i> <asp:Literal ID="Literal2" runat="server" Text="Profile"></asp:Literal>
                                </asp:HyperLink>
                            </li>
                          <%--  <li>
                                <a href="#">
                                    <span class="badge badge-danger pull-right">9</span>
                                    <i class="pli-mail icon-lg icon-fw"></i> Messages
                                </a>
                            </li>
                            <li>
                                <a href="#">
                                    <span class="label label-success pull-right">New</span>
                                    <i class="pli-gear icon-lg icon-fw"></i> Settings
                                </a>
                            </li>
                            <li>
                                <a href="#">
                                    <i class="pli-information icon-lg icon-fw"></i> Help
                                </a>
                            </li>
                            <li>
                                <a href="#">
                                    <i class="pli-computer-secure icon-lg icon-fw"></i> Lock screen
                                </a>
                            </li>--%>
                        </ul>

                        <!-- Dropdown footer -->
                        <div class="pad-all text-right">
                            <%--<a href="pages-login.html" class="btn btn-primary">
                                <i class="pli-unlock"></i> Logout
                            </a>--%>
                            <asp:HyperLink ID="lnklogout" Cssclass="btn btn-primary" runat="server" NavigateUrl="~/logout.aspx">
                                 <i class="pli-unlock"></i> <asp:Literal ID="Literal1" runat="server" Text="Logout"></asp:Literal>
                            </asp:HyperLink>
                        </div>
                    </div>
                </li>
                <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
                <!--End user dropdown-->

            </ul>
        </div>
        <!--================================-->
        <!--End Navbar Dropdown-->

    </div>
</header>
<!--===================================================-->
<!--END NAVBAR-->

