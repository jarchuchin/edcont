<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayExplorarContenido.ascx.vb" Inherits="Sec_SalonVirtual_Controles_DisplayExplorarContenido" %>


     
 <div style="padding-left:15px; padding-top:15px;">
                           
            <asp:TreeView ID="tvFolders" runat="server" ExpandDepth="1" ShowLines="True"  CssClass="treeView">
                    <NodeStyle HorizontalPadding="10px"  VerticalPadding="10px"  />
                    <LeafNodeStyle HorizontalPadding="10px"  VerticalPadding="3px"   />
            </asp:TreeView>
                         
</div>

<div style="height:30px;"></div>