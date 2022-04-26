<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="AddPRelacionColumnas.aspx.vb" Inherits="Sec_Workbook_AddPRelacionColumnas" title="Relacionar columnas" %>
 
<%@ Register src="~/Sec/workbook/Controles/Menu.ascx" tagname="Menu" tagprefix="uc5" %>
<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc2" %>


<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Literal ID="Literal1" runat="server" Text="Editar relacionar columnas" ></asp:Literal></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPanelBreadcrumb">
          <ol class="breadcrumb" >
  <li><asp:HyperLink ID="lnkSalirEdicion" runat="server" Text="Salir de edición" meta:resourcekey="lnkSalirEdicionResource1" ></asp:HyperLink>
      </li>
        </ol>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">

     <uc2:MenuGeneral ID="MenuGeneral1" runat="server" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">   

    
		<div class="panel">

              <div class="form-horizontal">

            <div class="panel-heading">
                  <h3 class="panel-title">
                         <asp:label id="lblTitulo" runat="server" Text="Relacionar columnas" ></asp:label>
                     </h3>
            </div>

              <div class="panel-body">



<div class="alert alert-danger" id="lblmensajeElementos" runat="server" visible="false">
  <span class="glyphicon glyphicon-saved"></span><strong>&nbsp; <asp:Label ID="Label11" runat="server" Text="Error!"></asp:Label>&nbsp;&nbsp; </strong> <asp:label id="lblMensajeBorrarinside" runat="server"  text=">Debes llenar todas las cajas de texto para iniciar la relación de columnas"></asp:label>
</div>
 <asp:validationsummary id="ValidationSummary2" runat="server" ForeColor="Red" headertext="Los campos marcados con * son requeridos o no estan en formato apropiado"  displaymode="List" CssClass="alert alert-danger"></asp:validationsummary>

    
      <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <div align="left" > <asp:Image ID="Image1" runat="server"  ImageUrl ="~/Images/indicator.gif" /><asp:Label ID="lbltexto" runat="server"   Text="Actualizando datos..." ></asp:Label></div>
                    </ProgressTemplate>
       </asp:UpdateProgress>
       <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional" >
               <ContentTemplate>
                  


 <div class="form-group">
    <label class="col-sm-2 control-label">
        <asp:Label ID="Label3" runat="server" Text="Examen"></asp:Label>
    </label>
    <div class="col-sm-10"> 
        <asp:Label ID="lblexamen" runat="server"></asp:Label>
    </div>
 </div>


    <div class="form-group">
    <label class="col-sm-2 control-label">
<asp:Label ID="lblPregunta" runat="server" text="Insstrucciones / descripción"></asp:Label>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtPregunta" Display="Dynamic">*</asp:RequiredFieldValidator>
    </label>
    <div class="col-sm-10"> 
 <asp:TextBox ID="txtPregunta" runat="server" Columns="60" Height="100px"  TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                               <asp:TextBox ID="txtid" runat="server" Visible="False"></asp:TextBox>
    </div>
    </div>


     <div class="form-group">
    <label class="col-sm-2 control-label">
             <asp:Label ID="lblRespuesta0" runat="server" text="Cargar imagen"></asp:Label>
                <asp:CustomValidator ID="CustomValidator1" runat="server" 
                    ControlToValidate="FileUpload1" ErrorMessage="Solo imágenes son permitidas">*</asp:CustomValidator>
    </label>
    <div class="col-sm-10"> 
