<%@ Page Title="" Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="PagoEnLineaConfirmacion.aspx.vb" Inherits="Sec_PagoEnLineaConfirmacion" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHead" Runat="Server">
</asp:Content>





<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lbltitulo" runat="server" Text="Pago en línea"></asp:Label></h1>

       
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPanelBreadcrumb" Runat="Server">
 
<ol class="breadcrumb"  >
   <li><asp:HyperLink ID="HyperLink2" runat="server"  Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
     <li >
      <asp:Label ID="Label2" runat="server" Text="Pago en linea"></asp:Label></li>
</ol>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">



  


    

<div class="row">
	<div class="col-sm-12 col-md-8 col-lg-8">

        <div class="panel">
			<div class="panel-heading">
                <h3 class="panel-title"> <asp:Label ID="Label1" runat="server" Text="Confirmación de pago en línea" ForeColor="Red"></asp:Label></h3>

            </div>
             <div class="panel-body">




           


	<asp:Panel ID="panelPago" runat="server">
		<asp:UpdatePanel ID="UpdatePanel2" runat="server">
			<ContentTemplate>
			

                
				


									<table style="width:100%" class="table">
									<tr>
										<td colspan="2">
											<strong>Alumno:</strong><br />
                                            <asp:Label ID="lblAlumno" runat="server" Text=""></asp:Label>
										</td>
									</tr>
									    <tr>
                                            <td style="width:320px; vertical-align:top;"><strong>Código de confirmación:</strong><br />
                                                <asp:label ID="txtpago" runat="server"  Font-Bold="true" Font-Size="20px" ForeColor="Black"></asp:label>
                                            </td>
                                            <td style="vertical-align:top;">&nbsp;</td>
                                        </tr>
									
									<tr>
										<td colspan="2">
											<strong>Cantidad:</strong><br />
										    <asp:Label ID="txtcantidad" runat="server" Font-Bold="true" Font-Size="20px" ForeColor="Black"></asp:Label>
                                            <br />
										</td>
									</tr>
                                        <tr>
										<td colspan="2">
											<strong>Fecha:</strong><br />
										    <asp:Label ID="txtFecha" runat="server" Font-Bold="true" Font-Size="20px" ForeColor="Black"></asp:Label>
                                            <br />
										</td>
									</tr>
									</table>
								</div>
						       </Content>
					
			
				
			</ContentTemplate>
		</asp:UpdatePanel>
	</asp:Panel>

                   <div style="height:200px;"></div>
	


        </div>
    </div>


    </div>

    </div>

   

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">

       <uc2:MenuGeneral ID="MenuGeneral1" runat="server" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceFooterScripts" Runat="Server">
</asp:Content>

