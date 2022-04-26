<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="verForo.aspx.vb" Inherits="Sec_SalonVirtual_verForo" title="Untitled Page" ValidateRequest="false"%>

<%@ Register src="~/Sec/Workbook/Controles/showadjuntos.ascx" tagname="showadjuntos" tagprefix="uc2" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="Controles/IndiceContenido.ascx" tagname="IndiceContenido" tagprefix="uc4" %>


<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>



<%@ Register src="Controles/displayBuscadores.ascx" tagname="displayBuscadores" tagprefix="uc1" %>



<%@ Register src="Controles/DisplayEstadisticasCotenidos.ascx" tagname="DisplayEstadisticasCotenidos" tagprefix="uc3" %>



<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server" Text="Foros"  ></asp:Label></h1>
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
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Editar apunte" ></asp:Label></li>
    </ol>


   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">
   
     <uc22:MenuGeneral ID="MenuGeneral1" runat="server" />

</asp:Content>




<asp:Content ID="contentCentral" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

	  <div class="row">

       <div class="col-md-3 hidden-sm hidden-xs"> 
             
        
            <uc4:IndiceContenido ID="IndiceContenido1" runat="server" />
        </div>
         <div class="col-md-9 col-sm-12 col-xs-12">

               <div class="row">
                 <div class="col-xs-8">

                       <div class="panel">
                            <div class="panel-heading">

                                   <div ID="panelEdicion" class="panel-control" runat="server" Visible="false" style="text-align:right">
					                 <asp:HyperLink ID="lnkEdicionContenido" runat="server" CssClass="btn btn-primary btn-sm">Editar texto</asp:HyperLink>
				                 </div>


                                    <h3 class="panel-title">
                                        <asp:Label ID="lblTitulo" runat="server"></asp:Label>
                                    </h3>
                            </div>
                            <div class="panel-body divPanelLink">


		<%--	<div class="titulo">
				<br /><br />
				<asp:Label ID="lblTitulo" runat="server" CssClass="title-big"></asp:Label>
			</div>--%>

                                <asp:Label ID="lblClasificacion" runat="server"></asp:Label>


                                 <p>
							<span class="seccion"><b>OBJETIVO</b></span><br />
							<asp:Label ID="lblObjetivo" runat="server" Text="---"></asp:Label>
						</p>


                        <p>
							<asp:Label ID="lblFecha" runat="server" Visible="false" CssClass="texto11"></asp:Label><br />
						<asp:Literal ID="littexto" runat="server"></asp:Literal>
							
						</p>



	
						
                            </div>

                        </div>

						
                    



<script type="text/javascript">



    // Your favorite JavaScript library probably has these utility functions.
    // Feel free to use them. I'm including them here so this example will
    // be library-agnostic.
    function collectionToArray(col) {
        var x, output = [];
        for (x = 0; x < col.length; x += 1) {
            output[x] = col[x];
        }
        return output;
    }

    // Another utility function probably covered by your favorite library.
    function trimString(s) {
        return s.replace(/^\s\s*/, '').replace(/\s\s*$/, '');
    }

    function filterHTML() {
        var iframe = your.rich.text.editor.getIframe(),
            win = iframe.contentWindow,
            doc = win.document,
            invalidClass = /(?:^| )msonormal(?:$| )/gi,
            cursor, nodes = [];

        // This is a depth-first, pre-order search of the document's body.
        // While searching, we want to remove invalid elements and comments.
        // We also want to remove invalid classNames.
        // We also want to remove font elements, but preserve their contents.

        nodes = collectionToArray(doc.body.childNodes);
        while (nodes.length) {
            cursor = nodes.shift();
            switch (cursor.nodeName.toLowerCase()) {

                // Remove these invalid elements.
                case 'meta':
                case 'link':
                case 'style':
                case 'o:p':
                case 'shapetype':
                case 'shape':
                case '#comment':
                    cursor.parentNode.removeChild(cursor);
                    break;

                    // Remove font elements but preserve their contents.
                case 'font':

                    // Make sure we scan these child nodes too!
                    nodes.unshift.apply(
                        nodes,
                        collectionToArray(cursor.childNodes)
                    );

                    while (cursor.lastChild) {
                        if (cursor.nextSibling) {
                            cursor.parentNode.insertBefore(
                                cursor.lastChild,
                                cursor.nextSibling
                            );
                        } else {
                            cursor.parentNode.appendChild(cursor.lastChild);
                        }
                    }

                    break;

                default:
                    if (cursor.nodeType === 1) {

                        // Remove all inline styles
                        cursor.removeAttribute('style');

                        // OR: remove a specific inline style
                        cursor.style.fontFamily = '';

                        // Remove invalid class names.
                        invalidClass.lastIndex = 0;
                        if (
                            cursor.className &&
                                invalidClass.test(cursor.className)
                        ) {

                            cursor.className = trimString(
                                cursor.className.replace(invalidClass, '')
                            );

                            if (cursor.className === '') {
                                cursor.removeAttribute('class');
                            }
                        }

                        // Also scan child nodes of this node.
                        nodes.unshift.apply(
                            nodes,
                            collectionToArray(cursor.childNodes)
                        );
                    }
            }
        }
    }