<asp:FileUpload ID="FileUpload1" runat="server"   CssClass="form-control"/>
   <asp:HyperLink ID="imgPreguntalink" runat="server" Visible="true" Target="_blank">
        <asp:Image ID="imgPregunta" runat="server" Visible="False" Width="150px" />
    </asp:HyperLink>
    </div>
    </div>


  

                               <table id="Tablea4" style="width:100%;" >
                                   <tr>
                                       <td style="width:50%;">
                                           <asp:Label ID="lblOpciones0" runat="server" cssclass="panel-title" text="Elementos de columna 1"></asp:Label>
                                       </td>
                                       <td style="width:50%;">
                                           <asp:Label ID="lblOpciones" runat="server" cssclass="panel-title" text="Elementos de columna 2"></asp:Label>
                                       </td>
                                   </tr>
                                   <tr>
                                       <td style="width:50%;">
                                           <table id="Table8" border="0" cellpadding="1" cellspacing="1" width="100%">
                                               <tr>
                                                   <td  >
                                                       <asp:TextBox ID="txtOP" runat="server" Columns="35" CssClass="form-control"></asp:TextBox>
                                               
                                                   </td>
                                                   <td>
                                                       <asp:Button ID="btnAgregarOpcion0" runat="server" CssClass="btn btn-success" Text="&gt;&gt;&gt;" />
                                                   </td>
                                               </tr>
                                           </table>
                                       </td>
                                        <td style="width:50%;">
                                           <table id="Table6" border="0" cellpadding="1" cellspacing="1" width="100%">
                                               <tr>
                                                   <td>
                                                       <asp:TextBox ID="txtOR" runat="server" Columns="35"  CssClass="form-control"></asp:TextBox>
                                             
                                                   </td>
                                                   <td>
                                                       <asp:Button ID="btnAgregarOpcion" runat="server" CssClass="btn btn-success" Text="&gt;&gt;&gt;" />
                                                   </td>
                                               </tr>
                                           </table>
                                       </td>
                                   </tr>
                                   </table>

      <div style="height:15px;"></div>



                                   <table id="Tablesa4" style="width:100%;" >
                                   <tr>
                                       <td valign="top"  style="text-align:left; width:50%;">
                                           <asp:DataGrid ID="dtgItem0" runat="server" AutoGenerateColumns="False" 
                                               BackColor="White" BorderColor="#C1CDD8" DataKeyField="idOP" GridLines="None" 
                                               ShowHeader="False" Width="100%">
                                               <selecteditemstyle backcolor="#C1CDD8" />
                                               <headerstyle font-bold="True" horizontalalign="Left" />
                                               <columns>
                                                   
                                                   <asp:templatecolumn  >
                                                       <itemstyle horizontalalign="Right" />
                                                       <itemtemplate>
                                                 
                                                             <asp:TextBox ID="txtpreg0" runat="server" Columns="30"  Text='<%# DataBinder.Eval(Container.DataItem,"enunciado" ) %>' CssClass="form-control"> </asp:TextBox>
                                                                  
                                                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" 
                                                                           ControlToValidate="txtpreg0" Display="Dynamic">*</asp:RequiredFieldValidator>
                                                                  <div style="height:5px;"></div>
                                                       </itemtemplate>
                                                   </asp:templatecolumn>
                                                    <asp:templatecolumn>
                                                       <itemstyle  width="30px"  HorizontalAlign="Center" />
                                                       <itemtemplate><asp:ImageButton ID="Imagebutton1" runat="server" CommandName="Editar"  ImageUrl="~/Images/si.png" />
                                                        </itemtemplate>
                                                   </asp:templatecolumn>

                                                   <asp:templatecolumn>
                                                       <itemstyle  width="30px"  HorizontalAlign="Center" />
                                                       <itemtemplate>
                                                       
                                                            <asp:ImageButton ID="Imagebutton2" runat="server" CausesValidation="False"  CommandName="Borrar"  ImageUrl="~/Images/no.png" />
                                                                
                                                       </itemtemplate>
                                                   </asp:templatecolumn>
                                               </columns>
                                           </asp:DataGrid>
                                       </td>
                                         <td valign="top"  style="text-align:left; width:50%;">
                                           <asp:DataGrid ID="dtgItem" runat="server" AutoGenerateColumns="False" 
                                               BackColor="White" BorderColor="#C1CDD8" DataKeyField="idOR" GridLines="None" 
                                               ShowHeader="False" Width="100%">
                                               <selecteditemstyle backcolor="#C1CDD8" />
                                               <headerstyle font-bold="True" horizontalalign="Left" />
                                               <columns>
                                                  <asp:templatecolumn  >
                                                       <itemstyle horizontalalign="Right" />
                                                       <itemtemplate>
                                                 
                                                             <asp:TextBox ID="txtpreg" runat="server" Columns="30"  Text='<%# DataBinder.Eval(Container.DataItem, "enunciado") %>' CssClass="form-control"> </asp:TextBox>
                                                                  
                                                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" 
                                                                           ControlToValidate="txtpreg" Display="Dynamic">*</asp:RequiredFieldValidator>
                                                                  <div style="height:5px;"></div>
                                                       </itemtemplate>
                                                   </asp:templatecolumn>
                                                    <asp:templatecolumn>
                                                       <itemstyle  width="30px"  HorizontalAlign="Center" />
                                                       <itemtemplate><asp:ImageButton ID="Imagebuttodn1" runat="server" CommandName="Editar"  ImageUrl="~/Images/si.png" />
                                                        </itemtemplate>
                                                   </asp:templatecolumn>

                                                   <asp:templatecolumn>
                                                       <itemstyle  width="30px"  HorizontalAlign="Center" />
                                                       <itemtemplate>
                                                       
                                                            <asp:ImageButton ID="Imagebutton21" runat="server" CausesValidation="False"  CommandName="Borrar"  ImageUrl="~/Images/no.png" />
                                                                
                                                       </itemtemplate>
                                                   </asp:templatecolumn>
                                               </columns>
                                           </asp:DataGrid>
                                       </td>
                                   </tr>
                               </table>


          <div style="height:10px;"></div>
    <hr />
    <div style="height:10px;"></div>




                              
                                           <asp:DataGrid ID="dtgSeleccion" runat="server" AutoGenerateColumns="False" 
                                                DataKeyField="idOP"  CssClass="table table-condensed"
                                               GridLines="None" Width="100%">
                                               <selecteditemstyle backcolor="#C1CDD8" />
                                               <headerstyle font-bold="True" horizontalalign="Left" />
                                               <columns>
                                                   <asp:templatecolumn HeaderText=" ">
                                                       <headerstyle width="50%" />
                                                       <itemstyle horizontalalign="Left"  />
                                                       <itemtemplate>
                                                           <asp:Label ID="Label1" runat="server">
                                                           <%# DataBinder.Eval(Container.DataItem, "enunciado") %></asp:Label>
                                                       </itemtemplate>
                                                   </asp:templatecolumn>
                                                   <asp:templatecolumn HeaderText="Relaciona las columnas correctamente">
                                                       <headerstyle width="50%" />
                                                       <itemstyle  />
                                                       <itemtemplate>
                                                           <asp:DropDownList ID="drpChido" runat="server" 
                                                               DataSource="<%# GetOpciones() %>" DataTextField="Enunciado" 
                                                               DataValueField="idOR" CssClass="form-control">
                                                           </asp:DropDownList>
                                                       </itemtemplate>
                                                   </asp:templatecolumn>
                                               </columns>
                                        </asp:DataGrid>

       <div style="height:20px;"></div>
                   
                                   
 <div class="form-group">
  
    <div class="col-sm-12 text-center"> 
  <asp:Button ID="btnGrabar" runat="server" CssClass="btn btn-success" 
                                               Text="Grabar" />
                                           &nbsp;
                                           <asp:Button ID="btnBorrar" runat="server" CssClass="btn btn-danger" Text="Borrar" 
                                               Visible="False" />
        &nbsp;<asp:HyperLink ID="lnkSalirEdicion2" runat="server" Text="Cancelar"  CssClass="btn btn-default"></asp:HyperLink>
<asp:Label ID="lblParaBorrar" runat="server" 
                                               Text="¿Desea borrar este elemento?" Visible="False"></asp:Label>
    </div>
 </div>
                                       
                    
               </ContentTemplate>
                  <Triggers>
                    <asp:PostBackTrigger ControlID="btnGrabar" />
                    <asp:PostBackTrigger ControlID="btnAgregarOpcion0" />
                    <asp:PostBackTrigger ControlID="btnAgregarOpcion" />
                 </Triggers>

        </asp:UpdatePanel>


</div>
                  </div>
            </div>
   

    

</asp:Content>


