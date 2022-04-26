<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MisSalonVirtualesAlumno.ascx.vb" Inherits="Sec_SalonVirtual_Controles_MisSalonVirtualesAlumno" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>




       <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional" >
               <ContentTemplate>


                   
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


                     <asp:LinkButton ID="lnkTodos" runat="server" CausesValidation="false" CssClass="btn btn-primary btn-sm"  >Ver todos</asp:LinkButton>

                     <asp:HyperLink ID="HyperLink1" CssClass="btn btn-warning btn-sm" NavigateUrl="~/sec/buscarSalones.aspx" runat="server">Incribirme a cursos</asp:HyperLink>

            	 </div>


                <h3 class="panel-title"> <asp:Label ID="Label2" runat="server" Text="Cursos como alumno"></asp:Label></h3>

            </div>
             <div class="panel-body">
     

            <asp:GridView id="gvMisSalones" runat="server" AllowSorting="False" Width="100%"  CssClass="table table-striped table-hover"
                AutoGenerateColumns="False" GridLines="None">
                <Columns>
                

                    <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Image runat="server" ID="flechita" ImageUrl="~/images/bull-arrow1.png" />
                    </ItemTemplate>
                    <HeaderStyle Width="15px"  />

                </asp:TemplateField>
                

               <asp:BoundField DataField="FechaInicioSV"  HeaderText="Inicia" SortExpression="FechaInicioSV"  htmlencode="false" DataFormatString="{0:d}"  >
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                            <HeaderStyle  CssClass="text-center"  Font-Bold="true" />
                 </asp:BoundField>   
              
                 
               <asp:BoundField DataField="FechaFinSV"  HeaderText="Termina" SortExpression="FechaFinSV"  htmlencode="false" DataFormatString="{0:d}"  >
                            <ItemStyle HorizontalAlign="Center" Width="70px" />
                            <HeaderStyle  CssClass="text-center"  Font-Bold="true" />
                 </asp:BoundField>  
                    
                    
             
                 <asp:BoundField DataField="ClaveAux1"  HeaderText="Clave" 
                        SortExpression="ClaveAux1" > 
                        <HeaderStyle CssClass="text-center"  Font-Bold="true" />
                    <ItemStyle Width="95px" HorizontalAlign="Center" />
                  </asp:BoundField>
               <asp:HyperLinkField DataNavigateUrlFields="idSalonVirtual" SortExpression="Nombre"  DataTextField="Nombre" HeaderText="Nombre"   ControlStyle-CssClass="btn-link"
                       DataNavigateUrlFormatString="~/sec/SalonVirtual/default.aspx?idSalonVirtual={0}" > 
                       <HeaderStyle  HorizontalAlign="Left" Font-Bold="true" />
                       <ItemStyle HorizontalAlign="Left" />
                 </asp:HyperLinkField>
              

                       <asp:BoundField DataField="CalificacionComputada"  HeaderText="Alcanzado" 
                        SortExpression="CalificacionComputada" > 
                        <HeaderStyle CssClass="text-center"  Font-Bold="true" />
                    <ItemStyle Width="95px" cssClass="text-center" />
                  </asp:BoundField>

                   
                        
                </Columns>
               
                
            </asp:GridView>

           

        <asp:HiddenField ID="hdUsuario" runat="server" />
        <asp:HiddenField id="hdStatus" runat="server" />
        <asp:HiddenField id="hdCantidad" runat="server" />



                    </div>

        </div>



        
            </ContentTemplate>
        </asp:UpdatePanel>
    