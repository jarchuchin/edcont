<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="EnviarCorreo.aspx.vb" Inherits="Sec_SalonVirtual_EnviarCorreo" title="Redactar correo" ValidateRequest="false" %>

<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register src="Controles/displayApuntes.ascx" tagname="displayApuntes" tagprefix="uc2" %>

<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>



<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server"  Text="Redactar un correo" ></asp:Label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/default.aspx" ></asp:HyperLink></li>
           <li><asp:HyperLink ID="lnkCurso" runat="server"  Text="Curso nombre"  NavigateUrl="~/sec/Sa/default.aspx" ></asp:HyperLink></li>
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Redactar mensaje" ></asp:Label></li>
    </ol>


   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">
   
     <uc22:MenuGeneral ID="MenuGeneral1" runat="server" />

</asp:Content>

<asp:Content ID="contentCentral" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">


   <div class="row">

        <div class="col-xs-3">
             <uc1:MenuSalonVirtual ID="MenuSalonVirtual2" runat="server" />
        </div>
        <div class="col-xs-9">

                        
            <div class="panel">
                <div class="panel-heading">
                        <h3 class="panel-title"><asp:Label ID="Label6" runat="server" Text="Enviar correo"></asp:Label></h3>
                </div>
                <div class="panel-body">

 <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" 
                                               Text="No has configurado una cuenta de correo. Ingresa a tu perfil para configurarlo" 
                                               Visible="False"></asp:Label>
                            
                                         <table style="width: 100%; " cellspacing="3px" >
                                  
                                             <tr>
                                                 <td style="width: 130px">
                                                     <asp:Label ID="Label5" runat="server" Text="De" Font-Bold="True"></asp:Label>
                                                 </td>
                                                 <td style="padding:3px;">
                                                     &nbsp;&nbsp;
                                                     <asp:Label ID="txtmailfrom" runat="server"  Font-Bold="true"></asp:Label>
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td style="width: 130px">
                                                     <asp:Label ID="Label1" runat="server" Text="Para" Font-Bold="True"></asp:Label>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPara">*</asp:RequiredFieldValidator>
                                                 </td>
                                                 <td  style="padding:3px;">
                                                     <asp:TextBox ID="txtPara" runat="server" CssClass="form-control"  TextMode="MultiLine"  ></asp:TextBox>
                                                 </td>
                                             </tr>
                                   <tr>
                                       <td style="width: 130px">
                                           <asp:Label ID="Label2" runat="server" Text="CC" Visible="False" Font-Bold="True"></asp:Label>
                                       </td>
                                       <td  style="padding:3px;">
                                           <asp:TextBox ID="txtCC" Width="550px" CssClass="form-control" runat="server" 
                                               TextMode="MultiLine" Visible="False"></asp:TextBox></td>
                                   </tr>
                                   <tr>
                                       <td style="width: 130px">
                                           <asp:Label ID="Label3" runat="server" Text="Asunto" Font-Bold="True"></asp:Label>
                                       </td>
                                       <td  style="padding:3px;">
                                           <asp:TextBox ID="txtAsunto"  CssClass="form-control" runat="server"></asp:TextBox></td>
                                   </tr>
                               </table>
                            
                  
                    
      
         



       <div style=" height:30px; ">
        <asp:Label ID="Label4" runat="server" Text="Mensaje" Font-Bold="True"></asp:Label>
     
     </div>          
         
<div style="padding:3px;">

                    <asp:TextBox ID="txtmensaje" TextMode="MultiLine" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>


                      <script>
                         $(document).ready(function () {
                             $("#txtmensaje").cleditor({
                                 height: 300,
                                 controls: // controls to add to the toolbar
                             "bold italic underline strikethrough subscript superscript | font size " +
                             "style | color highlight removeformat | bullets numbering | outdent " +
                             "indent | alignleft center alignright justify | undo redo | " +
                             "rule image link unlink | cut copy paste pastetext | print source",
                                 fonts: // font names in the font popup
                            "Verdana, Arial,Arial Black,Comic Sans MS,Courier New,Narrow,Garamond," +
                            "Georgia,Impact,Sans Serif,Serif,Tahoma,Trebuchet MS",
                                 bodyStyle:
                                     "margin:4px; font:10pt Verdana,Arial; cursor:text"
                             });

                         });
                    </script>

</div>
                       <div style=" height:25px;"></div>

               
         



            <asp:Button ID="btnEnviarCorreoNuevo" runat="server" CssClass="btn btn-success" Text="Enviar correo" />
       
         




                    </div>
                </div>
            </div>


          

          </div>
    


</asp:Content>



