<%@ Page Title="" Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="DesplegarTodo.aspx.vb" Inherits="Sec_Workbook_DesplegarTodo" %>

<%@ Register src="Controles/DisplayVerActividad.ascx" tagname="DisplayVerActividad" tagprefix="uc1" %>
<%@ Register src="Controles/DisplayVerArchivo.ascx" tagname="DisplayVerArchivo" tagprefix="uc2" %>
<%@ Register src="Controles/DisplayVerFlash.ascx" tagname="DisplayVerFlash" tagprefix="uc3" %>
<%@ Register src="Controles/DisplayVerForo.ascx" tagname="DisplayVerForo" tagprefix="uc4" %>
<%@ Register src="Controles/DisplayVerImagen.ascx" tagname="DisplayVerImagen" tagprefix="uc5" %>
<%@ Register src="Controles/DisplayVerTexto.ascx" tagname="DisplayVerTexto" tagprefix="uc6" %>
<%@ Register src="Controles/DisplayVerExamen.ascx" tagname="DisplayVerExamen" tagprefix="uc7" %>

<%@ Register src="Controles/Menu.ascx" tagname="Menu" tagprefix="uc11" %>

<%@ Register src="Controles/DisplayProgress.ascx" tagname="DisplayProgress" tagprefix="uc33" %>




<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombredelLibro2" runat="server"  ></asp:Label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelBreadcrumb" Runat="Server">

   
<ol class="breadcrumb"  >
  <li><asp:HyperLink ID="HyperLink3" runat="server"  Text="Inicio" NavigateUrl="~/sec/home.aspx" meta:resourcekey="HyperLink3Resource1"></asp:HyperLink></li>
     <li><asp:HyperLink ID="HyperLink2" runat="server"  Text="Libros de trabajo" NavigateUrl="~/sec/Libros.aspx" meta:resourcekey="HyperLink2Resource1"></asp:HyperLink></li>
  <li class="active"><asp:Label ID="lblNombreDelLibro" runat="server" meta:resourcekey="lblNombreDelLibroResource1" ></asp:Label></li>
</ol>

</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">




      


      <%--  Datos Generales--%>
      
<div class="row">
	<div class="col-xs-9">
		<div class="panel">

            <div class="panel-heading">
                <div class="panel-control">

                </div>
                 <h3 class="panel-title">
                         <asp:Label ID="lblTitulobox" runat="server"  ></asp:Label>
                     </h3>
            </div>
			
             <div class="panel-body">


                 



                <div class="alert alert-warning" id="lblNoIdioma" runat="server"  visible="false">
                  <span class="glyphicon glyphicon-exclamation-sign"></span><strong>&nbsp; <asp:Label ID="Label11" runat="server" Text="Alerta!" meta:resourcekey="Label11Resource1"></asp:Label>&nbsp;&nbsp; </strong> <asp:label id="lblMensajeBorrarinside" runat="server"  text="El contenido no esta en el idioma seleccionado" ></asp:label>
                </div>
    

                <h4><asp:Label ID="Label1" runat="server" Text="Descripcion general" ></asp:Label></h4>
 
                    <asp:Label ID="labelfecha" runat="server" Text="Última Actualización: " Font-Size="11px"  ></asp:Label>&nbsp;<asp:Label ID="lblUltimaActualizacion" runat="server"   Font-Size="11px"  ></asp:Label><br />
                <asp:literal ID="lbldescripcion" runat="server" ></asp:literal>
                <div style="height:10px;"></div>

                <h4><asp:Label ID="Label2" runat="server" Text="Palabras claves" ></asp:Label></h4>
                <asp:literal ID="lbltags" runat="server"></asp:literal>
                <div style="height:10px;"></div>

                <h4><asp:Label ID="Label3" runat="server" Text="Autor" ></asp:Label></h4>
                <asp:Label ID="lblautor" runat="server"  ></asp:Label>
                <div style="height:10px;"></div>

                <h4><asp:Label ID="Label4" runat="server" Text="Biblioteca"></asp:Label></h4>
                <asp:literal ID="lblbiblioteca" runat="server" ></asp:literal>
                <div style="height:10px;"></div>

                <h4><asp:Label ID="Label5" runat="server" Text="Sugerencias para el instructor" ></asp:Label></h4>
                <asp:literal ID="lblparainstructor" runat="server" ></asp:literal>
                <div style="height:10px;"></div>

                <h4><asp:Label ID="Label6" runat="server" Text="Convenios y derechos de autor" ></asp:Label></h4>
                <asp:literal ID="lblConvenios" runat="server"  ></asp:literal>
                <div style="height:10px;"></div>

                <h4><asp:Label ID="Label7" runat="server" Text="Archivo de certificación"></asp:Label></h4>
                <asp:HyperLink ID="lnkcertificacion" runat="server" Target="_blank" >[lnkcertificacion]</asp:HyperLink>


                <div style="height:10px;"></div>

                <h4><asp:Label ID="Label8" runat="server" Text="Idioma default" ></asp:Label></h4>
                <asp:literal ID="lblIdioma" runat="server"  ></asp:literal>
                <div style="height:10px;"></div>



                <div style="height:40px;"></div>




            </div>

        </div>

    </div>
    <div class="col-xs-3">


       <%-- <uc33:DisplayProgress ID="DisplayProgress1" runat="server" />--%>

        <div class="panel">
			
             <div class="panel-body">
              <%--  <uc11:Menu ID="Menu1" runat="server" />--%>

                 <asp:Button ID="btnGenerar" runat="server" CssClass="btn btn-success form-control" Text="Generar pdf" />
             </div>
       </div>



        
        
    </div>
