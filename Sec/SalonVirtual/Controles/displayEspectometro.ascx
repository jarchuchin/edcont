<%@ Control Language="VB" AutoEventWireup="false" CodeFile="displayEspectometro.ascx.vb" Inherits="Sec_SalonVirtual_Controles_displayEspectometro" %>


<div class="panel">
    <div class="panel-heading">
            <h3 class="panel-title"><asp:Label ID="Label7" runat="server" Text="Avance del curso"></asp:Label></h3>
    </div>
    <div class="panel-body">
         <table style="width:179px" align="center">
        <tr>
            <td >
                <asp:Image ID="Image1" ImageUrl="~/images/espectometro/100kmh.gif" CssClass="img-responsive" runat="server" />
            </td>
        </tr>
    </table>

    <div style="height:15px;"></div>
    
    <asp:Panel ID="PanelAlumno" runat="server">
    <table style=" width:100%">    
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Actividades enviadas: "  >
                </asp:Label>
                <asp:Label ID="lblActividadesAlumno" 
                      runat="server" Font-Bold="False"></asp:Label><br />
                
                <asp:Label ID="Label3" runat="server" Text="Promedio actividades: "  >
                </asp:Label>
                <asp:Label ID="lblPromedioActividadesAlumno" 
                     runat="server" Font-Bold="False"></asp:Label><br />
                
                <asp:Label ID="Label4" runat="server" Text="Promedio general: "  >
                </asp:Label>
                <asp:Label ID="lblPromedioGeneralAlumno" 
                     runat="server" Font-Bold="False"></asp:Label><br />
                    
                     <asp:Label ID="Label5" runat="server" Text="Contenidos evaluados: " >
                </asp:Label>
                <asp:Label ID="lblContenidosAlumno" 
                     runat="server" Font-Bold="False"></asp:Label>
                
             </td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="PanelMestro" runat="server">
    <table style=" width:100%">    
        <tr>
            <td>
                <asp:Label ID="hertherth" runat="server" Text="Actividades enviadas: "  >
                </asp:Label>
                <asp:Label ID="lblActividadesRevisadasMaestro" 
                      runat="server" Font-Bold="False"></asp:Label><br />
                
                <asp:Label ID="gererg" runat="server" Text="Promedio actividades: "  >
                </asp:Label>
                <asp:Label ID="lblPromedioActividadesMestro" 
                     runat="server" Font-Bold="False"></asp:Label><br />
                
                <asp:Label ID="sd" runat="server" Text="Promedio general: "  >
                </asp:Label>
                <asp:Label ID="lblPromedioGeneralMaestro" 
                 runat="server" Font-Bold="False"></asp:Label><br />
                    
                     <asp:Label ID="Label2" runat="server" Text="Promedio contenidos: "  >
                </asp:Label>
                <asp:Label ID="lblContenidosMaestro" 
                      runat="server" Font-Bold="False"></asp:Label>
                
             </td>
        </tr>
    </table>
</asp:Panel>



    <asp:HiddenField ID="hdclaveusuario" runat="server" />
    <asp:HiddenField ID="hdclavesalon" runat="server" />


    </div>
</div>



