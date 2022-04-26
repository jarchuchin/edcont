<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MisSalonesVirtualesInstructor.ascx.vb" Inherits="Sec_SalonVirtual_Controles_MisSalonesVirtuales" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


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

                <h3 class="panel-title"> <asp:Label ID="Label2" runat="server" Text="Cursos como docente"></asp:Label><asp:HyperLink ID="lnkvernuevo" runat="server" NavigateUrl="~/sec/defaultDocente2.aspx" Text="Vista nueva" CssClass="btn btn-warning btn-sm"></asp:HyperLink> </h3>

            </div>
             <div class="panel-body">
     


            <asp:GridView id="gvMisSalones" runat="server" AllowSorting="False" CssClass="table table-striped table-hover"  
                AutoGenerateColumns="False" GridLines="None">
                <Columns>


                       <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Image runat="server" ID="flechita" ImageUrl="~/images/bull-arrow1.png" />
                    </ItemTemplate>
                    <HeaderStyle Width="15px"  />

                </asp:TemplateField>


                       <asp:BoundField DataField="FechaInicio"  HeaderText="Inicia" SortExpression="FechaInicio"  htmlencode="false" DataFormatString="{0:d}"   >
                  <HeaderStyle  CssClass="text-center"  />
                            <ItemStyle HorizontalAlign="Center" Width="70px"  />
                 </asp:BoundField>
                 
                 <asp:BoundField DataField="ClaveAux1"  HeaderText="Clave" 
                        SortExpression="ClaveAux1" ItemStyle-CssClass="btn-link" > 
                     <HeaderStyle CssClass="text-center" />
                    <ItemStyle Width="95px" HorizontalAlign="Center" />
                    </asp:BoundField>
                
               <asp:HyperLinkField DataNavigateUrlFields="idSalonVirtual" SortExpression="Nombre"  DataTextField="Nombre" HeaderText="Nombre"  ControlStyle-CssClass="btn-link"
                       DataNavigateUrlFormatString="~/sec/SalonVirtual/default.aspx?idSalonVirtual={0}" > 
                      <ControlStyle CssClass="btn-link" />
                      <HeaderStyle  HorizontalAlign="Left"  />
                       <ItemStyle  HorizontalAlign="Left" />
                 </asp:HyperLinkField>
                    
                
                

                    
               <asp:HyperLinkField DataNavigateUrlFields="idSalonVirtual" SortExpression="numAlumnos"  DataTextField="numAlumnos" HeaderText="Alum." 
                       DataNavigateUrlFormatString="~/sec/SalonVirtual/ListaAlumnos.aspx?idSalonVirtual={0}"   > 
                       <HeaderStyle Width="40px" HorizontalAlign="Center"  />
                       <ItemStyle HorizontalAlign="Center" Width="40px" CssClass="btn-link"   />
                 </asp:HyperLinkField>
                        
                 <asp:HyperLinkField DataNavigateUrlFields="idSalonVirtual" SortExpression="ActividadeSinRevisar"  DataTextField="ActividadeSinRevisar" HeaderText="Act."
                       DataNavigateUrlFormatString="~/sec/SalonVirtual/TareasRecibidas.aspx?idSalonVirtual={0}"   > 
                        <ItemStyle Width="40px"  HorizontalAlign="Center"  CssClass="btn-link" />
                    <HeaderStyle HorizontalAlign="Center" />
                 </asp:HyperLinkField>
               
                        
                        
                </Columns>
        
                
            </asp:GridView>



              

        <asp:HiddenField ID="hdUsuario" runat="server" />
        <asp:HiddenField id="hdStatus" runat="server" />
        <asp:HiddenField id="hdCantidad" runat="server" />
        
       



        </div>
    </div>