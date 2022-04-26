<%@ Page Title="" Language="VB" MasterPageFile="~/MPUsmart01.master" AutoEventWireup="false" CodeFile="ListaRubricas.aspx.vb" Inherits="Sec_Administracion_ListaRubricas" %>

<%@ Register src="Controles/MenuAdministracion.ascx" tagname="MenuAdministracion" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelIzquierdo" Runat="Server">
    <uc1:MenuAdministracion ID="MenuAdministracion1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

  <div id="Caja">
  <table style="width:100%;"  cellspacing="0" cellpadding="0" border="0" >
    <tr>
        <td style="width:300px;"><asp:Label ID="lblTitulo" runat="server" CssClass="TituloCaja" >Lista de rubricas</asp:Label></td>
        <td style="text-align:right;">
            <asp:Button ID="btnAgregarRubrica" runat="server" Text="Agregar rubrica" /></td>
    </tr>
  </table>



  <div style="height:20px;"></div>


   <asp:GridView id="gvRubricas" runat="server" AllowSorting="True" Width="100%" 
                AutoGenerateColumns="False" GridLines="None">
                <Columns>
                

                 <asp:HyperLinkField DataNavigateUrlFields="idRubrica" Text="Editar"  ControlStyle-CssClass="LigaVerde"
                       DataNavigateUrlFormatString="~/sec/Administracion/Rubrica.aspx?idRubrica={0}" > 
                       <HeaderStyle  HorizontalAlign="Left"  Width="50px"/>
                 </asp:HyperLinkField>
                    

                <asp:BoundField DataField="Titulo"  HeaderText="Título" SortExpression="Titulo"  >
                    <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="270px" />
                 </asp:BoundField>
                  <asp:BoundField DataField="Descripcion"  HeaderText="Descripcion" SortExpression="Descripcion"  >
                    <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                 </asp:BoundField>
                
              
         
                    
              
                        
                </Columns>
                <HeaderStyle Font-Bold="True" ForeColor="Black" horizontalalign="center" 
                    BackColor="White"/>
                <AlternatingRowStyle BackColor="White" />
                
            </asp:GridView>



            </div>
</asp:Content>

