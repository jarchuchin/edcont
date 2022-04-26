<%@ Page Title="Iniciar session Skolar" Language="VB" MasterPageFile="~/MPDiamante02.master" AutoEventWireup="false" CodeFile="test.aspx.vb" Inherits="test" %>

<%@ Register src="Controles/Login.ascx" tagname="Login" tagprefix="uc1" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPanelCentral">
    <%--  <div class="container">
         <div class="page-header">
            <h1>Sticky footer with fixed navbar</h1>
          </div>
    </div>--%>


<%--    <style>--%>

     <%--   /*.backgRegistro {
        
            background-image: url('images/diamantebaners/ban1.jpg');
            background-size: contain;
            background-repeat: no-repeat;
            width: 100%;
            height: 0;--
            padding-top: 100%;
       
        }*/ %>

 <%--       html { 
             top:0px;
             left:0px;
            background: url(images/diamantebaners/ban1.jpg) no-repeat center center fixed; 
            -webkit-background-size: cover;
            -moz-background-size: cover;
            -o-background-size: cover;
            background-size: cover;
       }
       

    </style>

  
  <uc1:Login ID="Login1" runat="server" />--%>




    <asp:Button ID="Button1" runat="server" Text="Button" />
    
</asp:Content>

