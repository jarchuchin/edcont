<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="AddPOpcionMultiple.aspx.vb" Inherits="Sec_AddPOpcionMultiple" title="Opción multiple" ValidateRequest="false" %>
 <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1"  %>

<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc2" %>


<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Literal ID="Literal1" runat="server" Text="Editar pregunta opción múltiple" ></asp:Literal></h1>
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
                         <asp:Label ID="lblTitulobox" runat="server"  Text="Opción múltiple" ></asp:Label>
                     </h3>
            </div>

              <div class="panel-body">


    
      <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <div align="left" > <asp:Image ID="Image1" runat="server"  ImageUrl ="~/Images/indicator.gif" /><asp:Label ID="lbltexto" runat="server"   Text="Actualizando datos..." ></asp:Label></div>
                    </ProgressTemplate>
       </asp:UpdateProgress>
       <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional" >
               <ContentTemplate>




                   <asp:ValidationSummary ID="ValidationSummary1" runat="server"  CssClass="alert alert-danger"  displaymode="List" headertext="Los datos marcados con * (asterisco) son requeridos o son incorrectos" />


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
<asp:Label ID="lblPregunta" runat="server" text="Pregunta de opción múltiple"></asp:Label>
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

      
    <hr />



     <div class="form-group">
    <label class="col-sm-2 control-label"><asp:Label ID="lblOpciones" runat="server" text="Opciones"></asp:Label>
                           <asp:RequiredFieldValidator ID="validaOpcion" runat="server" 
                               ControlToValidate="txtOR" Display="Dynamic">*</asp:RequiredFieldValidator> 
       
                                       <asp:CustomValidator ID="CustomValidator2" runat="server" 
                                           ControlToValidate="FileUpload2" 
                                           ErrorMessage="Solo imágenes son permitidas para las opciones">*</asp:CustomValidator>
    </label>
    <div class="col-sm-10"> 
       <asp:TextBox ID="txtOR" runat="server" CssClass="form-control" placeholder="Coloca aquí una de las opciones" Height="50px" TextMode="MultiLine"></asp:TextBox> 
        <div style="height:4px;"></div>
        <asp:FileUpload ID="FileUpload2" runat="server"  CssClass="form-control"/>
             <div style="height:4px;"></div>                         
        <asp:Button ID="btnAgregarOpcion" runat="server" CssClass="btn btn-success btn-sm" Text="Agregar opción &gt;&gt;&gt;" />
                                  
    </div>
    </div>

   


                        <div class="form-group">
    <label class="col-sm-2 control-label">
    </label>
    <div class="col-sm-10">   <asp:DataGrid ID="dtgItem" runat="server" AutoGenerateColumns="False"  ShowHeader="false"
                               BackColor="White" BorderColor="#C1CDD8" DataKeyField="idOR" GridLines="None" 
                               Width="100%">
                               <selecteditemstyle backcolor="#C1CDD8" />
                               <headerstyle font-bold="True" horizontalalign="Left" />
                               <columns>

                                   <asp:templatecolumn>
                                    
                                       <itemstyle width="30px"  />
                                       <itemtemplate>
 <asp:ImageButton ID="Imagebutton1" runat="server" CommandName="Editar" 
                                                           ImageUrl="~/Images/si.png" ToolTip="Clic para actualizar esta opción" />

                                          </itemtemplate>
                                   </asp:templatecolumn>

                                    <asp:templatecolumn>
                                   
                                       <itemstyle width="30px"  />
                                       <itemtemplate>
                                          
                                                       <asp:ImageButton ID="Imagebutton2" runat="server" CausesValidation="False" 
                                                           CommandName="Borrar" ImageUrl="~/Images/no.png"  ToolTip="Clic para borrar esta opción"/>
                                                       <cc1:ConfirmButtonExtender ID="Imagebutton2_ConfirmButtonExtender" 
                                                           runat="server" TargetControlID="Imagebutton2" ConfirmText="¿Desea borrar esta opción?"> 
                                                       </cc1:ConfirmButtonExtender>
                                                  
                                       </itemtemplate>
                                   </asp:templatecolumn>
                                  
                                   <asp:templatecolumn >
                                       <itemstyle width="300px" />
                                       <itemtemplate>
                                       
                                                       <asp:TextBox ID="txtpreg" runat="server" Columns="30" Width="300px" cssClass="form-control" TextMode="MultiLine"  Height="30" Text='<%# DataBinder.Eval(Container.DataItem, "enunciado") %>' ></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"  ControlToValidate="txtpreg" Display="Dynamic">*</asp:RequiredFieldValidator>
                                                 
                                            <div style="height:5px;"></div>
             
                                       </itemtemplate>
                                   </asp:templatecolumn>


                                    <asp:templatecolumn>
                                      
                                       <itemstyle    verticalalign="Top" />
                                       <itemtemplate>
 <asp:HyperLink ID="imgopcionlink" runat="server" Target="_blank"    navigateurl='<%# getImagenOpcion(Eval("fileName"), Eval("idOR")) %>' Visible='<%# esvisbleOpcion(Eval("fileName")) %>' >
                                                        <asp:Image ID="imgOpcion" runat="server"  ImageUrl='<%# getImagenOpcion(Eval("fileName"), Eval("idOR")) %>' Visible='<%# esvisbleOpcion(Eval("fileName")) %>' Width="75px" />
                                                        </asp:HyperLink>

 </itemtemplate>
                                   </asp:templatecolumn>
                               </columns>
                           </asp:DataGrid>
    </div>
    </div>

       <hr />

                        <div class="form-group">
    <label class="col-sm-2 control-label"> <asp:Label ID="lblRespuesta" runat="server" text="Respuesta correcta"></asp:Label>
                           <asp:RequiredFieldValidator ID="ValidaCorrecta" runat="server" 
                               ControlToValidate="rdbOpcionesDisponibles" Display="Dynamic">*</asp:RequiredFieldValidator>
    </label>
    <div class="col-sm-10">  <asp:RadioButtonList ID="rdbOpcionesDisponibles" runat="server" CssClass="labelNormal">
                           </asp:RadioButtonList>
    </div>
    </div>


                    
   
    
     <div class="form-group">
    <label class="col-sm-2 control-label">

    </label>
    <div class="col-sm-10"> 
   <asp:Button ID="btnGrabar" runat="server" CssClass="btn btn-success" Text="Grabar" />
                               &nbsp;
                               <asp:Button ID="btnBorrar" runat="server" CssClass="btn btn-danger" Text="Borrar" 
                                   Visible="False" />
                               <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
                                   ConfirmText="¿Desea borrar esta preguta?" TargetControlID="btnBorrar">
                               </cc1:ConfirmButtonExtender>

          &nbsp;<asp:HyperLink ID="lnkSalirEdicion2" runat="server" Text="Cancelar"  CssClass="btn btn-default"></asp:HyperLink>
    </div>
    </div>



               </ContentTemplate>
               
                 <Triggers>
                    <asp:PostBackTrigger ControlID="btnGrabar" />
                     <asp:PostBackTrigger ControlID="btnAgregarOpcion" />
                 </Triggers>

               
               
        </asp:UpdatePanel>
       



</div>

                  </div>
            </div>
    
              
</asp:Content>

