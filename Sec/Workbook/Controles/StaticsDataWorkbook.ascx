<%@ Control Language="VB" AutoEventWireup="false" CodeFile="StaticsDataWorkbook.ascx.vb" Inherits="Sec_Workbook_Controles_staticsDataWorkbook" %>
<head>
    <style type="text/css">
        .style1
        {
            width: 174px;
        }
        .style2
        {
            width: 7px;
        }
        .style3
        {
            width: 1px;
        }
        .style4
        {
            width: 103px;
        }
        .style5
        {
            width: 19px;
        }
    </style>
</head>
<table style="width: 554px">
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style1">
            <asp:Label ID="Label1" runat="server" Text="Titulo del libro de trabajo"></asp:Label>
        </td>
        <td colspan="4">
            <asp:Label ID="lblTitulo" runat="server" Font-Bold="True"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Image ID="Image10" runat="server" ImageUrl="~/Images/lectures.gif" />
        </td>
        <td class="style1">
            <asp:Label ID="Label2" runat="server" Text="Carpetas existentes"></asp:Label>
        </td>
        <td class="style5">
            <asp:Label ID="lblCarpetas" runat="server" Text=""></asp:Label>
        </td>
        <td class="style3">
            <asp:Image ID="Image7" runat="server" ImageUrl="~/Images/flashmov.gif" />
        </td>
        <td class="style4">
            <asp:Label ID="Label8" runat="server" Text="Peliculas flash"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblPeliculas" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style2" >
            <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/lectures.gif" />
        </td>
        <td class="style1" >
            <asp:Label ID="Label3" runat="server" Text="Lecturas"></asp:Label>
        </td>
        <td class="style5" >
            <asp:Label ID="lblLecturas" runat="server" Text=""></asp:Label>
            </td>
        <td class="style3" >
            <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/actvs.gif" />
            </td>
        <td class="style4" >
            <asp:Label ID="Label9" runat="server" Text="Actividades"></asp:Label>
            </td>
        <td >
            <asp:Label ID="lblActividades" runat="server"></asp:Label>
            </td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/images.gif" />
        </td>
        <td class="style1">
            <asp:Label ID="Label5" runat="server" Text="Imagenes"></asp:Label>
        </td>
        <td class="style5">
            <asp:Label ID="lblimagenes" runat="server"></asp:Label>
            </td>
        <td class="style3">
            <asp:Image ID="Image8" runat="server" ImageUrl="~/Images/forums.gif" />
            </td>
        <td class="style4">
            <asp:Label ID="Label6" runat="server" Text="Foros"></asp:Label>
            </td>
        <td>
            <asp:Label ID="lblForos" runat="server"></asp:Label>
            </td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Image ID="Image6" runat="server" ImageUrl="~/Images/files.gif" />
        </td>
        <td class="style1">
            <asp:Label ID="Label7" runat="server" Text="Archivos"></asp:Label>
        </td>
        <td class="style5">
            <asp:Label ID="lblArchivos" runat="server"></asp:Label>
        </td>
        <td class="style3">
            <asp:Image ID="Image9" runat="server" ImageUrl="~/Images/exam.gif" />
        </td>
        <td class="style4">
            <asp:Label ID="Label4" runat="server" Text="Examenes"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblExamenes" runat="server"></asp:Label>
        </td>
    </tr>
    </table>
