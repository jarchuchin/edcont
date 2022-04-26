<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="verForo.aspx.vb" Inherits="Sec_SalonVirtual_verForo" title="Untitled Page" ValidateRequest="false"%>

<%@ Register src="~/Sec/Workbook/Controles/showadjuntos.ascx" tagname="showadjuntos" tagprefix="uc2" %>
<%@ Register src="~/Sec/Workbook/Controles/displayComentariosVistaPrevia.ascx" tagname="displayComentarios" tagprefix="uc3" %>


<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>



<%@ Register src="~/Sec/SalonVirtual/Controles/displayBuscadores.ascx" tagname="displayBuscadores" tagprefix="uc1" %>



<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server" Text="Foro"  ></asp:Label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Cursos como docente"  NavigateUrl="~/sec/default.aspx" ></asp:HyperLink></li>
         <li><asp:HyperLink ID="lnkCurso" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/Sa/default.aspx" ></asp:HyperLink></li>
          <li><asp:HyperLink ID="lnkUnidad" runat="server"  Text="Unidad"  ></asp:HyperLink></li>
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Foro" ></asp:Label></li>
    </ol>


   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">
   
     <uc22:MenuGeneral ID="MenuGeneral1" runat="server" />

</asp:Content>



<asp:Content ID="contentCentral" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
     <div class="row">

        <div class="col-xs-3">
               <div class="panel">
                            <div class="panel-heading">
                        

                    <h3 class="panel-title">
                                        <asp:Label ID="Label1" runat="server" Text="Menú del curso"></asp:Label>
                                    </h3>
                            </div>
                            <div class="panel-body text-center">


                                <div style="height: 50px"></div>

                                <asp:hyperlink ID="btnRegresarEdicion" runat="server" Text="Regresar a edición" CssClass="btn btn-primary form-control"  NavigateUrl="javascript:history.back(-1);" />


                                     <div style="height: 250px"></div>

                            </div>
            
                </div>
        </div>
        <div class="col-xs-9">


               <div class="row">
                 <div class="col-xs-8">

                       <div class="panel">
                            <div class="panel-heading">
				
<h3 class="panel-title">
				<asp:Label ID="lblTitulo" runat="server" ></asp:Label>
    </h3>
		 </div>
                            <div class="panel-body divPanelLink">
<div class="areaEdicion">
				<asp:HyperLink ID="lnkSalir" runat="server">Salir de vista previa</asp:HyperLink>
			</div>

                                 <asp:Label ID="Label2" runat="server" Text="Unidad de actividad" Font-Bold="true"></asp:Label>
                                 <div style="height:2px;"></div>
                                <asp:Label ID="lblClasificacion" runat="server"></asp:Label>
						         <div style="height:10px;"></div>

                        <p>
							<span class="seccion">OBJETIVO</span><br />
							<asp:Label ID="lblObjetivo" runat="server" Text="---"></asp:Label>
						</p>


                        <p>
							<asp:Label ID="lblFecha" runat="server" CssClass="texto11"></asp:Label><br />
						<asp:Literal ID="littexto" runat="server"></asp:Literal>
							
						</p>
						

						<table style="width:100%; border: 0;">
						<tr>
							<td>

								<table style="width:100%; border: 0;">
								<tr>
									<td style="width:10px; vertical-align:top;"><asp:Image ID="Image4" runat="server" ImageUrl="~/Images/ico-coments.png" /></td>
									<td style="text-align:right; vertical-align:top;"><asp:Button ID="btnResponder" 
											runat="server" Text="Responder" CssClass="button" Enabled="False" /></td>
								</tr>
								</table>

								<hr size="1" width="100%" />
								<asp:Literal ID="litarbol" runat="server"></asp:Literal>
								<hr size="1" width="100%" />

								<asp:DataGrid ID="dtgLista" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#C1CDD8" DataKeyField="idForoSalonVirtual" GridLines="Horizontal" Width="100%">
									<SelectedItemStyle BackColor="#C1CDD8" />
									<HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
									<Columns>
										<asp:TemplateColumn>
											<HeaderStyle Width="25px" />
											<ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
											<ItemTemplate>
												<a name='<%# DataBinder.Eval(Container.DataItem, "idForoSalonVirtual")%>'></a>
												<asp:Image ID="Imagde3" runat="server" ImageUrl="~/Images/ico-coments.png" />
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn>
											<HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
											<ItemTemplate>
												<asp:Label ID="Label2" runat="server" Font-Bold="true"><%# DataBinder.Eval(Container.DataItem, "Titulo") %> </asp:Label><br/>
												<asp:Label ID="lblDate" runat="server" CssClass="texto11"><%# DataBinder.Eval(Container.DataItem, "fechaCreacion", "{0:f}" ) %></asp:Label><br />
												<asp:Label ID="lblName" runat="server" CssClass="texto11"><%# Eval("nombreUsuario") %> </asp:Label><br/>
												<asp:Label ID="Label1" runat="server"><%# replace( DataBinder.Eval(Container.DataItem, "Texto"), vbcrlf, "<br>") %></asp:Label><br />
												<asp:HyperLink ID="HyperLink1" runat="server" Width="150px" NavigateUrl='<%# "~/sec/showfile.aspx?idForoSalonVirtual=" & eval("idForoSalonVirtual") %>' Text='<%# DataBinder.Eval(Container.DataItem, "nombreOriginal")%> '></asp:HyperLink><br />
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn>
											<HeaderStyle Width="90px" />
											<ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
											<ItemTemplate>
												<asp:HyperLink ID="HyperLink2" runat="server" CssClass="grisClaro12" NavigateUrl='<%#"verForoRespuesta.aspx?idForo=" & DataBinder.Eval(Container.DataItem, "idForo") & "&idSalonVirtual=" & DataBinder.Eval(Container.DataItem, "idSalonVirtual") & "&idRaiz=" & DataBinder.Eval(Container.DataItem, "idForoSalonVirtual") & "&idCI=" & request("idCI") %>' Text="Responder"></asp:HyperLink><br />
												<asp:Image ID="Image1" width="80px" ImageUrl='<%# getLiga(eval("nombre"), cint(eval("idForoSalonVirtual"))) %>' Visible='<%# getMostrar(eval("nombre")) %>' runat="server" />
											</ItemTemplate>
										</asp:TemplateColumn>
									</Columns>
								</asp:DataGrid>
							</td>
						</tr>
						</table>

					</div>

				</div>


                            <div class="panel">
                            <div class="panel-heading">
                                    <h3 class="panel-title"><asp:Label ID="Label5" runat="server" Text="Comentarios de alumnos"  /></h3>
                            </div>
                            <div class="panel-body">
                                <uc3:displayComentarios ID="displayComentarios1" runat="server" />
                            </div>

                      </div>
                   
                
                 </div>

	
                <div class="col-xs-4">

                   	  <uc2:showadjuntos ID="showContenidos" runat="server" />
                            <uc2:showadjuntos ID="showArchivosAdjuntos" runat="server" />
					        <uc2:showadjuntos ID="showDirecciones" runat="server" />
					        <uc2:showadjuntos ID="showImagenesAdjuntos" runat="server" />
					        <uc2:showadjuntos ID="showFlashes" runat="server" />



                    <uc1:displayBuscadores ID="displayBuscadores1" runat="server" />
                   

                </div>
   






</div>


            </div>

</div>


    

<asp:Label ID="labelCursosComoDocente" runat="server" Text="Cursos como docente" Visible="false"></asp:Label>
<asp:Label ID="labelCursosComoAlumno" runat="server" Text="Cursos como alumno"  Visible="false"></asp:Label>
    




</asp:Content>



