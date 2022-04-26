<%@ Control Language="VB" AutoEventWireup="false" CodeFile="displayObjetivos.ascx.vb" Inherits="Sec_SalonVirtual_Controles_displayObjetivos" %>


 <div class="panel">

                <div class="panel-heading">
                   
                    <h3 class="panel-title"><asp:Label ID="Label5" runat="server" Text="Objetivos y competencias" ></asp:Label></h3>
                   
                </div>
              <div class="panel-body">
                  <asp:Repeater ID="rptObjetivos" runat="server">
      
         <ItemTemplate>
            <div runat="server" id="divConocimiento" visible='<%# esvisible(Eval("Objetivo")) %>'>
                <asp:Label ID="Label4" runat="server" Text="De conocimiento:" Font-Bold="true"  ></asp:Label>
                <asp:Label ID="lblObjetivo" runat="server" Text='<%# setcontenido(Eval("Objetivo")) %>'  ></asp:Label>
                <div style="height:10px;"></div>
            </div>
              <div runat="server" id="div1" visible='<%# esvisible(Eval("Habilidad")) %>'>
            <asp:Label ID="Label6" runat="server" Text="De habilidad:"  Font-Bold="true" ></asp:Label>
            <asp:Label ID="Label7" runat="server" Text='<%# setcontenido(Eval("Habilidad")) %>'  ></asp:Label>
            <div style="height:10px;"></div>
                </div>
              <div runat="server" id="div2" visible='<%# esvisible(Eval("aptitud")) %>'>
            <asp:Label ID="Label8" runat="server" Text="De actitud:"   Font-Bold="true"></asp:Label>
            <asp:Label ID="Label9" runat="server" Text='<%# setcontenido(Eval("aptitud")) %>'  ></asp:Label>
            <div style="height:10px;"></div>

       </div>
                 
         </ItemTemplate>
       
    </asp:Repeater>
              </div>
        </div>