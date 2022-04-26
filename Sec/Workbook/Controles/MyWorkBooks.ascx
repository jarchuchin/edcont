<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MyWorkBooks.ascx.vb" Inherits="Sec_Workbook_Controles_MyWorkBooks" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<div class="panel">
			<div class="panel-heading">

           <div ID="panelEdicion" class="panel-control form-inline" runat="server" style="text-align:right">


                <div class="form-group">
                                  <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control" Width="250px" placeHolder="Buscar libros" meta:resourcekey="txtBuscarResource1"></asp:TextBox>
                                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar"  CssClass="btn btn-success btn-sm" meta:resourcekey="btnBuscarResource1" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBuscar"  ErrorMessage="Debe llenar la caja de texto para buscar" meta:resourcekey="RequiredFieldValidator1Resource1">*</asp:RequiredFieldValidator>
                                            <cc1:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender"  runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
                                            </cc1:ValidatorCalloutExtender>
                             </div>


                 <asp:LinkButton ID="lnknuevobook" CssClass="btn btn-primary btn-sm" runat="server" meta:resourcekey="lnknuevobookResource1" CausesValidation="false">Crear libro</asp:LinkButton>


            	 </div>

                <h3 class="panel-title"> <asp:Label ID="Label2" runat="server" Text="Libros de trabajo"></asp:Label></h3>

            </div>
             <div class="panel-body">
     

   <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <div class="text-left" > <asp:Image ID="Image1" runat="server"  ImageUrl ="~/Images/indicator.gif" meta:resourcekey="Image1Resource1" />
                            &nbsp;<asp:Label ID="lbltexto" runat="server"   Text="Ordenando datos..." meta:resourcekey="lbltextoResource1"  ></asp:Label></div>
                    </ProgressTemplate>
       </asp:UpdateProgress>
       <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional" >
               <ContentTemplate>
          

            <asp:GridView id="gvRoots" runat="server" Width="100%"   CssClass="table  table-striped table-hover"
                AutoGenerateColumns="False" GridLines="None" meta:resourcekey="gvRootsResource1">
                <Columns>
                
               <asp:HyperLinkField DataNavigateUrlFields="idRoot" SortExpression="Titulo"  DataTextField="Titulo" HeaderText="Título"  ControlStyle-CssClass="btn-link"
                       DataNavigateUrlFormatString="~/sec/Workbook/home.aspx?idRoot={0}" meta:resourcekey="HyperLinkFieldResource1" > 
                 </asp:HyperLinkField>
                 
                
                  <asp:BoundField DataField="FechaCreacion"  HeaderText="Creado en" SortExpression="FechaCreacion"  htmlencode="False"  DataFormatString="{0:d}" meta:resourcekey="BoundFieldResource1"  >
                            <ItemStyle HorizontalAlign="Left" Width="100px"  />
                 </asp:BoundField> 
                   
                <asp:BoundField DataField="numeroCarpetas"  HeaderText="Carpetas" 
                        SortExpression="numeroCarpetas" meta:resourcekey="BoundFieldResource2" > 
                    <ItemStyle Width="80px"  HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center"  />
                    </asp:BoundField>
                    
                 <asp:BoundField DataField="numeroContenidos"  HeaderText="Contenidos" 
                        SortExpression="numeroContenidos" meta:resourcekey="BoundFieldResource3" > 
                    <ItemStyle Width="80px"  HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center"  />
                    </asp:BoundField>
                        
                        
                </Columns>
               
                
              
            </asp:GridView>


        
        <asp:HiddenField ID="hdUsuario" runat="server" />
        <asp:HiddenField id="hdStatus" runat="server" />
        
            </ContentTemplate>
        </asp:UpdatePanel>
    

                 
        </div>
    </div>

    <div style="height:50px;"></div>