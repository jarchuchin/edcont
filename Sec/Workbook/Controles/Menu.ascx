<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Menu.ascx.vb" Inherits="Sec_Workbook_Controles_Menu" %>



<div class="mar-btm">
	<h4 class="text-thin"><i class="fa fa-cogs fa-lg fa-fw text-warning"></i> <asp:Literal ID="Literal1" runat="server" Text="Menú principal"></asp:Literal> </h4>
	<div class="list-group bg-trans">
        <asp:HyperLink ID="lnkPortal1" runat="server" text="Información general" NavigateUrl="~/Sec/workbook/Home.aspx"  CssClass="list-group-item">
            <span class="badge badge-purple badge-icon badge-fw pull-left"></span> <asp:Literal ID="Literal2" runat="server" Text="Información general" ></asp:Literal>
        </asp:HyperLink>
        <asp:HyperLink ID="lnkAgregarContenido1" runat="server" text="Explorar contenido" NavigateUrl="~/Sec/workbook/Explorar.aspx" CssClass="list-group-item">
            <span class="badge badge-info badge-icon badge-fw pull-left"></span><asp:Literal ID="Literal3" runat="server" Text="Explorar contenido" ></asp:Literal>
        </asp:HyperLink>
         <asp:HyperLink ID="lnkRevisionAutomatico" runat="server" text="Explorar contenido" NavigateUrl="~/Sec/workbook/Check.aspx" CssClass="list-group-item">
            <span class="badge badge-warning badge-icon badge-fw pull-left"></span><asp:Literal ID="Literal6" runat="server" Text="Revisión automática" ></asp:Literal>
        </asp:HyperLink>
        <asp:HyperLink ID="lnkIdiomas" runat="server" text="Idiomas" NavigateUrl="~/Sec/workbook/Idiomas.aspx" CssClass="list-group-item">
            <span class="badge badge-pink badge-icon badge-fw pull-left"></span><asp:Literal ID="Literal4" runat="server"  Text="Idiomas"></asp:Literal>
        </asp:HyperLink>
        <asp:HyperLink ID="lnkPermisos1" runat="server" text="Permisos" NavigateUrl="~/Sec/workbook/Permisos.aspx" CssClass="list-group-item">
            <span class="badge badge-success badge-icon badge-fw pull-left"></span> <asp:Literal ID="Literal5" runat="server" text="Permisos"></asp:Literal>
        </asp:HyperLink>
		
	</div>
</div>

       

       


      





