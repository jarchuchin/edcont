<%@ Control Language="VB" AutoEventWireup="false" CodeFile="displayEstadisticasSalon.ascx.vb" Inherits="Sec_SalonVirtual_Controles_displayEstadisticasSalon" %>

<!--Tiles - Bright Version-->
<!--===================================================-->
<div class="row">

    <div class="eq-height">

        <div class="col-sm-6 col-lg-4 eq-box-lg">
			<div class="panel">
				<div class="panel-heading">
					<h3 class="panel-title">% actividades enviadas</h3>
				</div>
				<div class="panel-body text-center">
					
					<!--Easy Pie Chart-->
					<!--===================================================-->
					<div id="demo-pie-1" class="pie-title-center mar-rgt"  data-percent='<%= IndiceActividadesEnviadas %>' >
						<span class="pie-value text-thin"></span>
					</div>
					<!--===================================================-->
					<!-- End Easy Pie Chart -->
					
				</div>
			</div>
		</div>


           <div class="col-sm-6 col-lg-4 eq-box-lg">
			<div class="panel">
				<div class="panel-heading">
					<h3 class="panel-title">% de calificación en actividades</h3>
				</div>
				<div class="panel-body text-center">
					
					<!--Easy Pie Chart-->
					<!--===================================================-->
					<div id="demo-pie-2" class="pie-title-center mar-rgt"   data-percent='<%= PromedioActividades %>' >
						<span class="pie-value text-thin"></span>
					</div>
					<!--===================================================-->
					<!-- End Easy Pie Chart -->
					
				</div>
			</div>
		</div>


           <div class="col-sm-6 col-lg-4 eq-box-lg">
			<div class="panel">
				<div class="panel-heading">
					<h3 class="panel-title">% general de alumnos</h3>
				</div>
				<div class="panel-body text-center">
					
					<!--Easy Pie Chart-->
					<!--===================================================-->
					<div id="demo-pie-3" class="pie-title-center mar-rgt"   data-percent='<%= PromedioComputada %>' >
						<span class="pie-value text-thin"></span>
					</div>
					<!--===================================================-->
					<!-- End Easy Pie Chart -->
					Calificación de 
				</div>
			</div>
		</div>

    </div>

	<%--<div class="col-sm-6 col-lg-">
         <div class="panel">
            <div class="panel-heading">
                <h3 class="panel-title"> <asp:Label ID="Label2" runat="server" Text="Promedio avance "></asp:Label></h3>

            </div>
             <div class="panel-body">



                <!--Morris DOna placeholder-->
		        <!-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ -->
		        <div id="graficaSeguimientoAvance-morris-area" style="height:212px"></div>
		        <!-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ -->



               
             </div>

        </div>
    </div>
    <div class="col-sm-6 col-lg-">

    </div>--%>
</div>

<div class="row">

   <div class="col-lg-12">

        <div class="panel">
            <div class="panel-heading">
                <h3 class="panel-title"> <asp:Label ID="Label1" runat="server" Text="Gráfica de seguimiento de curso "></asp:Label></h3>

            </div>
             <div class="panel-body">



                <!--Morris Area Chart placeholder-->
		        <!-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ -->
		        <div id="graficaSeguimientoSalon-morris-area" style="height:212px"></div>
		        <!-- ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ -->


                <asp:Literal ID="litScript" runat="server"></asp:Literal>



                Gráfica de seguimiento semanal de actividaes enviadas por alumnos
            </div>
        </div>



       


<div class="panel">
                <div class="panel-heading">
                    <div class="panel-control" style="text-align:right">
             
                  <asp:HyperLink ID="lnkDescargar" runat="server" CssClass="btn btn-primary btn-sm" Text="Descargar en excel" ></asp:HyperLink>

                      </div>

                        <h3 class="panel-title"><asp:Label ID="lblCalendario" runat="server" Text="Seguimiento de alumnos"></asp:Label> </h3>
                </div>
                <div class="panel-body">

    
                    


                    <asp:Panel ID="panelDatos" ScrollBars="Horizontal" runat="server" >
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped table-bordered" GridLines="None"  Width="10000px" AutoGenerateColumns="false" >

                            <Columns>

                                 <asp:TemplateField  HeaderText="#">
                                    <ItemTemplate >
                                        <asp:Label ID="lblNumeros" runat="server" Text='<%# numero %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10px" CssClass="text-center" />
                                    <ItemStyle HorizontalAlign="Center" Width="30px" CssClass="text-center" />
                                </asp:TemplateField>


                                 <asp:TemplateField HeaderText="Nombre del alumno" SortExpression="Nombre">
                                    <ItemTemplate >
                                      

                                           <asp:HyperLink ID="lnknombreloc" runat="server" 
                                            NavigateUrl='<%# Eval("idSalonVirtual", "~/sec/SalonVirtual/ListaSeguimientoAlumno.aspx?idSalonVirtual={0}") & Eval("idUserProfile", "&idUserProfile={0}") %>' 
                                             CssClass="btn-link"
                                              ToolTip="Clic para ver los detalles de evaluación"
                                            Text='<%# eval("Nombre") %>'></asp:HyperLink>

                                          <asp:Image runat="server" ID="imgtransp" ImageUrl="~/images/transp.gif" Height="1px" Width="180px" />
                                    </ItemTemplate>
                                     <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="180px"  />
                                 </asp:TemplateField> 

                                  <asp:boundfield DataField="claveAux1" HeaderText="Matrícula" 
                                   HtmlEncode="False" SortExpression="claveAux1"><HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center"  Width="50px" /></asp:boundfield>
                                   
                           

                            </Columns>

                        </asp:GridView>
                        <div style="height:10px;"></div>
                    </asp:Panel>

                </div>

                </div>

    </div>


</div>