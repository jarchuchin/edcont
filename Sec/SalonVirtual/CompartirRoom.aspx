<%@ Page Title="" Language="VB" MasterPageFile="~/MPUsmart01.master" AutoEventWireup="false" CodeFile="CompartirRoom.aspx.vb" Inherits="Sec_SalonVirtual_CompartirRoom" %>

<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>

<asp:Content ID="contentBreadCrumb" ContentPlaceHolderID="ContentPanelBreadcrumb" Runat="Server">
</asp:Content>

<asp:Content ID="contentIzquierdo" ContentPlaceHolderID="ContentPanelIzquierdo" Runat="Server">
    <uc1:MenuSalonVirtual ID="MenuSalonVirtual1" runat="server" />
</asp:Content>

<asp:Content ID="contentEdicion" ContentPlaceHolderID="ContentPanelEdicion" Runat="Server">
</asp:Content>

<asp:Content ID="contentCentral" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
	<table style="width: 100%">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Cursos disponibles" 
                    Font-Bold="True"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Cursos compartidos" 
                    Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
          <td style="vertical-align:top; width:350px">
             
             
              <asp:GridView ID="gvDisponibles" runat="server" AllowSorting="True" 
                  DataKeyNames="idSalonVirtual" AutoGenerateColumns="False" Width="350px" 
                  GridLines="None">
                           <columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                       <asp:CheckBox ID="chkAll" onclick="javascript:SelectAllCheckboxesSpecific(this);" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate >
                                        <asp:CheckBox ID="chkSeleccion" runat="server" />
                                        <asp:Label ID="lblClave" runat="server" Text='<%# eval("idSalonVirtual") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="20px" />
                                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                                </asp:TemplateField>
                           
                               <asp:boundfield DataField="FechaInicio" HeaderText="Fecha Inicio" HtmlEncode="False" SortExpression="FechaInicio"  DataFormatString="{0:dd/MMM/yyyy}"></asp:boundfield>
                                <asp:boundfield DataField="Nombre" HeaderText="Nombre" HtmlEncode="False" SortExpression="Nombre"></asp:boundfield>
                                 <asp:boundfield DataField="claveAux1" HeaderText="Clave" HtmlEncode="False" SortExpression="claveAux1"></asp:boundfield>
          
                           </columns>
                           <headerstyle font-bold="True" forecolor="Black" HorizontalAlign="Left" />
                           <AlternatingRowStyle BackColor="#F4F4F4" />
                       </asp:GridView>
             
             
             </td>
            <td style=" width:50px; text-align:center">
                <asp:Button ID="Button1" runat="server" Text=">>>" /><br />
                <asp:Button ID="Button2" runat="server" Text="<<<" />
            </td>
            <td style="vertical-align:top; width:350px">
                   <asp:GridView ID="gvCompartidos" runat="server" AllowSorting="True" 
                       DataKeyNames="idSalonVirtual" AutoGenerateColumns="False" Width="350px" 
                       GridLines="None">
                           <columns>
                           
                                   <asp:TemplateField>
                                    <HeaderTemplate>
                                       <asp:CheckBox ID="chkAll" onclick="javascript:SelectAllCheckboxesSpecific2(this);" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate >
                                        <asp:CheckBox ID="chkSeleccion" runat="server" />
                                        <asp:Label ID="lblClave" runat="server" Text='<%# eval("idSalonVirtualCompartido") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="20px" />
                                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                                </asp:TemplateField>
                           
                               <asp:boundfield DataField="FechaInicio" HeaderText="Fecha Inicio" HtmlEncode="False" SortExpression="FechaInicio"  DataFormatString="{0:dd/MMM/yyyy}"></asp:boundfield>
                                <asp:boundfield DataField="Nombre" HeaderText="Nombre" HtmlEncode="False" SortExpression="Nombre"></asp:boundfield>
                                 <asp:boundfield DataField="claveAux1" HeaderText="Clave" HtmlEncode="False" SortExpression="claveAux1"></asp:boundfield>
          
                           </columns>
                           <headerstyle font-bold="True" forecolor="Black" HorizontalAlign="Left" />
                           <AlternatingRowStyle BackColor="#F4F4F4" />
                       </asp:GridView>
                </td>
        </tr>
    </table>
    
    
    
    
<script language="javascript" type="text/javascript">

       function SelectAllCheckboxesSpecific(spanChk)
       {
           var IsChecked = spanChk.checked;
           var Chk = spanChk;

           Parent = document.getElementById('ctl00_ContentPanelCentral_gvDisponibles');      
              var items = Parent.getElementsByTagName('input');                          
            
              for(i=0;i<items.length;i++)

              {                
                  if(items[i].id != Chk && items[i].type=="checkbox")
                  {            
                      if(items[i].checked!= IsChecked)
                      {     
                          items[i].click();     
                      }
                  }
              }             
       }


       function SelectAllCheckboxesSpecific2(spanChk) {
           var IsChecked = spanChk.checked;
           var Chk = spanChk;

           Parent = document.getElementById('ctl00_ContentPanelCentral_gvCompartidos');
           var items = Parent.getElementsByTagName('input');

           for (i = 0; i < items.length; i++) {
               if (items[i].id != Chk && items[i].type == "checkbox") {
                   if (items[i].checked != IsChecked) {
                       items[i].click();
                   }
               }
           }
       }


 </script>

    
    
</asp:Content>

