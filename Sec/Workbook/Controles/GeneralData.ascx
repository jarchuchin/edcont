<%@ Control Language="VB" AutoEventWireup="false" CodeFile="GeneralData.ascx.vb" Inherits="Sec_Workbook_Controles_GeneralData" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>





 




    <div style="margin: auto; max-width: 100%; padding-top:15px;"  >

<div class="panel">
			<div class="panel-heading">
                <h3 class="panel-title"><asp:Label ID="Label6" runat="server" Text="Información general" meta:resourcekey="Label6Resource1"></asp:Label></h3>

            </div>
             <div class="panel-body">

 <asp:ValidationSummary ID="ValidationSummary1" runat="server" displaymode="List" headertext="Los datos marcados con * (asterisco) son requeridos o no estan en formato apropiado" CssClass="alert alert-danger" meta:resourcekey="ValidationSummary1Resource1" />

<div class="alert alert-success" id="alertSuccess" runat="server" visible="false">
  <span class="glyphicon glyphicon-saved"></span><strong>&nbsp; <asp:Label ID="Label10" runat="server" Text="Listo!" meta:resourcekey="Label10Resource1"></asp:Label>&nbsp;&nbsp; </strong> <asp:Label ID="Label9" runat="server" Text="Cambios realizados correctamente." meta:resourcekey="Label9Resource1"></asp:Label>
</div>


<div class="alert alert-danger" id="lblMensajeBorrar" runat="server" visible="false">
  <span class="glyphicon glyphicon-saved"></span><strong>&nbsp; <asp:Label ID="Label11" runat="server" Text="Error!" meta:resourcekey="Label11Resource1"></asp:Label>&nbsp;&nbsp; </strong> <asp:label id="lblMensajeBorrarinside" runat="server"  text="Para borrar, debes eliminar todos los elementos asociados (En caso de tener respuestas asociadas este elemento no podrá ser borrado)" meta:resourcekey="lblMensajeBorrarinsideResource1"></asp:label>
