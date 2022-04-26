<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="SolicitarIngreso.aspx.vb" Inherits="Sec_SolicitarIngreso" title="Untitled Page" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc2" %>









<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreSalon" runat="server"></asp:Label></h1>

       
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelBreadcrumb" Runat="Server">
 
<ol class="breadcrumb"  >
  <li >
      <asp:Label ID="Label6" runat="server" Text="Incripción al curso"></asp:Label></li>
</ol>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

    
<div class="row">
	<div class="col-sm-12 ">
		<div class="panel">
			<div class="panel-heading">
                <h3 class="panel-title"> <asp:Label ID="Label7" runat="server" Text="Buscar curso" ></asp:Label></h3>

            </div>
             <div class="panel-body">
  
  <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <div align="left" > <asp:Image ID="Image1" runat="server"  ImageUrl ="~/Images/indicator.gif" /><asp:Label ID="lbltexto" runat="server"   Text="Obteniendo información..." ></asp:Label></div>
                    </ProgressTemplate>
       </asp:UpdateProgress>
       <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional" >
               <ContentTemplate>
    <table id="Table3" border="0" cellpadding="0" cellspacing="0"  width="100%">
        <tr>
            <td>
         
                <asp:Panel ID="Panel2" runat="server" Visible="False">
                    <table id="Table5" border="0" cellpadding="1" cellspacing="1" width="100%"><tbody><tr><td 
                        align="center" colspan="2"><asp:Label ID="lblEmpresa" runat="server" 
                        Font-Italic="True"></asp:Label></td></tr><tr><td width="150"><asp:Label 
                        ID="lblStatus" runat="server" Font-Bold="True">Status del curso</asp:Label></td><td><asp:Label 
                        ID="txtStatus" runat="server"></asp:Label> <asp:TextBox ID="txtid" 
                        runat="server"></asp:TextBox>
                                <br />
                                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Estás inscrito a este curso" Visible="False"></asp:Label>
                                <asp:Label ID="Label3" runat="server" Font-Bold="true" Text="Solicitando ingreso"  Visible="False"></asp:Label>
                                <asp:Label ID="Label4" runat="server" Font-Bold="true" Text="No autorizado"  Visible="False"></asp:Label>
                                <asp:Label ID="Label5" runat="server" Font-Bold="true" Text="Calificación asignada"  Visible="False"></asp:Label>
                            </td></tr><tr><td width="150"><asp:Label 
                        ID="lblFechaInicio" runat="server" Font-Bold="True">Fecha de finalizacion</asp:Label></td><td><asp:Label 
                        ID="txtFechaInicio" runat="server"></asp:Label></td></tr><tr><td 
                        width="150"><asp:Label ID="lblFechafin" runat="server" Font-Bold="True">Fecha de 
                            finalización</asp:Label></td><td><asp:Label 
                        ID="txtfechaFin" runat="server"></asp:Label></td></tr><tr><td width="150"><asp:Label 
                        ID="lblhorarioAtencion" runat="server" Font-Bold="True">Horario de 
                            atención</asp:Label></td><td><asp:Label 
                        ID="txthorarioAtencion" runat="server"></asp:Label></td></tr><tr><td 
                        width="150"><asp:Label ID="lblCalificacionMaxima" runat="server" 
                        Font-Bold="True">Calificación máxima</asp:Label></td><td><asp:Label 
                        ID="txtCalificacionMaxima" runat="server"></asp:Label></td></tr><tr><td 
                        width="150"><asp:Label ID="lblClaves" runat="server" Font-Bold="True">Código de 
                            curso</asp:Label></td><td><asp:Label 
                        ID="txtClaveID1" runat="server"></asp:Label>&#160; <asp:Label ID="txtClaveID2" 
                        runat="server"></asp:Label></td></tr><tr><td width="150"><asp:Label 
                        ID="lblLibro" runat="server" Font-Bold="True">Contenidos asignados</asp:Label></td><td><asp:Label 
                        ID="txtLibro" runat="server"></asp:Label></td></tr><tr><td width="150"><asp:Label 
                        ID="lblDetallesLibro" runat="server" Font-Bold="True">Descripción de contenidos</asp:Label></td><td><asp:Label 
                        ID="txtDetallesLibro" runat="server" Font-Italic="True"></asp:Label></td></tr><tr><td 
                        align="center" colspan="2"><asp:Label ID="lblInstructores" runat="server" 
                                Font-Bold="True">Instructores 
                            para este curso</asp:Label></td></tr><tr><td 
                        align="center" colspan="2"><asp:DataGrid ID="dtgInstructores" 
                        runat="server" AutoGenerateColumns="False" BackColor="White" 
                        BorderColor="#C1CDD8" GridLines="Horizontal" Visible="False" Width="100%">
														<SelectedItemStyle BackColor="#C1CDD8">
                        </SelectedItemStyle>
                        
														<HeaderStyle BackColor="#DBEAF5" 
                            Font-Bold="True"></HeaderStyle>
                        
														<itemstyle horizontalalign="Left" />
                        
														<Columns>
															<asp:templatecolumn>
																<HeaderStyle HorizontalAlign="Center" Width="25px"></HeaderStyle>
                                                            
																<ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                            
																<ItemTemplate>
																	<asp:Image ID="Image4" runat="server" ImageUrl="../Images/user.gif">
                                                                    </asp:Image>
																</ItemTemplate>
                                                            
															</asp:templatecolumn>
															<asp:templatecolumn HeaderText="Nombre de instructor">
																<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                            
																<ItemTemplate >
																	<asp:Label ID="lblinstructoreslista" runat="server">
																		<%# DataBinder.Eval(Container, "DataItem.nombre") %></asp:Label>
																</ItemTemplate>
                                                            
															</asp:templatecolumn>
														</Columns>
                        
													</asp:DataGrid></td></tr><tr><td align="center" 
                        colspan="2"><br /><br />
                            <asp:Button 
                        ID="btnEnviar" runat="server" CssClass="BotonSubmit" Text="Solicitar inscripción"></asp:Button>
                            <cc1:ConfirmButtonExtender ID="btnEnviar_ConfirmButtonExtender" 
                                runat="server" 
                                ConfirmText="Se enviará tu petición al maestro para admitirte. ¿Deseas continuar?" 
                                Enabled="True" TargetControlID="btnEnviar">
                            </cc1:ConfirmButtonExtender>
                            <br /><asp:Label 
                        ID="lblMensaje" runat="server" Font-Bold="True" Font-Italic="True">Tú eres uno de los instructores para este curso</asp:Label></td></tr></tbody></table>
                </asp:Panel>
            </td>
        </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>

        </div>
    
    </div>

        </div>

    </div>
    
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">



     <uc2:MenuGeneral ID="MenuGeneral1" runat="server" />



</asp:Content>

