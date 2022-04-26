<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="EditAgenda.aspx.vb" Inherits="Sec_SalonVirtual_EditAgenda" title="Calendario" ValidateRequest="false" %>

<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server"  Text="Agendar actividades" ></asp:Label> </h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/default.aspx" ></asp:HyperLink></li>
           <li><asp:HyperLink ID="lnkCurso" runat="server"  Text="Curso nombre"  NavigateUrl="~/sec/Sa/default.aspx" ></asp:HyperLink></li>
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Agendar actividad" ></asp:Label></li>
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
                        <h3 class="panel-title"><asp:Label ID="lblCalendario" runat="server" Text="Calendario"></asp:Label></h3>
                </div>
                <div class="panel-body">

                   
                  
                    <div class="row">
                        <div class="col-md-6">
                            <asp:Label ID="lblTitulo" runat="server" Text="Editar agenda" Font-Bold="true"></asp:Label>
                             <div style="height:10px;"></div>
                             <asp:DropDownList ID="drpSeleccion" runat="server"  AutoPostBack="True" CssClass="form-control" Height="30px">
                               <asp:ListItem>Actividades</asp:ListItem>
                               <asp:ListItem>Foros</asp:ListItem>
                               <asp:ListItem>Contenidos</asp:ListItem>
                               <asp:ListItem>Eventos</asp:ListItem>
                           </asp:DropDownList>
                           <asp:Label ID="lblMensajeActividades" runat="server" ForeColor="Red" 
                               Text="Lista de actividades incluidas en el esquema de evaluación" 
                               Visible="False"></asp:Label>

                           <asp:Label ID="lblMensajeUM" runat="server" ForeColor="Red" 
                               Text="Aunque se ha grabado bien la información en el Skolar No se han podido enviar la fecha al sistema académico. Intenta más tarde." 
                               Visible="False"></asp:Label>

                                        <div style="height:10px;"></div>

                              <asp:panel id="PanelAgenda" runat="server" Visible="False">
										<table id="Table8" cellspacing="1" cellpadding="1" border="0">
											<tr>
												<td>
													<asp:Label ID="lbltituloContenido" runat="server"  Font-Bold="true">Evento</asp:Label></td>
											</tr>
											<tr>
												<td>
													<asp:TextBox ID="txtTitulo" runat="server" Columns="30" MaxLength="150" CssClass="form-control"></asp:TextBox>
													<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                        ControlToValidate="txtTitulo" Display="Dynamic">*</asp:RequiredFieldValidator>
													<asp:TextBox ID="txtid" runat="server" Visible="False"></asp:TextBox>
											    </td>
											</tr>
											<tr>
												<td>
													<asp:Label ID="lblTextoCorto" runat="server" CssClass="Mediana">Descripción</asp:Label>
													<asp:RequiredFieldValidator ID="Requiredfieldvalidator3" 
                                            runat="server" ControlToValidate="txtTextoCorto" Display="Dynamic">*</asp:RequiredFieldValidator>
													<asp:CustomValidator ID="CustomValidator1" runat="server" 
                                            ControlToValidate="txtTextoCorto" Display="Dynamic">*</asp:CustomValidator>
                                                 </td>
											</tr>
											<tr>
												<td>
													<asp:TextBox ID="txtTextoCorto" runat="server" Columns="35" Height="104px"  CssClass="form-control"
                                                        Rows="7" TextMode="MultiLine" ></asp:TextBox>
                                                 </td>
											</tr>
										</table>
							    </asp:panel>
								
                                   <asp:ListBox ID="lstActividades" runat="server" Height="205px" 
                                       SelectionMode="Multiple"  CssClass="form-control"></asp:ListBox>
                                   <asp:ListBox ID="lstForos" runat="server" Height="205px" 
                                       SelectionMode="Multiple"  CssClass="form-control">
                                   </asp:ListBox>
                                   <asp:ListBox ID="lstContenidos" runat="server" Height="205px"
                                       SelectionMode="Multiple"  CssClass="form-control">
                                   </asp:ListBox>
                                     <div style="height:10px;"></div>
                                   
                                    <asp:Label ID="label1" runat="server"    Font-Bold="true" Text="A partir de esta fecha puede enviar:"></asp:Label>

                                   <table style="width:100%;" >
                                      <tr>
                                           <td>
                                                 <asp:DropDownList ID="drphora" runat="server" CssClass="form-control" Height="30px" Width="70px">
                                                   <asp:ListItem>01</asp:ListItem>
                                                   <asp:ListItem>02</asp:ListItem>
                                                   <asp:ListItem>03</asp:ListItem>
                                                   <asp:ListItem>04</asp:ListItem>
                                                   <asp:ListItem>05</asp:ListItem>
                                                   <asp:ListItem>06</asp:ListItem>
                                                   <asp:ListItem >07</asp:ListItem>
                                                   <asp:ListItem>08</asp:ListItem>
                                                   <asp:ListItem>09</asp:ListItem>
                                                   <asp:ListItem>10</asp:ListItem>
                                                   <asp:ListItem>11</asp:ListItem>
                                                   <asp:ListItem Selected="True">12</asp:ListItem>
                                               </asp:DropDownList>
                                           </td>
                                     
                                           <td>
                                                <asp:DropDownList ID="drpMinutos" runat="server" CssClass="form-control" Height="30px"  Width="70px">
                                                   <asp:ListItem>00</asp:ListItem>
                                                   <asp:ListItem>05</asp:ListItem>
                                                   <asp:ListItem>10</asp:ListItem>
                                                   <asp:ListItem>15</asp:ListItem>
                                                   <asp:ListItem>20</asp:ListItem>
                                                   <asp:ListItem>25</asp:ListItem>
                                                   <asp:ListItem>30</asp:ListItem>
                                                   <asp:ListItem>45</asp:ListItem>
                                                   </asp:DropDownList>
                                           </td>
                                        
                                           <td>
                                         
                                              
                                                <asp:DropDownList ID="drpAMPM" runat="server" CssClass="form-control" Height="30px" Width="70px">
                                                   <asp:ListItem>AM</asp:ListItem>
                                                   <asp:ListItem>PM</asp:ListItem>
                                               </asp:DropDownList>
                                            
                                           
                                             
                                           </td>
                                          <td>
  &nbsp;&nbsp;
                                      
                                            <asp:TextBox ID="txtFecha1" runat="server" Width="100px" CssClass="form-control"></asp:TextBox>
                                               <cc1:CalendarExtender ID="txtFecha1_CalendarExtender" runat="server" 
                                                   Enabled="True" TargetControlID="txtFecha1">
                                               </cc1:CalendarExtender>
                                          
                                               <asp:CustomValidator ID="CustomValidator3" runat="server" 
                                                   ControlToValidate="txtFecha1">*</asp:CustomValidator>
                                          </td>
                                       </tr>
                                      
                                      </table>

                              <asp:Label ID="label2" runat="server"   Font-Bold="true"  Text="Fecha límite para entregar:"></asp:Label>
                 
                            <table style="width:100%;" >
                                      <tr>
                                           <td>
                                               <asp:DropDownList ID="drphorafin" runat="server" CssClass="form-control" Height="30px" Width="70px">
                                                   <asp:ListItem>01</asp:ListItem>
                                                   <asp:ListItem>02</asp:ListItem>
                                                   <asp:ListItem>03</asp:ListItem>
                                                   <asp:ListItem>04</asp:ListItem>
                                                   <asp:ListItem>05</asp:ListItem>
                                                   <asp:ListItem>06</asp:ListItem>
                                                   <asp:ListItem >07</asp:ListItem>
                                                   <asp:ListItem>08</asp:ListItem>
                                                   <asp:ListItem>09</asp:ListItem>
                                                   <asp:ListItem>10</asp:ListItem>
                                                   <asp:ListItem Selected="true">11</asp:ListItem>
                                                   <asp:ListItem >12</asp:ListItem>
                                               </asp:DropDownList>
                                           </td>
                                    
                                           <td>
                                           
                                         
                                               <asp:DropDownList ID="drpminutosfin" runat="server" CssClass="form-control" Height="30px" Width="70px">
                                                   <asp:ListItem>00</asp:ListItem>
                                                   <asp:ListItem>05</asp:ListItem>
                                                   <asp:ListItem>10</asp:ListItem>
                                                   <asp:ListItem>15</asp:ListItem>
                                                   <asp:ListItem>20</asp:ListItem>
                                                   <asp:ListItem>25</asp:ListItem>
                                                   <asp:ListItem>30</asp:ListItem>
                                                   <asp:ListItem>45</asp:ListItem>
                                                   <asp:ListItem Selected="True">59</asp:ListItem>
                                               </asp:DropDownList>
                                             
                                           
                                              
                                           </td>
                                     
                                           <td>
                                               <asp:DropDownList ID="drpampmfin" runat="server" CssClass="form-control" Height="30px" Width="70px">
                                                   <asp:ListItem>AM</asp:ListItem>
                                                   <asp:ListItem Selected="True">PM</asp:ListItem>
                                               </asp:DropDownList>
                                           </td>
                                     
                                           <td>
                                              &nbsp;&nbsp;  <asp:TextBox ID="txtFecha2" runat="server" Width="100px" CssClass="form-control"></asp:TextBox>
                                               <cc1:CalendarExtender ID="txtFecha2_CalendarExtender" runat="server" 
                                                   Enabled="True" TargetControlID="txtFecha2">
                                               </cc1:CalendarExtender>
                                              
                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                   ControlToValidate="txtFecha2">*</asp:RequiredFieldValidator>
                                               <asp:CustomValidator ID="CustomValidator2" runat="server" 
                                                   ControlToValidate="txtFecha2">*</asp:CustomValidator>
                                               <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                                   ControlToCompare="txtFecha1" ControlToValidate="txtFecha2" 
                                                   Operator="GreaterThanEqual" Type="Date">*</asp:CompareValidator>
                                           </td>
                                       </tr>
                                        </table>
                                 
                                       <asp:Label ID="lblMensajeFechas" runat="server" ForeColor="Red" 
                                                   Text="Los periodos de inicio y límite no son correctos" Visible="False"></asp:Label>
                                 <asp:CheckBox ID="chkImpedir" runat="server"  
                                                   Text="Bloquear acceso despues de la fecha límite" />
                                 
                            
                            <div style="height:10px;"></div>
                           
                            <asp:Button ID="btnAgregar" runat="server" Text="Agendar"  CssClass="btn btn-primary" ToolTip="Agendar actividades seleccionadas" />
                            <asp:Button ID="btnRegresar" runat="server" Text="Regresar al calendario" CssClass="btn btn-default" />
                           
                        </div>
                        <div class="col-md-6">
