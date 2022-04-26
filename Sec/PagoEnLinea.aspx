<%@ Page Title="" Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="PagoEnLinea.aspx.vb" Inherits="Sec_PagoEnLinea" %>
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
                <h3 class="panel-title"> <asp:Label ID="Label1" runat="server" Text="Captura los datos para enviar tu pago" ForeColor="Red"></asp:Label></h3>

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



        <div id="panelTarjetaNopagado" runat="server" Visible="false" class="box1">
		No se concluyó la inscripción al curso debido a <asp:Label ID="lblCausaRechazo" runat="server" Font-Bold="true"></asp:Label>.
		Elige a continuación alguna opción para reintentar el pago.
	</div>

	<asp:Panel ID="panelPago" runat="server">
		<asp:UpdatePanel ID="UpdatePanel2" runat="server">
			<ContentTemplate>
			

                
				

									<asp:Panel ID="panelPagoPrevio" runat="server" Visible="false">
										<div style="margin-bottom:10px; padding:5px; background-color:#eee;">
											<asp:Label ID="lblPagoPrevio" runat="server" Text="Pago previo con la tarjeta "></asp:Label>
											<asp:Label ID="lblTerminacionTarjeta" runat="server" Font-Bold="true"></asp:Label>,
											el <asp:Label ID="lblFechaPagoPrevio" runat="server" Font-Bold="true"></asp:Label>.
											No se concluyó el pago por: <asp:Label ID="lblRazonRechazo" runat="server" Font-Bold="true"></asp:Label>
										</div>
									</asp:Panel>

									<asp:Label ID="lblErrorTarjeta" runat="server" Text="Los datos de la tarjeta de crédito son incorrectos" ForeColor="red" Font-Bold="true" Visible="false"></asp:Label>

									<asp:ValidationSummary ID="ValidationSummary2" runat="server" CssClass="alart alert-danger" />

									<table style="width:100%" class="table">
									<tr>
										<td colspan="2">
											<strong>Alumno:</strong><br />
                                            <asp:Label ID="lblAlumno" runat="server" Text=""></asp:Label>
										</td>
									</tr>
									    <tr>
                                            <td style="width:320px; vertical-align:top;"><strong>Cantidad a pagar:<asp:RequiredFieldValidator ID="reqNumeroCuenta0" runat="server" ControlToValidate="txtpago" ErrorMessage="Debes colocar la cantidad a pagar" ForeColor="Red">*</asp:RequiredFieldValidator>
                                               
                                                </strong>
                                                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtpago" ErrorMessage="La cantidad debe ser mayor a 50(cincuenta pesos mx) y menor a 100000(cien mil pesos mx)" ForeColor="Red" MaximumValue="100000" MinimumValue="50" Type="Double">*</asp:RangeValidator>
                                               
                                                <br />
                                                <asp:TextBox ID="txtpago" runat="server" CssClass="form-control text-right" Font-Bold="true" Font-Size="15px" ForeColor="Black" Height="35px" Width="100px"></asp:TextBox>
                                                &nbsp;<em>ejemplo: 13560.58</em></td>
                                            <td style="vertical-align:top;"><em>Colocar el número sin comas ni espacios, luego el punto decimal y finalmente los dos decimales</em></td>
                                        </tr>
									    <tr>
                                            <td style="width:320px; vertical-align:top;">
                                                <asp:Label ID="lblTagNumeroTarjeta" runat="server" Font-Bold="True" Text="Número de la tarjeta"></asp:Label>
                                                <asp:RequiredFieldValidator ID="reqNumeroCuenta" runat="server" ControlToValidate="txtNumeroCuenta" ErrorMessage="Escribe el número de la tarjeta" ForeColor="Red">*</asp:RequiredFieldValidator>
                                             
                                                <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtNumeroCuenta" ErrorMessage="El número de tarjeta no esta en el formato  apropiado" ForeColor="Red">*</asp:CustomValidator>
                                             
                                                <br />
                                                <asp:TextBox ID="txtNumeroCuenta" runat="server" CssClass="form-control" MaxLength="16"></asp:TextBox>
                                            </td>
                                            <td style="vertical-align:top;">
                                                <asp:Label ID="lblTagNombreTarjeta" runat="server" Font-Bold="True" Text="Nombre como aparece en la tarjeta"></asp:Label>
                                                <asp:RequiredFieldValidator ID="reqNombreTarjeta" runat="server" ControlToValidate="txtNombre" ErrorMessage="Escribe el nombre que tiene la tarjeta" ForeColor="Red">*</asp:RequiredFieldValidator>
                                              
                                                <br />
                                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="35"></asp:TextBox>
                                            </td>
                                        </tr>
									<tr>
										<td colspan="2" class="form-inline">
													<asp:Label ID="lblTagTipoTarjeta" runat="server" Text="Tipo:" Font-Bold="True"></asp:Label> 
													<asp:DropDownList ID="drpTipoTarjeta" runat="server" CssClass="form-control">
														<asp:ListItem Value="3">Visa</asp:ListItem>
														<asp:ListItem Value="2">MasterCard</asp:ListItem>
													</asp:DropDownList> &nbsp;&nbsp;

													<asp:Label ID="lblTagVencimiento" runat="server" Text="Vencimiento:" Font-Bold="True"></asp:Label>
													<asp:DropDownList ID="drpMes" runat="server" CssClass="form-control">
														<asp:ListItem Value="1">Ene</asp:ListItem>
														<asp:ListItem Value="2">Feb</asp:ListItem>
														<asp:ListItem Value="3">Mar</asp:ListItem>
														<asp:ListItem Value="4">Abr</asp:ListItem>
														<asp:ListItem Value="5">May</asp:ListItem>
														<asp:ListItem Value="6">Jun</asp:ListItem>
														<asp:ListItem Value="7">Jul</asp:ListItem>
														<asp:ListItem Value="8">Ago</asp:ListItem>
														<asp:ListItem Value="9">Sep</asp:ListItem>
														<asp:ListItem Value="10">Oct</asp:ListItem>
														<asp:ListItem Value="11">Nov</asp:ListItem>
														<asp:ListItem Value="12">Dic</asp:ListItem>
													</asp:DropDownList>&nbsp;
													<asp:DropDownList ID="drpAno" runat="server" CssClass="form-control">
													</asp:DropDownList> &nbsp;&nbsp;

													<asp:Label ID="lblTagCodigo" runat="server" Text="Código:" Font-Bold="True"></asp:Label>
													<asp:TextBox ID="txtNumeroExtra" runat="server" Columns="6" MaxLength="10" CssClass="form-control"></asp:TextBox>
													<asp:RequiredFieldValidator ID="reqNumeroExtra" runat="server" ControlToValidate="txtNumeroExtra" ErrorMessage="Escribe el código de seguridad al reverso de tu tarjeta (CVV)" ForeColor="Red">*</asp:RequiredFieldValidator>
												

										</td>
									</tr>
									<tr>
										<td colspan="2">&nbsp;</td>
									</tr>
									<tr>
										<td colspan="2"><h5>&nbsp;</h5></td>
									</tr>
									<tr>
										<td colspan="2">
											<asp:Button ID="btnPagar" runat="server" Text="Confirmar datos" CssClass="btn btn-primary" />
										</td>
									</tr>
									</table>
								</div>
						       </Content>
					
			
				
			</ContentTemplate>
		</asp:UpdatePanel>
	</asp:Panel>

	<asp:Panel ID="panelNoPago" runat="server" Visible="false">
		<asp:Button ID="btnIncripcion" runat="server" Text="Inscribirme" SkinID="btnLevel1" />
	</asp:Panel>

	<asp:HiddenField ID="hiddenIdCurso" runat="server" Value="0" />
	<asp:HiddenField ID="hiddenIdCostoCurso" runat="server" Value="0" />
	<asp:HiddenField ID="hiddenCosto" runat="server" Value="0" />
	<asp:HiddenField ID="hiddenCostoContable" runat="server" Value="0" />
	<asp:HiddenField ID="hiddenIdConvenio" runat="server" Value="0" />

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