</script>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
                      
                       <div class="panel">
                            <div class="panel-heading">

                                 


                                    <h3 class="panel-title">
                                        <asp:Label ID="lblTituloComentario" runat="server" text="Agregar comentario"></asp:Label>
                                    </h3>
                            </div>
                            <div class="panel-body">

                                
  <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <div style="text-align: left">
                <asp:Image runat="server" ID="Image1" ImageUrl="~/Images/indicator.gif" ></asp:Image>
                <asp:Label runat="server" Text="Actualizando datos..." ID="lblProgress" ></asp:Label>
            </div>

        </ProgressTemplate>
    </asp:UpdateProgress>


         <asp:RequiredFieldValidator 
                ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtmensaje">*</asp:RequiredFieldValidator>
            <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" 
                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
            </cc1:ValidatorCalloutExtender>
            <div style="height:15px;"></div>
            <asp:TextBox ID="txtMensaje" runat="server" Height="106px" Width="98%" TextMode="MultiLine" CssClass="form-control" ></asp:TextBox>
                               <%--     <cc1:HtmlEditorExtender ID="txtMensaje_HtmlEditorExtender" runat="server" Enabled="True" TargetControlID="txtMensaje" DisplaySourceTab="True">
                                        <Toolbar> 
                                            <cc1:Bold />
                                            <cc1:Italic />
                                            <cc1:Underline />
                                            <cc1:HorizontalSeparator />
                                            <cc1:JustifyLeft />
                                            <cc1:JustifyCenter />
                                            <cc1:JustifyRight />
                                            <cc1:JustifyFull />
                                            <cc1:CreateLink />
                                            <cc1:UnLink />
                                            <cc1:Cut />
                                            <cc1:Copy />
                                            <cc1:Paste />
                                            
                                         
                                        </Toolbar>
                                    </cc1:HtmlEditorExtender>--%>
            <div style="height:15px;"></div>



            <script type="text/javascript">


        
                //win = iframe.contentWindow,
                //doc = win.document,
                //body = doc.body;

                // Use your favorite library to attach events. Don't actually do this
                // yourself. But if you did do it yourself, this is how it would be done.

               

                if (window.addEventListener) {
                    $("#ctl00_contentPlaceWorkArea_txtMensaje_HtmlEditorExtender_ExtenderContentEditable").bind("paste", function () { handlePaste(); });//.addEventListener('paste', handlePaste, false);
                } else {
                    //document.getElementById("ctl00_contentPlaceWorkArea_txtMensaje_HtmlEditorExtender_ExtenderContentEditable").attachEvent("onpaste", handlePaste);
                }


                function handlePaste() {
                    window.setTimeout(filterHTML, 50);
                }
            </script>


            
                <asp:Label ID="lblfile" runat="server" Font-Bold="true" Text="Adjuntar archivo" ></asp:Label>
                <div style="height:5px;"></div>
                <asp:FileUpload ID="FileUpload1" runat="server" />
              <div style="height:15px;"></div>

            <asp:Button ID="btngrabar" runat="server" Text="Grabar"  CssClass="btn btn-success btn-sm" />
            <cc1:ConfirmButtonExtender ID="btngrabar_ConfirmButtonExtender" runat="server" 
                ConfirmText="¿Deseas agregar el comentario al foro?" Enabled="True" 
                TargetControlID="btngrabar">
            </cc1:ConfirmButtonExtender>
            <br />
            <br />
         
	
						
                            </div>

                        </div>		




       
    



 

              
                       <div class="panel">
                            <div class="panel-heading">

                                 


                                    <h3 class="panel-title">
                                        <asp:Label ID="lblTituloComentariossss" runat="server" Text="Comentarios del foro"></asp:Label>
                                    </h3>
                            </div>
                            <div class="panel-body">

    





              
 <asp:DataList id="DataList1" runat="server" Width="100%">

	<ItemTemplate>

        <div class="media">
            <div class="media-left">
