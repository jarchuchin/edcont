<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="BuscarSalones.aspx.vb" Inherits="Sec_BuscarSalones" title="Buscar cursos" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc1" %>

<%@ Register src="Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc2" %>



<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="Label1" runat="server" Text="Buscar cursos para inscribirme"></asp:Label></h1>

       
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelBreadcrumb" Runat="Server">
 
<ol class="breadcrumb"  >
  <li >
      <asp:Label ID="Label2" runat="server" Text="Incripción al curso"></asp:Label></li>
</ol>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">




    
<div class="row">
	<div class="col-sm-12 ">
		<div class="panel">
			<div class="panel-heading">
                <h3 class="panel-title"> <asp:Label ID="Label3" runat="server" Text="Buscar curso" ></asp:Label></h3>

            </div>
             <div class="panel-body">






  
   <asp:UpdateProgress id="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                    <ProgressTemplate>
                        <div align="left" > <asp:Image ID="Image1" runat="server"  ImageUrl ="~/Images/indicator.gif" />
                            &nbsp;<asp:Label ID="lbltexto" runat="server"   Text="Ordenando datos..." ></asp:Label></div>
                    </ProgressTemplate>
       </asp:UpdateProgress>
       <asp:UpdatePanel id="UpdatePanel2" runat="server" >
               <ContentTemplate>

<div class="form-inline">

<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBuscar"  Display="Dynamic">*</asp:RequiredFieldValidator>
    <br />
<asp:TextBox ID="txtBuscar" CssClass="form-control"  runat="server" Width="300px" placeholder="Palabra o nombre de la materia"></asp:TextBox>  
    &nbsp;<asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-primary" Text="Buscar"></asp:Button><br />

    <br />
</div>



            <asp:GridView id="gvSalones" runat="server" CssClass="table table-stripped table-hover"  AllowSorting="True" Width="100%" 
                AutoGenerateColumns="False" GridLines="None">
                <Columns>
                
                <asp:BoundField DataField="FechaInicio"  HeaderText="Inicia" SortExpression="FechaInicio"  htmlencode="false" DataFormatString="{0:yyyy, dd MMM}"  >
                    <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" Width="120px" />
                 </asp:BoundField>


                      <asp:HyperLinkField DataNavigateUrlFields="idSalonVirtual" SortExpression="Nombre"  HeaderText=" " Text="Incribirme"  ControlStyle-CssClass="btn btn-sm btn-success"
                       DataNavigateUrlFormatString="~/sec/SolicitarIngreso.aspx?idSalonVirtual={0}" > 
                       <HeaderStyle  HorizontalAlign="Left"  Width="120px"/>
                 </asp:HyperLinkField>
                
               <asp:HyperLinkField DataNavigateUrlFields="idSalonVirtual" SortExpression="Nombre"  DataTextField="Nombre" HeaderText="Nombre"  ControlStyle-CssClass="link"
                       DataNavigateUrlFormatString="~/sec/SolicitarIngreso.aspx?idSalonVirtual={0}" > 
                       <HeaderStyle  HorizontalAlign="Left" />
                 </asp:HyperLinkField>
                    
                <asp:BoundField DataField="ClaveAux1"  HeaderText="Clave" 
                        SortExpression="ClaveAux1" > 
                    <ItemStyle HorizontalAlign="Left"  Width="80px" />
                    </asp:BoundField>
                    
              
                        
                </Columns>
                <HeaderStyle Font-Bold="True" ForeColor="Black" horizontalalign="center" 
                    BackColor="White"/>
                <AlternatingRowStyle BackColor="White" />
                
            </asp:GridView>

        
            </ContentTemplate>
        </asp:UpdatePanel>
    
    

       






                 </div>

            </div>
        </div>
    </div>
    
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">



     <uc2:MenuGeneral ID="MenuGeneral1" runat="server" />



</asp:Content>


