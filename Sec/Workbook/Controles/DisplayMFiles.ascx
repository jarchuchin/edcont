<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayMFiles.ascx.vb" Inherits="Sec_Workbook_Controles_DisplayMFiles" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

  
      <h2 class="text-center"><asp:Label ID="Label1" runat="server" Text="Subir archivos" meta:resourcekey="Label1Resource1"  ></asp:Label> </h2>
   <div style="height:10px;"></div>
     <div class="form-horizontal" style="margin: auto; max-width: 650px;" >

      <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                         <asp:Image ID="Image1" runat="server"  ImageUrl ="~/Images/indicator.gif" meta:resourcekey="Image1Resource1" /><asp:Label ID="lbltexto" runat="server"   Text="Actualizando datos..." meta:resourcekey="lbltextoResource1" ></asp:Label>
                    </ProgressTemplate>
       </asp:UpdateProgress>
       <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional" >
               <ContentTemplate>


<div class="form-group">
    <label class="col-sm-3 control-label">
        <asp:Label ID="Label2" runat="server" Text="Libro de trabajo" meta:resourcekey="Label2Resource1"></asp:Label>
    </label>
    <div class="col-sm-9">
        <asp:Label ID="lblLibro" runat="server" meta:resourcekey="lblLibroResource1" ></asp:Label>
         <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                        displaymode="List" headertext="Los campos marcados con * son requeridos o no estan en formato apropiado" 
                                        Font-Bold="False" meta:resourcekey="ValidationSummary1Resource1" />
			      <asp:Label ID="lblNoarchivo" runat="server" ForeColor="Red" Visible="False" 
                                        text="Se esperaba una imagen. Selecciona la imagen e intenta nuevamente. Si es un archivo utiliza la forma para subir archivos" meta:resourcekey="lblNoarchivoResource1"></asp:Label>
                                    &nbsp;<asp:Label ID="lblMensajeBorrar" runat="server" ForeColor="Red" Visible="False" 
                                        text="Existen elementos relacionados con este contenido" meta:resourcekey="lblMensajeBorrarResource1"></asp:Label>
                                    <asp:Label ID="lblMensajeEspacio" runat="server" ForeColor="Red" 
                                        Visible="False"  Text="No hay espacio en su cuenta para subir este contenido" meta:resourcekey="lblMensajeEspacioResource1"></asp:Label>
    </div>
</div>

<div class="form-group">
    <label class="col-sm-3 control-label">
         <asp:Label ID="lblUbicacion" runat="server"   Text="Seleccionar unidad" meta:resourcekey="lblUbicacionResource1"></asp:Label>
    </label>
    <div class="col-sm-9">
         <asp:DropDownList ID="drpUbicacion" runat="server"  CssClass="form-control" ClientIDMode="Static" AutoPostBack="True" meta:resourcekey="drpUbicacionResource1" > </asp:DropDownList>
    </div>
</div>


<div class="form-group">
    <label class="col-sm-3 control-label">
        <asp:Label ID="lbltituloContenido" runat="server" Text="Archivos" meta:resourcekey="lbltituloContenidoResource1" ></asp:Label>
			
    </label>
    <div class="col-sm-9">
     
        <div id="fileuploader">Subir archivos</div>
        <asp:HiddenField ID="hdc" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdr" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdu" runat="server" ClientIDMode="Static" />  <asp:Button ID="btnRefrescar" runat="server" ClientIDMode="Static" CssClass="invisible" meta:resourcekey="btnRefrescarResource1" />

    </div>
</div>

<div class="form-group">
    <label class="col-sm-3 control-label">
      
    </label>
    <div class="col-sm-9">
      	<asp:Button ID="btnregresar" runat="server" CssClass="btn btn-default" Text="Cancelar" CausesValidation="False" meta:resourcekey="btnregresarResource1"   />

             
    </div>
</div>


<div class="form-group">
    <label class="col-sm-3 control-label">
    </label>
    <div class="col-sm-9">
    </div>
</div>



<div style="height:150px;"></div>



         
                 </ContentTemplate> 
                 

 </asp:UpdatePanel>    

</div>



<script type="text/javascript">
    $(document).ready(function () {



        $("#fileuploader").uploadFile({
            url: "UploadClasificacion.ashx?idr=" + document.getElementById("hdr").value + "&idc=" + document.getElementById("hdc").value + "&idu=" + document.getElementById("hdu").value,
            fileName: "myfile",
            dragDrop: true,
            afterUploadAll: function (obj) {
                $('#btnRefrescar').click();
            }
        });



    });
</script>