</div>



        <div style="page-break-before: always"></div>

    <div class="row">
        <div class="col-xs-9">

            <div class="panel">

                <div class="panel-heading">
                    <div class="panel-control">

                    </div>
                     <h3 class="panel-title">
                             <asp:Label ID="lblresumendecontenidos" Text="Resumen de contenidos" runat="server"></asp:Label>
                         </h3>
                </div>
			
                 <div class="panel-body">


                     <asp:Repeater ID="repeaterClasificaciones" runat="server">
						<ItemTemplate>
							<h3 >
								<asp:HyperLink ID="lnkCarpeta" runat="server" Text='<%#Eval("titulo") %>' NavigateUrl='<%# "~/sec/workbook/AddCarpeta.aspx?idRoot=" & Eval("idRoot") & "&idClasificacion=" & Eval("idClasificacion") %>'></asp:HyperLink>
							</h3>

							<div style="text-align:left;">
								<table>
								<tr>
					<td><asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/Images/bull-arrow3.png" %>' /></td>
					<td>
						<asp:HyperLink ID="lnkPruebaDiagnostico" runat="server"  CssClass="btn-link" NavigateUrl='<%# "~/Sec/Workbook/Examen.aspx?idRoot=" & Eval("idRoot") & "&idClasificacion=" & Eval("idClasificacion") & "&idA=" & Eval("idActividad") %>'>Prueba de diagnóstico</asp:HyperLink>
					</td>
				</tr>
								<tr>
									<td>&nbsp;</td>
									<td > <h4>Contenidos</h4> </td>
								</tr>
								<tr>
					<td>&nbsp;</td>
					<td>
						<asp:ListView ID="listViewContenidos" runat="server">
						<LayoutTemplate>
							<table style="width:100%;">
							<tr runat="server" ID="itemPlaceholder">
							</tr>
							</table>
						</LayoutTemplate>
						<ItemTemplate>
							<tr>
								<td style="width:10px"><asp:Image ID="Image4" runat="server" ImageUrl='<%# "~/Images/bull-arrow3.png" %>' /></td>
								<td style="vertical-align:top;"><asp:HyperLink ID="lnkContenido" runat="server" NavigateUrl='<%# getLinkAnexos(Eval("idRoot"), Eval("idClasificacionItem"), Eval("idClasificacion"), "Contenido", Eval("idTipo")) %>' CssClass="linkMenu12" Text='<%# Eval("titulo")%>'></asp:HyperLink></td>
							</tr>
						</ItemTemplate>
						<EmptyDataTemplate>
							<%--<asp:Label ID="lblNoData" runat="server" CssClass="textoNoData12" Text="No hay accesibles en esta fecha"></asp:Label>--%>
						</EmptyDataTemplate>
					</asp:ListView>
					</td>
				</tr>
								<tr>
									<td>&nbsp;</td>
									<td><h4>Actividades</h4></td>
								</tr>
								<tr>
					<td>&nbsp;</td>
					<td>
						<asp:ListView ID="listViewActividades" runat="server">
						<LayoutTemplate>
							<table style="width:100%;">
							<tr runat="server" ID="itemPlaceHolder">
							</tr>
							</table>
						</LayoutTemplate>
						<ItemTemplate>
							<tr>
								<td style="width:10px"><asp:Image ID="Image4" runat="server" ImageUrl='<%# "~/Images/bull-arrow3.png" %>' /></td>
								<td style="vertical-align:top;"><asp:HyperLink ID="lnkActividad" runat="server" NavigateUrl='<%# getLinkAnexos(Eval("idRoot"), Eval("idClasificacionItem"), Eval("idClasificacion"), "Actividad", Eval("idTipo")) %>' CssClass="linkMenu12" Text='<%# Eval("titulo")%>'></asp:HyperLink></td>
							</tr>
						</ItemTemplate>
						<EmptyDataTemplate>
							<%--<asp:Label ID="lblNoData" runat="server" CssClass="textoNoData12" Text="No hay accesibles en esta fecha"></asp:Label>--%>
						</EmptyDataTemplate>
				</asp:ListView>
			</td>
		</tr>
								<tr>
									<td>&nbsp;</td>
									<td><h4>Exámenes</h4></td>
								</tr>
								<tr>
			<td>&nbsp;</td>
			<td>
				<asp:ListView ID="listViewExamenes" runat="server">
					<LayoutTemplate>
						<table style="width:100%;">
						<tr runat="server" ID="itemPlaceHolder">
						</tr>
						</table>
					</LayoutTemplate>
					<ItemTemplate>
						<tr>
							<td style="width:10px"><asp:Image ID="Image4" runat="server" ImageUrl='<%# "~/Images/bull-arrow3.png" %>' /></td>
							<td style="vertical-align:top;">
								<asp:HyperLink ID="lnkExamen" runat="server" NavigateUrl='<%# getLinkAnexos(Eval("idRoot"), Eval("idClasificacionItem"), Eval("idClasificacion"), "Examen", Eval("idTipo")) %>' CssClass="linkMenu12" Text='<%# Eval("titulo")%>'></asp:HyperLink>
							</td>
						</tr>
					</ItemTemplate>
					<EmptyDataTemplate>
						<%--<asp:Label ID="lblNoData" runat="server" CssClass="textoNoData12" Text="No hay accesibles en esta fecha"></asp:Label>--%>
					</EmptyDataTemplate>
				</asp:ListView>
			</td>
		</tr>
								<tr>
									<td>&nbsp;</td>
									<td><h4>Foros</h4></td>
								</tr>
								<tr>
			<td>&nbsp;</td>
			<td>
				<asp:ListView ID="listViewForos" runat="server">
					<LayoutTemplate>
						<table style="width:100%;">
						<tr runat="server" ID="itemPlaceHolder">
						</tr>
						</table>
					</LayoutTemplate>
					<ItemTemplate>
						<tr>
							<td style="width:10px"><asp:Image ID="Image4" runat="server" ImageUrl='<%# "~/Images/bull-arrow3.png" %>' /></td>
							<td style="vertical-align:top;"><asp:HyperLink ID="lnkForo" runat="server" NavigateUrl='<%# getLinkAnexos(Eval("idRoot"), Eval("idClasificacionItem"), Eval("idClasificacion"), "Foro", Eval("idTipo")) %>' CssClass="linkMenu12" Text='<%# Eval("titulo")%>'></asp:HyperLink></td>
						</tr>
					</ItemTemplate>
					<EmptyDataTemplate>
						<%--<asp:Label ID="lblNoData" runat="server" CssClass="textoNoData12" Text="No hay accesibles en esta fecha"></asp:Label>--%>
					</EmptyDataTemplate>
				</asp:ListView>
			</td>
		</tr>
								</table>
							</div>

                           <%-- <hr />--%>
						</ItemTemplate>
						<FooterTemplate>
						</FooterTemplate>
					</asp:Repeater>


                 </div>
            </div>


        </div>

    </div>

     


       
        		



          

        <div style="page-break-before: always"></div>
       


    
    


    <asp:DataList ID="dtlCapitulos" runat="server" Width="100%">
        <ItemTemplate>

            <div class="row">
                <div class="col-xs-9">

                  


                    <div class="panel">

                <div class="panel-heading">

                    

                    <div  ID="PanelIcons" runat="server" class="panel-control">
                           <asp:HyperLink ID="ibLectura" runat="server" ImageUrl="~/Images/iconsDiamante/iconEditarTexto.jpg"  ImageWidth="35px"  ToolTip="Nuevo texto" meta:resourcekey="ibLecturaResource1"  />
                           <asp:HyperLink ID="ibArchivo" runat="server"  ImageUrl="~/Images/iconsDiamante/iconArchivoUpload.jpg"  ImageWidth="35px" ToolTip="Nuevo archivo" meta:resourcekey="ibArchivoResource1"    />
                         <asp:HyperLink ID="ibArticulate" runat="server"  ImageUrl="~/Images/iconsDiamante/iconArticulate.jpg"  ImageWidth="35px" ToolTip="Nuevo archivo" meta:resourcekey="ibArticulateResource1"    />
                           <asp:HyperLink ID="ibActividad" runat="server"  ImageUrl="~/Images/iconsDiamante/iconActividad.jpg"  ImageWidth="35px"  ToolTip="Nueva actividad" meta:resourcekey="ibActividadResource1"  />
                           <asp:HyperLink ID="ibExamen" runat="server"  ImageUrl="~/Images/iconsDiamante/iconExamen.jpg"  ImageWidth="35px"  ToolTip="Nuevo examen" meta:resourcekey="ibExamenResource1"  />
                          <asp:HyperLink ID="ibForo" runat="server" CausesValidation="False" ImageUrl="~/Images/iconsDiamante/iconForos.jpg"  ImageWidth="35px"  ToolTip="Agregar foro" meta:resourcekey="ibForoResource1"  />
                            <asp:HyperLink ID="ibBuscar" runat="server" ImageUrl="~/Images/iconsDiamante/iconBuscar.jpg" ImageWidth="35px"  ToolTip="Buscar contenido y agregarlo" meta:resourcekey="ibBuscarResource1"    />

                    </div>
                     <h3 class="panel-title">
                          <asp:Label ID="lblTitulo" runat="server" Text='<%# CStr(Eval("Titulo")).ToUpper%>' Font-Bold="true"></asp:Label>
                     </h3>
                </div>
              <div class="panel-body">


                  

    
