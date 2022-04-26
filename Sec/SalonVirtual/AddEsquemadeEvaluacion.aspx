<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="AddEsquemadeEvaluacion.aspx.vb" Inherits="Sec_SalonVirtual_AddEsquemadeEvaluacion" title="Esquema de evaluación" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>

<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server"  Text="Esquema de evaluación" ></asp:Label> </h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Cursos como maestro"  NavigateUrl="~/sec/defaultDocente.aspx" ></asp:HyperLink></li>
           <li><asp:HyperLink ID="lnkCurso" runat="server"  Text="Curso nombre"  NavigateUrl="~/sec/Sa/default.aspx" ></asp:HyperLink></li>
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Esquema de evaluación" ></asp:Label></li>
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
                       <div class="panel-control">
                            <div class="pull-right">
                              <asp:Button ID="btnNuevo" runat="server" Text="Nueva evaluación" CssClass="btn btn-primary btn-sm" />
                            </div>
                        </div>

                        <h3 class="panel-title"><asp:Label ID="Label6" runat="server" Text="Esquema de evaluación"></asp:Label></h3>
                </div>
                <div class="panel-body">
	
         

                <asp:repeater ID="Datalist1" runat="server" >
                    <HeaderTemplate>
                         <table id="Table10" class="table table-striped" width="100%">
                              <th align="left" width="40">
                                   
                                </th>
                                <th align="left">
                                    <asp:Label ID="lbltituloD" runat="server" Font-Bold="True">Título</asp:Label>
                                </th>
                                <th align="center" width="30">
                                    <asp:Label ID="lblTipoD" runat="server" Font-Bold="True">Tipo</asp:Label>
                                </th>
                                <th align="center" width="30">
                                    <asp:Label ID="lblPorcD" runat="server" Font-Bold="True">Valor</asp:Label>
                                </th>
                    </HeaderTemplate>
                    <ItemTemplate>
                       <tr>
							<td valign="top" width="40">
								<asp:HyperLink ID="HyperLink3" runat="server" ToolTip="Haz clic aquí para editar la evaluación"  CssClass="btn-link"
								NavigateUrl='<%# "AddItemEvaluacion.aspx?idSalonVirtual=" & eval("idSalonVirtual") & "&idItemEvaluacion=" & eval("idItemEvaluacion") %>' Text="Editar" >
								</asp:HyperLink>
                            </td>
							<td style="text-align:left ">
								<asp:HyperLink ID="Hyperlink1"  runat="server" NavigateUrl='<%# GetLigaAItems(DataBinder.Eval(Container.DataItem,"idSalonVirtual"), DataBinder.Eval(Container.DataItem,"idItemEvaluacion"), cint(DataBinder.Eval(Container.DataItem,"tipoitem")) )%>' ToolTip="Clic para agregar actividades a la evaluación">
									<%# DataBinder.Eval(Container.DataItem,"Titulo")%></asp:HyperLink>
                                <div style="height:10px;"></div>
								<asp:DataGrid ID="Datagrid1s" runat="server" AutoGenerateColumns="False" DataSource='<%# GetActivas(CInt(DataBinder.Eval(Container.DataItem, "idItemEvaluacion"))) %>' GridLines="None" CssClass="table table-hover" Width="100%" ShowHeader="false">
                                    <Columns>
										<asp:templatecolumn>
											<ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
												<asp:Image ID="Image4" runat="server" ImageUrl="~/Images/bull-arrow1.png">
                                                </asp:Image>
												<asp:Label ID="Label145" runat="server"><%# DataBinder.Eval(Container.DataItem,"Titulo") %></asp:Label>
											</ItemTemplate>
                                        </asp:templatecolumn>
                                        <asp:templatecolumn>
											<HeaderStyle Width="75px"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" Width="75px"></ItemStyle>
                                            <ItemTemplate>
												<asp:HyperLink ID="HyperLink2" runat="server"  CssClass="btn-link" NavigateUrl='<%# "RespuestaActividadesSalonVirtual.aspx?idSalonVirtual="  & DataBinder.Eval(Container.DataItem,"idSalonVirtual") & "&idActividadSalonVirtual=" & DataBinder.Eval(Container.DataItem,"idActividadSalonVirtual") %>'>Respuestas</asp:HyperLink>
											</ItemTemplate>
                                        </asp:templatecolumn>
										<asp:templatecolumn>
											<HeaderStyle Width="25px"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Right"  Width="25px"></ItemStyle>
                                            <ItemTemplate>
												<asp:Label ID="Label2" runat="server">
													<%# DataBinder.Eval(Container.DataItem,"Valor") %>%
												</asp:Label>
											</ItemTemplate>
                                        </asp:templatecolumn>
									</Columns>

                                    </asp:DataGrid>
								
                              
                                    
                                <div style="width:100%;">
                                     <div id="bloc3" class="form-inline text-right" style="width:50px;float:right"><asp:Label ID="Label7"  runat="server" Font-Bold="true"  ><%# GetTotalActividades(CInt(DataBinder.Eval(Container.DataItem, "idItemEvaluacion"))) %>%
											</asp:Label></div>


                                    <div id="bloc2" class="form-inline text-left" style="width:100px;float:right"><asp:Label ID="Label6" runat="server"   >Porcentaje relativo</asp:Label></div>  
                                   

 <div id="bloc1" class="form-inline text-left" style="width:180px;float:right;"><asp:HyperLink ID="Hyperlink4"  runat="server"  CssClass="btn btn-success btn-xs" NavigateUrl='<%# GetLigaAItems(DataBinder.Eval(Container.DataItem, "idSalonVirtual"), DataBinder.Eval(Container.DataItem, "idItemEvaluacion"), CInt(DataBinder.Eval(Container.DataItem, "tipoitem")))%>' Text="agregar actividades" >
									</asp:HyperLink></div> 

                                </div>
                                  

                                    

                                    
                                
								<div style="height:10px;"></div>
								</td>
							<td align="center" valign="top" width="30">
								<asp:Image ID="Image8" runat="server" ImageUrl='<%#"~/Images/Eval" & DataBinder.Eval(Container.DataItem,"tipoItem")  & ".gif"%>'>
								</asp:Image></td>
							<td align="right" valign="top" width="30"><%# DataBinder.Eval(Container.DataItem,"Valor")%>%</td>
						</tr>
														
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>

                </asp:repeater>
                <table id="Tadble3" style="width:100%">
                    <tr>
                        <td style="width:25px">
                        </td>
                        <td>
                            <asp:Label ID="lbltotalrelativo" runat="server" Visible="False">Porcentaje relativo</asp:Label>
                        </td>
                        <td  style="width:45px; text-align:center">
                            <asp:Label ID="lbltotald" runat="server" Font-Bold="True" >Total</asp:Label>
                        </td>
                        <td style="width:45px; text-align:center">
                            <asp:Label ID="lbltot" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>



                      </div>

             </div>
        </div>

    </div>




</asp:Content>