</div>


  <div class="form-horizontal" >

        <div class="form-group" id="pnlIdioma" runat="server" visible="false">

            <label class="col-sm-2 control-label">
                <asp:Label  ID="Label5" runat="server" text="Idioma" meta:resourcekey="Label5Resource1"></asp:Label>
            </label>
             <div class="col-sm-10">
                 <asp:Label  ID="lblIdioma" runat="server" meta:resourcekey="lblIdiomaResource1" ></asp:Label>
             </div>
        </div>


       <div class="form-group">

            <label class="col-sm-2 control-label">

                <asp:Label  ID="Label7" runat="server" text="Institución" ></asp:Label>
 
            </label>

            <div class="col-sm-10">

              <asp:DropDownList ID="drpEmpresas" runat="server" Enabled="false" class="form-control" Width="350px" Height="35px">

                </asp:DropDownList> 

              

               

            </div>
    </div>



    <div class="form-group">

            <label class="col-sm-2 control-label">

                <asp:Label  ID="lblNombre" runat="server" text="Nombre" meta:resourcekey="lblNombreResource1"></asp:Label>
  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                controltovalidate="txtTitulo" display="Dynamic" meta:resourcekey="RequiredFieldValidator1Resource1">*       </asp:RequiredFieldValidator>
            </label>

            <div class="col-sm-10">

                <asp:TextBox    ID="txtTitulo" runat="server" columns="40" maxlength="100" CssClass="form-control" meta:resourcekey="txtTituloResource1"></asp:TextBox>

              

                <asp:TextBox ID="txtId" runat="server" visible="False" CssClass="form-control" meta:resourcekey="txtIdResource1" ></asp:TextBox>

                <asp:TextBox ID="txtEmpresa" runat="server" visible="False" CssClass="form-control" meta:resourcekey="txtEmpresaResource1" ></asp:TextBox>

            </div>
    </div>

    <div class="form-group">

            <label class="col-sm-2 control-label">

                <asp:Label ID="lblDescripcion" runat="server"  text="Descripción general" meta:resourcekey="lblDescripcionResource1"></asp:Label>

            </label>


        <div class="col-sm-10">

          <%--  <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" 
                textmode="MultiLine" Height="170px"  ></asp:TextBox>--%>


              <asp:TextBox ID="txtDescripcion" runat="server" 
                                        TextMode="MultiLine"   CssClass="form-control" ClientIDMode="Static" meta:resourcekey="txtDescripcionResource1"></asp:TextBox>

             <script>
                 $(document).ready(function () {
                     $("#txtDescripcion").cleditor({
                         height: 170,
                         controls: // controls to add to the toolbar
                     "bold italic underline | font size " +
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
        
            <label class="col-sm-2 control-label"> <asp:Label ID="lbltags" runat="server"  text="Palabras claves" meta:resourcekey="lbltagsResource1"></asp:Label></label>
        <div class="col-sm-10">

            <asp:TextBox ID="txttags" runat="server" CssClass="form-control" 
                textmode="MultiLine" Height="60px" meta:resourcekey="txttagsResource1"  ></asp:TextBox>

        </div>

    </div>

        <div class="form-group">
        
            <label class="col-sm-2 control-label"> <asp:Label ID="Label1" runat="server"  text="Sugerencias para instructor" meta:resourcekey="Label1Resource1"></asp:Label></label>
        <div class="col-sm-10">

            <asp:TextBox ID="txtParaInstructor" runat="server" CssClass="form-control" 
                textmode="MultiLine" Height="60px" meta:resourcekey="txtParaInstructorResource1"  ></asp:TextBox>

        </div>

    </div>

      <div class="form-group">
        
            <label class="col-sm-2 control-label"> <asp:Label ID="Label2" runat="server"  text="Convenios y derechos de autor" meta:resourcekey="Label2Resource1"></asp:Label></label>
        <div class="col-sm-10">

            <asp:TextBox ID="txtConvenios" runat="server" CssClass="form-control" 
                textmode="MultiLine" Height="60px" meta:resourcekey="txtConveniosResource1"  ></asp:TextBox>

        </div>

    </div>
           
    <div class="form-group">

            <label class="col-sm-2 control-label">

            <asp:Label ID="lblautor" runat="server" 
                text="Autor" meta:resourcekey="lblautorResource1"></asp:Label>

            </label>

   

        <div class="col-sm-10">

            <asp:TextBox ID="txtAutor" runat="server" maxlength="100"  CssClass="form-control" meta:resourcekey="txtAutorResource1"></asp:TextBox>

        </div>

    </div>
            
  <%--  <div class="form-group">

            <label class="col-sm-2 control-label">

            <asp:Label ID="lblDescripcion1" runat="server" 
                text="Biblioteca" meta:resourcekey="lblDescripcion1Resource1"></asp:Label>

            </label>

  
          <div class="col-sm-10">
            <asp:DropDownList ID="drpBiblioteca" runat="server" Enabled="False"  CssClass="form-control" meta:resourcekey="drpBibliotecaResource1">

            <asp:ListItem meta:resourcekey="ListItemResource1">General</asp:ListItem>

            <asp:ListItem meta:resourcekey="ListItemResource2">Educación a distancia</asp:ListItem>

            </asp:DropDownList>
            </div>
    </div>--%>



       <div class="form-group">

            <label class="col-sm-2 control-label">

                 <asp:Label ID="Label3" runat="server" Font-Bold="True" meta:resourcekey="Label3Resource1">Archivo de certificación</asp:Label>

            </label>

  
          <div class="col-sm-10">
                <asp:TextBox ID="txtcertificacion" runat="server"  CssClass="form-control" placeholder="Liga a google doc" type="url" patter="https?://.+" meta:resourcekey="txtcertificacionResource1"></asp:TextBox>
          </div>
    </div>



         <div class="form-group">

            <label class="col-sm-2 control-label">

            <asp:Label ID="Label4" runat="server" 
                Font-Bold="True" Text="Idioma default" meta:resourcekey="Label4Resource1"></asp:Label>

            </label>

  
          <div class="col-sm-10">
            <asp:DropDownList ID="drpIdiomas" runat="server"    CssClass="form-control" meta:resourcekey="drpIdiomasResource1">
            </asp:DropDownList>
            </div>
    </div>


      <div style="height:25px;"></div>
      
    <div class="form-group">
         <label class="col-sm-2 control-label"></label>
                  <div class="col-sm-10">
            <asp:Button ID="btnGrabar" runat="server" CssClass="btn btn-success" 
                text="Grabar" meta:resourcekey="btnGrabarResource1" />&nbsp;<asp:Button ID="btnBorrar" runat="server" CssClass="btn btn-danger" Text="Borrar" CausesValidation="False" 
                Visible="False" meta:resourcekey="btnBorrarResource1" />

            <cc1:ConfirmButtonExtender ID="btnBorrar_ConfirmButtonExtender" runat="server" 
                ConfirmText="¿Deseas borrar este libro de trabajo?" Enabled="True" 
                TargetControlID="btnBorrar">

            </cc1:ConfirmButtonExtender>
 &nbsp;<asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-default"  CausesValidation="False"
                text="Cancelar" meta:resourcekey="btnCancelarResource1" />

             &nbsp;

            &nbsp;
                      </div>

    </div>


       

    <div style="height:50px;"></div>


      
    <div class="form-group">
         <label class="col-sm-2 control-label"></label>
                  <div class="col-sm-10">
                     
      <asp:Button ID="btngenerarpdf" runat="server" CssClass="btn btn-primary" Text="Generar pdf" 
                Visible="False" meta:resourcekey="btngenerarpdfResource1" />
                      
                       <asp:Button ID="btnClonar" runat="server" CssClass="btn btn-primary" Text="Clonar libro"  Visible="False" meta:resourcekey="btnClonarResource1" />     
            <cc1:ConfirmButtonExtender ID="btnClonar_ConfirmButtonExtender" runat="server" ConfirmText="¿Deseas clonar el libro                             y todo su contenido?" Enabled="True" TargetControlID="btnClonar">
            </cc1:ConfirmButtonExtender>
           

        
              </div>

    </div>

        
  
      <asp:Label ID="lblBorrarBotonIdioma" runat="server" Text="Quitar idioma" Visible="False" meta:resourcekey="lblBorrarBotonIdiomaResource1"></asp:Label>
      <asp:Label ID="lblconfirmIdioma" runat="server" Text="¿Deseas borrar este idioma?" Visible="False" meta:resourcekey="lblconfirmIdiomaResource1"></asp:Label>

<div style="height:30px;"></div>

</div>


                 </div>
    </div>

       


  </div>


