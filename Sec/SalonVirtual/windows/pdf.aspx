<%@ Page Title="" Language="VB" MasterPageFile="~/MPDiamante02.master" AutoEventWireup="false" CodeFile="pdf.aspx.vb" Inherits="Sec_SalonVirtual_windows_pdf" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

     
    <input id="iframe-options" type="hidden" iframe-width="85%"/>


   

        <div class="panel">
            <div class="panel-heading">
             
               <h5 >  <asp:Label ID="lblNombreArchivo" runat="server" ></asp:Label></h5>
            </div>
            <div class="panel-body text-left">
             
                <asp:Literal ID="litFile" runat="server"></asp:Literal>

             </div>
        </div>

  
</asp:Content>

