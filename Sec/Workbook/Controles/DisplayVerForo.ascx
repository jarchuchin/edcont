<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DisplayVerForo.ascx.vb" Inherits="Sec_Workbook_Controles_DisplayVerForo" %>




<asp:Panel ID="panelContenidos" runat="server" Visible="false">

    
         
<div class="row">
	<div class="col-xs-9">
		<div class="panel">

            <div class="panel-heading">
           
                 <h3 class="panel-title">
                       <asp:Label ID="lblnombreoriginal2" runat="server" Text=""></asp:Label>
                     </h3>
            </div>
			
             <div class="panel-body">

                        
							<h5 >Objetivo del foro</h5>
							<asp:Label ID="lblObjetivo" runat="server" Text="---"></asp:Label>
						


                        <h5>
							<asp:Label ID="lblFecha" runat="server"></asp:Label></h5>
						<asp:Literal ID="littexto" runat="server"></asp:Literal>
							
						

               <div style="height:15px;"></div>

         <asp:TextBox ID="txtMensaje" runat="server" Height="85px" TextMode="MultiLine" CssClass="form-control" ></asp:TextBox>
                             
            <div style="height:15px;"></div>



           

            
                <asp:Label ID="lblfile" runat="server" >Adjuntar archivo</asp:Label>
                <div style="height:5px;"></div>
                <asp:FileUpload ID="FileUpload1" runat="server" />
              <div style="height:15px;"></div>

            <asp:Button ID="btngrabar" runat="server" Text="Participar en foro"  CssClass="btn btn-primary" />
          
        </div>


        </div>

        </div>

    </div>
    <div style="page-break-after: always"></div>
    </asp:Panel>