<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="AddActividadesAItemEvaluacion.aspx.vb" Inherits="Sec_SalonVirtual_AddActividadesAItemEvaluacion" title="Centro de actividades" %>

<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server"  Text="Agregar actividades" ></asp:Label> </h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/default.aspx" ></asp:HyperLink></li>
           <li><asp:HyperLink ID="lnkCurso" runat="server"  Text="Curso nombre"  NavigateUrl="~/sec/Sa/default.aspx" ></asp:HyperLink></li>
             <li><asp:HyperLink ID="lnkEsquemaEvaluacion" runat="server"  Text="Esquema de evaluación"  NavigateUrl="~/sec/Sa/default.aspx" ></asp:HyperLink></li>
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Agregar actividades" ></asp:Label></li>
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
                      

                        <h3 class="panel-title"><asp:Label ID="Label6" runat="server" Text="Agregar actividades a evaluación"></asp:Label></h3>
                </div>
                <div class="panel-body">
 
    
      
               


                <div class="row">

                    <div class="col-md-5">
                         <asp:Label ID="lblDisponibles" runat="server" Font-Bold="true">ACTIVIDADES DISPONIBLES</asp:Label>
                         
                        <div style="height:15px;"></div>

                         <asp:ListBox ID="lbxDisponibles" runat="server" Rows="20"  CssClass="form-control"    SelectionMode="Multiple" Width="100%" Height="200px"></asp:ListBox>
                          <div style="height:5px;"></div>
                            <asp:Label ID="lblInstruccion" runat="server" Text="Selecciona las actividades que deseas incluir en esta evaluación"  Font-Size="10px"></asp:Label>
                        <div style="height:15px;"></div>

                         <asp:hyperlink ID="ibActividad" runat="server"  Text="Nueva actividad" CssClass="btn btn-warning" />
                           <asp:hyperlink ID="ibExamen" runat="server"  Text="Nuevo examen" CssClass="btn btn-success"  />
                         <asp:Button ID="btnRegresar" runat="server" Text="Regresar"  CssClass="btn btn-default"/>
                    </div>
                    <div class="col-md-2 text-center">
                        <div style="height:25px;"></div>
                          <asp:Button ID="btnIncluir" ToolTip="Agregar actividades seleccionadas"  runat="server" CssClass="btn btn-primary" 
                                                           Text="Agregar &gt;&gt;&gt;" />
                        <div style="height:15px;"></div>
                    </div>
                    <div class="col-md-5">
                         <asp:Label ID="lblActivas" runat="server" font-bold="true">ACTIVIDADES PARA:</asp:Label>
                        &nbsp;
                        <asp:Label ID="lblItemEvaluacion" runat="server" Font-Italic="True" Font-Bold="true" CssClass="Mediana"></asp:Label>

                          <div style="height:15px;"></div>

                        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" 
                            Text="Existen respuestas asignadas a esta actividad y no puede ser excluida del esquema de evaluación." 
                            Visible="False"></asp:Label>
                        <asp:Label ID="lblMensajeSistema" runat="server" ForeColor="Red" text="Los datos alterados no podrán ser sinconizados con el 
                        sistema académico. El curso ya fué cerrado."
                            Visible="False"></asp:Label>


                         <asp:DataGrid ID="dtgActividades" runat="server"  CssClass="table table-striped table-hover" 
                                               AutoGenerateColumns="False"  HeaderStyle-Font-Bold="true"
                                               DataKeyField="idActividadSalonVirtual" GridLines="none" >

                                               <columns>
                                                   <asp:templatecolumn>
                                                       <headerstyle width="20px" />
                                                       <itemtemplate>
                                                           <asp:ImageButton ID="Imagebutton2" runat="server" CausesValidation="False" 
                                                               CommandName="Borrar" ImageUrl="../../Images/del.gif" />
                                                           
                                                           <cc1:ConfirmButtonExtender ID="Imagebutton2_ConfirmButtonExtender" 
                                                               runat="server" ConfirmText="Cuidado!!!! Al borrar este elemento se borraran las respuestas enviadas por los alumnos ¿Deseas continuar y borrar este elemento?" Enabled="True" TargetControlID="Imagebutton2">
                                                           </cc1:ConfirmButtonExtender>
                                                           
                                                       </itemtemplate>
                                                   </asp:templatecolumn>
                                                   <asp:templatecolumn HeaderText="Actividades">
                                                       <itemtemplate>
                                                           <asp:Label ID="lbl123" Runat="server">
                                                           <%# DataBinder.Eval(Container.DataItem, "Titulo") %></asp:Label>
                                                       </itemtemplate>
                                                    
                                                   </asp:templatecolumn>
                                                   <asp:templatecolumn HeaderText="% Relativo">
                                                       <headerstyle width="100px" CssClass="text-center" />
                                                       <itemstyle horizontalalign="right" />
                                                       <itemtemplate>
                                                          
                                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ForeColor="Red"
                                                               ControlToValidate="txtValor" Display="Dynamic">*</asp:RequiredFieldValidator>
                                                           <asp:Label ID="lblID" runat="server" 
                                                               Text='<%# DataBinder.Eval(Container.DataItem, "idActividadSalonVirtual") %>' 
                                                               Visible="False"> </asp:Label>
                                                            <asp:TextBox ID="txtValor" runat="server"   Width="60px" MaxLength="3"  CssClass="form-control text-right" 
                                                               Text='<%# DataBinder.Eval(Container.DataItem, "Valor") %>'>
                                                           </asp:TextBox>
                                                       </itemtemplate>
                                                   </asp:templatecolumn>
                                               </columns>
                                           </asp:DataGrid>
                                           <div style="text-align:right;   padding-right:10px;">
                                                 <asp:Label ID="lblTotal" runat="server" Text="Label" ForeColor="red" Font-Bold="true"> </asp:Label> 
                                             
                                           </div>
                                            <div style="text-align:right; padding-right:10px;">
                                                 <asp:Button ID="btnGrabar" runat="server" CssClass="btn btn-primary" Text="Grabar valores" />
                                            </div>
                                         

                    </div>

                </div>
               
                 
               

             </div>
        </div>

    </div>


</div>

</asp:Content>

