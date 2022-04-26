<%@ Page Title="" Language="VB" MasterPageFile="~/MPDiamante03.master" AutoEventWireup="false" CodeFile="configurarAC.aspx.vb" Inherits="Sec_Administracion_configurarAC" %>

<%@ Register src="../Controles/MenuGeneral.ascx" tagname="MenuGeneral" tagprefix="uc22" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPanelTitulo" Runat="Server">

      <!--Page Title-->
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <div id="page-title">
        <h1 class="page-header text-overflow"><asp:Label ID="lblNombreTitulo" runat="server" Text="Configurar actividades"  ></asp:Label></h1>
    </div>
    <!--~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~-->
    <!--End page title-->


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPanelBreadcrumb" Runat="Server">
     
   
    <ol class="breadcrumb">
      <li><asp:HyperLink ID="lnkHome" runat="server" Text="Inicio" NavigateUrl="~/sec/home.aspx"></asp:HyperLink></li>

    
      <li><asp:HyperLink ID="lnkMisCursos" runat="server"  Text="Administración"  NavigateUrl="~/sec/Administracion/home.aspx" ></asp:HyperLink></li>
       
       
      <li class="active"><asp:Label ID="lblCursoBread" runat="server"  Text="Configurar de actividades" ></asp:Label></li>
    </ol>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPanelCentral" Runat="Server">
       <div class="row">

 
        <div class=" col-sm-12 col-md-8 col-lg-6">


              
                <div class="panel">
                    <div class="panel-heading">

                           <h3 class="panel-title">
                                <asp:Label ID="lblTitulo" runat="server" Text="Configurar de actividad"></asp:Label>
                            </h3>
                    </div>
                    <div class="panel-body">

                          <div class="form-horizontal" >


                               <div class="form-group">

                                <label class="col-sm-3 control-label">

                                    <asp:Label  ID="lblNombre" runat="server" text="Nombre" ></asp:Label>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  controltovalidate="txtNombre" display="Dynamic">*       </asp:RequiredFieldValidator>
                                </label>

                                <div class="col-sm-9">

                                    <asp:TextBox    ID="txtNombre" runat="server"  maxlength="150" CssClass="form-control" ></asp:TextBox>

              

                               

                                </div>
                        </div>






                              
                               <div class="form-group">

                                <label class="col-sm-3 control-label">

                                    <asp:Label  ID="Label1" runat="server" text="Tipo" ></asp:Label>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="El tipo es un campo requerido"  controltovalidate="drpTipoHP" display="Dynamic">*       </asp:RequiredFieldValidator>
                                </label>

                                <div class="col-sm-9">

                                    <asp:DropDownList ID="drpTipoHP" runat="server" CssClass="form-control" Width="200px" Height="28px">
                                        <asp:ListItem Value="Basica">Básica</asp:ListItem>
                                        <asp:ListItem>Alta</asp:ListItem>
                                    </asp:DropDownList>

                                    

                                </div>
                        </div>




                                <div class="form-group">

                                <label class="col-sm-3 control-label">

                                    <asp:Label  ID="Label2" runat="server" text="Minutos requerido" ></asp:Label>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  controltovalidate="txtTiempoRealizacion" display="Dynamic">*       </asp:RequiredFieldValidator>
                                </label>

                                <div class="col-sm-9">

                                   <asp:TextBox ID="txtTiempoRealizacion" placeholder="Tiempo necesario para realizar la actividad" runat="server"  TextMode="Number"  min="0" max="500"  CssClass="form-control" ></asp:TextBox>
                                    

                                </div>
                        </div>




                                 <div class="form-group">

                                <label class="col-sm-3 control-label">

                                    <asp:Label  ID="Label3" runat="server" text="Formato sugerido" ></asp:Label>
                   
                                </label>

                                <div class="col-sm-9">

                                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                                    <div style="height:10px;"></div>
                                    <asp:HyperLink ID="lnkFileFormato" Visible="false" CssClass="btn-link" runat="server">Descargar</asp:HyperLink>
                                </div>
                        </div>




                                 <div class="form-group">

                                <label class="col-sm-3 control-label">

                                    <asp:Label  ID="Label4" runat="server" text="Ejemplo sugerido" ></asp:Label>
                    
                                </label>

                                <div class="col-sm-9">

                                    <asp:FileUpload ID="FileUpload2" runat="server" CssClass="form-control" />
                                       <div style="height:10px;"></div>
                                    <asp:HyperLink ID="lnkFileEjemplo" Visible="false" CssClass="btn-link" runat="server">Descargar</asp:HyperLink>

                                </div>
                        </div>






                               <div class="form-group">

                                    <div class="col-sm-12 text-right">

                                        <asp:Button ID="btnGrabar" runat="server" Text="Grabar" CssClass="btn btn-success" />
                                        <asp:Button ID="btnBorrar" runat="server" Text="Borrar" CssClass="btn btn-danger" />
                                         <asp:Button ID="btnregresar" runat="server" Text="Regresar" CssClass="btn btn-default"  />


                                        </div>

                                   </div>


                            </div>



                    </div>
                </div>

            </div>

          </div>


</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPanelMenu" Runat="Server">
    
     <uc22:MenuGeneral ID="MenuGeneral1" runat="server" />

</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceFooterScripts" Runat="Server">

   
</asp:Content>

