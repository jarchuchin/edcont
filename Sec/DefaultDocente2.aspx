<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="DefaultDocente2.aspx.vb" Inherits="Sec_DefaultDocente2" title="Mis cursos" %>


<%@ Register src="Workbook/Controles/MyWorkBooks.ascx" tagname="MyWorkBooks" tagprefix="uc2" %>
<%@ Register src="Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc3" %>
<%@ Register src="SalonVirtual/Controles/MisSalonesVirtualesInstructor.ascx" tagname="MisSalonesVirtualesInstructor" tagprefix="uc4" %>
<%@ Register src="SalonVirtual/Controles/MisSalonVirtualesAlumno.ascx" tagname="MisSalonVirtualesAlumno" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<%@ Register src="Controles/DatosUserProfile.ascx" tagname="DatosUserProfile" tagprefix="uc5" %>


<%@ Register src="Controles/DisplayAgenda.ascx" tagname="DisplayAgenda" tagprefix="uc6" %>



<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblTitulo" runat="server"  Text="Mis cursos como docente" ></asp:Label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelBreadcrumb" Runat="Server">


<ol class="breadcrumb" style="margin-bottom: 5px;">
  <li><asp:HyperLink ID="HyperLink2" runat="server"  Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
  <li class="active">Mis cursos como docente</li>
</ol>


</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">   







		


        
        <div class="panel">
		        <div class="panel-heading">



                      <div ID="panelEdicion" class="panel-control form-inline" runat="server" style="text-align:right">

                    <div class="form-group">
                                  <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control" Width="250px" placeHolder="Buscar cursos"></asp:TextBox>
                                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar"  CssClass="btn btn-success btn-sm"  />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBuscar"  ErrorMessage="Coloca el texto para iniciar la búsqueda" meta:resourcekey="RequiredFieldValidator1Resource1">*</asp:RequiredFieldValidator>
                                            <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender"  runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                                            </cc1:ValidatorCalloutExtender>
                             </div>
           
               
                    <asp:LinkButton ID="lnkTodos" runat="server" CausesValidation="false" CssClass="btn btn-default btn-sm" Text="Ver todos"></asp:LinkButton>
                 &nbsp;<asp:Button ID="btnNuevo" runat="server" Text="Nuevo curso" CssClass="btn btn-primary btn-sm" Visible="true" CausesValidation="false" />


			 </div>

                    <h3 class="panel-title"> <asp:Label ID="Label2" runat="server" Text="Cursos como docente"></asp:Label><asp:HyperLink ID="lnkvernuevo" runat="server" NavigateUrl="~/sec/defaultDocente.aspx" Text="Vista en lista" CssClass="btn btn-warning btn-sm"></asp:HyperLink></h3>
                </div>
                 <div class="panel-body">

                     <div class="text-right" style="font-size:11px; height:40px;">
                       Ordenar por:&nbsp;&nbsp;  <asp:DropDownList ID="drpOrden" runat="server" Font-Size="11px" AutoPostBack="true">
                           <asp:ListItem Text="Nombre" Value="NombreE"></asp:ListItem>
                           <asp:ListItem Text="FechaInicio" Value="FechaInicio"></asp:ListItem>
                           <asp:ListItem Text="Clave" Value="ClaveAux1"></asp:ListItem>
                           
                                     </asp:DropDownList> 
                     </div>

                     <div class="row">
                         
                         

                          
                         <asp:Repeater ID="rptSalnes" runat="server" >
                             <ItemTemplate>
                                 <div class="col-md-4 col-sm-6 col-xs-12">

                                     <div style="height:210px">
                                     <div class="row">
                                         <div class="col-xs-6">
                                             <asp:literal ID="limimg" runat="server" Text='<%# getFoto(Eval("fileDisplay"), Eval("videoDisplay"), Eval("EmbeddedDisplay"), Eval("idSalonVirtual")) %>'  />
                                         </div>
                                         <div class="col-xs-6">
                                             <b>Nombre:</b>
                                             <div style="height:0px;"></div>
                                             <asp:HyperLink ID="lnksalon" runat="server" NavigateUrl='<%# "~/sec/salonvirtual/default.aspx?idSalonVirtual=" & Eval("idSalonVirtual") %>' >
                                             <asp:Label ID="lblNombre" runat="server" Text='<%#Eval("Nombre") %>'  ></asp:Label> - <asp:Label ID="Label3" runat="server" Text='<%#Eval("ClaveAux1") %>'></asp:Label></asp:HyperLink>
                                             <div style="height:0px;"></div>
                                             <b>Fecha inicio:</b>
                                             <div style="height:0px;"></div>
                                             <asp:Label ID="lblFecha" runat="server" Text='<%#Format(Eval("FechaInicio"), "d")  %>'></asp:Label>

                                              <div style="height:0px;"></div>
                                             <b>Fecha de fin:</b>
                                             <div style="height:0px;"></div>
                                             <asp:Label ID="Label1" runat="server" Text='<%#Format(Eval("FechaFin"), "d")  %>'></asp:Label>
                                                 <div style="height:10px;"></div>
                                         </div>
                                     </div>
                                    </div>
                                 </div>
                             </ItemTemplate>
                         </asp:Repeater>
                         


                     </div>

     

                  </div>
         </div>


         
    
  
              
              



   
            

         
</asp:Content>

<asp:Content ID="Content3" runat="server" 
    contentplaceholderid="ContentPanelMenu">


    <uc3:MenuGeneral ID="MenuGeneral1" runat="server" />


</asp:Content>




