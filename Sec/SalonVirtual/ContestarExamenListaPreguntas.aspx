<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="ContestarExamenListaPreguntas.aspx.vb" Inherits="Sec_SalonVirtual_ContestarExamenListaPreguntas" title="Lista de preguntas" %>

<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>
<%@ Register src="Controles/UbicadorPreguntas.ascx" tagname="UbicadorPreguntas" tagprefix="uc2" %>
<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>


<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server" Text="Cuaderno de apuntes"  ></asp:Label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Cursos como docente"  NavigateUrl="~/sec/default.aspx" ></asp:HyperLink></li>
         <li><asp:HyperLink ID="lnkCurso" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/Sa/default.aspx" ></asp:HyperLink></li>
          <li><asp:HyperLink ID="lnkUnidad" runat="server"  Text="Unidad"  ></asp:HyperLink></li>
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Editar apunte" ></asp:Label></li>
    </ol>


   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">
   
     <uc22:MenuGeneral ID="MenuGeneral1" runat="server" />

</asp:Content>




<asp:Content ID="contentCentral" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">



       <div class="row">

         <div class="col-xs-12">





	<div class="panel">
		

        <div class="panel-heading">
             <h3 class="panel-title">
               <asp:Label ID="lbltitulo" runat="server" CssClass="title-big">Lista de preguntas</asp:Label>
                /  <asp:Label ID="lbltituloexamen" runat="server" CssClass="Mediana"></asp:Label>
            </h3>
        </div>
		<div class="panel-body">



            <uc2:UbicadorPreguntas ID="UbicadorPreguntas1" runat="server" />

            <div style="height:15px"></div>  

            <asp:Label ID="Label4" runat="server" Text="Status del examen: " Font-Bold="true"></asp:Label> <asp:HyperLink ID="lnkstatusexa" runat="server" ></asp:HyperLink>

            <div style="height:15px"></div>  

             <asp:Label ID="lblmensajeautorizar" runat="server" Text="Usuario no autorizado para ver el examen" ForeColor="Red" Visible ="false"></asp:Label>


                <asp:DataGrid ID="dtgItem" runat="server" AutoGenerateColumns="False" 
                    CssClass="table table-striped" DataKeyField="idPregunta" 
                    GridLines="None" Width="100%">
           
                    <HeaderStyle Font-Bold="True" HorizontalAlign="Left" />
                    <Columns>

                          <asp:TemplateColumn>
                            <HeaderStyle Width="30px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# getContador() %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>

                        <asp:TemplateColumn>
                            <HeaderStyle Width="30px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" 
                                    ImageUrl='<%# "~/Images/" & DataBinder.Eval(Container.DataItem, "tipoPregunta") & "quest.gif"  %>' 
                                    NavigateUrl='<%#  GetLiga(CInt(DataBinder.Eval(Container.DataItem, "idPregunta")), CInt(DataBinder.Eval(Container.DataItem, "tipoPregunta")))%>'>
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Lista de preguntas">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemTemplate>
                                
                                <asp:Label ID="Label2" runat="server">
                                <%# GetEnunciado(DataBinder.Eval(Container.DataItem, "enunciado")) %>
                                </asp:Label>
                                <asp:Label ID="lbltipo" runat="server" 
                                    Text='<%# DataBinder.Eval(Container.DataItem, "tipoPregunta")%>' 
                                    Visible="False"> </asp:Label>
                                
                                <div style="height:5px"></div>    

                                            <asp:Label ID="labelrespuestafront" runat="server" Font-Bold="true">Respuesta</asp:Label>
                                      <div style="height:5px"></div>  
                                            <asp:Literal ID="litRespuesta" runat="server" ></asp:Literal>
                                     <div style="height:5px"></div>  
                                            
                                            <asp:Label ID="lblRespuestaCorrecta" runat="server" CssClass="Chica" ForeColor="Red"></asp:Label>
                                      
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Status">
                            <HeaderStyle Width="120px" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:HyperLink ID="lnkContestada" runat="server" 
                                    NavigateUrl='<%#  GetLiga(cint(DataBinder.Eval(Container.DataItem, "idPregunta")), cint(DataBinder.Eval(Container.DataItem, "tipoPregunta"))  )%>'>
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Valor">
                            <HeaderStyle Width="60px" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                            <ItemTemplate>
                                <asp:Label ID="lblPuntos" runat="server" CssClass="Chica" 
                                    Font-Bold="True"></asp:Label>
                                <asp:Label ID="Label1" runat="server" CssClass="Chica" 
                                    Font-Bold="True">
                                <%# DataBinder.Eval(Container.DataItem,"Valor", "{0:.##}" ) %> </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </asp:DataGrid>
                <hr size="1" width="100%" />
                <table id="Table6" border="0" cellpadding="1" cellspacing="1" width="100%">
                    <tr>
                        <td>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblTotalExamen" runat="server" CssClass="Mediana" Font-Bold="true">Valor total de las preguntas</asp:Label>
                        </td>
                        <td align="right" width="55">
                            <asp:Label ID="totalexamen" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
           

</div>
</div>


             </div>
           </div>

 <asp:Label ID="lblContestada" runat="server" Text="Contestada" Visible="False"></asp:Label>
                <asp:Label ID="lblnoContestada" runat="server" Text="No contestada" 
                    Visible="False"></asp:Label>
                <asp:Label ID="lblTerminarexamen" runat="server" Text="Terminar examen" 
                    Visible="False"></asp:Label>
                <asp:Label ID="lblExamenTerminado" runat="server" 
                    Text="El examen ha sido contestado" Visible="False"></asp:Label>
                <asp:Label ID="lblFalso" runat="server" Text="Falso" Visible="False"></asp:Label>
                <asp:Label ID="lblverdadero" runat="server" Text="Verdadero" Visible="False"></asp:Label>
                <asp:Label ID="lblGuia" runat="server" CssClass="Chica" Visible="False">Clave: </asp:Label>


       <asp:Label ID="labelCursosComoDocente" runat="server" Text="Cursos como docente" Visible="false"></asp:Label>
    <asp:Label ID="labelCursosComoAlumno" runat="server" Text="Cursos como alumno"  Visible="false"></asp:Label>


</asp:Content>

