<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="ConfiguracionGeneral.aspx.vb" Inherits="Sec_Administracion_ConfiguracionGeneral" title="Configuración general" ValidateRequest="false" %>

<%@ Register src="Controles/MenuAdministracion.ascx" tagname="MenuAdministracion" tagprefix="uc1" %>




<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>



<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>





<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server" Text="Configuración general"  ></asp:Label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
   
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>

    
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Administración"  NavigateUrl="~/sec/Administracion/default.aspx" ></asp:HyperLink></li>
       
       
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Configuración" ></asp:Label></li>
    </ol>


   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">
   
     <uc22:MenuGeneral ID="MenuGeneral1" runat="server" />

</asp:Content>






<asp:Content ID="contentCentral" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

	  <div class="row">

 
        <div class="col-xs-12">


              
                       <div class="panel">
                            <div class="panel-heading">

                                


                                    <h3 class="panel-title">
                                        <asp:Label ID="lblTitulo" runat="server" Text="Mensaje general"></asp:Label>
                                    </h3>
                            </div>
                            <div class="panel-body">

                                
                                <asp:textbox ID="txtmensaje" runat="server" Width="642px" Height="250px" TextMode="MultiLine"></asp:textbox>

                              


       
                            </div>

                     </div>

                       <div class="panel">
                            <div class="panel-heading">

                                


                                    <h3 class="panel-title">
                                        <asp:Label ID="Label1" runat="server" Text="Bibliotecas digitales"></asp:Label>
                                    </h3>
                            </div>
                            <div class="panel-body">

                                
                                <asp:textbox ID="txtBibiotecas" runat="server" Width="642px" Height="250px" TextMode="MultiLine"></asp:textbox>

                                


       
                            </div>

                     </div>


             <div class="panel">
                            <div class="panel-heading">

                                


                                    <h3 class="panel-title">
                                        <asp:Label ID="Label2" runat="server" Text="Logo e imagen inicial"></asp:Label>
                                    </h3>
                            </div>
                            <div class="panel-body">

                                
                               <b>Logo de la institución</b>
                                <div style="height:5px"></div>
                                <asp:FileUpload ID="fuLogo" runat="server" Height="35px" Width="250px" />
                                <div style="height:5px"></div>
                                <asp:image ID="imgLogo" runat="server" Height="120px" Visible="false" />

                                <div style="height:20px"></div>
                                 <b>Imagen inicial</b>
                                <div style="height:5px"></div>
                                <asp:FileUpload ID="fuInicial" runat="server" Height="35px" Width="250px" />
                                 <div style="height:5px"></div>
                                 <asp:image ID="imgInicial" runat="server" Height="120px" Visible="false" />



                                  <div style="height:20px"></div>
                                 <b>Video inicial</b>
                                <div style="height:5px"></div>
                                <asp:FileUpload ID="fuVideo" runat="server" Height="35px" Width="250px" />
                                 <div style="height:5px"></div>
                                 <asp:literal ID="litVideo" runat="server" Visible="false" />
                                <div style="height:5px"></div>
                                <asp:LinkButton ID="lnkBorrarVideo" runat="server" Text="Eliminar video" ForeColor="Red"></asp:LinkButton>
                            </div>

                     </div>


                 <div class="panel">
                            <div class="panel-heading">

                                


                                    <h3 class="panel-title">
                                        <asp:Label ID="Label3" runat="server" Text="Empotrar video para portada"></asp:Label>
                                    </h3>
                            </div>
                            <div class="panel-body">

                                
                                <asp:textbox ID="txtEmpotrado" runat="server" Width="342px" Height="250px" TextMode="MultiLine"></asp:textbox>

                                


       
                            </div>

                     </div>


              <div style="height:10px"></div>

                                <asp:button ID="btnGrabar" runat="server" Text="Grabar" CssClass="btn btn-success"></asp:button>





          </div>

 </div>




</asp:Content>

