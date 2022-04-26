<%@ Page Language="VB" MasterPageFile="~/MPDiamante02.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" title="SKOLAR Education Solution" Culture="auto"  UICulture="auto" %>

<%@ Register Src="Controles/Login.ascx" TagName="Login" TagPrefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

    
    <!-- Create your own class to load custum image [ SAMPLE ]-->
   

    <asp:Literal ID="litnum" runat="server" Visible="false" ></asp:Literal>
    <asp:Literal ID="litscript" runat="server" ></asp:Literal>
  
     <style>


   .footer { 
           position: absolute;
       }
         .video {

             min-width: 100%;
             min-height: 100%;
         }
         .wrapper {

             position:fixed;
             top:0;
             left:0;
             width:100%;
             height:100%;

         }

    </style>

    <div class="wrapper">
        <div class="row">
              <div class="col-sm-1"></div>
              <div class="col-sm-2 col-md-2">

                  <uc1:Login ID="Login1" runat="server" />
            </div>
            <div class="col-sm-6"></div>
      
      
        <div class="col-sm-2 col-md-1"></div>


       </div>

   </div>
</asp:Content>