<asp:Label ID="lblDiaactual" runat="server"  Font-Bold="True" 
                               Text="Activides agendadas"></asp:Label>
                               <div style="height:10px;"></div>
  <asp:DataGrid ID="dtgAgenda" runat="server" AllowSorting="True"  CssClass="table table-striped table-hover"
                               AutoGenerateColumns="False"  DataKeyField="idAgenda"  ShowHeader="false"
                               GridLines="None" Width="100%">
                             
                               <alternatingitemstyle verticalalign="Top" />
                               <itemstyle verticalalign="Top" />
                               <columns>
                                   <asp:templatecolumn>
                                       <headerstyle horizontalalign="Center" width="20px" />
                                       <itemstyle horizontalalign="Center" verticalalign="Top" />
                                       <itemtemplate>
                                           <asp:CheckBox ID="chkMarcar" runat="server" AutoPostBack="false" />
                                           <asp:Label ID="lblID" runat="server" 
                                               Text='<%# DataBinder.Eval(Container.DataItem, "idAgenda") %>' Visible="False">
                                           </asp:Label>
                                       </itemtemplate>
                                   </asp:templatecolumn>
                                   <asp:templatecolumn>
                                       <headerstyle width="45px" />
                                       <itemstyle horizontalalign="Left" />
                                       <headertemplate>
                                           <asp:Image ID="Image2" runat="server" Height="1px" 
                                               ImageUrl="../../../Images/transp.gif" Width="45px" />
                                       </headertemplate>
                                       <itemtemplate>
                                          <asp:Label ID="Label6" runat="server"  ><%# DataBinder.Eval(Container.DataItem, "Titulo") %></asp:Label>
                                           <div style="height:2px;"></div>
                                           <asp:Label ID="Label4" runat="server"  Font-Size="10px" Font-Bold="True"> Abierta desde: </asp:Label>&nbsp;
                                         <asp:Label ID="Label7" runat="server" Font-Size="10px"> <%# DataBinder.Eval(Container.DataItem, "FechaInicio", "{0:D}") & "-" & DataBinder.Eval(Container.DataItem, "FechaInicio", "{0:HH:mm:ss}")%></asp:Label>
                                            <div style="height:2px;"></div>
                                            <asp:Label ID="Label5" runat="server" Font-Size="10px"  Font-Bold="True"> Fecha límite:</asp:Label>&nbsp;
                                                       <asp:Label ID="Label8" runat="server" Font-Size="10px"> <%# DataBinder.Eval(Container.DataItem, "Fecha", "{0:D}") & "-" & DataBinder.Eval(Container.DataItem, "Fecha", "{0:HH:mm:ss}")%></asp:Label>
                                           <div style="height:2px;"></div>
                                            <asp:CheckBox ID="chkactivarcito" runat="server" 
                                                           Checked='<%# DataBinder.Eval(Container.DataItem, "ActivarLimite") %>' 
                                                           CssClass="Chica" Enabled="False" Text="La actividad no puede enviarse despues de la fecha limite" />
                                             
                                       </itemtemplate>
                                   </asp:templatecolumn>
                               </columns>
                           </asp:DataGrid>
                 
                           <div style="text-align:left">
                           <asp:Button ID="btnBorrar" runat="server" CausesValidation="False" 
                               CssClass="btn btn-danger" Text="Borrar" ToolTip="Borrar registros seleccionados" Visible="false" /></div>

                        </div>
                    </div>
               
           
                   
                   
                   
             </div>

            </div>

        </div>
</div>



          <asp:Label ID="labelCursosComoDocente" runat="server" Text="Cursos como docente" Visible="false"></asp:Label>
    <asp:Label ID="labelCursosComoAlumno" runat="server" Text="Label"  Visible="false"></asp:Label>


  



</asp:Content>