<asp:Image id="imgAlumno" runat="server"  Width="50px" Height="50px" ImageUrl='<%# getImagen(Eval("imagen"), Eval("claveAux1"), Eval("claveAux2"), CInt(Eval("idUserProfile"))) %>' />
            </div>
            <div class="media-body">
                <asp:Label ID="Label6" runat="server" Text="Comentario: " Font-Bold="true"></asp:Label>
                <asp:Label id="lbltexto" runat="server"    Text='<%# DataBinder.Eval(Container.DataItem, "Texto") %>'></asp:Label>
                <div style="height:4px;"></div>
                <asp:HyperLink ID="HyperLink1" runat="server"   NavigateUrl='<%# "~/sec/showfile.aspx?idForoSalonVirtual=" & Eval("idForoSalonVirtual") %>'   Visible='<%# presentarImagen(Eval("nombreOriginal")) %>' Font-Size="9px"  Text='<%# "Descargar: " & Eval("nombreOriginal") %>' Target="_blank"  >
                </asp:HyperLink>
                   <asp:Label id="lblUsuario" runat="server" Font-Italic="true" Font-Size="10px" Text='<%# DataBinder.Eval(Container.DataItem, "nombreUsuario") %>' ></asp:Label> - 
                   <asp:Label id="lblfecha" runat="server" Font-Italic="true" Font-Size="10px" Text='<%# DataBinder.Eval(Container.DataItem, "fechaCreacion") %>' ></asp:Label>
                 <asp:HyperLink ID="lnkResponder" runat="server"   NavigateUrl='<%# "~/sec/SalonVirtual/verForo.aspx?idSalonVirtual=" & Eval("idSalonVirtual") & "&idCI=" & idCI & "&idRaiz=" & Eval("idForoSalonVirtual") %>'   CssClass="btn-link"   Text="Responder"  >
                </asp:HyperLink>
                <asp:DataList id="dtlrespuestas" DataSource='<%# getForoRaiz(Eval("idForo"), Eval("idSalonVirtual"), Eval("idForoSalonVirtual")) %>' runat="server" Width="100%">

	                <ItemTemplate>

                        <div class="media">
                            <div class="media-left">
                <asp:Image id="imgAlumno" runat="server"  Width="50px" Height="50px" ImageUrl='<%# getImagen(Eval("imagen"), Eval("claveAux1"), Eval("claveAux2"), CInt(Eval("idUserProfile"))) %>' />
                            </div>
                            <div class="media-body">
                                <asp:Label ID="Label6" runat="server" Text="Comentario: " Font-Bold="true"></asp:Label>
                                <asp:Label id="lbltexto" runat="server"    Text='<%# DataBinder.Eval(Container.DataItem, "Texto") %>'></asp:Label>
                                <div style="height:4px;"></div>
                                <asp:HyperLink ID="HyperLink1" runat="server"   NavigateUrl='<%# "~/sec/showfile.aspx?idForoSalonVirtual=" & Eval("idForoSalonVirtual") %>'   Visible='<%# presentarImagen(Eval("nombreOriginal")) %>' Font-Size="9px"  Text='<%# "Descargar: " & Eval("nombreOriginal") %>' Target="_blank"  >
                                </asp:HyperLink>
                                   <asp:Label id="lblUsuario" runat="server" Font-Italic="true" Font-Size="10px" Text='<%# DataBinder.Eval(Container.DataItem, "nombreUsuario") %>' ></asp:Label> - 
                                   <asp:Label id="lblfecha" runat="server" Font-Italic="true" Font-Size="10px" Text='<%# DataBinder.Eval(Container.DataItem, "fechaCreacion") %>' ></asp:Label>
                         <asp:HyperLink ID="lnkResponder" runat="server"   NavigateUrl='<%# "~/sec/SalonVirtual/verForo.aspx?idSalonVirtual=" & Eval("idSalonVirtual") & "&idCI=" & idCI & "&idRaiz=" & Eval("idRaiz") %>'   CssClass="btn-link"   Text="Responder"  >
                        </asp:HyperLink>
                            </div>
                        </div>  

		
                         <div style="height:10px;"></div>	
	                </ItemTemplate>

                </asp:DataList>

               
            </div>
        </div>  

		
         <div style="height:10px;"></div>	
	</ItemTemplate>

</asp:DataList>



      


      




 
                 </div>

                            </ContentTemplate>
        <Triggers>
                    <asp:PostBackTrigger ControlID="btngrabar" />
                  </Triggers>
    </asp:UpdatePanel>






                    
                       




                           </div>

               
 <uc3:DisplayEstadisticasCotenidos ID="DisplayEstadisticasCotenidos1" runat="server" />


      

   </div>

             <div class="col-xs-4">

                 <div class="hidden-lg hidden-md">
                           <uc4:IndiceContenido ID="IndiceContenido2" runat="server" />
                      </div>

                   	<div class="panel">
                        <div class="panel-heading">
                                <h3 class="panel-title"><asp:Label ID="Label7" runat="server" Text="Adjuntos"></asp:Label></h3>
                        </div>
                        <div class="panel-body">
                            <asp:HyperLink ID="lnkBiblioteca" runat="server" NavigateUrl="~/Sec/Biblioteca.aspx" CssClass="btn-link" >Biblioteca digital</asp:HyperLink>
                            <div style="height:10px;"></div>

                            <uc2:showadjuntos ID="showContenidos" runat="server" />
                            <uc2:showadjuntos ID="showArchivosAdjuntos" runat="server" />
					        <uc2:showadjuntos ID="showDirecciones" runat="server" />
					        <uc2:showadjuntos ID="showImagenesAdjuntos" runat="server" />
					        <uc2:showadjuntos ID="showFlashes" runat="server" />


                        </div>
                    </div>



                    <uc1:displayBuscadores ID="displayBuscadores1" runat="server" />
                   

                </div>
   




</div>


          </div>


<asp:Label ID="labelCursosComoDocente" runat="server" Text="Cursos como docente" Visible="false"></asp:Label>
<asp:Label ID="labelCursosComoAlumno" runat="server" Text="Cursos como alumno"  Visible="false"></asp:Label>
    


            
</asp:Content>