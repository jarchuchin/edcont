<%@ Page Title="" Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="Check.aspx.vb" Inherits="Sec_Workbook_Check" %>


<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc2" %>



<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Literal ID="Literal1" runat="server" Text="Revisíon" meta:resourcekey="Literal1Resource1"></asp:Literal></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">



     <uc2:MenuGeneral ID="MenuGeneral1" runat="server" />



</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelBreadcrumb" Runat="Server">

<ol class="breadcrumb" >
  <li><asp:HyperLink ID="HyperLink3" runat="server"  Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
     <li><asp:HyperLink ID="HyperLink4" runat="server"  Text="Libros de trabajo" NavigateUrl="~/sec/Libros.aspx" ></asp:HyperLink></li>
    <li><asp:HyperLink ID="lnkTitulo" runat="server"  > </asp:HyperLink></li>
  <li class="active"><asp:Label ID="lbltit" runat="server" Text="Revisíón automática" ></asp:Label></li>
</ol>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">


    <div class="panel">

        <div class="panel-heading">
            <h3 class="panel-title">
                <asp:Literal ID="Literal2" runat="server" Text="Revisión automática"></asp:Literal>
            </h3>
        </div>
        <div class="panel-body">


            <table class="nav-justified">
                <tr>
                    <td class="mail-nav" style="width: 40px; text-align: center; height: 33px;">
                        <asp:Image ID="imgCarpetas" runat="server" ImageUrl="~/images/t-mini_icon_dx_del.fw.png" />
                    </td>
                    <td style="height: 33px">
                        <asp:Label ID="lblCarpetas" runat="server" Text="3" Visible="False"></asp:Label>
                        <asp:HyperLink ID="lnkCarpetas" runat="server" cssclass="btn-link" Text="carpetas o unidades"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="mail-nav" style="width: 40px; text-align: center; height: 33px;">
                        <asp:Image ID="imgContenidos" runat="server" ImageUrl="~/images/t-mini_icon_dx_del.fw.png" />
                    </td>
                    <td class="push" style="height: 33px">
                        <asp:Label ID="lblContenidos" runat="server" Text="6" Visible="False"></asp:Label>
                        <asp:HyperLink ID="lnkContenidos" runat="server" cssclass="btn-link"  Text="contenidos temáticos"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="mail-nav" style="width: 40px; text-align: center; height: 33px;">
                        <asp:Image ID="imgForos" runat="server" ImageUrl="~/images/t-mini_icon_dx_del.fw.png" />
                    </td>
                    <td style="height: 33px">
                        <asp:Label ID="lblForos" runat="server" Text="2" Visible="False"></asp:Label>
                        <asp:HyperLink ID="lnkForos" runat="server" cssclass="btn-link"  Text="Foros"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="mail-nav" style="width: 40px; text-align: center; height: 33px;">
                        <asp:Image ID="imgActividades" runat="server" ImageUrl="~/images/t-mini_icon_dx_del.fw.png" />
                    </td>
                    <td class="push" style="height: 33px">
                        <asp:Label ID="lblActividades" runat="server" Text="3" Visible="False"></asp:Label>
                        <asp:HyperLink ID="lnkActividades"  cssclass="btn-link"  runat="server">Actividades</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="mail-nav" style="width: 40px; text-align: center; height: 33px">
                        <asp:Image ID="imgExamenes" runat="server" ImageUrl="~/images/t-mini_icon_dx_del.fw.png" />
                    </td>
                    <td style="height: 33px">
                        <asp:Label ID="lblExamenes" runat="server" Text="3" Visible="False"></asp:Label>
                        <asp:HyperLink ID="lnkExamenes" runat="server"  cssclass="btn-link"  Text="Exámenes"></asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="mail-nav" style="width: 40px; text-align: center; height: 25px">&nbsp;</td>
                    <td style="height: 25px">&nbsp;</td>
                </tr>
                <tr>
                    <td class="mail-nav" style="width: 40px; text-align: center">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>


        </div>

    </div>

</asp:Content>


