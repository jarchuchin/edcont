<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayVerExamen.ascx.vb" Inherits="Sec_Workbook_Controles_DisplayVerExamen" %>


<%@ Register src="~/Sec/Workbook/Controles/showadjuntos.ascx" tagname="showadjuntos" tagprefix="uc2" %>



<asp:Panel ID="panelContenidos" runat="server" Visible="false">
   


    
         
<div class="row">
	<div class="col-xs-9">
		<div class="panel">

            <div class="panel-heading">
           
                 <h3 class="panel-title">
                       <asp:label ID="txtTitulo" runat="server"></asp:label>
                     </h3>
            </div>
			
             <div class="panel-body">



			

						<div class="cajaSubseccionCentral">
							<h5>Objetivos</h5>
							<asp:Literal ID="litObjetivo" runat="server"></asp:Literal>
						</div>

						<div class="cajaSubseccionCentral">
							<h5>Instrucciones</h5>
							<asp:Literal ID="litInstrucciones" runat="server"></asp:Literal>
						</div>

						
                 <h5>Preguntas existentes</h5>
						
                        <asp:DataGrid ID="dtgItem" runat="server" AutoGenerateColumns="False"  CssClass="table table-stripped" ShowHeader="false"  DataKeyField="idPregunta" GridLines="None" Width="100%">
				
							<headerstyle font-bold="True" horizontalalign="Left" />
							<columns>
								
								<asp:templatecolumn>
									<headerstyle width="30px" />
									<itemstyle horizontalalign="Center" verticalalign="Top" />
									<itemtemplate>
										<asp:HyperLink ID="Hyperlink12" runat="server" 
											ImageUrl='<%# "~/Images/" & getImagen(DataBinder.Eval(Container.DataItem, "tipoPregunta"))  %>' 
											NavigateUrl='<%#  GetLiga(cint(DataBinder.Eval(Container.DataItem, "idPregunta")), cint(DataBinder.Eval(Container.DataItem, "tipoPregunta"))  )%>'>
										</asp:HyperLink>
									</itemtemplate>
								</asp:templatecolumn>
								<asp:templatecolumn HeaderText="Preguntas existentes">
									<headerstyle horizontalalign="Left" />
									<itemstyle horizontalalign="Left" />
									<itemtemplate>
										<asp:HyperLink ID="lnkClasificacion" runat="server" 
											NavigateUrl='<%#  GetLiga(cint(DataBinder.Eval(Container.DataItem, "idPregunta")), cint(DataBinder.Eval(Container.DataItem, "tipoPregunta"))  )%>' 
											Text='<%# GetEnunciado(DataBinder.Eval(Container.DataItem, "enunciado"),  cint(DataBinder.Eval(Container.DataItem, "tipoPregunta")) ) %>'>
										</asp:HyperLink>
									</itemtemplate>
								</asp:templatecolumn>
								
							</columns>
						</asp:DataGrid>

        
                        
					  
			



                      </div>

            </div>

        </div>


        <div class="col-xs-3">

             <div class="panel">

                <div class="panel-heading">
           
                     <h3 class="panel-title">
                            <asp:label ID="Label1" runat="server">Responder actividad</asp:label>
                         </h3>
                </div>
			
                 <div class="panel-body">
                     	<asp:Button ID="btnEnviarTarea"  runat="server" Text="Responder actividad" CssClass="btn btn-primary btn-sm form-control"  />
							<div style="height:5px"></div>
							<asp:Button ID="btnVerRespuestas" runat="server" Text="Ver respuestas" CssClass="btn btn-success btn-sm  form-control"  />
                 </div>
            </div>


   
							
				
					<uc2:showadjuntos ID="showArchivosAdjuntos" runat="server" />
					<uc2:showadjuntos ID="showDirecciones" runat="server" />
					<uc2:showadjuntos ID="showImagenesAdjuntos" runat="server" />
					<uc2:showadjuntos ID="showFlashes" runat="server" />





         <div class="panel">

                <div class="panel-heading">
           
                     <h3 class="panel-title">
                            <asp:label ID="Label3" runat="server">Biblioteca digital</asp:label>
                         </h3>
                </div>
			
                 <div class="panel-body">
                    
                 </div>
            </div>


					



        </div>
    </div>




    <div style="page-break-after: always"></div>
    </asp:Panel><asp:Label ID="lblpdesarrollo" runat="server" Text="Pregunta de desarrollo" Visible="False"></asp:Label>