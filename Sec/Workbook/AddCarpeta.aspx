<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="AddCarpeta.aspx.vb" Inherits="Sec_Workbook_AddCarpeta" title="Editar datos de carpetas" ValidateRequest="False" meta:resourcekey="PageResource1" uiculture="auto" Culture="auto" %>



<%@ Register src="Controles/Menu.ascx" tagname="Menu" tagprefix="uc1" %>




<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc2" %>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Literal ID="Literal1" runat="server" Text="Editar unidad" meta:resourcekey="Literal1Resource1"></asp:Literal></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">



     <uc2:MenuGeneral ID="MenuGeneral1" runat="server" />



</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPanelBreadcrumb" Runat="Server">
    <ol class="breadcrumb" >
  <li><asp:HyperLink ID="lnkSalirEdicion" runat="server" Text="Salir de edición" meta:resourcekey="lnkSalirEdicionResource1" ></asp:HyperLink>
      </li>
        </ol>
	
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPanelCentral">

 

		<div class="panel">

              <div class="form-horizontal">
              <div class="panel-body">

                 


<div class="form-group">

    <label class="col-sm-2 control-label">
        <asp:Label ID="Label5" runat="server" Text="Libro de trabajo" meta:resourcekey="Label5Resource1"></asp:Label>
    </label>
    <div class="col-sm-10">
        <asp:Label ID="lbllibro" runat="server" meta:resourcekey="lbllibroResource1" ></asp:Label>
    </div>

</div>


<div class="form-group">

    <label class="col-sm-2 control-label">
        <asp:Label ID="Label2" runat="server" Text="Título de la unidad" meta:resourcekey="Label2Resource1"></asp:Label>&nbsp;
		<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitulo" Display="Dynamic" meta:resourcekey="RequiredFieldValidator1Resource1">*</asp:RequiredFieldValidator>
    </label>
    <div class="col-sm-10">
        <asp:TextBox ID="txtTitulo" runat="server"  CssClass="form-control" meta:resourcekey="txtTituloResource1"></asp:TextBox>
    </div>

</div>




<div class="form-group">

    <label class="col-sm-2 control-label">
        <asp:Label ID="Label1" runat="server" Text="Planteamiento breve" meta:resourcekey="Label1Resource1"></asp:Label>
    </label>
    <div class="col-sm-10">
    <%--    <asp:TextBox ID="txtPlanteamientoBreve" runat="server" Height="70px" TextMode="MultiLine"  CssClass="form-control"></asp:TextBox>--%>

         <asp:TextBox ID="txtPlanteamientoBreve" runat="server" 
                                        TextMode="MultiLine"   CssClass="form-control" ClientIDMode="Static" meta:resourcekey="txtPlanteamientoBreveResource1"></asp:TextBox>

             <script>
                 $(document).ready(function () {
                     $("#txtPlanteamientoBreve").cleditor({
                         height: 120,
                         controls: // controls to add to the toolbar
                     "bold italic underline strikethrough subscript superscript | font size " +
                     "style | color highlight removeformat | bullets numbering | outdent " +
                     "indent | alignleft center alignright justify | undo redo | " +
                     "rule image link unlink | cut copy paste pastetext | print source",
                         fonts: // font names in the font popup
                    "Verdana, Arial,Arial Black,Comic Sans MS,Courier New,Narrow,Garamond," +
                    "Georgia,Impact,Sans Serif,Serif,Tahoma,Trebuchet MS",
                         bodyStyle:
                             "margin:4px; font:10pt Verdana,Arial; cursor:text"
                     });

                 });
            </script>

    </div>

</div>


<div class="form-group">

    <label class="col-sm-2 control-label">
        <asp:Label ID="Label8" runat="server" Text="Examen de diagnóstico" meta:resourcekey="Label8Resource1"></asp:Label>
    </label>
    <div class="col-sm-10">
        <asp:DropDownList ID="drpDiagnostico" runat="server"  CssClass="form-control"  Height="30px" meta:resourcekey="drpDiagnosticoResource1">
			</asp:DropDownList>
    </div>

</div>




