<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="CalificarExamen.aspx.vb" Inherits="Sec_SalonVirtual_CalificarExamen" title="Calificar examen" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>
<%@ Register src="Controles/DisplayRanking.ascx" tagname="DisplayRanking" tagprefix="uc3" %>
<%@ Register src="Controles/displayRespuestaArchivos.ascx" tagname="displayRespuestaArchivos" tagprefix="uc2" %>


<%@ Register src="Controles/displayRespuestasComentarios.ascx" tagname="displayRespuestasComentarios" tagprefix="uc333" %>


<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>


<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server"  Text="Calificar examen" ></asp:Label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/default.aspx" ></asp:HyperLink></li>
           <li><asp:HyperLink ID="lnkCurso" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/Sa/default.aspx" ></asp:HyperLink></li>
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Calificar examen" ></asp:Label></li>
    </ol>


   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">
   
     <uc22:MenuGeneral ID="MenuGeneral1" runat="server" />

</asp:Content>


<asp:Content ID="contentCentral" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">

	

     <div class="row">

        <div class="col-xs-3">
             <uc1:MenuSalonVirtual ID="MenuSalonVirtual2" runat="server" />
        </div>
        <div class="col-xs-7">

                        
            <div class="panel">
                <div class="panel-heading">
                        <h3 class="panel-title"> <asp:Label ID="actividad" runat="server" Text="Calificar examen" ></asp:Label></h3>
                </div>
                <div class="panel-body">

    <table id="Table3" border="0" cellpadding="0" cellspacing="0" 
         width="100%">
        <tr>
            <td>
                <table id="Table78" border="0" cellpadding="1" cellspacing="1" width="100%">
                 
                    <tr>
                        <td>
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                                displaymode="List" 
                                headertext="Los campos marcados con * son requeridos o no estan en el formato apropiado" />
                        </td>
                    </tr>
                  
                    <tr>
                        <td align="right" style="height:45px;">
                            <asp:Button ID="btnGrabar1" runat="server" CssClass="btn btn-success btn-sm" 
                                Text="Grabar" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DataGrid ID="dtgItem" runat="server" AutoGenerateColumns="False" 
                                 CssClass="table table-hover" DataKeyField="idPregunta" 
                                GridLines="None" Width="100%">
                                <SelectedItemStyle BackColor="#C1CDD8" />
                                <HeaderStyle Font-Bold="True" HorizontalAlign="Left" />
                                <Columns>
                                    <asp:TemplateColumn>
                                        <HeaderStyle Width="30px" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <asp:Image ID="Imagse9" runat="server" 
                                                ImageUrl='<%# "~/Images/" & DataBinder.Eval(Container.DataItem, "tipoPregunta") & "quest.gif" %>' />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Lista de preguntas">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                          
                                                        <asp:Label ID="lblPregunta" runat="server">
                                                        <%# GetEnunciado(DataBinder.Eval(Container.DataItem, "enunciado")) %>
                                                        </asp:Label>
                                                        <div style="height:3px;"></div>
                                                        <asp:Label ID="labelrespuestafront" runat="server" 
                                                            CssClass="Chica" Font-Bold="true"> Respuesta del alumno </asp:Label>
                                                  <div style="height:3px;"></div>
                                                        <asp:Literal ID="litRespuesta" runat="server"></asp:Literal>
                                                        <asp:PlaceHolder ID="myplaceholder" runat="server"></asp:PlaceHolder>
                                                    <div style="height:3px;"></div>
                                                        <asp:Label ID="lblclave" runat="server" 
                                                            CssClass="Chica" Font-Bold="true" ForeColor="Red"> Clave o guia del examen </asp:Label>
                                                 <div style="height:3px;"></div>
                                                        <asp:Literal ID="litClave" runat="server"></asp:Literal>
                                                     <div style="height:6px;"></div>
                                           
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Puntos">
                                        <HeaderStyle Width="50px" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <TABLE ID="Table7" border="0" cellPadding="0" cellSpacing="1" width="100%">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtValorObtenido" runat="server" Columns="4" MaxLength="4"  CssClass="form-control"
                                                            Text='<%# DataBinder.Eval(Container.DataItem, "tipoPregunta")%>'>
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RangeValidator ID="RangeValidator1" runat="server" 
                                                            ControlToValidate="txtValorObtenido" Display="Dynamic" 
                                                            MaximumValue='<%# DataBinder.Eval(Container.DataItem, "Valor")%>' 
                                                            MinimumValue="0" Type="Double">*</asp:RangeValidator>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                            ControlToValidate="txtValorObtenido" Display="Dynamic">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </TABLE>
                                            <TABLE ID="Tablessss7" border="0" cellPadding="0" cellSpacing="1" width="100%">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="LabelvalorFront" runat="server" CssClass="Mediana">
                                                        valor:</asp:Label>
                                                        &nbsp;
                                                        <asp:Label ID="lblval" runat="server" Font-Italic="True" ForeColor="Red">
                                                        <%# DataBinder.Eval(Container.DataItem, "valor")%> </asp:Label>
                                                    </td>
                                                </tr>
                                            </TABLE>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                            </asp:DataGrid>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="right">
                                <asp:Label ID="lblverdadero" runat="server" Text="Verdadero" Visible="False"></asp:Label>
                                <asp:Label ID="lblFalso" runat="server" Text="Falso" Visible="False"></asp:Label>
                                <asp:Button ID="btnGrabar2" runat="server" CssClass="btn btn-success btn-sm" 
                                    Text="Grabar" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="tablaCalificacion">
                            <div align="center" style="padding-top:60px; padding-bottom:30px;">
                                <asp:Button ID="btnBorrarRespuesta" runat="server" CssClass="btn btn-danger" 
                                    Text="Borrar respuestas del alumno" />
                                <cc1:ConfirmButtonExtender ID="btnBorrarRespuesta_ConfirmButtonExtender" 
                                    runat="server" 
                                    ConfirmText="Se borraran todas las repuestas del alumno de este examen. Deseas continuar?" 
                                    Enabled="True" TargetControlID="btnBorrarRespuesta">
                                </cc1:ConfirmButtonExtender>
                                &nbsp;</div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>


        </div>
                </div>


                   <div class="panel">
                <div class="panel-heading">
                        <h3 class="panel-title"><asp:Label ID="lbltitulodsd" runat="server" Text="Comentarios para el alumno"></asp:Label></h3>
                </div>
                <div class="panel-body">
                       
                        <uc333:displayRespuestasComentarios ID="displayRespuestasComentarios1" runat="server" />
                </div>
            </div>  


            </div>
            <div class="col-xs-2">


                 <div class="panel">
                <div class="panel-heading">
                        <h3 class="panel-title"><asp:Label ID="Label5" runat="server" Text="Alumno"></asp:Label></h3>
                </div>
                <div class="panel-body">
                       
                    <div style="text-align:center; padding-bottom:10px;">
                         <asp:Image ID="imgAlumno" runat="server" 
                                        ImageUrl="~/Sec/Usuarios/fotos/0100132.jpg" Height="100px" />

                  
                    </div>
                       





                   
                                                <asp:Label ID="Label1" runat="server"  Font-Bold="True" Text="Nombre del alumno:"></asp:Label><br />
                                           
                                                 <asp:Label ID="estudiante" runat="server" Font-Bold="True"></asp:Label>
                                           
                    <div style="height:3px;"></div>
                                                <asp:Label ID="lblfechaRegistro" runat="server" Font-Bold="True" Text="Fecha de envío:"></asp:Label><br />
                                           
                                                <asp:Label ID="fechaenvio" runat="server"></asp:Label>
                            <div style="height:3px;"></div>        
                    
                                         <asp:Label ID="lbltotalminutos" runat="server" CssClass="Mediana">Minutos 
                                                    utilizados</asp:Label>   
                    <br />
                    
                         <asp:Label ID="totalMinutos" runat="server"></asp:Label>
                     <div style="height:3px;"></div>  


                    <asp:Label ID="lblcalificacion" runat="server" CssClass="Mediana">Calificación</asp:Label>
                    <br />

                      <asp:Label ID="calificacion" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                    <asp:Label ID="lbltotaltodos" runat="server"  ForeColor="Green" Visible="false"></asp:Label>
                                                
                              <div style="height:10px;"></div>              
                                     
                                          
                                               
                                           
                                           
                                            
                                           
                              

                </div>
</div>
                     
             

          

          </div>


         </div>
    

        <asp:Label ID="labelCursosComoDocente" runat="server" Text="Cursos como docente" Visible="false"></asp:Label>
    <asp:Label ID="labelCursosComoAlumno" runat="server" Text="Cursos como alumno"  Visible="false"></asp:Label>



</asp:Content>

