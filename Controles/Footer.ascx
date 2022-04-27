<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Footer.ascx.vb" Inherits="Controles_Footer" %>









<!-- FOOTER -->
        <!--===================================================-->
        <footer id="footer">

            <!-- Visible when footer positions are fixed -->
            <!-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ -->
            <div class="pull-right">
                <ul class="footer-list list-inline">
                  
               
                    <li>
                        <asp:LinkButton ID="lnkEspanol" runat="server" Text="Español" CausesValidation="False" meta:resourcekey="lnkEspanolResource1" CssClass="btn btn-sm btn-dark btn-active-success"></asp:LinkButton> <asp:LinkButton ID="lnkIngles" runat="server" Text="English" CausesValidation="False" meta:resourcekey="lnkInglesResource1" CssClass="btn btn-sm btn-dark btn-active-success"></asp:LinkButton>
               
                    </li>
                </ul>
            </div>



            <!-- Visible when footer positions are static -->
            <!-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ -->
            <div class="pull-right pad-rgt">Usuarios en línea: <asp:Label ID="lblUsuarios" runat="server"></asp:Label></div>



            <!-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ -->
            <!-- Remove the class name "show-fixed" and "hide-fixed" to make the content always appears. -->
            <!-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ -->

            <p class="pad-lft"> Edcont &#0169;  Education Solutions Powered by edcont.com it solutions </p>



        </footer>
        <!--===================================================-->
        <!-- END FOOTER -->