<div class="form-group">
     <label class="col-sm-2 control-label">
         <asp:Label ID="Label6" runat="server" Text="Descripción" meta:resourcekey="Label6Resource1"></asp:Label>
    </label>
     <div class="col-sm-10">
       



          <asp:TextBox ID="txttexto" runat="server" 
                                        TextMode="MultiLine"   CssClass="form-control" ClientIDMode="Static" meta:resourcekey="txttextoResource1"></asp:TextBox>

             <script>
                 $(document).ready(function () {
                     $("#txttexto").cleditor({
                         height: 350,
                         controls: // controls to add to the toolbar
                     "bold italic underline strikethrough subscript superscript | font size " +
                     "style | color highlight removeformat | bullets numbering | outdent " +
                     "indent | alignleft center alignright justify | undo redo | " +
                     "rule image link unlink | cut copy paste pastetext | print source",
                         fonts: // font names in the font popup
                    "Verdana, Arial,Arial Black,Comic Sans MS,Courier New,Narrow,Garamond," +
                    "Georgia,Impact,Sans Serif,Serif,Tahoma,Trebuchet MS",
                         bodyStyle:
                             "margin:4px; font:10pt Verdana,Arial; cursor:text"
                     });

                 });
            </script>

     

        
    </div>
</div>

<div class="form-group">

    <label class="col-sm-2 control-label">
         <asp:Label ID="Label3" runat="server" Text="Imagen para cabecera" meta:resourcekey="Label3Resource1"></asp:Label>
    </label>
    <div class="col-sm-10">
        <asp:FileUpload ID="FileUpload1" runat="server" Width="267px"  CssClass="form-control" meta:resourcekey="FileUpload1Resource1" />
        <div style="height:10px;"></div>
        <asp:Image ID="img1" runat="server"   Height="150px" Visible="False" meta:resourcekey="img1Resource1"/>&nbsp;
			<asp:LinkButton ID="lnkBorrar1" runat="server" CausesValidation="False" Visible="False" CommandName="1" OnClick="lnkBorrarImg_Click" meta:resourcekey="lnkBorrar1Resource1">Quitar imagen</asp:LinkButton>
    </div>

</div>

<div class="form-group">

    <label class="col-sm-2 control-label">
        <asp:Label ID="Label4" runat="server" Text="Dia de presentación" meta:resourcekey="Label4Resource1"></asp:Label>
			<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtdiadisplay" CssClass="Mediana" Display="Dynamic" meta:resourcekey="RequiredFieldValidator2Resource1">*</asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtdiadisplay" MaximumValue="1000" MinimumValue="0" Type="Integer" Display="Dynamic" meta:resourcekey="RangeValidator1Resource1">0-1000</asp:RangeValidator>
			<asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtdiadisplay" Display="Dynamic" meta:resourcekey="CustomValidator1Resource1">*</asp:CustomValidator>
    </label>
    <div class="col-sm-10">
        <asp:TextBox ID="txtdiadisplay" runat="server" Width="40px"  CssClass="form-control" meta:resourcekey="txtdiadisplayResource1">1</asp:TextBox>
			
    </div>

</div>

<div class="form-group">

    <label class="col-sm-2 control-label">

    </label>
    <div class="col-sm-10">
        <asp:CheckBox ID="chkstatus" runat="server" Checked="True" Text="La carpeta está visible"  CssClass="checkbox-inline" meta:resourcekey="chkstatusResource1" />
    </div>

</div>

    
<div class="form-group">

    <label class="col-sm-2 control-label">

    </label>
    <div class="col-sm-10">

        
					<asp:Label ID="lblmensajeBorrar" runat="server" CssClass="Mediana" ForeColor="Red" Text="No se puede borrar porque existen elementos asociados a esta carpeta" Visible="False" meta:resourcekey="lblmensajeBorrarResource1"></asp:Label>
					<asp:Label ID="lblmensajeimagenes" runat="server" CssClass="Mediana" ForeColor="Red" Text="Los archivos deben ser imagenes" Visible="False" meta:resourcekey="lblmensajeimagenesResource1"></asp:Label>
	
			</div>	

</div>




   


                  </div>
                  <div class="panel-footer">
                      <div class="row">
                          <div class="col-sm-10 col-sm-offset-2">
<asp:Button ID="btnGrabar1" runat="server" Text="Grabar" CssClass="btn btn-success" meta:resourcekey="btnGrabar1Resource1"  />&nbsp;
					<asp:Button ID="btnBorrar1" runat="server" Text="Borrar" Visible="False" CssClass="btn btn-danger" meta:resourcekey="btnBorrar1Resource1" />
					<ajaxToolkit:ConfirmButtonExtender ID="btnBorrar1_ConfirmButtonExtender" runat="server" ConfirmText="" TargetControlID="btnBorrar1" Enabled="True">
                    </ajaxToolkit:ConfirmButtonExtender>
                    &nbsp;
					<asp:Button ID="btnregresar" runat="server" CssClass="btn btn-default" Text="Cancelar" CausesValidation="False" meta:resourcekey="btnregresarResource1"   /><br />

                          </div>
                      </div>
                  </div>
            </div>

            </div>
    
    
	
</asp:Content>

