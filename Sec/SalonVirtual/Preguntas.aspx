<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="Preguntas.aspx.vb" Inherits="Sec_SalonVirtual_Preguntas" title="Lista de preguntas" %>

<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server" Text="Preguntas del grupo" ></asp:Label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/default.aspx" ></asp:HyperLink></li>
       <li><asp:HyperLink ID="lnkCurso" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/Sa/default.aspx" ></asp:HyperLink></li>
      <li class="active"><asp:Label ID="lblCursoBread" runat="server" Text="Preguntas y respuestas"  ></asp:Label></li>
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

                     <div class="panel-control" style="text-align:right">
                          <asp:Button ID="btnNueva" runat="server"  CssClass="btn btn-primary bt-sm" Text="Hacer pregunta"  />

                    </div>

                        <h3 class="panel-title"><asp:Label ID="Label1" runat="server" Text="Preguntas y respuestas"></asp:Label></h3>
                </div>
                <div class="panel-body">





                    <div style="height:25px;"></div>



                     <asp:DataList id="DataList2" runat="server" Width="100%">
		            <ItemTemplate>
		                <div class="media">
                          <div class="media-left">
                              <asp:Image id="Image2" runat="server"  Width="64px" cssclass="media-object"  ImageUrl='<%# getImagen(eval("imagen"), eval("claveAux1"), eval("claveAux2"), cint(eval("idUserProfile"))) %>' />
                             
                          </div>
                          <div class="media-body">
       
                              <asp:Label ID="Label6" runat="server" Text="Pregunta: " Font-Bold="true"></asp:Label><asp:Label id="lbltexto" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Pregunta") %>'></asp:Label>
                               <div style="height:4px;"></div>
                            <asp:Label id="lblUsuario" runat="server" Font-Italic="true" Font-Size="11px" Text='<%# DataBinder.Eval(Container.DataItem, "Nombre") %>' ></asp:Label>&nbsp;
		                    <asp:Label id="Label2" runat="server" Font-Italic="true" Font-Size="11px"  Text='<%# DataBinder.Eval(Container.DataItem, "PreguntaFecha", "{0:F}")  %>'></asp:Label>


                              <div id="divRespuesta" runat="server" Visible='<%# esvisible(Eval("Respuesta")) %>'>
                            <div style="height:4px;"></div>
                             <asp:Label ID="Label7" runat="server" Text="Respuesta: " Font-Bold="true"></asp:Label><asp:Label id="Label8" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Respuesta") %>'></asp:Label>
                             <div style="height:4px;"></div>
                            <asp:Label id="Label9" runat="server" Font-Italic="true" Font-Size="11px" Text='<%# DataBinder.Eval(Container.DataItem, "nombreMaestro") %>' ></asp:Label>&nbsp;
		                    <asp:Label id="Label10" runat="server" Font-Italic="true" Font-Size="11px"  Text='<%# DataBinder.Eval(Container.DataItem, "RespuestaFecha", "{0:F}")  %>'></asp:Label>
                            </div>
                           
                            <div style="height:4px;"></div>
		                    <asp:HyperLink  ID="lnkeditar" Visible='<%# presentar(CInt(Eval("idUserProfile"))) %>'  NavigateUrl='<%# "PreguntasNueva.aspx?idSalonVirtual=" & Eval("idSalonVirtual") & "&idSalonVirtualPregunta=" & Eval("idSalonVirtualPregunta") %>' runat="server"  >
                            <span class="badge badge-success"><asp:Literal ID="Literal1" runat="server" Text="Editar"></asp:Literal></span>
		                    </asp:HyperLink>
                            <asp:HyperLink  ID="lnkResponder" Visible='<%# presentar(CInt(Eval("idMaestro"))) %>'   NavigateUrl='<%# "PreguntasEditarRespuesta.aspx?idSalonVirtual=" & Eval("idSalonVirtual") & "&idSalonVirtualPregunta=" & Eval("idSalonVirtualPregunta") %>' runat="server"  >
                            <span class="badge badge-warning"><asp:Literal ID="Literal2" runat="server" Text="Responder"></asp:Literal></span>
		                    </asp:HyperLink>
                             

                          </div>


                            


                        </div>
                        <div style="height:10px;"></div>
		            </ItemTemplate>
	            </asp:DataList>

               <%--     <asp:Repeater ID="rptPreguntas" runat="server" >
                        <HeaderTemplate>
                            <ul class="list-unstyled search-result-list">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li>
										<p class="result-type">
											<span class="label label-primary">sss</span>
										</p>
										<a href="pages-user-profile.html" class="has-thumb">
											<div class="result-thumb">
												
											</div>
											<div class="result-data">
												<p class="h3 title text-primary"></p>
												<p class="description">
                                                    <asp:Literal ID="litpregunta" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Pregunta") %>'></asp:Literal><br />
<asp:Label id="Label2" runat="server"    Font-Size="11px" Text='<%# DataBinder.Eval(Container.DataItem, "PreguntaFecha", "{0:F}" )  %>'></asp:Label>
												</p>
											</div>
										</a>
									</li>

                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                        </FooterTemplate>
                    </asp:Repeater>--%>

     

                    </div>
                </div>

            </div>

      </div>

    
    

        <asp:Label ID="labelCursosComoDocente" runat="server" Text="Cursos como docente" Visible="false"></asp:Label>
    <asp:Label ID="labelCursosComoAlumno" runat="server" Text="Label"  Visible="false"></asp:Label>

</asp:Content>



