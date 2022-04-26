<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayVerTexto.ascx.vb" Inherits="Sec_Workbook_Controles_DisplayVerTexto" %>

<%@ Register src="~/Sec/Workbook/Controles/showadjuntos.ascx" tagname="showadjuntos" tagprefix="uc2" %>

<asp:Panel ID="panelContenidos" runat="server" Visible="false">
     








    
         
<div class="row">
	<div class="col-xs-9">
		<div class="panel">

            <div class="panel-heading">
           
                 <h3 class="panel-title">
                        <asp:label ID="txtTitulo" runat="server"></asp:label>
                     </h3>
            </div>
			
             <div class="panel-body">



				    <h5 >Descripcion del contenido</h5>
                    
                    <asp:Literal ID="literalDescripcion" runat="server"></asp:Literal>
                    <div style="height:5px"></div>
                    <asp:Literal ID="literalUrlFrameBox" runat="server"></asp:Literal>

				    <asp:Literal ID="literalTextoLargo" runat="server"></asp:Literal>

                      

                  <h5>
              <asp:Label ID="Label15" runat="server" text="Sugerencias para instructor" ></asp:Label>
        </h5>

               <asp:label ID="txtparaInstructor" runat="server" ></asp:label>


    

 


  



        <h5> <asp:Label ID="lbltags" runat="server" Text="Tags separados por comas" ></asp:Label>
        </h5>
       <asp:label ID="txttags" runat="server"  ></asp:label>



			  
                 </div>
            </div>



    </div>



    <div class="col-xs-3">
          
        
        <uc2:showadjuntos ID="showArchivosAdjuntos" runat="server" />
			    <uc2:showadjuntos ID="showDirecciones" runat="server" />
			    <uc2:showadjuntos ID="showImagenesAdjuntos" runat="server" />
			    <uc2:showadjuntos ID="showFlashes" runat="server" />




        </div>












</div>





















			

	

    <div style="page-break-after: always"></div>
</asp:Panel>