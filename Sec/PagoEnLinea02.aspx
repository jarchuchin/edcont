<%@ Page Title="" Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="PagoEnLinea02.aspx.vb" Inherits="Sec_PagoEnLinea02" %>
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
                <h3 class="panel-title"> <asp:Label ID="Label1" runat="server" Text="Confirma los datos de tu tarjeta de crédito" ForeColor="Red"></asp:Label></h3>

            </div>
             <div class="panel-body">




                 <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" />

        	<asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0">
		<progresstemplate>
			<div class="progressBackgroundFilter"></div>
			<div class="processMessage">
				<asp:Image runat="server" ID="imgProgress" ImageUrl="~/Images/indicator.gif"></asp:Image>
				<asp:Label runat="server" ID="lblVerificando" Text="Procesando datos..."></asp:Label>
			</div>
		</progresstemplate>
	</asp:UpdateProgress>



	<asp:Panel ID="panelPago" runat="server">
		<asp:UpdatePanel ID="UpdatePanel2" runat="server">
			<ContentTemplate>
			

                
				

									<asp:Panel ID="panelPagoPrevio" runat="server" Visible="false">
										<div style="margin-bottom:10px; padding:5px; background-color:#eee;">
											<asp:Label ID="lblPagoPrevio" runat="server" Text="El pago con la tarjeta "></asp:Label>
											<asp:Label ID="lblTerminacionTarjeta" runat="server" Font-Bold="true"></asp:Label>,
											el <asp:Label ID="lblFechaPagoPrevio" runat="server" Font-Bold="true"></asp:Label>.
											No se concluyó el pago por código de respuesta: <asp:Label ID="lblRazonRechazo" runat="server" Font-Bold="true"></asp:Label>
										</div>
									</asp:Panel>
                                    
                <div class="alert alert-danger" id="lblErrorTarjeta" runat="server" Visible="False">
									<asp:Label ID="asdf" runat="server" Text="Sucedió un error el procesar el pago"  Font-Bold="True" ></asp:Label>
                    </div>

									<table style="width:100%" class="table">
									<tr>
										<td colspan="2">
											<strong>Alumno:</strong><br />
                                            <asp:Label ID="lblAlumno" runat="server" Bold="true" Font-Size="15px" ForeColor="Black" Text=""></asp:Label>
										</td>
									</tr>
									    <tr>
                                            <td style="width:320px; vertical-align:top;"><strong>Cantidad a pagar:</strong><br />
                                                <asp:label ID="txtpago" runat="server"  Font-Bold="true" Font-Size="15px" ForeColor="Black"></asp:label>
                                            </td>
                                            <td style="vertical-align:top;">&nbsp;</td>
                                        </tr>
									    <tr>
                                            <td style="width:320px; vertical-align:top;">
                                                <asp:Label ID="lblTagNumeroTarjeta" runat="server" Font-Bold="True" Text="Número de la tarjeta"></asp:Label>
                                               
                                                <br />
                                                <asp:label ID="txtNumeroCuenta" Bold="true" Font-Size="15px" ForeColor="Black"  runat="server" ></asp:label>
                                            </td>
                                            <td style="vertical-align:top;">
                                                <asp:Label ID="lblTagNombreTarjeta" runat="server" Font-Bold="True" Text="Nombre como aparece en la tarjeta"></asp:Label>
                                               
                                                <br />
                                                <asp:label ID="txtNombre" Bold="true" Font-Size="15px" ForeColor="Black" runat="server" ></asp:label>
                                            </td>
                                        </tr>
									<tr>
										<td colspan="2" class="form-inline">
													&nbsp;<br />

													<asp:Label ID="lblTagTipoTarjeta" runat="server" Text="Tipo:" Font-Bold="True"></asp:Label>
													<asp:Label ID="drpTipoTarjeta" Bold="true" Font-Size="15px" ForeColor="Black" runat="server">
														
													</asp:Label>
                                                    &nbsp;&nbsp;
                                                    <asp:Label ID="lblTagVencimiento" runat="server" Font-Bold="True" Text="Vencimiento:"></asp:Label>
													<asp:label ID="drpMes" Bold="true" Font-Size="15px" ForeColor="Black" runat="server">
														
													</asp:label>&nbsp;
													<asp:label ID="drpAno" runat="server" Bold="true" Font-Size="15px" ForeColor="Black" >
													</asp:label> &nbsp;&nbsp;

													<asp:Label ID="lblTagCodigo" runat="server" Text="Código:" Font-Bold="True"></asp:Label>
													<asp:label ID="txtNumeroExtra" Bold="true" Font-Size="15px" ForeColor="Black" runat="server" ></asp:label>
												

										</td>
									</tr>
									
									<tr>
										<td colspan="2">
											<br />
											<asp:Button ID="btnPagar" runat="server" Text="Pagar ahora" CssClass="btn btn-success" />
										</td>
									</tr>
									</table>
								</div>
						       </Content>
					
			
				
			</ContentTemplate>
		</asp:UpdatePanel>
	</asp:Panel>

	<asp:Panel ID="panelNoPago" runat="server" Visible="false">
	</asp:Panel>

	<script type="text/javascript">
		Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(startRequest);
		Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequest);

		function startRequest(sender, e) {
			//disable button during the AJAX call
			document.getElementById('<%=btnPagar.ClientID%>').disabled = true;
			document.getElementById('<%=btnPagar.ClientID%>').value = 'Procesando...';
		
		}
		function endRequest(sender, e) {
			//re-enable button once the AJAX call has completed
			document.getElementById('<%=btnPagar.ClientID%>').disabled = false;
			document.getElementById('<%=btnPagar.ClientID%>').value = 'Enviando información al banco';
			
		}

		var instance = Sys.WebForms.PageRequestManager.getInstance();
		instance.add_initializeRequest(instance_initializeRequest);

		function instance_initializeRequest(sender, args) {
			if (instance.get_isInAsyncPostBack()) {
				alert('Aún en proceso, por favor espera.');
				args.set_cancel(true);
			}
		}

 </script>

	<asp:Literal ID="lit" runat="server"></asp:Literal>


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