<%--        <div class="pull-right">
            <asp:HyperLink ID="lnkEditarCarpeta" runat="server" Text="Editar"  CssClass="btn btn-primary  btn-sm" meta:resourcekey="lnkEditarCarpetaResource1"></asp:HyperLink>
        </div>--%>
    


                  
<%--<asp:Image id="imagenClasificacion1" runat="server" Height="150px"  ImageUrl='<%# "~/sec/showfile.aspx?idClasificacion=" & Eval("idClasificacion") & "&num=1" %>' />--%>


	







	<h4><asp:Label ID="Label1" runat="server" Text="Planteamiento breve" meta:resourcekey="Label1Resource1"></asp:Label></h4>
    <asp:Literal ID="literalPlanteamientoBreve" runat="server" text='<%#Eval("PlanteamientoBreve").Replace(vbCr, "<br/>") %>'></asp:Literal>
    <div style="height:10px;"></div>

   

    <h4><asp:Label ID="Label2" runat="server" Text="Descripcion" meta:resourcekey="Label2Resource1"></asp:Label></h4>
	<asp:Literal ID="literalTexto" runat="server" text='<%# Replace(Eval("texto"), vbCr, "<br>") %>'></asp:Literal>
    <div style="height:10px;"></div>

     <h4><asp:Label ID="Label10" runat="server" Text="Día de presentación" meta:resourcekey="Label10Resource1"></asp:Label></h4>
	<asp:Literal ID="literalDia" runat="server"  text='<%#Eval("diaDisplay") %>'></asp:Literal>
    <div style="height:10px;"></div>



              </div>

        </div>


          <div class="panel">

                <div class="panel-heading">
                    <%-- <div class="panel-control">
                        <asp:HyperLink ID="lnkAgregarObjetivo" runat="server" Text="Agregar objetivo"  CssClass="btn  btn-success btn-sm" meta:resourcekey="lnkAgregarObjetivoResource1"></asp:HyperLink>
                      </div>--%>
                    <h3 class="panel-title"><asp:Label ID="Label5" runat="server" Text="Objetivos y competencias" meta:resourcekey="Label5Resource1"></asp:Label></h3>
                   
                </div>
              <div class="panel-body">
                  <asp:Repeater ID="rptObjetivos" runat="server" DataSource='<%# getObjetivos(CInt(Eval("idClasificacion"))) %>'>
      
                     <ItemTemplate>
            
                        <h4><asp:Label ID="Label4" runat="server" Text="Objetivo" meta:resourcekey="Label4Resource1"></asp:Label></h4>
                        <asp:Label ID="lblObjetivo" runat="server" Text='<%# getObjetivo(Eval("Objetivo"))%>' ></asp:Label>
                        <div style="height:10px;"></div>
                       <%-- <h4><asp:Label ID="Label6" runat="server" Text="De habilidad" meta:resourcekey="Label6Resource1"></asp:Label></h4>
                        <asp:Label ID="Label7" runat="server" Text='<%# getObjetivo(Eval("Habilidad")) %>' ></asp:Label>
                        <div style="height:10px;"></div>
                        <h4><asp:Label ID="Label8" runat="server" Text="De actitud" meta:resourcekey="Label8Resource1"></asp:Label></h4>
                        <asp:Label ID="Label9" runat="server" Text='<%# getObjetivo(Eval("aptitud")) %>' ></asp:Label>
                        <div style="height:10px;"></div>--%>



                 <%--   <div class="text-right">
                        <asp:HyperLink ID="lnkEditar" runat="server" CssClass="btn btn-primary btn-sm" Text="Editar" NavigateUrl='<%# "addObjetivo.aspx?idObjetivo=" & Eval("idObjetivo") & "&idRoot=" & Request("idRoot") & "&idClasificacion=" & Eval("idClasificacion") & "&idSalonVirtual=" & Request("idSalonVirtual") %>' meta:resourcekey="lnkEditarResource1"></asp:HyperLink>
                    </div>--%>
                 
                     </ItemTemplate>
       
                </asp:Repeater>
              </div>
        </div>



                </div>
               
            </div>


            
            <div style="height:5px;"></div>
          
            <asp:DataList ID="dtlContenidos" runat="server" Width="100%" DataSource='<%# getContenidos(CInt(Eval("idClasificacion")))%>'>
               <ItemTemplate>
                   

                                <uc1:DisplayVerActividad ID="DisplayVerActividad1" runat="server" claveContenido='<%# Eval("idProc")%>'  tipoContenido='<%# Eval("Procedencia")%>'/>
                                <uc2:DisplayVerArchivo ID="DisplayVerArchivo1" runat="server"  claveContenido='<%# Eval("idProc")%>'  tipoContenido='<%# Eval("Procedencia")%>'/>
                                <uc3:DisplayVerFlash ID="DisplayVerFlash1" runat="server"  claveContenido='<%# Eval("idProc")%>'  tipoContenido='<%# Eval("Procedencia")%>'/>
                               
                                <uc5:DisplayVerImagen ID="DisplayVerImagen1" runat="server"  claveContenido='<%# Eval("idProc")%>'  tipoContenido='<%# Eval("Procedencia")%>'/>
                                <uc7:DisplayVerExamen ID="DisplayVerExamen1" runat="server"  claveContenido='<%# Eval("idProc")%>'  tipoContenido='<%# Eval("Procedencia")%>'/>
                                <uc4:DisplayVerForo ID="DisplayVerForo1" runat="server"  claveContenido='<%# Eval("idProc")%>'  tipoContenido='<%# Eval("Procedencia")%>'/>
                                <uc6:DisplayVerTexto ID="DisplayVerTexto1" runat="server"  claveContenido='<%# Eval("idProc")%>'  tipoContenido='<%# Eval("Procedencia")%>'/>
                       
                    
                </ItemTemplate>
            </asp:DataList>
            <div style="height:20px"></div>         
        </ItemTemplate>
        <ItemStyle Width="100%" />
    </asp:DataList>



</asp:Content>

