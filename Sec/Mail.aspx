<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Mail.aspx.vb" Inherits="Sec_Mail" Theme="" StylesheetTheme="" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bandeja de entrada</title>
    
    <style type="text/css"> 

body
{
    background-color: #FFFFFF;
    text-align: center;
    font-family: Arial;
     font-size:11px;
     width:480px;    
    position:relative;
 top:-12px;
 left:-8px;

    
}





.TextoDescripcionSalon
{
	color: #333333;
	font-family: Trebuchet MS, Arial, Helvetica, sans-serif;
	font-size: 11px;
}

.TextoDescripcionNumero
{
	color: #008000;
	font-family: Trebuchet MS, Arial, Helvetica, sans-serif;
	font-size: 11px;
}



	
	.LigaGris
{
	color: #666666;
	font-family: Georgia;
	font-size: 11px;
	text-decoration: none;
}
.LigaGris:hover
{
	 text-decoration: underline;
	}
  
  
  
  .LigaVerde
{
	color: #008000;
	font-family: Georgia;
	font-size: 11px;
	text-decoration: none;
}
.LigaVerde:hover
{
	 text-decoration: underline;
	}
  
  
  

</style>
    
    
</head>
<body >
    <form id="form1" runat="server">
    
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    
       
    
   
    </form>
</body>
</html>
