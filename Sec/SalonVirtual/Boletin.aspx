<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="Boletin.aspx.vb" Inherits="Sec_SalonVirtual_Boletin" title="Boletín de anuncios" ValidateRequest="false" %>

<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>


<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lbltitulo" runat="server"  ></asp:Label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>


<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/default.aspx" ></asp:HyperLink></li>
        <li><asp:HyperLink ID="lnkMuro" runat="server" ></asp:HyperLink></li>
      <li class="active"><asp:Label ID="lblCursoBread" runat="server" Text="Editar comentarios"  ></asp:Label></li>
    </ol>

</asp:Content>





<asp:Content ID="contentCentral" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">


     <div class="row">

        <div class="col-xs-3">
             <uc1:MenuSalonVirtual ID="MenuSalonVirtual2" runat="server" />
        </div>
        <div class="col-xs-9">

                        
            <div class="panel">
 

                <div class="panel-heading">
        
                        <h3 class="panel-title"><asp:Label ID="Label1" runat="server" Text="Escribe tu comentario"></asp:Label></h3>
                </div>
                <div class="panel-body">
            

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>

             
  
                        <asp:TextBox ID="txtmensaje" runat="server" Height="81px" TextMode="MultiLine"  CssClass="form-control"
                            ></asp:TextBox>
                                <asp:RequiredFieldValidator 
                            ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtmensaje">*</asp:RequiredFieldValidator>
                        <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" 
                            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                        </cc1:ValidatorCalloutExtender>

                        <div style="height:5px;"></div>
                        <asp:Button ID="btngrabar" runat="server" Text="Grabar"  CssClass="btn btn-success" />
                        <cc1:ConfirmButtonExtender ID="btngrabar_ConfirmButtonExtender" runat="server" 
                            ConfirmText="¿Deseas actualizar el boletín de anuncios?" Enabled="True" 
                            TargetControlID="btngrabar">
                        </cc1:ConfirmButtonExtender>
                        &nbsp;<asp:Button ID="btnborrar" runat="server" Text="Borrar" Visible="False" CssClass="btn btn-danger"/>
                        <cc1:ConfirmButtonExtender ID="btnborrar_ConfirmButtonExtender" runat="server" 
                            ConfirmText="¿Deseas borrar este anuncio del boletín?" Enabled="True" 
                            TargetControlID="btnborrar">
                        </cc1:ConfirmButtonExtender>
                        <br />
                        <br />
         
       
    

      


                   </ContentTemplate>
                </asp:UpdatePanel>

              </div>
    
            </div>
            
             
            <div class="panel">
 

                <div class="panel-heading">
        
                        <h3 class="panel-title"><asp:Label ID="Label3" runat="server" Text="Comentarios de alumnos y maestros"></asp:Label></h3>
                </div>
                <div class="panel-body">
      

	            <asp:DataList id="DataList1" runat="server" Width="100%">
		            <ItemTemplate>
		                <div class="media">
                          <div class="media-left">
                              <asp:Image id="imgAlumno" runat="server" Width="64px" class="media-object"  ImageUrl='<%# getImagen(Eval("imagen"), Eval("claveAux1"), CInt(Eval("idUserProfile"))) %>' />
                          </div>
                          <div class="media-body">
       
                            <asp:Label id="lbltexto" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Texto") %>'></asp:Label>
                            <div style="height:4px;"></div>

                            <asp:Label id="lblUsuario" runat="server" Font-Italic="true"  Font-Bold="true" Font-Size="11px"  Text='<%# DataBinder.Eval(Container.DataItem, "Nombre") %>' ></asp:Label>&nbsp;
		                    <asp:Label id="Label2" runat="server" Font-Italic="true" Font-Bold="true" Font-Size="11px"  Text='<%# DataBinder.Eval(Container.DataItem, "fecha", "{0:F}")  %>'></asp:Label>
                            <div style="height:4px;"></div>
		                    <asp:HyperLink  ID="lnkeditar" Visible='<%# presentar(CInt(Eval("idUserProfile"))) %>' NavigateUrl='<%# "~/sec/SalonVirtual/Boletin.aspx?idSalonVirtual=" & Eval("idSalonVirtual") & "&idBoletinSalonVirtual=" & Eval("idBoletinSalonVirtual") %>' runat="server"  >
                            <span class="badge badge-success"><asp:Literal ID="Literal1" runat="server" Text="Editar"></asp:Literal></span>
		                    </asp:HyperLink>


                          </div>
                        </div>
                        <div style="height:10px;"></div>
		            </ItemTemplate>
	            </asp:DataList>

      

                </div>
            </div>



        </div>
        <div class="col-xs-2">

        </div>
    </div>

	
	
    
        <asp:Label ID="labelCursosComoDocente" runat="server" Text="Cursos como docente" Visible="false"></asp:Label>
    <asp:Label ID="labelCursosComoAlumno" runat="server" Text="Label"  Visible="false"></asp:Label>



</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">
   
     <uc22:MenuGeneral ID="MenuGeneral1" runat="server" />

</asp:Content>


