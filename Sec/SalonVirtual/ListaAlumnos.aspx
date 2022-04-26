<%@ Page Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="ListaAlumnos.aspx.vb" Inherits="Sec_SalonVirtual_ListaAlumnos" title="Lista de alumnos" %>

<%@ Register src="Controles/MenuSalonVirtual.ascx" tagname="MenuSalonVirtual" tagprefix="uc1" %>


<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelTitulo" runat="server">
    <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server"  Text="Lista de alumnos" ></asp:Label> </h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->

</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPanelBreadcrumb">


    
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Mis cursos"  NavigateUrl="~/sec/default.aspx" ></asp:HyperLink></li>
           <li><asp:HyperLink ID="lnkCurso" runat="server"  Text="Curso nombre"  NavigateUrl="~/sec/Sa/default.aspx" ></asp:HyperLink></li>
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Lista de alumnos" ></asp:Label></li>
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
        <div class="col-xs-9">

                        
            <div class="panel">
                <div class="panel-heading">
                        <h3 class="panel-title"><asp:Label ID="lblCalendario" runat="server" Text="Lista de alumnos"></asp:Label> </h3>
                   &nbsp;  <asp:HyperLink ID="lnkVerTodos" CssClass="btn btn-success btn-sm pull-right" NavigateUrl="ListaAlumnos.aspx?display=t" runat="server">Ver todos los alumnos</asp:HyperLink>

                      &nbsp;<asp:HyperLink runat="server" ID="lnkNuevoAlumno" Text="Inscribir alumno" NavigateUrl="BuscaAlumno.aspx" CssClass="btn btn-primary btn-sm pull-right"></asp:HyperLink> 

                </div>
                <div class="panel-body">

                
                  
                          <div style="height:3px;"></div>
                       <asp:GridView ID="gvListaAlumnos" runat="server" AllowSorting="True"   CssClass="table table-hover table-striped"
                               DataKeyNames="idUserProfile" AutoGenerateColumns="False" Width="100%" 
                               GridLines="None">
                           <columns>
                               <asp:TemplateField >
                                    <ItemTemplate >
                                        <asp:Label ID="lblNumero" runat="server" Text='<%# numero %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10px" />
                                    <ItemStyle HorizontalAlign="Center" Width="10px" />
                                </asp:TemplateField>
                                
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                       <asp:CheckBox ID="chkAll" onclick="javascript:SelectAllCheckboxesSpecific(this);" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate >
                                        <asp:CheckBox ID="chkSeleccion" runat="server" />
                                        <asp:Label ID="lblClave" runat="server" Text='<%# Eval("idUserProfile") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="20px" HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                                </asp:TemplateField>
                           
                          

                                  <asp:TemplateField >
                                    <ItemTemplate >
                                        <asp:HyperLink ID="lnkimagen" runat="server" 
                                            NavigateUrl='<%# Eval("idSalonVirtual", "EvaluacionPorAlumno.aspx?idSalonVirtual={0}") & Eval("idUserProfile", "&idUserProfile={0}") %>' 
                                             
                                              ToolTip="Clic para ver los detalles de evaluación"
                                            > <asp:Image runat="server" ID="imgAlumno" ImageUrl='<%# getImagen(Eval("claveAux1"), Eval("idUserProfile"))  %>' Width="45px" Height="45px" /></asp:HyperLink>
                                       
                                    </ItemTemplate>
                                    <HeaderStyle Width="45px" />
                                    <ItemStyle HorizontalAlign="Center" Width="45px" />
                                </asp:TemplateField>

                              
                                <asp:TemplateField HeaderText="Apellidos" SortExpression="Apellidos">
                                    <ItemTemplate >
                                           <asp:HyperLink ID="lnkapellidos" runat="server" 
                                            NavigateUrl='<%# Eval("idSalonVirtual", "EvaluacionPorAlumno.aspx?idSalonVirtual={0}") & Eval("idUserProfile", "&idUserProfile={0}") %>' 
                                             CssClass="btn-link"
                                              ToolTip="Clic para ver los detalles de evaluación"
                                            Text='<%# eval("Apellidos") %>'></asp:HyperLink>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left"  />
                                 </asp:TemplateField> 
                                 
                                 
                                  <asp:TemplateField HeaderText="Nombre" SortExpression="Nombre">
                                    <ItemTemplate >
                                           <asp:HyperLink ID="lnknombre" runat="server" 
                                            NavigateUrl='<%# Eval("idSalonVirtual", "EvaluacionPorAlumno.aspx?idSalonVirtual={0}") &  Eval("idUserProfile", "&idUserProfile={0}") %>' 
                                             CssClass="btn-link"
                                              ToolTip="Clic para ver los detalles de evaluación"
                                            Text='<%# eval("Nombre") %>'></asp:HyperLink>
                                    </ItemTemplate>
                                     <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left"  />
                                 </asp:TemplateField> 
                                
                              
                               
                               
                               
                               
                                <asp:boundfield DataField="claveAux1" HeaderText="Matrícula" 
                                   HtmlEncode="False" SortExpression="claveAux1"><HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center"  /></asp:boundfield>
                                   
                                   <asp:boundfield DataField="asistencia" HeaderText="Asistencia" 
                                   HtmlEncode="False" SortExpression="Asistencia"><HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center"  /></asp:boundfield>
                                    <asp:boundfield DataField="retraso" HeaderText="Retraso" 
                                   HtmlEncode="False" SortExpression="retraso"><HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center"  /></asp:boundfield>
                                   <asp:boundfield DataField="inasistencia" HeaderText="inasistencia" 
                                   HtmlEncode="False" SortExpression="inasistencia"><HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center"  /></asp:boundfield>
                                   
                                   <asp:TemplateField HeaderText="Calificación">
                                    <ItemTemplate >
                                           <asp:HyperLink ID="HysperLink1" runat="server" 
                                            NavigateUrl='<%# Eval("idSalonVirtual", "EvaluacionPorAlumno.aspx?idSalonVirtual={0}") &  Eval("idUserProfile", "&idUserProfile={0}") %>' 
                                             CssClass="LigaVerde"
                                              ToolTip="Detalles de evaluación"
                                            Text='<%# getcalificacion(eval("idUserProfile")) %>'>'></asp:HyperLink>
                                    </ItemTemplate>
                                   <HeaderStyle Width="20px" />
                                    <ItemStyle HorizontalAlign="Center" Width="50px"  />
                                </asp:TemplateField> 
                                


                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink2xxxw" runat="server" 
                                            NavigateUrl='<%# Eval("idSalonVirtual", "EnviarCorreo.aspx?idSalonVirtual={0}") & Eval("email", "&correos={0}")%>' 
                                           
                                            ImageUrl="~/images/IconEmail.jpg"
                                             ImageWidth="25px"
                                            Text="Enviar Email"></asp:HyperLink>
                                    </ItemTemplate>
                                    <HeaderStyle Width="25px" />
                                    <ItemStyle HorizontalAlign="Center" Width="25px" />
                                </asp:TemplateField>
                                    
                                  <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink2" runat="server" 
                                            NavigateUrl='<%# Eval("idSalonVirtual", "Accesos.aspx?idSalonVirtual={0}") &  Eval("idUserProfile", "&idUserProfile={0}")%>' 
                                            ToolTip="Accesos al curso"
                                            ImageUrl="~/images/miniiconacceso.jpg"
                                            Text="Accesos"></asp:HyperLink>
                                    </ItemTemplate>
                                    <HeaderStyle Width="20px" />
                                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                                </asp:TemplateField>
                                    
                                <asp:boundfield DataField="numeroEntradas"
                                   HtmlEncode="False" SortExpression="numeroEntradas">
                                   <ItemStyle  Width="20px"/>
                                </asp:boundfield>
                                   
                                   
                           </columns>
                           
                         
                       </asp:GridView>
                        <input type="hidden" name="checkboxParentHidden" id="checkboxParentHidden" runat="server" />
                   
                       
                           <asp:LinkButton ID="lnkEnviarCorreo2" CssClass="btn btn-success" runat="server">Enviar correo</asp:LinkButton>
                 
                       
                       <asp:Label ID="labelCursosComoDocente" runat="server" Text="Cursos como docente" Visible="false"></asp:Label>
    <asp:Label ID="labelCursosComoAlumno" runat="server" Text="Cursos como alumno"  Visible="false"></asp:Label>

                </div>

                </div>

            </div>

        </div>

    


<script language="javascript" type="text/javascript">

       function SelectAllCheckboxesSpecific(spanChk)
       {
           var IsChecked = spanChk.checked;
           var Chk = spanChk;

              Parent = document.getElementById('ctl00_ContentPanelCentral_gvListaAlumnos');      
              var items = Parent.getElementsByTagName('input');                          
            
              for(i=0;i<items.length;i++)

              {                
                  if(items[i].id != Chk && items[i].type=="checkbox")
                  {            
                      if(items[i].checked!= IsChecked)
                      {     
                          items[i].click();     
                      }
                  }
              }             
       }


 </script>



   

              
     

</asp:Content>

