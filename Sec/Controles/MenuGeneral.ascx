<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MenuGeneral.ascx.vb" Inherits="Sec_Controles_MenuGeneral" %>








            <!--MAIN NAVIGATION-->
            <!--===================================================-->
            <nav id="mainnav-container">
                <div id="mainnav">

                <%--    <!--Shortcut buttons-->
                    <!--================================-->
                    <div id="mainnav-shortcut">
                        <ul class="list-unstyled">
                            <li class="col-xs-4" data-content="Additional Sidebar">
                                <a id="demo-toggle-aside" class="shortcut-grid" href="#">
                                    <i class="psi-sidebar-window"></i>
                                </a>
                            </li>
                            <li class="col-xs-4" data-content="Notification">
                                <a id="demo-alert" class="shortcut-grid" href="#">
                                    <i class="psi-speech-bubble-comic-2"></i>
                                </a>
                            </li>
                            <li class="col-xs-4" data-content="Page Alerts">
                                <a id="demo-page-alert" class="shortcut-grid" href="#">
                                    <i class="psi-warning-window"></i>
                                </a>
                            </li>
                        </ul>
                    </div>
                    <!--================================-->
                    <!--End shortcut buttons-->--%>


                    <!--Menu-->
                    <!--================================-->
                    <div id="mainnav-menu-wrap">
                        <div class="nano">
                            <div class="nano-content">
                                <ul id="mainnav-menu" class="list-group">
						
						         
                                    <li id="liInicio" runat="server"  >
                                        <asp:HyperLink ID="lnkIncio" runat="server" text="Inicio" NavigateUrl="~/Sec/home.aspx">
                                             <i class="psi-home"></i>
						                    <span class="menu-title">
												<strong><asp:Literal ID="litInicio" runat="server"  Text="Portal de inicio"></asp:Literal></strong>
												<%--<span class="label label-success pull-right"><asp:Literal ID="Literal1" runat="server"  Text="Top"></asp:Literal></span>--%>
											</span>
                                        </asp:HyperLink>

                                    </li>


                                     <li id="liCursosAlumno" runat="server"  >
                                        <asp:HyperLink ID="HyperLinkd5" runat="server" NavigateUrl="~/Sec/default.aspx">
                                             <i class="psi-wacom-tablet"></i>
						                    <span class="menu-title">
												<strong><asp:Literal ID="Literal1" runat="server"  Text="Mis cursos como alumno"></asp:Literal></strong>
												<%--<span class="label label-success pull-right"><asp:Literal ID="Literal1" runat="server"  Text="Top"></asp:Literal></span>--%>
											</span>
                                        </asp:HyperLink>

                                    </li>

                                     <li id="liCursosDocente" runat="server"  >
                                        <asp:HyperLink ID="HyperLink5sd" runat="server" NavigateUrl="~/Sec/defaultDocente.aspx">
                                             <i class="psi-computer-3"></i>
						                    <span class="menu-title">
												<strong><asp:Literal ID="Literal2" runat="server"  Text="Mis cursos como docente"></asp:Literal></strong>
												<%--<span class="label label-success pull-right"><asp:Literal ID="Literal1" runat="server"  Text="Top"></asp:Literal></span>--%>
											</span>
                                        </asp:HyperLink>

                                    </li>

                                    <%-- <li id="liCursos" runat="server" >
                                        

                                         <a href="#">
						                    <i class="psi-board"></i>
						                    <span class="menu-title">
												<strong><asp:Literal ID="Literal3" runat="server"  Text="Mis cursos"></asp:Literal></strong>
											</span>
											<i class="arrow"></i>
						                </a>
						
						                <!--Submenu-->
						                <ul class="collapse">
						                    <li>
                                                
                                                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Sec/default.aspx"><asp:Literal ID="Literal7" runat="server"  Text="Cursos como alumno"></asp:Literal></asp:HyperLink>
                                              
                                            </li>
											<li><asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Sec/defaultDocente.aspx"><asp:Literal ID="Literal8" runat="server"  Text="Cursos como docente"></asp:Literal></asp:HyperLink></li>
                                        </ul>


                                     </li>--%>

                                    <li id="liLibros" runat="server" >
                                         <asp:HyperLink ID="HyperLink1" runat="server"  NavigateUrl="~/Sec/libros.aspx" >
                                            <i class="psi-books-2"></i>
						                    <span class="menu-title">
												<strong><asp:Literal ID="Literal6" runat="server"  Text="Libros de trabajo"></asp:Literal></strong>
											</span>
                                           
                                         </asp:HyperLink>
                                    </li>

                            <%--         <li id="liLibro" runat="server" visible="false"  >
                                         <asp:HyperLink ID="lnkLibro2" runat="server"  NavigateUrl="~/Sec/libros.aspx" >
                                            <i class="psi-split-vertical-2"></i>
						                    <span class="menu-title">
												<strong><asp:Literal ID="litRootName" runat="server" ></asp:Literal></strong>
											</span>
                                            <i class="arrow"></i>
                                         </asp:HyperLink>

                                     
                                          <!--Submenu-->
						                  <ul class="collapse" runat="server" visible="false" id="ulLibroDeTrabajo">

                                            
                                                <li id="liLibroInicio" runat="server" ><asp:HyperLink ID="lnkPortal1" runat="server" text="Información general" NavigateUrl="~/Sec/workbook/Home.aspx"></asp:HyperLink></li>
                                                <li id="liLibroExplorar" runat="server" ><asp:HyperLink ID="lnkAgregarContenido1" runat="server" text="Explorar contenido" NavigateUrl="~/Sec/workbook/Explorar.aspx" ></asp:HyperLink></li>
                                                <li id="liLibroIdiomas" runat="server" ><asp:HyperLink ID="lnkIdiomas" runat="server" text="Idiomas" NavigateUrl="~/Sec/workbook/Idiomas.aspx" ></asp:HyperLink></li>
                                                <li id="LiLibroPermisos" runat="server" ><asp:HyperLink ID="lnkPermisos1" runat="server" text="Permisos" NavigateUrl="~/Sec/workbook/Permisos.aspx" ></asp:HyperLink></li>
                                            
                                          </ul>

                                     </li>--%>

                                     <li id="libibliotecas" runat="server">
                                         <asp:HyperLink ID="lnkBiblioteca" runat="server" NavigateUrl="~/Sec/Biblioteca.aspx" >
                                            <i class="psi-university"></i>
						                    <span class="menu-title">
												<strong><asp:Literal ID="Literal4" runat="server"  Text="Biblioteca"></asp:Literal></strong>
											</span>
                                         </asp:HyperLink>

                                     </li>


						
						          <%--  <!--Menu list item-->
						            <li>
						                <a href="#">
						                    <i class="psi-split-vertical-2"></i>
						                    <span class="menu-title">
												<strong>Ayuda</strong>
											</span>
											<i class="arrow"></i>
						                </a>
						
						                <!--Submenu-->
						                <ul class="collapse">
						                    <li><a href="layouts-collapsed-navigation.html">Collapsed Navigation</a></li>
											<li><a href="layouts-offcanvas-navigation.html">Off-Canvas Navigation</a></li>
											<li><a href="layouts-offcanvas-slide-in-navigation.html">Slide-in Navigation</a></li>
											<li><a href="layouts-offcanvas-revealing-navigation.html">Revealing Navigation</a></li>
											<li class="list-divider"></li>
											<li><a href="layouts-aside-right-side.html">Aside on the right side</a></li>
											<li><a href="layouts-aside-left-side.html">Aside on the left side</a></li>
											<li><a href="layouts-aside-bright-theme.html">Bright aside theme</a></li>
											<li class="list-divider"></li>
											<li><a href="layouts-fixed-navbar.html">Fixed Navbar</a></li>
											<li><a href="layouts-fixed-footer.html">Fixed Footer</a></li>
											
						                </ul>
						            </li>--%>
						
						        
						
						            <li class="list-divider"></li>
						
						          
						            <!--Category name-->
						            <li class="list-header">Permisos especiales</li>
						
						            <!--Menu list item-->
						            <li id="liAdministracion" runat="server">
						                <a href="#">
						                    <i class="psi-bar-chart"></i>
						                    <span class="menu-title">
                                                <asp:Literal ID="Literal5" runat="server" Text="Administración"></asp:Literal></span>
											<i class="arrow"></i>
						                </a>
						
						                <!--Submenu-->
						                <ul class="collapse">
						                    <li><asp:HyperLink ID="lnkUsuarios3" runat="server" text="Administración de usuarios" NavigateUrl="~/Sec/Administracion/Default.aspx" ></asp:HyperLink></li>
											<li><asp:HyperLink ID="lnkPermisos3" runat="server" text="Permisos" NavigateUrl="~/Sec/Administracion/Permisos.aspx"></asp:HyperLink></li>
											<li><asp:HyperLink ID="lnksalones3" runat="server" text="Administración de cursos" NavigateUrl="~/Sec/Administracion/salones.aspx" ></asp:HyperLink></li>
                                            <li><asp:HyperLink ID="HyperLink3" runat="server" text="Libros de trabajo" NavigateUrl="~/Sec/Administracion/libros.aspx" ></asp:HyperLink></li>
											 <li id="liMensaje" runat="server" visible="false"><asp:HyperLink ID="HyperLink2" runat="server" text="Configuración" NavigateUrl="~/Sec/Administracion/ConfiguracionGeneral.aspx" ></asp:HyperLink></li>
						                </ul>
						            </li>
						
						        
                                </ul>


                                <!--Widget-->
                                <!--================================-->
                                <div class="mainnav-widget">

                                    <!-- Show the button on collapsed navigation -->
                                    <div class="show-small">
                                        <a href="#" data-toggle="menu-widget" data-target="#demo-wg-server">
                                            <i class="fa fa-desktop"></i>
                                        </a>
                                    </div>

                                    <!-- Hide the content on collapsed navigation -->
                                    <div id="demo-wg-server" class="hide-small mainnav-widget-content">
                                        <ul class="list-group">
                                            <li class="list-header pad-no pad-ver">Progreso del alumno</li>
                                            <li class="mar-btm">
                                                <span class="label label-primary pull-right">75%</span>
                                                <p>Promedio de cursos</p>
                                                <div class="progress progress-sm">
                                                    <div class="progress-bar progress-bar-primary" style="width: 75%;">
                                                        <span class="sr-only">75%</span>
                                                    </div>
                                                </div>
                                            </li>
                                            <li class="mar-btm">
                                                <span class="label label-purple pull-right">60%</span>
                                                <p>Actividades enviadas</p>
                                                <div class="progress progress-sm">
                                                    <div class="progress-bar progress-bar-purple" style="width: 60%;">
                                                        <span class="sr-only">60%</span>
                                                    </div>
                                                </div>
                                            </li>
                                            <li class="pad-ver"><a href="#" class="btn btn-success btn-bock">Ver detalles</a></li>
                                        </ul>
                                    </div>
                                </div>
                                <!--================================-->
                                <!--End widget-->

                            </div>
                        </div>
                    </div>
                    <!--================================-->
                    <!--End menu-->

                </div>
            </nav>
            <!--===================================================-->
            <!--END MAIN NAVIGATION-->


</div>